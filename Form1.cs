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
        public Form1()
        {
            InitializeComponent();
        }

        private void antrenareBtn_Click(object sender, EventArgs e)
        {
            //se alege un numar random de centroizi
            Random random = new Random();
            int nrCentroizi = random.Next(2, 10);

            List<Double> distantaPunctCentroid = new List<double>();
            List<Centroid> centroizi = new List<Centroid>();
            List<Coordonate> puncte = new List<Coordonate>();
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
            Bitmap bitmap = new Bitmap(600, 600);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            //desenam sistemul de coordonate:
            DesenareInitiala(bitmap, g);
            //desenam punctele si centroizii:
            Desenare(centroizi, puncte, bitmap, g);
            //Similaritate(centroizi, puncte);
            Similaritate(centroizi, puncte, nrCentroizi, distantaPunctCentroid);
            //Redesenare centroid in centrul de greutate:
            RedesenareCentroizi(centroizi, nrCentroizi, g);
        }



        private void DesenareInitiala(Bitmap bitmap, Graphics g)
        {
            Point p1 = new Point(0, 300);
            Point p2 = new Point(600, 300);
            Point p3 = new Point(300, 0);
            Point p4 = new Point(300, 600);

            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
        }

        private void Desenare(List<Centroid> centroizi, List<Coordonate> puncte, Bitmap bitmap, Graphics g)
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

        private void Similaritate(List<Centroid> centroizi, List<Coordonate> puncte, int nrCentroizi, List<Double> distantaPunctCentroid)
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
        private void RedesenareCentroizi(List<Centroid> centroizi, int nrCentroizi, Graphics g)
        {
            for (int i = 0; i < nrCentroizi; i++)
            {
                int sumaX = 0;
                int sumaY = 0;
                foreach (var punctApropiat in centroizi[i].punctSimilar)
                {
                    sumaX += punctApropiat.x;
                    sumaY += punctApropiat.y;
                }
                centroizi[i].coordonateCentroid.x = sumaX;
                centroizi[i].coordonateCentroid.y = sumaY;
            }
            for (int i = 0; i < nrCentroizi; i++)
            {
                int radius = 3;
                g.FillEllipse(Brushes.Red, centroizi[i].coordonateCentroid.x - radius, centroizi[i].coordonateCentroid.y - radius, 2 * radius, 2 * radius);
            }
        }
    }
}
