using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class King:Piece
    {
        Queen queen;
        public King(int x, int y,bool color) : base(x, y, color)
        {
            if (this.color == false)
            {
                this.set_image(Resource1.King_Black);

            }
            else this.set_image(Resource1.King_White);
        }
        public override int validare_mutare(int[,] matrix)
        {
            /* Variable used to return number of possible movements */
            int movment_nr = 0;
            queen=new Queen(this.row,this.column,this.color);
            queen.Change_n(1);
             movment_nr = queen.validare_mutare(matrix);


            for (int index = 0; index < movment_nr; index++)
            {
                /* Get the cell that need highlight */
                valid_movement[index].Set_X(queen.get_movement_x(index));
                valid_movement[index].Set_Y(queen.get_movement_y(index));


            }
        

            /* Return number of movements */
            return movment_nr;
        }


    }
}

