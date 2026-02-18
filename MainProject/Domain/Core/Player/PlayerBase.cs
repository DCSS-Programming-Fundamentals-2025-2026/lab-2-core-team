namespace Lab.Domain.Core.Player;
public class PlayerBase
{
    public string Name { get; }

    public char Side { get; set; }

    public PlayerBase(string name, char side)
    {
        Name = name;
        Side = side;
    }
}