using System;
using System.Collections.Generic;
using System.Text;

namespace CPFData
{
    public class clsCPFData
    {
        /// <summary>
        /// Returns TRUE if the input string is a valid CPF.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isCPF_Simple(string input)
        {
            bool result = false;

            string _input = input.Replace("-", "").Replace(".", "");

            foreach (char ch in _input)
            {
                if (!char.IsNumber(ch))
                    return false;
            }

            if (_input.Length == 11)
                result = true;

            return result;
        }

        public static bool isCPF_Mod11(string input)
        {


            input = input.Replace("-", "").Replace(".", "");


            foreach (char ch in input)
            {
                if (!char.IsNumber(ch))
                    return false;
            }


            if (input.Length != 11)
                return false;

            int Total = 0;
            int Mod = 0;
            for (int i = 0; i < 9; i++)
            {
                char current = input[i];
                Total += int.Parse(current.ToString()) * (i + 1);
            }
            Mod = Total % 11;
            if (Mod.ToString() != input[9].ToString())
                return false;
            Total = 0;
            for (int i = 0; i < 10; i++)
            {
                char current = input[i];
                Total += int.Parse(current.ToString()) * (i);
            }
            Mod = Total % 11;
            if (Mod.ToString() != input[10].ToString())
                return false;

            return true;
        }
    }
}
