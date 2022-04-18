// See https://aka.ms/new-console-template for more information

var xmlHandler = new XmlHandler(@"C:\...\xmlFile.xml");
string elementName = "title";

IEnumerable<string> listOfTitles = xmlHandler.GetElementList(elementName);

foreach (string title in listOfTitles)
    Console.WriteLine(title);
