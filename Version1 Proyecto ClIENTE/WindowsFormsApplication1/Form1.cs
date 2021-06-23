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
        string usuario_pc;
        string mensaje_chat;
        public string mensaje_invitados;
        public int cont_anadidos = 0;
        List<String> anadir_chat = new List<String>();
        Socket server;
        Thread atender;
        int nForm = 0;

        bool anadir = true;
        delegate void DelegadoMostrarVentanas();
        delegate void DelegadoParaEnviarChatMain(int partida, string autor, string mensaje);
        delegate void DelegadoListaConectados(int numcon999, string[] trozos);


        List<Form2> formularios = new List<Form2>();
        

        internal static Form2 form2;
        internal static Form1 form1;


        public Form1()
        {
            InitializeComponent();
            form1 = this;
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = Color.FromArgb(35, 32, 39);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.GridColor = Color.FromArgb(0, 0, 0);
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 32, 39);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Green;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Juego.Visible = false;
            groupBox2.Visible = false;
            //groupBox1.Visible = true;
            //Registro.Visible = true;
        }

        private void MostrarVentanas()
        {
            groupBox2.Visible = true;
            Juego.Visible = true;
            groupBox1.Visible = false;
            Registro.Visible = false;
        }

        public void PonerEnGrid(int numcon999, string[] trozos)
        {//metodo para poner en el datagridview los nombres de los usuarios conectados
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
        {//bucle de atencion a las peticiones del servidor
            while (true)
            {
                byte[] msg2 = new byte[200];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];                
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                


                switch (codigo)
                {
                    case 1://log in
                        MessageBox.Show(trozos[1]);
                        string mensajerecivido = trozos[1];
                        string logincorrecto = "Sesion iniciada correctamente";
                        if (string.Equals(mensajerecivido, logincorrecto))
                        {
                            DelegadoMostrarVentanas ventanas = new DelegadoMostrarVentanas(MostrarVentanas);
                            groupBox2.Invoke(ventanas, new object[] { });
                            Juego.Invoke(ventanas, new object[] { });
                            groupBox1.Invoke(ventanas, new object[] { });
                            Registro.Invoke(ventanas, new object[] { });

                        }                                                
                        break;

                    case 2://registro
                        MessageBox.Show(trozos[1]);
                        break;

                    case 4://consulta
                        MessageBox.Show(trozos[1]);
                        break;

                    case 5://consulta
                        MessageBox.Show(trozos[1]);
                        break;

                    case 7://peticion para los invitados
                        string anfitrion = trozos[2];
                        partida = Convert.ToInt32(trozos[1]);
                        string MessageBoxTitle = "Invitación de chat";
                        string MessageBoxContent = anfitrion + " te ha invitado a un chat cond id " + partida + "\n Deseas aceptarlo?";
                        string respuesta_invitation;
                        DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
  
                                respuesta_invitation = "8/" + anfitrion + "/" + partida + "/" + usuario.Text + "/" + Convert.ToString(result) + "/1";
                                byte[] accept = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);                             
                                server.Send(accept);
                                ServicioChats(usuario_pc, partida);
                                break;
                            case DialogResult.No:
                                respuesta_invitation = "8/" + anfitrion + "/" + partida + "/" + usuario.Text + "/" + Convert.ToString(result) + "/0";
                                byte[] decline = System.Text.Encoding.ASCII.GetBytes(respuesta_invitation);
                                server.Send(decline);
                                break;
                        }
                        
                        break;

                    case 8://respuesta del anfitrion sobre las invitaciones
                        partida = Convert.ToInt32(trozos[1]);
                        string invitado = trozos[2];
                        string respuesta_inv = trozos[3];
                        MessageBox.Show("Respuesta del invitado " + invitado + " al chat de id " + partida + " es " + respuesta_inv);
                        if (respuesta_inv == "Yes")
                        {
                            ServicioChats(usuario_pc, partida);
                        }
                        break;

                    case 9://recebir mensaje del chat                        
                        int partida9 = Convert.ToInt32(trozos[1]);
                        autor = trozos[2];
                        mensaje_chat = trozos[3];
                        EnviarChatForm(partida9, autor, mensaje_chat);
                        //DelegadoParaEnviarChatMain delegado9 = new DelegadoParaEnviarChatMain(EnviarChatForm);
                        //this.Invoke(delegado9, new object[] { partida9, autor, mensaje_chat });
                        break;

                    case 999://notificaciones de conexion

                        int numcon999 = Convert.ToInt32(trozos[1]);
                        DelegadoListaConectados delegado999 = new DelegadoListaConectados(PonerEnGrid);
                        dataGridView1.Invoke(delegado999, new object[] { numcon999, trozos });
                        break;
                }


            }

        }

        private void Form1_Close(object sender, EventArgs e)
        {
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

        

        private void button2_Click(object sender, EventArgs e)
        {//boton para el login
            if (String.IsNullOrEmpty(usuario.Text) | String.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Error en la introduccion de datos, vuelva a probar");
            }
            else
            {
                string mensaje = "1/" + usuario.Text + "/" + password.Text;
                usuario_pc = usuario.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                chateador_1.Text = "";
                chateador_1.SelectionColor = Color.White;
                chateador_1.AppendText(usuario_pc);
                chateador_1.SelectionAlignment = HorizontalAlignment.Center;
            }                     

        }

        private void consultas_Click(object sender, EventArgs e)
        {//apartado de consultas
            if (chatsconcurrentes.Checked)
            {
                string mensaje = "4/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (ParticipantesChat.Checked)
            {
                if (id_chat.Text != null)
                {

                    string mensaje = "5/" + id_chat.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    id_chat.Text = "";

                }
                else
                    MessageBox.Show("Introduzca una id de chat valido");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Registrarse_Click(object sender, EventArgs e)
        {//boton de regsitro
            string mensaje = "2/" + usuario1.Text + "/" + password1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {//metodo de conexion al servidor
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50073);
            //IPAddress direc = IPAddress.Parse("192.168.56.101");
            //IPEndPoint ipep = new IPEndPoint(direc, 9026);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackgroundImage = Properties.Resources.fondoCHATAGRAM;
                //this.BackColor = Color.Coral;
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
        {//boton para invitar a una partida los usuarios elegidos         
            if (anadir_chat.Count() == 0)
            {
                MessageBox.Show("Por favor seleccione a alguien");
            }
            else
            {
                //var random = new Random();
                //int partida = random.Next(1000);

                mensaje_invitados = "7/" + /*partida + "/" +*/ usuario.Text + "/";

                int i;
                for (i = 0; i < anadir_chat.Count(); i++)
                {
                    mensaje_invitados = mensaje_invitados + anadir_chat[i] + "/";
                }
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje_invitados);
                server.Send(msg);
            }



            //string invitacion_partida = dataGridView1.SelectedCells[0].Value.ToString();
            //string mensaje = "7/" + usuario.Text + "/" + invitacion_partida;
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            //server.Send(msg);


        }

        public void ServicioChats(string usuario, int partida)
        {//iniciamos thread para los chats abiertos

            ThreadStart ts = delegate { Iniciar_Partida(usuario, partida); };
            Thread T = new Thread(ts);
            T.Start();

        }

        public void Iniciar_Partida(string usuario, int partida)
        {//iniciamos chat
            nForm = nForm + 1;
            int cont = partida;
            Form2 f2 = new Form2(cont, server, usuario);          
            //formpartidas_chat[form_chat] = (f2);
            //form_chat = form_chat + 1;
            formularios.Add(f2);
            f2.ShowDialog();
            
        }

        public void EnviarChatForm(int partida9, string autor, string mensaje_chat)
        {//metodo para enviar chat al form correspondiente
            int n = 0;
            
            for (n = 0; n < nForm ; n++)
            {
                if (formularios[n].getId() == partida9)
                {
                    formularios[n].RecibirChat(autor, mensaje_chat);
                }

            }
            //if (formularios[n].getId() == partida9)
            //{
            //    formularios[n].RecibirChat(autor, mensaje_chat);
            //    n++;
            //}

            //formularios[partida9].RecibirChat(autor, mensaje_chat);
            //for (int i = 0; i < VectorChats.Count(); i++)
            //{
            //    if (VectorChats[i] == partida)
            //    {
            //        formpartidas_chat[i].RecibirChat(partida9, autor, mensaje_chat);
            //    }
            //}            
        }

        private void AnadirChat_Click(object sender, EventArgs e)
        {//metodo para añadir gente a la lista de un futuro posible nuevo chat
            if (anadir)
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    int i;
                    int encontrado = 0;
                    for (i = 0; i < anadir_chat.Count(); i++)
                    {
                        if (anadir_chat[i] == Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value))
                        {
                            MessageBox.Show("El usuario ya ha sido invitado");
                            encontrado = 1;
                            break;
                        }

                    }
                    if (encontrado == 0)
                    {
                        anadir_chat.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                        cont_anadidos++;
                        if (cont_anadidos == 1)
                        {

                            chateador_2.SelectionColor = Color.White;
                            chateador_2.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            chateador_2.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 2)
                        {

                            chateador_3.SelectionColor = Color.White;
                            chateador_3.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            chateador_3.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 3)
                        {

                            chateador_4.SelectionColor = Color.White;
                            chateador_4.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            chateador_4.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else if (cont_anadidos == 4)
                        {

                            chateador_5.SelectionColor = Color.White;
                            chateador_5.AppendText(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                            chateador_5.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        else
                            MessageBox.Show("No se pueden añadir más jugadores");
                    }
                }
                else
                    MessageBox.Show("Seleccione con quien jugar");
            }
        }

        private void Eliminar_Chateadores_Click(object sender, EventArgs e)
        {//eliminar de la lista de futuro posible chat
            if (cont_anadidos != 0)
            {
                anadir_chat.Remove(anadir_chat[cont_anadidos - 1]);

                if (cont_anadidos == 1)
                {
                    chateador_2.Clear();
                }
                else if (cont_anadidos == 2)
                {
                    chateador_3.Clear();
                }
                else if (cont_anadidos == 3)
                {
                    chateador_4.Clear();
                }
                else if (cont_anadidos == 4)
                {
                    chateador_5.Clear();
                }
                cont_anadidos = cont_anadidos - 1;
            }

            else
            {
                MessageBox.Show("Ningún usuario añadido");
            }
        }
    }
}
