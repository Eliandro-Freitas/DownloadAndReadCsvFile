using Download;

var service = new Service();
Console.WriteLine("Caminho para salvar o arquivo");
var filePath = $@"{Console.ReadLine()}";
service.Download(filePath);
Console.WriteLine($"Arquivo salvo em ({filePath})");