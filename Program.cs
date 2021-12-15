using System;

namespace Tower_of_Revenge
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            bool started = false;
            if (!started) { 
            Start();
            started = true;
            }

            Menu();
            
           
        }
        public static void Menu()
        {
            while (mainLoop)
            {
                Console.Clear();
                Console.WriteLine("===========================");
                Console.WriteLine("| (F)ight    (S)hop       |");
                Console.WriteLine("| (R)est     (N)ext Floor |");
                Console.WriteLine("===========================");

                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " |  Money: " + Program.currentPlayer.money);
                Console.WriteLine("");
                Console.WriteLine("Health: " + Program.currentPlayer.health + " / " + Program.currentPlayer.maxHealth + " | Your damage: " + Program.currentPlayer.damage + " |  Your armor: " + Program.currentPlayer.armor);
                Console.WriteLine("");
                Console.WriteLine("Xp: " + Program.currentPlayer.xp + "/" + currentPlayer.GetLevelUpValue() + " |  Level: " + Program.currentPlayer.level);
                Console.WriteLine("");
                Console.WriteLine("Current Floor: " + Tower.floorNumber);
                Console.WriteLine("");
                Console.WriteLine("Recommended level before going to next floor: " + (3 + Tower.floorNumber * 2));
                
                string temp = Console.ReadLine();
                if (temp.ToLower() == "f" || temp.ToLower() == "fight")
                {
                    Encounters.BasicFight();
                }
                else if (temp.ToLower() == "r" || temp.ToLower() == "rest")
                {
                    if(Tower.floorNumber != 4) { 
                        if (currentPlayer.health < Math.Round(0.7 * currentPlayer.maxHealth))
                         {
                        currentPlayer.health += Convert.ToInt32(Math.Ceiling(0.7 * Convert.ToDouble(currentPlayer.maxHealth))) - currentPlayer.health;
                         }
                         else
                         {
                         Console.WriteLine("You can't rest when you have more than 70% of your maximum health");
                         }
                    }
                    else if(Tower.floorNumber == 4)
                    {
                       
                        Console.Clear();
                        Console.WriteLine("You've tried to rest but you got attacked in the middle of your sleep.");
                        Console.ReadKey();
                        Encounters.Combat(false, "Goblin", 2, 2);
                    }

                }
                else if (temp.ToLower() == "s" || temp.ToLower() == "shop")
                {
                    Shop.RunShop(currentPlayer);
                }
                else if (temp.ToLower() == "n" || temp.ToLower() == "next")

                {
                    Console.WriteLine("You're going to the next floor");
                    Tower.NextFloor();
                    Tower.Debuff();

                }


            }
        }
        static void Start()
        {
             
            Console.WriteLine("                     Tower of Revenge          ");
            Console.WriteLine("");
            Console.WriteLine(@"
                    
                          |~
                        uuuuu
                        |_#-|
                        | _#|
                        |_ -|
   ________ .$$. ______ | - | _____________
           .#$$$. __    |-  | ....__
     _.--' $$$$$$    ` -[__N]        `--a:f-
           $$$$$$    -.
      -.    `:/'    _.))        .--.
             ||   .'.-'     _..-.. _.-.
      ._.-.  '     .'      `.
    - '     `.   .    `. -'
             `. .      `--..
                 `."                      
);
            Console.WriteLine("");
            Console.WriteLine("What's your name? ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You've finally found the hiding place of your archenemy - Omniphobia The Emperor.");
            Console.WriteLine("He's the one who destroyed your village and murdered your wife.");
            Console.WriteLine("You must get to the top of his tower but it won't be easy because all of the floors are guarded by hordes of monsters.");
            Console.WriteLine("However, you're not worried. This is the moment you've been training for.");
            Console.WriteLine("It's time to get your revenge !");
            
            Console.ReadKey();

            
           
           
        }
    }
}
