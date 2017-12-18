using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Strings2
{
    class DateHelper : AbstractRegularHelper
    {
        public DateHelper() { }
        public DateHelper(string s) : base(s)
        {
        }

        public override string UpgradeData()
        {
            Regex regex = new Regex(@"\b\d{1,2}(/|-|\.)\d{1,2}(/|-|\.)(\d{2}|\d{4})\b");
            MatchEvaluator matchEvaluator = new MatchEvaluator(ReplaceDate);
            Str = regex.Replace(Str, matchEvaluator);           

            return Str;
        }

        public bool CheckCharacters(Match m)    
        {
            Regex rgx = new Regex(@"\D");
            string characters = "";
            foreach (Match match in rgx.Matches(m.Value))
            {
                characters += match;
            }

            return (characters[0].Equals(characters[1]));
        }

        public string ReplaceDate(Match m)
        {
            if (CheckCharacters(m))
            {
                try
                {
                    DateTime result = DateTime.Parse(m.Value);
                    return (result.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("en-US")));
                }
                catch(FormatException)
                {
                    return m.Value;
                }
            }
            else
            {
                return m.Value;
            }                   
        }        
    }
}
