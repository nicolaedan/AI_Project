using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{

    public abstract class Piece
    {
        public class Movement
        {
            public int x, y;
            public Movement(int x, int y)
            { }
            public void Set_X(int x)
            { 
                this.x = x;
            }

            public void Set_Y(int y)
            {
                this.y = y;
            }

            public int Get_X()
            {
                return this.x;
            }

            public int Get_Y()
            {
                return this.y;
            }
        }
        public Movement[] valid_movement;
        public int row;
        public int column;

        public Bitmap bitmap;
        Image image;
        public Piece(int row,int column,Image image)
        {
            this.row = row;
            this.column = column;
            this.image = image;
            valid_movement = new Movement[50];
            for (int index = 0; index < 50; index++)
                valid_movement[index] = new Movement(0, 0);


            //this.bitmap = new Bitmap();
        }
        
        public void Change_position(int x, int y)
        {
            this.row = y;
            this.column = x;
        }
        public int Get_Row()
        {
            return this.row;
        }

        public int Get_Column()
        {
            return this.column;
        }

        public int get_movement_x(int index)
        {
            return valid_movement[index].Get_X();
        }

        public int get_movement_y(int index)
        {
            return valid_movement[index].Get_Y();
        }
        public abstract int validare_mutare(int[,] matrix);

        public Image get_piece_image()
        {
            return this.image;
        }
    };

}
