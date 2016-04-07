using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KinectWPFOpenCV
{
    public class drawpoint : Shape
    {
        public drawpoint(Pion pion, PointF coord)
        {
            SizeF size = pion.myPSize;
            this.Width = size.Width;
            this.Height = size.Height;

            double left = coord.X - size.Width / 2;
            double top = coord.Y - size.Height / 2;
            this.Margin = new Thickness(left, top, 0, 0);

            // Couleur
            this.StrokeThickness = 2;
        }

        private Geometry random;
        protected override Geometry DefiningGeometry
        {
            get { return random; }
        }
    }
}
