// Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата. В программе должна быть возможность
// добавить досье, вывести все досье в формате фио-должность-зп (Иванов Иван Иванович – кассир – 25 000), удалить досье по
// номеру (номера начинаются с 1), поиск досье по фамилии. Дополнительно: вывод всех досье с зп меньше или больше указанной,
// вывод всех досье с указанной должностью. Можно придумать еще свои команды.

string[] name = new string[]
{
    "Иванов Иван Иванович",
    "Петров Петр Петрович",
    "Иванов Сергей Иванович",
    "Семёнов Семён Семёнович"
};
string[] position = new string[]
{
    "Директор",
    "Заместитель директора",
    "Родственник директора",
    "Работает"
};
double[] paycheck = new double[] { 5000, 2000, 4000, 1000 };

Console.WriteLine(
    "Введите команду. Для вывода списка команд введите Help. Для выхода введите Exit"
);
while (true)
{
    Console.Write("Введите команду > ");
    string inputString = Console.ReadLine();
    string command = GetCommand(inputString);
    if (command == "Exit")
        break;
    else if (command == "Help")
        RunCommandHelp();
    else if (command == "Add")
        RunCommandAdd(inputString, command.Length + 1);
    else if (command == "Print")
        RunCommandPrint();
    else if (command == "Delete")
        RunCommandDelete(inputString, command.Length + 1);
    else if (command == "Find")
        RunCommandFind(inputString, command.Length + 1);
    else
        Console.WriteLine("Команда не распознана.");
}

string GetCommand(string inputString)
{
    string command = string.Empty;

    for (int i = 0; i < inputString.Length; i++)
    {
        if (inputString[i] == ' ')
            break;
        command += inputString[i];
    }

    return command;
}

void RunCommandHelp()
{
    Console.WriteLine("Exit - выход из программы");
    Console.WriteLine("Help - выход списка команд");
    Console.WriteLine("Add <ФИО - должность - зарплата> - добвавить досье");
    Console.WriteLine("Print - вывести все досье");
    Console.WriteLine("Delete <номер> - удалить досье");
    Console.WriteLine("Find <фамилия> - поиск по фамилии");
}

void RunCommandAdd(string inputString, int argsStartPosition)
{
    string temp = string.Empty;
    int index = argsStartPosition;
    while (inputString[index + 1] != '-')
    {
        temp += inputString[index++];
    }
    name = AddToArrayString(name, temp);
    index += 3;
    temp = string.Empty;
    while (inputString[index + 1] != '-')
    {
        temp += inputString[index++];
    }
    position = AddToArrayString(position, temp);
    index += 3;
    temp = string.Empty;
    while (index < inputString.Length)
    {
        temp += inputString[index++];
    }
    paycheck = AddToArrayDouble(paycheck, Convert.ToDouble(temp));

    PrintFile(name.Length);
}

void RunCommandPrint()
{
    for (int i = 0; i < name.Length; i++)
    {
        PrintFile(i + 1);
    }
}

void RunCommandDelete(string inputString, int argsStartPosition)
{
    string temp = string.Empty;
    int index = argsStartPosition;
    while (index < inputString.Length)
    {
        temp += inputString[index++];
    }
    int ID = Convert.ToInt32(temp);

    if (ID >= 1 && ID <= name.Length)
    {
        name = RemoveFromArrayString(name, ID - 1);
        position = RemoveFromArrayString(position, ID - 1);
        paycheck = RemoveFromArrayDouble(paycheck, ID - 1);
    }
    else
    {
        Console.WriteLine("Не верный ID");
    }
}

void RunCommandFind(string inputString, int argsStartPosition)
{
    string find = string.Empty;
    int index = argsStartPosition;
    while (index < inputString.Length)
    {
        find += inputString[index++];
    }

    for (int i = 0; i < name.Length; i++)
    {
        index = 0;
        string temp = string.Empty;
        while (name[i][index] != ' ' && index < inputString.Length)
        {
            temp += name[i][index++];
        }
        if (temp == find)
        {
            PrintFile(i + 1);
        }
    }
}

string[] AddToArrayString(string[] sourceArray, string value)
{
    string[] newArray = new string[sourceArray.Length + 1];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

double[] AddToArrayDouble(double[] sourceArray, double value)
{
    double[] newArray = new double[sourceArray.Length + 1];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

string[] RemoveFromArrayString(string[] sourceArray, int position)
{
    string[] newArray = new string[sourceArray.Length - 1];
    for (int i = 0; i < position; i++)
    {
        newArray[i] = sourceArray[i];
    }
    for (int i = position + 1; i < sourceArray.Length; i++)
    {
        newArray[i - 1] = sourceArray[i];
    }
    return newArray;
}

double[] RemoveFromArrayDouble(double[] sourceArray, int position)
{
    double[] newArray = new double[sourceArray.Length - 1];
    for (int i = 0; i < position; i++)
    {
        newArray[i] = sourceArray[i];
    }
    for (int i = position + 1; i < sourceArray.Length; i++)
    {
        newArray[i - 1] = sourceArray[i];
    }
    return newArray;
}

void PrintFile(int ID)
{
    if (ID >= 1 && ID <= name.Length)
    {
        Console.WriteLine($"{ID}. {name[ID - 1]} - {position[ID - 1]} - {paycheck[ID - 1]}");
    }
    else
    {
        Console.WriteLine("Не верный ID");
    }
}
