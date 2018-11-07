using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRandomNumber
{
    class Program
    {
        static string result = @"c:\temp\testResult.txt";
        static string score = @"c:\temp\testScore.txt";
        static string name;


        static void Main(string[] args)
        {
            bool isPlay = true;

            Console.WriteLine("Entrez votre nom");
            name = Console.ReadLine();

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

            int cpt = 0;
            bool hasWin = false;

            List<int> AllReponse = new List<int>();

            while (hasWin == false)
            {
                Console.WriteLine("indiquez un chiffre entre 1 et 100 (Essai {0})", cpt);

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
                    cpt++;
                    Console.WriteLine();
                    AllReponse.Add(rep);
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
            FileResult(rnd, cpt, AllReponse, name);
            ScoreResult(name, cpt);
            AllReponse = new List<int>();
        }

        public static void ScoreResult(string name, int cpt)
        {
            int id = 0;
            id++;

            if (!File.Exists(score))
            {
                using (StreamWriter sw = File.CreateText(score))
                {
                    sw.WriteLine("Classement général");
                    sw.WriteLine("**************************************");
                    sw.WriteLine();
                    sw.WriteLine("Class;Nom;Point");
                    sw.WriteLine("--------------------------------------");
                    sw.WriteLine("{0}. {1}: {2}", id, name, cpt);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(score))
                {
                    sw.WriteLine("{0}. {1}: {2}", id, name, cpt);
                }
            }
        }

        public static void FileResult(int rnd, int cpt, List<int> AllResponse, string name)
        {
            if (!File.Exists(result))
            {
                using (StreamWriter sw = File.CreateText(result))
                {
                    sw.WriteLine("Résultat pour {0}, le {1}", name, DateTime.Now.ToShortDateString());
                    sw.WriteLine("--------------------------------------");
                    sw.WriteLine("La bonne réponse est: {0}", rnd);
                    sw.WriteLine("Nombre d'essais: {0}", cpt);
                    sw.WriteLine("Voici vos réponse: ");
                    AllResponse.ForEach(x => sw.Write(x.ToString() + " - "));
                    sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(result))
                {
                    sw.WriteLine();
                    sw.WriteLine("***************************************");
                    sw.WriteLine();
                    sw.WriteLine("Résultat pour {0}, le {1}", name, DateTime.Now.ToShortDateString());
                    sw.WriteLine("--------------------------------------");
                    sw.WriteLine("La bonne réponse est: {0}", rnd);
                    sw.WriteLine("Nombre d'essais: {0}", cpt);
                    sw.WriteLine("Voici vos réponse: ");
                    AllResponse.ForEach(x => sw.Write(x.ToString() + " - "));
                    sw.WriteLine();
                }
            }
        }
    }
}

