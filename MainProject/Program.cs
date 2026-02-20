using Lab.Contracts;
using Lab.UI;
using Lab.Domain.Core.Player;
using Lab.Domain.Core;
using Lab;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        ConsoleRender renderer = new ConsoleRender();
        InputHandler inputHandler = new InputHandler();
        
        string[] menuOptions =
        {
            " - New game",
            " - Match history",
            " - Exit"
        };

        while (true)
        {
            int choice = menu.ShowMenu(menuOptions);
            switch (choice)
            {
                case 0:
                    string nameOfFirstPlayer = inputHandler.AskForName("Enter name of the first player: ");
                    string nameOfSecondPlayer = inputHandler.AskForName("Enter name of the second player: ");
                    PlayerBase player1 = new PlayerBase(nameOfFirstPlayer, 'X');
                    PlayerBase player2 = new PlayerBase(nameOfSecondPlayer, 'O');

                    Game.StartGame(player1, player2);
                    break;

                case 1:
                    renderer.DrawScore();
                    break;
                case 2:
                    return;
            }
        }
    }
}