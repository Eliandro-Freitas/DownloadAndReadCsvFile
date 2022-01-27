using Download;

var service = new Service();
Console.WriteLine("Caminho para salvar o arquivo");
var pathFile = Console.ReadLine();
service.Download(@$"{pathFile}");