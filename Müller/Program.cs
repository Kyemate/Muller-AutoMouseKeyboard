namespace Müller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            catch (Exception exc)
            {
                File.WriteAllText("complete error.log",exc.Message);  // get at entire error message w/ stacktrace
                File.WriteAllText("stack.log",exc.StackTrace);  // or just the stacktrace
            }
           
        }
        public static readonly string KeySettingsPath = AppDomain.CurrentDomain.BaseDirectory + @"\Settings\Instructions.muller";

        public static readonly string ReplayFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Replays\";

        #region settings
        public static List<Keys> KeyList = new List<Keys>();
        public static bool RecordMouse = false;
        public static bool RecordMouseMove = false;
        public static long MouseMoveInterval = 200;
        #endregion

        //public static int StartOffset = 0;

        public static void ValidateFileSystem()
        {
            if (!Directory.Exists("Replays"))
            {
                Directory.CreateDirectory("Replays");
            }
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            if (!File.Exists(KeySettingsPath))
                File.Create(KeySettingsPath).Close();

        }
    }
}