using System;
using System.Collections.Generic;
using System.Text;

namespace Dto
{
    public class Chat
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdRemetente { get; set; }
        public string Mensagem { get; set; }
        public DateTime Horario { get; set; }

    }
}
