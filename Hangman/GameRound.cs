using System;
using System.Collections.Generic;

namespace Hangman
{
    class GameRound
    {
        string secretWord;
        public void PlayGameRound()
        {
            var secredWordGenerator = new SecredWordCountryGenerator();
            Console.Title = ("HangMan Game");
            var countryWithCapitalCity = secredWordGenerator.GetSecredWord();
            secretWord = countryWithCapitalCity.CapitalCity;
            List<string> letterGuessed = new List<string>();
            List<string> letterGuessedButWrong = new List<string>();
            int live = 5;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome To HangMan Game");
            Console.WriteLine("hello");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Guess for a {secretWord.Length} letter word that is a capital city");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You Have {live} Live");

            PrintWordBoard(secretWord, letterGuessed, letterGuessedButWrong);

            while (live > 0)
            {
                string wordOrLetter = null;
                do
                {
                    Console.WriteLine("Do you want to guess a letter or a word? l/w");
                    wordOrLetter = Console.ReadLine();

                    if (wordOrLetter != "l" && wordOrLetter != "w")
                    {
                        Console.WriteLine("I do not understand.");
                        continue;
                    }
                    break;
                } while (true);

                if (wordOrLetter == "l")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Provide a letter");
                    string input = Console.ReadLine().ToLower();

                    if (IsAlreadyGuessedBefore(letterGuessed, input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You entered letter [{input}] already");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Try a different letter");
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
                        PrintWordBoard(secretWord, letterGuessed, letterGuessedButWrong);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Letter not in my word ");
                        live -= 1;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"You have {live} live");
                        letterGuessedButWrong.Add(input);

                        PrintWordBoard(secretWord, letterGuessed, letterGuessedButWrong);
                    }
                }
                else if (wordOrLetter == "w")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Provide a word");
                    string input = Console.ReadLine().ToLower();

                    if (input.ToLower() == secretWord.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(secretWord);
                        Console.WriteLine("Congratulations");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is not a word to guess :(");
                        live -= 2;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"You have {live} live");

                        PrintWordBoard(secretWord, letterGuessed, letterGuessedButWrong);
                    }
                }

                Console.WriteLine();
                if (live <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Game Over \nmy secret word is [ {secretWord} ]");
                    break;
                }

                Console.WriteLine();
                if (live <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The capital of {countryWithCapitalCity.Country}");
                }
            }
        }

        private static void PrintWordBoard(string secretword, List<string> letterGuessed, List<string> letterGuessedButWrong)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Isletter(secretword, letterGuessed));
            Console.WriteLine($"Wrong letters: ");
            foreach (var letter in letterGuessedButWrong)
            {
                Console.Write($" {letter} ");
            }
            Console.WriteLine();
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
                string c = Convert.ToString(secreword[i]).ToLower();
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return false;
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
                if (letterGuessed.Contains(c.ToLower()))
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
    }
}


