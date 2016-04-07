using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace KinectWPFOpenCV
{
    /// <summary>
    /// Interaction logic for affichage.xaml
    /// </summary>
    public partial class affichage : UserControl
    {
        public affichage()
        {
            InitializeComponent();
        }

        public void afficherTerrain(terrain t)
        {
            canvas.Children.Clear();
            if (t.myPions.Count > 0)
            {
                IEnumerable<Pion> pions = t.myPions as IEnumerable<Pion>;
                foreach (Pion pion in pions)
                {
                    PointF lastCoord = pion.myPCoord[pion.myPCoord.Count - 1];
                    float point_X = (float)(lastCoord.X * canvas.Width) / t.myTaille.Width;
                    float point_Y = (float)(lastCoord.Y * canvas.Height) / t.myTaille.Height;
                    PointF point_Coord = new PointF(point_X, point_Y);
                    if ((point_X < t.myTaille.Width) && (point_Y < t.myTaille.Height))
                    {
                        /* 
                        System.Windows.shapes.Rectangle rect;
                         * rect = new System.Windows.Shapes.Rectangle();
                         * 
                         * Canvas.SetLeft(rect, ((float)(a.tab_center[i].X)));
                         * Canvas.SetTop(rect, ((float)(a.tab_center[i].Y));
                         * 
                         */
                        //drawpoint newpoint = new drawpoint(pion, point_Coord);
                        SizeF size = pion.myPSize;
                        System.Windows.Shapes.Rectangle newpoint = new System.Windows.Shapes.Rectangle();
                        newpoint.Height = (double)(size.Height * canvas.Height) / t.myTaille.Height;
                        newpoint.Width = (double)(size.Width * canvas.Width) / t.myTaille.Width;
                        
                        newpoint.StrokeThickness = 2;
                        newpoint.Stroke = new SolidColorBrush(Colors.Black);

                        double left = point_X - (size.Width / 2);
                        double top = point_Y - (size.Height / 2);
                        Canvas.SetLeft(newpoint, left);
                        Canvas.SetTop(newpoint, top);
                        canvas.Children.Add(newpoint);
                    }

                }
            }
        }
    }
}
