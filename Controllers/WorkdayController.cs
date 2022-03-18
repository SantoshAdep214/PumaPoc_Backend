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
        [HttpGet(Name = "GetworkdayData")]
        public IEnumerable<Data>? Get()
        {
           
            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);
            List<Data> workdayData = new List<Data>();
            int count = 0;
            System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" + data);

            foreach (var a in data)
            {
               Console.WriteLine("name bata re baba isss controller ka -="+a.name);
                if (a.name == "Workday")
                {
                    count++;
                    string id = a.id;
                    string name = a.name;
                    string source = a.source;
                    int Due = a.due;
                    string title = a.title;
                    bool resolved = a.resolved;
                    var date = DateTime.Today;
                    var add = date.AddDays(Due);
                    string dateadd = add.ToString("dd'/'MM'/'yyyy");

                    workdayData.Add(new Data() { id = id, name = name, source = source, due = Due, title = title, resolved = resolved, date = dateadd, count = count });


                    Console.WriteLine("inside m agaya workday.........  ");

                }


            }

            var x = JsonConvert.SerializeObject(workdayData);
            Console.WriteLine( "workday data====="+x);
            return workdayData;
        }
    }
}






/* {
    "id": "122",
    "source": "workday",
    "title": "Absence Request - Employee Maria Musterfrau22222222222",
    "due": 4,
    "resolved": false,
    "imageUrl": "Adobe_Sign_icon.png",
    "name": "Workday",
    "date": "11-10-2021"
  },
  {
    "id": "13",
    "source": "workday",
    "title": "Absence Request - Employee Maria Musterfrau33333",
    "due": -4,
    "resolved": false,
    "imageUrl": "Adobe_Sign_icon.png",
    "name": "Workday",
    "date": "11-10-2021"
  },*/