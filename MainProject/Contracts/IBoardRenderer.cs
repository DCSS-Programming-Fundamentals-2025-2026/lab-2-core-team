namespace Lab.Contracts;

public interface IBoardRenderer
{
    public void DrawBoard(char[] board, int selectedIndex);
    public void DrawCell(int index, char symbol, bool isSelected);
}