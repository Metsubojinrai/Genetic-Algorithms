using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Genetic_Zone
{
    public class Chromosome : List<string>
    {
        private Fitness calcFit = null;
        private Mutate mutateMethod = null;
        private double m_dFitness = 0;

        public Chromosome()
        {
        }

        public Chromosome(Fitness fit, Mutate mut)
        {
            calcFit = fit;
            mutateMethod = mut;
            calcFit(this);
        }

        public Chromosome(Initializer initializer, Fitness fit, Mutate mut)
        {
            calcFit = fit;
            mutateMethod = mut;
            initializer(this);
            calcFit(this);
        }
        ~Chromosome()
        {
            Clear();
        }

        //Them Gene
        public void AddGene(string str)
        {
            Add(str);
        }

        // copy nhiem sac the
        public void Copy_NhiemSacThe(Chromosome newNST)
        {
            int iLength = GeneLength;
            Clear();
            for (int i = 0; i < iLength; i++)
            {
                this.AddGene(newNST[i]);
            }
        }
        //----------------------------
        // Tim vi tri cua Gene
        // Neu tim thay no se tra ve vi tri tim thay
        // Khong tim thay tra lai -1
        //------------------------------
        public int HasThisGene(string Gene)
        {
            return this.FindIndex(s => s == Gene);
        }
    
        public double Fitness
        {
            set { m_dFitness = value; }
            get { return m_dFitness; }
        }
        public int GeneLength
        {
            get { return this.Count; }
        }
        public override string ToString()
        {
            System.Text.StringBuilder st = new System.Text.StringBuilder(this.GeneLength * 3);
            for (int i = 0; i < this.GeneLength; i++)
                st.Append(this[i] + ",");
            st.Length = st.Length - 1;
            return st.ToString();
        }
    }
}
