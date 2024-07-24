using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var thread = new Thread(() =>
        {
            Console.WriteLine("Thread bắt đầu.");
            Thread.Sleep(1000);
            Console.WriteLine("Thread kết thúc.");
        });

        thread.Start();
        thread.Join(); // Đợi thread hoàn thành
    }
}

// ý b

/*

class Program
{
    static async Task Main(string[] args)
    {
        await Async1();
    }
 Console.OutputEncoding = Encoding.UTF8;
    public static async Task Async1()
    {
        Console.WriteLine("Async bắt đầu.");
        await Task.Delay(1000);
        Console.WriteLine("Async kết thúc.");
    }
}
*/