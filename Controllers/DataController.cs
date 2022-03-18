using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]                               
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet(Name = "GetData")]
        public IEnumerable<Outlook>? Get()
        {
           
            var date = DateTime.Today;

            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Outlook[]>(json);

            

            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);

           
            foreach (var a in data)
            {
                string id = a.id;
               

                if (id == "214")
                {

                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");
                    List<Outlook> data1 = new List<Outlook>()
                   {
                      new Outlook()
                      {
                              dateTask2= dateadd,
                               source=source,
                               due4=Due,
                               name =name,
                               title2 =title,
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