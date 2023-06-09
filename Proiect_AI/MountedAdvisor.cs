﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class MountedAdvisor : Piece
    {
        Piece knight;
        Piece bishop;

        public MountedAdvisor(int x, int y,bool color) : base(x, y, color)
        {

            if (this.color == false)
            {
                this.set_image(Resource1.MountedAdvisor_Black);

            }
            else this.set_image(Resource1.MountedAdvisor_White);
        }

        public override int validare_mutare(int[,] matrix)
        {
            knight = new Horse(this.row, this.column, this.color);
            bishop = new Advisor(this.row, this.column, this.color);
            int movment_nr = 0;
            int j = 0;
            int copy = 0;

            j = knight.validare_mutare(matrix);
            copy = j;
            movment_nr = j + bishop.validare_mutare(matrix);


            for (int index = 0; index < j; index++)
            {
                /* Get the cell that need highlight */
                valid_movement[index].Set_X(knight.get_movement_x(index));
                valid_movement[index].Set_Y(knight.get_movement_y(index));

                
            }
            for (int i = 0; i < movment_nr - copy; i++)
            {
                valid_movement[j].Set_X(bishop.get_movement_x(i));
                valid_movement[j].Set_Y(bishop.get_movement_y(i));
                j++;
            }


            /* Return number of movements */
            return movment_nr;
        }


    }
}
