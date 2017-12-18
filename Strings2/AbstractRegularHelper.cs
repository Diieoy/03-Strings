using System.IO;

namespace Strings2
{
    abstract class AbstractRegularHelper
    {
        private string s;

        public string Str { get => s; set => s = value; }

        protected AbstractRegularHelper() { }
        protected AbstractRegularHelper(string s)
        {
            this.s = s;
        }

        public abstract string UpgradeData();

        public static string UpgradeTheFileToString(string pathToFile)
        {
            string file = File.ReadAllText(pathToFile);
            DateHelper dateHelper = new DateHelper(file);           
            file = dateHelper.UpgradeData();
            MoneyHelper moneyHelper = new MoneyHelper(file);
            file = moneyHelper.UpgradeData();

            return file;
        }     
        
        public static string[] UpgradeTheFileToArray(string pathToFile)
        {
            string[] file = File.ReadAllLines(pathToFile);

            AbstractRegularHelper dateHelper = new DateHelper();
            AbstractRegularHelper moneyHelper = new MoneyHelper();

            for (int i = 0; i < file.Length; i++)
            {
                dateHelper.Str = file[i].ToString();
                file[i] = dateHelper.UpgradeData();
                moneyHelper.Str = file[i].ToString();
                file[i] = moneyHelper.UpgradeData();
            }           

            return file;
        }
    }
}
