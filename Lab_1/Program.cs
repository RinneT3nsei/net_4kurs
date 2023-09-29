using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Завдання 1: Асинхронний метод з операторами async/await");
        await Task.Delay(1000); // Приклад асинхронного виконання
        Console.WriteLine("Завдання 1: Завершено");

        Console.WriteLine("\nЗавдання 2: Асинхронний метод з послiдовним виконанням");
        await SequentialExecutionAsync();

        Console.WriteLine("\nЗавдання 3: Асинхронний метод з паралельним виконанням");
        await ParallelExecutionAsync();

        Console.WriteLine("Готово. Натиснiть Enter для завершення програми.");
        Console.ReadLine();
    }

    static async Task SequentialExecutionAsync()
    {
        Console.WriteLine("Початок послiдовного виконання методiв.");
        await FirstMethodAsync();
        await SecondMethodAsync();
        Console.WriteLine("Завершено послiдовне виконання методiв.");
    }

    static async Task FirstMethodAsync()
    {
        Console.WriteLine("Перший метод почав виконуватися.");
        await Task.Delay(2000); // Приклад асинхронного виконання
        Console.WriteLine("Перший метод завершив виконання.");
    }

    static async Task SecondMethodAsync()
    {
        Console.WriteLine("Другий метод почав виконуватися.");
        await Task.Delay(1000); // Приклад асинхронного виконання
        Console.WriteLine("Другий метод завершив виконання.");
    }

    static async Task ParallelExecutionAsync()
    {
        Console.WriteLine("Початок паралельного виконання методiв.");
        var task1 = Task.Run(() => FirstMethodAsync());
        var task2 = Task.Run(() => SecondMethodAsync());

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Завершено паралельне виконання методiв.");
    }
}
