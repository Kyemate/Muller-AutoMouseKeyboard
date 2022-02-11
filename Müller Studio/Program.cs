namespace Müller_Studio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static readonly string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory + @"Müller Studio Files\";

        public static readonly string OutputFolder = AppDomain.CurrentDomain.BaseDirectory + @"Müller Output\";

        public static void ValidateFileSystem()
        {
            if (!Directory.Exists("Müller Studio Files"))
            {
                Directory.CreateDirectory("Müller Studio Files");
            }
            if (!Directory.Exists("Müller Output"))
            {
                Directory.CreateDirectory("Müller Output");
            }

        }
    }
}