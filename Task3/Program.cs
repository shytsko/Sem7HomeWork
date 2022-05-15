// **Задача 52**: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3

int m = ReadInt("Введите количество строк массива: ");
int n = ReadInt("Введите количество столбцов массива: ");
int minimumValue = -10;
int maximumValue = 10;

int[,] array = GenerateIntArray2D(m, n, minimumValue, maximumValue);
PrintIntArray2D(array);

double[] averageValues = CalculateAverageColumn(array);
Console.WriteLine();
Console.WriteLine("Средние арифметические по столбцам:");
PrintDoubleArray(averageValues);


int[,] GenerateIntArray2D(int rows, int columns, int minValue, int maxValue)
{
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            array[i, j] = new Random().Next(minValue, maxValue + 1);

    return array;
}

double[] CalculateAverageColumn(int[,] array2D)
{
    double[] result = new double[array2D.GetLength(1)];

    for (int column = 0; column < array2D.GetLength(1); column++)
    {
        double sum = 0.0;
        for (int row = 0; row < array2D.GetLength(0); row++)
            sum += array2D[row, column];
        result[column] = Math.Round(sum / array2D.GetLength(0), 2);
    }

    return result;
}

void PrintIntArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]} ");
        Console.WriteLine();
    }
}

void PrintDoubleArray(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}