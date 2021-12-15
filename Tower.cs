using System;
using System.Collections.Generic;
using System.Text;

namespace Tower_of_Revenge
{
    class Tower
    {
        static Random rand = new Random();
        public static int floorNumber = 0;

        public static void NextFloor()
        {
            floorNumber += 1;
        }
        public static void Debuff()
        {
            switch (floorNumber)
            {
                
                case 1:
                    Console.Clear();
                    Console.WriteLine("A thief was hiding on the next floor. You've lost all of your money");
                    Program.currentPlayer.money = 0;
                    Console.ReadKey();
                    break;
                case 2:

                    Encounters.SecondFloorBoss();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("You can't see any enemies at the entrance so you've decided to take a break to check your equipment");
                    Console.ReadKey();
                    switch(rand.Next(0,2))
                    {
                        case 0:
                            Console.WriteLine("You've slipped and broke your finger. You lose 2 hp");
                            Program.currentPlayer.health -= 2;
                            if(Program.currentPlayer.health <= 0)
                            {
                                Program.currentPlayer.health = 1;
                            }
                            break;
                        case 1:
                            Console.WriteLine("Your sword is getting blunt");
                            Console.WriteLine("Your damage decreases by 1");
                            Program.currentPlayer.damage-= 1;
                            break;
                        case 2:
                            Console.WriteLine("Your shield is dented in many places.");
                            Console.WriteLine("Your armor decreases by 1");
                            Program.currentPlayer.armor -= 1;
                            break;
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("The fourth floor is full of goblins. You must get past them in one go. There's no time for rest.");
                    Console.WriteLine("");
                    Console.WriteLine("Game tip: Resting on this floor will make a goblin attack you");
                    Console.ReadKey();
                    break;

                case 5:
                    Encounters.LastBossFight();
                    Console.ReadKey();
                    break; 




            }
        }
       

    }
}
