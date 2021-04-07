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
            this.label2 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.Juego = new System.Windows.Forms.GroupBox();
            this.nombre_puntos = new System.Windows.Forms.TextBox();
            this.nombre_partidasganadas = new System.Windows.Forms.TextBox();
            this.puntos = new System.Windows.Forms.RadioButton();
            this.partidasganadas = new System.Windows.Forms.RadioButton();
            this.consultas = new System.Windows.Forms.Button();
            this.Registro = new System.Windows.Forms.GroupBox();
            this.Registrarse = new System.Windows.Forms.Button();
            this.repetirpassword = new System.Windows.Forms.TextBox();
            this.password1 = new System.Windows.Forms.TextBox();
            this.usuario1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Juego.SuspendLayout();
            this.Registro.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(23, 45);
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
            // 
            // Juego
            // 
            this.Juego.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Juego.Controls.Add(this.nombre_puntos);
            this.Juego.Controls.Add(this.nombre_partidasganadas);
            this.Juego.Controls.Add(this.puntos);
            this.Juego.Controls.Add(this.partidasganadas);
            this.Juego.Controls.Add(this.consultas);
            this.Juego.Location = new System.Drawing.Point(407, 45);
            this.Juego.Name = "Juego";
            this.Juego.Size = new System.Drawing.Size(551, 509);
            this.Juego.TabIndex = 7;
            this.Juego.TabStop = false;
            this.Juego.Text = "Consultas";
            // 
            // nombre_puntos
            // 
            this.nombre_puntos.Location = new System.Drawing.Point(71, 121);
            this.nombre_puntos.Name = "nombre_puntos";
            this.nombre_puntos.Size = new System.Drawing.Size(165, 20);
            this.nombre_puntos.TabIndex = 4;
            // 
            // nombre_partidasganadas
            // 
            this.nombre_partidasganadas.Location = new System.Drawing.Point(71, 64);
            this.nombre_partidasganadas.Name = "nombre_partidasganadas";
            this.nombre_partidasganadas.Size = new System.Drawing.Size(165, 20);
            this.nombre_partidasganadas.TabIndex = 3;
            // 
            // puntos
            // 
            this.puntos.AutoSize = true;
            this.puntos.Location = new System.Drawing.Point(54, 98);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(116, 17);
            this.puntos.TabIndex = 2;
            this.puntos.TabStop = true;
            this.puntos.Text = "Puntos del jugador:";
            this.puntos.UseVisualStyleBackColor = true;
            // 
            // partidasganadas
            // 
            this.partidasganadas.AutoSize = true;
            this.partidasganadas.Location = new System.Drawing.Point(54, 41);
            this.partidasganadas.Name = "partidasganadas";
            this.partidasganadas.Size = new System.Drawing.Size(187, 17);
            this.partidasganadas.TabIndex = 1;
            this.partidasganadas.TabStop = true;
            this.partidasganadas.Text = "ID de la ultima partida ganada por:";
            this.partidasganadas.UseVisualStyleBackColor = true;
            // 
            // consultas
            // 
            this.consultas.Location = new System.Drawing.Point(54, 370);
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
            this.Registro.Location = new System.Drawing.Point(23, 247);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 579);
            this.Controls.Add(this.Registro);
            this.Controls.Add(this.Juego);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Juego.ResumeLayout(false);
            this.Juego.PerformLayout();
            this.Registro.ResumeLayout(false);
            this.Registro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox Juego;
        private System.Windows.Forms.TextBox nombre_puntos;
        private System.Windows.Forms.TextBox nombre_partidasganadas;
        private System.Windows.Forms.RadioButton puntos;
        private System.Windows.Forms.RadioButton partidasganadas;
        private System.Windows.Forms.Button consultas;
        private System.Windows.Forms.GroupBox Registro;
        private System.Windows.Forms.TextBox repetirpassword;
        private System.Windows.Forms.TextBox password1;
        private System.Windows.Forms.TextBox usuario1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Registrarse;
    }
}

