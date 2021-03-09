using System;
using System.Xml.XPath;

namespace Examples
{
    public class XPathSample
    {
        static void Main()
        {
            XPathDocument xPathDocument = new XPathDocument("books.xml");
            XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();

            XPathNodeIterator xPathNodeIterator = xPathNavigator.Select("/bookstore/book");
            xPathNodeIterator.MoveNext();
            XPathNavigator nodesNavigator = xPathNodeIterator.Current;

            XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);

            while (nodesText.MoveNext())
                Console.WriteLine(nodesText.Current.Value);

            Console.ReadKey();
        }
    }
}