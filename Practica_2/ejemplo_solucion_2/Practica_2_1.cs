//Programa que dibuja triángulos crecientes invertidos

using System;

class DibujarTriangulos
{
    static void Main()
    {
        int altura, contadorEspacios, contadorCaracter;
        char caracter;

		//Insertamos los datos 
			
		Console.Write("Escribe la altura: ");
		altura = Convert.ToInt32(Console.ReadLine());

		Console.Write("Escribe un caracter: ");
		caracter = Convert.ToChar(Console.ReadLine());

		contadorCaracter = 1;
		contadorEspacios = altura - 1;
		
		// Imprimimos la figura
		
        for (int i = 1; i <= altura; i++)
        {
            for (int j = 1; j <= contadorCaracter; j++)
            {
                Console.Write("{0}", caracter);
            }

            for (int j = 1; j <= contadorEspacios*2; j++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j <= contadorCaracter; j++)
            {
                Console.Write("{0}", caracter);
            }

            Console.WriteLine();
            contadorCaracter++;
            contadorEspacios--;
        }
    }
}



