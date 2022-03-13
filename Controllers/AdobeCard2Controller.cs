using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdobeCard2Controller : ControllerBase
    {
        [HttpGet(Name = "GetData2")]
        public IEnumerable<Adobe>? Get1()
        {
            var date = DateTime.Today;

            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Adobe[]>(json);

            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);

            foreach (var a in data)
            {
                string id = a.id;
             
                if (id == "056")
                {
                    int Due = a.due;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");
                    string title = a.title;
                    string name = a.name;
                    string source = a.source;
                    bool resolved = a.resolved;

                    List<Adobe> data2 = new List<Adobe>()
                   {
                      new Adobe()
                      {
                               dateAdobe= dateadd,
                               source=source,
                               dueAdobe=Due,
                               name =name,
                               titleAdobe=title,
                               resolved=resolved,
                      }
                    };
                    return data2;
                }

            }
            return null;
        }

    }
}
