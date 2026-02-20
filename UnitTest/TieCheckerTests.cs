using Lab.Domain.Core.WinConditionLogic;

namespace UnitTest;

[TestFixture]
public class TieCheckerTests
{
    private TieChecker _tieChecker;

    [SetUp]
    public void Setup()
    {
        _tieChecker = new TieChecker();
    }

    [Test]
    public void TieCheckerTest1()
    {
        char[] board = new char[]
        {
            'X', 'O', 'X',
            'X', 'O', 'O',
            'O', 'X', 'X'
        };

        bool result = _tieChecker.CheckForTie(board);
        
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void TieCheckerTest2()
    {
        char[] board = new char[]
        {
            'X', '\0', '\0',
            'O', 'X', 'O',
            '\0', '\0', 'X'
        };

        bool result = _tieChecker.CheckForTie(board);
        
        Assert.That(result, Is.False);
    }
}