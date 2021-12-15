using System;
using System.Collections.Generic;
using System.Text;

namespace Tower_of_Revenge
{
    public class Encounters
    {
        static Random rand = new Random(); // obiekt do generowania losowych liczb z danego przedziału

        
        
        public static void LastBossFight() // kod do wywołania walki z ostatnim bossem
        {
            Console.Clear();
            Console.WriteLine("You can see your nemesis... Your blood is boiling and you want to murder him as fast as possible");
            Console.ReadKey();
            Combat(false,"Omniphobia the Emperor", 20, 50);
            Console.Clear();
            Console.WriteLine("You've finally got your revenge. It's time to go home and rest.");
            Console.WriteLine("=================");
            Console.WriteLine("|  You've won!  | ");
            Console.WriteLine("=================");
            Console.WriteLine(""); 
            Console.WriteLine("Congratulations " + Program.currentPlayer.name+ "!");
            Console.WriteLine("You are the mightiest of warriors"); 
            Console.ReadKey();
            System.Environment.Exit(0);

        }
        
        public static void SecondFloorBoss() // kod do wywołania walki z bossem na drugim piętrze
        {
            Console.Clear();
            Console.WriteLine("An enemy is guarding the entrance to the second floor. Defeat him in order to pass.");
            Console.ReadKey();
            Combat(false, "Stone Sentinel", 10, 25);

            
        }
        
        public static void BasicFight()
        {
            Console.WriteLine("You can see your next enemy");
            Combat(true, "", 0, 0);
           
        }
        // walka z losowym przeciwnikiem
       

        
        public static void Combat(bool random, string name, int damage, int health) // system walki
        {
            string n = "";
            int d = 0;
            int h = 0;
            if (random)
            {
                n = RandomName();
                d = rand.Next(1, 6);
                h = rand.Next(1, 10);

                if (Tower.floorNumber > 0)
                {
                    d = rand.Next(1, 6) + 3 * Tower.floorNumber;
                    h = rand.Next(1, 10) + 2 * Tower.floorNumber;

                }

            }
            else
            {
                n = name;
                d = damage;
                h = health;

            }

            while(h > 0 )
            {
                
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("Damage: " + d + " | " + "Health: " + h );



                Console.WriteLine("========================");
                Console.WriteLine("| (A)ttack    (D)efend |");
                Console.WriteLine("| (R)un       (P)otion |");
                Console.WriteLine("========================");
                Console.WriteLine("Number of Potions: " +Program.currentPlayer.potion + "   " + "   Health: " + Program.currentPlayer.health + "/" + Program.currentPlayer.maxHealth);
                string action = Console.ReadLine();

                if(action.ToLower() == "a" || action.ToLower() == "attack")
                {
                    Console.WriteLine("You swing your sword in an attempt to damage the enemy");
                    int attackValue = Program.currentPlayer.damage + rand.Next(1,7);
                    int damageTaken = d - Program.currentPlayer.armor;
                    if( damageTaken <= 0)
                    {
                        damageTaken = 1;
                    }
                   

                    Console.WriteLine("You've dealt  " + attackValue + " Damage ");
                    Console.WriteLine("The enemy attacks you for " + damageTaken + " Damage");
                    Program.currentPlayer.health -= damageTaken;
                    h -= attackValue;
                   
                }
                else if (action.ToLower() == "d" || action.ToLower() == "defend")
                {
                    Console.WriteLine(" You try to predict your enemy's attack and get into a defensive stance.");
                    int attackValue = Program.currentPlayer.damage - 2;
                    if(attackValue <= 0)
                    {
                        attackValue = 1;
                    }
                    int damageTaken = d - ( Program.currentPlayer.armor * 2 );
                    if (damageTaken < 0)
                    {
                        damageTaken = 1;
                    }



                    Console.WriteLine("You've dealt  " + attackValue + " Damage ");
                    Console.WriteLine("The enemy attacks you for " + damageTaken + " Damage");
                    Program.currentPlayer.health -= damageTaken;
                    h -= attackValue;

                }
                else if (action.ToLower() == "r" || action.ToLower() == "run")
                {
                    if (n != "Stone Sentinel" & n != "Omniphobia the Emperor")
                    {

                        Console.WriteLine("You've realised that you can't beat your opponent now and you try to escape his grasp.");
                        int runOutcome = rand.Next(0, 2);
                        if (runOutcome == 0)
                        {
                            Console.WriteLine("You've tried your best but the enemy grabbed you in the last moment");
                            int damageTaken = d - Program.currentPlayer.armor;
                            if (damageTaken <= 0)
                            {
                                damageTaken = 1;
                            }
                            Program.currentPlayer.health -= damageTaken;
                            Console.WriteLine("The enemy attacks you for " + damageTaken + " Damage");

                        }
                        else
                        {
                            Console.WriteLine("You've successfuly escaped");
                            Console.WriteLine("You've decided to hide in the shop");
                            Console.ReadKey();
                            Shop.RunShop(Program.currentPlayer);

                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You cannot escape from the guardian");
                    }
                }
                else if (action.ToLower() == "p" || action.ToLower() == "potion")
                {
                   if(Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You've realised that you're out of potions.");
                    }
                   else
                    {
                        int hpRecovered = 5 + Program.currentPlayer.level;
                        
                        int actualHpRecovered = Program.currentPlayer.maxHealth - Program.currentPlayer.health;
                        if (actualHpRecovered < hpRecovered) {
                            Console.WriteLine("You've healed yourself for " + actualHpRecovered + " health");
                        }
                        else
                        {
                            Console.WriteLine("You've healed yourself for " + hpRecovered + " health");
                        }
                        
                         Program.currentPlayer.potion -= 1;
                  
                        Program.currentPlayer.health += hpRecovered ;
                        if(Program.currentPlayer.health > Program.currentPlayer.maxHealth)
                        {
                            Program.currentPlayer.health = Program.currentPlayer.maxHealth;
                                                    }
                    }
                   
                    
                }
                Console.ReadKey();
                //Deaths
                if (Program.currentPlayer.health <= 0) 
                {
                    Console.WriteLine("You've died miserably..."); 
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                
               


            }
            int treasure = rand.Next(1, 15);
            int xpTreasure = rand.Next(1,5);
          

            switch (Tower.floorNumber)
            {
                
                case 1:
                     treasure = rand.Next(3, 20);
                     xpTreasure = rand.Next(2, 8);
                    break;
                case 2:
                     treasure = rand.Next(8, 30);
                    xpTreasure = rand.Next(3, 10);
                    break;
                case 3:
                    treasure = rand.Next(14, 40);
                    xpTreasure = rand.Next(4, 13);
                    break;
                case 4:
                    treasure = rand.Next(25, 50);
                    xpTreasure = rand.Next(5, 15);
                    break;

            }
            if (n != "Goblin" & n!= "Stone Sentinel" & n!= "Omniphobia the Emperor")
            {
                Console.Clear();
            Console.WriteLine("As you search through the corpse you stumble upon " + treasure + " golden coins");
            Console.WriteLine("You're also blessed with " + xpTreasure + " experience points");
            Console.ReadKey();
            Program.currentPlayer.money += treasure;
            Program.currentPlayer.xp += xpTreasure;
            }else if(n == "Stone Sentinel")
            {
                Console.Clear();
                treasure = 70;
                xpTreasure = 40;
                Console.WriteLine("As you search through the corpse you stumble upon " + treasure + " golden coins");
                Console.WriteLine("You're also blessed with " + xpTreasure + " experience points");
                Console.ReadKey();
                Program.currentPlayer.money += treasure;
                Program.currentPlayer.xp += xpTreasure;

            }
            else if(n == "Omniphobia the Emperor")
            {
                Console.Clear();
            }
            if (Program.currentPlayer.CanLevelUp())
            {
                Program.currentPlayer.LevelUp();
                
            }

            static string RandomName()
                 {
                     switch (rand.Next(0, 5))
                   {
                    case 0:
                        return "Fallen";
                    case 1:
                        return "Stone Golem";
                    case 2:
                        return "Living Corpse";
                    case 3:
                        return "Skeleton Warrior ";
                    case 4:
                        return "Ghost";

                   

                }
                return "random enemy";
            }

   
        }


    }
}
