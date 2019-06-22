using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            String[] value=equation.Split('*','=');
            int first=0,second=0,third=0;
            if (value[0].Contains("?"))
            {
                second = Convert.ToInt32(value[1]);
                third = Convert.ToInt32(value[2]);

                if(third%second == 0)
                    return Findmiss(value[0],third/second);
                return -1;
            }
            else if (value[1].Contains("?"))
            {
                first = Convert.ToInt32(value[0]);
                third = Convert.ToInt32(value[2]);

                if(third%first == 0)
                    return Findmiss(value[1],third/first);;
                return -1;
            }
            else
            {
                second = Convert.ToInt32(value[1]);
                first = Convert.ToInt32(value[0]);
                return Findmiss(value[2],first*second);
            }
            //foreach(String a in value)
              //  Console.WriteLine(a);
            //return 1;
            throw new NotImplementedException();
        }

        public static int Findmiss(string val,int temp)
        {
            Console.WriteLine(temp);
            int position = val.IndexOf(@"?");
            position=val.Length-position-1;
            int poscount=0;
            Console.WriteLine(position);
            while(temp>0)
            {
                if(position==poscount)
                {
                    Console.WriteLine(temp%10);
                    return temp%10;
                }
                poscount +=1;
                temp /= 10;
            }
            return -1;
        }
    }
}
