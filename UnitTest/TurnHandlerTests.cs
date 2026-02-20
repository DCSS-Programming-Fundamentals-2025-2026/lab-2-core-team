using Lab.Domain.Core.Player;
using Lab.Domain.Core.TurnHandler;

namespace UnitTest;

[TestFixture]
public class TurnHandlerTests
{
    private TurnHandler _turnHandler;
    private PlayerBase _player1;
    private PlayerBase _player2;

    [SetUp]
    public void Setup()
    {
        _turnHandler = new TurnHandler();
        _player1 = new PlayerBase("Player1", 'X');
        _player2 = new PlayerBase("Player2", 'O');
    }

    [Test]
    public void TurnHandlerTest1()
    {
        char[] board = new char[9];
        bool isPlayerOneTurn = true;
        int lastSelectedCell = 0;
        
        _turnHandler.HandleMove(ref isPlayerOneTurn, board, lastSelectedCell, _player1, _player2);
        
        Assert.That(board[lastSelectedCell], Is.EqualTo('X'));
        Assert.That(isPlayerOneTurn, Is.False);
    }
    
    [Test]
    public void TurnHandlerTest2()
    {
        char[] board = new char[9];
        bool isPlayerOneTurn = false;
        int lastSelectedCell = 4;
        
        _turnHandler.HandleMove(ref isPlayerOneTurn, board, lastSelectedCell, _player1, _player2);
        
        Assert.That(board[lastSelectedCell], Is.EqualTo('O'));
        Assert.That(isPlayerOneTurn, Is.True);
    }
}