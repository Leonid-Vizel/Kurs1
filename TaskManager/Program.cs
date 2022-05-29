namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.TakeControl();
        }
    }
}