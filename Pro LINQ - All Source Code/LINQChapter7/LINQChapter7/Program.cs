using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Xml.Linq;
using System.Xml;
using System.Text;

namespace LINQChapter7
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing7_1();
      //Listing7_2();
      //Listing7_3();
      //Listing7_4();
      //Listing7_5();
      //Listing7_6();
      //Listing7_7();
      //Listing7_8();
      //Listing7_9();
      //Listing7_10();
      //Listing7_11();
      //Listing7_12();
      //Listing7_13();
      //Listing7_14();
      //Listing7_15();
      //Listing7_16();
      //Listing7_17();
      //Listing7_18();
      //Listing7_19();
      //Listing7_20();
      //Listing7_21();
      //Listing7_22();
      //Listing7_23();
      //Listing7_24();
      //Listing7_25();
      //Listing7_26();
      //Listing7_27();
      //Listing7_28();
      //Listing7_29();
      //Listing7_30();
      //Listing7_31();
      //Listing7_32();
      //Listing7_33();
      //Listing7_34();
      //Listing7_35();
      //Listing7_36();
      //Listing7_37();
      //Listing7_38();
      //Listing7_39();
      //Listing7_40();
      //Listing7_41();
      //Listing7_42();
      //Listing7_43();
      //Listing7_44();
      //Listing7_45();
      //Listing7_46();
      //Listing7_47();
      //Listing7_48();
      //Listing7_49();
      //Listing7_50();
      //Listing7_51();
      //Listing7_52();
      //Listing7_53();
      //Listing7_54();
      //Listing7_55();
      //Listing7_56();
      //Listing7_57();
      //Listing7_58();
      //Listing7_59();
      //Listing7_60();
      //Listing7_61();
      //Listing7_62();
      //Listing7_63();
      //Listing7_64();
      //Listing7_65();
      //Listing7_66();
      //Listing7_67();
      //Listing7_68();
      //Listing7_69();
      //Listing7_70();
      //Listing7_71();
      //Listing7_72();
      //Listing7_73();
      //Listing7_74();
      //Listing7_75();
      //Listing7_76();
      //Listing7_77();
      //Listing7_78();
      //Listing7_79();
      //Listing7_80();
      //Listing7_81();
      //Listing7_82();
      //Listing7_83();
      //Listing7_84();
      //Listing7_85();
      //Listing7_86();
      //Listing7_87();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant =
        new XElement("BookParticipant",
          new XElement("FirstName", "Joe"),
          new XElement("LastName", "Rattz"));

      Console.WriteLine(xBookParticipant.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipants =
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham")));

      Console.WriteLine(xBookParticipants.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument =
        new XDocument(
          new XElement("BookParticipants",
            new XElement("BookParticipant",
              new XAttribute("type", "Author"),
              new XElement("FirstName", "Joe"),
              new XElement("LastName", "Rattz"))));

      Console.WriteLine(xDocument.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xElement =
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")));

      Console.WriteLine(xElement.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XNamespace nameSpace = "http://www.linqdev.com";

      XElement xBookParticipants =
        new XElement(nameSpace + "BookParticipants",
          new XElement(nameSpace + "BookParticipant",
            new XAttribute("type", "Author"),
            new XElement(nameSpace + "FirstName", "Joe"),
            new XElement(nameSpace + "LastName", "Rattz")),
          new XElement(nameSpace + "BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement(nameSpace + "FirstName", "Ewan"),
            new XElement(nameSpace + "LastName", "Buckingham")));

      Console.WriteLine(xBookParticipants.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XNamespace nameSpace = "http://www.linqdev.com";

      XElement xBookParticipants =
        new XElement(nameSpace + "BookParticipants",
          new XAttribute(XNamespace.Xmlns + "linqdev", nameSpace),
          new XElement(nameSpace + "BookParticipant"));

      Console.WriteLine(xBookParticipants.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement name = new XElement("Name", "Joe");
      Console.WriteLine(name.ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement name = new XElement("Person",
        new XElement("FirstName", "Joe"),
        new XElement("LastName", "Rattz"));
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement name = new XElement("Name", "Joe");
      Console.WriteLine(name);
      Console.WriteLine((string)name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement count = new XElement("Count", 12);
      Console.WriteLine(count);
      Console.WriteLine((int)count);

      XElement smoker = new XElement("Smoker", false);
      Console.WriteLine(smoker);
      Console.WriteLine((bool)smoker);

      XElement pi = new XElement("Pi", 3.1415926535);
      Console.WriteLine(pi);
      Console.WriteLine((double)pi);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement smoker = new XElement("Smoker", "true");
      Console.WriteLine(smoker);
      Console.WriteLine((bool)smoker);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      try
      {
        XElement smoker = new XElement("Smoker", "Tue");
        Console.WriteLine(smoker);
        Console.WriteLine((bool)smoker);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I'll create a full document.
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

      //  I'll get a sequence of BookParticipant elements.  I need a sequence of some
      //  elements to remove to demonstrate the Halloween problem.
      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  Just so you can see the actual source elements in the sequence...
      foreach (XElement element in elements)
      {
        // First, we will display the source elements.
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }
      //  Ok, I have the BookParticipant elements.

      //  Now that we have seen the sequence of source elements, I'll enumerate 
      //  through the sequence removing them one at a time.
      foreach (XElement element in elements)
      {
        // Now, I'll remove each element.
        Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
        element.Remove();
      }

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I'll create a full document.
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

      //  I'll get a sequence of BookParticipant elements.  I need a sequence of some
      //  elements to remove to demonstrate the Halloween problem.
      IEnumerable<XElement> elements =
        xDocument.Element("BookParticipants").Elements("BookParticipant");

      //  Just so you can see the actual source elements in the sequence...
      foreach (XElement element in elements)
      {
        // First, we will display the source elements.
        Console.WriteLine("Source element: {0} : value = {1}",
          element.Name, element.Value);
      }
      //  Ok, I have the BookParticipant elements.

      //  Now that we have seen the sequence of source elements, I'll enumerate 
      //  through the sequence removing them one at a time.
      foreach (XElement element in elements.ToArray())
      {
        // Now, I'll remove each element.
        Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
        element.Remove();
      }

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstName = new XElement("FirstName", "Joe");
      Console.WriteLine((string)firstName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      BookParticipant[] bookParticipants = new[] {
        new BookParticipant {FirstName = "Joe", LastName = "Rattz", 
                             ParticipantType = ParticipantTypes.Author},
        new BookParticipant {FirstName = "Ewan", LastName = "Buckingham",
                             ParticipantType = ParticipantTypes.Editor}
      };

      XElement xBookParticipants =
         new XElement("BookParticipants",
                       bookParticipants.Select(p =>
                         new XElement("BookParticipant",
                           new XAttribute("type", p.ParticipantType),
                           new XElement("FirstName", p.FirstName),
                           new XElement("LastName", p.LastName))));

      Console.WriteLine(xBookParticipants);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant = new XElement("BookParticipant",
                                               new XAttribute("type", "Author"));

      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant = new XElement("BookParticipant");
      XAttribute xAttribute = new XAttribute("type", "Author");
      xBookParticipant.Add(xAttribute);

      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant = new XElement("BookParticipant",
                                               new XComment("This person is retired."));

      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant = new XElement("BookParticipant");
      XComment xComment = new XComment("This person is retired.");
      xBookParticipant.Add(xComment);

      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_21()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                          new XElement("BookParticipant"));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_22()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(new XElement("BookParticipant"));

      XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", "yes");
      xDocument.Declaration = xDeclaration;

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_23()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(new XDocumentType("BookParticipants",
                                                            null,
                                                            "BookParticipants.dtd",
                                                            null),
                                          new XElement("BookParticipant"));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_24()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument();

      XDocumentType documentType =
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null);

      xDocument.Add(documentType, new XElement("BookParticipants"));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_25()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument();
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_26()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        new XElement("BookParticipants"));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_27()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xBookParticipant = new XElement("BookParticipant");
      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_28()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XNamespace ns = "http://www.linqdev.com/Books";
      XElement xBookParticipant = new XElement(ns + "BookParticipant");
      Console.WriteLine(xBookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_29()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XProcessingInstruction("ParticipantDeleter", "delete"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_30()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument =
        new XDocument(new XElement("BookParticipants",
                                   new XElement("BookParticipant",
                                                new XElement("FirstName", "Joe"),
                                                new XElement("LastName", "Rattz"))));

      XProcessingInstruction xPI1 = new XProcessingInstruction("BookCataloger",
                                                               "out-of-print");
      xDocument.AddFirst(xPI1);

      XProcessingInstruction xPI2 = new XProcessingInstruction("ParticipantDeleter",
                                                               "delete");
      XElement outOfPrintParticipant = xDocument
        .Element("BookParticipants")
        .Elements("BookParticipant")
        .Where(e => ((string)((XElement)e).Element("FirstName")) == "Joe"
                 && ((string)((XElement)e).Element("LastName")) == "Rattz")
        .Single<XElement>();

      outOfPrintParticipant.AddFirst(xPI2);

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_31()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] names = { "John", "Paul", "George", "Pete" };

      XElement xNames = new XElement("Beatles",
                                     from n in names
                                     select new XElement("Name", n));

      names[3] = "Ringo";

      Console.WriteLine(xNames);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_32()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] names = { "John", "Paul", "George", "Pete" };

      XStreamingElement xNames =
        new XStreamingElement("Beatles",
                              from n in names
                              select new XStreamingElement("Name", n));

      names[3] = "Ringo";

      Console.WriteLine(xNames);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_33()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xFirstName = new XElement("FirstName", "Joe");
      Console.WriteLine(xFirstName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_34()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XText xName = new XText("Joe");
      XElement xFirstName = new XElement("FirstName", xName);
      Console.WriteLine(xFirstName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_35()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xErrorMessage = new XElement("HTMLMessage",
                                 new XCData("<H1>Invalid user id or password.</H1>"));

      Console.WriteLine(xErrorMessage);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_36()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      xDocument.Save("bookparticipants.xml");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_37()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement bookParticipants =
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")));

      bookParticipants.Save("bookparticipants.xml");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_38()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = XDocument.Load("bookparticipants.xml",
        LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);

      Console.WriteLine(xDocument);

      XElement firstName = xDocument.Descendants("FirstName").First();

      Console.WriteLine("FirstName Line:{0} - Position:{1}",
        ((IXmlLineInfo)firstName).LineNumber,
        ((IXmlLineInfo)firstName).LinePosition);

      Console.WriteLine("FirstName Base URI:{0}", firstName.BaseUri);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_39()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xElement = XElement.Load("c:\\bookparticipants.xml");
      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_40()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><BookParticipants>" +
        "<BookParticipant type=\"Author\" experience=\"first-time\" language=" +
        "\"English\"><FirstName>Joe</FirstName><LastName>Rattz</LastName>" +
        "</BookParticipant></BookParticipants>";

      XElement xElement = XElement.Parse(xml);
      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_41()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_42()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(firstParticipant.NextNode);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_43()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(firstParticipant.NextNode.PreviousNode);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_44()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(firstParticipant.Document);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_45()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(firstParticipant.Parent);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_46()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Nodes())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_47()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Nodes())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_48()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Nodes().OfType<XElement>())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_49()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Nodes().OfType<XComment>())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_50()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XAttribute attr in firstParticipant.Attributes())
      {
        Console.WriteLine(attr);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_51()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Elements())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_52()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XNode node in firstParticipant.Elements("FirstName"))
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_53()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(firstParticipant.Element("FirstName"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_54()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName",
              new XText("Joe"),
              new XElement("NickName", "Joey")),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XElement element in firstParticipant.
        Element("FirstName").Element("NickName").Ancestors())
      {
        Console.WriteLine(element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_55()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName",
              new XText("Joe"),
              new XElement("NickName", "Joey")),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XElement element in firstParticipant.
        Element("FirstName").Element("NickName").AncestorsAndSelf())
      {
        Console.WriteLine(element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_56()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName",
              new XText("Joe"),
              new XElement("NickName", "Joey")),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XElement element in firstParticipant.Descendants())
      {
        Console.WriteLine(element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_57()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XProcessingInstruction("AuthorHandler", "new"),
            new XAttribute("type", "Author"),
            new XElement("FirstName",
              new XText("Joe"),
              new XElement("NickName", "Joey")),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      foreach (XElement element in firstParticipant.DescendantsAndSelf())
      {
        Console.WriteLine(element.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_58()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants",
          new XComment("Begin Of List"), firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham")),
          new XComment("End Of List")));

      foreach (XNode node in firstParticipant.NodesAfterSelf())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_59()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants",
          new XComment("Begin Of List"), firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham")),
          new XComment("End Of List")));

      foreach (XNode node in firstParticipant.ElementsAfterSelf())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_60()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants",
          new XComment("Begin Of List"), firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham")),
          new XComment("End Of List")));

      foreach (XNode node in firstParticipant.NextNode.NodesBeforeSelf())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_61()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      //  A full document with all the bells and whistles.
      XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
        new XProcessingInstruction("BookCataloger", "out-of-print"),
        //  Notice on the next line that I am saving off a reference to the first
        //  BookParticipant element.
        new XElement("BookParticipants",
          new XComment("Begin Of List"), firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham")),
          new XComment("End Of List")));

      foreach (XNode node in firstParticipant.NextNode.ElementsBeforeSelf())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_62()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  A document with one book participant.
      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_63()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  A document with one book participant.
      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      xDocument.Element("BookParticipants").Add(
        new XElement("BookParticipant",
          new XAttribute("type", "Editor"),
          new XElement("FirstName", "Ewan"),
          new XElement("LastName", "Buckingham")));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_64()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  A document with one book participant.
      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      xDocument.Element("BookParticipants").AddFirst(
        new XElement("BookParticipant",
          new XAttribute("type", "Editor"),
          new XElement("FirstName", "Ewan"),
          new XElement("LastName", "Buckingham")));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_65()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  A document with one book participant.
      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      xDocument.Element("BookParticipants").Add(
        new XElement("BookParticipant",
          new XAttribute("type", "Editor"),
          new XElement("FirstName", "Ewan"),
          new XElement("LastName", "Buckingham")));

      //  Now I'll insert a new element between the two BookParticipant elements.
      //  First with AddBeforeThis.
      //  Since I am inserting before the reference node, I must obtain a reference
      //  to the second BookParticipant element.
      xDocument.Element("BookParticipants").
        Elements("BookParticipant").
        Where(e => ((string)e.Element("FirstName")) == "Ewan").
        Single<XElement>().AddBeforeSelf(
          new XElement("BookParticipant",
            new XAttribute("type", "Technical Reviewer"),
            new XElement("FirstName", "Fabio"),
            new XElement("LastName", "Ferracchiati")));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_66()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  A document with one book participant.
      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      xDocument.Element("BookParticipants").Add(
        new XElement("BookParticipant",
          new XAttribute("type", "Editor"),
          new XElement("FirstName", "Ewan"),
          new XElement("LastName", "Buckingham")));

      //  Now I'll insert a new element between the two BookParticipant elements.
      //  Now with AddAfterSelf.
      //  Since I am inserting after the reference node, I must obtain a reference
      //  to the first BookParticipant element.
      xDocument.Element("BookParticipants").
        Element("BookParticipant").AddAfterSelf(
          new XElement("BookParticipant",
            new XAttribute("type", "Technical Reviewer"),
            new XElement("FirstName", "Fabio"),
            new XElement("LastName", "Ferracchiati")));

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_67()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      Console.WriteLine(System.Environment.NewLine + "Before node deletion");

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine(xDocument);

      firstParticipant.Remove();
      Console.WriteLine(System.Environment.NewLine + "After node deletion");

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_68()
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

      xDocument.Descendants().Where(e => e.Name == "FirstName").Remove();

      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_69()
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

      Console.WriteLine(System.Environment.NewLine + "Before removing the content.");
      Console.WriteLine(xDocument);

      xDocument.Element("BookParticipants").RemoveAll();

      Console.WriteLine(System.Environment.NewLine + "After removing the content.");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_70()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XComment("This is a new author."),
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine("Before updating nodes:");
      Console.WriteLine(xDocument);

      //  Now, I'll update an element, a comment, and a text node.
      firstParticipant.Element("FirstName").Value = "Joey";
      firstParticipant.Nodes().OfType<XComment>().Single().Value =
        "Author of Pro LINQ: Language Integrated Query in C# 2008.";
      ((XElement)firstParticipant.Element("FirstName").NextNode)
        .Nodes().OfType<XText>().Single().Value = "Rattz, Jr.";

      Console.WriteLine("After updating nodes:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_71()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to the DocumentType for later access.
      XDocumentType docType;

      XDocument xDocument = new XDocument(
        docType = new XDocumentType("BookParticipants", null,
                                    "BookParticipants.dtd", null),
        new XElement("BookParticipants"));

      Console.WriteLine("Before updating document type:");
      Console.WriteLine(xDocument);

      docType.Name = "MyBookParticipants";
      docType.SystemId = "http://www.somewhere.com/DTDs/MyBookParticipants.DTD";
      docType.PublicId = "-//DTDs//TEXT Book Participants//EN";

      Console.WriteLine("After updating document type:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_72()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference for later access.
      XProcessingInstruction procInst;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants"),
        procInst = new XProcessingInstruction("BookCataloger", "out-of-print"));

      Console.WriteLine("Before updating processing instruction:");
      Console.WriteLine(xDocument);

      procInst.Target = "BookParticipantContactManager";
      procInst.Data = "update";

      Console.WriteLine("After updating processing instruction:");
      Console.WriteLine(xDocument);


      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_73()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine + "Before updating elements:");
      Console.WriteLine(xDocument);

      firstParticipant.ReplaceAll(
        new XElement("FirstName", "Ewan"),
        new XElement("LastName", "Buckingham"));

      Console.WriteLine(System.Environment.NewLine + "After updating elements:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_74()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine + "Before updating elements:");
      Console.WriteLine(xDocument);

      //  First, I will use XElement.SetElementValue to update the value of an element.
      //  Since an element named FirstName is there, its value will be updated to Joseph.
      firstParticipant.SetElementValue("FirstName", "Joseph");

      //  Second, I will use XElement.SetElementValue to add an element.
      //  Since no element named MiddleInitial exists, one will be added.
      firstParticipant.SetElementValue("MiddleInitial", "C");

      //  Third, I will use XElement.SetElementValue to remove an element.
      //  Setting an element's value to null will remove it.
      firstParticipant.SetElementValue("LastName", null);

      Console.WriteLine(System.Environment.NewLine + "After updating elements:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_75()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(firstParticipant.FirstAttribute);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_76()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(firstParticipant.FirstAttribute.NextAttribute);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_77()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(firstParticipant.FirstAttribute.NextAttribute.PreviousAttribute);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_78()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(firstParticipant.LastAttribute);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_79()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(firstParticipant.Attribute("type").Value);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_80()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      foreach (XAttribute attr in firstParticipant.Attributes())
      {
        Console.WriteLine(attr);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_81()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine + "Before removing attribute:");
      Console.WriteLine(xDocument);

      firstParticipant.Attribute("type").Remove();

      Console.WriteLine(System.Environment.NewLine + "After removing attribute:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_82()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine + "Before removing attributes:");
      Console.WriteLine(xDocument);

      firstParticipant.Attributes().Remove();

      Console.WriteLine(System.Environment.NewLine + "After removing attributes:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_83()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine +
        "Before changing attribute's value:");
      Console.WriteLine(xDocument);

      firstParticipant.Attribute("experience").Value = "beginner";

      Console.WriteLine(System.Environment.NewLine + "After changing attribute's value:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_84()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"))));

      Console.WriteLine(System.Environment.NewLine + "Before changing the attributes:");
      Console.WriteLine(xDocument);

      //  This call will update the type attribute's value because an attribute whose 
      //  name is "type" exists.
      firstParticipant.SetAttributeValue("type", "beginner");

      //  This call will add an attribute because an attribute with the specified name
      //  does not exist.
      firstParticipant.SetAttributeValue("language", "English");

      //  This call will delete an attribute because an attribute with the specified name
      //  exists, and the passed value is null.
      firstParticipant.SetAttributeValue("experience", null);

      Console.WriteLine(System.Environment.NewLine + "After changing the attributes:");
      Console.WriteLine(xDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_85()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I will use this to store a reference to one of the elements in the XML tree.
      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("experience", "first-time"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      //  Display the document for reference.
      Console.WriteLine(xDocument + System.Environment.NewLine);

      //  I'll add some annotations based on their type attribute.
      foreach (XElement e in xDocument.Element("BookParticipants").Elements())
      {
        if ((string)e.Attribute("type") == "Author")
        {
          AuthorHandler aHandler = new AuthorHandler();
          e.AddAnnotation(aHandler);
        }
        else if ((string)e.Attribute("type") == "Editor")
        {
          EditorHandler eHandler = new EditorHandler();
          e.AddAnnotation(eHandler);
        }
      }

      //  Declare some variables for the handler objects.  I declared additional
      //  variables because normally, I probably wouldn't be adding the annotations
      //  and retrieving them in the same place.
      AuthorHandler aHandler2;
      EditorHandler eHandler2;
      foreach (XElement e in xDocument.Element("BookParticipants").Elements())
      {
        if ((string)e.Attribute("type") == "Author")
        {
          aHandler2 = e.Annotation<AuthorHandler>();
          if (aHandler2 != null)
          {
            aHandler2.Display(e);
          }
        }
        else if ((string)e.Attribute("type") == "Editor")
        {
          eHandler2 = e.Annotation<EditorHandler>();
          if (eHandler2 != null)
          {
            eHandler2.Display(e);
          }
        }
      }

      //  Now, I'll remove the annotations.
      //  This time I will just reuse the handler variables from above.  But normally,
      //  this too would probably be done elsewhere.
      foreach (XElement e in xDocument.Element("BookParticipants").Elements())
      {
        if ((string)e.Attribute("type") == "Author")
        {
          e.RemoveAnnotations<AuthorHandler>();
        }
        else if ((string)e.Attribute("type") == "Editor")
        {
          e.RemoveAnnotations<EditorHandler>();
        }
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_86()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("{0}{1}", xDocument, System.Environment.NewLine);

      //  First I must register for the event.
      firstParticipant.Changing +=
        new EventHandler<XObjectChangeEventArgs>(MyChangingEventHandler);
      firstParticipant.Changed += 
        new EventHandler<XObjectChangeEventArgs>(MyChangedEventHandler);
      xDocument.Changed += 
        new EventHandler<XObjectChangeEventArgs>(DocumentChangedHandler);

      //  Now. let's make a change.
      firstParticipant.Element("FirstName").Value = "Seph";

      Console.WriteLine("{0}{1}", xDocument, System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing7_87()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement firstParticipant;

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants", firstParticipant =
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("{0}{1}", xDocument, System.Environment.NewLine);

      //  First I must register for the event.
      firstParticipant.Changing += new EventHandler<XObjectChangeEventArgs>(
        (sender, cea) =>
          Console.WriteLine("Type of object changing: {0}, Type of change: {1}",
            sender.GetType().Name, cea.ObjectChange));

      firstParticipant.Changed += new EventHandler<XObjectChangeEventArgs>(
        (sender, cea) =>
          Console.WriteLine("Type of object changed: {0}, Type of change: {1}",
            sender.GetType().Name, cea.ObjectChange));

      xDocument.Changed += new EventHandler<XObjectChangeEventArgs>(
        (sender, cea) =>
          Console.WriteLine("Doc: Type of object changed: {0}, Type of change: {1}{2}",
            sender.GetType().Name, cea.ObjectChange, System.Environment.NewLine));

      //  Now. let's make a change.
      firstParticipant.Element("FirstName").Value = "Seph";

      Console.WriteLine("{0}{1}", xDocument, System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    //  Used by Listing 7_86.
    public static void MyChangingEventHandler(object sender, XObjectChangeEventArgs cea)
    {
      Console.WriteLine("Type of object changing: {0}, Type of change: {1}",
        sender.GetType().Name, cea.ObjectChange);
    }

    //  Used by Listing 7_86.
    public static void MyChangedEventHandler(object sender, XObjectChangeEventArgs cea)
    {
      Console.WriteLine("Type of object changed: {0}, Type of change: {1}",
        sender.GetType().Name, cea.ObjectChange);
    }

    //  Used by Listing 7_86.
    public static void DocumentChangedHandler(object sender, XObjectChangeEventArgs cea)
    {
      Console.WriteLine("Doc: Type of object changed: {0}, Type of change: {1}{2}",
        sender.GetType().Name, cea.ObjectChange, System.Environment.NewLine);
    }
  }

  //  Used by Listing7_16.
  enum ParticipantTypes
  {
    Author = 0,
    Editor
  }

  //  Used by Listing7_16.
  class BookParticipant
  {
    public string FirstName;
    public string LastName;
    public ParticipantTypes ParticipantType;
  }

  //  Used by Listing7_85.
  public class AuthorHandler
  {
    public void Display(XElement element)
    {
      Console.WriteLine("AUTHOR BIO");
      Console.WriteLine("--------------------------");
      Console.WriteLine("Name:        {0} {1}",
        (string)element.Element("FirstName"),
        (string)element.Element("LastName"));
      Console.WriteLine("Language:    {0}", (string)element.Attribute("language"));
      Console.WriteLine("Experience:  {0}", (string)element.Attribute("experience"));
      Console.WriteLine("==========================" + System.Environment.NewLine);
    }
  }

  //  Used by Listing7_85.
  public class EditorHandler
  {
    public void Display(XElement element)
    {
      Console.WriteLine("EDITOR BIO");
      Console.WriteLine("--------------------------");
      Console.WriteLine("Name:        {0}", (string)element.Element("FirstName"));
      Console.WriteLine("             {0}", (string)element.Element("LastName"));
      Console.WriteLine("==========================" + System.Environment.NewLine);
    }
  }
}
