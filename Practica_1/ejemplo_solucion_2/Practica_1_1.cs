using System;

/* 
 * Este programa convierte las temperaturas dadas en distintas 
 * unidades por el usuario a celsius y luego compara esa temperatura 
 * para decirte si hace frio, calor o buen tiempo.
 */

public class convertidorTemperaturas 
{
    public static void Main()
	{
		Console.WriteLine("Escribe una unidad de temperatura (C para grados");
		Console.WriteLine("centígrados, K para kelvin y F para fahrenheit)");
		char unidadTemperatura = Convert.ToChar(Console.ReadLine());
			
		if(unidadTemperatura == 'K' || unidadTemperatura == 'C'|| 
		unidadTemperatura == 'F')
		{
			Console.WriteLine("Escribe una temperatura en esa unidad");
			int cantidadTemperatura = Convert.ToInt32(Console.ReadLine()); 
			int celsius=0;
		
			switch(unidadTemperatura)
			{
				case 'C': 
					Console.WriteLine("No es necesaria la conversión");
					celsius= cantidadTemperatura;
					break;
				
				case 'K': 
					Console.WriteLine("Es necesaria la conversión");
					int kelvin = cantidadTemperatura;
					celsius = kelvin-273;
					Console.WriteLine($"{kelvin} Kelvin son {celsius} Celsius");
					break;
					
				case 'F': 
					Console.WriteLine("Es necesaria la conversión");
					int fahrenheit = cantidadTemperatura;
					celsius = (fahrenheit-32)/2;
					Console.Write($"{fahrenheit} Fahrenheit");
					Console.WriteLine($" son {celsius} Celsius");
					break;
			}
			
			if (celsius<10)
			{
				Console.WriteLine("Hace frío");
			}
			else if (celsius>20)
			{
				Console.WriteLine("Hace calor");
			}
			else
			{
				Console.WriteLine("Hace buen tiempo");
			}
		}
		
		else
		{
				Console.WriteLine("Unidad incorrecta");
		}
		
	}
}
