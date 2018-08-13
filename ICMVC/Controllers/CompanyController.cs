using ICMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ICMVC.Controllers
{
    public class CompanyController : Controller
    {
        //Hosted web API REST Service base url 
        string Baseurl = "http://localhost:13626/";
        public async Task<ActionResult> Index()
        {
            List<Company> CompanyInfo = new List<Company>();
            using(var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllComapnies using HttpClient 
                HttpResponseMessage Res = await client.GetAsync("api/company/getcompanies");

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var CompanyResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Company list  
                    CompanyInfo = JsonConvert.DeserializeObject<List<Company>>(CompanyResponse);
                }

                //returning the company list to view  
                return View(CompanyInfo);
            }
        }
    }
}
