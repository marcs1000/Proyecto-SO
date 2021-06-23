namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Enviar_chat = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.escribir_chat = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox3.Controls.Add(this.Enviar_chat);
            this.groupBox3.Controls.Add(this.chat);
            this.groupBox3.Controls.Add(this.escribir_chat);
            this.groupBox3.Location = new System.Drawing.Point(75, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 564);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chat";
            // 
            // Enviar_chat
            // 
            this.Enviar_chat.Location = new System.Drawing.Point(254, 525);
            this.Enviar_chat.Name = "Enviar_chat";
            this.Enviar_chat.Size = new System.Drawing.Size(79, 22);
            this.Enviar_chat.TabIndex = 12;
            this.Enviar_chat.Text = "Enviar";
            this.Enviar_chat.UseVisualStyleBackColor = true;
            this.Enviar_chat.Click += new System.EventHandler(this.Enviar_chat_Click);
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(15, 19);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(318, 488);
            this.chat.TabIndex = 10;
            this.chat.Text = "";
            // 
            // escribir_chat
            // 
            this.escribir_chat.Location = new System.Drawing.Point(15, 527);
            this.escribir_chat.Name = "escribir_chat";
            this.escribir_chat.Size = new System.Drawing.Size(217, 20);
            this.escribir_chat.TabIndex = 11;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 595);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form2";
            this.Text = "Chat";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Enviar_chat;
        private System.Windows.Forms.RichTextBox chat;
        private System.Windows.Forms.TextBox escribir_chat;
    }
}