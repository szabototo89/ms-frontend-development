namespace ELTE.EVA2.TicTacToe.View.View
{
    partial class NewGameForm
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
            this.playersGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.formLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.firstPlayer = new ELTE.EVA2.TicTacToe.View.View.PlayerEditor();
            this.secondPlayer = new ELTE.EVA2.TicTacToe.View.View.PlayerEditor();
            this.playersGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.formLayoutPanel.SuspendLayout();
            this.buttonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playersGroupBox
            // 
            this.playersGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.playersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersGroupBox.Location = new System.Drawing.Point(3, 3);
            this.playersGroupBox.Name = "playersGroupBox";
            this.playersGroupBox.Size = new System.Drawing.Size(518, 317);
            this.playersGroupBox.TabIndex = 0;
            this.playersGroupBox.TabStop = false;
            this.playersGroupBox.Text = "Players";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.firstPlayer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondPlayer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 298);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // formLayoutPanel
            // 
            this.formLayoutPanel.ColumnCount = 1;
            this.formLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayoutPanel.Controls.Add(this.playersGroupBox, 0, 0);
            this.formLayoutPanel.Controls.Add(this.buttonsLayoutPanel, 0, 1);
            this.formLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.formLayoutPanel.Name = "formLayoutPanel";
            this.formLayoutPanel.RowCount = 2;
            this.formLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayoutPanel.Size = new System.Drawing.Size(524, 358);
            this.formLayoutPanel.TabIndex = 0;
            // 
            // buttonsLayoutPanel
            // 
            this.buttonsLayoutPanel.AutoSize = true;
            this.buttonsLayoutPanel.ColumnCount = 2;
            this.buttonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonsLayoutPanel.Controls.Add(this.acceptButton, 0, 0);
            this.buttonsLayoutPanel.Controls.Add(this.cancelButton, 1, 0);
            this.buttonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsLayoutPanel.Location = new System.Drawing.Point(3, 326);
            this.buttonsLayoutPanel.Name = "buttonsLayoutPanel";
            this.buttonsLayoutPanel.RowCount = 1;
            this.buttonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.buttonsLayoutPanel.Size = new System.Drawing.Size(518, 29);
            this.buttonsLayoutPanel.TabIndex = 1;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.acceptButton.Location = new System.Drawing.Point(359, 3);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(440, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // firstPlayer
            // 
            this.firstPlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.firstPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstPlayer.Location = new System.Drawing.Point(3, 3);
            this.firstPlayer.Name = "firstPlayer";
            this.firstPlayer.Size = new System.Drawing.Size(506, 37);
            this.firstPlayer.TabIndex = 0;
            this.firstPlayer.Value = "Player 1";
            // 
            // secondPlayer
            // 
            this.secondPlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.secondPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondPlayer.Location = new System.Drawing.Point(3, 46);
            this.secondPlayer.Name = "secondPlayer";
            this.secondPlayer.Size = new System.Drawing.Size(506, 37);
            this.secondPlayer.TabIndex = 1;
            this.secondPlayer.Value = "Player 2";
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 368);
            this.Controls.Add(this.formLayoutPanel);
            this.Name = "NewGameForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "New Game";
            this.playersGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.formLayoutPanel.ResumeLayout(false);
            this.formLayoutPanel.PerformLayout();
            this.buttonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox playersGroupBox;
        private System.Windows.Forms.TableLayoutPanel formLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel buttonsLayoutPanel;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PlayerEditor firstPlayer;
        private PlayerEditor secondPlayer;
    }
}