using Lab.Contracts;
using Lab.Domain.Core.Player;

namespace Lab.UI;

class InputHandler
{
    public int SelectCell(char[] board, ConsoleRender renderer, int lastSelectedCell, int round, PlayerBase player1, PlayerBase player2, int[] score)
    {
        int currentPosition = lastSelectedCell;

        Console.CursorVisible = false;
        Console.Clear();
        renderer.DrawGameScreen(board, currentPosition, round, player1, player2, score);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            int oldPositon = currentPosition;
            bool positionChanged = false;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    currentPosition -= 3;
                    if (currentPosition < 0)
                    {
                        currentPosition += 9;
                    }
                    positionChanged = true;
                    break;
                case ConsoleKey.DownArrow:
                    currentPosition += 3;
                    if (currentPosition > 8)
                    {
                        currentPosition -= 9;
                    }
                    positionChanged = true;
                    break;
                case ConsoleKey.LeftArrow:
                    currentPosition--;
                    if (currentPosition < 0)
                    {
                        currentPosition = 8;
                    }
                    positionChanged = true;
                    break;
                case ConsoleKey.RightArrow:
                    currentPosition++;
                    if (currentPosition > 8)
                    {
                        currentPosition = 0;
                    }
                    positionChanged = true;
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return currentPosition;
            }

            if (positionChanged)
            {
                renderer.DrawCell(oldPositon, board[oldPositon], false);
                renderer.DrawCell(currentPosition, board[currentPosition], true);
            }
        }
    }

    public string AskForName(string messageToUser)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(messageToUser);
            string? name = Console.ReadLine();

            if (name is null || name.Trim() == "")
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            return name.Trim();
        }
    }

    public bool RoundMenu()
    {
        while (true)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if (keyInfo == ConsoleKey.Enter)
            {
                return true;
            }
            if (keyInfo == ConsoleKey.Escape)
            {
                return false;
            }
        }
    }

    public bool ClearStatistics()
    {
        while (true)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if (keyInfo == ConsoleKey.Enter)
            {
                return true;
            }
            if (keyInfo == ConsoleKey.Escape)
            {
                return false;
            }
        }
    }

    public bool SortStatisticsToggle()
    {
        bool toggle = true;
        while (true)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if (keyInfo == ConsoleKey.Spacebar)
            {
                toggle = !toggle;
            }
            else if (keyInfo == ConsoleKey.Spacebar)
            {
                return toggle;
            }
        }
    }
}