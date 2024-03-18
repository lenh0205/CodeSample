namespace ComputerSystem.services
{
    internal class TaskSample
    {
        // Sử dụng delegate "Func" (có kiểu trả về) để tạo "Task"
        public static Task<string> Async1(string thamso1, string thamso2)
        {
            Func<object, string> myfunc = (object thamso) =>
            {
                dynamic ts = thamso;
                for (int i = 1; i <= 10; i++)
                {
                    // "Thread.CurrentThread.ManagedThreadId" trả về ID của thread đang chạy
                    WriteLine($"Func - Time:{i,5} ThreadId:{Thread.CurrentThread.ManagedThreadId,3} Tham so {ts.x} {ts.y}", ConsoleColor.Green);
                    Thread.Sleep(300);
                }
                return $"Ket thuc Async1! {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 }); // Tạo Task
            task.Start(); // khởi chạy một thread mới  

            Console.WriteLine("Async1: Lam gi đo sau khi task chay");
            return task;
        }

        // Sử dụng delegate "Action" (không kiểu trả về) để tạo "Task"
        public static Task Async2()
        {
            Action myaction = () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"Action - Time:{i,5} ThreadId:{Thread.CurrentThread.ManagedThreadId,3}",
                        ConsoleColor.Yellow);
                    Thread.Sleep(500);
                }
                WriteLine("Ket thuc Async2!", ConsoleColor.Red);
            };

            Task task = new Task(myaction); // Tạo Task
            task.Start(); // chạy Task

            Console.WriteLine("Async2: Lam gi đo sau khi task chay");
            return task;
        }

        public static void WriteLine(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
}
