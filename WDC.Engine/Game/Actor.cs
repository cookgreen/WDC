using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.AI;
using WDC.Core;
using WDC.Expression;

namespace WDC.Game
{
    public class Actor
    {
        private GameObject gameObject;
        private Dictionary<string, string> actorProperies;
        private ExpressionParser expressionParser;
        private StateMachine stateMachine;

        public Actor(GameObject gameObject, Dictionary<string, string> actorProperies)
        {
            this.gameObject = gameObject;
            this.actorProperies = actorProperies;
            expressionParser = new ExpressionParser();
        }

        public void InitAI(List<AIState> states)
        {
            stateMachine = new StateMachine(this);
            stateMachine.Init(states);
        }

        public PointF Position
        {
            get { return gameObject.Position; }
            set { gameObject.Position = value; }
        }

		public float GetActorProperty(string propertyName)
        {
            string expression = actorProperies[propertyName];
            return float.Parse(expressionParser.Parse(expression).ToString());
		}

		public void SetActorProperty(string propertyName, float newValue)
		{
			actorProperies[propertyName] = newValue.ToString();
		}

		public void Render(Graphics g, IRenderer renderer)
        {
            gameObject.Render(g, renderer);
		}

		public int GetActorPropertyInt(string propertyName)
		{
			string expression = actorProperies[propertyName];
			return int.Parse(expressionParser.Parse(expression).ToString());
		}
	}
}
