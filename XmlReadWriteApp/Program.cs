using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

// Config
const string CONFIG_FILE = "AppConfig/appsettings";
IConfiguration _configuration = new ConfigurationBuilder()
    .AddJsonFile($"{CONFIG_FILE}.development.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

string xmlSource = AppDomain.CurrentDomain.BaseDirectory + _configuration["XmlSources:Default"];
var xmlHandler = new XmlHandler(xmlSource);

// Print element list
IEnumerable<string> listOfElements = xmlHandler.GetElementList();

foreach (string element in listOfElements)
    Console.WriteLine(element);

// Print element keys with values list
IEnumerable<XElement> listOfKeys = xmlHandler.GetKeyList();
string xmlRoot = listOfKeys.ElementAtOrDefault(0)?.Parent?.Name.ToString();
Console.WriteLine($"\nXML Root <{xmlRoot}>:\n");
foreach (var key in listOfKeys)
{
    Console.WriteLine(key);
}
