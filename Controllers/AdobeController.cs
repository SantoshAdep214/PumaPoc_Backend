using Microsoft.AspNetCore.Mvc;
/*using Newtonsoft.Json;*/
using System.Collections.Generic;
using Puma_Poc.Models;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdobeController : ControllerBase
    {
        // GET: api/<AdobeController>
        [HttpGet(Name = "GetAdobe")]
        public IEnumerable<Data>? Get()
        {
            System.Diagnostics.Debug.WriteLine("hello controller");

            Console.WriteLine("hello world");
          
            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
           var adobe = JsonConvert.DeserializeObject <Adobe[]>(json);

            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :"+adobe);
            List<Data> data = new List<Data>();
            foreach (var a in adobe)
            {

                string id = a.id;

                if (a.name=="Adobe Sign")
                {
                  
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var date = DateTime.Today;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");

                    data.Add(new Data() 
                    { 
                        id = id, 
                        name = name, 
                        source = source, 
                        due = Due,
                        title = title,
                        resolved = resolved,
                        date = dateadd
                    });


                  
                }  
             
            }
            return data;
        }
    }
    
}


/*  
 *  
   { "status": "success",
  "data": [
    {
      "id": "123",
      "source": "workday",
      "title": "Absence Request - Employee Maria Musterfrau",
      "due": 4,
      "resolved": false,
      "imageUrl": "Adobe_Sign_icon.png",
      "name": "Workday",
      "date": "11-10-2021"
    },
    {
      "id": "456",
      "source": "adobe_sign",
      "title": "Sign Employment Contract",
      "due": -3,
      "resolved": false,
      "imageUrl": "Workday.png",
      "name": "Adobe Sign",
      "date": "02-25-2022"
    },
    {
      "id": "345",
      "source": "outlook",
      "title": "Please Approve Invoice",
      "due": 1,
      "resolved": false,
      "imageUrl": "Adobe_Sign_icon.png",
      "name": "Outlook",
      "date": "01-20-2022"
    },
    {
      "id": "789",
      "source": "sap_concur",
      "title": "Approve Expense Report - Maria Musterfrau",
      "due": 0,
      "resolved": false,
      "imageUrl": "Adobe_Sign_icon.png",
      "name": "SAP Concur",
      "date": "01-25-2022"
    },
    {
      "id": "246",
      "source": "opentext",
      "title": "Absence Request - Employee Miroslav Klose",
      "due": -2,
      "resolved": false,
      "imageUrl": "Adobe_Sign_icon.png",
      "name": "Opentext",
      "date": "02-22-2022"
    },
    {
      "id": "056",
      "source": "adobe_sign",
      "title": "Sign Employment Contract",
      "due": -3,
      "resolved": true,
      "imageUrl": "Workday.png",
      "name": "Adobe Sign",
      "date": "02-25-2022"
    },
    {
      "id": "468",
      "source": "outlook",
      "title": "Please Approve Invoice From Vendor 'AAA'",
      "due": 4,
      "resolved": false,
      "imageUrl": "Adobe_Sign_icon.png",
      "name": "Outlook",
      "date": "01-20-2022"
    }
  ]*/