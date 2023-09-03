namespace bubblesort;
class Program
{
    static void BubbleSort(List<int> input)
    {
        int n = input.Count - 1;
        bool swapped;

        for (int i = 0; i < n; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i; j++)
            {
                if (input[j] > input[j + 1])
                {
                    (input[j], input[j + 1]) = (input[j + 1], input[j]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        for (int i = 0; i < n + 1; i++)
        {
            Console.Write(input[i]);
            if (i < n) Console.Write(", ");
        }
    }

    static void Main(string[] args)
    {
        List<int> sortMe = new() { 45, 84, 735, -7, 90, 420, -6, 9, 0, 257, 5231 };
        BubbleSort(sortMe);
        Console.ReadKey();
    }
}