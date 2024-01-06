using System.Collections;
using System.Diagnostics;

namespace bubblesort;
class Program
{
    static void Main(string[] args)
    {
        var methodsRaw = new Hashtable
        {
            { "SortNumbers()", new Action<Direction>(SortNumbers) },
            { "SortStrings()", new Action<Direction>(SortStrings) },
        };

        var methods = new Hashtable
        {
            { 1, "SortNumbers()" },
            { 2, "SortStrings()" },
        };

        var options = new Hashtable
        {
            { 1, Direction.Asc },
            { 2, Direction.Desc }
        };

        int selectedMethod = GetInput("Select method to call:", methods);
        int selectedOption = GetInput("Select which order to sort array in:", options);

        Action<Direction> action = (Action<Direction>)methodsRaw[methods[selectedMethod]!]!;
        action((Direction)options[selectedOption]!);
    }

    static short[] BubbleSort(short[] input, Direction direction)
    {
        Func<int, int, bool> compare = GetOrder(direction);
        bool swapped;

        for (int i = 0; i < input.Length; i++)
        {
            swapped = false;
            for (int j = 1; j < input.Length - i; j++)
            {
                if (compare(input[j - 1], input[j]))
                {
                    (input[j - 1], input[j]) = (input[j], input[j - 1]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        return input;
    }
    static string[] BubbleSortString(string[] input, Direction direction)
    {
        Func<string, string, bool> compare = GetOrderString(direction);
        bool swapped;

        for (int i = 0; i < input.Length; i++)
        {
            swapped = false;
            for (int j = 1; j < input.Length - i; j++)
            {
                if (compare(input[j - 1], input[j]))
                {
                    (input[j - 1], input[j]) = (input[j], input[j - 1]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        return input;
    }


    enum Direction
    {
        Asc,
        Desc
    }

    static Func<int, int, bool> GetOrder(Direction direction)
    {
        switch (direction)
        {
            case Direction.Asc:
                return (x, y) => x > y;
            case Direction.Desc:
                return (x, y) => x < y;
            default:
                throw new ArgumentOutOfRangeException("Not a direction!");
        }
    }
    static Func<string, string, bool> GetOrderString(Direction direction)
    {
        switch (direction)
        {
            case Direction.Asc:
                return (x, y) => string.Compare(x, y) > 0;
            case Direction.Desc:
                return (x, y) => string.Compare(x, y) < 0;
            default:
                throw new ArgumentOutOfRangeException("Not a direction!");
        }
    }


    static short[] CreateArray(int length)
    {
        Random random = new();
        short[] array = new short[length];
        short min = short.MinValue;
        short max = short.MaxValue;

        for (int i = 0; i < length; i++)
        {
            array[i] = (short)random.Next(min, max);
        }

        return array;
    }


    static void SortNumbers(Direction direction)
    {
        Stopwatch watch = new();

        Console.WriteLine("Creating the array...");
        short[] array = CreateArray(5_00);
        Console.WriteLine("Array created!\n");

        Console.WriteLine("Sorting the array...");
        watch.Start();
        BubbleSort(array, direction);
        watch.Stop();
        Console.WriteLine("Array sorted!\n");

        Console.WriteLine("Displaying the array...");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine("Displayed the array!\n");

        Console.WriteLine($"Time elapsed: {watch.ElapsedMilliseconds} ms");
    }
    static void SortStrings(Direction direction)
    {
        Stopwatch watch = new();

        string[] array = new string[] { "Satisfactory", "Space Engineers", "Dyson Sphere Program", "Programming", "Gaming", "Fishing", "Coca Cola", "Word", "Visual Studio Code", "C#" };

        Console.WriteLine("Sorting the array...");
        watch.Start();
        BubbleSortString(array, direction);
        watch.Stop();
        Console.WriteLine("Array sorted!\n");

        Console.WriteLine("Displaying the array...");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine("Displayed the array!\n");

        Console.WriteLine($"Time elapsed: {watch.ElapsedMilliseconds} ms");
    }


    static int GetInput(string question, Hashtable options)
    {
        int input;
        bool ok;
        do
        {
            Console.WriteLine(question);

            for (int i = 1; i <= options.Count; i++)
            {
                Console.WriteLine("Option " + i + ": " + options[i]);
            }

            Console.Write("Write your option: ");

            ok = int.TryParse(Console.ReadLine(), out input);
            if (!ok) Console.WriteLine("You can only input a number!\n");

            if (input > options.Count || input < 1)
            {
                ok = false;
                Console.WriteLine("Selected option does not exist, try again.\n");
            }

        } while (!ok);

        Console.WriteLine($"You selected: {options[input]}\n");
        return input;
    }
}