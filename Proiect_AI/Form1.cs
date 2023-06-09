﻿ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using Microsoft.VisualBasic;



namespace Proiect_AI
{
    public partial class Form1 : Form
    {
        /* Matrix of buttons that will be the game board */
        public Button[,] Board_Matrix = new Button[11, 11];
        public Button button_retea = new Button();
        public Label labelConnected=new Label();
        
        string numeClient;
        string serverIp;
        int serverPort;
        int color_player;
        int movement_enable;

        /* Board object used for tracking of game */
        Board board;

        int last_x = -1, last_y = -1;
        private Label label1;

        public Form1()
        {
            /* Initialize the board object and the board */
            board = new Board();
            generate_board();
            button_retea.Location = new Point(700, 700);
            labelConnected.Location = new Point(700, 0);
            
            labelConnected.Text = "Not Connected";
            button_retea.Click += delegate (object sender, EventArgs args) {
                string ip, stringPort;
                int port;
                string ipSiPort = Interaction.InputBox("Enter ip and port of the client", "Client box", "ex : 10.10.10.10:123");
                this.numeClient = Interaction.InputBox("Enter a client name", "Client Name Box", "ex : Bob");
                this.serverIp = ipSiPort.Split(':')[0];
                stringPort = ipSiPort.Split(':')[1];
                this.serverPort = Int32.Parse(stringPort);
                NetworkComms.SendObject<string>("Message", this.serverIp, this.serverPort, "@" + this.numeClient);

            };
            this.Controls.Add(button_retea);
            this.Controls.Add(labelConnected);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", ReceivedPacketsHandlers);


            //board.start_minmax(2);
            //  highlight_buttons(board.AI_move.row,board.AI_move.column);

        }
        private void ReceivedPacketsHandlers(PacketHeader header, Connection connection, String message)
        {
            string mesajDecodat = message.Substring(1);
            Console.WriteLine(message);
            if (message[0] == '&')
            {
                writeConnectedLabelSafe(mesajDecodat);
            }
            else
            {
                receptieSiParsareDateEvent(mesajDecodat, '%');
            }
        }
        public void receptieSiParsareDateEvent(string message, char caracterulDeEncodare)
        {
            
            int XRetea = 0;
            int YRetea = 0;
            int X_oldRetea = 0;
            int Y_oldRetea = 0;
            string[] vectorVariabile;
            string numeVariabila;
            string valoareVariabila;
            string numeVariabila_old;
            string valoareVariabila_old;
            string variabilaEncodata="";
            vectorVariabile = message.Split(caracterulDeEncodare);
            
       
            numeVariabila = vectorVariabile[0];
            valoareVariabila = vectorVariabile[1];
            numeVariabila_old = vectorVariabile[2];
            valoareVariabila_old = vectorVariabile[3];
            Console.WriteLine(vectorVariabile[1]);
            board.update_element(Int32.Parse(numeVariabila_old), Int32.Parse(valoareVariabila_old), Int32.Parse(numeVariabila), Int32.Parse(valoareVariabila));
            delete_button_onClick(Int32.Parse(numeVariabila_old), Int32.Parse(valoareVariabila_old));
            delete_button_onClick(Int32.Parse(numeVariabila), Int32.Parse(valoareVariabila));
            movement_enable = (movement_enable + 1) % 2;
        }
        public void encodare(int X, int Y)
        {
            string coordonate = "";
            string encodedString = "";
            coordonate =  X.ToString() + "%"  + Y.ToString()+"%"+last_x.ToString() + "%" +  last_y.ToString();
            encodedString =  "%" + coordonate;
            if (labelConnected.Text == "connectionEstablished")
            {
                NetworkComms.SendObject<string>("Message", this.serverIp, this.serverPort, encodedString);
                Console.WriteLine(encodedString);
            }
        }

        public void writeConnectedLabelSafe(string text)
        {
            if (labelConnected.InvokeRequired)
            {
                Action safeWrite = delegate { writeConnectedLabelSafe(text); };
                labelConnected.Invoke(safeWrite);
            }
            else
            {
                movement_enable = (text[text.Length - 1])-'0';
                color_player = text[text.Length - 3] - '0';
                labelConnected.Text = text.Substring(0,text.Length-4);
                Console.WriteLine(movement_enable + " " + color_player);
            }
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
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int, int>(delete_button_onClick), new object[] { x, y });
                return;
            }
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
                if (movement_enable == 0)
                {
                    if (Board_Matrix[x, y].FlatAppearance.BorderColor != Color.Green)
                    {
                        if (board.get_element(x, y) != 0 && board.piece_matrix[x,y].get_color()== Convert.ToBoolean(color_player))
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
                        // board.update_element(last_x, last_y, x, y);
                        encodare(x, y);
                        // delete_button_onClick(x, y);
                        // delete_button_onClick(last_x, last_y);
                        last_x = -1;
                        last_y = -1;
                    }
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1648, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
