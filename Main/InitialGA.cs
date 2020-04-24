using Main.Genetic_Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class InitialGA
    {
        // Sinh một tổ hợp ngẫu nhiên từ dữ liệu các thành phố
        public static void khoitaoNST(Chromosome chromose)
        {
            var input = Enumerable.Range(0, MainTSP.points.Count).ToList();
            int index = 0;
            for (int i = 0; i < MainTSP.points.Count; i++)
            {
                index = MainTSP.rand.Next(input.Count);
                chromose.AddGene(input[index].ToString());
                input.RemoveAt(index);
            }
        }
        #region  ĐỘT BIẾN
        // Đột biến bằng cách hoán vị 2 vị trí bất kỳ trong NST được chọn
        public static void Dotbien(Chromosome chromose)
        {
            //do dai nhiem sac the
            int ChromoLen = chromose.GeneLength;
            //lay vi tri ngau nhien
            int vitri1 = MainTSP.rand.Next(0, ChromoLen);

            int vitri2 = vitri1;
            while (vitri2 == vitri1)
                vitri2 = MainTSP.rand.Next(0, ChromoLen);

            //lay gen tai vi tri da chon
            string Gene1 = chromose[vitri1];
            string Gene2 = chromose[vitri2];

            //hoan vi 2 gen do
            chromose.RemoveAt(vitri1);
            chromose.Insert(vitri1, Gene2);

            chromose.RemoveAt(vitri2);
            chromose.Insert(vitri2, Gene1);
        }
        #endregion

        # region HÀM THÍCH NGHI
        public static void Thichnghi(Chromosome NST)
        {
            // Độ thích nghi thô là tổng khoảng cách của chu trình
            // khởi tạo độ thích nghi này là khoảng cách từ thành phố đầu đến thành phố cuối
            // do khi đi qua tất cả các thành phố thì sẽ quay lại thành phố đầu tiên

            //double fitness = MainTSP.distanceMatrix[int.Parse(NST[0]), int.Parse(NST[NST.GeneLength - 1])];
            double fitness = 0;
            int CityIndex1 = 0;
            int CityIndex2 = 1;

            if (NST.Count > 0)
            {
                while (CityIndex2 < NST.GeneLength)
                {
                    fitness += MainTSP.distanceMatrix[int.Parse(NST[CityIndex1]), int.Parse(NST[CityIndex2])];
                    CityIndex1++;
                    CityIndex2++;
                }

                fitness += MainTSP.distanceMatrix[int.Parse(NST[0]), int.Parse(NST[NST.Count - 1])];

                // do thich nghi tang len khi khoang cach giam 
                NST.Fitness = 1000 / fitness;
            }

        }

        #endregion
        #region LAI GHÉP

        // single - point crossover
        public static void Laighep(Chromosome Dad, Chromosome Mum, ref Chromosome child1, ref Chromosome child2)
        {
            GreedyCrossOver(Dad, Mum, ref child1);
            GreedyCrossOver(Mum, Dad, ref child2);
        }

        public static void GreedyCrossOver(Chromosome Dad, Chromosome Mum, ref Chromosome child)
        {
            // do dai nhiem sac the 
            int length = Dad.GeneLength;
            int MumIndex = -1;
            //chon ngau nhien vi tri Gene cua Dad
            int DadIndex = MainTSP.rand.Next(0, length);
            string DadGene = Dad[DadIndex];

            //tim vi tri Gene do trong ca the me
            MumIndex = Mum.HasThisGene(DadGene);
            if (MumIndex < 0)
                throw new Exception(" Khong tim thay Gene trong ca the me");

            // them DadGene vao ca the con
            child.Add(DadGene);
            bool bDadAdded = true;
            bool bMumAdded = true;
            do
            {
                string obMumGene = "";
                string obDadGene = "";
                //them Gene tu cha
                if (bDadAdded)
                {
                    if (DadIndex > 0)
                        DadIndex = DadIndex - 1;
                    else
                        DadIndex = length - 1;
                    obDadGene = Dad[DadIndex];
                }
                else
                {
                    bDadAdded = false;
                }
                //them gene tu me
                if (bMumAdded)
                {
                    if (MumIndex < length - 1)
                        MumIndex = MumIndex + 1;
                    else
                        MumIndex = 0;
                    obMumGene = Mum[MumIndex];
                }
                else
                {
                    bMumAdded = false;
                }
                if (bDadAdded && child.HasThisGene(obDadGene) < 0)
                {
                    //them Gen Nst cha vao dau
                    child.Insert(0, obDadGene);
                }
                else
                    bDadAdded = false;
                if (bMumAdded && child.HasThisGene(obMumGene) < 0)
                {
                    //Them Gen nst me vao cuoi
                    child.AddGene(obMumGene);
                }
                else
                    bMumAdded = false;

            } while (bDadAdded || bMumAdded); // dung khi bDadAdded hoac bMumAdded = false

            // Them nhung Gene con lai bang cach chon ngau nhien
            while (child.GeneLength < length)
            {
                bool bDone = false;
                do
                {
                    //chon ngau nhien Gene
                    // int iRandom = this.rand.Next(0, length);
                    int iRandom = MainTSP.rand.Next(0, length);
                    // Neu Gene nay khong co trong NST con thi them vao cac the con                    
                    if (child.HasThisGene(iRandom.ToString()) < 0)
                    {
                        child.Add(iRandom.ToString());
                        bDone = true;
                    }
                } while (!bDone);
            } // exit while (child.GeneLength <length)
        }
        #endregion

        public static void Compraror_NST(Chromosome chromo)
        {
            // Đột biến bằng cách phát sinh một vị trí ngẫu nhiên, sau đó tìm hàng xóm gần nhất với nó
            // cho đến khi ma trận chi phí không còn hợp lệ thì thôi
            int sotp = MainTSP.points.Count;
            double[,] NighborMatrix = new double[MainTSP.distanceMatrix.GetLength(0), MainTSP.distanceMatrix.GetLength(1)];
            Array.Copy(MainTSP.distanceMatrix, NighborMatrix,
                MainTSP.distanceMatrix.GetLength(0) * MainTSP.distanceMatrix.GetLength(1));

            // khoi tao nhiem sac the moi
            Chromosome NSTmoi = new Chromosome();

            //bat dau chon ngau nhien					
            int iCurrentSel = MainTSP.rand.Next(0, sotp);

            string Gene = chromo[iCurrentSel];

            NSTmoi.AddGene(Gene);

            //vieng tham cac thanh pho ben trai
            int iLeftpoints = sotp - 1;
            int iCurrentCitySel = int.Parse(Gene);
            do
            {
                int iNearstNeighbor = GetNearstNeighbor(NighborMatrix, iCurrentCitySel);
                NSTmoi.AddGene(iNearstNeighbor.ToString());
                iLeftpoints--;
                iCurrentCitySel = iNearstNeighbor;

            } while (iLeftpoints > 0);
            chromo.Copy_NhiemSacThe(NSTmoi);
        }

        public static int GetNearstNeighbor(double[,] NighborMatrix, int iCurrentCitySel)
        {
            int Index = 0;
            double distance = 1000000000;
            int sotp = MainTSP.points.Count;
            for (int i = 0; i < sotp; i++)
            {

                if (NighborMatrix[iCurrentCitySel, i] != -1
                    && distance > NighborMatrix[iCurrentCitySel, i])
                {
                    distance = NighborMatrix[iCurrentCitySel, i];
                    Index = i;
                }
            }
            // Nhung O khong co gia tri
            for (int i = 0; i < sotp; i++)
            {
                NighborMatrix[i, iCurrentCitySel] = -1;
                NighborMatrix[i, Index] = -1;
            }
            return Index;
        }
    }
}
