public class WinConditionChecker
{
    public char CheckBoardForWin(char[] board)
    {
        char emptyBoardCell = '\0';
        
        for (int i = 0; i <= 6; i += 3)
        {
            if (board[i] != emptyBoardCell && board[i] == board[i + 1] && board[i] == board[i + 2])
            {
                return board[i];
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (board[i] != emptyBoardCell && board[i] == board[i + 3] && board[i] == board[i + 6])
            {
                return board[i];
            }
        }

        if (board[4] != emptyBoardCell)
        {
            if (board[0] == board[4] && board[4] == board[8])
            {
                return board[4];
            }

            if (board[2] == board[4] && board[4] == board[6])
            {
                return board[4];
            }
        }

        return emptyBoardCell;
    }
}