using System.Xml.Linq;

internal class XmlHandler
{
    private XElement _xmlContent;

    public XmlHandler(string xmlSource)
    {
        XmlSource = xmlSource;
        _xmlContent = XElement.Load(xmlSource);
    }

    public string XmlSource { get; }

    internal IEnumerable<string> GetElementList()
    {
        IEnumerable<string> list =
            from e in _xmlContent.Elements()
            select (string)e;

        return list;
    }

    internal IEnumerable<XElement> GetKeyList()
    {
        IEnumerable<XElement> groupByElementName =
            from e in _xmlContent.Elements()
            select e;

        return groupByElementName;
    }
}