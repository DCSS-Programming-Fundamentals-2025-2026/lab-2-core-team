namespace Lab.Domain.Core.StatisticsLogic;

public class StatisticsObject : IComparable
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

    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }

        if (obj is not StatisticsObject other)
        {
            throw new ArgumentException();
        }

        int result1 = string.Compare(PlayerOneName, other.PlayerOneName, StringComparison.CurrentCulture);
        if (result1 != 0)
        {
            return result1;
        }

        int result2 = string.Compare(PlayerTwoName, other.PlayerTwoName, StringComparison.CurrentCulture);
        if (result2 != 0)
        {
            return result2;
        }

        int resultX = XWinsCount.CompareTo(other.XWinsCount);
        if (resultX != 0)
        {
            return resultX;
        }

        int resultO = OWinsCount.CompareTo(other.OWinsCount);
        if (resultO != 0)
        {
            return resultO;
        }

        int resultD = DrawsCount.CompareTo(other.DrawsCount);
        return resultD;
    }

}