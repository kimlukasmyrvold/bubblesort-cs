namespace bubblesort;

class Program
{
    static void SortArray()
    {
        int[] array = { 3, 2, 6, 7, 5, 9, 8, 1, 12, 10, 11, 4 };
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        var n = array.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (array[j] > array[j + 1])
                {
                    var tempVar = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tempVar;
                }

        Console.Write("Output:   ");
        foreach (var item in array)
        {
            Console.Write(item + ", ");
        }

        Console.Write("\nExpected: ");
        foreach (var item in expected)
        {
            Console.Write(item + ", ");
        }
    }

    static void Main(string[] args)
    {
        SortArray();

        // Todo:
        // Write the sorting algorithm
    }
}
