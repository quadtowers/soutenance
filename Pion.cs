using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectWPFOpenCV
{
    [Serializable]
    public class Pion
    {
        private string pName;
        private SizeF pSize;
        private List<PointF> pCoord = new List<PointF>();
        private Color color;

        public Pion()
        {
            pName = "";
            pSize = new SizeF(-1, -1);
            // color = Random;
        }

        public string myPName
        {
            get { return pName; }
            set { pName = value; }
        }
        public SizeF myPSize
        {
            get { return pSize; }
            set { pSize = value; }
        }
        public List<PointF> myPCoord
        {
            get { return pCoord; }
            set { pCoord = value; }
        }

        public bool AddCoord(float x, float y)
        {
            PointF newCoord = new PointF(x, y);
            pCoord.Add(newCoord);
            return true;
        }






    }
}
