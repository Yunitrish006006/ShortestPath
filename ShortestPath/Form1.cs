namespace ShortestPath
{
    public partial class Form1 : Form
    {

        int[,] initial = new int[10, 10];
        int[,] shortest = new int[10, 10];
        string[,] path = new string[10, 10];
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * start 起始
         * end 終點
         * caculate 計算最短路徑按鈕
        */

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grayPen = new Pen(Color.Gray,1);
            g.DrawLine(grayPen, new Point(PA.Location.X + 5, PA.Location.Y + 5), new Point(PB.Location.X+5, PB.Location.Y));//AB
            g.DrawLine(grayPen, new Point(PA.Location.X + 7, PA.Location.Y + 2), new Point(PC.Location.X, PC.Location.Y + 6));//AC
            g.DrawLine(grayPen, new Point(PA.Location.X + 5, PA.Location.Y + 5), new Point(PD.Location.X, PD.Location.Y));//AD

            g.DrawLine(grayPen, new Point(PB.Location.X + 5, PB.Location.Y + 8), new Point(PD.Location.X, PD.Location.Y+8));//BD
            g.DrawLine(grayPen, new Point(PB.Location.X + 5, PB.Location.Y + 5), new Point(PE.Location.X, PE.Location.Y));//BE

            g.DrawLine(grayPen, new Point(PC.Location.X + 5, PC.Location.Y + 5), new Point(PF.Location.X, PF.Location.Y + 5));//CF
            g.DrawLine(grayPen, new Point(PC.Location.X + 7, PC.Location.Y + 5), new Point(PD.Location.X + 7, PD.Location.Y - 5));//CD

            g.DrawLine(grayPen, new Point(PD.Location.X + 5, PD.Location.Y + 5), new Point(PF.Location.X + 5, PF.Location.Y + 5));//DF
            g.DrawLine(grayPen, new Point(PD.Location.X + 5, PD.Location.Y + 5), new Point(PG.Location.X + 5, PG.Location.Y + 3));//DG
            g.DrawLine(grayPen, new Point(PD.Location.X + 7, PD.Location.Y + 9), new Point(PE.Location.X + 7, PE.Location.Y));//DE

            g.DrawLine(grayPen, new Point(PF.Location.X + 7, PF.Location.Y + 9), new Point(PG.Location.X + 7, PG.Location.Y - 2));//FG
            g.DrawLine(grayPen, new Point(PF.Location.X + 7, PF.Location.Y + 9), new Point(PH.Location.X , PH.Location.Y + 7));//FH
            g.DrawLine(grayPen, new Point(PF.Location.X + 7, PF.Location.Y + 9), new Point(PI.Location.X , PI.Location.Y + 5));//FI

            g.DrawLine(grayPen, new Point(PE.Location.X + 7, PE.Location.Y + 9), new Point(PG.Location.X + 5, PG.Location.Y + 6));//EG

            g.DrawLine(grayPen, new Point(PG.Location.X + 7, PG.Location.Y + 9), new Point(PI.Location.X + 5, PI.Location.Y + 6));//GI
            g.DrawLine(grayPen, new Point(PG.Location.X + 7, PG.Location.Y + 9), new Point(PJ.Location.X + 5, PJ.Location.Y + 6));//GJ

            g.DrawLine(grayPen, new Point(PH.Location.X + 7, PH.Location.Y + 9), new Point(PI.Location.X + 5, PI.Location.Y + 6));//HI

            g.DrawLine(grayPen, new Point(PI.Location.X + 7, PI.Location.Y + 9), new Point(PJ.Location.X + 5, PJ.Location.Y + 6));//IJ

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // 參數類型中參考型別是否可為 Null 的情況，與目標委派不相符 (可能的原因是屬性可為 Null)。
            this.Paint += new PaintEventHandler(Form1_Paint);
#pragma warning restore CS8622 // 參數類型中參考型別是否可為 Null 的情況，與目標委派不相符 (可能的原因是屬性可為 Null)。
            InitialValue();
        }

        void writePathLengthToArray(TextBox n)
        {
            string path = n.Name;
            int x = (int) path[0] - (int) 'A';
            int y = (int) path[1] - (int) 'A';
            initial[x, y] = Convert.ToInt32(n.Text);
            initial[y, x] = Convert.ToInt32(n.Text);
        }

        //debug 工具
        void InitialValue()
        {
            AB.Text = Convert.ToString(8);
            AC.Text = Convert.ToString(3);
            AD.Text = Convert.ToString(12);

            BD.Text = Convert.ToString(23);
            BE.Text = Convert.ToString(19);

            CD.Text = Convert.ToString(5);
            CF.Text = Convert.ToString(39);

            DE.Text = Convert.ToString(2);
            DF.Text = Convert.ToString(32);
            DG.Text = Convert.ToString(16);

            EG.Text = Convert.ToString(7);

            FG.Text = Convert.ToString(19);
            FH.Text = Convert.ToString(17);
            FI.Text = Convert.ToString(6);

            GI.Text = Convert.ToString(11);
            GJ.Text = Convert.ToString(2);

            HI.Text = Convert.ToString(25);

            IJ.Text = Convert.ToString(10);

            start.Text = "B";
            end.Text = "H";
        }
        void printDebug()
        {
            textBox1.Text = "";
            textBox1.Text += "\t\t\t\tINITIAL\r\n";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (initial[i, j] != 1073741823) textBox1.Text += initial[i, j] + "\t";
                    else textBox1.Text += "*\t";
                }
                textBox1.Text += "\r\n\r\n";
            }
            textBox1.Text += "\t\t\t\tShortest\r\n";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (shortest[i, j] != 1073741823) textBox1.Text += shortest[i, j] + "\t";
                    else textBox1.Text += "*\t";
                }
                textBox1.Text += "\r\n\r\n";
            }
        }

        private void caculate_Click(object sender, EventArgs e)
        {
            int start_index = (int)start.Text[0] - (int)'A';
            int end_index = (int)end.Text[0] - (int)'A';

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(i != j) initial[i, j] = 1073741823;
                    else initial[i, j] = 0;
                    char from = (char) ((int)'A' + i);
                    char to = (char)((int)'A' + j);
                    path[i, j] = Convert.ToString(from) + " -> " + Convert.ToString(to);
                }
            }
            shortest_path.Text = "";
            writePathLengthToArray(AB);writePathLengthToArray(AC);writePathLengthToArray(AD);
            writePathLengthToArray(BD);writePathLengthToArray(BE);
            writePathLengthToArray(CD);writePathLengthToArray(CF);
            writePathLengthToArray(DE);writePathLengthToArray(DG);writePathLengthToArray(DF);
            writePathLengthToArray(EG);
            writePathLengthToArray(FG);writePathLengthToArray(FH);writePathLengthToArray(FI);
            writePathLengthToArray(GI);writePathLengthToArray(GJ);
            writePathLengthToArray(HI);
            writePathLengthToArray(IJ);

            shortest = initial;
            //計算最短路徑
            for (int i = 0;i < 10;i++)
            {
                for(int j = 0;j < 10;j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (shortest[i, j] > shortest[i,k] + shortest[k,j])
                        {
                            shortest[i, j] = shortest[i, k] + shortest[k, j];
                            path[i, j] = path[i, k].Substring(0, path[i,k].Length-1) + path[k, j];
                        }
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (shortest[i, j] > shortest[i, k] + shortest[k, j])
                        {
                            shortest[i, j] = shortest[i, k] + shortest[k, j];
                            path[i, j] = path[i, k].Substring(0, path[i, k].Length - 1) + path[k, j];
                        }
                    }
                }
            }

            //printDebug();
            
            
            shortest_path_length.Text = Convert.ToString(shortest[start_index, end_index]);
            shortest_path.Text = path[start_index, end_index];
            // A -> F == A C D E G I F
            // J -> A == J G E D C A
        }
    }
}