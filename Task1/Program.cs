// **Задача 47**: Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

int m = ReadInt("Введите количество строк массива m=");
int n = ReadInt("Введите количество столбцов массива n=");
double minimumValue = -100.0;
double maximumValue = 100.0;

double[,] array = GenerateDoubleArray2D(m, n, minimumValue, maximumValue);

PrintArray2D(array);



int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

double[,] GenerateDoubleArray2D(int rows, int columns, double minValue, double maxValue)
{
    double[,] array = new double[rows, columns];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            array[i, j] = Math.Round(new Random().NextDouble() * (maxValue - minValue) + minValue, 2);

    return array;
}

void PrintArray2D(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

