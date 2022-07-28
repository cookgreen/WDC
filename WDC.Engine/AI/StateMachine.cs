using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Game;

namespace WDC.AI
{
    public class StateMachine
    {
        private AIState currentState;
        private List<AIState> states;
        private Actor actor;

        public StateMachine(Actor actor)
        {
            this.actor = actor;
            states = new List<AIState>();
        }

        public void Init(List<AIState> states)
        {
            this.states = states;
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}
