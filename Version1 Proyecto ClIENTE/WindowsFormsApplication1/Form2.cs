using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {

        public string mensaje_chat;
        public string enviarChat;
        string usuario;

        int idpartida;
        Socket server;

        public Form2(int idpartida, Socket server, string usuario)
        {
            InitializeComponent();
            this.idpartida = idpartida;
            this.server = server;
            this.usuario = usuario;

            CheckForIllegalCrossThreadCalls = false;

            this.BackColor = Color.Turquoise;

        }

        public int getId()
        {
            return idpartida;
        }

        public string getchat()
        {
            return enviarChat;
        }

        public void RecibirChat(string autor, string msg)
        {//funcion par mostrar por pantalla los mensajes recibidos
            if (autor == usuario)
            {
                chat.SelectionFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                chat.SelectionColor = Color.Green;
                //chat.AppendText(autor);
                chat.AppendText(autor);
                chat.SelectionAlignment = HorizontalAlignment.Right;
                chat.SelectionFont = new Font("Microsoft Sans Serif", 8);
                chat.SelectionColor = Color.Black;
                chat.AppendText(" :\n" + msg + "\r\n");
                chat.SelectionAlignment = HorizontalAlignment.Right;
                //chat.AppendText(" :\n" + msg + "\r\n");
                chat.ScrollToCaret();
            }
            else
            {
                chat.SelectionFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                chat.SelectionColor = Color.Green;
                chat.AppendText(autor);
                chat.SelectionAlignment = HorizontalAlignment.Left;
                chat.SelectionFont = new Font("Microsoft Sans Serif", 8);
                chat.SelectionColor = Color.Black;
                chat.AppendText(" :\n" + msg + "\r\n");
                chat.SelectionAlignment = HorizontalAlignment.Left;
                chat.ScrollToCaret();
            }
           
        }

        private void Enviar_chat_Click(object sender, EventArgs e)
        {//enviar mensajes al otro usuario
            int partida_enviada = idpartida;
            string mensaje_chat = "9/" + partida_enviada + "/" + usuario + "/" + escribir_chat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje_chat);
            server.Send(msg);
            escribir_chat.Text = "";
        }
    }
}
