
namespace Dto
{
    public class ResultadosGoogle
    {
       public string[] answers { get; set; }
       public Results[] results { get; set; }
        public long total { get; set; }

    }
    public class Results
    {
        public string description { get; set; }
        public string link { get; set; }
        public string title { get; set; }
    }
}
