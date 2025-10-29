/*
 * Programa que convierte a distintas unidades de temperatura 
 * pidiendo al usuario la unidad de temperatura y los grados.
 */

using System;

class Practica1
{
    static void Main()
    {
        char unidad;
        int grados, celsius;
        
        Console.WriteLine("Dime una unidad de temperatura:");
        unidad = Convert.ToChar(Console.ReadLine());
        
        if (unidad == 'C' || unidad == 'K' || unidad == 'F')
        {
            Console.WriteLine("Dime una temperatura en esa unidad:");
            grados = Convert.ToInt32(Console.ReadLine());
            
            if (unidad == 'F')
            {
                celsius = (grados - 32) / 2;
                Console.WriteLine("{0} grados Farenheith son {1} " +
                    "grados Celsius", grados, celsius);
            }
            else if (unidad == 'K')
            {
                celsius = grados - 273;
                Console.WriteLine("{0} grados Kelvin son {1} grados Celsius",
                    grados, celsius);
            }
            else
            {
                celsius = grados;
            }
            
            if (celsius < 10)
            {
                Console.WriteLine("Hace frío");
            }
            else if (celsius >= 10 && celsius <= 20)
            {
                Console.WriteLine("Hace buen tiempo");
            }
            else
            {
                Console.WriteLine("Hace calor");
            }
        }
        else
        {
            Console.WriteLine("Unidad incorrecta");
        }
    }
}
