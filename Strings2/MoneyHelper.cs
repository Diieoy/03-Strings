using System.Text.RegularExpressions;

namespace Strings2
{
    class MoneyHelper : AbstractRegularHelper
    {
        public MoneyHelper() { }
        public MoneyHelper(string s) : base(s)
        {
        }

        public override string UpgradeData()
        {
            Regex regex = new Regex(@"\b(\d{1,3} +)(\d{3} +)*(blr|belarusian roubles)\b");
            MatchEvaluator matchEvaluator = new MatchEvaluator(ReplaceBlr);
            Str = regex.Replace(Str, matchEvaluator);   
            
            return Str;
        }

        public string ReplaceBlr(Match m)
        {
            string str = m.Value.Replace(" ", string.Empty);

            if (str.Contains("blr"))
            {
                return (str.Replace("blr", " blr"));
            }
            else
            {
                return (str.Replace("belarusianroubles", " belarusian roubles"));
            }
        }
    }
}
