using Xunit;

namespace XmlReadWriteTest
{
    public class XmlHandlerTest
    {
        [Fact]
        public void UnitTestDocPath_ShouldValidateFileExists()
        {
            string assemblyName = typeof(XmlHandler).Assembly.Location;
            string baseDir = assemblyName.Substring(0, assemblyName.LastIndexOf(@"\"));
            string xmlSource = baseDir + @"\Resources\Documents\xmlFile.xml";
            var xmlHandler = new XmlHandler(xmlSource);

            Assert.NotNull(xmlHandler.UTest_xDocument);
        }
    }
}
