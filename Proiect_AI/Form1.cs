 
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
                Board_Matrix[i, j].Text = board.get_element(i, j).ToString();
            }

            /* Print the board piece on form */
            this.Controls.Add(Board_Matrix[i, j]);
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
        public void create_eventonclick(int x,int y)
        {
            /* Create the event that will happen when we click on a piece of the board */
            Board_Matrix[x, y].Click += delegate (object sender, EventArgs args)
            {
                board.update_element(x, y,x+2, y); 
                delete_button_onClick( x,  y); 
                delete_button_onClick(x + 2, y);
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
