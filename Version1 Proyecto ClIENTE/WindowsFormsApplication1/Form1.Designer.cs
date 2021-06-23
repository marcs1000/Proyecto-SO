namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.Juego = new System.Windows.Forms.GroupBox();
            this.id_chat = new System.Windows.Forms.TextBox();
            this.ParticipantesChat = new System.Windows.Forms.RadioButton();
            this.chatsconcurrentes = new System.Windows.Forms.RadioButton();
            this.consultas = new System.Windows.Forms.Button();
            this.Registro = new System.Windows.Forms.GroupBox();
            this.Registrarse = new System.Windows.Forms.Button();
            this.repetirpassword = new System.Windows.Forms.TextBox();
            this.password1 = new System.Windows.Forms.TextBox();
            this.usuario1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Conectar = new System.Windows.Forms.MenuStrip();
            this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Eliminar_Chateadores = new System.Windows.Forms.Button();
            this.chateador_5 = new System.Windows.Forms.RichTextBox();
            this.chateador_4 = new System.Windows.Forms.RichTextBox();
            this.chateador_3 = new System.Windows.Forms.RichTextBox();
            this.chateador_2 = new System.Windows.Forms.RichTextBox();
            this.chateador_1 = new System.Windows.Forms.RichTextBox();
            this.AnadirChat = new System.Windows.Forms.Button();
            this.Invitar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.Juego.SuspendLayout();
            this.Registro.SuspendLayout();
            this.Conectar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(147, 50);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(164, 20);
            this.usuario.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Log In";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.usuario);
            this.groupBox1.Location = new System.Drawing.Point(35, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 177);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contraseña";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(147, 98);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(164, 20);
            this.password.TabIndex = 9;
            this.password.UseSystemPasswordChar = true;
            // 
            // Juego
            // 
            this.Juego.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Juego.Controls.Add(this.id_chat);
            this.Juego.Controls.Add(this.ParticipantesChat);
            this.Juego.Controls.Add(this.chatsconcurrentes);
            this.Juego.Controls.Add(this.consultas);
            this.Juego.Location = new System.Drawing.Point(35, 60);
            this.Juego.Name = "Juego";
            this.Juego.Size = new System.Drawing.Size(281, 213);
            this.Juego.TabIndex = 7;
            this.Juego.TabStop = false;
            this.Juego.Text = "Consultas";
            // 
            // id_chat
            // 
            this.id_chat.Location = new System.Drawing.Point(71, 87);
            this.id_chat.Name = "id_chat";
            this.id_chat.Size = new System.Drawing.Size(165, 20);
            this.id_chat.TabIndex = 4;
            // 
            // ParticipantesChat
            // 
            this.ParticipantesChat.AutoSize = true;
            this.ParticipantesChat.Location = new System.Drawing.Point(54, 64);
            this.ParticipantesChat.Name = "ParticipantesChat";
            this.ParticipantesChat.Size = new System.Drawing.Size(222, 17);
            this.ParticipantesChat.TabIndex = 2;
            this.ParticipantesChat.TabStop = true;
            this.ParticipantesChat.Text = "Numero de participantes en el chat de ID;";
            this.ParticipantesChat.UseVisualStyleBackColor = true;
            // 
            // chatsconcurrentes
            // 
            this.chatsconcurrentes.AutoSize = true;
            this.chatsconcurrentes.Location = new System.Drawing.Point(54, 41);
            this.chatsconcurrentes.Name = "chatsconcurrentes";
            this.chatsconcurrentes.Size = new System.Drawing.Size(171, 17);
            this.chatsconcurrentes.TabIndex = 1;
            this.chatsconcurrentes.TabStop = true;
            this.chatsconcurrentes.Text = "Numero de chats concurrentes";
            this.chatsconcurrentes.UseVisualStyleBackColor = true;
            // 
            // consultas
            // 
            this.consultas.Location = new System.Drawing.Point(54, 174);
            this.consultas.Name = "consultas";
            this.consultas.Size = new System.Drawing.Size(75, 23);
            this.consultas.TabIndex = 0;
            this.consultas.Text = "Enviar";
            this.consultas.UseVisualStyleBackColor = true;
            this.consultas.Click += new System.EventHandler(this.consultas_Click);
            // 
            // Registro
            // 
            this.Registro.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Registro.Controls.Add(this.Registrarse);
            this.Registro.Controls.Add(this.repetirpassword);
            this.Registro.Controls.Add(this.password1);
            this.Registro.Controls.Add(this.usuario1);
            this.Registro.Controls.Add(this.label5);
            this.Registro.Controls.Add(this.label4);
            this.Registro.Controls.Add(this.label1);
            this.Registro.Location = new System.Drawing.Point(35, 263);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(333, 278);
            this.Registro.TabIndex = 8;
            this.Registro.TabStop = false;
            this.Registro.Text = "Registro";
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(155, 196);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(75, 23);
            this.Registrarse.TabIndex = 13;
            this.Registrarse.Text = "Sign Up";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // repetirpassword
            // 
            this.repetirpassword.Location = new System.Drawing.Point(155, 134);
            this.repetirpassword.Name = "repetirpassword";
            this.repetirpassword.Size = new System.Drawing.Size(156, 20);
            this.repetirpassword.TabIndex = 10;
            // 
            // password1
            // 
            this.password1.Location = new System.Drawing.Point(155, 95);
            this.password1.Name = "password1";
            this.password1.Size = new System.Drawing.Size(156, 20);
            this.password1.TabIndex = 11;
            // 
            // usuario1
            // 
            this.usuario1.Location = new System.Drawing.Point(155, 48);
            this.usuario1.Name = "usuario1";
            this.usuario1.Size = new System.Drawing.Size(156, 20);
            this.usuario1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 48);
            this.label5.TabIndex = 10;
            this.label5.Text = "Repetir \r\ncontraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // Conectar
            // 
            this.Conectar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.desconectarToolStripMenuItem});
            this.Conectar.Location = new System.Drawing.Point(0, 0);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(1003, 24);
            this.Conectar.TabIndex = 9;
            this.Conectar.Text = "Conectar";
            // 
            // conectarToolStripMenuItem
            // 
            this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
            this.conectarToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.conectarToolStripMenuItem.Text = "Conectar";
            this.conectarToolStripMenuItem.Click += new System.EventHandler(this.conectarToolStripMenuItem_Click);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.desconectarToolStripMenuItem.Text = "Desconectar";
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Controls.Add(this.Eliminar_Chateadores);
            this.groupBox2.Controls.Add(this.chateador_5);
            this.groupBox2.Controls.Add(this.chateador_4);
            this.groupBox2.Controls.Add(this.chateador_3);
            this.groupBox2.Controls.Add(this.chateador_2);
            this.groupBox2.Controls.Add(this.chateador_1);
            this.groupBox2.Controls.Add(this.AnadirChat);
            this.groupBox2.Controls.Add(this.Invitar);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(472, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 479);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Conectados";
            // 
            // Eliminar_Chateadores
            // 
            this.Eliminar_Chateadores.Location = new System.Drawing.Point(226, 368);
            this.Eliminar_Chateadores.Name = "Eliminar_Chateadores";
            this.Eliminar_Chateadores.Size = new System.Drawing.Size(168, 29);
            this.Eliminar_Chateadores.TabIndex = 8;
            this.Eliminar_Chateadores.Text = "Eliminar usuarios";
            this.Eliminar_Chateadores.UseVisualStyleBackColor = true;
            this.Eliminar_Chateadores.Click += new System.EventHandler(this.Eliminar_Chateadores_Click);
            // 
            // chateador_5
            // 
            this.chateador_5.BackColor = System.Drawing.Color.Black;
            this.chateador_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chateador_5.ForeColor = System.Drawing.Color.White;
            this.chateador_5.Location = new System.Drawing.Point(227, 323);
            this.chateador_5.Name = "chateador_5";
            this.chateador_5.Size = new System.Drawing.Size(168, 32);
            this.chateador_5.TabIndex = 7;
            this.chateador_5.Text = "";
            // 
            // chateador_4
            // 
            this.chateador_4.BackColor = System.Drawing.Color.Black;
            this.chateador_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chateador_4.ForeColor = System.Drawing.Color.White;
            this.chateador_4.Location = new System.Drawing.Point(227, 254);
            this.chateador_4.Name = "chateador_4";
            this.chateador_4.Size = new System.Drawing.Size(168, 32);
            this.chateador_4.TabIndex = 6;
            this.chateador_4.Text = "";
            // 
            // chateador_3
            // 
            this.chateador_3.BackColor = System.Drawing.Color.Black;
            this.chateador_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chateador_3.ForeColor = System.Drawing.Color.White;
            this.chateador_3.Location = new System.Drawing.Point(227, 181);
            this.chateador_3.Name = "chateador_3";
            this.chateador_3.Size = new System.Drawing.Size(168, 32);
            this.chateador_3.TabIndex = 5;
            this.chateador_3.Text = "";
            // 
            // chateador_2
            // 
            this.chateador_2.BackColor = System.Drawing.Color.Black;
            this.chateador_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chateador_2.ForeColor = System.Drawing.Color.White;
            this.chateador_2.Location = new System.Drawing.Point(227, 109);
            this.chateador_2.Name = "chateador_2";
            this.chateador_2.Size = new System.Drawing.Size(168, 32);
            this.chateador_2.TabIndex = 4;
            this.chateador_2.Text = "";
            // 
            // chateador_1
            // 
            this.chateador_1.BackColor = System.Drawing.Color.Black;
            this.chateador_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chateador_1.ForeColor = System.Drawing.Color.White;
            this.chateador_1.Location = new System.Drawing.Point(227, 42);
            this.chateador_1.Name = "chateador_1";
            this.chateador_1.Size = new System.Drawing.Size(168, 32);
            this.chateador_1.TabIndex = 3;
            this.chateador_1.Text = "";
            // 
            // AnadirChat
            // 
            this.AnadirChat.Location = new System.Drawing.Point(15, 423);
            this.AnadirChat.Name = "AnadirChat";
            this.AnadirChat.Size = new System.Drawing.Size(104, 39);
            this.AnadirChat.TabIndex = 2;
            this.AnadirChat.Text = "Añadir a Chat";
            this.AnadirChat.UseVisualStyleBackColor = true;
            this.AnadirChat.Click += new System.EventHandler(this.AnadirChat_Click);
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(226, 423);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(168, 39);
            this.Invitar.TabIndex = 1;
            this.Invitar.Text = "Crear Chat";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(179, 388);
            this.dataGridView1.TabIndex = 0;
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(WindowsFormsApplication1.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1003, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Registro);
            this.Controls.Add(this.Juego);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Conectar);
            this.Name = "Form1";
            this.Text = "Pantalla Inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Juego.ResumeLayout(false);
            this.Juego.PerformLayout();
            this.Registro.ResumeLayout(false);
            this.Registro.PerformLayout();
            this.Conectar.ResumeLayout(false);
            this.Conectar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox Juego;
        private System.Windows.Forms.TextBox id_chat;
        private System.Windows.Forms.RadioButton ParticipantesChat;
        private System.Windows.Forms.RadioButton chatsconcurrentes;
        private System.Windows.Forms.Button consultas;
        private System.Windows.Forms.GroupBox Registro;
        private System.Windows.Forms.TextBox repetirpassword;
        private System.Windows.Forms.TextBox password1;
        private System.Windows.Forms.TextBox usuario1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.MenuStrip Conectar;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Button AnadirChat;
        private System.Windows.Forms.RichTextBox chateador_1;
        private System.Windows.Forms.RichTextBox chateador_5;
        private System.Windows.Forms.RichTextBox chateador_4;
        private System.Windows.Forms.RichTextBox chateador_3;
        private System.Windows.Forms.RichTextBox chateador_2;
        private System.Windows.Forms.Button Eliminar_Chateadores;
    }
}

