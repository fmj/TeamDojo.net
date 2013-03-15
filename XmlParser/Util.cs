using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlParser.Class;
using System.Xml;
using System.Xml.Linq;

namespace XmlParser
{
    public class Util
    {
        public static List<Programmer> GetProgrammersFromXmlFile(string inputfile)
        {
            System.Xml.Linq.XDocument doc = XDocument.Load(inputfile);
           

            var programmers = from item in doc.Descendants("Network").Descendants("Programmer")
                              select new Programmer()
                                  {
                                      name = item.Attribute("name").Value,
                                      skills = item.Descendants("Skills").Descendants("Skill").Select(m => m.Value).ToList(),
                                      links = item.Descendants("Recommendations").Descendants("Recommendation").Select(m => m.Value).ToList()
                                  };

            List<Programmer> retval = new List<Programmer>();
            foreach (var p in programmers)
            {
                retval.Add(p);
            }
            for (int i = 0; i < retval.Count; i++)
            {
                foreach(string s in retval[i].links)
                    retval.ElementAt(i).Recommendations.Add(i);
            }
       

            for (int i = 0; i < retval.Count(); i++)
            {
                foreach(var tmpProg in retval.Where(m => m.links.Contains(retval.ElementAt(i).name)))
                    retval.ElementAt(i).RecommendedBy.Add(retval.IndexOf(tmpProg));
            }
            return retval;
        }
    }
}
