using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Newtonsoft.Json;
using StealthOverhaul.Settings;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AIStealthOverhaul.Settings
{
    public class ConfigPresetSettings
    {
        #region Fields
        [Tooltip("Allows you to LOAD a preset file from your local filesystem.\n" +
            "Accepts absolute paths or paths that are relative to the shell's current working directory.\n\n" +
            "Leave this blank if you don't want to load a preset file.")]
        public string LoadFromPath = string.Empty;
        [Tooltip("Allows you to SAVE a preset file to your local filesystem that contains all of the config values that were applied to records.\n" +
            "Accepts absolute paths or paths that are relative to the shell's current working directory.\n" +
            "Missing parent directories will be created automatically.\n\n" +
            "Leave this blank if you don't want to save a preset file.")]
        public string SaveToPath = string.Empty;
        [Tooltip($"When checked, the new preset file specified by '{nameof(SaveToPath)}' will be opened with the default JSON handler application after being successfully written to disk.")]
        public bool OpenFileOnSave = true;
        #endregion Fields

        #region Methods
        #region ReadPresetFile...
        private static bool ReadPresetFile(string path, [MaybeNullWhen(false)] out StealthGameSettings? gameSettings)
        {
            if (!File.Exists(path))
                if (!File.Exists(path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, path))))
                    throw new FileNotFoundException($"Couldn't find the specified file; you should make sure the path you entered is valid!");

            gameSettings = null;
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
        public bool ReadPresetFileIfSet([MaybeNullWhen(false)] out StealthGameSettings? gameSettings)
        {
            gameSettings = null;

            string path = LoadFromPath.Trim();
            if (path.Length.Equals(0))
                return false;

            return ReadPresetFile(path, out gameSettings);
        }
        #endregion ReadPresetFile...

        #region WritePresetFile...
        private static string GetBackupPresetFilePath(string originalPath)
        {
            if (!Path.IsPathRooted(originalPath))
                originalPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, originalPath));

            var dirPath = Path.GetDirectoryName(originalPath)!;
            var fileName = Path.GetFileNameWithoutExtension(originalPath);
            var extension = Path.GetExtension(originalPath);

            string path = originalPath;
            for (int i = 0; i < 99; ++i, path = Path.Combine(dirPath, $"{fileName}-{i}{extension}"))
            {
                if (!File.Exists(path))
                {
                    return path;
                }
            }
            return string.Empty;
        }
        private static bool WritePresetFile(string path, StealthGameSettings stealthGameSettings)
        {
            string actualPath = Path.GetFullPath(Path.IsPathRooted(path) ? Path.Combine(Environment.CurrentDirectory, path) : path);
            string dirPath = Path.GetDirectoryName(actualPath)!;

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine($"[INFO]\tCreated directory tree: \"{dirPath}\"");
            }
            else if (File.Exists(actualPath))
            {
                File.Move(actualPath, GetBackupPresetFilePath(actualPath));
                Console.WriteLine($"[INFO]\tDeleted existing file: \"{actualPath}\"");
            }

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
                Console.WriteLine($"[ERROR]\tAn exception was thrown while writing a preset file to disk: \"{ex.Message}\"");
                return false;
            }

            if (serialized.Length.Equals(0))
                return false;

            Console.WriteLine($"[INFO]\tSuccessfully serialized an object instance of type \"{typeof(StealthGameSettings).FullName}\"");

            File.WriteAllText(actualPath, serialized, System.Text.Encoding.UTF8);

            Console.WriteLine($"[INFO]\tFinished writing preset file \"{actualPath}\".");

            return true;
        }
        public bool WritePresetFileIfSet(StealthGameSettings gameSettings)
        {
            string path = SaveToPath.Trim();

            if (path.Length.Equals(0)) return false;

            if (WritePresetFile(path, gameSettings))
            {
                if (OpenFileOnSave)
                    OpenFileWithDefaultHandler(path);
                return true;
            }
            else return false;
        }
        #endregion WritePresetFile...

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
                Console.WriteLine($"[ERROR]\tFailed to open preset file due to an exception: \"{ex.Message}\"!");
                return false;
            }
            if (proc is null)
            {
                Console.WriteLine($"[ERROR]\tFailed to open preset file!");
                return false;
            }

            Console.WriteLine(
                $"[INFO]\tSuccessfully opened preset file with process {proc.Id}{(proc.ProcessName.Length.Equals(0) ? "" : $" (\"{proc.ProcessName}\")")}"
            );
            return true;
        }
        #endregion Methods
    }
}
