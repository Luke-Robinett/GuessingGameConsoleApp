using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DisplayIntro();
                RunGame();
                DisplayEnding();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayEnding()
        {
            Console.WriteLine();
            Console.WriteLine("Thanks for playing! Come back again soon!");
            Console.WriteLine();
        }

        private static void RunGame()
        {
            var quit = false;
            while (!quit)
            {
                var status = GameStatus.InProgress;
                var score = 1000;
                var guessCount = 0;
                var secretNumber = (new Random()).Next(101);

                while (status == GameStatus.InProgress)
                {
                    DisplayUpdate(score, guessCount);
                    var guess = GetGuess();
                    if ((guess < 1) || (guess > 100))
                    {
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    }
                    else if (guess < secretNumber)
                    {
                        Console.WriteLine("Nope. Too low!");
                        score -= 100;
                        guessCount++;
                    }
                    else if (guess > secretNumber)
                    {
                        Console.WriteLine("That's too high!");
                        score -= 100;
                        guessCount++;
                    }
                    else
                    {
                        Console.WriteLine("That's right!");
                        guessCount++;
                        status = GameStatus.Won;
                    }
                    if (score == 0)
                    {
                        status = GameStatus.Lost;
                    }
                }
                if (status == GameStatus.Won)
                {
                    Console.WriteLine($"Congrats! You guessed the secret number in {guessCount} tries!");
                }
                else
                {
                    Console.WriteLine("Bummer! You ran out of points. Better luck next time!");
                }
                quit = !PlayAgain();
            }
        }

        private static bool PlayAgain()
        {
            Console.Write("Play again (y/n)? ");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.N)
            {
                return false;
            }

            return true;
        }

        private static int GetGuess()
        {
            var guess = 0;
            Console.Write("Enter guess: ");
            var guessString = Console.ReadLine();
            int.TryParse(guessString, out guess);

            return guess;
        }

        private static void DisplayUpdate(int score, int guessCount)
        {
            Console.WriteLine($"Score: {score}\nGuesses: {guessCount}");
        }

        private static void DisplayIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Guessing Game!");
            Console.WriteLine();
            Console.WriteLine("I'll think of a number between 1 and 100.");
            Console.WriteLine("You'll start out with 1000 points. Each time you guess incorrectly, you will lose 100 points.");
            Console.WriteLine("If you guess successfully before you run out of points, you win!");
            Console.WriteLine("To achieve awesomeness, try to guess in as few tries as possible!");
            Console.WriteLine();
            Console.WriteLine("Let's play!");
            Console.WriteLine();
        }
    }
}