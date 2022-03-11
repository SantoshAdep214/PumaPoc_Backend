namespace Puma_Poc.Models
{
   /* public class Adobe
    {*/
        public class Adobe
       {
        public string id { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public int due { get; set; }
        public bool resolved { get; set; }
        public string? ImageUrl { get; set; }
        public string name { get; set; }
        public string? Date { get; set; }

        public string titleAdobe { get; set; }
        public int dueAdobe { get; set; }
        public string dateAdobe{ get; set; }
    }

        public class AdobeRoot
        {
            public string? status { get; set; }
            public List<Adobe>? Adobesign { get; set; }
        }
    }

