using System;
using System.IO;

public class Calculator
{
    public double Divide(double num1, double num2)
    {
        try
        {
            return num1 / num2;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Помилка: Дiлення на нуль!");
            return 0;
        }
    }
}

public class FileReader
{
    public string ReadFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Помилка: Файл {filePath} не знайдено.");
            return string.Empty;
        }
    }
}

public class ArrayProcessor
{
    public double Process(int[] numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Помилка: Вхiдний масив не може бути нульовим.");
        }

        if (numbers.Length == 0)
        {
            throw new ArgumentException("Помилка: Вхiдний масив не може бути порожнiм.", nameof(numbers));
        }

        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum / numbers.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        Console.WriteLine("Введiть перше число:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введiть друге число:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = calculator.Divide(num1, num2);

        Console.WriteLine($"{num1} подiлити на {num2} це {result}");

        FileReader fileReader = new FileReader();
        string content = fileReader.ReadFile("C:\\1.txt");
        Console.WriteLine($"Вмiст файлу: {content}");

        ArrayProcessor arrayProcessor = new ArrayProcessor();

        Console.WriteLine("Введiть кiлькiсть елементiв масиву:");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Введiть число для iндексу {i}:");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        double average = arrayProcessor.Process(numbers);

        Console.WriteLine($"Середнє значення масиву дорiвнює {average}");

        Console.ReadKey();
    }
}
