using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;
using System.Xml;

namespace LINQChapter6
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing6_1();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing6_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I just want to build some XML of book participants, 
      //  query the authors, and output their first and 
      //  last names.  Seems simple enough.

      //  I'll declare some variables I will reuse.
      XmlElement xmlBookParticipant;
      XmlAttribute xmlParticipantType;
      XmlElement xmlFirstName;
      XmlElement xmlLastName;

      //  First, I must build an XML document.
      XmlDocument xmlDoc = new XmlDocument();

      //  I'll create the root element and add it to the document.
      XmlElement xmlBookParticipants = xmlDoc.CreateElement("BookParticipants");
      xmlDoc.AppendChild(xmlBookParticipants);

      //  I'll create a participant and add it to the book participants list.
      xmlBookParticipant = xmlDoc.CreateElement("BookParticipant");

      xmlParticipantType = xmlDoc.CreateAttribute("type");
      xmlParticipantType.InnerText = "Author";
      xmlBookParticipant.Attributes.Append(xmlParticipantType);

      xmlFirstName = xmlDoc.CreateElement("FirstName");
      xmlFirstName.InnerText = "Joe";
      xmlBookParticipant.AppendChild(xmlFirstName);

      xmlLastName = xmlDoc.CreateElement("LastName");
      xmlLastName.InnerText = "Rattz";
      xmlBookParticipant.AppendChild(xmlLastName);

      xmlBookParticipants.AppendChild(xmlBookParticipant);

      //  I'll create another participant and add it to the book participants list.
      xmlBookParticipant = xmlDoc.CreateElement("BookParticipant");

      xmlParticipantType = xmlDoc.CreateAttribute("type");
      xmlParticipantType.InnerText = "Editor";
      xmlBookParticipant.Attributes.Append(xmlParticipantType);

      xmlFirstName = xmlDoc.CreateElement("FirstName");
      xmlFirstName.InnerText = "Ewan";
      xmlBookParticipant.AppendChild(xmlFirstName);

      xmlLastName = xmlDoc.CreateElement("LastName");
      xmlLastName.InnerText = "Buckingham";
      xmlBookParticipant.AppendChild(xmlLastName);

      xmlBookParticipants.AppendChild(xmlBookParticipant);

      //  Now, I'll search for authors and display their first and last name.
      XmlNodeList authorsList =
        xmlDoc.SelectNodes("BookParticipants/BookParticipant[@type=\"Author\"]");

      foreach (XmlNode node in authorsList)
      {
        XmlNode firstName = node.SelectSingleNode("FirstName");
        XmlNode lastName = node.SelectSingleNode("LastName");
        Console.WriteLine("{0} {1}", firstName, lastName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
