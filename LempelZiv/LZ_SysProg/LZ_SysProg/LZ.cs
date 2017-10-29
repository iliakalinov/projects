using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ_SysProg
{
	public class LZ
	{
		private List<string> dictionry;

		public LZ() {
			dictionry = new List<string>();//создание списка 
		}

		public string Encrypt(string message) {//для разбиения 
			string checkStr="";
			string binaryStr = "";
			for (int i = 0; i < message.Length; i++)   
			{
				checkStr +=message[i].ToString();//плюс символ
				if (dictionry.ToList().IndexOf(checkStr) < 0)//есть ли в списке				
				{
					dictionry.Add(checkStr);//в список
					checkStr = "";//обнуление 
				}
			}

			return binaryStr = Generirt(message);
		}

		private string Generirt(string message) {//в единую строку 
			string binaryStr = "";
			string checkStr = "";
			string st = "";
            binaryStr += checkFormat(Convert.ToString(dictionry.IndexOf(message[0].ToString()), 2));//возврат в двоичке 
			for (int i = 1; i < message.Count(); i++)//взять все символы
			{
				checkStr += message[i].ToString();//плюс символ
				if (i + 1 < message.Count())      //если символ который мы смотрим не последний в строке 
					 st= checkStr + message[i + 1].ToString();//строка+след символ 
				else {
					st = checkStr;
					string s = Convert.ToString(dictionry.IndexOf(checkStr), 2);
					binaryStr += checkFormat(s);//+ последовательность в двоичке
					return binaryStr;
				}
				if (dictionry.ToList().IndexOf(st) < 0)	//в листе нет последовательности			
				{
					string s= Convert.ToString(dictionry.IndexOf(checkStr), 2);
					binaryStr += checkFormat(s);//последовательность в двоичке
                    checkStr = "";
					//i--;
				}
			}
			return binaryStr;//итоговая строка в двоичке
		}

		private string checkFormat(string binaryNumber) {//добавление нулей
			string str = "";
			string n = Convert.ToString(dictionry.Count,2);//в двоичку 
			if (binaryNumber.Count() < n.Count())//if число значений в строке < число значений в списке 
			{
				for (int i = 0; i < n.Count() - binaryNumber.Count(); i++) 
				{
					str += "0";
				}
			}
			return str+binaryNumber;
		}

		public string Decrypt(string message) {
			string dMessage = "";
			int c = Convert.ToString(dictionry.Count, 2).Length;            
			for (int i = 0; i < message.Count() ; i += c)
			{
                string st = "";
                for (int j = 0; j < c; j++)
                    st += message[i + j].ToString();
				dMessage +=dictionry[Convert.ToInt32(st,2)];
			}
			return dMessage;
		}
	}
}
