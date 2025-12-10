/* Programa que genera y muestra una matriz y nos dice si un elemento
 * suyo es al mismo tiempo mínimo de su fila y máximo de su columna. */

using System;

class ProgramaMatriz
{
    static void Main()
    {
		int N, M;
		bool encontrado=false;
		bool esMaximoColumna=true;
			
        Console.Write("Introduce el número de filas (N): ");
        N = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Introduce el número de columnas (M): ");
        M = Convert.ToInt32(Console.ReadLine());
        
        int[,] matriz = new int[N, M];
        
        Console.WriteLine("Introduce los valores de la matriz:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("Fila {0} (valores separados por espacios): ",(i+1));
            string linea = Console.ReadLine();
            string[] valores = linea.Split(' ');
            
            for (int j = 0; j < M; j++)
            {
                matriz[i, j] = Convert.ToInt32(valores[j]);
            }
        }
        
        // Dibujamos la matriz
        Console.WriteLine("Matriz introducida:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write( matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
        
        
        for (int i = 0; i < N; i++)
        {
            // Buscamos el mínimo de la fila i
            int minFila = matriz[i, 0];
            int colMin = 0;
            
            for (int j = 1; j < M; j++)
            {
                if (matriz[i, j] < minFila)
                {
                    minFila = matriz[i, j];
                    colMin = j;
                }
            }
            
            esMaximoColumna = true;
            
            // Averiguamos si ese mínimo es el máximo de su columna            
            for (int k = 0; k < N; k++)
            {
                if (matriz[k, colMin] > minFila)
                {
                    esMaximoColumna = false;
                }
            }
            
            // Si cumple ambas condiciones, lo mostramos
            if (esMaximoColumna)
            {
                Console.WriteLine("Elemento {0} en posición {1},{2}",
                    minFila,(i+1),(colMin+1));
                encontrado = true;
            }
        }
        
        // Si no hemos encontrado nada, lo indicamos en pantalla
        if (!encontrado)
        {
            Console.WriteLine("No se han encontrado elementos que" + 
                " cumplan la condición");
        }
    }
}




