using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<coordinateSet> coords = new List<coordinateSet>();
        BackgroundWorker back = new BackgroundWorker();

        internal class coordinateSet
        {
            public int XCoord{ get; set; }
            public int ZCoord { get; set; }
            public double Distance { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            back.WorkerReportsProgress = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "Running";
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            coords = new List<coordinateSet>();
            back.DoWork += new DoWorkEventHandler(back_DoWork);
            back.RunWorkerAsync();
            back.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            back.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }


        void back_DoWork(object sender, DoWorkEventArgs e)
        {
            long seed = (long)Int64.Parse(SeedBox.Text);
            int square = Int32.Parse(SquareBox.Text);
            int xPosition;
            int zPosition;
            java.util.Random rnd;




            for (int xChunk = -square; xChunk <= square; xChunk++)
            {
                int dif = Math.Abs(xChunk - (-square));
                double percent = ((double)dif / (double)(square * 2)) * 100;
                back.ReportProgress((int)percent);
                for (int zChunk = -square; zChunk <= square; zChunk++)
                {
                    //	1
                    xPosition = xChunk;
                    zPosition = zChunk;
                    rnd = new java.util.Random(
                            seed +
                            (int)(xPosition * xPosition * 0x4c1906) +
                            (int)(xPosition * 0x5ac0db) +
                            (int)(zPosition * zPosition) * 0x4307a7L +
                            (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                    );

                    if (rnd.nextInt(10) == 0)
                    {
                        //  2
                        xPosition++;
                        rnd = new java.util.Random(
                                seed +
                                (int)(xPosition * xPosition * 0x4c1906) +
                                (int)(xPosition * 0x5ac0db) +
                                (int)(zPosition * zPosition) * 0x4307a7L +
                                (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                        );

                        if (rnd.nextInt(10) == 0)
                        {
                            //  3
                            xPosition++;
                            rnd = new java.util.Random(
                                    seed +
                                    (int)(xPosition * xPosition * 0x4c1906) +
                                    (int)(xPosition * 0x5ac0db) +
                                    (int)(zPosition * zPosition) * 0x4307a7L +
                                    (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                            );

                            if (rnd.nextInt(10) == 0)
                            {
                                //  4
                                zPosition++;
                                rnd = new java.util.Random(
                                        seed +
                                        (int)(xPosition * xPosition * 0x4c1906) +
                                        (int)(xPosition * 0x5ac0db) +
                                        (int)(zPosition * zPosition) * 0x4307a7L +
                                        (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                );

                                if (rnd.nextInt(10) == 0)
                                {
                                    //  5
                                    xPosition--;
                                    rnd = new java.util.Random(
                                            seed +
                                            (int)(xPosition * xPosition * 0x4c1906) +
                                            (int)(xPosition * 0x5ac0db) +
                                            (int)(zPosition * zPosition) * 0x4307a7L +
                                            (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                    );

                                    if (rnd.nextInt(10) == 0)
                                    {
                                        //  6
                                        xPosition--;
                                        rnd = new java.util.Random(
                                                seed +
                                                (int)(xPosition * xPosition * 0x4c1906) +
                                                (int)(xPosition * 0x5ac0db) +
                                                (int)(zPosition * zPosition) * 0x4307a7L +
                                                (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                        );

                                        if (rnd.nextInt(10) == 0)
                                        {
                                            //  7
                                            zPosition++;
                                            rnd = new java.util.Random(
                                                    seed +
                                                    (int)(xPosition * xPosition * 0x4c1906) +
                                                    (int)(xPosition * 0x5ac0db) +
                                                    (int)(zPosition * zPosition) * 0x4307a7L +
                                                    (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                            );

                                            if (rnd.nextInt(10) == 0)
                                            {
                                                //  8
                                                xPosition++;
                                                rnd = new java.util.Random(
                                                        seed +
                                                        (int)(xPosition * xPosition * 0x4c1906) +
                                                        (int)(xPosition * 0x5ac0db) +
                                                        (int)(zPosition * zPosition) * 0x4307a7L +
                                                        (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                                );

                                                if (rnd.nextInt(10) == 0)
                                                {
                                                    //  9
                                                    xPosition++;
                                                    rnd = new java.util.Random(
                                                            seed +
                                                            (int)(xPosition * xPosition * 0x4c1906) +
                                                            (int)(xPosition * 0x5ac0db) +
                                                            (int)(zPosition * zPosition) * 0x4307a7L +
                                                            (int)(zPosition * 0x5f24f) ^ 0x3ad8025fL
                                                    );

                                                    if (rnd.nextInt(10) == 0)
                                                    {
                                                        coords.Add(new coordinateSet() { XCoord = xPosition * 16, ZCoord = zPosition * 16, Distance = (Math.Sqrt(xPosition * xPosition + zPosition * zPosition) * 16) });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = coords;
            resultLabel.Text = "Done!";
        }

    }
}
