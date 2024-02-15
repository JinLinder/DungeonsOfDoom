using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Core.Items
{
    public class GlovesOfMetal : Item
    {
        public GlovesOfMetal() : base("Gloves of Metal")
        {
        }

        public override void Use(Player player, int worldWidth, int worldHeight)
        {
            player.AttackStrength += 5;
        }
    }
}
