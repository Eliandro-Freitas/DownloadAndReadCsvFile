namespace Download.Helper;

public class FileRepository
{
    public string Writer(string fileName, Stream file, string filePath)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));

        var completePath = Path.Combine(filePath, fileName);
        var path = Path.GetDirectoryName(completePath);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        using (var output = new FileStream(completePath, FileMode.Create))
            file.CopyTo(output);

        return completePath;
    }
}