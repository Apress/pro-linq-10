using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace LINQChapter9
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing9_1();
      //Listing9_2();
      //Listing9_3();
      //Listing9_4();
      //Listing9_5();
      //Listing9_6();
      //Listing9_7();
      //Listing9_8();
      //Listing9_9();
      //Listing9_10();
      //Listing9_11();
      //Listing9_12();
      //Listing9_13();
      //Listing9_14();
      //Listing9_15();
      //Listing9_16();
      //Listing9_17();
      //Listing9_18();
      //Listing9_19();
      //Listing9_20();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_1()
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

      IEnumerable<XElement> elements = xDocument.Descendants("BookParticipant");

      foreach (XElement element in elements)
      {
        Console.WriteLine("Element: {0} : value = {1}",
          element.Name, element.Value);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_2()
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

      IEnumerable<XElement> elements = xDocument
        .Descendants("BookParticipant")
        .Where(e => ((string)e.Element("FirstName")) == "Ewan");

      foreach (XElement element in elements)
      {
        Console.WriteLine("Element: {0} : value = {1}",
          element.Name, element.Value);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_3()
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
        from e in xDocument.Descendants("BookParticipant")
        where ((string)e.Attribute("type")) != "Illustrator"
        orderby ((string)e.Element("LastName"))
        select e;

      foreach (XElement element in elements)
      {
        Console.WriteLine("Element: {0} : value = {1}",
          element.Name, element.Value);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument users = XDocument.Parse(
        @"<users>
            <user_tuple>
              <userid>U01</userid>
              <name>Tom Jones</name>
              <rating>B</rating>
            </user_tuple>
            <user_tuple>
              <userid>U02</userid>
              <name>Mary Doe</name>
              <rating>A</rating>
            </user_tuple>
            <user_tuple>
              <userid>U03</userid>
              <name>Dee Linquent</name>
              <rating>D</rating>
            </user_tuple>
            <user_tuple>
              <userid>U04</userid>
              <name>Roger Smith</name>
              <rating>C</rating>
            </user_tuple>
            <user_tuple>
              <userid>U05</userid>
              <name>Jack Sprat</name>
              <rating>B</rating>
            </user_tuple>
            <user_tuple>
              <userid>U06</userid>
              <name>Rip Van Winkle</name>
              <rating>B</rating>
            </user_tuple>
          </users>");

      XDocument items = XDocument.Parse(
        @"<items>
            <item_tuple>
              <itemno>1001</itemno>
              <description>Red Bicycle</description>
              <offered_by>U01</offered_by>
              <start_date>1999-01-05</start_date>
              <end_date>1999-01-20</end_date>
              <reserve_price>40</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1002</itemno>
              <description>Motorcycle</description>
              <offered_by>U02</offered_by>
              <start_date>1999-02-11</start_date>
              <end_date>1999-03-15</end_date>
              <reserve_price>500</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1003</itemno>
              <description>Old Bicycle</description>
              <offered_by>U02</offered_by>
              <start_date>1999-01-10</start_date>
              <end_date>1999-02-20</end_date>
              <reserve_price>25</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1004</itemno>
              <description>Tricycle</description>
              <offered_by>U01</offered_by>
              <start_date>1999-02-25</start_date>
              <end_date>1999-03-08</end_date>
              <reserve_price>15</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1005</itemno>
              <description>Tennis Racket</description>
              <offered_by>U03</offered_by>
              <start_date>1999-03-19</start_date>
              <end_date>1999-04-30</end_date>
              <reserve_price>20</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1006</itemno>
              <description>Helicopter</description>
              <offered_by>U03</offered_by>
              <start_date>1999-05-05</start_date>
              <end_date>1999-05-25</end_date>
              <reserve_price>50000</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1007</itemno>
              <description>Racing Bicycle</description>
              <offered_by>U04</offered_by>
              <start_date>1999-01-20</start_date>
              <end_date>1999-02-20</end_date>
              <reserve_price>200</reserve_price>
            </item_tuple>
            <item_tuple>
              <itemno>1008</itemno>
              <description>Broken Bicycle</description>
              <offered_by>U01</offered_by>
              <start_date>1999-02-05</start_date>
              <end_date>1999-03-06</end_date>
              <reserve_price>25</reserve_price>
            </item_tuple>
          </items>");

      XDocument bids = XDocument.Parse(
        @"<bids>
            <bid_tuple>
              <userid>U02</userid>
              <itemno>1001</itemno>
              <bid>35</bid>
              <bid_date>1999-01-07</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U04</userid>
              <itemno>1001</itemno>
              <bid>40</bid>
              <bid_date>1999-01-08</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U02</userid>
              <itemno>1001</itemno>
              <bid>45</bid>
              <bid_date>1999-01-11</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U04</userid>
              <itemno>1001</itemno>
              <bid>50</bid>
              <bid_date>1999-01-13</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U02</userid>
              <itemno>1001</itemno>
              <bid>55</bid>
              <bid_date>1999-01-15</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U01</userid>
              <itemno>1002</itemno>
              <bid>400</bid>
              <bid_date>1999-02-14</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U02</userid>
              <itemno>1002</itemno>
              <bid>600</bid>
              <bid_date>1999-02-16</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U03</userid>
              <itemno>1002</itemno>
              <bid>800</bid>
              <bid_date>1999-02-17</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U04</userid>
              <itemno>1002</itemno>
              <bid>1000</bid>
              <bid_date>1999-02-25</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U02</userid>
              <itemno>1002</itemno>
              <bid>1200</bid>
              <bid_date>1999-03-02</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U04</userid>
              <itemno>1003</itemno>
              <bid>15</bid>
              <bid_date>1999-01-22</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U05</userid>
              <itemno>1003</itemno>
              <bid>20</bid>
              <bid_date>1999-02-03</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U01</userid>
              <itemno>1004</itemno>
              <bid>40</bid>
              <bid_date>1999-03-05</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U03</userid>
              <itemno>1007</itemno>
              <bid>175</bid>
              <bid_date>1999-01-25</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U05</userid>
              <itemno>1007</itemno>
              <bid>200</bid>
              <bid_date>1999-02-08</bid_date>
            </bid_tuple>
            <bid_tuple>
              <userid>U04</userid>
              <itemno>1007</itemno>
              <bid>225</bid>
              <bid_date>1999-02-12</bid_date>
            </bid_tuple>
          </bids>");

      var biddata = from b in bids.Descendants("bid_tuple")
                    where ((double)b.Element("bid")) > 50
                    join u in users.Descendants("user_tuple")
                    on ((string)b.Element("userid")) equals
                      ((string)u.Element("userid"))
                    join i in items.Descendants("item_tuple")
                    on ((string)b.Element("itemno")) equals
                      ((string)i.Element("itemno"))
                    select new
                    {
                      Item = ((string)b.Element("itemno")),
                      Description = ((string)i.Element("description")),
                      User = ((string)u.Element("name")),
                      Date = ((string)b.Element("bid_date")),
                      Price = ((double)b.Element("bid"))
                    };

      Console.WriteLine("{0,-12} {1,-12} {2,-6} {3,-14} {4,10}",
        "Date",
        "User",
        "Item",
        "Description",
        "Price");

      Console.WriteLine("==========================================================");

      foreach (var bd in biddata)
      {
        Console.WriteLine("{0,-12} {1,-12} {2,-6} {3,-14} {4,10:C}",
          bd.Date,
          bd.User,
          bd.Item,
          bd.Description,
          bd.Price);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string xsl =
        @"<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
          <xsl:template match='//BookParticipants'>
              <html>
                  <body>
                  <h1>Book Participants</h1>
                  <table>
                      <tr align='left'>
                          <th>Role</th>
                          <th>First Name</th>
                          <th>Last Name</th>
                      </tr>
                      <xsl:apply-templates></xsl:apply-templates>
                  </table>
                  </body>
              </html>
          </xsl:template>
          <xsl:template match='BookParticipant'>
              <tr>
                  <td><xsl:value-of select='@type'/></td>
                  <td><xsl:value-of select='FirstName'/></td>
                  <td><xsl:value-of select='LastName'/></td>
              </tr>
          </xsl:template>
        </xsl:stylesheet>";

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

      XDocument transformedDoc = new XDocument();
      using (XmlWriter writer = transformedDoc.CreateWriter())
      {
        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(XmlReader.Create(new StringReader(xsl)));
        transform.Transform(xDocument.CreateReader(), writer);
      }
      Console.WriteLine(transformedDoc);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_6()
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

      Console.WriteLine("Here is the original XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XDocument xTransDocument = new XDocument(
        new XElement("MediaParticipants",
          new XAttribute("type", "book"),
            xDocument.Element("BookParticipants")
              .Elements("BookParticipant")
              .Select(e => new XElement("Participant",
                new XAttribute("Role", (string)e.Attribute("type")),
                new XAttribute("Name", (string)e.Element("FirstName") + " " +
                  (string)e.Element("LastName"))))));

      Console.WriteLine("Here is the transformed XML document:");
      Console.WriteLine(xTransDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement xElement = new XElement("RootElement", Helper());
      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<XElement> elements =
        new XElement[] {
          new XElement("Element", "A"),
          new XElement("Element", "B")};

      XElement xElement = new XElement("RootElement",
        elements.Select(e => (string)e != "A" ? new XElement(e.Name, (string)e) : null));

      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<XElement> elements =
        new XElement[] {
          new XElement("BookParticipant", 
            new XElement("Name", "Joe Rattz"),
            new XElement("Book", "Pro LINQ: Language Integrated Query in C# 2008")),
          new XElement("BookParticipant", 
            new XElement("Name", "John Q. Public"))};

      XElement xElement =
        new XElement("BookParticipants",
          elements.Select(e =>
            new XElement(e.Name,
              new XElement(e.Element("Name").Name, e.Element("Name").Value),
              new XElement("Books", e.Elements("Book")))));

      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<XElement> elements =
        new XElement[] {
          new XElement("BookParticipant", 
            new XElement("Name", "Joe Rattz"),
            new XElement("Book", "Pro LINQ: Language Integrated Query in C# 2008")),
          new XElement("BookParticipant", 
            new XElement("Name", "John Q. Public"))};

      XElement xElement =
        new XElement("BookParticipants",
          elements.Select(e =>
            new XElement(e.Name,
              new XElement(e.Element("Name").Name, e.Element("Name").Value),
              e.Elements("Book").Any() ?
                new XElement("Books", e.Elements("Book")) : null)));

      Console.WriteLine(xElement);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz"),
            new XElement("Nickname", "Joey"),
            new XElement("Nickname", "Null Pointer")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("Here is the original XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XDocument xTransDocument = new XDocument(
        new XElement("BookParticipants",
          xDocument.Element("BookParticipants")
            .Elements("BookParticipant")
            .Select(e => new object[] {
              new XComment(" BookParticipant "),
              new XElement("FirstName", (string)e.Element("FirstName")),
              new XElement("LastName", (string)e.Element("LastName")),
              e.Elements("Nickname")})));

      Console.WriteLine("Here is the transformed XML document:");
      Console.WriteLine(xTransDocument);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_12()
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

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      xDocument.Save("bookparticipants.xml");

      XmlSchemaInference infer = new XmlSchemaInference();
      XmlSchemaSet schemaSet =
        infer.InferSchema(new XmlTextReader("bookparticipants.xml"));

      XmlWriter w = XmlWriter.Create("bookparticipants.xsd");
      foreach (XmlSchema schema in schemaSet.Schemas())
      {
        schema.Write(w);
      }
      w.Close();

      XDocument newDocument = XDocument.Load("bookparticipants.xsd");
      Console.WriteLine("Here is the schema:");
      Console.WriteLine("{0}{1}{1}", newDocument, System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("MiddleInitial", "C"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add(null, "bookparticipants.xsd");

      try
      {
        xDocument.Validate(schemaSet, null);
        Console.WriteLine("Document validated successfully.");
      }
      catch (XmlSchemaValidationException ex)
      {
        Console.WriteLine("Exception occurred: {0}", ex.Message);
        Console.WriteLine("Document validated unsuccessfully.");
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_14()
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

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add(null, "bookparticipants.xsd");

      try
      {
        xDocument.Validate(schemaSet, MyValidationEventHandler);
        Console.WriteLine("Document validated successfully.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception occurred: {0}", ex.Message);
        Console.WriteLine("Document validated unsuccessfully.");
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add(null, "bookparticipants.xsd");

      try
      {
        xDocument.Validate(schemaSet, MyValidationEventHandler);
        Console.WriteLine("Document validated successfully.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception occurred: {0}", ex.Message);
        Console.WriteLine("Document validated unsuccessfully.");
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XAttribute("language", "English"),
            new XElement("FirstName", "Joe"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add(null, "bookparticipants.xsd");

      try
      {
        xDocument.Validate(schemaSet, (o, vea) =>
        {
          Console.WriteLine(
            "A validation error occurred processing object type {0}.",
            o.GetType().Name);

          Console.WriteLine(vea.Message);

          throw (new Exception(vea.Message));
        });

        Console.WriteLine("Document validated successfully.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception occurred: {0}", ex.Message);
        Console.WriteLine("Document validated unsuccessfully.");
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XDocument xDocument = new XDocument(
        new XElement("BookParticipants",
          new XElement("BookParticipant",
            new XAttribute("type", "Author"),
            new XElement("FirstName", "Joe"),
            new XElement("MiddleName", "Carson"),
            new XElement("LastName", "Rattz")),
          new XElement("BookParticipant",
            new XAttribute("type", "Editor"),
            new XElement("FirstName", "Ewan"),
            new XElement("LastName", "Buckingham"))));

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add(null, "bookparticipants.xsd");

      xDocument.Validate(schemaSet, (o, vea) =>
        {
          Console.WriteLine("An exception occurred processing object type {0}.",
            o.GetType().Name);

          Console.WriteLine("{0}{1}", vea.Message, System.Environment.NewLine);
        }, 
        true);

      foreach (XElement element in xDocument.Descendants())
      {
        Console.WriteLine("Element {0} is {1}", element.Name,
          element.GetSchemaInfo().Validity);

        XmlSchemaElement se = element.GetSchemaInfo().SchemaElement;
        if (se != null)
        {
          Console.WriteLine(
            "Schema element {0} must have MinOccurs = {1} and MaxOccurs = {2}{3}",
            se.Name, se.MinOccurs, se.MaxOccurs, System.Environment.NewLine);
        }
        else
        {
          //  Invalid elements will not have a SchemaElement.
          Console.WriteLine();
        }
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string schema =
        @"<?xml version='1.0' encoding='utf-8'?>
          <xs:schema attributeFormDefault='unqualified' elementFormDefault='qualified'
            xmlns:xs='http://www.w3.org/2001/XMLSchema'>
            <xs:element name='BookParticipants'>
              <xs:complexType>
                <xs:sequence>
                  <xs:element maxOccurs='unbounded' name='BookParticipant'>
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element name='FirstName' type='xs:string' />
                        <xs:element minOccurs='0' name='MiddleInitial'
                          type='xs:string' />
                        <xs:element name='LastName' type='xs:string' />
                      </xs:sequence>
                      <xs:attribute name='type' type='xs:string' use='required' />
                    </xs:complexType>
                  </xs:element>
                </xs:sequence>
              </xs:complexType>
            </xs:element>
          </xs:schema>";

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add("", XmlReader.Create(new StringReader(schema)));

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

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      bool valid = true;
      xDocument.Validate(schemaSet, (o, vea) =>
      {
        Console.WriteLine("An exception occurred processing object type {0}.",
          o.GetType().Name);

        Console.WriteLine(vea.Message);

        valid = false;
      }, true);

      Console.WriteLine("Document validated {0}.{1}",
        valid ? "successfully" : "unsuccessfully",
        System.Environment.NewLine);

      XElement bookParticipant = xDocument.Descendants("BookParticipant").
        Where(e => ((string)e.Element("FirstName")).Equals("Joe")).First();

      bookParticipant.Element("FirstName").
        AddAfterSelf(new XElement("MiddleInitial", "C"));

      valid = true;
      bookParticipant.Validate(bookParticipant.GetSchemaInfo().SchemaElement, schemaSet,
        (o, vea) =>
        {
          Console.WriteLine("An exception occurred processing object type {0}.",
            o.GetType().Name);

          Console.WriteLine(vea.Message);

          valid = false;
        }, true);

      Console.WriteLine("Element validated {0}.{1}",
        valid ? "successfully" : "unsuccessfully",
        System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string schema =
        @"<?xml version='1.0' encoding='utf-8'?>
          <xs:schema attributeFormDefault='unqualified' elementFormDefault='qualified' xmlns:xs='http://www.w3.org/2001/XMLSchema'>
            <xs:element name='BookParticipants'>
              <xs:complexType>
                <xs:sequence>
                  <xs:element maxOccurs='unbounded' name='BookParticipant'>
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element name='FirstName' type='xs:string' />
                        <xs:element minOccurs='0' name='MiddleInitial' type='xs:string' />
                        <xs:element name='LastName' type='xs:string' />
                      </xs:sequence>
                      <xs:attribute name='type' type='xs:string' use='required' />
                    </xs:complexType>
                  </xs:element>
                </xs:sequence>
              </xs:complexType>
            </xs:element>
          </xs:schema>";

      XmlSchemaSet schemaSet = new XmlSchemaSet();
      schemaSet.Add("", XmlReader.Create(new StringReader(schema)));

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

      Console.WriteLine("Here is the source XML document:");
      Console.WriteLine("{0}{1}{1}", xDocument, System.Environment.NewLine);

      bool valid = true;
      xDocument.Validate(schemaSet, (o, vea) =>
      {
        Console.WriteLine("An exception occurred processing object type {0}.",
          o.GetType().Name);

        Console.WriteLine(vea.Message);

        valid = false;
      }, true);

      Console.WriteLine("Document validated {0}.{1}",
        valid ? "successfully" : "unsuccessfully",
        System.Environment.NewLine);

      XElement bookParticipant = xDocument.Descendants("BookParticipant").
        Where(e => ((string)e.Element("FirstName")).Equals("Joe")).First();

      bookParticipant.Element("FirstName").
        AddAfterSelf(new XElement("MiddleName", "Carson"));

      valid = true;
      bookParticipant.Validate(bookParticipant.GetSchemaInfo().SchemaElement, schemaSet,
        (o, vea) =>
        {
          Console.WriteLine("An exception occurred processing object type {0}.",
            o.GetType().Name);

          Console.WriteLine(vea.Message);

          valid = false;
        }, true);

      Console.WriteLine("Element validated {0}.{1}",
        valid ? "successfully" : "unsuccessfully",
        System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing9_20()
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

      XElement bookParticipant = xDocument.XPathSelectElement(
        "//BookParticipants/BookParticipant[FirstName='Joe']");

      Console.WriteLine(bookParticipant);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    //  Used in Listing 9_7.
    static IEnumerable<XElement> Helper()
    {
      //  This code could do anything it needs to create a sequence of elements.
      //  For this example, I will just dynamically create an array using the new
      //  C# 3.0 collection initialization features.
      XElement[] elements = new XElement[] {
        new XElement("Element", "A"),
        new XElement("Element", "B")};

      return (elements);
    }

    //  Used in Listing 9_14 and 9_15.
    static void MyValidationEventHandler(object o, ValidationEventArgs vea)
    {

      Console.WriteLine("A validation error occurred processing object type {0}.",
        o.GetType().Name);

      Console.WriteLine(vea.Message);

      throw (new Exception(vea.Message));
    }
  }
}
