using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SAPConcurController : ControllerBase
    {
        // GET: api/<SAPConcurController>
        [HttpGet(Name = "GetSAP")]
        public IEnumerable<Data>? Get()
        {
            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");




            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
           var sapdata = JsonConvert.DeserializeObject<Data[]>(json);
            
         
            //var data1 = JsonConvert.DeserializeObject<Adobe[]>(json);
            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + sapdata);
            List<Data> data = new List<Data>();
            foreach (var a in sapdata)
            {

                string id = a.id;

                if (a.name == "SAP Concur")
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



/**/