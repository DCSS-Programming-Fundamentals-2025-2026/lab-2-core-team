namespace Lab.UI;
class Menu
{
    public int ShowMenu(string[] options)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      Tic-Tac-Toe\n");
            Console.ResetColor();

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{options[i]}");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"{options[i]}");
                }
            }

            Console.ResetColor();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex++;
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        }
    }
}