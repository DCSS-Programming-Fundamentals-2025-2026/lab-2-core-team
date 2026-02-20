namespace UnitTest;
using Lab.UI;

[TestFixture]
public class InputHandlerTests
{
    private TextReader _textReader;

    [SetUp]
    public void Setup()
    {
        _textReader = Console.In;
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetIn(_textReader);
    }
    
    [Test]
    public void InputHandlerTest1()
    {
        
        InputHandler inputHandler = new InputHandler();

        string simulatedUserInput = "     \n   Bob    \n";
        using var stringReader = new StringReader(simulatedUserInput);
        Console.SetIn(stringReader);
        
        string result = inputHandler.AskForName(" ");
        
        Assert.That(result, Is.EqualTo("Bob"));
    }
}