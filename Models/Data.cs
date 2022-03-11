
namespace Puma_Poc.Models
{
    public class Data
    {
        public int id { get; set; }
        public string? source { get; set; }
        public string? title { get; set; }
        public int due{ get; set; }
        public bool resolved { get; set; }
        //public string? imageUrl { get; set; }
        public string? name { get; set; }
        public string? date { get; set; }    
    }

    public class Root
    {
        public string? status { get; set; }
        public List<Data> data { get; set; }
    }
}
