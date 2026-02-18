using System.Text.Json;

namespace Lab.Domain.Core.StatisticsLogic;

public class StatisticsManager
{
    public void AppendStatisticsToFile(StatisticsObject statistics)
    {
        string jsonString = JsonSerializer.Serialize(statistics);
        
        using (StreamWriter sw = new StreamWriter("statistics.json", append: true))
        {
            sw.WriteLine(jsonString);
        }
    }

    public List<StatisticsObject>? DeserializeStatistics()
    {
        List<StatisticsObject> statisticsObjects = new List<StatisticsObject>();
        
        if (!File.Exists("statistics.json"))
        {
            return null;
        }

        foreach (string line in File.ReadLines("statistics.json"))
        {
            try
            {
                StatisticsObject? matchStatistics = JsonSerializer.Deserialize<StatisticsObject>(line);

                if (matchStatistics is null)
                {
                    return null;
                }
                
                statisticsObjects.Add(matchStatistics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        return statisticsObjects;
    }
    
    public void DeleteStatistics()
    {
        File.Delete("statistics.json");
    }
}