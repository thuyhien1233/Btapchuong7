using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding= Encoding.UTF8 ;
        // Tạo một thread mới và gán hàm DoWork để thực thi
        Thread thread = new Thread(new ThreadStart(DoWork));
        thread.Start();

        // Main thread tiếp tục chạy
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Main thread: " + i);
            Thread.Sleep(100); // Dừng main thread 100ms
        }

        // Đợi worker thread hoàn thành
        thread.Join();
    }

    static void DoWork()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(100); // Dừng worker thread 100ms
        }
    }
}
