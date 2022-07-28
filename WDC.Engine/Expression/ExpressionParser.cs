using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Expression
{
    public class ExpressionParser
    {
        public ExpressionParser()
        {
        }

        public object Parse(string expression)
        {
            string name = expression.Substring(0, expression.IndexOf("{"));

            int startIndex = expression.IndexOf("{");
            int endIndex = expression.IndexOf("}");
            string parameterStr = expression.Substring(startIndex + 1, endIndex - startIndex - 1);

            switch (name)
            {
                case "RANDOM":
                    string[] parameters = parameterStr.Split('-');
                    ExpressionRandom expressionParser = new ExpressionRandom(parameters);
                    return expressionParser.Parse();
                case "VALUE":
                    ExpressionValue expressionValue = new ExpressionValue(parameterStr);
                    return expressionValue.Parse();
                default:
                    return null;
            }
        }
    }
}
