namespace DungeonsOfDoom.Core.Characters
{
    public class Skeleton : Monster
    {
        public Skeleton() : base("Skeleton", 15, 5)
        {
        }

        public override void Attack(Character opponent)
        {
            bool isStrongOpponent = opponent.Health >= Health * 2;
            if (isStrongOpponent)
                opponent.Health -= 1;
            else
                opponent.Health -= AttackStrength;
        }
    }
}
