using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests
{
    public class PersonaModel
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string fh_nac { get; set; }
        public int id_rol { get; set; }
        public string nombre_completo
        {
            get => $"{nombre} {apellido}";
        }

        public PersonaModel() { }

        public PersonaModel(string _nombre, string _apellido, string _sexo, string _fh_nac, int _id_rol)
        {
            nombre = _nombre;
            apellido = _apellido;
            sexo = _sexo;
            fh_nac = _fh_nac;
            id_rol = _id_rol;
        }
    }
}
