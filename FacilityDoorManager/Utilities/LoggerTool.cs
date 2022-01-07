using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDoorManager.Utilities
{
    class LoggerTool
    {

        static string static_default_path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)} \\{nameof(FacilityDoorManager)}.log";
        string default_path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)} \\{nameof(FacilityDoorManager)}.log";
        private const int DefaultBufferSize = 4096;

        static Config config;





        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void StaticAddText(string value)
        {
            using (StreamWriter file_stream_ref = File.AppendText(static_default_path))
            {

                file_stream_ref.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + " : " + value);

            }

        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void log_msg_static(string msg, bool add_timestamp = true)
        {
            if (config == null)
            {
                config = FacilityDoorManager.early_config;
                if (config.behavior_rules.debug_enabled)
                {
                    using (StreamWriter file_stream_ref = File.CreateText(static_default_path))
                    {
                        if (add_timestamp)
                        {
                            file_stream_ref.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + " : " + msg);
                        }
                        else
                        {
                            file_stream_ref.WriteLine(msg);
                        }
                    }
                }
                return;
            }

            if (config.behavior_rules.debug_enabled)
            {
                StaticAddText(msg);
            }
        }



        public async Task WriteAllTextAsync(string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            FileStream sourceStream = new FileStream(default_path, FileMode.Append, FileAccess.Write, FileShare.None,
                DefaultBufferSize, true);
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            sourceStream.Close();
        }

    }
}
