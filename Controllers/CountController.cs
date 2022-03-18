using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puma_Poc.Models;

namespace Puma_Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        [HttpGet(Name = "GetCount")]
        public IEnumerable<Count>? Get()
        {

            System.Diagnostics.Debug.WriteLine("hello controller");
            Console.WriteLine("hello world");

            StreamReader r = new StreamReader("PumaPoC.json");
            string json = r.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Data[]>(json);

            

            int workdayc = 0;
            int adobec = 0;
            int sapc = 0;
            int openc = 0;
            int todoc = 0;
            int outlookc = 0;
            int count = 0;
            foreach (var a in data)
            {
                bool resolved = a.resolved;

                if (a.name == "Workday")
                {
                    workdayc++;
                }
                else if (a.name == "Adobe Sign")
                {
                    adobec++;
                }
                else if (a.name == "Outlook")
                {
                    outlookc++;
                }
                else if (a.name == "SAP Concur")
                {
                    sapc++;
                }
                else if (a.name == "Opentext")
                {
                    openc++;
                }
                else if (a.name == "TODO")
                {
                    todoc++;
                }
               
                count++;


                System.Diagnostics.Debug.WriteLine("dfdfdfdfdfdffffdfdfdf :" +count);
                if (a.name == "Adobe Sign" && a.resolved == true)
                {
                    count--;
                    adobec--;
                }
                else if (a.name == "Workday" && a.resolved == true)
                {
                    count--;
                    workdayc--;
                }
                else if (a.name == "Outlook" && a.resolved == true)
                {
                    count--;
                    outlookc--;
                }
                else if (a.name == "SAP Concur" && a.resolved == true)
                {
                    count--;
                    sapc--;
                }
                else if (a.name == "Opentext" && a.resolved == true)
                {
                    count--;
                    openc--;
                }
               
                else if (a.name == "TODO" && a.resolved == true)
                {
                    count--;
                }
            }




            List<Count> allcount = new List<Count>()
              {
                 
                      new Count()
                            {
                             workdaycount = workdayc, 
                               adobecount = adobec,
                                  sapcount=sapc,
                            opentextcount =openc,
                                todocount =todoc,
                              outlookcount=outlookc,
                             /* resolved=resolved*/
                             count=count,
                            }
               };
                return allcount;
        }  
       
    }

}