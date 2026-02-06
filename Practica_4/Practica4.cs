/* Programa de agenda con menú para gestionar hasta 50 contactos descomponiendo
 * el código en funciones.*/

using System;

class ProgramaAgendaContactos
{
	struct Fecha
	{
		public int dia;
		public int mes;
		public int anyo;
	}

	struct Contacto
	{
		public string nombreApellidos;
		public string direccion;
		public string telefono;
		public string ciudad;
		public Fecha fechaNacimiento;
	}
    
    enum opciones {NUEVO=1, BORRAR, BUSCAR_CIUDAD, BUSCAR_ANYO, ORDENAR, SALIR}
    
    static opciones MostrarMenu()
    {
        opciones opcion;
        
        Console.WriteLine("\n== MENÚ ==");
        Console.WriteLine("1. Añadir contacto");
        Console.WriteLine("2. Borrar contacto");
        Console.WriteLine("3. Mostrar contactos de una ciudad");
        Console.WriteLine("4. Mostrar contactos por año");
        Console.WriteLine("5. Ordenar array por nombre");
        Console.WriteLine("6. Salir del programa");
        Console.Write("\nElige una opción: ");
        opcion = (opciones)Convert.ToInt32(Console.ReadLine());
        
        return opcion;
    }
    
    static void NuevoContacto(Contacto[] agenda, ref int cantidad)
    {
        Contacto nuevo;
        bool fechaValida;
        
        if (cantidad < agenda.Length)
        {
            do
            {
                Console.Write("Nombre y apellidos: ");
                nuevo.nombreApellidos = Console.ReadLine();
            } while (nuevo.nombreApellidos == "");

            do
            {
                Console.Write("Dirección: ");
                nuevo.direccion = Console.ReadLine();
            } while (nuevo.direccion == "");

            do
            {
                Console.Write("Teléfono: ");
                nuevo.telefono = Console.ReadLine();
            } while (nuevo.telefono == "");

            do
            {
                Console.Write("Ciudad: ");
                nuevo.ciudad = Console.ReadLine();
            } while (nuevo.ciudad == "");

            do
            {
                Console.Write("Fecha de nacimiento (dd/mm/aaaa): ");
                string fechaTexto = Console.ReadLine();
                string[] partes = fechaTexto.Split('/');
                
                nuevo.fechaNacimiento.dia = 0;
                nuevo.fechaNacimiento.mes = 0;
                nuevo.fechaNacimiento.anyo = 0;

                fechaValida = false;
                
                int dia;
                int mes;
                int anyo;
                
                if (partes.Length == 3 
                    && Int32.TryParse(partes[0], out dia) 
                    && Int32.TryParse(partes[1], out mes) 
                    && Int32.TryParse(partes[2], out anyo))
                {
                    if (dia >= 1 && dia <= 31 && 
                        mes >= 1 && mes <= 12 && 
                        anyo >= 1950 && anyo <= 2020)
                    {
                        nuevo.fechaNacimiento.dia = dia;
                        nuevo.fechaNacimiento.mes = mes;
                        nuevo.fechaNacimiento.anyo = anyo;
                        fechaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Fecha no válida");
                    }
                }
                else
                {
                    Console.WriteLine("Formato incorrecto");
                }
                
            } while (!fechaValida);

            agenda[cantidad] = nuevo;
            cantidad++;
            Console.WriteLine("Contacto añadido correctamente.");
        }
        else
        {
            Console.WriteLine("La agenda está llena.");
        }
    }
    
    static void BorrarContacto(Contacto[] agenda, ref int cantidad)
    {   
        int posicion;
        if (cantidad > 0)
        {
            Console.WriteLine("\n== CONTACTOS ACTUALES ==");
            for (int i = 0; i < cantidad; i++)
            {
                MostrarContactos(agenda, i);
            }

            do
            {
                Console.Write("¿Qué contacto quieres borrar?");
                posicion = Convert.ToInt32(Console.ReadLine());								
            } while (posicion < 1 || posicion > cantidad);

            posicion--;

            for (int i = posicion; i < cantidad - 1; i++)
            {
                agenda[i] = agenda[i + 1];
            }

            cantidad--;
            Console.WriteLine("Contacto borrado correctamente.");
        }
        else
        {
            Console.WriteLine("No hay contactos para borrar.");
        }
    }
    static void MostrarContactosCiudad(Contacto[] agenda, int cantidad, 
        string ciudadBuscada)
    {
        bool encontrado = false;
        
        if(cantidad > 0)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (agenda[i].ciudad.ToLower()==ciudadBuscada.ToLower())
                {
                    MostrarContactos(agenda, i);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No existen contactos de esa ciudad");
            }
        }
        else
        {
            Console.WriteLine("No hay contactos almacenados.");
        }
    }
    
    static void MostrarContactosAnyo(Contacto[] agenda, int cantidad, 
        int anyoBuscado)
    {
        bool encontrado = false;
        
        for (int i = 0; i < cantidad; i++)
        {
            if (agenda[i].fechaNacimiento.anyo == anyoBuscado)
            {
                MostrarContactos(agenda, i);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron contactos de ese año");
        }
    }
    
    static void OrdenarContactos(Contacto[] agenda, int cantidad)
    {
        if(cantidad > 0)
        {
            for (int i = 0; i < cantidad - 1; i++)
            {
                for (int j = i + 1; j < cantidad; j++)
                {
                    if (string.Compare(agenda[i].nombreApellidos, 
                        agenda[j].nombreApellidos) > 0)
                    {
                        Contacto temp = agenda[i];
                        agenda[i] = agenda[j];
                        agenda[j] = temp;
                    }
                }
            }

            Console.WriteLine("\n== CONTACTOS ORDENADOS POR NOMBRE ==");
            for (int i = 0; i < cantidad; i++)
            {
                MostrarContactos(agenda, i);
            }
        }
        else
        {
            Console.WriteLine("No hay contactos almacenados.");
        }
    }
     
    static void MostrarContactos(Contacto[] agenda, int i)
    {
        Console.WriteLine("{0}, {1}, {2}, {3}, " + 
            "{4}/{5}/{6}",
            agenda[i].nombreApellidos,
            agenda[i].direccion,
            agenda[i].telefono,
            agenda[i].ciudad,
            agenda[i].fechaNacimiento.dia.
                ToString("00"),
            agenda[i].fechaNacimiento.mes.
                ToString("00"),
            agenda[i].fechaNacimiento.anyo);
    }
    
    static void Main()
    {
		const int CAPACIDAD=50;
        Contacto[] agenda = new Contacto[CAPACIDAD];
        opciones opcion;
        int cantidad = 0, anyoBuscado;
        string ciudadBuscada;

        do
        {
            opcion = MostrarMenu();

            switch (opcion)
            {
                case opciones.NUEVO:
                    NuevoContacto(agenda, ref cantidad);
                    break;

                case opciones.BORRAR:
                    BorrarContacto(agenda, ref cantidad);
                    break;

                case opciones.BUSCAR_CIUDAD:
                    Console.Write("Introduce el nombre de la ciudad: ");
                    ciudadBuscada = Console.ReadLine();
                    MostrarContactosCiudad(agenda, cantidad, ciudadBuscada);
                    break;

                case opciones.BUSCAR_ANYO:
                    Console.Write("Introduce el año de nacimiento: ");
                    anyoBuscado = Convert.ToInt32(Console.ReadLine());
                    MostrarContactosAnyo(agenda, cantidad, anyoBuscado);
                    break;

                case opciones.ORDENAR:
                    OrdenarContactos(agenda, cantidad);
                    break;

                case opciones.SALIR:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            
        } while (opcion != opciones.SALIR);
    }
}
