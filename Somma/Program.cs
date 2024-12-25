using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Somma
{
    internal class Program
    {
        static System.Resources.ResourceManager m;
        static void Main(string[] args)
        {
            int i = 0, round;
            bool continua = false;
            m = GetResourceManager();
            Console.WriteLine($"{m.GetString("Header")} by Giulio Sorrentino, License GPLv3 {m.GetString("Translation")} {m.GetString("Translators")}");
            while (!continua)
            {
                i = GetIntValue(m.GetString("NumbersOfElements"));
                continua = i > 1;
                if (!continua)
                    Console.Write(m.GetString("NumberTooSmall"));
            }
            round = GetIntValue(m.GetString("DecimalOfResult"));
            double d = GetDoubleValue(1);
            double d1= d+GetDoubleValue(2);
            for (int j=2; j<i; j++)
            {
                d1 = d1 + GetDoubleValue(j);
            }
            Console.WriteLine($"{m.GetString("Sum")}: {Math.Round(d1, round)}", CultureInfo.InvariantCulture);
        }

        public static double GetDoubleValue(int quale)
        {
            String s="";
            double d=0.0;
            bool esci = false;
            Console.Write($"{m.GetString("InsertWhichNumber")} {quale}: ");
            while (!esci)
            {
                s = Console.ReadLine();
                try
                {
                    d = double.Parse(s, CultureInfo.InvariantCulture);
                    esci = true;
                }
                catch (FormatException ex)
                {
                    Console.Write(m.GetString("NAN"));
                }
                catch (OverflowException ex)
                {
                    Console.Write(m.GetString("Overflow"));
                }
                catch (ArgumentNullException ex)
                {
                    Console.Write(m.GetString("Blank"));
                }

            }
            return d;
        }

        public static int GetIntValue(String prompt)
        {
            String s = "";
            int d = 0;
            bool esci = false;
            Console.Write(prompt);
            while (!esci)
            {
                s = Console.ReadLine();
                try
                {
                    d = int.Parse(s, CultureInfo.InvariantCulture);
                    esci = true;
                }
                catch (FormatException ex)
                {
                    Console.Write(m.GetString("NIN"));
                }
                catch (OverflowException ex)
                {
                    Console.Write(m.GetString("IntegerInvalid"));
                }
                catch (ArgumentNullException ex)
                {
                    Console.Write(m.GetString("Blank"));
                }

            }
            return d;
        }
        private static System.Resources.ResourceManager GetResourceManager()
        {
            System.Resources.ResourceManager m;
            m = new System.Resources.ResourceManager($"Somma.Strings.{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            try
            {
                m.GetString("Translator");
            }
            catch (System.Resources.MissingManifestResourceException e)
            {
                m = new System.Resources.ResourceManager($"Somma.Strings.en.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            }
            return m;
        }
    }
}
