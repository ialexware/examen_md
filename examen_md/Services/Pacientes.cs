using examen_md.Helpers;
using examen_md.Models;

namespace examen_md.Services
{
    public class Pacientes
    {
        public static void GrabarPacientes(string nomFitch, LinkedList<Paciente> pacientes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomFitch))
                {
                    foreach (Paciente paciente in pacientes)
                    {
                        //Escribir las propiedades del paciente separadas por ;
                        sw.WriteLine(paciente.Nombre + ";" + paciente.Apellido + ";" + paciente.Direccion + ";" + paciente.Telefono + ";" + paciente.Email);
                    }
                }
            }
            catch (FormatoDeFicheroIncorrecto e)
            {
                throw new FormatoDeFicheroIncorrecto("Error al escribir el archivo: " + e.Message);
            }
        }

        private static LinkedList<Paciente> leePaciewntes(string nomFich)
        {
            LinkedList<Paciente> pacientes = new LinkedList<Paciente>();
            try
            {
                using (StreamReader sr = new StreamReader(nomFich))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(';');
                        Paciente paciente = new Paciente()
                        {
                            Nombre = datos[0],
                            Apellido = datos[1],
                            Direccion = datos[2],
                            Telefono = datos[3],
                            Email = datos[4]
                        };
                        pacientes.AddLast(paciente);
                    }
                }
            }
            catch (FormatoDeFicheroIncorrecto e)
            {
                throw new FormatoDeFicheroIncorrecto("Error al leer el archivo: " + e.Message);
            }
            return pacientes;
        }
    }
}
