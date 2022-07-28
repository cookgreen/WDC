using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.AI
{
    public abstract class AIState
    {
        public abstract string Name { get; }
        public abstract void Update();
    }
}
