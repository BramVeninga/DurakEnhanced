using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.gameLogic.ActionCards.Troll
{
    public class TrollCard : ActionCard
    {
        private readonly Action _effect;

        public TrollCard(string name, Action effect) : base(name)
        {
            _effect = effect;
        }

        public override void Execute()
        {
            _effect?.Invoke();
        }
    }

}
