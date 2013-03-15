using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParser.Class
{
    public class Programmer
    {

        public void UpdateOldKudusFromCurrent()
        {
            oldKudus = currentKudus;
        }

        public static double DampeningValue = 0.85;

        public Programmer()
        {
            Recommendations = new List<int>();
            RecommendedBy = new List<int>();
        }

        private double _currentKudus = 0;

        public double currentKudus
        {
            get { return _currentKudus; }
            set
            {
                //if (oldKudus != currentKudus) oldKudus = currentKudus;
                _currentKudus = value;
            }
        }
        public double oldKudus { get; set; }

        public string name { get; set; }
        public List<string> links { get; set; }

        public List<int> Recommendations { get; set; }
        public List<int> RecommendedBy { get; set; } 
        public List<string> skills { get; set; }

        public override string ToString()
        {
            return name + " " + currentKudus + " " + oldKudus;

        }

        public void GetKudos(List<Programmer> lst )
        {
            double kudos = 0;
            //Add all incoming links 
            foreach (var index in RecommendedBy)
            {
                var p = lst.ElementAt(index);
                kudos += (double)p.oldKudus/p.Recommendations.Count;
                System.Diagnostics.Debug.WriteLine("{0} har kudus: {1} og antall {2}",p.name,p.oldKudus,p.Recommendations.Count);
            }
            kudos = (1 - Programmer.DampeningValue) + Programmer.DampeningValue*kudos;
            currentKudus = kudos;
        }

        public bool Delta()
        {
            System.Diagnostics.Debug.WriteLine(currentKudus.ToString("f2") == oldKudus.ToString("f2"));
            return currentKudus.ToString("f2") == oldKudus.ToString("f2");
        }
    }
}
