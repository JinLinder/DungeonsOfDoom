namespace DungeonsOfDoom.Core.Characters
{
    public abstract class Character
    {
        public Character(int health, int attackStrength)
        {
            MaxHealth = health;
            Health = health;
            AttackStrength = attackStrength;
        }

        //public int Health { get; set; }
        private int health;
        public virtual int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                    health = 0;
                else if (value > MaxHealth)
                    health = MaxHealth;
                else
                    health = value;
            }
        }

        public int MaxHealth { get; set; }
        public int AttackStrength { get; set; }
        public bool IsAlive { get { return Health > 0; } }

        public virtual void Attack(Character opponent)
        {
            opponent.Health -= AttackStrength;
        }
    }
}
