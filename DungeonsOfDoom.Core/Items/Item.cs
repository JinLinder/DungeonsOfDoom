using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Core.Items
{
    public abstract class Item : ICarriable
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract void Use(Player player, int worldWidth, int worldHeight);
    }
}
