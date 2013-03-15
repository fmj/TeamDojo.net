using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParser.Class
{
    public class Programmer
    {
        public static double DampeningValue = 0.85;

        public Programmer()
        {
            Recommendations = new List<Programmer>();
            RecommendedBy = new List<Programmer>();
        }

        private int _currentKudus = 0;

        public int currentKudus
        {
            get { return _currentKudus; }
            set
            {
                if (oldKudus != currentKudus) oldKudus = currentKudus;
                _currentKudus = value;
            }
        }
        public int oldKudus { get; set; }

        public string name { get; set; }
        public List<string> links { get; set; }

        public List<Programmer> Recommendations { get; set; }
        public List<Programmer> RecommendedBy { get; set; } 
        public List<string> skills { get; set; }

        public override string ToString()
        {
            //return name + "(links : " + links.Count + " " + Recommendations.Count +  ")" + " " + RecommendedBy.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + name + Environment.NewLine);
            foreach (var r in Recommendations)
                sb.Append("Recommends: " + r.name + Environment.NewLine);
            foreach (var req in RecommendedBy)
                sb.Append("Recommended by: " + req.name + Environment.NewLine);
            return sb.ToString();

        }

        public double GetKudos(int dampening)
        {
            return 0.0;
        }
    }
}
