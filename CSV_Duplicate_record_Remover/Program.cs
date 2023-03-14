
Console.Write("Enter a filepath: ");
string filePathInput = ValidateFilePath();
string filePathOutput = @$"{Path.GetDirectoryName(filePathInput)}\{Path.GetFileNameWithoutExtension(filePathInput)}_duplicates_removed.csv";
var values = ReadCSVFile(filePathInput);
WriteCSVFile(filePathOutput, values);

static string ValidateFilePath()
{
    string filePath = String.Empty;
    while (true)
    {
        filePath = Console.ReadLine().Replace("\"", "");
        if (File.Exists(filePath))
        {
            return filePath;
        }
        else
        {
            Console.Write("Filepath is not valid, please enter valid filepath: ");
        }
    }
}
static List<string> ReadCSVFile(string filePath)
{
    List<string> list = new List<string>();
    StreamReader reader = new StreamReader(filePath);
    while (true)
    {
        string line = reader.ReadLine();
        if(line == null)
        {
            break;
        }
        else
        {
            if (!list.Contains(line))
            {
                list.Add(line);
            }
            else
            {
                continue;
            }
        }
    }
    return list;
}
static void WriteCSVFile(string filePath, List<string> values)
{
    StreamWriter writer = new StreamWriter(filePath);
    foreach(string line in values)
    {
        writer.WriteLine(line);
    }
    writer.Close();
    Console.WriteLine();
    Console.WriteLine("Duplicates removed!");
}