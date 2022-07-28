using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Expression
{
    public class ExpressionRandom : IExpression
    {
        private Random random;
        private int minValue;
        private int maxValue;

        private object parameters;

        public string Name
        {
            get { return "RANDOM"; }
        }

        public object Parameters
        {
            get { return parameters; }
        }

        public ExpressionRandom(string[] parameters)
        {
            random = new Random();
            this.parameters = parameters;
            string[] paramt = parameters;
            minValue = int.Parse(paramt[0]);
            maxValue = int.Parse(paramt[1]);
        }

        public object Parse()
        {
            return random.Next(minValue, maxValue);
        }
    }
}
