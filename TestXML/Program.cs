using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlParser.Class;

namespace TestXML
{
    class Program
    {
        private static List<Programmer> prog;
        static void Main(string[] args)
        {
            prog = XmlParser.Util.GetProgrammersFromXmlFile(@"C:\Projects\TeamDojo\src\ProNet.xml");
            

            foreach (var p in prog)
            {
                p.currentKudus = 1;
                p.oldKudus = 1;
            }
            Print();
            //First run
            while(true)
            {
            prog.ForEach(p => p.GetKudos());
            Print();
            Console.ReadLine();
            }
        }

        static void Print()
        {
            foreach (var p in prog)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
