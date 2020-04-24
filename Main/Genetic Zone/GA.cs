using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Genetic_Zone
{
    // Các delegate đại diện cho các hàm đánh giá, hàm đột biến, hàm lai ghép và hàm khởi tạo trong quần thể
    // sử dụng các ủy nhiệm hàm tiện lợi khi cần thay đổi sang mô hình bài toán khác
        public delegate void Fitness(Chromosome ga_NST);
    public delegate void Mutate(Chromosome ga_NST);
    public delegate void CrossOver(Chromosome dad, Chromosome mum, ref Chromosome child1, ref Chromosome child2);
    public delegate void Initializer(Chromosome chromose);

    // Các kiểu lựa chọn NST bố mẹ đưa vào lai tạo
    public enum Selection { Roullette, Tournment };

    public class GA
    {
        // Cac tham so
        protected double m_dMutation = 0;
        protected long m_lGenerations = 0;
        protected double m_dCrossOver = 0;
        protected ushort m_usPopSize = 0;
        protected double tong_thichnghi = 0;
        protected ushort m_usGen = 0;

        protected bool m_bApplyElitism = true;
        protected Selection m_SelType = Selection.Roullette;

        protected List<Chromosome> thisGeneration = null;
        protected List<Chromosome> nextGeneration = new List<Chromosome>();
        protected System.Random m_Random = new Random();

        // biểu diễn NST dạng string
        protected System.Text.StringBuilder ChromosomesStr = new System.Text.StringBuilder();

        protected Fitness computeFitness = null;
        protected Mutate mutateProc = null;
        protected Initializer initChromo = null;
        protected CrossOver crossoverProc = null;

        // GA constructor

        public GA(Initializer init, Fitness fit, Mutate mutater, CrossOver crossOver)
        {
            computeFitness = fit;
            initChromo = init;
            crossoverProc = crossOver;
            mutateProc = mutater;
        }

        // GA destructor
        ~GA()
        {
            if (null != thisGeneration)
                thisGeneration.Clear();
        }
        //Ham khoi tao
        public void Initialize()
        {
            thisGeneration = new List<Chromosome>();
            for (int i = 0; i < PopulationSize; i++)
            {
                //tao nhung ca the moi
                Chromosome newParent = new Chromosome(initChromo, computeFitness, mutateProc);
                //them cac ca the vao trong quan the
                thisGeneration.Add(newParent);
            }
            //sap xep cac ca the theo do thich nghi 
            RankPopulation();
        }
        // Sap xep cac ca the theo su thich nghi cua chung
        private void RankPopulation()
        {
            tong_thichnghi = 0;
            for (int i = 0; i < PopulationSize; i++)
                // tong do thich nghi cua tat ca NST trong quan the
                tong_thichnghi += ((Chromosome)thisGeneration[i]).Fitness;
            // sap xep
            thisGeneration.Sort(new FitnessComparer());
        }

        //-------------------------
        // Sinh the he tiep theo
        // b1: Chon loc (Selection)
        // b2: Lai ghep (CrosssOver)
        // b3: Dot bien  (Mutation)
        // Tinh toan do thich nghi moi
        //----------------------------

        public void CreateNextGeneration()
        {
            nextGeneration.Clear();

            Chromosome bestChromo = null;       // nhiễm sắc thể có độ thích nghi tốt nhất

            if (this.ApplyElitism)
                //lay nhiem sac the tot
                bestChromo = thisGeneration[0];
            for (int i = 0; i < this.PopulationSize; i += 2)
            {
                // buoc 1: Chon loc  								
                int iDadParent = 0;
                int iMumParent = 0;
                //Chon loc dung banh xe quay Ru let
                //Roulette_Selection();

                switch (this.SelectionType)
                {
                    case Selection.Tournment:
                        iDadParent = Roulette_Selection();
                        iMumParent = Roulette_Selection();
                        break;
                    default:
                        iDadParent = TournamentSelection();
                        iMumParent = TournamentSelection();
                        break;
                }

                Chromosome dad = thisGeneration[iDadParent];
                Chromosome mum = thisGeneration[iMumParent];

                Chromosome child1 = new Chromosome(this.computeFitness, this.mutateProc);
                Chromosome child2 = new Chromosome(this.computeFitness, this.mutateProc);

                // Buoc 2  Lai ghep		
                // phat sinh mot so ngau nhien r trong (0,1)
                // neu r< pc thi dot bien.( pc: xac suat lai )
                //-----------
                //                 
                if (m_Random.NextDouble() < this.CrossOver)
                {
                    crossoverProc(dad, mum, ref child1, ref child2);
                }
                else
                {
                    child1 = dad;
                    child2 = mum;
                }
                //  Buoc 3 :Dot bien 
                // phat sinh mot so ngau nhien r trong (0,1)
                // neu r< pm thi dot bien.( pm: xac suat dot bien )
                //-----------
                if (m_Random.NextDouble() < this.Mutation)
                {
                    mutateProc(child1);
                    mutateProc(child2);
                }
                //Tinh toan ham thich nghi moi					
                this.computeFitness(child1);
                this.computeFitness(child2);

                //dua vao the he moi
                nextGeneration.Add(child1);
                nextGeneration.Add(child2);
            }
            if (null != bestChromo)
                //dua ca the tot nhat len dau
                nextGeneration.Insert(0, bestChromo);

            // Copy quần thể mới, sẽ là quần thể hiện tại trong vòng lặp tiếp theo
            thisGeneration = new List<Chromosome>(nextGeneration);

            // sap xep cac ca the trong quan the theo do thich nghi
            this.RankPopulation();
            this.GenerationNum++;
        }
        //----------------------------------
        // chon loc dung banh xe quay Ru let
        //-------------------------------------
        private int Roulette_Selection()
        {
            //Rs  chon do thich nghi ngau nhien trong khoang 0 den 1.0 * Tong do thich nghi											
            double randomFitness = m_Random.NextDouble() * tong_thichnghi;
            int idx = -1;
            int mid;
            int first = 0;
            int last = this.PopulationSize - 1;
            mid = (last - first) / 2;
            //Tim kiem nhi phan tren mang lay gia tri thich hop											
            while (idx == -1 && first <= last)
            {
                double fitness = ((Chromosome)this.thisGeneration[mid]).Fitness;
                if (randomFitness < fitness)
                {
                    last = mid;
                }
                else if (randomFitness > fitness)
                {
                    first = mid;
                }
                mid = (first + last) / 2;
                //  nam giua i va i+1
                if ((last - first) == 1)
                    idx = last;
            }
            return idx;
        }
        private int TournamentSelection()
        {
            int Count = 1;
            if (this.PopulationSize >= 50)
                Count = 8;
            else if (this.PopulationSize >= 30)
                Count = 6;
            else if (this.PopulationSize >= 20)
                Count = 4;
            else if (this.PopulationSize >= 10)
                Count = 3;
            else if (this.PopulationSize >= 2)
                Count = 2;
            int finalindex = 0;
            double dMaxFit = 0;
            for (int i = 0; i < Count; i++)
            {
                int selIndex = m_Random.Next(0, this.PopulationSize);
                double fitness = ((Chromosome)thisGeneration[selIndex]).Fitness;
                if (fitness > dMaxFit)
                {
                    finalindex = i;
                    dMaxFit = fitness;
                }
            }
            return finalindex;
        }

        // Dieu kien dung cua bai toan
        public bool IsStop()
        {
            return GenerationNum == Generations;
        }

        // Lay nhiem sac the tot nhat
        // nhiem sac the dau tien trong quan the
        public Chromosome GetBestChromosome()
        {
            return (Chromosome)thisGeneration[0];
        }

        public Selection SelectionType
        {
            set { m_SelType = value; }
            get { return m_SelType; }
        }
        public double Mutation
        {
            set { m_dMutation = value; }
            get { return m_dMutation; }
        }
        public double CrossOver
        {
            set { m_dCrossOver = value; }
            get { return m_dCrossOver; }
        }
        public long Generations
        {
            set { m_lGenerations = value; }
            get { return m_lGenerations; }
        }
        public ushort PopulationSize
        {
            set { m_usPopSize = value; }
            get { return m_usPopSize; }
        }
        public bool ApplyElitism
        {
            set { m_bApplyElitism = value; }
            get { return m_bApplyElitism; }
        }
        public ushort GenerationNum
        {
            set { this.m_usGen = value; }
            get { return this.m_usGen; }
        }
    }
}
