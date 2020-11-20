using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class GameRound
    {
        public void PlayGameRound()
        {
            var secredWordGenerator = new SecredWordCountryGenerator();
            Console.Title = ("HangMan Game");
            var countryWithCapitalCity = secredWordGenerator.GetSecredWord();
            string secretWord = countryWithCapitalCity.CapitalCity;
            List<string> letterGuessed = new List<string>();
            int live = 5;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome To HangMan Game");
            Console.WriteLine("hello");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Guess for a {0} Letter Word  ", secretWord.Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You Have {0} Live", live);
           

            PrintWordBoard(secretWord, letterGuessed);

            while (live > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                if (IsAlreadyGuessedBefore(letterGuessed, input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Entered Letter [{0}] already", input);                              
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Try a Different Word");
                    PrintLeftAlphabet(input);
                    continue;
                }

                letterGuessed.Add(input);                                        
                if (IsWordToGuess(secretWord, letterGuessed))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(secretWord);
                    Console.WriteLine("Congratulations");
                    break;
                }

                if (IsLetterInWordToGuess(secretWord, input))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Nice Entry");
                    PrintWordBoard(secretWord, letterGuessed);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Letter Not in My Word ");
                    live -= 1;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You Have {0} Live", live);

                    PrintWordBoard(secretWord, letterGuessed);
                }

                Console.WriteLine();
                if (live == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Game Over \nMy Secret Word is [ {0} ]", secretWord);
                    break;
                }
                
            }
        }

        private static void PrintWordBoard(string secretword, List<string> letterGuessed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Isletter(secretword, letterGuessed));
        }

        private static bool IsAlreadyGuessedBefore(List<string> letterGuessed, string input)
        {
            return letterGuessed.Contains(input);
        }

        private static bool IsLetterInWordToGuess(string secretword, string input)
        {
            return secretword.Contains(input);
        }

        protected static bool IsWordToGuess(string secreword, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < secreword.Length; i++)
            {
                string c = Convert.ToString(secreword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;
                }
            }
            return word;
        }
        static string Isletter(string secretword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }
        static void PrintLeftAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();
            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }
            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");
            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }
            Console.WriteLine();
        }
        
    }
    
}


