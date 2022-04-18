using System.Xml.Linq;

internal class XmlHandler
{
    public XmlHandler(string xmlSource)
    {
        XmlSource = xmlSource;
    }

    public string XmlSource { get; }

    internal IEnumerable<string> GetElementList(string elementName)
    {
        XElement xElement = XElement.Load(XmlSource);

        IEnumerable<string> list = from eName in xElement.Descendants(elementName)
                                   select eName.Value;

        return list;
    }
}