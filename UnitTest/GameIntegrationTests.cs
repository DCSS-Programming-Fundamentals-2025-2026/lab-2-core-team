using Lab.Domain.Core.Player;
using Lab.Domain.Core.StatisticsLogic;
using Lab.Domain.Core.TurnHandler;
using Lab.Domain.Core.WinConditionLogic;

namespace UnitTest;

[TestFixture]
public class GameIntegrationTests
{
    private const string StastFile = "statistics.json";

    [SetUp]
    public void Setup()
    {
        if (File.Exists(StastFile))
        {
            File.Delete(StastFile);
        }
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(StastFile))
        {
            File.Delete(StastFile);
        }
    }

    [Test]
    public void GameIntegrationTest1()
    {
        var winChcker = new WinConditionChecker();
        var turnHandler = new TurnHandler();
        var player1 = new PlayerBase("Player1", 'X');
        var player2 = new PlayerBase("Player2", 'O');
        var statsManager = new StatisticsManager();

        char[] board = new char[9];
        bool isPlayerOneTurn = true;
        
        turnHandler.HandleMove(ref isPlayerOneTurn, board, 4, player1, player2);
        turnHandler.HandleMove(ref isPlayerOneTurn, board, 0, player1, player2);

        board[3] = 'X';
        board[5] = 'X';

        char sideThatWon = winChcker.CheckBoardForWin(board);

        if (sideThatWon == player1.Side)
        {
            var stats = new StatisticsObject(1, 0, 0, player1.Name, player2.Name);
            statsManager.AppendStatisticsToFile(stats);
        }

        var savedReport = statsManager.DeserializeStatistics();
        
        Assert.That(sideThatWon, Is.EqualTo('X'));
        Assert.That(savedReport, Is.Not.Null);
        Assert.That(savedReport[0].PlayerOneName, Is.EqualTo("Player1"));
        Assert.That(savedReport[0].XWinsCount, Is.EqualTo(1));
    }

    [Test]
    public void GameIntegrationTest2()
    {
        var tieChecker = new TieChecker();
        var winChecker = new WinConditionChecker();
        char[] board = new char[]
        {
            'X', 'O', 'X',
            'X', 'O', 'O',
            'O', 'X', 'X'
        };

        char sideThatWon = winChecker.CheckBoardForWin(board);
        bool isTie = tieChecker.CheckForTie(board);
        
        Assert.That(sideThatWon, Is.EqualTo('\0'));
        Assert.That(isTie, Is.True);
        
    }
}