using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    class Exceptions : System.Exception
    {
    }

    class UserDiedException : Exception
    {
        public override string Message => "You have died!";
    }

    class AIDiedException : Exception
    {
        public override string Message => "Your opponent has died!";
    }

    class MonsterDiedException : Exception
    {

    }
    class UserKilled : Exception
    {
        public override string Message => "You killed the monster!";
    }

    class AIKilled : Exception
    {
        public override string Message => "Your opponent killed the monster!";
    }
}
