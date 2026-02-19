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
            'X', 'X', 'X',
            'O', 'O', '\0',
            '\0', 'X', 'O'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }

    [Test]
    public void WinConditionCheckerTest4()
    {
        char[] board = new char[]
        {
            'O', 'X', '\0',
            'O', 'O', '\0',
            'X', 'X', 'X'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }

    [Test]
    public void WinConditionCheckerTest5()
    {
        char[] board = new char[]
        {
            'X', 'O', '\0',
            'X', 'O', '\0',
            'X', '\0', 'O'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }
    
    [Test]
    public void WinConditionCheckerTest6()
    {
        char[] board = new char[]
        {
            'O', 'X', '\0',
            '\0', 'X', '\0',
            '\0', 'X', 'O'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }
    
    [Test]
    public void WinConditionCheckerTest7()
    {
        char[] board = new char[]
        {
            'O', '\0', 'X',
            '\0', '\0', 'X',
            '\0', 'O', 'X'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }
    
    [Test]
    public void WinConditionCheckerTest8()
    {
        char[] board = new char[]
        {
            'X', 'O', '\0',
            '\0', 'X', '\0',
            '\0', 'O', 'X'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }
    [Test]
    public void WinConditionCheckerTest9()
    {
        char[] board = new char[]
        {
            'O', '\0', 'X',
            '\0', 'X', '\0',
            'X', 'O', '\0'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('X'));
    }
    
    [Test]
    public void WinConditionCheckerTest10()
    {
        char[] board = new char[]
        {
            'O', 'O', 'O',
            'X', 'X', '\0',
            '\0', 'X', '\0'
        };
        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }

    [Test]
    public void WinConditionCheckerTest11()
    {
        char[] board = new char[]
        {
            'X', 'X', '\0',
            'O', 'O', 'O',
            '\0', 'X', '\0'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }

    [Test]
    public void WinConditionCheckerTest12()
    {
        char[] board = new char[]
        {
            'X', 'X', '\0',
            'X', '\0', '\0',
            'O', 'O', 'O'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }

    [Test]
    public void WinConditionCheckerTest13()
    {
        char[] board = new char[]
        {
            'X', 'O', '\0',
            'X', 'O', '\0',
            '\0', 'O', 'X'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }
    
    [Test]
    public void WinConditionCheckerTest14()
    {
        char[] board = new char[]
        {
            'O', 'X', '\0',
            'O', 'X', '\0',
            'O', '\0', 'X'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }
    
    [Test]
    public void WinConditionCheckerTest15()
    {
        char[] board = new char[]
        {
            'X', '\0', 'O',
            'X', '\0', 'O',
            '\0', 'X', 'O'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }
    
    [Test]
    public void WinConditionCheckerTest16()
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
    [Test]
    public void WinConditionCheckerTest17()
    {
        char[] board = new char[]
        {
            'X', '\0', 'O',
            '\0', 'O', 'X',
            'O', 'X', '\0'
        };

        char result = _winChecker.CheckBoardForWin(board);

        Assert.That(result, Is.EqualTo('O'));
    }
}