namespace Hemming
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Stat = new System.Windows.Forms.RichTextBox();
            this.Stat2 = new System.Windows.Forms.RichTextBox();
            this.Recv = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.TextBox();
            this.ErrorText = new System.Windows.Forms.ToolStripStatusLabel();
            this.Transmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stat
            // 
            this.Stat.Location = new System.Drawing.Point(4, 45);
            this.Stat.Margin = new System.Windows.Forms.Padding(2);
            this.Stat.Name = "Stat";
            this.Stat.ReadOnly = true;
            this.Stat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Stat.Size = new System.Drawing.Size(317, 347);
            this.Stat.TabIndex = 0;
            this.Stat.Text = "";
            this.Stat.TextChanged += new System.EventHandler(this.Stat_TextChanged);
            // 
            // Stat2
            // 
            this.Stat2.Location = new System.Drawing.Point(340, 47);
            this.Stat2.Margin = new System.Windows.Forms.Padding(2);
            this.Stat2.Name = "Stat2";
            this.Stat2.ReadOnly = true;
            this.Stat2.Size = new System.Drawing.Size(317, 347);
            this.Stat2.TabIndex = 1;
            this.Stat2.Text = "";
            this.Stat2.TextChanged += new System.EventHandler(this.Stat2_TextChanged);
            // 
            // Recv
            // 
            this.Recv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Recv.Location = new System.Drawing.Point(340, 18);
            this.Recv.Margin = new System.Windows.Forms.Padding(2);
            this.Recv.MaxLength = 999;
            this.Recv.Name = "Recv";
            this.Recv.Size = new System.Drawing.Size(203, 26);
            this.Recv.TabIndex = 2;
            this.Recv.TextChanged += new System.EventHandler(this.Recv_TextChanged);
            this.Recv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Recv_KeyPress);
            // 
            // Send
            // 
            this.Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Send.Location = new System.Drawing.Point(4, 15);
            this.Send.Margin = new System.Windows.Forms.Padding(2);
            this.Send.MaxLength = 999;
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(203, 26);
            this.Send.TabIndex = 3;
            this.Send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Send_KeyPress);
            // 
            // ErrorText
            // 
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(23, 23);
            // 
            // Transmit
            // 
            this.Transmit.Location = new System.Drawing.Point(547, 19);
            this.Transmit.Margin = new System.Windows.Forms.Padding(2);
            this.Transmit.Name = "Transmit";
            this.Transmit.Size = new System.Drawing.Size(110, 26);
            this.Transmit.TabIndex = 5;
            this.Transmit.Text = "Передать";
            this.Transmit.UseVisualStyleBackColor = true;
            this.Transmit.Click += new System.EventHandler(this.Transmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Stat);
            this.groupBox1.Controls.Add(this.Stat2);
            this.groupBox1.Controls.Add(this.Transmit);
            this.groupBox1.Controls.Add(this.Recv);
            this.groupBox1.Controls.Add(this.Send);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(670, 426);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(680, 408);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(353, 332);
            this.Name = "Form1";
            this.Text = "Модифицированный код Хемминга";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Stat;
        private System.Windows.Forms.RichTextBox Stat2;
        private System.Windows.Forms.TextBox Recv;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ErrorText;
        private System.Windows.Forms.Button Transmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox Send;
    }
}

