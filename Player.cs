using System;
using System.Collections.Generic;
using System.Text;

namespace Tower_of_Revenge
{
    
    public class Player
    {
        static Random rand = new Random();
        public string name;
        public int health = 15;
        public int maxHealth = 15;
        public int damage = 2;
        public int armor = 2;
        public int money = 0;
        public int xp = 0;
        public int level = 1;
        public int potion = 3;

        public int GetLevelUpValue()
        {
            return 4 * level + 5;       
        }

        public bool CanLevelUp()
        {
            if(xp >= GetLevelUpValue())
            {
                return true;
                
            }
            else
                return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;
                int levelReward = rand.Next(0, 3);
                Console.Clear();
                Console.WriteLine("==================");
                Console.WriteLine("|You've leveled up|");
                Console.WriteLine("==================");

                switch (levelReward)
                {
                    case 0:
                        Program.currentPlayer.damage += 1;
                        Console.WriteLine("You gain +1 to damage");
                        break;
                    case 1:
                        Program.currentPlayer.armor += 1;
                        Console.WriteLine("You gain +1 to armor");
                        break;
                    case 2:
                        Program.currentPlayer.maxHealth += 1;
                        Program.currentPlayer.health += 1;
                        Console.WriteLine("You gain +1 to maximum health");
                        break;
                }
                Console.ReadKey();

            }
            
            

        }

    }
}
