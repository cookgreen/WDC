using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Expression
{
    public interface IExpression
    {
        public string Name { get; }
        public object Parameters { get; }
        public object Parse();
    }
}
