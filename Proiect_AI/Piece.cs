using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Piece
    {
        public int row;
        public int column;

        public Bitmap bitmap;

        public Piece(int row,int column)
        {
            this.row = row;
            this.column = column;
            //this.bitmap = new Bitmap();
        }

        public void Change_position(int x, int y)
        {
            this.row = x;
            this.column = y;
        }
    }
}
