using System;
using System.Xml;

namespace Examples
{
    public class XmlDocumentReadSample
    {
        public static void Main()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
                Console.WriteLine(xmlNode.Attributes["currency"].Value + ": " + xmlNode.Attributes["rate"].Value);
            Console.ReadKey();
        }
    }
}