using Lab.Domain.Core.Player;

namespace Lab.Domain.Core.TurnHandler;

public class TurnHandler
{
    public void HandleMove(ref bool isPlayerOneTurn, char[] board, int lastSelectedCell, PlayerBase player1, PlayerBase player2)
    {
        if (isPlayerOneTurn)
        {
            board[lastSelectedCell] = player1.Side;
            isPlayerOneTurn = false;
        }
        else
        {
            board[lastSelectedCell] = player2.Side;
            isPlayerOneTurn = true;
        }
    }
}