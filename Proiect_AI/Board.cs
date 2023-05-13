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
           /* White pieces */
           /* ------------------------------ */
            Board_Matrix[0, 10] = 1;
            Board_Matrix[1, 10] = 2;
            Board_Matrix[2, 10] = 3;
            Board_Matrix[3, 10] = 4;
            Board_Matrix[4, 10] = 5;
            Board_Matrix[5, 10] = 6;
            Board_Matrix[6, 10] = 7;
            Board_Matrix[7, 10] = 8;
            Board_Matrix[8, 10] = 9;
            Board_Matrix[9, 10] = 10;
            Board_Matrix[10, 10] = 11;
            Board_Matrix[0, 9] = 12;
            Board_Matrix[1, 9] = 13;
            Board_Matrix[2, 9] = 14;
            Board_Matrix[3, 9] = 15;
            Board_Matrix[4, 9] = 16;
            Board_Matrix[5, 9] = 17;
            Board_Matrix[6, 9] = 18;
            Board_Matrix[7, 9] = 19;
            Board_Matrix[8, 9] = 20;
            Board_Matrix[9, 9] = 21;
            Board_Matrix[10, 9] = 22;
            Board_Matrix[4,8] = 23;
            Board_Matrix[5, 8] = 24;
            Board_Matrix[6, 8] = 25;
            Board_Matrix[5, 7] = 26;
            /* ------------------------------ */


            /* Black pieces */
            /* ...........................*/
            Board_Matrix[0, 0] = 27;
            Board_Matrix[1, 0] = 28;
            Board_Matrix[2, 0] = 29;
            Board_Matrix[3, 0] = 30;
            Board_Matrix[4, 0] = 31;
            Board_Matrix[5, 0] = 32;
            Board_Matrix[6, 0] = 33;
            Board_Matrix[7, 0] = 34;
            Board_Matrix[8, 0] = 34;
            Board_Matrix[9, 0] = 36;
            Board_Matrix[10, 0] = 37;
            Board_Matrix[0, 1] = 38;
            Board_Matrix[1, 1] = 39;
            Board_Matrix[2, 1] = 40;
            Board_Matrix[3, 1] = 41;
            Board_Matrix[4, 1] = 42;
            Board_Matrix[5, 1] = 43;
            Board_Matrix[6, 1] = 44;
            Board_Matrix[7, 1] = 45;
            Board_Matrix[8, 1] = 46;
            Board_Matrix[9, 1] = 47;
            Board_Matrix[10, 1] = 48;
            Board_Matrix[4, 2] = 49;
            Board_Matrix[5, 2] = 50;
            Board_Matrix[6, 2] = 51;
            Board_Matrix[5, 3] = 52;
            /* ...........................*/

            /* White pieces */
            /* ------------------------------ */
            piece_matrix[0, 10] = new Tower(0, 10,true);
            piece_matrix[1, 10] = new Horse(1, 10, true);
            piece_matrix[2, 10] = new Advisor(2, 10, true);
            piece_matrix[3, 10] = new MountedAdvisor(3, 10, true);
            piece_matrix[4, 10] = new Queen(4, 10, true);
            piece_matrix[5, 10] = new King(5, 10, true);
            piece_matrix[6, 10] = new Serpent(6, 10, true);
            piece_matrix[7, 10] = new Advisor(7, 10, true);
            piece_matrix[8, 10] = new MountedAdvisor(8, 10, true);
            piece_matrix[9, 10] = new Horse(9, 10, true);
            piece_matrix[10, 10] = new Tower(10, 10, true);

            piece_matrix[0, 9] = new Sword(0, 9, true);
            piece_matrix[1, 9] = new Sword(1, 9, true);
            piece_matrix[2, 9] = new Sword(2, 9, true);
            piece_matrix[3, 9] = new Sword(3, 9, true);
            piece_matrix[4, 9] = new Pillar(4, 9, true);
            piece_matrix[5, 9] = new Medusa(5, 9, true);
            piece_matrix[6, 9] = new Pillar(6, 9, true);
            piece_matrix[7, 9] = new Sword(7, 9, true);
            piece_matrix[8, 9] = new Sword(8, 9, true);
            piece_matrix[9, 9] = new Sword(9, 9, true);
            piece_matrix[10, 9] = new Sword(10, 9, true);

            piece_matrix[4, 8] = new Sword(4, 8, true);
            piece_matrix[5, 8] = new Morph(5, 8, true);
            piece_matrix[6, 8] = new Sword(6, 8, true);

             piece_matrix[5, 7] = new Sword(5, 7, true);
            /* ------------------------------ */


            /* Black pieces */
            /* ...........................*/
            piece_matrix[0, 0] = new Tower(0, 0, false);
            piece_matrix[1, 0] = new Horse(1, 0, false);
            piece_matrix[2, 0] = new Advisor(2, 0, false);
            piece_matrix[3, 0] = new MountedAdvisor(3, 0, false);
            piece_matrix[4, 0] = new Queen(4, 0, false);
            piece_matrix[5, 0] = new King(5, 0, false);
            piece_matrix[6, 0] = new Serpent(6, 0, false);
            piece_matrix[7, 0] = new Advisor(7, 0, false);
            piece_matrix[8, 0] = new MountedAdvisor(8, 0, false);
            piece_matrix[9, 0] = new Horse(9, 0, false);
            piece_matrix[10, 0] = new Tower(10, 0, false);

            piece_matrix[0, 1] = new Sword(0, 1, false);
            piece_matrix[1, 1] = new Sword(1, 1, false);
            piece_matrix[2, 1] = new Sword(2, 1, false);
            piece_matrix[3, 1] = new Sword(3, 1, false);
            piece_matrix[4, 1] = new Pillar(4, 1, false);
            piece_matrix[5, 1] = new Medusa(5, 1, false);
            piece_matrix[6, 1] = new Pillar(6, 1, false);
            piece_matrix[7, 1] = new Sword(7, 1, false);
            piece_matrix[8, 1] = new Sword(8, 1, false);
            piece_matrix[9, 1] = new Sword(9, 1, false);
            piece_matrix[10, 1] = new Sword(10, 1, false);

            piece_matrix[4, 2] = new Sword(4, 2, false);
            piece_matrix[5, 2] = new Morph(5, 2, false);
            piece_matrix[6, 2] = new Sword(6, 2, false);

            piece_matrix[5, 3] = new Sword(5, 3, false);
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
