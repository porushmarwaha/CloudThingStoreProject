using CloudThingStoreConsoleApp.Configuration;

namespace CloudThingStoreConsoleApp {
    public static class Program
    {
        public static void Main(string[] args)
        {
           ProjectConfig.CloudThingInstance().Start();
        }
    }
}