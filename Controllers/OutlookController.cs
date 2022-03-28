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


           // System.Diagnostics.Debug.WriteLine("hello outlook");
            Console.WriteLine("hello outlook shuru ho ja ....");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);
            var da=JsonConvert.SerializeObject(data);
         
            int count = 0;
            List<Data> data1 = new List<Data>();
        
            Console.WriteLine("data1 ka data dikha re baba" + data1);

          
            foreach (var a in data)
            {
              
                if (a.name=="Outlook" )
                {
                    count++;
                    string id=a.id;
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;                               
                    var date = DateTime.Today;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");

                    data1.Add(new Data() { id=id ,name = name, source = source, due=Due, title = title, resolved = resolved, date = dateadd,count=count });


                    Console.WriteLine("inside if m agaya chutitaaa  ");
                 
                }
              
              
            }

            Console.WriteLine("count dikha re baba:"+count );
            
            return data1;

          
        }


    }
}



