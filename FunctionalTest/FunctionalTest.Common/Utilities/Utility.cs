namespace FunctionalTest.Common.Utilities
{
    public class Utility
    {
        public static string GetRootDir()
        {
            var currentDir = Directory.GetCurrentDirectory();
            return currentDir.Split("bin")[0];
        }
    }
}
