using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Advisor : Piece
    {
        public Advisor(int x, int y,bool color) : base(x, y, color)
        {
            if (this.color == false)
            {
                this.set_image(Resource1.Advisor_Black);

            }
            else this.set_image(Resource1.Advisor_White);
        }

        public override int validare_mutare(int[,] matrix)
        {
            /* Variable used to return number of possible movements */
            int movment_nr = 0;

            /* Get actual row for pawm movement */
            int actual_row = this.Get_Row();
            int actual_column = this.Get_Column();

            int suma = actual_column + actual_row;

            int nr_elements = this.n;
            while (actual_row < 10 && actual_column < 10 && nr_elements!=0)
            {
                nr_elements--;
                actual_column++; actual_row++;
                valid_movement[movment_nr].Set_X(actual_row);
                valid_movement[movment_nr++].Set_Y(actual_column);
                if (matrix[actual_row, actual_column] != 0)
                {
                    break;
                }
                /*moves.Add(new Coordinate(vertical, horizontal));*/
            }
            actual_row = this.Get_Row();
            actual_column = this.Get_Column();
            nr_elements = this.n;
            while (actual_row > 0 && actual_column < 10 && nr_elements != 0)
            {
                nr_elements--;
                actual_column++; actual_row--;
                valid_movement[movment_nr].Set_X(actual_row);
                valid_movement[movment_nr++].Set_Y(actual_column);
                if (matrix[actual_row, actual_column] != 0)
                {
                    break;
                }
                /*moves.Add(new Coordinate(vertical, horizontal));*/
            }
            actual_row = this.Get_Row();
            actual_column = this.Get_Column();
            nr_elements = this.n;
            while (actual_row < 10 && actual_column > 0 && nr_elements != 0)
            {
                nr_elements--;
                actual_column--; actual_row++;
                valid_movement[movment_nr].Set_X(actual_row);
                valid_movement[movment_nr++].Set_Y(actual_column);
                if (matrix[actual_row, actual_column] != 0)
                {
                    break;
                }
                /*moves.Add(new Coordinate(vertical, horizontal));*/
            }
            actual_row = this.Get_Row();
            actual_column = this.Get_Column();
            nr_elements = this.n;
            while (actual_row > 0 && actual_column > 0&& nr_elements != 0)
            {
                nr_elements--;
                actual_column--; actual_row--;
                valid_movement[movment_nr].Set_X(actual_row);
                valid_movement[movment_nr++].Set_Y(actual_column);
                if (matrix[actual_row, actual_column] != 0)
                {
                    break;
                }
                /*moves.Add(new Coordinate(vertical, horizontal));*/
            }

            
            /* Return number of movements */
            return movment_nr;
        }


    }
}
