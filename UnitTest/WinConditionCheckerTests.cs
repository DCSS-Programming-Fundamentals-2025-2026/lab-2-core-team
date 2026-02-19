namespace UnitTest;

[TestFixture]
public class WinConditionCheckerTests
{
    private WinConditionChecker _winChecker;
    
    [SetUp]
    public void Setup()
    {
        _winChecker = new WinConditionChecker();
    }
    
    [Test]
    public void WinConditionCheckerTest1()
    {
        char[] board = new char[9];

        char result = _winChecker.CheckBoardForWin(board);
            
        Assert.That(result, Is.EqualTo('\0'));    
    }
    
    [Test]
    public void WinConditionCheckerTest2()
    {
        char[] board = new char[]
        {
            'O', 'O', '\0',
            'X', 'X', 'X',
            '\0', '\0', '\0'
        };
        char result = _winChecker.CheckBoardForWin(board);
        
        Assert.That(result, Is.EqualTo('X'));
    }
    
    [Test]
    public void WinConditionCheckerTest3()
    {
        char[] board = new char[]
        {
            'O', 'X', '\0',
            'X', 'O', '\0',
            '\0', 'X', 'O'
        };
        
        char result = _winChecker.CheckBoardForWin(board);
        
        Assert.That(result, Is.EqualTo('O'));
    }
}