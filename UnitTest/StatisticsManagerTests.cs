using Lab.Domain.Core.StatisticsLogic;
using Lab.UI;

namespace UnitTest;

[TestFixture]
public class StatisticsManagerTests
{
    private StatisticsManager _statisticsManager;
    private const string _testFilePath = "statistics.json";

    [SetUp]
    public void Setup()
    {
        _statisticsManager = new StatisticsManager();
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }

    [Test]
    public void StatisticsManagerTest1()
    {
        var result = _statisticsManager.DeserializeStatistics();
        
        Assert.That(result, Is.Null);
    }
    
    [Test]
    public void StatisticsManagerTest2()
    {
        var stats = new StatisticsObject(1, 0, 0, "Player1", "Player2");

        _statisticsManager.AppendStatisticsToFile(stats);
        List<StatisticsObject>? loadedStats = _statisticsManager.DeserializeStatistics();
        
        Assert.That(loadedStats, Is.Not.Null);
        Assert.That(loadedStats.Count, Is.EqualTo(1));
        Assert.That(loadedStats[0].PlayerOneName, Is.EqualTo("Player1"));
        Assert.That(loadedStats[0].XWinsCount, Is.EqualTo(1));
    }

    [Test]
    public void StatisticsManagerTest3()
    {
        File.WriteAllText(_testFilePath, "test data");
        
        _statisticsManager.DeleteStatistics();

        bool fileExists = File.Exists(_testFilePath);
        Assert.That(fileExists, Is.False);
    }
    
    [Test]
    public void StatisticsManagerTest4()
    {
        ConsoleRender consoleRender = new ConsoleRender();
        File.WriteAllText(_testFilePath, "{\"XWinsCount\":1,\"OWinsCount\":1,\"DrawsCount\":1,\"PlayerOneName\":\"Batman\",\"PlayerTwoName\":\"Serhii\"}\n{\"XWinsCount\":0,\"OWinsCount\":1,\"DrawsCount\":0,\"PlayerOneName\":\"wqrewt\",\"PlayerTwoName\":\"asafds\"}\n{\"XWinsCount\":1,\"OWinsCount\":0,\"DrawsCount\":0,\"PlayerOneName\":\"qweqeresdsfs\",\"PlayerTwoName\":\"ththh\"}");
        
        List<StatisticsObject>? list = _statisticsManager.DeserializeStatistics();

        if (list is null)
        {
            Assert.Fail();
            return;
        }
        
        List<StatisticsObject> processedList = consoleRender.DrawSortMatch(list, true);
        
        
        Assert.That(processedList[0].PlayerOneName, Is.EqualTo("qweqeresdsfs"));
    }
    
    [Test]
    public void StatisticsManagerTest5()
    {
        ConsoleRender consoleRender = new ConsoleRender();
        File.WriteAllText(_testFilePath, "{\"XWinsCount\":1,\"OWinsCount\":1,\"DrawsCount\":1,\"PlayerOneName\":\"Batman\",\"PlayerTwoName\":\"Serhii\"}\n{\"XWinsCount\":0,\"OWinsCount\":1,\"DrawsCount\":0,\"PlayerOneName\":\"wqrewt\",\"PlayerTwoName\":\"asafds\"}\n{\"XWinsCount\":1,\"OWinsCount\":0,\"DrawsCount\":0,\"PlayerOneName\":\"qweqeresdsfs\",\"PlayerTwoName\":\"ththh\"}");
        
        List<StatisticsObject>? list = _statisticsManager.DeserializeStatistics();

        if (list is null)
        {
            Assert.Fail();
            return;
        }
        
        List<StatisticsObject> processedList = consoleRender.DrawSortMatch(list, false);
        
        
        Assert.That(processedList[0].PlayerOneName, Is.EqualTo("Batman"));
    }
}