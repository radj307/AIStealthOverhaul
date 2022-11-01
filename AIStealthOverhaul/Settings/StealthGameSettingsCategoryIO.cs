using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Newtonsoft.Json;
using StealthOverhaul.Settings;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AIStealthOverhaul.Settings
{
    public class StealthGameSettingsCategoryIO
    {
        #region Fields
        internal const string ImportFromPathName = "Import From Path";
        [SettingName(ImportFromPathName)]
        [Tooltip($"IMPORTs a previously-exported [{TopLevelSettings.GameSettingsName}] category from the specified JSON file.\n" +
            $"Accepts absolute and/or relative paths; paths are relative to the Synthesis working directory.\n\n" +
            "Leave this blank if you don't want to load a preset file.")]
        public string ImportFromPath = string.Empty;
        internal const string ExportToPathName = "Export To Path";
        [SettingName(ExportToPathName)]
        [Tooltip($"EXPORTs the current [{TopLevelSettings.GameSettingsName}] category to the specified JSON file.\n" +
            $"This occurs AFTER the patcher has completed successfully. Any missing parent directories will be created for you.\n" +
            $"Accepts absolute and/or relative paths; paths are relative to the Synthesis working directory.\n\n" +
            "Leave this blank if you don't want to save a preset file.")]
        public string ExportToPath = string.Empty;
        [Tooltip($"When checked, successfully exported files are opened in the default handler application.")]
        public bool OpenExportedFile = true;
        #endregion Fields

        #region Statics
        #region ImportFromFile
        private static bool ImportFromFile(string path, [MaybeNullWhen(false)] out StealthGameSettings? gameSettings)
        {
            gameSettings = null;

            if (!File.Exists(path) && !File.Exists(path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, path))))
                return false;

            try
            {
                gameSettings = JsonConvert.DeserializeObject<StealthGameSettings>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]\tAn exception was thrown while reading a preset file: \"{ex.Message}\"");
                return false;
            }
            Console.WriteLine($"[INFO]\tSuccessfully loaded config preset from file: \"{path}\"");
            return true;
        }
        #endregion ImportFromFile
        #region ExportToFile
        private static bool ExportToFile(string path, StealthGameSettings stealthGameSettings)
        {
            string actualPath = Path.GetFullPath(Path.IsPathRooted(path) ? Path.Combine(Environment.CurrentDirectory, path) : path);
            string dirPath = Path.GetDirectoryName(actualPath)!;

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            else if (File.Exists(actualPath))
                File.Move(actualPath, Path.GetFileNameWithoutExtension(actualPath) + "-backup" + Path.GetExtension(actualPath), true);

            string serialized;

            try
            {
                serialized = JsonConvert.SerializeObject(stealthGameSettings, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]\tAn exception was thrown by the JSON serializer while processing the configuration object: \"{ex.Message}\"");
                return false;
            }

            if (serialized.Length.Equals(0))
                return false;

            //Console.WriteLine($"[INFO]\tSuccessfully serialized an object instance of type \"{typeof(StealthGameSettings).FullName}\"");

            File.WriteAllText(actualPath, serialized, System.Text.Encoding.UTF8);

            //Console.WriteLine($"[INFO]\tFinished writing preset file \"{actualPath}\".");

            return File.Exists(actualPath);
        }
        #endregion ExportToFile
        #region OpenFileWithDefaultHandler
        private static bool OpenFileWithDefaultHandler(string path)
        {
            Process? proc;
            try
            {
                proc = Process.Start(new ProcessStartInfo(path)
                {
                    Verb = "open",
                    UseShellExecute = true,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]\tAn exception was thrown by the WIN32 API while attempting to open file \"{path}\":\n       \t\"{ex.Message}\"!");
                return false;
            }

            if (proc is null)
            {
                //Console.WriteLine($"[ERROR]\tFailed to open preset file!");
                return false;
            }

            Console.WriteLine(
                $"[INFO]\tSuccessfully opened file \"{path}\", using filetype handler: {proc.Id}{(proc.ProcessName.Length.Equals(0) ? "" : $" (\"{proc.ProcessName}\")")}"
            );
            return true;
        }
        #endregion OpenFileWithDefaultHandler
        #endregion Statics

        #region Methods
        public bool Export(StealthGameSettings inst)
        {
            if (ExportToPath.Length.Equals(0)) return false;

            bool result = ExportToFile(ExportToPath, inst);

            if (OpenExportedFile)
            {
                OpenFileWithDefaultHandler(ExportToPath);
            }

            return result;
        }
        public bool Import([MaybeNullWhen(false)] out StealthGameSettings? inst)
        {
            if (ImportFromPath.Length.Equals(0))
            {
                inst = null;
                return false;
            }

            return ImportFromFile(ImportFromPath, out inst);
        }
        #endregion Methods
    }
}
