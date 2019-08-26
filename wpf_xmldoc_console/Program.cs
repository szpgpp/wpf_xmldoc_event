using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace wpf_xmldoc_console
{
    class Program
    {
        static XmlDocument XmlDoc;
        static void Main(string[] args)
        {
            XmlDoc = new XmlDocument();

            XmlDoc.NodeChanged += (sender, e) => { W("NodeChanged",e); };
            XmlDoc.NodeChanging += (sender, e) => { W("NodeChanging",e); };
            XmlDoc.NodeInserted += (sender, e) => { W("NodeInserted",e); };
            XmlDoc.NodeInserting += (sender, e) => { W("NodeInserting",e ); };
            XmlDoc.NodeRemoved += (sender, e) => { W("NodeRemoved",e); };
            XmlDoc.NodeRemoving += (sender, e) => { W("NodeRemoving",e); };
            Console.WriteLine("--Add Node Root--");
            var root = XmlDoc.AppendChild(XmlDoc.CreateElement("Root")) as XmlElement;
            Console.WriteLine();
            //var school = XmlDoc.DocumentElement.AppendChild(XmlDoc.CreateElement("Schooll")) as XmlElement;
            //var student = school.AppendChild(XmlDoc.CreateElement("School2")) as XmlElement;

            Console.WriteLine("--SetAttribute School_Name--");
            root.SetAttribute("school_name","haidian");
            //root.SetAttribute("school_name", "haidian1");
            Console.WriteLine();

            Console.WriteLine("--SetAttribute School_Name--");
            root.SetAttribute("school_name", "haidian1");
            Console.WriteLine();


            Console.WriteLine("--RemoveAttribute School_Name--");
            root.RemoveAttribute("school_name");
            Console.WriteLine();

            Console.WriteLine("--RemoveNode Root--");
            root.ParentNode.RemoveChild(root);
            Console.WriteLine();

            XmlDoc = null;

            Console.ReadKey();
        }
        static void W(String action, XmlNodeChangedEventArgs e)
        {
            //action = Convert.ToString(e.Action);
            var msg = String.Format("{0}/{1}/{2}->{3}/{4}/{5}"
                , e.OldParent?.Name, e.Node.Name, e.OldValue
                , e.NewParent?.Name, e.Node.Name, e.NewValue);
            Console.WriteLine(action +"  "+ msg);
        }
    }
}
