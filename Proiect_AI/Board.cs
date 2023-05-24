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

        public Piece AI_move;

        /* Class constructor */
        public Board() {

            AI_move =new Sword(12,12,true);
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

        public int start_minmax(int depth)
        { 
            /* Make a copy of the board */
            int[,] matrix_copy =new int[11,11];
            copy_matrix(matrix_copy,Board_Matrix);

            /* Make a copy of the pieces on the board */
            Piece[,] pieces_copy = new Piece[11,11];
            copy_pieces(pieces_copy,piece_matrix);

            minmax(matrix_copy,pieces_copy,false,depth);

            return 0;
        }

        public Piece[] generate_move(int[,]matrix,Piece[,]piece, bool player_color)
        { 
            Piece[] moveble_piece = new Piece[30];
            int index=0;

            for (int i=0;i<11;i++)
                for(int j=0;j<11;j++)
                { 
                    if(matrix[i,j]!=0 && piece[i,j].get_color()==player_color )
                    {
                        int nr = piece[i, j].validare_mutare(matrix) -1;
                        if ( nr!= 0)
                        {
                            int elements = 0;
                            bool one_move_valid = false;
                            for (int k = 0; i < nr; i++)
                            {
                                
                                int row = piece[i, j].get_movement_x(k);
                                int column = piece[i, j].get_movement_y(k);
                                Console.WriteLine(i.ToString() + " " + j.ToString());
                                if (matrix[row, column] != 0)
                                {
                                    Console.WriteLine(row.ToString() + " " + column.ToString()+"*");
                                    if (piece[row, column].get_color() != player_color)
                                    {
                                        Console.WriteLine(i.ToString() + " " + j.ToString());
                                        moveble_piece[index] = piece[i, j];
                                        moveble_piece[index].nr_moves = elements;
                                        moveble_piece[index].valid_movement[elements].Set_X(row);
                                        moveble_piece[index].valid_movement[elements].Set_Y(column);
                                        moveble_piece[index].nr_moves = elements;
                                        elements++;
                                        one_move_valid = true;
                                    }
                                }
                                else {
                                    Console.WriteLine(i.ToString() + " " + j.ToString());
                                    moveble_piece[index] = piece[i, j];
                                    moveble_piece[index].nr_moves = elements;
                                    moveble_piece[index].valid_movement[elements].Set_X(row);
                                    moveble_piece[index].valid_movement[elements].Set_Y(column);
                                    moveble_piece[index].nr_moves = elements;
                                    elements++;
                                    one_move_valid = true;

                                }
                              
                            }
                            if (one_move_valid == true)
                            { index++; }

                        }
                    }
                }

            return moveble_piece;
        }
        public double evaluet_move(int[,]matrix,Piece[,]piece)
        { 
            double result=0;
            for (int i=0;i<11;i++)
                for(int j=0;j<11;j++)
                { 
                    if(matrix[i,j]!=0)
                    { 
                        if(piece[i,j].get_color()==true)
                        { 
                            result+=piece[i,j].get_score(); 
                        }
                        else
                        { 
                            result-=piece[i,j].get_score(); 
                        }
                    }
                }
            return result;
        }
        public double minmax(int[,]matrix,Piece[,]piece,bool maximizing,int depth)
        { 
            double value;
          
            if(depth==0)
            { 
                double result = evaluet_move(matrix,piece);
                return result;
            }
            Piece[] moves = new Piece[30];

             moves=generate_move(matrix,piece,maximizing);
            Console.WriteLine(moves.Length);
            if (maximizing==false)
            {
                Console.WriteLine("negru");
                value =double.MaxValue;
                int ceva =1;
                foreach (Piece move in moves)
                { 
                    Console.WriteLine(move.get_moves_nr().ToString()+ " " +move.row.ToString() +" "+ move.column.ToString());
                    ceva++;
                    for (int move_nr=0;move_nr<move.get_moves_nr();move_nr++)
                    {
                        Console.WriteLine("ddd");
                        /* Make copies for new call */
                        int[,] new_matrix=new int[11,11];
                        copy_matrix(new_matrix,matrix);

                        Piece[,] new_pieces = new Piece[11,11];
                        copy_pieces(new_pieces,piece);

                        /* Update matrixes for movement */
                        new_matrix[move.get_movement_x(move_nr),move.get_movement_y(move_nr)]=new_matrix[move.row,move.column];
                        new_matrix[move.row,move.column] = 0;
                        new_pieces[move.get_movement_x(move_nr),move.get_movement_y(move_nr)]=new_pieces[move.row,move.column];
                        new_pieces[move.get_movement_x(move_nr),move.get_movement_y(move_nr)].Change_position(move.get_movement_x(move_nr),move.get_movement_y(move_nr));


                        double minmaxResult = minmax(new_matrix,new_pieces,true,depth-1);
                        if(minmaxResult<value)
                        {  value=minmaxResult;
                           AI_move=move;
                           AI_move.valid_movement[0].Set_X(move.get_movement_x(move_nr));
                           AI_move.valid_movement[0].Set_Y(move.get_movement_y(move_nr));
                        }
                       
                    }
                }        
            }
            else
            {
                Console.WriteLine("alb");
                value =double.MinValue;
                 foreach(Piece move in moves)
                { 
                    for(int move_nr=0;move_nr<move.get_moves_nr();move_nr++)
                    { 
                        /* Make copies for new call */
                        int[,] new_matrix=new int[11,11];
                        copy_matrix(new_matrix,matrix);

                        Piece[,] new_pieces = new Piece[11,11];
                        copy_pieces(new_pieces,piece);

                        /* Update matrixes for movement */
                        new_matrix[move.get_movement_x(move_nr),move.get_movement_y(move_nr)]=new_matrix[move.row,move.column];
                        new_matrix[move.row,move.column] = 0;
                        new_pieces[move.get_movement_x(move_nr),move.get_movement_y(move_nr)]=new_pieces[move.row,move.column];
                        new_pieces[move.get_movement_x(move_nr),move.get_movement_y(move_nr)].Change_position(move.get_movement_x(move_nr),move.get_movement_y(move_nr));


                        double minmaxResult = minmax(new_matrix,new_pieces,false,depth-1);
                        if(minmaxResult>value)
                        {  value=minmaxResult;
                           AI_move=move;
                           AI_move.valid_movement[0].Set_X(move.get_movement_x(move_nr));
                           AI_move.valid_movement[0].Set_Y(move.get_movement_y(move_nr));
                        }
                       
                    }
                }        
            }
             return value;
        }


        public void copy_matrix(int[,] copy,int[,]matrix)
        { 
            for (int i=0;i<11;i++)
                for(int j=0;j<11;j++)
                    copy[i,j]=matrix[i,j];
        }
        public void copy_pieces(Piece[,] copy,Piece[,]matrix)
        { 
            for (int i=0;i<11;i++)
                for(int j=0;j<11;j++)
                    copy[i,j]=matrix[i,j];
        }
    }
}
