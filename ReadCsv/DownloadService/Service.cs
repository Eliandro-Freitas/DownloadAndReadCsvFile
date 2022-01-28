using Download.Helper;
using System.Net;

namespace Download;

public class Service
{
    public const string _url = "http://srea64.github.io/msan622/project/pokemon.csv";
    private readonly FileRepository _fileRepository;

    public Service()
        => _fileRepository = new FileRepository();

    public void Download(string filePath)
    {
        var byteFile = DownloadFile();
        var stream = new MemoryStream(byteFile);
        var fileName = "pokemon.csv";
        _fileRepository.Writer(fileName, stream, filePath);
        Console.WriteLine($"Download do arquivo {fileName} finalizado.");
    }

    private static byte[] DownloadFile()
    {
        var webClient = new WebClient();
        Console.WriteLine($"Obtendo arquivo de: {_url}");
        return webClient.DownloadData(_url);
    }
}