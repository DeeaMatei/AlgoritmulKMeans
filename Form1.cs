using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2
{
    public partial class Form1 : Form
    {
        private Random random;
        private int nrCentroizi;
        private List<Double> distantaPunctCentroid;
        private List<Centroid> centroizi;
        private List<Coordonate> puncte;
        private Graphics g;
        private Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void antrenareBtn_Click(object sender, EventArgs e)
        {
            //se alege un numar random de centroizi
            random = new Random();
            nrCentroizi = random.Next(2, 10);
            distantaPunctCentroid = new List<double>();
            centroizi = new List<Centroid>();
            puncte = new List<Coordonate>();

            //pentru fiecare centroid generam coordonate:
            for (int i = 0; i < nrCentroizi; i++)
            {
                int xPunct = random.Next(0, 600);
                int yPunct = random.Next(0, 600);
                centroizi.Add(new Centroid(xPunct, yPunct));
                //centroizi.Add(new Coordonate { x = xPunct, y = yPunct });
            }

            //luam coordonatele punctelor din fisierul generat de prima aplicatie:
            string path = @"E:\Facultate\coordonate.txt";
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] bits = line.Split(' ');
                    int xPunct = int.Parse(bits[1]);
                    int yPunct = int.Parse(bits[3]);
                    puncte.Add(new Coordonate(xPunct, yPunct));
                }
            }

            //creem un bitmap unde urmeaza sa desenam sistemul de coordonate, centroizii si punctele:
            bitmap = new Bitmap(600, 600);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            //desenam sistemul de coordonate:
            DesenareInitiala();
            //desenam punctele si centroizii:
            Desenare();
            //Similaritate(centroizi, puncte);
            Similaritate();
        }

        private void DesenareInitiala()
        {
            Point p1 = new Point(0, 300);
            Point p2 = new Point(600, 300);
            Point p3 = new Point(300, 0);
            Point p4 = new Point(300, 600);

            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
        }

        private void Desenare()
        {
            foreach (var centroid in centroizi)
            {
                int radius = 3;
                g.FillEllipse(Brushes.Red, centroid.coordonateCentroid.x - radius, centroid.coordonateCentroid.y - radius, 2 * radius, 2 * radius);
            }

            foreach (var punct in puncte)
            {
                bitmap.SetPixel(punct.x + 300, punct.y + 300, Color.Black);
            }

            pictureBox1.Image = bitmap;
            Refresh();
        }

        private void Similaritate()
        {
            double distanta;
            foreach (var punct in puncte)
            {
                double minim = Double.MaxValue;     //aici retinem distanta minima
                int centroidApropiat = 0;           //salvam numaruul centroidului cel mai apropiat
                for (int i = 0; i < nrCentroizi; i++)
                {
                    distanta = Math.Sqrt(Math.Pow(centroizi[i].coordonateCentroid.x - punct.x, 2) + Math.Pow(centroizi[i].coordonateCentroid.y - punct.y, 2));
                    if (distanta > minim)
                    {
                        minim = distanta;
                        centroidApropiat = i;
                    }
                }
                centroizi[centroidApropiat].punctSimilar.Add(punct);
                distantaPunctCentroid.Add(minim);
            }
        }
        private void RedesenareCentroizi()
        {
            for (int i = 0; i < nrCentroizi; i++)
            {
                int sumaX = 0;
                int sumaY = 0;

                if (!centroizi[i].punctSimilar.Count.Equals(0))
                {
                    foreach (var punctApropiat in centroizi[i].punctSimilar)
                    {
                        sumaX += punctApropiat.x;
                        sumaY += punctApropiat.y;
                    }
                    centroizi[i].coordonateCentroid.x = sumaX / centroizi[i].punctSimilar.Count;
                    centroizi[i].coordonateCentroid.y = sumaY / centroizi[i].punctSimilar.Count;
                }
            }
            for (int i = 0; i < nrCentroizi; i++)
            {
                int radius = 4;
                g.FillEllipse(Brushes.Aquamarine, centroizi[i].coordonateCentroid.x - radius, centroizi[i].coordonateCentroid.y, 2 * radius, 2 * radius);
            }
        }

        private void testareBtn_Click(object sender, EventArgs e)
        {
            RedesenareCentroizi();
            Refresh();
        }

    }
}
