// **Задача 50**: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// 17 -> такого числа в массиве нет

int[,] array = new int[,] { {1, 4, 7, 2},
                            {5, 9, 2, 3},
                            {8, 4, 2, 4}};

Console.WriteLine("Исходный массив:");
for (int m = 0; m < array.GetLength(0); m++)
{
    for (int n = 0; n < array.GetLength(1); n++)
        Console.Write($"{array[m, n]} ");
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("                   номер строки --↓↓--номер столбца ");
Console.Write    ("Введите позицию элемента массива (mn): ");
int position = Convert.ToInt32(Console.ReadLine());

if (position >= 11 && position <= 99)
{
    int row = position / 10;
    int column = position % 10;
    if (row > array.GetLength(0) || column > array.GetLength(1))
        Console.WriteLine("В массиве нет такой позиции");
    else
        Console.WriteLine($"Элемент в позиции {position} - {array[row - 1, column - 1]}");
}
else
    Console.WriteLine("Не правильная позиция");


