using INTEXAPP2.Models;
using Microsoft.AspNetCore.Authorization;
using INTEXAPP2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Crypto;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using Nancy.Json;
using System.Drawing.Text;

namespace INTEXAPP2.Controllers
{
    public class HomeController : Controller
    {

        private mummiesContext Context { get; set; }
        private mummiesContext Context1 { get; set; }
        private mummiesContext Context2 { get; set; }
        private mummiesContext Context3 { get; set; }
        private IHttpContextAccessor httpContextAccessor { get; set; }

        public HomeController(ILogger<HomeController> logger, mummiesContext mc, mummiesContext mc1, mummiesContext mc2, mummiesContext mc3, IHttpContextAccessor _httpContextAccessor)
        {

            Context = mc;
            Context1 = mc1;
            Context2 = mc2;
            Context3 = mc3;
            httpContextAccessor = _httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BurialSummary(string filter, int pageNum = 1)
        {

            


            //Check to see if there is a cookie called "filters" and if not, create one
            if(httpContextAccessor.HttpContext.Request.Cookies["filters"] == null)
            {
                var cookieOptions = new CookieOptions();
                cookieOptions.Domain = httpContextAccessor.HttpContext.Request.Host.Value;
                cookieOptions.Path = httpContextAccessor.HttpContext.Request.Path;
                httpContextAccessor.HttpContext.Response.Cookies.Append("filters", "hello,this,is,my,stuff", cookieOptions);
            }


            

            // Set page length
            int pageLen = 10;
            List<SummaryView> summaryViews = new List<SummaryView>();

            //IQueryable<Burialmain> burialmains = new IQueryable<Burialmain>();

            if (filter == "M" || filter == "F")
            {
                IQueryable<Burialmain> burialmains = Context.Burialmains
                .Where(f => f.Sex == filter || filter == null)
                .OrderBy(f => f.Sex)
                .Skip((pageNum - 1) * pageLen).Take(pageLen);

                foreach (var b in burialmains)
                {
                    SummaryView summary = new SummaryView
                    {


                        Id = b.Id,
                        sex = b.Sex,
                        depth = b.Depth,
                        //stature = Context1.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().EstimateStature,
                        age = b.Ageatdeath,
                        headdirection = b.Headdirection,
                        //haircolor = Context2.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().RightHairColor,
                        //TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == b.Id).ToList(),
                    };

                    summaryViews.Add(summary);

                }

                foreach (var s in summaryViews)
                {
                    try
                    {
                        s.stature = Context1.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().EstimateStature;
                    }
                    catch
                    {
                        s.stature = null;
                    }
                    try
                    {
                        s.haircolor = Context2.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().RightHairColor;
                    }
                    catch
                    {
                        s.haircolor = null;
                    }
                    try
                    {
                        s.TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == s.Id).ToList();
                    }
                    catch
                    {
                        s.TextileList = null;
                    }
                }

                //Create view Model
                var x = new BurialViewModel
                {
                    //Get books using repo
                    Burials = summaryViews,

                    //Set up page details
                    PageDetails = new PageDetails
                    {
                        totalBurials = Context.Burialmains.Count(),
                        BurialsPerPage = pageLen,
                        CurrentPage = pageNum
                    }

                };
                return View(x);

            }
            else if (filter == "A" || filter == "I" || filter == "N" || filter == "In" || filter == "C")
            {
                IQueryable<Burialmain> burialmains = Context.Burialmains
                .Where(f => f.Ageatdeath == filter || filter == null)
                .OrderBy(f => f.Ageatdeath)
                .Skip((pageNum - 1) * pageLen).Take(pageLen);

                foreach (var b in burialmains)
                {
                    SummaryView summary = new SummaryView
                    {


                        Id = b.Id,
                        sex = b.Sex,
                        depth = b.Depth,
                        //stature = Context1.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().EstimateStature,
                        age = b.Ageatdeath,
                        headdirection = b.Headdirection,
                        //haircolor = Context2.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().RightHairColor,
                        //TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == b.Id).ToList(),
                    };

                    summaryViews.Add(summary);

                }

                foreach (var s in summaryViews)
                {
                    try
                    {
                        s.stature = Context1.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().EstimateStature;
                    }
                    catch
                    {
                        s.stature = null;
                    }
                    try
                    {
                        s.haircolor = Context2.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().RightHairColor;
                    }
                    catch
                    {
                        s.haircolor = null;
                    }
                    try
                    {
                        s.TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == s.Id).ToList();
                    }
                    catch
                    {
                        s.TextileList = null;
                    }
                }

                //Create view Model
                var x = new BurialViewModel
                {
                    //Get books using repo
                    Burials = summaryViews,

                    //Set up page details
                    PageDetails = new PageDetails
                    {
                        totalBurials = Context.Burialmains.Count(),
                        BurialsPerPage = pageLen,
                        CurrentPage = pageNum
                    }

                };
                return View(x);

            }
            else if (filter == "N" || filter == "S" )
            {
                IQueryable<Burialmain> burialmains = Context.Burialmains
                .Where(f => f.Headdirection == filter || filter == null)
                .OrderBy(f => f.Headdirection)
                .Skip((pageNum - 1) * pageLen).Take(pageLen);

                foreach (var b in burialmains)
                {
                    SummaryView summary = new SummaryView
                    {


                        Id = b.Id,
                        sex = b.Sex,
                        depth = b.Depth,
                        //stature = Context1.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().EstimateStature,
                        age = b.Ageatdeath,
                        headdirection = b.Headdirection,
                        //haircolor = Context2.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().RightHairColor,
                        //TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == b.Id).ToList(),
                    };

                    summaryViews.Add(summary);

                }

                foreach (var s in summaryViews)
                {
                    try
                    {
                        s.stature = Context1.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().EstimateStature;
                    }
                    catch
                    {
                        s.stature = null;
                    }
                    try
                    {
                        s.haircolor = Context2.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().RightHairColor;
                    }
                    catch
                    {
                        s.haircolor = null;
                    }
                    try
                    {
                        s.TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == s.Id).ToList();
                    }
                    catch
                    {
                        s.TextileList = null;
                    }
                }

                //Create view Model
                var x = new BurialViewModel
                {
                    //Get books using repo
                    Burials = summaryViews,

                    //Set up page details
                    PageDetails = new PageDetails
                    {
                        totalBurials = Context.Burialmains.Count(),
                        BurialsPerPage = pageLen,
                        CurrentPage = pageNum
                    }

                };
                return View(x);

            }
            else
            {
                IQueryable<Burialmain> burialmains = Context.Burialmains
                .Skip((pageNum - 1) * pageLen).Take(pageLen);

                foreach (var b in burialmains)
                {
                    SummaryView summary = new SummaryView
                    {


                        Id = b.Id,
                        sex = b.Sex,
                        depth = b.Depth,
                        //stature = Context1.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().EstimateStature,
                        age = b.Ageatdeath,
                        headdirection = b.Headdirection,
                        //haircolor = Context2.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().RightHairColor,
                        //TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == b.Id).ToList(),
                    };

                    summaryViews.Add(summary);

                }

                foreach (var s in summaryViews)
                {
                    try
                    {
                        s.stature = Context1.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().EstimateStature;
                    }
                    catch
                    {
                        s.stature = null;
                    }
                    try
                    {
                        s.haircolor = Context2.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().RightHairColor;
                    }
                    catch
                    {
                        s.haircolor = null;
                    }
                    try
                    {
                        s.TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == s.Id).ToList();
                    }
                    catch
                    {
                        s.TextileList = null;
                    }
                }

                //Create view Model
                var x = new BurialViewModel
                {
                    //Get books using repo
                    Burials = summaryViews,

                    //Set up page details
                    PageDetails = new PageDetails
                    {
                        totalBurials = Context.Burialmains.Count(),
                        BurialsPerPage = pageLen,
                        CurrentPage = pageNum
                    }

                };
                return View(x);
            }

            
            

        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(long id)
        {
            Burialmain b = Context.Burialmains.Where(x => x.Id == id).First();
            SummaryView s = new SummaryView
            {
                Id = b.Id,
                sex = b.Sex,
                depth = b.Depth,
                //stature = Context1.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().EstimateStature,
                age = b.Ageatdeath,
                headdirection = b.Headdirection,
                //haircolor = Context2.Burialdetails.Where(x => x.Id == b.Id).FirstOrDefault().RightHairColor,
                //TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == b.Id).ToList(),
            };
            try
            {
                s.stature = Context1.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().EstimateStature;
            }
            catch
            {
                s.stature = null;
            }
            try
            {
                s.haircolor = Context2.Burialdetails.Where(x => x.Id == s.Id).FirstOrDefault().RightHairColor;
            }
            catch
            {
                s.haircolor = null;
            }
            try
            {
                s.TextileList = Context3.Textiledetails.Where(x => x.MainBurialmainid == s.Id).ToList();
            }
            catch
            {
                s.TextileList = null;
            }
            return View(s);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(SummaryView s) {
            if(ModelState.IsValid)
            {
                Burialmain b = Context.Burialmains.Where(x => x.Id == s.Id).First();
                b.Sex = s.sex;
                b.Depth = s.depth;
                b.Ageatdeath = s.age;
                b.Headdirection = s.headdirection;
                Context.Update(b);
                Context.SaveChanges();
                return View("Success");
            }
            else
            {
                return View(s);
            }
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            long? id = Context.Burialmains.Max(x => x.Id) + 1;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Burialmain b)
        {
            if (ModelState.IsValid)
            {
                Context.Add(b);
                Context.SaveChanges();
                return View("Success");
            }
            else
            {
                return View(b);
            }
            
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            try
            {
                Burialmain b = Context.Burialmains.Where(x => x.Id == id).First();
                return View(b);
            }
            catch
            {
                return View(new Burialmain());
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Burialmain b)
        {
            Burialmain removal = Context.Burialmains.Where(y => y.Id == b.Id).FirstOrDefault();
            Context.Remove(removal);
            Context.SaveChanges();
            return View("Success");
        }

        public IActionResult UnsupervisedAnalysis()
        {
            return View();
        }


        public IActionResult AdministrativePages()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SupervisedAnalysis(Prediction? d)
        {
            ViewBag.j = d.PredictedValue;
            return View();
        }

        public IActionResult ViewDetails(long id)
        {
            Burialmain? b;
            Burialdetail? d;
            try {
                 b = Context.Burialmains.FirstOrDefault(y => y.Id == id);
            }
            catch
            {
                 b = null;
            }

            try
            {
                d = Context.Burialdetails.FirstOrDefault(y => y.Id == id);
            }
            catch
            {
                d = null;
            }

            if (b == null)
            {
                return RedirectToAction("BurialSummary");
            }
            else if (d == null)
            {
                return View("JustBurial");
            }
            else
            {
                DetailsViewModel dvm = new DetailsViewModel
                {
                    BurialDetails = d,
                    Burial = b,
                };
                return View(dvm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SupervisedAnalysisAsync(SupervisedView m)
        {
            float? headE = 0;
            float? headW = 0;
            float? sexF = 0;
            float? sexM = 0;
            float? ew_E = 0;
            float? ew_w = 0;
            float? fb_N = 0;
            float? fb_Y = 0;
            float? age_A = 0;
            float? age_C = 0;
            float? age_I = 0;
            float? age_N = 0;
            //float? thickC = 0;
            //float? thickF = 0;
            //float? thickFM = 0;
            //float? thickM = 0;
            //float? thickVF = 0;
            //float? mLinen = 0;
            //float? mWool = 0;
            //float? plyM = 0;
            //float? plyS = null;
            //float? dirS = null;
            //float? dirST = null;
            //float? dirSZ = null;
            //float? dirSZT = null;
            //float? dirZ = null;
            //float? dirZT = null;



            if (m.head == "")
            {
                headE = null;
                headW = null;
            }


            float? sNorthSouth = m.squarenorthsouth;
            float? depth = m.depth;
            float? sEastWest = m.squareeastwest;
            float? length = m.length;
            

            //float? count = m.count;
            if (m.sex == "")
            {
                 sexF = null;
                 sexM = null;
            }
            if (m.eastwest == "")
            {
                 ew_E = null;
                 ew_w = null;
            }
            if (m.face == "")
            {
                 fb_N = null;
                 fb_Y = null;
            }
            if (m.age == "")
            {
                 age_A = null;
                 age_C = null;
                 age_I = null;
                 age_N = null;
            }
            //if (m.thickness == "")
            //{
            //    float? thickC = null;
            //    float? thickF = null;
            //    float? thickFM = null;
            //    float? thickM = null;
            //    float? thickVF = null;
            //}
            //if (m.material == "")
            //{
            //    float? mLinen = null;
            //    float? mWool = null;
            //}
            //if (m.ply == "")
            //{
            //    float? plyM = null;
            //    float? plyS = null;
            //}
            //if (m.direction == "")
            //{
            //    float? dirS = null;
            //    float? dirST = null;
            //    float? dirSZ = null;
            //    float? dirSZT = null;
            //    float? dirZ = null;
            //    float? dirZT = null;
            //}






            if (m.head == "E")
            {
                 headE = 1;
                 headW = 0;
            }


            if (m.sex == "M")
            {
                 sexF = 0;
                 sexM = 1;
            }
            else if (m.sex == "F")
            {
                headE = 0;
                headE = 1;
            }

            if (m.eastwest == "E")
            {
                headE = 0;
                 ew_E = 1;
            }
            else if (m.eastwest == "W")
            {
                 ew_w = 0;
                headE = 1;
            }


            if (m.face == "Y")
            {
                headE = 1;
                 fb_N = 0;
            }
            else if (m.face == "N")
            {
                 fb_Y = 0;
                 fb_N = 1;
            }


            if (m.age == "A")
            {
                 age_A = 1;
                 age_C = 0;
                 age_I = 0;
                 age_N = 0;
            }
            else if (m.age == "C")
            {
                 age_A = 0;
                 age_C = 1;
                 age_I = 0;
                 age_N = 0;
            }
            else if (m.age == "I")
            {
                ew_w = 0;
                headE = 0;
                headE = 1;
                headE = 0;
            }
            else if (m.age == "N")
            {
                headE = 0;
                headE = 0;
                headE = 0;
                headE = 1;
            }


            //if (m.thickness == "Coarse")
            //{
            //    float thickC = 1;
            //    float thickF = 0;
            //    float thickFM = 0;
            //    float thickM = 0;
            //    float thickVF = 0;
            //}
            //else if (m.thickness == "Fine")
            //{
            //    float thickC = 0;
            //    float thickF = 1;
            //    float thickFM = 0;
            //    float thickM = 0;
            //    float thickVF = 0;
            //}
            //else if (m.thickness == "FineMedium")
            //{
            //    float thickC = 0;
            //    float thickF = 0;
            //    float thickFM = 1;
            //    float thickM = 0;
            //    float thickVF = 0;
            //}
            //else if (m.thickness == "Medium")
            //{
            //    float thickC = 0;
            //    float thickF = 0;
            //    float thickFM = 0;
            //    float thickM = 1;
            //    float thickVF = 0;
            //}
            //else if (m.thickness == "VeryFine")
            //{
            //    float thickC = 0;
            //    float thickF = 0;
            //    float thickFM = 0;
            //    float thickM = 0;
            //    float thickVF = 1;
            //}


            //if (m.material == "Linen")
            //{
            //    float mLinen = 1;
            //    float mWool = 0;
            //}
            //else if (m.material == "Wool")
            //{
            //    float mLinen = 0;
            //    float mWool = 1;
            //}


            //if (m.ply == "Single")
            //{
            //    float plyS = 1;
            //    float plyM = 0;
            //}
            //else if (m.ply == "Multiple")
            //{
            //    float plyS = 0;
            //    float plyM = 1;
            //}


            //if (m.direction == "S")
            //{
            //    float dirS = 1;
            //    float dirST = 0;
            //    float dirSZ = 0;
            //    float dirSZT = 0;
            //    float dirZ = 0;
            //    float dirZT = 0;
            //}
            //else if (m.direction == "S-twist")
            //{
            //    float dirS = 0;
            //    float dirST = 1;
            //    float dirSZ = 0;
            //    float dirSZT = 0;
            //    float dirZ = 0;
            //    float dirZT = 0;
            //}
            //else if (m.direction == "S/Z")
            //{
            //    float dirS = 0;
            //    float dirST = 0;
            //    float dirSZ = 1;
            //    float dirSZT = 0;
            //    float dirZ = 0;
            //    float dirZT = 0;
            //}
            //else if (m.direction == "S/Z-twist")
            //{
            //    float dirS = 0;
            //    float dirST = 0;
            //    float dirSZ = 0;
            //    float dirSZT = 1;
            //    float dirZ = 0;
            //    float dirZT = 0;
            //}
            //else if (m.direction == "Z")
            //{
            //    float dirS = 0;
            //    float dirST = 0;
            //    float dirSZ = 0;
            //    float dirSZT = 0;
            //    float dirZ = 1;
            //    float dirZT = 0;
            //}
            //else if (m.direction == "Z-twist")
            //{
            //    float dirS = 0;
            //    float dirST = 0;
            //    float dirSZ = 0;
            //    float dirSZT = 0;
            //    float dirZ = 0;
            //    float dirZT = 1;
            //}

            Dictionary<string, float?> context = new Dictionary<string, float?>();

            context.Add("squarenorthsouth", sNorthSouth);
            context.Add("depth", depth);
            context.Add("squareeastwest", sEastWest);
            context.Add("length", length);
            context.Add("headdirection_E", headE);
            context.Add("headdirection_W", headW);
            context.Add("sex_F", sexM);
            context.Add("sex_M", sexF);
            context.Add("eastwest_E", ew_E);
            context.Add("eastwest_W", ew_w);
            context.Add("facebundles_N", fb_N);
            context.Add("facebundles_Y", fb_Y);
            context.Add("ageatdeath_A", age_A);
            context.Add("ageatdeath_C", age_C);
            context.Add("ageatdeath_I", age_I);
            context.Add("ageatdeath_N", age_N);

            //string js = JsonConvert.SerializeObject(context);

            //using var client = new HttpClient();
            ////client.BaseAddress = new Uri("https://localhost:4000/score");
            //// Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //   new MediaTypeWithQualityHeaderValue("application/json"));
            //// Get data response
            //var response = client.PostAsync("https://localhost:4000/score",new StringContent( new JavaScriptSerializer().Serialize(context), Encoding.UTF8, "application/json")).Result;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:4000/score");
            var content = new StringContent($"{{\r\n        \"squarenorthsouth\" : {sNorthSouth},\r\n        \"depth\" : {depth},\r\n        \"squareeastwest\" : {sEastWest},\r\n        \"length\" : {length},\r\n        \"headdirection_E\" : {headE},\r\n        \"headdirection_W\" : {headW}, \r\n        \"sex_F\" : {sexF},\r\n        \"sex_M\" : {sexM},\r\n        \"eastwest_E\" : {ew_E},\r\n        \"eastwest_W\" : {ew_w},\r\n        \"facebundles_N\" : {fb_N},\r\n        \"facebundles_Y\" : {fb_Y},\r\n        \"ageatdeath_A\" : {age_A},\r\n        \"ageatdeath_C\" : {age_C},\r\n        \"ageatdeath_I\" : {age_I},\r\n        \"aeatdeath_N\" : {age_N}\r\n\r\n}}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                //Parse the response body
                var dataObjects = await response.Content.ReadFromJsonAsync<IEnumerable<Prediction>>();
                
                //GetJson<Prediction>(dataObjects);
                //foreach (var d in dataObjects)
                //{
                //    System.Diagnostics.Debug.WriteLine(GetJson<Prediction>(d).PredictedValue);
                //}
                //var prediction = JsonConvert.DeserializeObject<response>
                return RedirectToAction("SupervisedAnalysis", dataObjects.FirstOrDefault());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
                return View();
            }

            
        }

        //static T GetJson<T>(IEnumerable<> s)
        //{
        //    return JsonSerializer.Deserialize<T>(s);
        //}
    }

    public class Prediction
    {
        public string? PredictedValue { get; set; }
    }

}