using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRandomNumber
{
    class Program
    {
        static string path = @"c:\temp\myTest.txt";
        static string name;

        static void Main(string[] args)
        {
            bool isPlay = true;
            while (isPlay)
            {
                Play();
                {
                    Console.WriteLine("Rejouer ? O / N");
                    string rep = Console.ReadLine();
                    if (rep.ToUpper() != "O")
                    {
                        isPlay = false;
                    }
                }
            }
        }

        public static void Play()
        {
            Random random = new Random();
            int rnd = random.Next(1, 100);

            List<int> AllReponse = new List<int>();

            bool hasWin = false;
            while (hasWin == false)
            {
                Console.WriteLine("indiquez un chiffre entre 1 et 100");

                string chiffre = Console.ReadLine();
                bool success = int.TryParse(chiffre, out int rep);
                Console.WriteLine();

                if (success && rep < 101 && rep > 0)
                {
                    if (rep > rnd)
                    {
                        Console.WriteLine("C'est moins");
                    }

                    else if (rep < rnd)
                    {
                        Console.WriteLine("C'est plus");
                    }
                    else
                    {
                        hasWin = true;
                    }
                    Console.WriteLine();
                    AllReponse.Add(rnd);
                }

                else
                {
                    Console.WriteLine("erreur de saisie");
                    Console.WriteLine();
                }
            }

            if (hasWin)
            {
                Console.WriteLine("Bingo !!");
            }
            else
            {
                Console.WriteLine("Désolé vous avez perdu. La réponse était {0}", rnd);
            }
            Console.WriteLine();
            AllReponse = new List<int>();

            string path = @"c:\temp\myTest.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Résultat pour {0}", name);
                    sw.WriteLine("--------------------------------------");
                    sw.WriteLine("La réponse était: {0}", rnd);
                    //sw.WriteLine("Voici vos réponse: {0}", );
                }
            }
        }
    }
}

