using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRest
{
    public class Student
    {
        public Guid Guid { get; set; }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public int Edad { get; set; }

        public Student() { }
    }
}
