using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutlookController : ControllerBase
    {
        // GET: api/<OutlookController>
        [HttpGet(Name = "GetOutlook")]
        public IEnumerable<Data>? Get()
        {
           
            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);

            //Adobe.AdobeRoot adobe = JsonConvert.DeserializeObject<Adobe.AdobeRoot>(json);

            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);
           
            
            // IEnumerable<Adobe> adobe = JsonConvert.DeserializeObject<IEnumerable<Adobe>>(json);
            foreach (var a in data)
            {
                int id = a.id;

                if (id == 0214)
                {
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var date = DateTime.Today;
                    var add = date.AddDays(Due); string dateadd = add.ToString("dd'/'MM'/'yyyy");


                    List<Data> data1 = new List<Data>()
                   {
                      new Data()
                      {
                              date= dateadd,
                               source=source,
                               due=Due,
                               name =name,
                               title =title,
                               resolved=resolved,
                      }
                    };
                    return data1;
                }
            }
           
            return null;
        }
      
    }
}
