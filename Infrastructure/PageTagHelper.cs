using INTEXAPP2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace INTEXAPP2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "link-maker")]
    public class PageTagHelper : TagHelper
    {
        // get access to the IUrlHelperFactory
        public PageTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        private IUrlHelperFactory uhf;

        //Create ViewContext
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        //Get access to the PageDetails Class
        public PageDetails LinkMaker { get; set; }

        //Following along with Bootstrap section
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string PageClassDisabled { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Create a url helper
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            //Create the finished tag
            TagBuilder finishedProduct = new TagBuilder("div");

            //Should we include the first button
            if (LinkMaker.CurrentPage != 1)
            {

                //Create the first page button
                TagBuilder first = new TagBuilder("a");

                if (PageClassesEnabled)
                {
                    first.AddCssClass(PageClass);
                    first.AddCssClass(1 == LinkMaker.CurrentPage
                        ? PageClassDisabled : PageClassNormal);
                    first.Attributes["href"] = 1 == LinkMaker.CurrentPage
                        ? "#" : uh.Action(PageAction, new { pageNum = 1 });
                }
                //first.Attributes["href"] = uh.Action(PageAction, new { pageNum = 1 });
                first.InnerHtml.AppendHtml("First");

                finishedProduct.InnerHtml.AppendHtml(first);

                //Create the next page button

                TagBuilder LastPage = new TagBuilder("a");

                if (PageClassesEnabled)
                {
                    LastPage.AddCssClass(PageClass);
                    LastPage.AddCssClass(PageClassNormal);
                    LastPage.Attributes["href"] = uh.Action(PageAction, new { pageNum = LinkMaker.CurrentPage - 1 });
                }
                LastPage.InnerHtml.AppendHtml("<<");

                finishedProduct.InnerHtml.AppendHtml(LastPage);
               
            }

            //Make sure the start is always above 1
            int start = 3 > LinkMaker.CurrentPage ? 0 : LinkMaker.CurrentPage-3;

            //Make sure the end does not go beyond the number of pages we have
            int end = (LinkMaker.TotalPages - 3) < LinkMaker.CurrentPage ? LinkMaker.TotalPages : LinkMaker.CurrentPage + 3; 

            for (int i = start; i < end; i++)
            {
                //Create a tags
                TagBuilder tagBuilder = new TagBuilder("a");
                //Set their attribute
                tagBuilder.Attributes["href"] = uh.Action(PageAction, new { pageNum = i + 1 });
                //Toggling colors
                if (PageClassesEnabled)
                {
                    tagBuilder.AddCssClass(PageClass);
                    tagBuilder.AddCssClass(i + 1 == LinkMaker.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                //Add the number as the text on screen
                tagBuilder.InnerHtml.Append((i + 1).ToString());
                //Add the finished tag to the html of the final product
                finishedProduct.InnerHtml.AppendHtml(tagBuilder);
            }

            if(LinkMaker.CurrentPage != LinkMaker.TotalPages)
            {
                TagBuilder NextPage = new TagBuilder("a");

                if (PageClassesEnabled)
                {
                    NextPage.AddCssClass(PageClass);
                    NextPage.AddCssClass(PageClassNormal);
                    NextPage.Attributes["href"] = uh.Action(PageAction, new { pageNum = LinkMaker.CurrentPage + 1 });
                }
                NextPage.InnerHtml.AppendHtml(">>");

                finishedProduct.InnerHtml.AppendHtml(NextPage);

                TagBuilder last = new TagBuilder("a");

                if (PageClassesEnabled)
                {
                    last.AddCssClass(PageClass);
                    last.AddCssClass(LinkMaker.TotalPages == LinkMaker.CurrentPage
                        ? PageClassDisabled : PageClassNormal);
                    last.Attributes["href"] = LinkMaker.TotalPages == LinkMaker.CurrentPage
                        ? "#" : uh.Action(PageAction, new { pageNum = LinkMaker.TotalPages });
                }
                //last.Attributes["href"] = uh.Action(PageAction, new { pageNum = LinkMaker.TotalPages });
                last.InnerHtml.AppendHtml("Final");

                finishedProduct.InnerHtml.AppendHtml(last);

                

            }
            

            //Set the output's innerhtml to the finished product's inner htmld
            output.Content.AppendHtml(finishedProduct.InnerHtml);
        }
    }
}
