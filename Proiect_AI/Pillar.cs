﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Pillar:Piece
    {
        Piece rook;//tower
        Piece knight;//horse

        public Pillar(int x, int y,bool color) : base(x, y, color)
        {

            if (this.color == false)
            {
                this.set_image(Resource1.Pillar_Black);

            }
            else this.set_image(Resource1.Pillar_White);
        }

        public override int validare_mutare(int[,] matrix)
        {
            rook = new Tower(this.row, this.column, this.color);
            knight = new Horse(this.row, this.column, this.color);
            int movment_nr = 0;
            int j = 0;
            int copy = 0;

            j = rook.validare_mutare(matrix);
            copy = j;
            movment_nr = j + knight.validare_mutare(matrix);


            for (int index = 0; index < j; index++)
            {
                /* Get the cell that need highlight */
                valid_movement[index].Set_X(rook.get_movement_x(index));
                valid_movement[index].Set_Y(rook.get_movement_y(index));


            }
            for (int i = 0; i < movment_nr - copy; i++)
            {
                valid_movement[j].Set_X(knight.get_movement_x(i));
                valid_movement[j].Set_Y(knight.get_movement_y(i));
                j++;
            }


            /* Return number of movements */
            return movment_nr;
        }
    }
}
