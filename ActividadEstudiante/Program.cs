using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

namespace ActividadEstudiante
{
    class Program
    {
        static List<Estudiante> ListaEstudiantes = new List<Estudiante>();
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        {
            int Menu;
            string aux;
            bool entradaVal = false;

            do
            {              
                Console.Clear();
                Console.WriteLine("1) Agregar Estudiantes.");
                Console.WriteLine("2) Listar Estudiantes.");
                Console.WriteLine("3) Buscar Estudiantes.");
                Console.WriteLine("0) Salir...");

                do
                {
                    Console.WriteLine("Digite una opcion: ");
                    aux = Console.ReadLine();
                    if (!Validar.Vacio(aux))
                        if (Validar.Numero(aux))
                            entradaVal = true;
                } while (!entradaVal);

               Menu = Convert.ToInt32(aux);          

                switch (Menu)
                {
                    case 1:
                        AgregarEstudiantes();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        BuscarEstudiantes();
                        break;
                    case 0:
                        Console.WriteLine("Gracias y hasta luego ......");
                        break;
                    default:
                        Console.WriteLine("Digite una opcion. ");
                        break;

                }

            } while (Menu > 0);

        }

        static void AgregarEstudiantes()
        {
            string nombre, correo, codigo, nota1, nota2, nota3;
            bool nomVal = false;
            bool correoVal = false; 
            bool codVal = false;
            bool notas1 = false;
            bool notas2 = false;
            bool notas3 = false;

            Console.Clear();
            Console.WriteLine("Ingrese datos...");
            Console.WriteLine("---------------------------------------");

            //---------------------------------------------------------------

            do
            {
                Console.WriteLine("Ingrese el codigo del nuevo estudiante: ");
                codigo = Console.ReadLine();
                if (!Validar.Vacio(codigo))
                    if (Validar.Numero(codigo))
                        codVal = true;
            } while (!codVal);

            if (Existe(Convert.ToInt32(codigo)))
                Console.WriteLine("El codigo" + codigo + " ya existe en el programa.");
            else
            {


                //----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese el nombre del nuevo estudiante: ");
                    nombre = Console.ReadLine();
                    if (!Validar.Vacio(nombre))
                        if (Validar.TipoTexto(nombre))
                            nomVal = true;
                } while (!nomVal);

                //----------------------------------------------------------------

                    do
                     {
                        Console.WriteLine("Ingrese el correo del nuevo estudiante: ");
                        correo = Console.ReadLine();
                        if (!Validar.Vacio(correo))
                            if (Validar.Mail(correo))                             
                                  correoVal = true;
                      } while (!correoVal);  


                //-----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 1ra Nota:  ");
                    nota1 = Console.ReadLine();
                    if (!Validar.Vacio(nota1))
                        if (Validar.Numero(nota1))
                            notas1 = true;
                } while (!notas1);

                //--------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 2da Nota:  ");
                    nota2 = Console.ReadLine();
                    if (!Validar.Vacio(nota2))
                        if (Validar.Numero(nota2))
                            notas2 = true;
                } while (!notas2);

                //----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 3ra Nota:  ");
                    nota3 = Console.ReadLine();
                    if (!Validar.Vacio(nota3))
                        if (Validar.Numero(nota3))
                            notas3 = true;
                } while (!notas3);

                //----------------------------------------------------

                Estudiante myEstudiante = new Estudiante();
                myEstudiante.cod = Convert.ToInt32(codigo);
                myEstudiante.nom = nombre;
                myEstudiante.email = correo;
                myEstudiante.n1 = Convert.ToInt32(nota1);
                myEstudiante.n2 = Convert.ToInt32(nota2);
                myEstudiante.n3 = Convert.ToInt32(nota3);

                //-----------------------------------------------------
                ListaEstudiantes.Add(myEstudiante);
            }
        }

        static void ListarEstudiantes()
        {
            decimal notaEs1 = 0;
            decimal notaEs2 = 0;
            decimal notaEs3 = 0;
            int y = 20;

            Console.SetCursorPosition(5, y); Console.Write("Codigo: ");
            Console.SetCursorPosition(15, y); Console.Write("Nombre: ");
            Console.SetCursorPosition(15, y); Console.WriteLine("Correo: ");
            Console.SetCursorPosition(15, y); Console.WriteLine("Nota 1: ");
            Console.SetCursorPosition(15, y); Console.WriteLine("Nota 2: ");
            Console.SetCursorPosition(15, y); Console.WriteLine("Nota 3: ");


            Console.WriteLine("----Lista de estudiantes----");
            Console.ReadKey();
        }

        static void BuscarEstudiantes()
        {
            string codigo;
            bool codigVal = false;

            Console.Clear();
            Console.WriteLine("Ingrese el estudiante que desea buscar: ");

            do
            {
                Console.Write("Digite el codigo del estudiante a buscar: ");
                codigo = Console.ReadLine();
                if (!Validar.Vacio(codigo))
                    if (Validar.Numero(codigo))
                        codigVal = true;
            } while (!codigVal);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Estudiante myEstudiante = ObtenerDatos(Convert.ToInt32(codigo));
                Console.WriteLine("Codigo: "+ myEstudiante.cod + "Nombre: " + myEstudiante.nom + "Correo: " + myEstudiante.email + "Nota 1:" + myEstudiante.n1 + "Nota 2: " + myEstudiante.n2 + "Nota 3: " + myEstudiante.n3);            
            }
            else
                Console.WriteLine("El usuario " + codigo + "no existe...");

        }

        static bool Existe(int codigo)
        {
            bool aux = false;
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                    aux = true;
            }
            return aux;
        }

        static Estudiante ObtenerDatos(int codigo)
        {
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                    return objetoEstudiante;
            }
            return null;
        }

        static void EscribirXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
            TextWriter escribirXml = new StreamWriter("C:/Users/wluis/Documents/ADSI/TRIMESTRE_2/Jesus_Ropero/ejercisios/ActividadEstudientes/ActividadEstudiante/Estudiantes/ListaEstudiantes.xml");
            codificador.Serialize(escribirXml, ListaEstudiantes);
            escribirXml.Close();

            Console.WriteLine(" Archivo Guardado ---- ");
        }

        static void leerXml ()
        {
            ListaEstudiantes.Clear();
            if (File.Exists("C:/Users/wluis/Documents/ADSI/TRIMESTRE_2/Jesus_Ropero/ejercisios/ActividadEstudientes/ActividadEstudiante/Estudiantes/ListaEstudiantes.xml"))
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
                FileStream leerXml = File.OpenRead("C:/Users/wluis/Documents/ADSI/TRIMESTRE_2/Jesus_Ropero/ejercisios/ActividadEstudientes/ActividadEstudiante/Estudiantes/ListaEstudiantes.xml");
                ListaEstudiantes = (List<Estudiante>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }
            Console.WriteLine("Archivo Cargado !!!!!!!!!!!!!!");


        }
    }
}
