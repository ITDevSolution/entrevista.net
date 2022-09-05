using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPI.Models.WS
{
    public class ContactoViewModel
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string celular { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public int Idempresa { get; set; }
    }
}