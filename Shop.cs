using System;
using System.Collections.Generic;
using System.Text;

namespace Tower_of_Revenge
{
    public class Shop
    {
         static int damageCost = 20;
         static int armorCost = 20;
         static int potionCost = 25;
        static int healthCost = 15;

      

        public static void RunShop(Player p)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Adventurer's Shop");
            Console.WriteLine("Money: " + Program.currentPlayer.money);
            Console.WriteLine("=================");
            Console.WriteLine("| (D)amage      $ " + damageCost );
            Console.WriteLine("| (A)rmor       $ " + armorCost);
            Console.WriteLine("| (H)ealth      $ " + healthCost);
            Console.WriteLine("| (P)otion      $ " + potionCost);
            Console.WriteLine("=================");

            Console.WriteLine("| (L)eave          |");

            string input = Console.ReadLine();

            if(input.ToLower() == "d" || input.ToLower() == "damage")
            {
                if(damageCost <= p.money) { 
                p.damage += 1;
                p.money -= damageCost;
                    Console.WriteLine("You feel stronger");
                    damageCost = damageCost + 5;
                }
                else
                {
                    Console.WriteLine("You don't have enough money.");
                }

            }
            else if(input.ToLower() == "a" || input.ToLower() == "armor")
            {
                if (armorCost <= p.money)
                {
                    p.armor+= 1;
                    p.money -= armorCost;
                   
                    Console.WriteLine("You feel tankier");
                    armorCost = armorCost + 5;
                }
                else
                {
                    Console.WriteLine("You don't have enough money.");
                }
            }
            else if (input.ToLower() == "p" || input.ToLower() == "potion")
            {
                if (potionCost <= p.money)
                {
                    p.potion += 1;
                    p.money -= potionCost;
                    Console.WriteLine("Another potion might be useful");
                }
                else
                {
                    Console.WriteLine("You don't have enough money.");
                }
            }
            else if(input.ToLower() == "h" || input.ToLower() == "health")
            {
                if (healthCost <= p.money)
                {
                    p.maxHealth += 1;
                    p.health += 1;
                    p.money -= healthCost;
                    healthCost = healthCost + 5;
                    Console.WriteLine("Another potion might be useful");
                }
                else
                {
                    Console.WriteLine("You don't have enough money.");
                }
            }
            else if (input.ToLower() == "l" || input.ToLower() == "leave")
            {
                Console.WriteLine("You're leaving the shop");
                Program.Menu();
                
            }
        }
    }
}
