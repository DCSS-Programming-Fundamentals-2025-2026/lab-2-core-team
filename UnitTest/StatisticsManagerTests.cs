using Lab.Domain.Core.StatisticsLogic;

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
        var manager = new StatisticsManager();
        File.WriteAllText(_testFilePath, "test data");
        
        manager.DeleteStatistics();

        bool fileExists = File.Exists(_testFilePath);
        Assert.That(fileExists, Is.False);
    }
}