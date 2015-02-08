using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Slider
{
    public partial class Form1 : Form
    {
        bool scrambled = false;
        bool scrambling = false;
        int moves = 0;
        int dimX = 3;
        int dimY = 3;

        int last;
        int buffer;
        int btnDimX;
        int btnDimY;
        int padding;     
        Button[] buttons;
        Point[] ogPos;
        Point[] locations;

        Image img;
        Size btnSize;


        public Form1()
        {
            InitializeComponent();
            AltGenerate(1);
            pbSolved.BackgroundImage = img;
            cbDimX.Text = "3";
            cbDimY.Text = "3";
        }

        //SPLIT IMAGE
        public Image splitImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        //ALTERNATE GENERATION
        public void AltGenerate(int type)
        {       
            last = (dimX * dimY) - 1;
            buttons = new Button[dimX * dimY];
            ogPos = new Point[last];    //1 less than 'buttons', excludes empty button
            buffer = 1;
            btnDimX = Convert.ToInt32(((this.Height * 0.9) / dimX) - buffer);   //button dimensions proportional to size of form, leave a 10% padding on top and bottom
            btnDimY = Convert.ToInt32(((this.Height * 0.9) / dimY) - buffer);
            padding = 2; //(this.Height - Convert.ToInt32(this.Height * 0.9)) / 2;
            int lineCount = 1;
            int count = 1;
            Point buttonPos = new Point(padding, padding);  //initial button position is just the padding on x/y
            btnSize = new Size(btnDimX,btnDimY);

            for (int n = 0; n <= last; n++)
            {
                    buttons[n] = new Button();   //generation
                    buttons[n].Width = btnDimX;      //for
                    buttons[n].Height = btnDimY;         //all
                    buttons[n].Location = buttonPos;         //buttons
                    buttons[n].FlatStyle = FlatStyle.Popup;

                if (type == 2)
                {
                    buttons[n].Location = locations[n];        
                }

                if (n == last)     //final button ("empty button")
                {
                    buttons[n].Name = "empty";
                    buttons[n].Visible = false;
                    buttons[n].Enabled = false;
                }
                else
                {                                       //other buttons
                    buttons[n].Name = "btn" + (n + 1);
                    //buttons[n].Text = (n + 1).ToString();
                    buttons[n].Click += new EventHandler(this.buttons_Click);   //button click event for movement
                    ogPos[n] = buttonPos;   //to detect if solved         
                }

                //background image
                img = new Bitmap(Properties.Resources.pic, new Size(this.Height, this.Height));
                Rectangle cropRect = new Rectangle(buttonPos, (Size)btnSize);
                buttons[n].BackgroundImage = splitImage(img, cropRect);


                if (lineCount == dimX)      //not at end of y
                {
                    buttonPos = new Point(padding, padding + (count * (btnDimY + buffer)));
                    lineCount = 1;
                    count += 1;
                }
                else
                {
                    buttonPos.X += btnDimX + buffer;
                    lineCount += 1;
                }
                this.Controls.Add(buttons[n]);

                
            }
        }

        //GENERATATE BUTTONS (SAME X/Y DIM)
        //public void Generate()
        //{           
        //    int last = (dimX * dimX) - 1;
        //    buttons = new Button[dimX * dimX];
        //    ogPos = new Point[last];    //1 less than 'buttons', excludes empty button
        //    int buffer = 30 / dimX;
        //    int padding = Convert.ToInt32((this.Height * 0.043));
        //    int lineCount = 1;
        //    int count = 1;

        //    Point buttonPos = new Point(padding, padding);  //initial button position is just the padding on x/y
        //    int btnDim = Convert.ToInt32(((this.Height * 0.9) / dimX) - buffer);   //button dimensions proportional to size of form, leave a 10% padding on top and bottom


        //    for (int n = 0; n <= last; n++)
        //    {
        //        if (n == last)     //final button ("empty button")
        //        {
        //            buttons[n] = new Button();
        //            buttons[n].Name = "empty";
        //            buttons[n].Width = btnDim;
        //            buttons[n].Height = btnDim;
        //            buttons[n].Location = buttonPos;
        //            buttons[n].Text = "empty";
        //            buttons[n].Visible = false;
        //        }
        //        else
        //        {                                       //generate all buttons
        //            buttons[n] = new Button();
        //            buttons[n].Name = "btn" + (n + 1);
        //            buttons[n].Width = btnDim;
        //            buttons[n].Height = btnDim;
        //            buttons[n].Text = (n + 1).ToString();
        //            buttons[n].Location = buttonPos;
        //            buttons[n].Click += new EventHandler(this.buttons_Click);
        //            ogPos[n] = buttonPos;
        //        }

        //        if (lineCount == dimX)      //not at end of y
        //        {
        //            buttonPos = new Point(padding, padding + (count * (btnDim + buffer)));
        //            lineCount = 1;
        //            count += 1;
        //        }
        //        else
        //        {
        //            buttonPos.X += btnDim + buffer;
        //            lineCount += 1;
        //        }
        //        this.Controls.Add(buttons[n]);
        //    }
        //}

        //CHECK IF SOLVED
        public bool check()
        {
            int last = (dimX * dimY) - 1;

                for (int n = 0; n < last; n++)
                {
                    if (ogPos[n] != buttons[n].Location)    //if the original position of any button doesn't
                    {                                       //equal its current position, return false
                        return false;
                    }
                }
                return true;            //else return true, it is solved
        }

        //MOVE CONTROLS ON FORM RESIZE
        public void AdjustControls()    
        {
            Point scrambleLoc = new Point(this.Width - 187, btnScramble.Location.Y);    //Repositions all controls   
            btnScramble.Location = scrambleLoc;
            Point UpdateLoc = new Point(this.Width - 187, btnUpdate.Location.Y);
            btnUpdate.Location = UpdateLoc;

            Point dimXLoc = new Point(this.Width - 187, cbDimX.Location.Y);
            cbDimX.Location = dimXLoc;
            Point dimXTextLoc = new Point(this.Width - 187, lblDimXText.Location.Y);
            lblDimXText.Location = dimXTextLoc;
            Point dimYLoc = new Point(this.Width - 121, cbDimY.Location.Y);
            cbDimY.Location = dimYLoc;
            Point dimYTextLoc = new Point(this.Width - 121, lblDimYText.Location.Y);
            lblDimYText.Location = dimYTextLoc;
            
            Point MovesLoc = new Point(this.Width - 139, lblMoves.Location.Y);
            lblMoves.Location = MovesLoc;
            Point MovesTextLoc = new Point(this.Width - 187, lblMovesText.Location.Y);
            lblMovesText.Location = MovesTextLoc;
            Point solvedLoc = new Point(this.Width - 187, pbSolved.Location.Y);
            pbSolved.Location = solvedLoc;
        }

        //REMOVE ALL BUTTONS
        public void ClearGrid()     
        {
            foreach (var v in buttons)
            {
                this.Controls.Remove(v);
            }
        }

        //SCRAMBLE
        public void Scramble()     
        {
            int last = (dimX * dimY) - 1;     //declare random/last item
            var rnd = new Random();


            for (int n = 0; n < 40 * ((dimX + dimY) / 2); n++)
            {
                int r = rnd.Next(0, last);  //from first to last button, generate random    
                buttons[r].PerformClick();  //click the random button (move it)

                System.Threading.Thread.Sleep(2);   //pause    

                if (check() == true)
                {
                    n = 0;
                }
            }


            scrambled = true;  
            moves = 0;     //reset moves
            lblMoves.Text = (moves.ToString());
        }   
        
        //SLIDE PIECES
        public void buttons_Click(object sender, EventArgs e)  
        {   
            Button btn = sender as Button;
            Point tempLoc;
            int last = (dimX * dimY) - 1;
            int buffer = 5;
            int btnDimX = Convert.ToInt32(((this.Height * 0.9) / dimX) - buffer);   
            int btnDimY = Convert.ToInt32(((this.Height * 0.9) / dimY) - buffer);

            int xDist = btnDimX + buffer;
            int yDist = btnDimY + buffer;


            //Move single button
            if ((btn.Location.X == buttons[last].Location.X - xDist || btn.Location.X == buttons[last].Location.X + xDist) && (btn.Location.Y == buttons[last].Location.Y) ||
                (btn.Location.Y == buttons[last].Location.Y - yDist || btn.Location.Y == buttons[last].Location.Y + yDist) && (btn.Location.X == buttons[last].Location.X))
            {
                moves += 1;     //increment move counter
                lblMoves.Text = (moves.ToString());

                tempLoc = buttons[last].Location;        //swap location of btn and empty space (buttons[last])
                buttons[last].Location = btn.Location;
                btn.Location = tempLoc;
            }
            //Move multiple buttons 
            else if (btn.Location.X == buttons[last].Location.X)    //same X, diff Y (vertical)
            {
                moves += 1;     //increment move counter
                lblMoves.Text = (moves.ToString());

                if (btn.Location.Y < buttons[last].Location.Y)  
                {
                    multiSlideYDown(btn, yDist);                  //above empty button
                }
                else
                {
                    multiSlideYUp(btn, yDist * -1);               //below                    
                }
            }
            else if (btn.Location.Y == buttons[last].Location.Y)    //same Y, diff X (horizontal)
            {
                moves += 1;     //increment move counter
                lblMoves.Text = (moves.ToString());

                if (btn.Location.X < buttons[last].Location.X)  
                {
                    multiSlideXRight(btn, xDist);                 //left of empty button                    
                }
                else
                {
                    multiSlideXLeft(btn, xDist * -1);             //right of
                }
            }
            
            


            //if SOLVED (scrambled, buttons in correct place, not in the middle of scrambling)
            if (scrambled == true && check() == true && scrambling == false)
            {
                buttons[last].Visible = true;    
                MessageBox.Show("You won in " + lblMoves.Text + " moves!");
                scrambled = false;  //reset 'scrambled'   
                foreach (var v in buttons)
                {
                    v.Enabled = false;
                }
            }          
        }

        //MULTI SLIDE PIECES     
        public void multiSlideYDown(Button btn, int dist)
        {
            Point beforePos = btn.Location;         
            for (int n = 0; n < last; n++)   //because n is 1, it will actually only go to just before the last button
            {
                if (buttons[n].Location.X == buttons[last].Location.X && (buttons[n].Location.Y < buttons[last].Location.Y && buttons[n].Location.Y >= btn.Location.Y))
                {
                    buttons[n].Location = new Point(buttons[n].Location.X, buttons[n].Location.Y + dist);  //move down
                }
            }
            buttons[last].Location = beforePos;  //move empty button to button clicked
        }   //DOWN
        public void multiSlideYUp(Button btn, int dist)
        {
            Point beforePos = btn.Location;
            for (int n = 0; n < last; n++)   //because n is 1, it will actually only go to just before the last button
            {
                if (buttons[n].Location.X == buttons[last].Location.X && (buttons[n].Location.Y > buttons[last].Location.Y && buttons[n].Location.Y <= btn.Location.Y))
                {
                    buttons[n].Location = new Point(buttons[n].Location.X, buttons[n].Location.Y + dist);  //move up (dist * -1 as arg)
                }
            }
            buttons[last].Location = beforePos;  //move empty button to button clicked
        }   //UP
        public void multiSlideXRight(Button btn, int dist)
        {
            Point beforePos = btn.Location;
            for (int n = 0; n < last; n++)   //because n is 1, it will actually only go to just before the last button
            {
                if (buttons[n].Location.Y == buttons[last].Location.Y && (buttons[n].Location.X < buttons[last].Location.X && buttons[n].Location.X >= btn.Location.X))
                {
                    buttons[n].Location = new Point(buttons[n].Location.X + dist, buttons[n].Location.Y);  //move right
                }
            }
            buttons[last].Location = beforePos;  //move empty button to button clicked
        }   //RIGHT
        public void multiSlideXLeft(Button btn, int dist)
        {
            Point beforePos = btn.Location;
            for (int n = 0; n < last; n++)   //because n is 1, it will actually only go to just before the last button
            {
                if (buttons[n].Location.Y == buttons[last].Location.Y && (buttons[n].Location.X > buttons[last].Location.X && buttons[n].Location.X <= btn.Location.X))
                {
                    buttons[n].Location = new Point(buttons[n].Location.X + dist, buttons[n].Location.Y) ;  //move right
                }
            }
            buttons[last].Location = beforePos;  //move empty button to button clicked
        }   //LEFT
        
      







            //Image[] images = new Image[last];
            //Graphics g = Graphics.FromImage(img);
            //Brush redBrush = new SolidBrush(Color.Red);
            //Pen pen = new Pen(redBrush, 3);
            //MessageBox.Show(img.Width + " " + img.Height);
            //for (int i = 0; i < img.Width; i = (img.Width / 3) + i)
            //{
            //    for (int y = 0; y < last; y = (img.Height / 3) + y)
            //    {
            //        Rectangle r = new Rectangle(i, y, img.Width / dimX, img.Height / dimY);
            //        g.DrawRectangle(pen, r);
            //        if (i > 0 && y > 0)
            //        {
            //            if (i + r.Width < b.Width && y + r.Height < b.Height)
            //            {
                            
            //            }
            //        }
            //    }
            //}
            //g.Dispose();

        private void btnScramble_Click_1(object sender, EventArgs e)    //Scramble button click
        {
            buttons[last].Visible = false;

            scrambling = true;  //can't give 'solved' prompt
            do
            {
                Scramble();     //scramble once
            }
            while (check() == true);    //keep scrambling until it's not in solved state
            scrambling = false;
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            AdjustControls();
            locations = new Point[last];

            for (int i = 0; i <= last; i++)
            {
                locations[i] = buttons[i].Location;
            }
            ClearGrid();
            AltGenerate(2); //regen so that positions are kept; without unscrambling 
            scrambled = false;
                      
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (var v in buttons)
            {
                v.Enabled = true;
            }
            
            dimX = Convert.ToInt32(cbDimX.SelectedItem);
            dimY = Convert.ToInt32(cbDimY.SelectedItem);
            ClearGrid();
            AltGenerate(1);
            moves = 0;
            lblMoves.Text = moves.ToString();
            scrambled = false;
        }

        }
}

