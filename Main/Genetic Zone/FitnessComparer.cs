using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Genetic_Zone
{
    public class FitnessComparer : Comparer<Chromosome>
    {
        public override int Compare(Chromosome y, Chromosome x)
        {
            return x.Fitness.CompareTo(y.Fitness);
        }
    }
}
 