using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.gameLogic
{
    public enum ActionCardTier { Troll, Tier2, Tier3, Tier4, God }

    public abstract class ActionCard
    {
        public string Name { get; }

        protected ActionCard(string name)
        {
            Name = name;
        }

        public abstract void Execute();
    }

}
