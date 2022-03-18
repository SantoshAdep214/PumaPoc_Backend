using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpentextController : ControllerBase
    {
        // GET: api/<OpentextController>
        [HttpGet(Name = "GetOpentext")]
        public IEnumerable<Data>? Get()
        {
            
            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var opentextData = JsonConvert.DeserializeObject<Data[]>(json);

            //Adobe.AdobeRoot adobe = JsonConvert.DeserializeObject<Adobe.AdobeRoot>(json);

            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + opentextData);

            // IEnumerable<Adobe> adobe = JsonConvert.DeserializeObject<IEnumerable<Adobe>>(json);

            List<Data> data = new List<Data>();
            foreach (var a in opentextData)
            {

                string id = a.id;

                if (a.name == "Opentext")
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
