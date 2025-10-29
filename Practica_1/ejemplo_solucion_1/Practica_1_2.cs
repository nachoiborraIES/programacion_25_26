/*
 * Programa que pide al usuario tres valores para tres revistas diferentes,
 * y calcula los días que coinciden a lo largo de un año, si los hay.
 */

using System;

class Practica2
{
    static void Main()
    {
        int x,y,z;
        
        do
        {
            Console.Write("Frecuencia en días de revista A: ");
            x = Convert.ToInt32(Console.ReadLine());
        }
        while (x < 1 || x > 365);
        
        do
        {
            Console.Write("Frecuencia en días de revista B: ");
            y = Convert.ToInt32(Console.ReadLine());
        }
        while (y < 1 || y > 365);
        
        do
        {
            Console.Write("Frecuencia en días de revista C: ");
            z = Convert.ToInt32(Console.ReadLine());
        }
        while (z < 1 || z > 365);
        
        for (int i = 1; i <= 365; i++)
        {
            if (i%x == 0 && i%y == 0 && i%z == 0)
            {   
                Console.WriteLine("Coinciden el día {0}", i);
            }
        }
    } 
}

