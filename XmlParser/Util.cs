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

                                      //.Aggregate((current, result) => current + "," + result));
                                  };

            List<Programmer> retval = new List<Programmer>();
            foreach (var p in programmers)
            {
                Programmer ret = ((Programmer) p);
                foreach (string linkName in ret.links)
                {
                    ret.Recommendations.Add(programmers.Where(m=> m.name == linkName).First());
                }
                retval.Add(ret);
            }

            for (int i = 0; i < retval.Count(); i++)
            {
                retval.ElementAt(i).RecommendedBy.AddRange(retval.Where(m=> m.links.Contains(retval.ElementAt(i).name)));

            }


                return retval;
        }
    }
}
