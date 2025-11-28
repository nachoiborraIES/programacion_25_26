/*
 * Programa que calcula la nota final del primer trimestre
 * con validaciones y penalizaciones.
 * Las notas se piden al usuario.
 */
 
using System;

public class Practica_2_2
{
    static void Main()
    {
        int numPracticas = 0;
        float notaPractica, suma = 0, mediaPracticas, 
        notaExamen = 0, notaFinal;
        bool datoValido, penalizar = false;
        
        Console.Write("Indica cuántas prácticas has realizado: ");           
        numPracticas = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduce la nota de tus {0} prácticas:", 
            numPracticas);
        
        for (int i = 1; i <= numPracticas; i++)
        {
            do
            {
                try
                {
                    notaPractica = Convert.ToSingle(Console.ReadLine());
                    datoValido = notaPractica >= 0 && notaPractica <= 10;
                    
                    if (datoValido)
                    {
                        suma += notaPractica;
                        if (notaPractica < 3) penalizar = true;
                    }
                    else 
                    {
						Console.WriteLine("Nota incorrecta, " +
						"introdúcela de nuevo:");
					}
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato no válido");
                    datoValido = false;
                }
            } 
            while (!datoValido);
        }
            
        do
        {
            Console.Write("Nota de examen: ");
            
            try
            {
                notaExamen = Convert.ToSingle(Console.ReadLine());
                datoValido = notaExamen >= 0 && notaExamen <= 10;
                
                if (!datoValido) 
                {
					Console.WriteLine("Nota incorrecta, " + 
					"introdúcela de nuevo:");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato no válido");
                datoValido = false;
            }
        } 
        while (!datoValido);
        
        mediaPracticas = suma / numPracticas;
        
        if (notaExamen < 4 || mediaPracticas < 5) 
        {
			penalizar = true;
		}
        
        notaFinal = notaExamen * 0.7f + mediaPracticas * 0.3f;
        
        if (penalizar) 
        {
			notaFinal = Math.Min(notaFinal, 4);
		}
        
        Console.WriteLine("Tu nota final es {0}", notaFinal.ToString("N2"));
    }
}

