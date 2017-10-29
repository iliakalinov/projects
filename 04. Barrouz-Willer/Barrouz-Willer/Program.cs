using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrouz_Willer
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("Введите сжимаемую информацию:");
            string ab = Console.ReadLine();
            int size = ab.Length;

            List<string> replace = new List<string>();
            
            string temp = ab;

            replace.Add( temp );
            for(int i=0;i< size-1;i++)
            {
                replace.Add( temp.Substring( 1, size - 1 ) + temp[0] );
                temp = temp.Substring( 1, size - 1 ) + temp[0];
            }
            replace.Sort();

            int id=-1;

            for (int i = 0; i < replace.Count; i++)
            {
                if (replace[i] == ab) id = i;
            }

            Console.WriteLine( "\nИндекс в листе перестановок, начиная с 0:\n" +  id);

            string result = "";
            foreach (string str in replace)
            {
                result += str[str.Length-1];
            }

             Console.WriteLine("\nСжатый текст:\n" + result);


            List<string> repair = new List<string>();

            for(int i=0;i<result.Length;i++)
            {
                repair.Add("");
            }
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length;j++)
                {
                    repair[j] = result[j] + repair[j];
                }
                repair.Sort();
            }

            Console.WriteLine();
            Console.WriteLine("Обратное преобразование:\n" + repair[id]);
            Console.ReadLine();
        }
    }
}
