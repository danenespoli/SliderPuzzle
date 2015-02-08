namespace New_Slider
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScramble = new System.Windows.Forms.Button();
            this.cbDimX = new System.Windows.Forms.ComboBox();
            this.lblMovesText = new System.Windows.Forms.Label();
            this.lblMoves = new System.Windows.Forms.Label();
            this.cbDimY = new System.Windows.Forms.ComboBox();
            this.lblDimXText = new System.Windows.Forms.Label();
            this.lblDimYText = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pbSolved = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSolved)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScramble
            // 
            this.btnScramble.Location = new System.Drawing.Point(613, 26);
            this.btnScramble.Name = "btnScramble";
            this.btnScramble.Size = new System.Drawing.Size(128, 46);
            this.btnScramble.TabIndex = 0;
            this.btnScramble.Text = "Scramble!";
            this.btnScramble.UseVisualStyleBackColor = true;
            this.btnScramble.Click += new System.EventHandler(this.btnScramble_Click_1);
            // 
            // cbDimX
            // 
            this.cbDimX.FormattingEnabled = true;
            this.cbDimX.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5\t",
            "6",
            "7",
            "8\t",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbDimX.Location = new System.Drawing.Point(613, 98);
            this.cbDimX.Name = "cbDimX";
            this.cbDimX.Size = new System.Drawing.Size(62, 21);
            this.cbDimX.TabIndex = 1;
            // 
            // lblMovesText
            // 
            this.lblMovesText.AutoSize = true;
            this.lblMovesText.Location = new System.Drawing.Point(613, 201);
            this.lblMovesText.Name = "lblMovesText";
            this.lblMovesText.Size = new System.Drawing.Size(42, 13);
            this.lblMovesText.TabIndex = 2;
            this.lblMovesText.Text = "Moves:";
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoves.Location = new System.Drawing.Point(661, 201);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(14, 13);
            this.lblMoves.TabIndex = 3;
            this.lblMoves.Text = "0";
            // 
            // cbDimY
            // 
            this.cbDimY.FormattingEnabled = true;
            this.cbDimY.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5\t",
            "6",
            "7",
            "8\t",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbDimY.Location = new System.Drawing.Point(679, 98);
            this.cbDimY.Name = "cbDimY";
            this.cbDimY.Size = new System.Drawing.Size(62, 21);
            this.cbDimY.TabIndex = 4;
            // 
            // lblDimXText
            // 
            this.lblDimXText.AutoSize = true;
            this.lblDimXText.Location = new System.Drawing.Point(613, 82);
            this.lblDimXText.Name = "lblDimXText";
            this.lblDimXText.Size = new System.Drawing.Size(12, 13);
            this.lblDimXText.TabIndex = 5;
            this.lblDimXText.Text = "x";
            // 
            // lblDimYText
            // 
            this.lblDimYText.AutoSize = true;
            this.lblDimYText.Location = new System.Drawing.Point(682, 82);
            this.lblDimYText.Name = "lblDimYText";
            this.lblDimYText.Size = new System.Drawing.Size(12, 13);
            this.lblDimYText.TabIndex = 6;
            this.lblDimYText.Text = "y";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(613, 125);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 25);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pbSolved
            // 
            this.pbSolved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSolved.Location = new System.Drawing.Point(613, 280);
            this.pbSolved.Name = "pbSolved";
            this.pbSolved.Size = new System.Drawing.Size(128, 128);
            this.pbSolved.TabIndex = 8;
            this.pbSolved.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 567);
            this.Controls.Add(this.pbSolved);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblDimYText);
            this.Controls.Add(this.lblDimXText);
            this.Controls.Add(this.cbDimY);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.lblMovesText);
            this.Controls.Add(this.cbDimX);
            this.Controls.Add(this.btnScramble);
            this.Name = "Form1";
            this.Text = "Slide Puzzle!";
            this.SizeChanged += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbSolved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScramble;
        private System.Windows.Forms.ComboBox cbDimX;
        private System.Windows.Forms.Label lblMovesText;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.ComboBox cbDimY;
        private System.Windows.Forms.Label lblDimXText;
        private System.Windows.Forms.Label lblDimYText;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pbSolved;
    }
}

