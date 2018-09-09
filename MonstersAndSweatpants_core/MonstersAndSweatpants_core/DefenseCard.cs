using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public class DefenseCard
    {
        public virtual string Name { get; set; }
        public virtual double Defense { get; set; }
    }

    class LvlTenDCard : DefenseCard
    {
        public override string Name => "Near-Invincibility";
        public override double Defense => 0.95;
    }
    class LvlNineDCard : DefenseCard
    {
        public override string Name => "Shield of Defense";
        public override double Defense => 0.85;
    }
    class LvlEightDCard : DefenseCard
    {
        public override string Name => "Heavyboi Armor";
        public override double Defense => 0.80;
    }
    class LvlSevenDCard : DefenseCard
    {
        public override string Name => "No consent for u";
        public override double Defense => 0.69;
    }
    class LvlSixDCard : DefenseCard
    {
        public override string Name => "Middleman of Defense";
        public override double Defense => 0.50;
    }
    class LvlFiveDCard : DefenseCard
    {
        public override string Name => "Better than Cardboard";
        public override double Defense => 0.45;
    }
    class LvlFourDCard : DefenseCard
    {
        public override string Name => "Literally Cardboard";
        public override double Defense => 0.35;
    }
    class LvlThreeDCard : DefenseCard
    {
        public override string Name => "Rags and Robes";
        public override double Defense => 0.30;
    }
    class LvlTwoDCard : DefenseCard
    {
        public override string Name => "Sweatpants";
        public override double Defense => 0.20;
    }
    class LvlOneDCard : DefenseCard
    {
        public override string Name => "Nakedman";
        public override double Defense => 0.10;
    }
}
