using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQChapter8
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing8_1();
      //Listing8_2();
      //Listing8_3();
      //Listing8_4();
      //Listing8_5();
      //Listing8_6();
      //Listing8_7();
      //Listing8_8();
      //Listing8_9();
      //Listing8_10();
      //Listing8_11();
      //Listing8_12();
      //Listing8_13();
      //Listing8_14();
      //Listing8_15();
      //Listing8_16();
      //Listing8_17();
      //Listing8_18();
      //Listing8_19();
      //Listing8_20();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Descendants("FirstName");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display the ancestor elements for each source element.
      foreach (XElement element in elements.Ancestors())
      {
        Console.WriteLine("Ancestor element: {0}", element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Descendants("FirstName");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      foreach (XElement element in elements)
      {
        //  Call the Ancestors method on each element.
        foreach (XElement e in element.Ancestors())
          //  Now, I will display the ancestor elements for each source element.
          Console.WriteLine("Ancestor element: {0}", e.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XElement element in
        xDocument.Element("BookParticipants").Descendants("FirstName").Ancestors())
      {
        Console.WriteLine("Ancestor element: {0}", element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Descendants("FirstName");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display the ancestor elements for each source element.
      foreach (XElement element in elements.Ancestors("BookParticipant"))
      {
        Console.WriteLine("Ancestor element: {0}", element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Descendants("FirstName");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display the ancestor elements for each source element.
      foreach (XElement element in elements.AncestorsAndSelf())
      {
        Console.WriteLine("Ancestor element: {0}", element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Descendants("FirstName");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display the ancestor elements for each source element.
      foreach (XElement element in elements.AncestorsAndSelf("BookParticipant"))
      {
        Console.WriteLine("Ancestor element: {0}", element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's attributes.
      foreach (XAttribute attribute in elements.Attributes())
      {
        Console.WriteLine("Attribute: {0} : value = {1}",
          attribute.Name, attribute.Value);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's attributes.
      foreach (XAttribute attribute in elements.Attributes("type"))
      {
        Console.WriteLine("Attribute: {0} : value = {1}",
          attribute.Name, attribute.Value);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant nodes.
      foreach (XNode node in elements.DescendantNodes())
      {
        Console.WriteLine("Descendant node: {0}", node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant nodes.
      foreach (XNode node in elements.DescendantNodesAndSelf())
      {
        Console.WriteLine("Descendant node: {0}", node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant elements.
      foreach (XElement element in elements.Descendants())
      {
        Console.WriteLine("Descendant element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant elements.
      foreach (XElement element in elements.Descendants("LastName"))
      {
        Console.WriteLine("Descendant element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant elements.
      foreach (XElement element in elements.DescendantsAndSelf())
      {
        Console.WriteLine("Descendant element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's descendant elements.
      foreach (XElement element in elements.DescendantsAndSelf("LastName"))
      {
        Console.WriteLine("Descendant element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's elements.
      foreach (XElement element in elements.Elements())
      {
        Console.WriteLine("Child element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's elements.
      foreach (XElement element in elements.Elements("LastName"))
      {
        Console.WriteLine("Child element: {0}", element);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XNode> nodes =
        xDocument.Element("BookParticipants").Elements("BookParticipant").
          Nodes().Reverse();

      //  First, I will display the source nodes.
      foreach (XNode node in nodes)
      {
        Console.WriteLine("Source node: {0}", node);
      }

      //  Now, I will display each source nodes's child nodes.
      foreach (XNode node in nodes.InDocumentOrder())
      {
        Console.WriteLine("Ordered node: {0}", node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  First, I will display the source elements.
      foreach (XElement element in elements)
      {
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }

      //  Now, I will display each source element's child nodes.
      foreach (XNode node in elements.Nodes())
      {
        Console.WriteLine("Child node: {0}", node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XAttribute> attributes =
        xDocument.Element("BookParticipants").Elements("BookParticipant").Attributes();

      //  First, I will display the source attributes.
      foreach (XAttribute attribute in attributes)
      {
        Console.WriteLine("Source attribute: {0} : value = {1}",
          attribute.Name, attribute.Value);
      }

      attributes.Remove();

      //  Now, I will display the XML document.
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing8_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XComment("This is a new author."),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      IEnumerable<XComment> comments =
        xDocument.Element("BookParticipants").Elements("BookParticipant").
          Nodes().OfType<XComment>();

      //  First, I will display the source comments.
      foreach (XComment comment in comments)
      {
        Console.WriteLine("Source comment: {0}", comment);
      }

      comments.Remove();

      //  Now, I will display the XML document.
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
