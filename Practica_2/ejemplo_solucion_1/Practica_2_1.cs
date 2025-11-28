/*
 * Programa que dibuja por pantalla una figura que combina 
 * un triángulo creciente y un triángulo creciente volteado, 
 * separados por un espacio central que disminuye hasta unirse 
 * completamente en la base. 
 * El carácter usado y la altura se piden al usuario. 
 */

using System;

public class Practica_2_1
{
    static void Main()
    {	
		int altura = 0;
        char caracter = ' ';
        bool datoValido;
        
        Console.Write("Introduce la altura: ");
        altura = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce el carácter: ");
        caracter = Convert.ToChar(Console.ReadLine());
        
        for(int i = 1; i <= altura; i++)
        {
            for(int j = 1; j <= i; j++)
            {
                Console.Write(caracter);
            }       
            
            for(int j = 1; j <= (altura - i) * 2; j++)
            {
                Console.Write(" ");
            }
            
            for(int j = 1; j <= i; j++)
            {
                Console.Write(caracter);
            }
            
            Console.WriteLine();
        }    
	}
}
        
