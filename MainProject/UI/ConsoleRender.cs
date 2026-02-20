using Lab.Domain.Core.StatisticsLogic;

namespace Lab.UI;

using Domain.Core.Player;
using Contracts;

public class ConsoleRender : IBoardRenderer
{
    private const int OffsetX = 16;
    private const int OffsetY = 5;
    private const int CellWidth = 5;
    public void DrawGameScreen(char[] board, int selectedIndex, int roundNumber, PlayerBase player1, PlayerBase player2, int[] score)
    {
        Console.Clear();

        Console.SetCursorPosition(20, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Round {roundNumber}");
        Console.ResetColor();

        Console.SetCursorPosition(0, 2);
        Console.Write($"{player1.Name} (");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{player1.Side}");
        Console.ResetColor();
        Console.Write($"): {score[0]}  VS  ");

        Console.Write($"{player2.Name} (");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{player2.Side}");
        Console.ResetColor();
        Console.Write($"): {score[1]}");

        Console.SetCursorPosition(0, 3);
        Console.Write($"Draws: {score[2]}");

        DrawBoard(board, selectedIndex);
    }
    public void DrawBoard(char[] board, int selectedIndex)
    {
        for (int i = 0; i < board.Length; i++)
        {
            bool isSelected;

            if (i == selectedIndex)
            {
                isSelected = true;
            }
            else
            {
                isSelected = false;
            }

            DrawCell(i, board[i], isSelected);
        }
    }
    public void DrawCell(int index, char symbol, bool isSelected)
    {
        int row = index / 3;
        int col = index % 3;

        int left = OffsetX + (col * CellWidth);
        int top = OffsetY + row;

        Console.SetCursorPosition(left, top);

        ConsoleColor bracketColor = ConsoleColor.White;

        if (isSelected)
        {
            bracketColor = ConsoleColor.DarkGray;
        }

        Console.ForegroundColor = bracketColor;
        Console.Write("[ ");

        if (symbol == 'X')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
        }
        else if (symbol == 'O')
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("O");
        }
        else
        {
            Console.Write(" ");
        }

        Console.ForegroundColor = bracketColor;
        Console.Write(" ]");
        Console.ResetColor();

        if ((index + 1) % 3 == 0)
        {
            Console.WriteLine();
        }
    }

    public void DrawScore()
    {
        InputHandler inputHandler = new InputHandler();
        StatisticsManager statisticsManager = new StatisticsManager();
        List<StatisticsObject>? allGamesStatistics = statisticsManager.DeserializeStatistics();
        
        StatisticsCollection collection = new StatisticsCollection();
        
        if (allGamesStatistics != null)
        {
            for (int i = 0; i < allGamesStatistics.Count; i++)
            {
                collection.Add(allGamesStatistics[i]);
            }
        }

        bool stayInMenu = true;
        int sortMode = 0; 

        while (stayInMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                     Match History");
            Console.ResetColor();

            if (allGamesStatistics is null || collection.Count() == 0)
            {
                Console.WriteLine("\nNo games played yet.");
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
                return;
            }

            if (sortMode == 1)
            {
                collection.Sort();
            }
            else if (sortMode == 2) 
            {
                collection.Sort(new Lab.Domain.Core.StatisticsLogic.Comparers.XComparer());
            }

            NewDrawSortMatch(collection, sortMode == 0);
            
            Console.WriteLine("\n[Enter] - Delete statistics | [Escape] - Back to menu");
            ShowStatisticsSortMenu(sortMode); 

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Escape:
                    stayInMenu = false;
                    break;
                case ConsoleKey.Enter:
                    statisticsManager.DeleteStatistics();
                    allGamesStatistics = null; 
                    collection = new StatisticsCollection();
                    break;
                case ConsoleKey.Spacebar:
                    sortMode++;
                    if (sortMode > 2) sortMode = 0;
                    break;
            }
        }
    }

    public void ShowStatisticsSortMenu(int currentMode)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("[Spacebar] - Change Sort Mode: ");
        
        Console.ForegroundColor = ConsoleColor.White;
        if (currentMode == 0) Console.Write("Time (Default)");
        else if (currentMode == 1) Console.Write("Names (A-Z)");
        else if (currentMode == 2) Console.Write("X Wins (Low-High)");
        
        Console.ResetColor();
        Console.WriteLine();
    }

    public void RenderWin(IBoardRenderer renderer, char[] board, PlayerBase player1, PlayerBase player2, int[] score, char sideThatWon, out bool winHappenedFlag)
    {
        winHappenedFlag = false;
        renderer.DrawBoard(board, -1);

        if (sideThatWon == player1.Side)
        {
            score[0]++;
            Console.Write($"\n{player1.Name} (");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{player1.Side}");
            Console.ResetColor();
            Console.WriteLine(") won!");
            winHappenedFlag = true;
        }
        else if (sideThatWon == player2.Side)
        {
            score[1]++;
            Console.Write($"\n{player2.Name} (");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{player2.Side}");
            Console.ResetColor();
            Console.WriteLine(") won!");
            winHappenedFlag = true;
        }
    }

    public void RenderTie(IBoardRenderer renderer, char[] board, int[] score)
    {
        renderer.DrawBoard(board, -1);

        score[2]++;
        Console.WriteLine("Draw!");
    }

    public void ShowPostRoundMenu()
    {
        Console.SetCursorPosition(0, OffsetY + 7);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[Enter] - Next round");
        Console.ResetColor();

        Console.SetCursorPosition(25, OffsetY + 7);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[Esc] - Return to menu");
        Console.ResetColor();
    }

    public void ShowStatisticsMenu()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\n[Enter] - Clear history         ");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[Esc] - Return to menu");
        Console.ResetColor();
    }

    public void ShowStatisticsSortMenu(bool toggle)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        if (toggle)
        {
            Console.WriteLine("\n[Spacebar] - Sort by newest");
        }
        else
        {
            Console.WriteLine("\n[Spacebar] - Sort by oldest");
        }
        Console.ResetColor();
    }

    public List<StatisticsObject> DrawSortMatch(List<StatisticsObject> allGamesStatistics, bool sortNewestFirst)
    {
        if (sortNewestFirst)
        {
            for (int i = allGamesStatistics.Count - 1; i >= 0 ; i--)
            {
                DrawMatch(allGamesStatistics[i]);
            }
            
            allGamesStatistics.Reverse();
        }
        else
        {
            for (int i = 0; i < allGamesStatistics.Count ; i++)
            {
                DrawMatch(allGamesStatistics[i]);
            }
        }
        
        return allGamesStatistics;
    }

    public void NewDrawSortMatch (StatisticsCollection collection, bool sortNewestFirst)
    {
        var it = collection.GetEnumerator();

        if (sortNewestFirst)
        {
            for (int i = collection.Count() - 1; i >= 0; i--)
            {
                var item = collection.GetAt(i);
                DrawMatch(item);
            }             
        }   
        else
        {
            while (it.MoveNext())
            {
                var item = it.Current;
                DrawMatch((StatisticsObject)item);
            }
        }
    }   

    public void DrawMatch(StatisticsObject match)
    {
        Console.Write($"\n{match.PlayerOneName} (");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write('X');
        Console.ResetColor();
        Console.WriteLine($"): {match.XWinsCount}");

        Console.Write($"{match.PlayerTwoName} (");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write('O');
        Console.ResetColor();
        Console.WriteLine($"): {match.OWinsCount}");

        Console.WriteLine($"Draws: {match.DrawsCount}");
    }
}