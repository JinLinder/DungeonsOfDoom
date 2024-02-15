using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Core.Items
{
    public class TeleportPotion : Item
    {
        public TeleportPotion() : base("Teleport Potion")
        {
        }

        public override void Use(Player player, int worldWidth, int worldHeight)
        {
            player.Health += 5;
            player.X = Random.Shared.Next(worldWidth);
            player.Y = Random.Shared.Next(worldHeight);
        }
    }
}
