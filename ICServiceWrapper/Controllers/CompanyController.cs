using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICServiceWrapper.Controllers
{
    public class CompanyController : ApiController
    {
        [HttpPost]
        public bool AddCompany()
        {
            return true;
        }
        [HttpGet]
        public string GetCompanies()
        {
            return "Comapnies will be listed here";
        }
        [HttpDelete]
        public string DeleteCompany(int id)
        {
            return "Company is deleted with ID: " + id;
        }
        [HttpPut]
        public string UpdateCompany(int id)
        {
            return "Company is updated with ID: " + id;
        }
    }
}
