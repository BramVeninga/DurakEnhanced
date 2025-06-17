using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.gameLogic
{
    public enum ActionCardTier { Troll, Tier2, Tier3, Tier4, God }

    public class ActionCard
    {
        public ActionCardTier Tier { get; set; }
        public string Description { get; set; }

        public void ApplyEffect(Player self, Player opponent)
        {
            // Effect logica hier (voorbeeld: opponent.Hand.Add(new Card()))
        }
    }

}
