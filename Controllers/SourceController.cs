using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet(Name = "GetSource")]
        public IEnumerable<Data>? Get()
        {


           
            

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);
          /*  var da = JsonConvert.SerializeObject(data);
             Console.WriteLine("hello source data "+da);*/

            //  System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);
          
            List<Data> data1 = new List<Data>();
           
            foreach (var a in data)
            {
                if (a.name == "Outlook")
                {
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var date = DateTime.Today;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");



                    data1.Add(new Data() { name = name, source = source, due = Due, title = title, resolved = resolved, date = dateadd });

                    return data1;
                  //  Console.WriteLine("inside of source................... ");
                    var jsondata = JsonConvert.SerializeObject(data1);

                    //Console.WriteLine("return dikha re baba  jsondata source wale ka baba re ....  ..:" + jsondata);
                }
            }

            return null;

        }
    }
}
