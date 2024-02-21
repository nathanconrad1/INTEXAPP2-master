using INTEXAPP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace INTEXAPP2.Componets
{
    public class TypesViewComponent : ViewComponent
    {
        private mummiesContext repo { get; set; }

        public TypesViewComponent(mummiesContext temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var sex = repo.Burialmains
            .Select(x => x.Sex)
            .Distinct()
            .OrderBy(e => String.IsNullOrEmpty(e));

            var age = repo.Burialmains
            .Select(t => t.Ageatdeath)
            .Distinct()
            .OrderBy(e => String.IsNullOrEmpty(e));

            var direction = repo.Burialmains
            .Select(d => d.Headdirection)
            .Distinct()
            .OrderBy(e => String.IsNullOrEmpty(e))
            
            ;

            

            List<IOrderedQueryable> li = new List<IOrderedQueryable> ();
            li.Add(sex);
            li.Add(age);
            li.Add(direction);

            return View(li);
        }
    }
}
