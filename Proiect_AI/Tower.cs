using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Tower : Piece 
    {
        public Tower(int x, int y) : base(x, y, Resource1.white_pawm)
        {
        }

        public override int validare_mutare(int[,] matrix)
        {
            /* Variable used to return number of possible movements */
            int movment_nr = 0;

            /* Get actual row for pawm movement */
            int actual_row = this.Get_Row();
            int actual_column = this.Get_Column();

            for(int i = 0; i < 11 - actual_row; i++)
            {
                if (matrix[actual_row + i, actual_column] == 0)
                {
                    /* Save valid movement in member of class Piece */
                    valid_movement[movment_nr].Set_X(actual_row + i);
                    valid_movement[movment_nr++].Set_Y(actual_column);
                }
            }
            for (int k = actual_row; k > 0; k--)
            {
                if (matrix[actual_row - k, actual_column] == 0)
                {
                    /* Save valid movement in member of class Piece */
                    valid_movement[movment_nr].Set_X(actual_row - k);
                    valid_movement[movment_nr++].Set_Y(actual_column);
                }
            }
            for (int j = 0; j < 11 - actual_column; j++)
            {
                if (matrix[actual_row , actual_column + j] == 0)
                {
                    /* Save valid movement in member of class Piece */
                    valid_movement[movment_nr].Set_X(actual_row);
                    valid_movement[movment_nr++].Set_Y(actual_column + j);
                }
            }
            for (int j2 = actual_column ; j2 > 0; j2--)
            {
                if (matrix[actual_row, actual_column - j2] == 0)
                {
                    /* Save valid movement in member of class Piece */
                    valid_movement[movment_nr].Set_X(actual_row);
                    valid_movement[movment_nr++].Set_Y(actual_column - j2);
                }
            }


            if (matrix[actual_row + 1, actual_column + 1] != 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 1);
                valid_movement[movment_nr++].Set_Y(actual_column + 1);
            }
            if (matrix[actual_row + 1, actual_column - 1] != 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 1);
                valid_movement[movment_nr++].Set_Y(actual_column - 1);
            }

            /* Return number of movements */
            return movment_nr;
        }

    }
}
