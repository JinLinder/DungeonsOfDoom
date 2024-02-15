using DungeonsOfDoom.Core;
using DungeonsOfDoom.Core.Characters;
using DungeonsOfDoom.Core.Items;
using System.Text;

namespace DungeonsOfDoom
{
    class Program
    {
        public static int WorldWidth = 20;
        public static int WorldHeight = 5;

        Room[,] rooms;
        Player player;
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Play();
        }

        public void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            player = new Player();
            CreateRooms();
             
            do
            {
                Console.Clear();
                DisplayRooms();
                DisplayStats();
                if (CheckForValidMovement())
                {
                    ExploreRoom();
                }
            } while (player.IsAlive && Monster.MonsterCounter > 0);

            GameOver();
        }

        void CreateRooms()
        {
            rooms = new Room[20, 5];
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                for (int x = 0; x < rooms.GetLength(0); x++)
                {
                    rooms[x, y] = new Room();

                    int spawnChance = Random.Shared.Next(1, 100 + 1);
                    if (spawnChance < 5)
                        rooms[x, y].MonsterInRoom = new Skeleton();
                    else if (spawnChance < 10)
                        rooms[x, y].MonsterInRoom = new Ogre();
                    else if (spawnChance < 20)
                        rooms[x, y].ItemInRoom = new GlovesOfMetal();
                    else if (spawnChance < 25)
                        rooms[x, y].ItemInRoom = new TeleportPotion();
                }
            }
        }

        void DisplayRooms()
        {
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                for (int x = 0; x < rooms.GetLength(0); x++)
                {
                    Room room = rooms[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write(player.Health >= player.MaxHealth / 2 ? "🙂" : "😲");
                    else if (room.MonsterInRoom != null)
                        Console.Write("😈");
                    else if (room.ItemInRoom != null)
                        Console.Write("📦");
                    else
                        Console.Write("🔹");
                }
                Console.WriteLine();
            }
        }

        void DisplayStats()
        {
			Console.WriteLine("");
			Console.WriteLine($"Health❤️: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Attack Strength⚔️: {player.AttackStrength}");
            Console.WriteLine($"Monster Counter🧌: {Monster.MonsterCounter}");
			Console.WriteLine("");
			Console.WriteLine("Player's backpack:");

			foreach (ICarriable item in player.Backpack)
            {
                Console.WriteLine(item.Name);
            }
        }

        bool CheckForValidMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < rooms.GetLength(0) &&
                newY >= 0 && newY < rooms.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                return true;
            }
            else
                return false;
        }

        void ExploreRoom()
        {
            Room currentRoom = rooms[player.X, player.Y];
            if (currentRoom.ItemInRoom != null)
            {
                player.Backpack.Add(currentRoom.ItemInRoom);
                currentRoom.ItemInRoom.Use(player, WorldWidth, WorldHeight);
                currentRoom.ItemInRoom = null;
            }

            if (currentRoom.MonsterInRoom != null)
            {
                player.Attack(currentRoom.MonsterInRoom);
                if (currentRoom.MonsterInRoom.IsAlive)
                    currentRoom.MonsterInRoom.Attack(player);
                else
                {
                    player.Backpack.Add(currentRoom.MonsterInRoom);
                    currentRoom.MonsterInRoom = null;
                }
            }   
        }

        void GameOver()
        {
            Console.Clear();
            
            if (player.IsAlive)
                Console.WriteLine("Congratulations!");
            else
                Console.WriteLine("You perished!");

            Console.ReadKey();
            Play();
        }
    }
}
