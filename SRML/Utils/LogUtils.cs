using System.Text;
using BepInEx.Logging;
using Logger = BepInEx.Logging.Logger;

namespace SRML.Utils
{
    public static class LogUtils
    {
        private static StringBuilder currentBuilder;

        public static ManualLogSource BepInExLog = Logger.CreateLogSource("SRML");

        public static void OpenLogSession()
        {
            currentBuilder = new StringBuilder();
        }

        public static void Log(object b)
        {
            if (currentBuilder != null)
            {
                currentBuilder.AppendLine(b.ToString());
            }
            else
            {
                BepInExLog.LogMessage(b);
            }
        }

        public static void CloseLogSession()
        {
            if (currentBuilder != null)
            {
                LogUtils.BepInExLog.LogMessage(currentBuilder.ToString());
                currentBuilder = null;
            }
        }

    }
}
