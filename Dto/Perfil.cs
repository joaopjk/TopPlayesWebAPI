using System.Text.Json.Serialization;

namespace Dto
{
    public class Perfil
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string DataNascimento { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
