namespace Lab.Domain.Core.WinConditionLogic;

public class TieChecker
{
    public bool CheckForTie(char[] board)
    {
        char emptyBoardCell = '\0';
        
        bool isTie = true;
        foreach (char cell in board)
        {
            if (cell == emptyBoardCell)
            {
                isTie = false;
                break;
            }
        }

        return isTie;
    }
}