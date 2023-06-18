using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBot.Extensions
{
    internal class StringExtension
    {

        public static string GetLength(string str)
        {
            return $"Количество символов в тексте: {str.Length}";
        }
        public static string GetSum(string str)
        {
            try
            {
                int sum = 0;
                string num = " ";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ' ')
                    {
                        num += str[i];
                    }           
                    else
                    {
                        sum += int.Parse(num);
                        num = null;
                    }
                   
                }
                sum += int.Parse(num);
                return $"Сумма чисел: {sum}";
            }
            catch (Exception)
            {
                return "Исключение";
            }
        }
    }
}
