using Lab.UI;
using Lab.Domain.Core.Player;
using Lab.Domain.Core.StatisticsLogic;
using Lab.Domain.Core.TurnHandler;
using Lab.Domain.Core.WinConditionLogic;

public class Game
{
    public static void StartGame(PlayerBase player1, PlayerBase player2)
    {
        ConsoleRender renderer = new ConsoleRender();
        WinConditionChecker winChecker = new WinConditionChecker();
        TurnHandler turnHandler = new TurnHandler();
        StatisticsManager statisticsManager = new StatisticsManager();
        InputHandler inputHandler = new InputHandler();
        int[] score = new int [3];
        char emptyBoardCell = '\0';
        
        while (true)
        {
            char[] board = new char[9];
            bool isPlayerOneTurn = true;
            int lastSelectedCell = 0;

            while (true)
            {
                lastSelectedCell =
                    inputHandler.SelectCell(board, renderer, lastSelectedCell, 0, player1, player2, score);

                if (board[lastSelectedCell] != emptyBoardCell)
                {
                    continue;
                }

                turnHandler.HandleMove(ref isPlayerOneTurn, board, lastSelectedCell, player1, player2);

                TieChecker tieChecker = new TieChecker();
                bool isTie = tieChecker.CheckForTie(board);

                if (isTie)
                {
                    renderer.RenderTie(renderer, board, score);
                    break;
                }

                char sideThatWon = winChecker.CheckBoardForWin(board);

                if (sideThatWon == emptyBoardCell)
                {
                    continue;
                }

                renderer.RenderWin(renderer, board, player1, player2, score, sideThatWon, out bool winHappenedFlag);

                if (winHappenedFlag)
                {
                    break;
                }
            }

            renderer.ShowPostRoundMenu();

            bool userInput = inputHandler.RoundMenu();

            if (userInput)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        
        StatisticsObject statistics = new StatisticsObject(score[0], score[1], score[2], player1.Name, player2.Name);
        statisticsManager.AppendStatisticsToFile(statistics);
    }
}