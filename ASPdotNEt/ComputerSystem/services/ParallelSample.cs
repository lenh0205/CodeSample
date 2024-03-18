namespace ComputerSystem.services
{
    internal class ParallelSample
    {
        public static void PintInfo(string info) => Console.WriteLine(
            $"{info,10} task:{Task.CurrentId,3}" + $"thread: {Thread.CurrentThread.ManagedThreadId}"
        );

        public static void RunTask(int i)
        {
            PintInfo($"Start {i,3}");
            Task.Delay(100).Wait();          
            PintInfo($"Finish {i,3}");
        }

        public static void ParallelFor()
        {
            ParallelLoopResult result = Parallel.For(1, 20, RunTask);   // Vòng lặp tạo ra 20 lần chạy RunTask
            Console.WriteLine($"All task start and finish: {result.IsCompleted}");
        }
    }
}
