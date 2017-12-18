using System.IO;

namespace Strings2
{
    class Program
    {      
        static void Main(string[] args)
        {
            string path = @"..\..\..\inFor2.txt";

            File.WriteAllText(@"..\..\..\outFor2.txt", AbstractRegularHelper.UpgradeTheFileToString(path));
            File.WriteAllLines(@"..\..\..\out2For2.txt", AbstractRegularHelper.UpgradeTheFileToArray(path));
        }
    }
}
