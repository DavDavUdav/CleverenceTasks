namespace Task3
{
    public class LogHandler
    {
        private string _path = string.Empty;

        private bool InitializePath()
        {
            Console.WriteLine("Введите путь к папке с логами.");
            string? path = Console.ReadLine();
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Путь к логам не может быть пустым.");
                return false;
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Указана несуществующая директория: {path}");
                return false;
            }
            _path = path;
            return true;
        }

        public async void Handle()
        {
            bool result = InitializePath();
            if (!result)
            {
                return;
            }

            var getFilesResult = GetFiles();
            if (!getFilesResult.hasFiles)
            {
                return;
            }

            LogValidator validator = new LogValidator();
            
            foreach (var filePath in getFilesResult.names!)
            {
                string[] fileData = await File.ReadAllLinesAsync(filePath);
                if (fileData.Length == 0 || string.IsNullOrEmpty(fileData[0]))
                {
                    WriteToProblemsFile("Файл пустой:" + filePath);
                }

                bool containsLine = fileData[0].Contains("|");

                string? resultHandle = containsLine ? validator.ValidateLogType1(fileData[0]) : validator.ValidateLogType2(fileData[0]);

                if (string.IsNullOrEmpty(resultHandle))
                {
                    WriteToProblemsFile(fileData[0]);
                    continue;
                }
                WriteToLogFile(resultHandle);
            }
        }

        private (bool hasFiles, string[]? names) GetFiles()
        {
            var files = Directory.GetFiles(_path);
            if (files == null)
            {
                Console.WriteLine("Файлов в папке нет.");
                return (false, files);
            }
            return (true, files);
        }

        private void WriteToLogFile(string text)
        {
            File.AppendAllText(Path.Combine(_path, "Logs.txt"), text + "\n");
        }

        private void WriteToProblemsFile(string text)
        {
            File.AppendAllText(Path.Combine(_path, "Problems.txt"), text + "\n");
        }
    }
}
