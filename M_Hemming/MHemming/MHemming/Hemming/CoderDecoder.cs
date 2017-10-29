using System;
using System.Text;
using Hemming;


public class Coder
{
    
 
   
   
    int[,] H;
    int[] InformSlovo;
    int[] IzbSlovo;
    int[] ItogSlovo;
    int INF_WORD_LENGTH;
    int k;
    int CHECK_BIT_LENGTH;
    int r;
    int WORD_LENGTH;
    int nn;
   

    public Coder(int lol)
	{

        k = Convert.ToInt32(lol);
        r = (int)(Math.Ceiling(Math.Log(k, 2)) + 1);
        r++;
        nn = k + r;
        H = new int[r, nn];
        InformSlovo = new int[k];
        IzbSlovo = new int[r];
        ItogSlovo = new int[nn];
        GenerateMatrix();

        
	}
    public void GenerateMatrix()
    {
        int mask=2;
        int counter=0;
        for(int j=0;j<k ;)
        {
            mask++;
            for(int i=0;i<r - 1;i++)
            {
                if((mask&(1<<i))>0)
                {
                    counter++;
                }
            }
            if(counter>1) 
            {
                for(int i=0;i<r - 1;i++)
                {
                    if((mask&(1<<i))>0)
                    {
                        H[i,j]=1;
                    }
                }
                j++;
            }
            counter = 0;
        }
        for (int i = k; i < nn - 1; i++)
        {
            for (int j = 0; j < r - 1; j++)
            {
                if (i - k == j) H[j, i] = 1;
            }
        }

        int prov = 0;
        for (int j = 0; j < nn; j++)
        {
            if (H[r - 2, j] == 0) prov++;
        }
        if (prov == nn - 1)
        {
            r--;
            nn--;
            //H = new int[r, nn];
            InformSlovo = new int[k];
            IzbSlovo = new int[r];
            ItogSlovo = new int[nn];

            int[,] H2 = new int[r, nn];
            for(int i = 0; i < r;i++)
            {
                for(int n = 0; n < nn; n++)
                {
                    H2[i, n] = H[i, n]; 
                }
            }
            H = new int[r, nn];
            H = H2;
            NewMatrix();
        }
        else NewMatrix();
    }


    public void NewMatrix()
    {
        for (int i = 0; i < r; i++)
        {
            H[i, nn - 1] = 0;
        }
        for (int i = 0; i < nn; i++)
        {
            H[r - 1, i] = 1;
        }
        int sum = 0;
        for (int i = 0; i < nn; i++)
        {
            for (int n = 0; n < r; n++)
            {
                sum += H[n, i];
            }
            H[r - 1, i] = sum % 2;
            sum = 0;

        }
    }

    public int[] Code(int[] inf)
    {
        int sum=0;
        InformSlovo = inf;
        //Вычисление проверочных битов
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < k; j++)
            {
                sum = (sum+H[i, j]*InformSlovo[j])%2;
            }
            IzbSlovo[i] = sum;
            sum = 0;
        }
        Array.Copy(InformSlovo, ItogSlovo, k);
        Array.Copy(IzbSlovo, 0, ItogSlovo, k, r);
        return (int[])ItogSlovo.Clone();
    }
    public string PrintInformation()
    {
        StringBuilder res = new StringBuilder();
        res.Append("k = "+k+"\n");
        res.Append("r = " + r + "\n");
        res.Append("Проверочная матрица:\n");
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < nn; j++)
            {
                res.Append(Convert.ToString(H[i, j]));
                res.Append(' ');
            }
            res.Append('\n');
        }
        res.Append("Информационное Сообщение: ");
        for (int i = 0; i < k; i++) res.Append(InformSlovo[i]);
        res.Append("\n проверочные биты:");
        for (int i = 0; i < r; i++) res.Append(IzbSlovo[i]);
        res.Append("\nСообщение для передачи:");
        for (int i = 0; i < nn; i++) res.Append(ItogSlovo[i]);
        return res.ToString();
    }
    public string PrintInformation1()
    {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < nn; i++) res.Append(ItogSlovo[i]);
        return res.ToString();
    }
}
public class Decoder
{
    int k ;
   int r ;
    int nn;
    bool IsGood;
    int ErrorIndex;
    int[,] H;
    int[] PrinSlovo;
    int[] IzbSlovo;
    int[] InformSlovo;
    int[] Sindrom;
    int[] Errors;
    int wr = 0;
    public Decoder(int lol)
	{
        k = Convert.ToInt32(lol);
        r = (int)(Math.Ceiling(Math.Log(k, 2)) + 1);
        r++;
        nn = k + r;
        H = new int[r, nn];
        InformSlovo = new int[k];
        IzbSlovo = new int[r];
        PrinSlovo = new int[nn];
        Sindrom = new int[r];
        Errors = new int[nn];
        ErrorIndex = -1;
        GenerateMatrix();
	}
    public void GenerateMatrix()
    {
        int mask = 2;
        int counter = 0;
        for (int j = 0; j < k; )
        {
            mask++;
            for (int i = 0; i < r - 1; i++)
            {
                if ((mask & (1 << i)) > 0)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                for (int i = 0; i < r - 1; i++)
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
        for (int i = k; i < nn - 1; i++)
        {
            for (int j = 0; j < r - 1; j++)
            {
                if (i - k == j) H[j, i] = 1;
            }
        }

        int prov = 0;
        for (int j = 0; j < nn; j++)
        {
            if (H[r - 2, j] == 0) prov++;
        }
        if (prov == nn - 1)
        {
            r--;
            nn--;
            //H = new int[r, nn];
            InformSlovo = new int[k];
            IzbSlovo = new int[r];
            PrinSlovo = new int[nn];
            Sindrom = new int[r];
            Errors = new int[nn];
            

            int[,] H2 = new int[r, nn];
            for (int i = 0; i < r; i++)
            {
                for (int n = 0; n < nn; n++)
                {
                    H2[i, n] = H[i, n];
                }
            }
            H = new int[r, nn];
            H = H2;
            NewMatrix();
        }
        else NewMatrix();
    }


    public void NewMatrix()
    {
        for (int i = 0; i < r; i++)
        {
            H[i, nn - 1] = 0;
        }
        for (int i = 0; i < nn; i++)
        {
            H[r - 1, i] = 1;
        }
        int sum = 0;
        for (int i = 0; i < nn; i++)
        {
            for (int n = 0; n < r; n++)
            {
                sum += H[n, i];
            }
            H[r - 1, i] = sum % 2;
            sum = 0;

        }
    }

    public int[] Decode(int[] message)
    {
        Array.Clear(Errors, 0, nn);
        Array.Clear(Sindrom, 0, r);
        int[] PrinIzbSlovo = new int[r];
        PrinSlovo = message;
        Array.Copy(PrinSlovo, k, PrinIzbSlovo, 0, r);
        int sum = 0;
        //Вычисления контрольных битов
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < k; j++)
            {
                sum = (sum + H[i, j] * PrinSlovo[j]) % 2;
            }
            IzbSlovo[i] = sum;
            sum = 0;
        }
        //Вычисление синдрома
        for (int i = 0; i < r; i++) Sindrom[i] = (IzbSlovo[i] + PrinIzbSlovo[i]) % 2;
        IsGood = true;
        for (int i = 0; i < r && IsGood; i++) 
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
            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (H[j, i] == Sindrom[j]) equels++;
                }
                //Совпадение синдрома со столбцом
                if (equels == r)
                {
                    ErrorIndex = i;
                    break;
                }
                equels = 0;
            }
            if(ErrorIndex>=0) Errors[ErrorIndex] = 1;
        }
        //коррекция с вектором ошибок
        for (int i = 0; i < k; i++) InformSlovo[i] = (PrinSlovo[i] + Errors[i]) % 2;
        return (int[])InformSlovo.Clone();
    }

    public string Ctol(int[] S)
    {
        int[] a  = new int [r];
        int k = 1;
        bool f = true;
        string s = "возможны ошибки:\n";
        wr = 1;
        for (int i =0; i < nn ;i++)
        {
            
            for (int n0 = k; n0 < nn; n0++)
            {
                f = true;
                for (int j = 0; j < r; j++)
                {
                    a[j] = (H[j, i] + H[j, n0]) % 2;
                }
                for (int t = 0; t < r; t++)
                {
                    if (S[t] != a[t]) f = false; 
                }
                if (f) s += "в столбецах: " + (i+1) + " и " + (n0+1) + " \n";
               
            }
            k++;             
        }
        return s;
    }

    public string PrintInformation()
    {
        StringBuilder res = new StringBuilder();
        res.Append("Проверочная матрица:\n");
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < nn; j++)
            {
                res.Append(Convert.ToString(H[i, j]));
                res.Append(' ');
            }
            res.Append('\n');
        }
        res.Append("Принятое сообщение: ");
        for (int i = 0; i < nn; i++) res.Append(PrinSlovo[i]);
        res.Append("\nпроверочные биты");
        for (int i = 0; i < IzbSlovo.Length; i++) res.Append(IzbSlovo[i]);
        res.Append("\nСиндром:");
        for (int i = 0; i < r; i++) res.Append(Sindrom[i]);
        
        int sum = 0;
        for (int i = 0; i < Sindrom.Length; i++) sum += Sindrom[i];
        if (sum % 2 == 0 && sum != 0)
        {
            res.Append("\nПроизошла двойная ошибка при передачи данных\n");
            res.Append(Ctol(Sindrom));
            if (wr == 0)
            {
                res.Append("\nИнформационное сообщение:");
                for (int i = 0; i < k; i++) res.Append(InformSlovo[i]);
            }
        }
        else
        {
            res.Append("\nВектор ошибок:");
            for (int i = 0; i < nn; i++) res.Append(Errors[i]);
          
                res.Append("\nИнформационное сообщение:");
                for (int i = 0; i < k; i++) res.Append(InformSlovo[i]);
            
        }
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