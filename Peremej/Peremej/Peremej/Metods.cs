using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peremej
{
    class Metods
    {
        static public int[] HemingKod(int r, int k, int[] soob)
        {
            int[] vozvrat = new int[k + r];
            int[] soobsh = new int[k];
            soobsh = soob;
            int[,] prMar = new int[k + r, r];
            for(int i=0;i<k+r;i++)
            {
                for(int j=0;j<r;j++)
                {
                    prMar[i, j] = 0;
                }
            }
            int TeckSchisl = 0;
            int[] stolbec = new int[r];
            int ves = 0;
            string sTeckChisl;
            int TeckPosition = 0;
            int[] prSimb = new int[r];
            int chetPrSimb = 0;
            for(;;)
            {
                sTeckChisl = Convert.ToString(TeckSchisl, 2).PadLeft(r, '0');
                for (int i = 0; i < r;i++)
                {
                    if(sTeckChisl[i]==49)
                    {
                        ves++;
                    }                  
                }
                if(ves >= 2)
                {
                    for(int i=0;i<r;i++)
                    {
                        if (sTeckChisl[i] == 48)
                        {
                            prMar[TeckPosition, i] = 0;
                        }
                        else
                        {
                            prMar[TeckPosition, i] = 1;
                        } 
                    }
                    TeckPosition++;
                }
                ves = 0;
                
                TeckSchisl++;
                if(TeckPosition == k)
                {
                    break;
                }
            }
            for(int i=0;i<r;i++)
            {
                prMar[k + i, i] = 1;
            }

            for(int i=0;i<r;i++)
            {
                for(int j=0;j<k;j++)
                {
                    if(soobsh[j]==prMar[j,i]&&soobsh[j]!=0)
                    {
                        chetPrSimb++;
                    }
                }
                if(chetPrSimb%2==1)
                {
                    prSimb[i] = 1;
                }else
                    {
                    prSimb[i] = 0;
                }
                chetPrSimb = 0;
            }
            for(int i=0;i<k+r;i++)
            {
                if(i<k)
                {
                   vozvrat[i] = soob[i];
                }
                else
                {
                    vozvrat[i] = prSimb[i - k];
                }
            }
            return vozvrat; 
        }

        static public int[,] HemingKodprMat(int r, int k, int[] soob)
        {
            int[] vozvrat = new int[k + r];
            int[] soobsh = new int[k];
            soobsh = soob;
            int[,] prMar = new int[k + r, r];
            for (int i = 0; i < k + r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    prMar[i, j] = 0;
                }
            }
            int TeckSchisl = 0;
            int[] stolbec = new int[r];
            int ves = 0;
            string sTeckChisl;
            int TeckPosition = 0;
            int[] prSimb = new int[r];
            int chetPrSimb = 0;
            for (;;)
            {
                sTeckChisl = Convert.ToString(TeckSchisl, 2).PadLeft(r, '0');
                for (int i = 0; i < r; i++)
                {
                    if (sTeckChisl[i] == 49)
                    {
                        ves++;
                    }
                }
                if (ves >= 2)
                {
                    for (int i = 0; i < r; i++)
                    {
                        if (sTeckChisl[i] == 48)
                        {
                            prMar[TeckPosition, i] = 0;
                        }
                        else
                        {
                            prMar[TeckPosition, i] = 1;
                        }
                    }
                    TeckPosition++;
                }
                ves = 0;

                TeckSchisl++;
                if (TeckPosition == k)
                {
                    break;
                }
            }
            for (int i = 0; i < r; i++)
            {
                prMar[k + i, i] = 1;
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (soobsh[j] == prMar[j, i] && soobsh[j] != 0)
                    {
                        chetPrSimb++;
                    }
                }
                if (chetPrSimb % 2 == 1)
                {
                    prSimb[i] = 1;
                }
                else
                {
                    prSimb[i] = 0;
                }
                chetPrSimb = 0;
            }
            for (int i = 0; i < k + r; i++)
            {
                if (i < k)
                {
                    vozvrat[i] = soob[i];
                }
                else
                {
                    vozvrat[i] = prSimb[i - k];
                }
            }
            return prMar;
        }

        static public int[,] StroimMatr(int[] soobsh,int K, int R)
        {
            int k = R;
            int r = Convert.ToInt32(Math.Round(Math.Log(k) + 2));
            int[,] Matr = new int[k + r, K/R];
            int[,] soobPoKa = new int[K/R, k];
            int[] strokaHeminga = new int[k + r];
            int[] strokaSoobsh = new int[k];
            int possoobsh = 0;
            for(int i=0;i<K/R;i++)
            {
                for(int j=0;j<k;j++)
                {
                    soobPoKa[i, j] = soobsh[possoobsh];
                    possoobsh++;
                }
            }
            for(int i=0;i<K/R; i++)
            {
                for(int j=0;j<k;j++)
                {
                    strokaSoobsh[j] = soobPoKa[i, j];
                }
                strokaHeminga = HemingKod(r, k, strokaSoobsh);
                for(int j =0;j < r+k; j++)
                {
                    Matr[j,i] = strokaHeminga[j];
                }
            }
            


            return Matr;
        }
        static public int[,] IspravlMatr(int[] soobsh,int R, int K)
        {
            int k = R;
            int r = Convert.ToInt32(Math.Round(Math.Log(k) + 2));
            int[,] Matr = new int[k + r, K / R];
            int[,] soobshch = new int[k + r, K / R];
            int pos = 0;
            int[] noustroka = new int[k + r];
            int[] isprstroka = new int[k + r];
            for(int i=0;i<K/R;i++)
            {
             
                for(int j=0;j<r+k;j++)
                {
                    soobshch[j, i] = soobsh[pos];
                    pos++;
                }
                for (int ia = 0; ia < r + k; ia++)
                {
                    noustroka[ia] = soobshch[ia, i];
                }
                isprstroka = HemingDekod(r, k, noustroka);
                for(int ja=0;ja<k+r;ja++)
                {
                    Matr[ja, i] = isprstroka[ja];
                }
            }
          
            return Matr;
        }

    

        static public int[] sindrom(int r, int k, int[] soob)
        {
            int[] isprInf = new int[r + k];
            int[] prishInf = new int[k];
            int[] prishPrSimb = new int[r];
            int[] noviePrSimb = new int[r];
            int[] vectorOshib = new int[r + k];
            int[] sindrom = new int[r];
            int[] newprSimb = new int[r];
            int[] hemingkodir = new int[r + k];

            for (int i = 0; i < k + r; i++)
            {
                if (i < k)
                {
                    prishInf[i] = soob[i];
                }
                else
                {
                    prishPrSimb[i - k] = soob[i];
                }
            }

            hemingkodir = HemingKod(r, k, prishInf);
            for (int i = 0; i < r; i++)
            {
                newprSimb[i] = hemingkodir[i + k];
            }

            for (int i = 0; i < r; i++)
            {
                if (prishPrSimb[i] != newprSimb[i])
                {
                    sindrom[i] = 1;
                }
                else
                {
                    sindrom[i] = 0;
                }
            }

            int TeckPosition = 0;
            int[,] prMar = new int[k + r, r];
            int ves = 0;
            int TeckSchisl = 0;
            string sTeckChisl;
            for (;;)
            {
                sTeckChisl = Convert.ToString(TeckSchisl, 2).PadLeft(r, '0');
                for (int i = 0; i < r; i++)
                {
                    if (sTeckChisl[i] == 49)
                    {
                        ves++;
                    }
                }
                if (ves >= 2)
                {
                    for (int i = 0; i < r; i++)
                    {
                        if (sTeckChisl[i] == 48)
                        {
                            prMar[TeckPosition, i] = 0;
                        }
                        else
                        {
                            prMar[TeckPosition, i] = 1;
                        }
                    }
                    TeckPosition++;
                }
                ves = 0;

                TeckSchisl++;
                if (TeckPosition == k)
                {
                    break;
                }
            }
            for (int i = 0; i < r; i++)
            {
                prMar[k + i, i] = 1;
            }

            int sovpSindroma = 0;

            for (int i = 0; i < k + r; i++)
            {
                int nule = 0;
                for (int j = 0; j < r; j++)
                {
                    if (prMar[i, j] == sindrom[j])
                    {
                        if (prMar[i, j] == 0)
                        {

                            nule++;
                        }
                        sovpSindroma++;
                    }
                }

                if (sovpSindroma == r & nule != r)
                {
                    vectorOshib[i] = 1;

                }
                else
                {
                    vectorOshib[i] = 0;
                }
                sovpSindroma = 0;
            }
            for (int i = 0; i < k + r; i++)
            {
                if (vectorOshib[i] == 1)
                {
                    if (soob[i] == 1)
                    {
                        isprInf[i] = 0;
                    }
                    if (soob[i] == 0)
                    {
                        isprInf[i] = 1;
                    }
                }
                if (vectorOshib[i] == 0)
                {
                    isprInf[i] = soob[i];
                }
            }

            return sindrom;
        }

        static public int[] HemingDekod(int r,int k,int[] soob)
        {
            int[] isprInf = new int[r + k];
            int[] prishInf = new int[k];
            int[] prishPrSimb = new int[r];
            int[] noviePrSimb = new int[r];
            int[] vectorOshib = new int[r + k];
            int[] sindrom = new int[r];
            int[] newprSimb = new int[r];
            int[] hemingkodir = new int[r + k];
                     
            for(int i=0;i<k+r;i++)
            {
                if (i < k)
                {
                    prishInf[i] = soob[i];
                } else
                {
                    prishPrSimb[i - k] = soob[i];
                }
            }

            hemingkodir = HemingKod(r, k, prishInf);
            for(int i=0;i<r;i++)
            {
                newprSimb[i] = hemingkodir[i + k];
            }

            for(int i=0;i<r;i++)
            {
                if(prishPrSimb[i]!=newprSimb[i])
                {
                    sindrom[i] = 1;
                }
                else
                {
                    sindrom[i] = 0;
                }
            }

            int TeckPosition = 0;
            int[,] prMar = new int[k + r, r];
            int ves = 0;
            int TeckSchisl = 0;
            string sTeckChisl;
            for (;;)
            {
                sTeckChisl = Convert.ToString(TeckSchisl, 2).PadLeft(r, '0');
                for (int i = 0; i < r; i++)
                {
                    if (sTeckChisl[i] == 49)
                    {
                        ves++;
                    }
                }
                if (ves >= 2)
                {
                    for (int i = 0; i < r; i++)
                    {
                        if (sTeckChisl[i] == 48)
                        {
                            prMar[TeckPosition, i] = 0;
                        }
                        else
                        {
                            prMar[TeckPosition, i] = 1;
                        }
                    }
                    TeckPosition++;
                }
                ves = 0;

                TeckSchisl++;
                if (TeckPosition == k)
                {
                    break;
                }
            }
            for(int i=0;i<r;i++)
            {
                prMar[k + i, i] = 1;
            }

            int sovpSindroma = 0;
           
            for(int i=0;i<k+r;i++)
            {
                int nule = 0;
                for (int j=0;j<r;j++)
                {
                    if(prMar[i,j] == sindrom[j] )
                    {
                        if (prMar[i, j] == 0)
                        {
                          
                            nule++;
                        }
                        sovpSindroma++;
                    }
                }
               
                if(sovpSindroma == r & nule != r)
                {
                    vectorOshib[i] = 1;
                    
                }
                else
                {
                    vectorOshib[i] = 0;
                }
                sovpSindroma = 0;
            }
            for(int i=0;i<k+r;i++)
            {
                if(vectorOshib[i]==1)
                {
                    if(soob[i]==1)
                    {
                        isprInf[i] = 0;
                    }
                   if(soob[i]==0)
                    {
                        isprInf[i] = 1;
                    }
                }
               if(vectorOshib[i] ==0)
                {
                    isprInf[i] = soob[i];
                }
            }

            return isprInf;
        }
    }
}
