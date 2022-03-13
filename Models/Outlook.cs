namespace Puma_Poc.Models
{
    public class Outlook
    {
        public string?  dateTask1 { get; set; }
        public string? dateTask2 { get; set; }

        /* public string? DateData1 { get; set; }
         public string? DateData2 { get; set; }*/
        public string id { get; set; }
        public string? source { get; set; }
        public bool resolved { get; set; }
        public string? name{ get; set; }
        public string? title{ get; set; }
        public string title2 { get; set; }

        public string? ImageUrl { get; set; }
        public int due{ get; set; } 
        public int due4{ get; set; }
    }
}
