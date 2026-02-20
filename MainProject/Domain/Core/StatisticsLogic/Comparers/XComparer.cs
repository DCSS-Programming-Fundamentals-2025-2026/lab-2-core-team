using System.Collections;

namespace Lab.Domain.Core.StatisticsLogic.Comparers;

public class XComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is not StatisticsObject other1)
        {
            throw new ArgumentException();  
        }

        if (y is not StatisticsObject other2)
        {
            throw new ArgumentException();
        }

        return other1.XWinsCount.CompareTo(other2.XWinsCount);
    }
}