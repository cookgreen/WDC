using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Expression;

namespace WDC.Game
{
    public class Actor
    {
        private GameObject gameObject;
        private Dictionary<string, string> actorProperies;
        private ExpressionParser expressionParser;

        public Actor(GameObject gameObject, Dictionary<string, string> actorProperies)
        {
            this.gameObject = gameObject;
            this.actorProperies = actorProperies;
        }

        public PointF Position
        {
            get { return gameObject.Position; }
            set { gameObject.Position = value; }
        }

        public int GetActorPropertyExpressionValueInt(string propertyName)
        {
            string expression = actorProperies[propertyName];
            return int.Parse(expressionParser.Parse(expression).ToString());
        }

        public float GetActorPropertyExpressionValueFloat(string propertyName)
        {
            string expression = actorProperies[propertyName];
            return float.Parse(expressionParser.Parse(expression).ToString());
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            gameObject.Render(g, renderer);
        }
    }
}
