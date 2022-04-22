using System.Xml.Linq;

public class XmlHandler
{
    private XDocument _xDocument;

    public XmlHandler(string xmlSource)
    {
        _xDocument = XDocument.Load(xmlSource);
        RootName = _xDocument.Root!.Name;
    }

    public XName RootName { get; private set; }
    public XDocument UTest_xDocument { get => _xDocument; }

    public IEnumerable<XElement> GetRootStructure()
    {
        IEnumerable<XElement> structure =
            from e in _xDocument.Elements()
            select e;

        return structure;
    }

    public IEnumerable<XElement> GetElementList(string element)
    {
        IEnumerable<XElement> eList =
            from e in _xDocument.Descendants(element)
            select e;

        return eList;
    }

    public IEnumerable<XElement> GetElementValue(string parent, string descendant)
    {
        IEnumerable<XElement> eList =
            from e in _xDocument.Descendants(parent)
            select e.Element(descendant);
        
        return eList;
    }
}