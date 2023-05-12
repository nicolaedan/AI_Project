﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Horse : Piece
    {
        public Horse(int x, int y) : base(x, y, Resource1.white_pawm)
        {
        }

        public override int validare_mutare(int[,] matrix)
        {
            /* Variable used to return number of possible movements */
            int movment_nr = 0;

            /* Get actual row for pawm movement */
            int actual_row = this.Get_Row();
            int actual_column = this.Get_Column();

            if (matrix[actual_row + 2, actual_column + 1] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 2);
                valid_movement[movment_nr++].Set_Y(actual_column + 1);
            }

            if (matrix[actual_row + 2, actual_column - 1] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 2);
                valid_movement[movment_nr++].Set_Y(actual_column - 1);
            }

            if (matrix[actual_row - 2, actual_column - 1] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row - 2);
                valid_movement[movment_nr++].Set_Y(actual_column - 1);
            }

            if (matrix[actual_row - 2, actual_column + 1] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row - 2);
                valid_movement[movment_nr++].Set_Y(actual_column + 1);
            }

            if (matrix[actual_row + 1, actual_column + 2] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 1);
                valid_movement[movment_nr++].Set_Y(actual_column + 2);
            }

            if (matrix[actual_row - 1, actual_column + 2] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row - 1);
                valid_movement[movment_nr++].Set_Y(actual_column + 2);
            }

            if (matrix[actual_row + 1, actual_column - 2] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row + 1);
                valid_movement[movment_nr++].Set_Y(actual_column - 2);
            }

            if (matrix[actual_row - 1, actual_column - 2] == 0)
            {
                /* Save valid movement in member of class Piece */
                valid_movement[movment_nr].Set_X(actual_row - 1);
                valid_movement[movment_nr++].Set_Y(actual_column - 2);
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
