using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proiect_AI
{
    class Board
    {
        /* Matrix used for board tracking */
        public int[,] Board_Matrix;
        /* Not sure yet what is the purpose or if will remain */
        public Piece[,] piece_matrix;

        /* Class constructor */
        public Board() {
            /* Initialize members */
            Board_Matrix = new int[11, 11];
            piece_matrix = new Piece[11, 11];
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    Board_Matrix[i, j] = 0;
                }
            Board_Matrix[1, 4] = 1;
            Board_Matrix[2, 5] = 2;
            piece_matrix[1, 4] = new Pawm(1, 4);
            piece_matrix[2, 5] = new Pawm(2, 5);

        }

        /* Function used to get value of matrix element*/
        /* Will be used to test if we have a chess piece or not on the grid cell */
        public int get_element(int x,int y)
        {
            return Board_Matrix[x, y];
        }

        /* Function used when a piece is moving */
        public void update_element(int old_x, int old_y, int new_x, int new_y)
        {
            /* Update new position of chess piece */
            Board_Matrix[new_x, new_y] = Board_Matrix[old_x, old_y];
            piece_matrix[new_x, new_y] = piece_matrix[old_x, old_y];

            
            /* Set new coordonates */
            piece_matrix[new_x, new_y].Change_position(new_y, new_x);

            /* Clear old board cell */
            Board_Matrix[old_x, old_y] = 0;

        }

        public int[,] get_matrixPtr()
        {
            return Board_Matrix;
        }

    }
}
