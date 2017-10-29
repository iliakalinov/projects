using System;


public class Program
{
    public static void Main()
    {
        Console.WriteLine("Ввод строки :\n");
        MD5.MD5 md = new MD5.MD5();

     /*   for(;;)
        { */
            md.Value = Console.ReadLine();
            Console.WriteLine( "результат:\n" + md.Value );
            Console.WriteLine();
        //}
    }
}


