using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.Game
{
    public class Actor
    {
        private GameObject gameObject;
        private Dictionary<string, string> actorProperies;

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

        public int GetActorPropertyInt(string propertyName)
        {
            return int.Parse(actorProperies[propertyName]);
        }

        public float GetActorPropertyFloat(string propertyName)
        {
            return float.Parse(actorProperies[propertyName]);
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            gameObject.Render(g, renderer);
        }
    }
}
