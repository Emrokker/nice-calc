using NiceCalc.Helpers;

Console.WriteLine("Hello, World!");
Console.WriteLine();

Console.Write("Please enter your name: ");
var nameString = Console.ReadLine()?.Trim();
var name = string.IsNullOrWhiteSpace(nameString) ? "Anonymous" : nameString;

Console.Write("Please enter your age: ");
var ageString = Console.ReadLine()?.Trim();
var age = string.IsNullOrWhiteSpace(ageString) ? "" : $" ({Convert.ToInt32(ageString)})";

Console.WriteLine($"\nWelcome to NiceCalc, {name}{age}!\n");

MyMath math = new();

var exit = false;
while (!exit)
{
    var calcMode = chooseCalcMode();
    if (calcMode is 0)
    {
        continue;
    }

    Console.Write("Enter 1st value: ");
    var x = Convert.ToInt32(Console.ReadLine()?.Trim());
    Console.Write("Enter 2nd value: ");
    var y = Convert.ToInt32(Console.ReadLine()?.Trim());

    int? result = null;
    switch (calcMode)
    {
        case 1:
            result = math.Add(x, y);
            break;
        case 2:
            result = math.Subtract(x, y);
            break;
        case 3:
            result = math.Multiply(x, y);
            break;
        case 4:
            result = math.Divide(x, y);
            break;
        default:
            break;
    }

    if (result is null)
    {
        Console.WriteLine("Couldn't calculate a result!");
    } else
    {
        Console.WriteLine($"The result is: {result}");
    }

    Console.WriteLine();

    var confirm = new string[] { "yes", "y", "1" };
    Console.WriteLine("Do you wanna quit?");
    Console.Write($"({string.Join("/", confirm)}): ");
    if (confirm.Contains(Console.ReadLine()?.Trim().ToLower()))
    {
        exit = true;
    }

    Console.WriteLine();
}

Console.WriteLine("Thanks for using NiceCalc, until next time!");
Console.WriteLine();

static int chooseCalcMode()
{
    Console.WriteLine("Choose an calculation mode: ");

    var possibleCalcModes = new int[] { 1, 2, 3, 4 };

    Console.WriteLine($"({possibleCalcModes[0]}) Addition");
    Console.WriteLine($"({possibleCalcModes[1]}) Subtraction");
    Console.WriteLine($"({possibleCalcModes[2]}) Multiplication");
    Console.WriteLine($"({possibleCalcModes[3]}) Division");

    var calcMode = Convert.ToInt32(Console.ReadLine()?.Trim());
    Console.WriteLine();

    return possibleCalcModes.Contains(calcMode) ? calcMode : 0;
}
