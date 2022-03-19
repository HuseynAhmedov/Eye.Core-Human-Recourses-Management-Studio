using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Helper
{
    public class RandomGeneratorManager
    {
        public string RandomPasswordBuilder(int size = 11)
        {
            Random randomGen = new Random();
            StringBuilder builder = new StringBuilder();
            do
            {
                builder.Append(RandomString(4, true));
                builder.Append(randomGen.Next(1000, 9999));
                builder.Append(RandomString(2, false));
            }while(builder.ToString().Length < size);
            string randomStr = builder.ToString();
            randomStr = randomStr.Substring(0, size);
            return randomStr;
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
