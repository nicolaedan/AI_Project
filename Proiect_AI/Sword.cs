using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Sword : Piece
    {
        public Sword(int x, int y, bool color) : base(x, y,color )
        {
            
            if (this.color == false)
            {
                this.set_image(Resource1.Sword_Black);

            }
            else this.set_image(Resource1.Sword_White);
        }
        public override int validare_mutare(int[,] matrix)
        {
            /* Variable used to return number of possible movements */
            int movment_nr = 0;

            /* Get actual row for pawm movement */
            int actual_row = this.Get_Row();
            int actual_column = this.Get_Column();

            if (this.color == false)
            {
                if (actual_column + 1 < 11)
                {
                    if (matrix[actual_row, actual_column + 1] == 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row);
                        valid_movement[movment_nr++].Set_Y(actual_column + 1);
                    }
                }

                if (actual_row + 1 < 11 && actual_column + 1 < 11)
                {
                    if (matrix[actual_row + 1, actual_column + 1] != 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row + 1);
                        valid_movement[movment_nr++].Set_Y(actual_column + 1);
                    }
                }

                if (actual_row + 1 < 11 && actual_column - 1 >= 0)
                {
                    if (matrix[actual_row + 1, actual_column - 1] != 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row + 1);
                        valid_movement[movment_nr++].Set_Y(actual_column - 1);
                    }
                }
            }
            else {
                if (actual_column - 1 >=0)
                {
                    if (matrix[actual_row, actual_column - 1] == 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row);
                        valid_movement[movment_nr++].Set_Y(actual_column - 1);
                    }
                }

                if (actual_row - 1 >=0 && actual_column - 1 >= 0)
                {
                    if (matrix[actual_row - 1, actual_column - 1] != 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row - 1);
                        valid_movement[movment_nr++].Set_Y(actual_column - 1);
                    }
                }

                if (actual_row - 1 >= 0 && actual_column + 1 < 11)
                {
                    if (matrix[actual_row - 1, actual_column + 1] != 0)
                    {
                        /* Save valid movement in member of class Piece */
                        valid_movement[movment_nr].Set_X(actual_row - 1);
                        valid_movement[movment_nr++].Set_Y(actual_column + 1);
                    }
                }
            }

            /* Return number of movements */
            return movment_nr;
        }




    }
}
