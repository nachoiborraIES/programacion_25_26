/* 
 * Una editorial publica 3 revistas con distintas frecuencias de salida.
 * El programa pide al usuario que introduzca 3 valores para la
 * periodicidad en días de cada una (X, Y, Z).
 * Estos valores solo pueden estar comprendidos entre 1 y 365.
 * Si no cumple el rango volverá a preguntar hasta que sea correcto.
 * Suponiendo que las tres revistas coinciden el día 1, el programa
 * mostrará los otros días del año (365 días) en los que
 * vuelvan a coincidir.
 */

using System;

class DiasCoincidentes
{
	static void Main()
	{
		int x = 0, y = 0, z = 0, dia;

		do
		{
			Console.Write("Introduce un valor para X: ");
			x = Convert.ToInt32(Console.ReadLine());
		}
		while (x < 1 || x > 365);

		do
		{
			Console.Write("Introduce un valor para Y: ");
			y = Convert.ToInt32(Console.ReadLine());
		}
		while (y < 1 || y > 365);

		do
		{
			Console.Write("Introduce un valor para Z: ");
			z = Convert.ToInt32(Console.ReadLine());
		}
		while (z < 1 || z > 365);

		for (dia = 2; dia <= 365; dia += 1)
		{
			if ((dia - 1) % x == 0 &&
				(dia - 1) % y == 0 &&
				(dia - 1) % z == 0)
			{
				Console.WriteLine("Vuelven a coincidir el día {0}", dia);
			}
		}
	}
}
