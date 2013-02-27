using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;
using System.Xml;
using System.IO;
using APICaller.Annotation;
using System.Xml.Serialization;
using System.Reflection;

namespace APICaller.Serializer
{
    public class CBAPISerializer : ISerializer
    {
        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        private List<Node> _CustomNodes { get; set; }
        private bool _NeedWriteCustomNode { get; set; }

        public string Serialize(object obj)
        {
            if (obj.GetType().GetCustomAttributes(typeof(CBHasCustomValuesAttribute), true).Length > 0)
                _NeedWriteCustomNode = true;

            Node root = ConvertObjectToNode(obj);
            return Serialize(root);
        }

        private String Serialize(Node root)
        {
            String str = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlTextWriter xw = new XmlTextWriter(stream, Encoding.UTF8);
                xw.WriteStartDocument();
                WriteRootObject(xw, root);
                xw.Flush();
                stream.Position = 0;
                using (StreamReader sr = new StreamReader(stream))
                {
                    str = sr.ReadToEnd();
                }
            }
            return str;
        }

        private void WriteRootObject(XmlTextWriter xw, Node n)
        {
            xw.WriteStartElement(n.Name);
            if (n.Children == null)
                xw.WriteString(n.Value);
            else
                n.Children.ForEach(t => WriteObject(xw, t));
            if (_NeedWriteCustomNode)
                WriteCustomObjects(xw, _CustomNodes);
            xw.WriteEndElement();
        }

        private void WriteObject(XmlTextWriter xw, Node n)
        {
            xw.WriteStartElement(n.Name);
            if (n.Children == null)
                xw.WriteString(n.Value);
            else
                n.Children.ForEach(t => WriteObject(xw, t));

            xw.WriteEndElement();
        }

        private void WriteCustomObjects(XmlTextWriter xw, List<Node> nodes)
        {
            xw.WriteStartElement("CustomValues");
            nodes.ForEach(t =>
            {
                xw.WriteStartElement("CustomValue");
                xw.WriteElementString("Key", t.Name);
                xw.WriteElementString("Value", t.Value);
                xw.WriteEndElement();
            });
            xw.WriteEndElement();
        }

        private Node ConvertObjectToNode(object obj)
        {
            return ConvertObjectToNode(obj, string.Empty);
        }

        private Node ConvertObjectToNode(object obj, string typeName)
        {
            if (String.IsNullOrEmpty(typeName))
            {
                if (obj.GetType().GetCustomAttributes(typeof(XmlRootAttribute), true).Length > 0)
                    typeName = (obj.GetType().GetCustomAttributes(typeof(XmlRootAttribute), true)[0] as XmlRootAttribute).ElementName;
                else
                    typeName = obj.GetType().Name;
            }

            if (obj is string)
            {
                return new Node() { Name = typeName, Value = obj as string };
            }
            else if (obj is int)
            {
                return new Node() { Name = typeName, Value = XmlConvert.ToString((int)obj) };
            }
            else if (obj is bool)
            {
                return new Node() { Name = typeName, Value = XmlConvert.ToString((bool)obj) };
            }
            else if (obj is IEnumerable<object>)
            {
                Node n = new Node() { Name = typeName, Value = string.Empty, Children = new List<Node>() };
                foreach (var o in obj as IEnumerable<object>)
                {
                    n.Children.Add(ConvertObjectToNode(o));
                }
                return n;
            }
            else if (obj is ICollection<object>)
            {
                Node n = new Node() { Name = typeName, Value = string.Empty, Children = new List<Node>() };
                foreach (var o in obj as IEnumerable<object>)
                {
                    n.Children.Add(ConvertObjectToNode(o));
                }
                return n;
            }
            Node n1 = new Node() { Name = typeName, Children = new List<Node>(), Value = string.Empty };
            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                string Name = info.Name;
                if (info.GetValue(obj, null) != null)
                {
                    n1.Children.Add(ConvertObjectToNode(info.GetValue(obj, null), Name));
                }
            }
            return n1;
        }

        class Node
        {
            public List<Node> Children { get; set; }
            public String Name { get; set; }
            public String Value { get; set; }
        }
    }
}
