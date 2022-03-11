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
           var data = JsonConvert.DeserializeObject<Data[]>(json);
            
         
            //var data1 = JsonConvert.DeserializeObject<Adobe[]>(json);
            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);

            foreach (var a in data)
            {
                int id = a.id;


                if (id == 555)
                {
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var date = DateTime.Today;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");

                    List<Data> data1 = new List<Data>()
                    {
                       new Data()
                       {

                                date = dateadd,
                                source = source,
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



/**/