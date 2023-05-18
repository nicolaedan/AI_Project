 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum ChessPieces{
    Sword = 1,       //Pawm
    Tower,           //Rook
    Horse,           //Knight
    Advisor,         //Bishop
    Mounted_Advisor, //Bishop/Knight
    Queen,           //Queen
    King,            //King
    Serpent,         //Bishop/Knight/Rook
    Pillar,          //Knight/Rook
    Medusa,          //kind of Queen
    Morph,           //Starts as Advisor
}

namespace Proiect_AI
{
    public partial class Form1 : Form
    {
        /* Matrix of buttons that will be the game board */
        public Button[,] Board_Matrix = new Button[11, 11];

        /* Board object used for tracking of game */
        Board board;

        int last_x = -1, last_y = -1;

        public Form1()
        {
            /* Initialize the board object and the board */
            board = new Board();
            generate_board();
        }

        public void generate_board()
        {
            /* Create the board piece by piece */
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    /* Generate the board piece */
                    generate_OneButton(i, j);

                    /* Create event for when we click on it */
                    create_eventonclick(i, j);
                }
        }

        public void display_generated_button(int i, int j)
        {
            /* Print the board piece on form */
            this.Controls.Add(Board_Matrix[i, j]);
        }
        public void generate_OneButton(int i, int j)
        {
            /* Use a button as the board piece */
            Board_Matrix[i, j] = new Button();

            /* Set button atributs */
            Board_Matrix[i, j].Height = 60;
            Board_Matrix[i, j].Width = 60;
            Board_Matrix[i, j].Location = new Point(60 * i, 60 * j);


            /* Give it alternating color */
            if ((i + j) % 2 == 0)
            {
                Board_Matrix[i, j].BackColor = Color.Black;
            }
            else
            {
                Board_Matrix[i, j].BackColor = Color.White;
            }

            /* Test if we have a chess piece on it */
            if (board.get_element(i, j) != 0)
            {
                Board_Matrix[i, j].Image = board.piece_matrix[i, j].get_piece_image();
            }

            /* Call t print button */
            display_generated_button(i, j);
        }
        public void delete_button_onClick(int x, int y)
        {
            /* Remove actual board piece */
            this.Controls.Remove(Board_Matrix[x, y]);

            /* Create another board piece */
            generate_OneButton(x, y);

            /* Create event when we click on the new board piece  */
            create_eventonclick(x, y);
        }
        public void highlight_buttons(int x, int y)
        {
            int nr, cell_x, cell_y;

            /* Get number of elemets that need  highlight */
            nr = board.piece_matrix[x, y].validare_mutare(board.get_matrixPtr());
            for (int index = 0; index < nr; index++)
            {
                /* Get the cell that need highlight */
                cell_x = board.piece_matrix[x, y].get_movement_x(index);
                cell_y = board.piece_matrix[x, y].get_movement_y(index);
                 if(board.get_element(cell_x,cell_y)!=0)
                    {
                        if (board.piece_matrix[cell_x, cell_y].get_color() != board.piece_matrix[x,y].get_color())
                            {
                             /* Make border green for highlight */
                Board_Matrix[cell_x, cell_y].FlatStyle = FlatStyle.Flat;
                Board_Matrix[cell_x, cell_y].FlatAppearance.BorderColor = Color.Green;
                        display_generated_button(cell_x, cell_y);
                        }


                            
                      }
                 else
                {
                    Board_Matrix[cell_x, cell_y].FlatStyle = FlatStyle.Flat;
                Board_Matrix[cell_x, cell_y].FlatAppearance.BorderColor = Color.Green;
                        display_generated_button(cell_x, cell_y);
                }
                
                
                
                
            }

            /* Save the coordonates of piece that needs to be moved */
            last_x = x;
            last_y = y;
        }
        public void clear_highlight(int x,int y)
        {
            int nr, cell_x, cell_y; ;

            /* Test we have highlighted buttons */
            if( last_x != -1 && last_y != -1)
            {
                /* Get number of elemets highlighted*/
                nr = board.piece_matrix[last_x, last_y].validare_mutare(board.get_matrixPtr());
           
                /* Reset them */
                for (int index = 0; index < nr; index++)
                {
                    /* Get cell */
                    cell_x = board.piece_matrix[last_x, last_y].get_movement_x(index);
                    cell_y = board.piece_matrix[last_x, last_y].get_movement_y(index);

                   
                   
                   delete_button_onClick(cell_x, cell_y);
                    }
                
                
            }
        }
        public void create_eventonclick(int x,int y)
        {
            /* Create the event that will happen when we click on a piece of the board */
            Board_Matrix[x, y].Click += delegate (object sender, EventArgs args) {
            int nr, cell;

              
                    if (Board_Matrix[x, y].FlatAppearance.BorderColor != Color.Green)
                    {
                        if (board.get_element(x, y) != 0)
                        {
                            /* Make sure we highlight the correct cells */
                            clear_highlight(x, y);

                            /* Highlight cells */
                            highlight_buttons(x, y);
                        }
                        else
                        {
                            /* Clear highlight buttons */
                            clear_highlight(x, y);
                        }
                     }
                    else
                    {
                        /* Clear highlight after move */
                        clear_highlight(x, y);


                        /* Reset the cells for piece movement(source cell and destionation cell) */
                        board.update_element(last_x, last_y, x, y);
                        delete_button_onClick(x, y);
                        delete_button_onClick(last_x, last_y);
                        last_x = -1;
                        last_y = -1;
                    }
          

            };
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
          
            this.ClientSize = new System.Drawing.Size(3000, 3000);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
