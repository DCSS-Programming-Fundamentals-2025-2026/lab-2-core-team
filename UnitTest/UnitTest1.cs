namespace UnitTest;

public class Tests
{
    [Test]
    public void Test1()
    {
        WinConditionChecker winChecker = new WinConditionChecker();
        char[] board = new char[9]
        {
            'O', 'O', '\0',
            'X', 'X', 'X',
            '\0', '\0', '\0'

        };
        char sideThatWon = winChecker.CheckBoardForWin(board);
        
        Assert.That(sideThatWon, Is.EqualTo('X'));
    }
}