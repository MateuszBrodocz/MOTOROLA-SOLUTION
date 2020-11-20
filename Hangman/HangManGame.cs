using System;

namespace Hangman
{
    class HangManGameRestartRound
    {
        static void Main()
        {
            string restartAnswer = "y";
            while (restartAnswer == "y")
            {
                GameRound gameRound = new GameRound();
                gameRound.PlayGameRound();

                do {
                    Console.WriteLine("Do you want to play again? y/n");
                    restartAnswer = Console.ReadLine();

                    if (restartAnswer != "y" && restartAnswer != "n")
                    {
                        Console.WriteLine("Try a Different Word");
                        continue;
                    }
                    break;
                } while (true);

                if (restartAnswer == "n")
                {
                    break;
                }
            }
        }
    }

}