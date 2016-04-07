using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KinectWPFOpenCV
{
    /// <summary>
    /// Interaction logic for points_view.xaml
    /// </summary>
    public partial class points_view : UserControl
    {
        public points_view()
        {
            InitializeComponent();
        }

        public void showPoints(List<Pion> pions)
        {
            this.point_lv.Items.Clear();

            IEnumerable<Pion> Points = pions as IEnumerable<Pion>;
            foreach (Pion pion in Points)
            {
                int count = pion.myPCoord.Count;
                point newpoint = new point
                    {
                        myName = pion.myPName,
                        myNewCoord = pion.myPCoord[count - 1],
                    };
                if (count >= 2)
                {
                        newpoint.myOldCoord = pion.myPCoord[count - 2];
                    
                }
                else
                {
                        newpoint.myOldCoord = new PointF(0, 0);
                }

                point_lv.Items.Add(newpoint);
            }
        }
    }
}
