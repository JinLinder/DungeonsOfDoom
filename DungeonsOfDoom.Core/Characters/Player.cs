using DungeonsOfDoom.Core.Items;

namespace DungeonsOfDoom.Core.Characters
{
    public class Player : Character
    {
        public Player() : base(30, 10)
        {
            Backpack = new List<ICarriable>();
        }

        public List<ICarriable> Backpack { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
