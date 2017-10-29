using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ_SysProg
{
	class Program
	{
		static void Main(string[] args)
		{
			LZ l = new LZ();
            Console.WriteLine("сообщение:");
            string message = Console.ReadLine();
    //        Console.WriteLine($"сообщение: {message}");
			string eMessage = l.Encrypt(message);
			Console.WriteLine($"шифрование: {eMessage}");
			Console.WriteLine($"дешифрование: {l.Decrypt(eMessage)}");			
		}
	}
}
