using System.IO;
using System.Text.RegularExpressions;

namespace Strings3
{
    class Program
    {
        public static string CheckReg(Match match)
        {
            if (match.Value.StartsWith("/*"))
            {
                return string.Empty;
            }
            else if (match.Value.StartsWith("//"))
            {
                return "\r\n";
            }

            return match.Value;
        }

        static void Main(string[] args)
        {
            string file = File.ReadAllText(@"..\..\..\inputFor3.txt");

            //находит комментарии для удаления
            string delComments = @"/\*[\w\W]*?\*/";
            //находит комментарии для замены на \r\n
            string changeComments = @"//([\w\W]*?)\r?\n";
            //находит валидную строку с кавычками
            string strWithQuotes = @"(\w*\W*=\s*""(.*?)"";)|(\W*\(\s*""(.*?)""\);)";
            
            string regularStr = delComments + "|" + changeComments + "|" + strWithQuotes;

            Regex regex = new Regex(regularStr);
            string output = regex.Replace(file, CheckReg);

            File.WriteAllText(@"..\..\..\outputFor3.txt", output);
        }
    }
}
