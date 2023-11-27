using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LabCalculator
{
    class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        //BaseErrorListener implementation
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            string pattern = @"'(.*?)'";
            MatchCollection matches = Regex.Matches(msg, pattern);
            if (matches.Count > 0)
                foreach (Match match in matches)
                {
                    if (!match.Value.Contains("EOF"))
                        throw new ArgumentException($"? Хибний ввід. Очікується: {match.Value}");
                }
            throw new ArgumentException($"? Хибний ввід");
        }

        //IAntlrErrorListener<int> implementation
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            string pattern = @"'(.*?)'";
            MatchCollection matches = Regex.Matches(msg, pattern);
            if (matches.Count > 0)
                throw new ArgumentException($"? Невідомий операнд: {matches[0].Value}");
            else
                throw new ArgumentException($"? Невідомий операнд");

        }
    }
}

