using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

// Config
const string CONFIG_FILE = "AppConfig/appsettings";
string base_dir = AppDomain.CurrentDomain.BaseDirectory;
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile($"{CONFIG_FILE}.development.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Data source path
string xmlSource = base_dir + configuration["XmlSources:PurchaseOrder"];

// Handler instance
var xmlHandler = new XmlHandler(xmlSource);

/*// Get root structure
IEnumerable<XElement>? xmlWithRoot = xmlHandler.GetRootStructure();
string xmlRoot = xmlHandler.RootName.ToString();

Console.WriteLine($"# XML Root <{xmlRoot ?? default}>:\n");
foreach (XElement key in xmlWithRoot)
    Console.WriteLine(key);
Console.WriteLine("\n---\n");

// Get element list
string elementGetElementList = "Item";
IEnumerable<XElement>? xmlGetElementList = xmlHandler.GetElementList(elementGetElementList);

Console.WriteLine($"Element <{elementGetElementList}>:\n");
foreach (XElement e in xmlGetElementList)
    Console.WriteLine(e);
Console.WriteLine("\n---\n");

// Get value from specified element
string parentGetElementValue = "Item", descendantGetElementValue = "ProductName";
IEnumerable<XElement>? xmlGetElementValue = xmlHandler.GetElementValue(
    parentGetElementValue,
    descendantGetElementValue);

Console.WriteLine($"<{parentGetElementValue}>:");
Console.WriteLine($@"   <{xmlGetElementValue.First().Name}>");
foreach (XElement key in xmlGetElementValue)
    Console.WriteLine($@"    {key.Value}");
Console.WriteLine("\n---\n");*/

// Get descendant values given parent attribute value
string
    parentGetDescendantValues = "Address",
    attributeNameGetDescendantValues = "Type",
    attributeValueGetDescendantValues = "Billing";
var xmlGetDescendantValues = xmlHandler.GetDescendantValues<XElement>(
    parentGetDescendantValues,
    attributeNameGetDescendantValues,
    attributeValueGetDescendantValues);

Console.WriteLine($"{attributeValueGetDescendantValues} {parentGetDescendantValues}:");
foreach (var key in xmlGetDescendantValues)
    Console.WriteLine($@"   {key.Name}: {key.Value}");
Console.WriteLine("\n---\n");
