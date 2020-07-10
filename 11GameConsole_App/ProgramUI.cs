using System;

namespace _11GameConsole_App
{
    public class ProgramUI : Player
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.GuessPlayer = 1;
            player.WordPlayer = 2;
            player.Player1Score = 0;
            player.Player2Score = 0;
            int player1Score = 0;
            int player2Score = 0;
            string wordToGuess;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string guess;
            bool tie = false;
            bool done = false;
            while (!done)
            {

                {
                    Console.WriteLine("Player " + player.WordPlayer + ", pick a word or phrase. Make sure that player " + player.GuessPlayer + " isn't looking!");
                    wordToGuess = Console.ReadLine().ToLower();
                    Console.Clear();
                    guess = wordToGuess;
                    for (int i = 0; i != wordToGuess.Length; i++)
                    {
                        if (alphabet.Contains(wordToGuess[i]))
                        {
                            guess = guess.Replace(wordToGuess[i], '*');
                        }
                    }
                    int characters = 0;
                    for (int i = 0; i != guess.Length; i++)
                    {
                        if (guess[i] == '*')
                        {
                            characters++;
                        }
                    }
                    Console.WriteLine("Player " + player.GuessPlayer + ". The word or phrase you need to guess has " + characters + " letters in it that you must guess!.");
                    bool gameEnd = false;
                    bool win = false;
                    string badLetters = "";
                    int miss = 6; //change to vary number of guesses dependent on word length
                    string letter;
                    StringBuilder sb = new StringBuilder(guess);
                    while (!gameEnd)
                    {
                        Console.WriteLine(guess);
                        Console.WriteLine("Guess a letter!");
                        Console.WriteLine("Wrong letters: " + badLetters);
                        letter = Console.ReadLine().ToLower();
                        if (letter.Length == 1 && wordToGuess.Contains(letter))
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            for (int i = 0; i != wordToGuess.Length; i++)
                            {
                                if (wordToGuess[i] == letter.ToCharArray()[0])
                                {
                                    sb[i] = letter.ToCharArray()[0];
                                    guess = sb.ToString();
                                }
                            }
                            if (!guess.Contains("*"))
                            {
                                gameEnd = true;
                                win = true;
                            }
                        }
                        else if (letter == wordToGuess)
                        {
                            win = true;
                            gameEnd = true;
                        }
                        else
                        {
                            bool solveAttempt = false;
                            if (!badLetters.Contains(letter) || letter.Length == wordToGuess.Length)
                            {
                                if (letter.Length == wordToGuess.Length)
                                {
                                    solveAttempt = true;
                                }
                                if (solveAttempt == false)
                                {
                                    if (letter.Length == 1)
                                    {
                                        badLetters += (" " + letter);
                                        Console.WriteLine("Sorry that letter is incorrect!");
                                        miss--;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (miss != 0)
                            {
                                Console.WriteLine("You have " + miss + " wrong guesses left!");
                            }
                            else
                            {
                                gameEnd = true;
                            }
                        }
                    }
                    if (win)
                    {
                        Console.WriteLine("Congratulations! You Won! The phrase was " + wordToGuess + ".");
                        if (player.GuessPlayer == 1)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }
                        Console.WriteLine("Score: ");
                        Console.WriteLine("Player 1:  " + player1Score);
                        Console.WriteLine("Player 2:  " + player2Score);
                    }
                    else
                    {
                        Console.WriteLine("Game Over!");
                        Console.WriteLine("The word was " + wordToGuess + ".");
                        if (player.WordPlayer == 1)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Score: ");
                        Console.WriteLine("Player 1:  " + player1Score);
                        Console.WriteLine("Player 2:  " + player2Score);
                    }
                    bool exitGame = false;
                    if (tie)
                    {
                        if (player1Score > player2Score)
                        {
                            Console.WriteLine("Player 1 wins!");
                            done = true;
                        }
                        else if (player2Score > player1Score)
                        {
                            Console.WriteLine("Player 2 wins!");
                            done = true;
                        }
                    }
                    else
                    {
                        while (!exitGame)
                        {
                            Console.WriteLine("Would you like to play again? [y/n]");
                            string again = Console.ReadLine().ToLower();
                            if (again == "y")
                            {
                                done = false;
                                exitGame = true;
                                if (player.GuessPlayer == 1)
                                {
                                    player.GuessPlayer = 2;
                                    player.WordPlayer = 1;
                                }
                                else
                                {
                                    player.GuessPlayer = 1;
                                    player.WordPlayer = 2;
                                }
                            }
                            else if (again == "n")
                            {

                                exitGame = true;
                                if (player1Score > player2Score)
                                {
                                    Console.WriteLine("Player 1 wins!");
                                    done = true;
                                }
                                else if (player2Score > player1Score)
                                {
                                    Console.WriteLine("Player 2 wins!");
                                    done = true;
                                }
                                else
                                {
                                    Console.WriteLine("You can't leave yet we have a tie!");
                                    Console.WriteLine("Time to settle this...");
                                    tie = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}