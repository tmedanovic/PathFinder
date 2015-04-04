namespace PathFinder.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            var action = args[0];
            var path = args[1];

            if (action == "R")
            {
                RegisterApp.Register(path);
            }
            else
            {
                RegisterApp.Unregister();
            }
        }
    }
}
