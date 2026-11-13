using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioRegistro
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Correo { get; set; }
        public string Carrera { get; set; }

        public Alumno(string nombre, string matricula, string correo, string carrera)
        {
            Nombre = nombre;
            Matricula = matricula;
            Correo = correo;
            Carrera = carrera;
        }

        // Primera letra del nombre (para el circulo de la lista)
        public string Inicial
        {
            get { return Nombre.Substring(0, 1).ToUpper(); }
        }

        // Matricula y carrera juntas (para la segunda linea de la lista)
        public string Detalle
        {
            get { return "Matrícula " + Matricula + "  •  " + Carrera; }
        }
    }
}