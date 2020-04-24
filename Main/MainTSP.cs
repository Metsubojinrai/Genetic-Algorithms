using Main.Genetic_Zone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class MainTSP : Form
    {
        public static List<Point> points = new List<Point>();       // danh sách các toa độ các thành phố, trên hệ tọa độ map
        public static Random rand = new Random();
        public static Chromosome solutionChromo = null;
        public static double[,] distanceMatrix;                     // Khoảng cách giữa các thành phố, được tính toán 
                                                                    // dựa trên tọa độ của chúng
        public static string strPath = "";
        private string[] edgeDetail, weightDetail;

        private bool isInSearch = false;

        public static int totalCost = 0;
        //-- cac bien phuc vu ve do thi cac thanh pho
        private Label _cursorCoordinate = new Label();      // nhãn tọa độ chuột trong map
        private Point clickedPoint;                         // điểm được click trên map
        private int pointRadius = 4;                        // bán kính điểm tròn đại diện cho thành phố

        public MainTSP()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            OnLoadInit();
        }

        private void OnLoadInit()
        {
            numCities.Value = 6;
            numGenLimit.Value = 50;
            numPopSize.Value = 50;
            numCrossOver.Value = (decimal)0.75;
            numMutation.Value = (decimal)0.05;
            btnSearch.Enabled = false;

            _cursorCoordinate.BackColor = Color.Transparent;
            _cursorCoordinate.Visible = false;
            _cursorCoordinate.AutoSize = false;
            //_cursorCoordinate.Text = "X: 999" + Environment.NewLine + "Y: 999";
            _cursorCoordinate.Height = 30;
            _cursorCoordinate.Location = new Point(ptbMap.Width - 45, 0);
            ptbMap.Controls.Add(_cursorCoordinate);

            txtPath.MouseDoubleClick += new MouseEventHandler(txtPath_DoubleClick);
        }

        private void ShowCoordinate(Point e)
        {
            //_cursorCoordinate.Location = e;
            _cursorCoordinate.Text = "X: " + e.X + Environment.NewLine + "Y: " + e.Y;
            _cursorCoordinate.Visible = true;
        }

        private void ptbMap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ptbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (points.Count < numCities.Maximum)
            {
                clickedPoint = new Point(e.X, e.Y);
                points.Add(clickedPoint);
                System.Drawing.Graphics g = this.ptbMap.CreateGraphics();
                g.FillEllipse(Brushes.Tomato, e.X, e.Y, 2 * pointRadius, 2 * pointRadius);
                numCities.Value = points.Count;
                g.DrawString(points.Count.ToString(), new Font(this.Font, FontStyle.Bold), Brushes.DarkBlue, clickedPoint.X - 12, clickedPoint.Y - 12);
                g.Dispose();
            }
            if (points.Count >= 4)
            {
                btnSearch.Enabled = true;
            }
        }

        private void ptbMap_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinate(ptbMap.PointToClient(Cursor.Position));
        }

        private void ptbMap_MouseLeave(object sender, EventArgs e)
        {

            if (!_cursorCoordinate.Bounds.Contains(ptbMap.PointToClient(Cursor.Position)))
            {
                _cursorCoordinate.Visible = false;
            }
        }

        // Tính ma trận khoảng cách giữa các điểm đã cho
        private double[,] ComputeDistances(List<Point> citiesLoc)
        {
            double[,] d = new double[citiesLoc.Count, citiesLoc.Count];
            double dx, dy;
            double tempX, tempY;

            for (int i = 0; i < citiesLoc.Count; i++)
            {
                tempX = citiesLoc[i].X;
                tempY = citiesLoc[i].Y;
                d[i, i] = -1;
                for (int j = i + 1; j < citiesLoc.Count; j++)
                {
                    dx = tempX - citiesLoc[j].X;
                    dy = tempY - citiesLoc[j].Y;
                    d[i, j] = d[j, i] = Math.Sqrt(dx * dx + dy * dy);
                }
            }
            return d;
        }

        private bool isValidNumberOfCities()        // tu 4 thanh pho tro len moi thuc hien tim chu trinh
        {
            return numCities.Value >= 4;
        }

        private void DrawPoints()
        {
            Graphics g = ptbMap.CreateGraphics();
            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(Brushes.Tomato, points[i].X, points[i].Y, 2 * pointRadius, 2 * pointRadius);
                g.DrawString((i + 1).ToString(), new Font(this.Font, FontStyle.Bold), Brushes.DarkBlue, points[i].X - 12, points[i].Y - 12);
            }
            g.Dispose();

        }
        private void DrawPath(Chromosome chromo)
        {
            edgeDetail = new string[chromo.Count];
            weightDetail = new string[chromo.Count];
            totalCost = 0;
            Point p1, p2, wp;
            int x1 = 0;
            int x2 = int.Parse(chromo[0]);
            int tempW = 0;
            StringBuilder tempath = new StringBuilder((x2 + 1).ToString());

            Graphics g = ptbMap.CreateGraphics();

            for (int i = 0; i < chromo.Count; i++)
            {
                x1 = x2;
                x2 = int.Parse(chromo[(i + 1) % chromo.Count]);
                p1 = points[x1];
                p2 = points[x2];
                g.DrawLine(new Pen(Color.GreenYellow, 2), new Point(p1.X + pointRadius, p1.Y + pointRadius),
                    new Point(p2.X + pointRadius, p2.Y + pointRadius));
                wp = ComputeWeightLabel(new Point(p1.X + pointRadius, p1.Y + pointRadius),
                    new Point(p2.X + pointRadius, p2.Y + pointRadius));
                tempW = (int)Math.Round(distanceMatrix[x1, x2]);
                g.DrawString(tempW.ToString(), this.Font, Brushes.ForestGreen, wp);
                totalCost += tempW;
                tempath.Append(" --> ");
                tempath.Append((x2 + 1).ToString());
                edgeDetail[i] = (x1 + 1).ToString() + " --> " + (x2 + 1).ToString();
                weightDetail[i] = tempW.ToString();
            }
            lblTotalCost.Text = totalCost.ToString();
            strPath = tempath.ToString();
            txtPath.Text = strPath;
            g.Dispose();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ptbMap.Refresh();
            points.Clear();
            txtPath.Text = "Waiting for solution...";
            btnSearch.Enabled = false;
            isInSearch = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isInSearch = true;
            if (!isValidNumberOfCities())
            {
                MessageBox.Show("Số thành phố tối thiểu phải bằng 4  !", "Cảnh báo");
                return;
            }
            distanceMatrix = ComputeDistances(points);         // tính ma trận khoảng cách từ ma trận điểm đã cho

            Initializer khoitaomoi = new Initializer(InitialGA.khoitaoNST);
            Mutate dotbien = new Mutate(InitialGA.Compraror_NST);
            Fitness phepthichnghi = new Fitness(InitialGA.Thichnghi);
            CrossOver pheplaighep = new CrossOver(InitialGA.Laighep);
            //tao doi tuong moi
            GA GeneticSolver = new GA(khoitaomoi, phepthichnghi, dotbien, pheplaighep);

            GeneticSolver.Generations = (long)numGenLimit.Value;
            GeneticSolver.PopulationSize = (ushort)numPopSize.Value;
            GeneticSolver.Mutation = (double)numMutation.Value;
            GeneticSolver.CrossOver = (double)numCrossOver.Value;

            // Khoi tao thuat toan
            GeneticSolver.Initialize();

            // kiem tra dieu kien dung
            // chua thoa man thuc hien tao the he moi
            while (!GeneticSolver.IsStop())
            {
                GeneticSolver.CreateNextGeneration();
            }

            // Lay ra phan tu co do thich nghi tot nhat trong quan the
            solutionChromo = GeneticSolver.GetBestChromosome();

            // Vẽ phương án lên bản đồ
            ptbMap.Refresh();
            DrawPath(solutionChromo);
            DrawPoints();
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (!isValidNumberOfCities())
            {
                MessageBox.Show("Số thành phố tối thiểu phải bằng 4!", "Cảnh báo");
                return;
            }

            btnSearch.Enabled = true;
            ptbMap.Refresh();
            points.Clear();
            int nCities = (int)numCities.Value;
            int rndX, rndY;
            for (int i = 0; i < nCities; i++)
            {
                rndX = rand.Next(15, ptbMap.Width - 15);
                rndY = rand.Next(30, ptbMap.Height - 20);
                points.Add(new Point(rndX, rndY));
            }
            DrawPoints();
        }

        private void txtPath_DoubleClick(object sender, EventArgs e)
        {
            if (isInSearch)
            {
                FrmPathDetail fpd = new FrmPathDetail(edgeDetail, weightDetail);
                fpd.ShowDialog();
            }
        }

        // tính toán vị trí đặt nhãn trọng số cho đường đi
        private Point ComputeWeightLabel(Point a, Point b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            double tanAlpha;
            double referee = 1;
            double halfX = (1.0 * a.X + b.X) / 2;
            double halfY = (1.0 * a.Y + b.Y) / 2;
            int xOffset = 5, yOffset = 5;
            if (dx != 0)
            {
                tanAlpha = dy / dx;
                if (tanAlpha >= 0 && tanAlpha <= referee)
                {
                    return new Point((int)(halfX - xOffset), (int)(halfY + yOffset));
                }
                if (tanAlpha > referee && tanAlpha < Double.MaxValue)
                {
                    return new Point((int)(halfX + xOffset), (int)(halfY - yOffset));
                }
                if (tanAlpha > -Double.MaxValue && tanAlpha < referee)
                {
                    return new Point((int)(halfX + xOffset), (int)(halfY + yOffset));
                }
                else
                {
                    return new Point((int)(halfX - xOffset), (int)(halfY - yOffset));
                }
            }

            return new Point((int)(halfX + 12), (int)(halfY - 10));
        }

    }
}
