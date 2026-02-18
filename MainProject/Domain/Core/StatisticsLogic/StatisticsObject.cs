namespace Lab.Domain.Core.StatisticsLogic;

public class StatisticsObject
{
    public int XWinsCount { get; set; }
    public int OWinsCount { get; set; }
    public int DrawsCount { get; set; }
    public string PlayerOneName { get; set; }
    public string PlayerTwoName { get; set; }

    public StatisticsObject(int xWinsCount, int oWinsCount, int drawsCount, string playerOneName, string playerTwoName)
    {
        XWinsCount = xWinsCount;
        OWinsCount = oWinsCount;
        DrawsCount = drawsCount;
        PlayerOneName = playerOneName;
        PlayerTwoName = playerTwoName;
    }
}