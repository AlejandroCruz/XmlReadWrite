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
}