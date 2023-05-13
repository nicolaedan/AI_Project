using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_AI
{
    public class Morph:Piece
    {
        Piece morph;
        public Morph(int x, int y, bool color) : base(x, y, color)
        {
            if (this.color == false)
            {
                this.set_image(Resource1.Morph_Black);

            }
            else this.set_image(Resource1.Morph_White);
        }

        public override int validare_mutare(int[,] matrix)
        {
            morph = new Advisor(this.row, this.column,this.color);
            int movment_nr = 0;
            

            
            movment_nr = morph.validare_mutare(matrix);


            for (int index = 0; index < movment_nr; index++)
            {
                /* Get the cell that need highlight */
                valid_movement[index].Set_X(morph.get_movement_x(index));
                valid_movement[index].Set_Y(morph.get_movement_y(index));


            }
           
            return movment_nr;
        }
    }
}
