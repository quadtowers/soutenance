using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectWPFOpenCV
{
    public class point
    {
        private string Name;
        private PointF old_Coord;
        private PointF new_Coord;

        public string myName
        {
            get { return Name; }
            set { Name = value; }
        }

        public PointF myOldCoord
        {
            get { return old_Coord; }
            set { old_Coord = value; }
        }

        public PointF myNewCoord
        {
            get { return new_Coord; }
            set { new_Coord = value; }
        }

    }
}
