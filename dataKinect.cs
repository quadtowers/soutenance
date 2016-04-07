using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectWPFOpenCV
{
    public struct dataKinect
    {
        public MCvBox2D box_obj;
        public PointF[] centre_obj;
        public SizeF[] aire_obj;
        public int nb_obj;
    };
}
