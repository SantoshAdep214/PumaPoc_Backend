using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkdayController : ControllerBase
    {
        [HttpGet(Name = "GetDate")]
        public IEnumerable<Data>? Get()
        {
           
            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);

            
            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);

            foreach (var a in data)
            {
                int count=0;
                int id = a.id;
                if (a.name == "Workday")
                {
                    
                        count++;
                    
                }
                System.Diagnostics.Debug.WriteLine("hello controller"+"count:"+count);

                if (id == 123)
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





 /*  public IEnumerable<Data> Get()
          {
              var date = DateTime.Today;
              var add = date.AddDays(4); //addded due days in static 

              string dateadd = add.ToString("dd'/'MM'/'yyyy");

              List<Data> data = new List<Data>()
             {
                 new Data() {
                 Date=dateadd,
                 Source="Workday",
                 Name="Workday",
                 Title="Absence Request - Employee Maria Musterfrau",
                 Due=4,
                 ImageUrl="https://d2c0jhkf0fswap.cloudfront.net/static/media/MicrosoftTeams-image_workday.cc261bd7341d76e9023e.png"
                 }
             };


              return data;
          }*/
