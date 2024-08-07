namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                CopyDirectory(@"C:\Users\Brill\Desktop\Новая папка", @"C:\Users\Brill\Desktop\Новая папка 1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void CopyDirectory(string oldPath, string newPath)
        {
            if(oldPath is null) throw new ArgumentNullException(nameof(oldPath));
            if (newPath is null) throw new ArgumentNullException(nameof(newPath));
            if(!Directory.Exists(oldPath)) throw new DirectoryNotFoundException(nameof(oldPath));
            DirectoryInfo dir = new DirectoryInfo(oldPath);
            if (!dir.Exists) throw new DirectoryNotFoundException();
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(newPath, file.Name);
                file.CopyTo(temppath, false);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(newPath, subdir.Name);
                CopyDirectory(subdir.FullName, temppath);
            }
        }
    }
}

//Создайте приложение для копирования папок. 
//Пользователь вводит путь к оригинальной папке и путь к тому месту куда нужно скопировать папку.
//Приложение должно сообщить об успешности или неуспешности операции.