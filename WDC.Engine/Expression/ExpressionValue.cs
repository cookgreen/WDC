using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Expression
{
    public class ExpressionValue : IExpression
    {
        private object parameter;

        public string Name { get { return "VALUE"; } }

        public object Parameters { get { return parameter; } }

        public ExpressionValue(object parameter)
        {
            this.parameter = parameter;
        }

        public object Parse()
        {
            return parameter;
        }
    }
}
