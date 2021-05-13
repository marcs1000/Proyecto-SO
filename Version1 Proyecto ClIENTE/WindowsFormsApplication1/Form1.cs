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
        private int partida;
        string autor;
        string mensaje_chat;
        Socket server;
        Thread atender;

        delegate void DelegadoParaEnviarChatMain(int partida, string autor, string mensaje);
        delegate void DelegadoListaConectados(int numcon999, string[] trozos);



        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void PonerEnGrid(int numcon999, string[] trozos)
        {
            if (numcon999 == 0)
                dataGridView1.Rows.Clear();
            else
            {
                dataGridView1.RowCount = numcon999;
                dataGridView1.ColumnCount = 1;
                for (int h = 2; h < trozos.Length;) // añadimos a los usuarios al datagridview
                {
                    dataGridView1.Rows[h - 2].Cells[0].Value = trozos[h];
                    h++;
                }
            }
        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[200];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];                
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);


                switch (codigo)
                {
                    case 1:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 2:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 4:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 5:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 7:
                        string anfitrion = trozos[2];
                        partida = Convert.ToInt32(trozos[1]);
                        string MessageBoxTitle = "Invitación de partida";
                        string MessageBoxContent = anfitrion + " te ha retado a una partida\n Deseas aceptarla? ";
                        string respuesta_invitation;
                        DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
  
                                respuesta_invitation = "8/" + anfitrion + "/" + partida + "/" + usuario.Text + "/" + Convert.ToString(result) + "/1";
                                byte[] accept = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);
                                server.Send(accept);
                                break;
                            case DialogResult.No:
                                respuesta_invitation = "8/" + anfitrion + "/" + partida + "/" + usuario.Text + "/" + Convert.ToString(result) + "/0";
                                byte[] decline = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);
                                server.Send(decline);
                                break;
                        }
                        
                        break;

                    case 8:
                        partida = Convert.ToInt32(trozos[1]);
                        string invitado = trozos[2];
                        string respuesta_inv = trozos[3];
                        MessageBox.Show("Respuesta del invitado " + invitado + " a la partida " + partida + " del juego  es " + respuesta_inv);
                        if (respuesta_inv == "Yes")
                        {
                            
                        }
                        break;

                    case 9:                       
                        int partida9 = Convert.ToInt32(trozos[1]);
                        autor = trozos[2];
                        mensaje_chat = trozos[3];
                        DelegadoParaEnviarChatMain delegado9 = new DelegadoParaEnviarChatMain(RecibirChat);
                        this.Invoke(delegado9, new object[] { partida9, autor, mensaje_chat });
                        break;

                    case 999:

                        int numcon999 = Convert.ToInt32(trozos[1]);
                        DelegadoListaConectados delegado999 = new DelegadoListaConectados(PonerEnGrid);
                        dataGridView1.Invoke(delegado999, new object[] { numcon999, trozos });
                        break;
                }


            }

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
            IPEndPoint ipep = new IPEndPoint(direc, 9027);


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
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Invitar_Click(object sender, EventArgs e)
        {

            string invitacion_partida = dataGridView1.SelectedCells[0].Value.ToString();
            string mensaje = "7/" + usuario.Text + "/" + invitacion_partida;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


        }

        private void Enviar_chat_Click(object sender, EventArgs e)
        {
            int partida_enviada = partida;
            string mensaje_chat = "9/" + partida_enviada + "/" + usuario.Text + "/" + escribir_chat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje_chat);
            server.Send(msg);
        }

        public void RecibirChat(int partida, string autor, string msg)
        {
            chat.SelectionFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            chat.SelectionColor = Color.Green;
            chat.AppendText(autor);
            chat.SelectionFont = new Font("Microsoft Sans Serif", 8);
            chat.SelectionColor = Color.Black;
            chat.AppendText(" :\n" + msg + "\r\n");
            chat.ScrollToCaret();
        }


    }
}
