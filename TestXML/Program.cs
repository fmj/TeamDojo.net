using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = XmlParser.Util.GetProgrammersFromXmlFile(@"C:\Projects\TeamDojo\src\ProNet.xml");
            foreach(var p in prog)
                Console.Write(p.ToString());

            Console.ReadLine();
        }
    }
}
