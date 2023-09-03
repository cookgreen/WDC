using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.AI;
using WDC.Core;
using WDC.Expression;
using WDC.Physics;

namespace WDC.Game
{
    public class Actor : ICollidable
    {
        private Actor parentActor;
        private GameObject gameObject;
        private Dictionary<string, string> actorProperies;
        private ExpressionParser expressionParser;
        private StateMachine stateMachine;
        private bool isAlive;

        public event Action ActorIsDead;

		public Actor Parent
		{
			get { return parentActor; }
		}
		public GameObject GameObject
        { 
            get { return gameObject; } 
        }
        public bool IsAlive
        {
            get { return isAlive; }
        }

        public Actor(
            Actor parentActor,
            GameObject gameObject, 
            Dictionary<string, string> actorProperies)
        {
            this.parentActor = parentActor;
            this.gameObject = gameObject;
            this.actorProperies = actorProperies;
            expressionParser = new ExpressionParser();
            isAlive = true;
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

		public PointF CenterPosition
		{
			get 
            { 
                var gdiPos  = gameObject.Position;
                return new PointF(gdiPos.X + gameObject.Size.Width / 2, gdiPos.Y + gameObject.Size.Height); 
            }
			set 
            {
                var centerPos = value;
                var pos = new PointF(centerPos.X - gameObject.Size.Width / 2, centerPos.Y - gameObject.Size.Height / 2);
                gameObject.Position = pos;
            }
		}

		public float GetActorProperty(string propertyName)
        {
            if (actorProperies.ContainsKey(propertyName))
            {
                string expression = actorProperies[propertyName];
                return float.Parse(expressionParser.Parse(expression).ToString());
            }
            else if (parentActor != null)
            {
                return parentActor.GetActorProperty(propertyName);
            }
            else
            {
                throw new Exception("Error!");
            }
		}

		public void SetActorPropertyFixedValue(string propertyName, float newValue)
		{
            actorProperies[propertyName] = "VALUE{" + newValue.ToString() + "}";
		}

		public void SetActorPropertyRangeValue(string propertyName, float newValue1, float newValue2)
		{
            actorProperies[propertyName] = "RANDOM{" + newValue1.ToString() + "-" + newValue2.ToString() + "}";
		}

		public void Render(Graphics g, IRenderer renderer)
        {
            gameObject.Render(g, renderer);

            if (GetActorProperty("HP") <= 0)
            {
                isAlive = false;
                ActorIsDead?.Invoke();
			}
            else
            {
                isAlive = true;
            }
		}
	}
}
