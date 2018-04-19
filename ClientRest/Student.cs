using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRest
{
    public class Student
    {
        #region Atributos
        private int id;
        private string name;
        private string apellidos;
        private string dni;
        private DateTime fechaNac;
        private int edad;
        private string fechaCr;
        #endregion

        public Student() { }

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public string FechaCr { get => fechaCr; set => fechaCr = value; }
        #endregion
    }
}
