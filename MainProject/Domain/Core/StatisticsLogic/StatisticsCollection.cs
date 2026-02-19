using System.Collections;

namespace Lab.Domain.Core.StatisticsLogic;

public class StatisticsCollection : IEnumerable
{
    private StatisticsObject[] items = new StatisticsObject[100];
    private int counter;

    public void Add (StatisticsObject obj)
    {
        if (counter >= items.Length)
        {
            MultiplyCountBuckets();   
        }

        items[counter] = obj;
        counter++;
    }   

    public void RemoveAt (int index)
    {
        if (index < 0 || index >= counter)
        {
            throw new InvalidOperationException();
        }

        for (int i = index; i < counter - 1; i++)
        {
            items[i] = items[i + 1];  
        }

        counter--;
        items[counter] = null;
    }

    public StatisticsObject GetAt (int index)
    {
        if (index < 0 || index >= counter)
        {
            throw new InvalidOperationException();
        }

        return items[index];
    }

    public void SetAt (StatisticsObject obj, int index)
    {
        if (index < 0 || index >= counter)
        {
            throw new InvalidOperationException();
        }

        items[index] = obj;
    }

    public int Count ()
    {
        return counter;
    }

    private void MultiplyCountBuckets ()
    {
        StatisticsObject[] array = new StatisticsObject[items.Length * 2];
        for (int i = 0; i < items.Length; i++)
        {
            array[i] = items[i];
        }

        items = array;
    }

    public IEnumerator GetEnumerator ()
    {
        return new StatisticsObjectEnumerator(items, counter);
    }
}

public class StatisticsObjectEnumerator : IEnumerator
{
    private StatisticsObject[] _statisticsObjects;
    private int _position = -1;
    private int length = 0;

    public StatisticsObjectEnumerator(StatisticsObject[] statistics, int len)
    {
        _statisticsObjects = statistics;
        length = len;
    }

    public object Current
    {
        get { return _statisticsObjects[_position]; }
    }

    public bool MoveNext()
    {
        _position++;
        return _position < length;
    }

    public void Reset()
    {
        _position = -1;
    }
}