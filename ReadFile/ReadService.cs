using ReadFile.ReadingService;

var service = new Service();
Console.WriteLine("Caminho do arquivo: ");
var filePath = @$"{Console.ReadLine()}\pokemon.csv";
var stream = File.OpenRead(filePath);
service.Run(stream);