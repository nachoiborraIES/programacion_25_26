// Programa para calcular nota del primer trimestre

using System;

class CalculadoraNota
{
    static void Main()
    {
        int numPracticas;
        bool notaValida, examenValido, practicasSuspensas;
        double nota, sumaPracticas, mediaPracticas, notaFinal,
			notaExamen;
        
        // Inicializo las variables para evitar errores
        numPracticas = 0;
        notaValida=examenValido=practicasSuspensas = false;
        nota=mediaPracticas=notaFinal=notaExamen=sumaPracticas = 0.0;
        
        Console.Write("Indica cuántas prácticas has realizado: ");
        numPracticas = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduce la nota de tus {0} prácticas: ", 
            numPracticas);
            
        for (int i = 0; i < numPracticas; i++)
        {
            notaValida = false;   //reseteo a false en cada loop
            
            while (!notaValida)
            {
                try
				{
                    nota = Convert.ToDouble(Console.ReadLine());
                    
                    // valido que la nota sea entre 0 y 10
                    if (nota < 0 || nota > 10)
                    {
						Console.Write("Nota incorrecta, introdúcela de"
							+ " nuevo (un valor entre 0 y 10): ");
                    }
					else
					{	
						/* si la nota es valida, la vamos sumando
						 * en el contador sumaPracticas  */
						notaValida = true; 
						sumaPracticas += nota;
                        
						if (nota < 3)
						{
							//controlamos si hay practica suspendida
							practicasSuspensas = true;
						}
					}
				} 
				catch (Exception e)   //captamos un error generico
				{
					Console.WriteLine("Error: " + e.Message);
                    Console.Write("Introduce la nota de nuevo: ");
				}
            }
        }
        
        // Calculo la media de prácticas
        mediaPracticas = sumaPracticas / numPracticas;
        
        // Pido la nota del examen
        Console.Write("Nota de examen: ");
        while (!examenValido)
        {
            try
            {
                notaExamen = Convert.ToDouble(Console.ReadLine());
                
                if (notaExamen < 0 || notaExamen > 10)
                {
					Console.Write("Nota incorrecta, introdúcela de " +
                        "nuevo (debe ser un valor entre 0 y 10): ");
                }
                else
                {
                    examenValido = true;
                }
            }
			catch (Exception e)   
			{
				Console.WriteLine("Error: " + e.Message);
                Console.Write("Introduce la nota de nuevo: ");
			}
        }
        
        // Calculo la nota final
        notaFinal = notaExamen * 0.7 + mediaPracticas * 0.3;
        
        // Averiguo suspensos y escojo el menor entre notaFinal y 4
        if (notaExamen < 4 || practicasSuspensas || mediaPracticas < 5)
        {
            notaFinal = Math.Min(notaFinal, 4);
        }
        
        // Muestro la nota final en pantalla redondeada a dos decimales
        Console.WriteLine("Tu nota final es " + notaFinal.ToString("N2"));
    }
}
