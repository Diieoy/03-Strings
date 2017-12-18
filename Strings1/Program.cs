using System;
using System.IO;
using System.Text;

namespace Strings1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\..\in.csv";
            int errorLines = 0;           
            int index = 0;
            string[] strngs = null;
            bool firstNumberInExample = true;
            double result = 0;
            double number = 0;
            string line = null;

            try
            {
                StringBuilder exercise = new StringBuilder("result(");

                using(StreamReader streamReader = new StreamReader(fileName))
                {                    
                    while((line = streamReader.ReadLine()) != null)
                    {
                        try
                        {
                            strngs = line.Split(';');
                            index = int.Parse(strngs[0]);
                            result += double.Parse(strngs[index]);
                            number = double.Parse(strngs[index]);
                            if (firstNumberInExample)
                            {
                                exercise.AppendFormat("{0:0.0#}", number);
                                firstNumberInExample = false;
                            }
                            else if (number < 0)
                            {
                                exercise.AppendFormat(" - {0:0.0#}", -number);
                            }
                            else
                            {
                                exercise.AppendFormat(" + {0:0.0#}", number);
                            }
                        }
                        catch (FormatException)
                        {
                            errorLines++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            errorLines++;
                        }
                    }

                }

                exercise.AppendFormat(") = {0:0.0#}", result);

                Console.WriteLine(exercise);
                Console.WriteLine("error-lines = " + errorLines);
            }
            catch (FileNotFoundException)    
            {
                Console.WriteLine("File name is wrong!");
            }

            Console.ReadLine();
        }
    }
}
