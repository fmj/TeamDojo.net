using System;
using System.Collections.Generic;
using System.IO;
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
            //Print();
            //First run
            do
            {
                prog.ForEach(p => p.UpdateOldKudusFromCurrent());
                prog.ForEach(p => p.GetKudos(prog));
            } while (prog.Count(m => !m.Delta()) > 0);


            Console.WriteLine("Result");
            //Print();

            var list = prog.OrderByDescending(m => m.currentKudus).ToList();
            foreach(var p in list)
                Console.WriteLine(p.name + "\t" + p.currentKudus);

            Console.WriteLine("Yes for write");
            string input = Console.ReadLine();
            StringBuilder fullFile = new StringBuilder();
            if (input != null && input.Length > 0)
            {
                if (input == "XML")
                {
                    fullFile.Append(
                        "<?xml version=\"1.0\" encoding=\"utf-8\" ?><?xml-stylesheet type=\"text/xsl\" href=\"xslt/Display.xslt\"?><Network>");
                    foreach (var p in prog)
                        fullFile.Append(p.GetXMlRepr(prog));
                    fullFile.Append("</Network>");

                    using (
                        StreamWriter sw =
                            new StreamWriter(
                                File.OpenWrite(
                                    Path.Combine(new FileInfo(@"C:\Projects\TeamDojo\src\ProNet.xml").DirectoryName,
                                                 "ProNet" + System.Guid.NewGuid() + ".xml"))))
                    {
                        sw.Write(fullFile.ToString());
                        sw.Close();
                    }
                }
                else if(input == "RB")
                {
                    StringBuilder dict = new StringBuilder();
                    foreach (var p in prog)
                        dict.Append(p.GetRubyList());
                    fullFile.Append("programmers_kudos = {" + dict.ToString().Substring(0, dict.ToString().Length - 1) +
                                    "}");

                    using (
                       StreamWriter sw =
                           new StreamWriter(
                               File.OpenWrite(
                                   Path.Combine(new FileInfo(@"C:\Projects\TeamDojo\src\ProNet.xml").DirectoryName,
                                                "ProNet" + System.Guid.NewGuid() + ".rb"))))
                    {
                        sw.Write(fullFile.ToString());
                        sw.Close();
                    }
                }
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
