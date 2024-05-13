using System;

namespace mini_jeu_de_math
{
    internal class Program
    {
        static bool PoserQuestion(int nombreMin, int nombreMax)
        {
            int score = 0;
            int reponseInt = 0;
            Random rnd = new Random();

            while (true)
            {
                int a = rnd.Next(nombreMin, nombreMax + 1);
                int b = rnd.Next(nombreMin, nombreMax + 1);
                int o = rnd.Next(1, 5);
                int resultatAttendu; 

                if(o == 1)
                {
                    Console.Write(a + " + " + b + " = ");
                    resultatAttendu = a + b;
                }
                else if(o == 2)
                {
                    Console.Write(a + " - " + b + " = ");
                    resultatAttendu = a - b;
                }
                else if(o == 3)
                {
                    Console.Write(a + " ÷ " + b + " = ");
                    resultatAttendu = a / b;
                }
                else
                {
                    Console.Write(a + " x " + b + " = ");
                    resultatAttendu = a * b;
                }

                string reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse);
                    if(reponseInt == resultatAttendu)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : Veuillez rentrer un nombre");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int NB_QUESTIONS = 6;
            int score = 0;
            float moyenne = (NB_QUESTIONS / 2f);

            for(int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine("Question n°" + (i+1) + "/" + NB_QUESTIONS);
                bool bonneReponse = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);
                if (bonneReponse)
                {
                    Console.WriteLine("Bonne réponse!");
                    score++;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse!");
                    Console.WriteLine();
                }
            }

            if(score == NB_QUESTIONS)
            {
                Console.WriteLine("Excellent c'est un perfect!");
            }
            else if (score > (NB_QUESTIONS / 2) && score < NB_QUESTIONS)
            {
                Console.WriteLine("C'est bien! Au dessus de la moyenne, continue comme ça!");
            }
            else if(score == moyenne)
            {
                Console.WriteLine("La moyenne! Aller on y croit tu peux mieux faire");
            }
            else if(score < moyenne && score > 0)
            {
                Console.WriteLine("En dessous de la moyenne! Tu peux y arriver !");
            }
            else
            {
                Console.WriteLine("N'abandonne pas, révise et recommance :'(");
            }

            Console.WriteLine("Score : " + score + "/" + NB_QUESTIONS);
        }
    }
}
