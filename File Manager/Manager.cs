namespace File_Manager;
//Gets all files in a given directory and sorts them based on inputed parameters
class Manager
{
    public void manage(string check, string destination, string file, string type)
    {
        var files = Directory.GetFiles(check, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string f in files)
        {
            if(Path.GetFileName(f).ToLower().EndsWith($".{type.ToLower()}") && Path.GetFileName(f).ToLower().StartsWith(file.ToLower()))
            {
                File.Move(f, $"{destination}\\{Path.GetFileName(f)}");
            }
        }

        MessageBox.Show("File sorting completed!");
    }
}
