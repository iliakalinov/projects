cusing System;
using System.Text;
using Hemming;



public class Coder
{
    int[,] H;
    int[] InformSlovo;
    int[] IzbSlovo;
    int[] ItogSlovo;
    int K;//k
    int R;//r
    int L;
    public Coder(int lol)
    {

        K = Convert.ToInt32(lol);
        //  R = (int)Math.Log((double)(K), (double)(2))+1;
        
      //  R = (int)(Math.Ceiling(Math.Log(K+1, 2)) );
      if (K == 1) { R = 2; }
      if ((K >= 2) && (K <= 4)) { R = 3; }
      if ((K >=5)&&(K<=11)) { R = 4; }
      if ((K >= 12) && (K <= 26)) { R = 5; }
        if (K >27) { R = 6; }
        L = K + R;
        H = new int[R, L];/* {{1,1,0,1,  1,0,0},
                              {0,1,1,1,  0,1,0},
                              {1,0,1,1,  0,0,1},};*/
        InformSlovo = new int[K];
        IzbSlovo = new int[R];
        ItogSlovo = new int[L];
        GenerateMatrix();


    }
    public void GenerateMatrix()
    {
        int mask = 2;
        int counter = 0;
        for (int j = 0; j < K;)
        {
            mask++;
            for (int i = 0; i < R; i++)
            {
                if ((mask & (1 << i)) > 0)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                for (int i = 0; i < R; i++)
                {
                    if ((mask & (1 << i)) > 0)
                    {
                        H[i, j] = 1;
                    }
                }
                j++;
            }
            counter = 0;
        }
        for (int i = K; i < L; i++)
        {
            for (int j = 0; j < R; j++)
            {
                if (i - K == j) H[j, i] = 1;
            }
        }
    }
    public int[] Code(int[] inf)
    {
        int sum = 0;
        InformSlovo = inf;
        //Вычисление проверочных битов
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < K; j++)
            {
                sum = (sum + H[i, j] * InformSlovo[j]) % 2;
            }
            IzbSlovo[i] = sum;
            sum = 0;
        }
        Array.Copy(InformSlovo, ItogSlovo, K);
        Array.Copy(IzbSlovo, 0, ItogSlovo, K, R);
        return (int[])ItogSlovo.Clone();
    }
    public string PrintInformation()
    {
        StringBuilder res = new StringBuilder();
        res.Append("k = " + K + "\n");
        res.Append("r = " + R + "\n");
        res.Append("Проверочная матрица:\n");
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < L; j++)
            {
                res.Append(Convert.ToString(H[i, j]));
                res.Append(' ');
            }
            res.Append('\n');
        }
        res.Append("Информационное Сообщение: ");
        for (int i = 0; i < K; i++) res.Append(InformSlovo[i]);
        res.Append("\n проверочные биты:");
        for (int i = 0; i < R; i++) res.Append(IzbSlovo[i]);
        res.Append("\nСообщение для передачи:");
        for (int i = 0; i < L; i++) res.Append(ItogSlovo[i]);
        return res.ToString();
    }
    public string PrintInformation1()
    {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < L; i++) res.Append(ItogSlovo[i]);
        return res.ToString();
    }
}
public class Decoder
{
    int K;
    int R;
    int L;
    bool IsGood;
    int ErrorIndex;
    int[,] H;
    int[] PrinSlovo;
    int[] IzbSlovo;
    int[] InformSlovo;
    int[] Sindrom;
    int[] Errors;
    public Decoder(int lol)
    {
        K = Convert.ToInt32(lol);
        //   R = (int)Math.Log((double)(K), (double)(2)) + 1;
        if (K == 1) { R = 2; }
        if ((K >= 2) && (K <= 4)) { R = 3; }
        if ((K >= 5) && (K <= 11)) { R = 4; }
        if ((K >= 12) && (K <= 26)) { R = 5; }
        if (K > 27) { R = 6; }
        L = K + R;
        H = new int[R, L]; /*{{1,1,0,1,  1,0,0},
                           {0,1,1,1,  0,1,0},
                           {1,0,1,1,  0,0,1},};*/
        InformSlovo = new int[K];
        IzbSlovo = new int[R];
        PrinSlovo = new int[L];
        Sindrom = new int[R];
        Errors = new int[L];
        ErrorIndex = -1;
        GenerateMatrix();
    }
    public void GenerateMatrix()
    {
        int mask = 2;
        int counter = 0;
        for (int j = 0; j < K;)
        {
            mask++;
            for (int i = 0; i < R; i++)
            {
                if ((mask & (1 << i)) > 0)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                for (int i = 0; i < R; i++)
                {
                    if ((mask & (1 << i)) > 0)
                    {
                        H[i, j] = 1;
                    }
                }
                j++;
            }
            counter = 0;
        }
        for (int i = K; i < L; i++)
        {
            for (int j = 0; j < R; j++)
            {
                if (i - K == j) H[j, i] = 1;
            }
        }
    }
    public int[] Decode(int[] message)
    {
        Array.Clear(Errors, 0, L);
        Array.Clear(Sindrom, 0, R);
        int[] PrinIzbSlovo = new int[R];
        PrinSlovo = message;
        Array.Copy(PrinSlovo, K, PrinIzbSlovo, 0, R);
        int sum = 0;
        //Вычисления контрольных битов
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < K; j++)
            {
                sum = (sum + H[i, j] * PrinSlovo[j]) % 2;
            }
            IzbSlovo[i] = sum;
            sum = 0;
        }
        //Вычисление синдрома
        for (int i = 0; i < R; i++) Sindrom[i] = (IzbSlovo[i] + PrinIzbSlovo[i]) % 2;
        IsGood = true;
        for (int i = 0; i < R && IsGood; i++)
        {
            if (Sindrom[i] != 0)
            {
                IsGood = false;
            }
        }
        //Если синдром не нулевой
        if (!IsGood)
        {
            int equels = 0;
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < R; j++)
                {
                    if (H[j, i] == Sindrom[j]) equels++;
                }
                //Совпадение синдрома со столбцом
                if (equels == R)
                {
                    ErrorIndex = i;
                    break;
                }
                equels = 0;
            }
            if (ErrorIndex >= 0) Errors[ErrorIndex] = 1;
        }
        //коррекция с вектором ошибок
        for (int i = 0; i < K; i++) InformSlovo[i] = (PrinSlovo[i] + Errors[i]) % 2;
        return (int[])InformSlovo.Clone();
    }
    public string PrintInformation()
    {
        StringBuilder res = new StringBuilder();
        res.Append("Проверочная матрица:\n");
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < L; j++)
            {
                res.Append(Convert.ToString(H[i, j]));
                res.Append(' ');
            }
            res.Append('\n');
        }
        res.Append("Принятое сообщение: ");
        for (int i = 0; i < L; i++) res.Append(PrinSlovo[i]);
        res.Append("\nСиндром:");
        for (int i = 0; i < R; i++) res.Append(Sindrom[i]);
        res.Append("\nВектор ошибок:");
        for (int i = 0; i < L; i++) res.Append(Errors[i]);
        res.Append("\nИнформационное сообщение:");
        for (int i = 0; i < K; i++) res.Append(InformSlovo[i]);
        return res.ToString();
    }
}



public static class Converter
{
    public static int[] ConvertToArray(string data)
    {
        char[] letters = data.ToCharArray();
        int[] result = new int[letters.Length];
        for (int i = 0; i < result.Length; i++)
        {
            if (letters[i] == '1') result[i] = 1;
            else result[i] = 0;
        }
        return result;
    }
}
