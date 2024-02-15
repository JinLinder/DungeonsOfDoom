namespace DungeonsOfDoom.Core.Characters
{
    public abstract class Monster : Character, ICarriable
    {
        public static int MonsterCounter { get; private set; }
        public Monster(string name, int health, int attackStrength) : base(health, attackStrength)
        {
            MonsterCounter++;
            Name = name;
        }

        public override int Health
        {
            get { return base.Health; }
            set
            {
                base.Health = value;

                if (Health == 0)
                    MonsterCounter--;
            }
        }

        public string Name { get; }
    }
}
