using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        delegate void DelegadoParaGrid(string[] mensaje, int codigo);


        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
<<<<<<< HEAD
=======
        }


        private void AtenderServidor ()
        {
            while (true)
            {
                byte[] msg2 = new byte[200];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];


                switch (codigo)
                {
                    case 1:
                         MessageBox.Show(mensaje);
                        break;

                    case 2:
                        MessageBox.Show(mensaje);
                        break;

                    case 4:
                        MessageBox.Show(mensaje);
                        break;

                    case 5:
                        MessageBox.Show(mensaje);
                        break;

                    case 999:
                        int numcon999 = Convert.ToInt32(mensaje);
                        dataGridView1.RowCount = numcon999;
                        dataGridView1.ColumnCount = 1;
                        for (int h = 2; h < trozos.Length;) // añadimos a los usuarios al datagridview
                        {
                            dataGridView1.Rows[h - 2].Cells[0].Value = trozos[h];
                            h++;
                        }
                        break;
                }


            }

>>>>>>> dev-v3
        }

        private void Form1_Close(object sender, EventArgs e)
        {
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + usuario.Text + "/" + password.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void consultas_Click(object sender, EventArgs e)
        {
            if (partidasganadas.Checked)
            {
                string mensaje = "4/" + nombre_partidasganadas.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (puntos.Checked)
            {
                string mensaje = "5/" + nombre_puntos.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + usuario1.Text + "/" + password1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            //IPAddress direc = IPAddress.Parse("147.83.117.22");
            //IPEndPoint ipep = new IPEndPoint(direc, 50073);
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9031);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();


        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos

            dataGridView1.Rows.Clear();
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9022);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] word = mensaje.Split('/');
            listBox1.Items.Clear();
            foreach (string item in word)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
