using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rnd = random.Next(1, 100);

            bool win = false;
            while (win == false)
            {
                Console.WriteLine("indiquez un chiffre entre 1 et 100");
                string chiffre = Console.ReadLine();
                bool success = int.TryParse(chiffre, out int rep);
                Console.WriteLine();

                if (success && rep < 101 && rep > 0)
                {
                    if (rep > rnd)
                    {
                        Console.WriteLine("Nombre plus grand");
                    }

                    else if (rep < rnd)
                    {
                        Console.WriteLine("Nombre plus petit");
                    }
                    else
                    {
                        win = true;
                    }
                        Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("erreur de saisie");
                    Console.WriteLine();
                }
            }

            if (win)
            {
                Console.WriteLine("Bingo !!");
            }

            Console.ReadLine();
        }
    }
}
