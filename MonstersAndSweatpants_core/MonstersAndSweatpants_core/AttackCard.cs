using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public class AttackCard
    {
        public virtual string Name { get; set; }
        public virtual int Attack { get; set; }
    }

    class LvlTenACard : AttackCard
    {
        public override string Name => "Mega Godsent Strength";
        public override int Attack => 10;
    }

    class LvlNineACard : AttackCard
    {
        public override string Name => "The Big 9";
        public override int Attack => 9;
    }

    class LvlEightACard : AttackCard
    {
        public override string Name => "Strongboi";
        public override int Attack => 8;
    }

    class LvlSevenACard : AttackCard
    {
        public override string Name => "Seven of Heaven";
        public override int Attack => 7;
    }

    class LvlSixACard : AttackCard
    {
        public override string Name => "OK strength i guess";
        public override int Attack => 6;
    }

    class LvlFiveACard : AttackCard
    {
        public override string Name => "Half Power";
        public override int Attack => 5;
    }

    class LvlFourACard : AttackCard
    {
        public override string Name => "Four Score";
        public override int Attack => 4;
    }

    class LvlThreeACard : AttackCard
    {
        public override string Name => "Noodle-arm Ninny";
        public override int Attack => 3;
    }

    class LvlTwoACard : AttackCard
    {
        public override string Name => "AMD CPU";
        public override int Attack => 2;
    }

    class LvlOneACard : AttackCard
    {
        public override string Name => "All Hands";
        public override int Attack => 1;
    }
}
