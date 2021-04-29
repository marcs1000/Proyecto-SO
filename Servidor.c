#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>


typedef struct {
	char nombre [20];
	int socket;
} Conectado;
typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;
//meter las comsultas fuera del bucle del server
int contador;

ListaConectados miLista;


//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int DameSocket (ListaConectados *lista, char usuario[20]){
	//Devuelve el socket o -1 si no esta en la lista
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,usuario)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados [i].socket;
	else
		return -1;
}


int DamePosicionSocket (ListaConectados *lista,int socket){ //retorna la posicion del socket en la lista o -1  si no encuentra el socket en la lista

	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado)
	{
		if (lista->conectados[i].socket==socket)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}


void EliminarPosicion(ListaConectados *lista,int posicion){ //elimina lo que hay en una posicion de la lista de  conectados
	//funcion para eliminar el usuario inicial que se inserta para provar la correcta conexi￯﾿ﾳn del socket y no depender de una lista de sockets antes de insertar al usuario real

	if(lista->num>posicion)
	{
		int i;
		for (i=posicion;i<lista->num -1;i++)
		{
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
	}
}


void DameConectados (ListaConectados *lista,char conectados[300]){

	sprintf(conectados,"%d",lista->num);
	int i;
	for (i=0;i<lista->num;i++)
		sprintf(conectados,"%s/%s",conectados,lista->conectados[i].nombre);
	
}


int DamePosicion (ListaConectados *lista,char usuario[20]){ //retorna la posicion del jugador en la lista, retorna -1 si no encuentra al jugador en la lista

	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,usuario)==0)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}


int Eliminar (ListaConectados *lista,char usuario[20]){ //esta funcion retorna -1 si no encuentra el nombre que se debe eliminar de la lista y 0 si se ha eliminado correctamente

	int pos = DamePosicion (lista,usuario);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<lista->num -1;i++)
		{
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
		return 0;
	}
}


int Pon (ListaConectados *lista,char usuario[20],int socket){ //funcion para introducir a un usuario a la lista de usuarios conectados
	
	
	
	//retorna -1 si la lista esta llena,retorna 0 si ha introducido correctamente al usuario, retorna -2 si el usuario ya se encuentra en la lista
	int encontrado=0;
	int i=0;
	if (lista->num==100)
		return -1;
	else
	{
		while (i<lista->num && encontrado==0 )
		{
			if (strcmp(lista->conectados[i].nombre,usuario)==0)
			{
				encontrado=1;
				break;
			}
			i=i+1;
		}
		
		if (encontrado==0) {
			strcpy(lista->conectados[lista->num].nombre,usuario);
			lista->conectados[lista->num].socket=socket;
			lista->num++;
			return 0;
		}
		else
			return -2;
	}
}


void Consulta_1( MYSQL *conn, char respuesta[1000], char usuario [20]){
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	char nombre[20];
	char consulta [80];
	
	sprintf(consulta," SELECT PARTIDA.ID FROM (JUGADOR, PARTIDA) WHERE PARTIDA.GANADOR = JUGADOR.NICK AND JUGADOR.NICK = '%s'", usuario);
	err=mysql_query (conn, consulta);
	if (err!=0) {
		sprintf (respuesta,"Usuario incorrecto");
		//exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		sprintf (respuesta,"No se han obtenido datos en la consulta");					
	}
	else
		while (row != NULL){
			sprintf (respuesta,"La ultima partida ganada por el jugador %s es la partida numero %s", usuario, row[0]);
			row = mysql_fetch_row (resultado);
	}		
}


int LogIn(MYSQL *conn ,char respuesta[1000],char usuario [20],char password [20],ListaConectados *miLista, int sock_conn,char notificacion[100], int socket){

	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	char nombre[20];
	char consulta [80];
	printf("hola\n");
	sprintf(consulta,"SELECT JUGADOR.PWD FROM (JUGADOR) WHERE JUGADOR.NICK = '%s'", usuario);
	
	printf("hola\n");
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		sprintf (respuesta,"Usuario incorrecto");
		int eliminar=DamePosicionSocket(miLista,sock_conn);
		EliminarPosicion(miLista,eliminar);
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	char serverpassword[20];
	strcpy(serverpassword, row[0]);
	if (strcmp(serverpassword, password) == 0)
	{			
		printf("hola\n");
/*		int socket_jugador=DamePosicionSocket(miLista,sock_conn);*/
/*		strcpy(miLista->conectados[socket_jugador].nombre,usuario);					*/
/*		char conectados[1000];*/
/*		DameConectados(miLista,conectados);*/
		sprintf (respuesta,"Sesion iniciada correctamente");
		
		

	}
	else 
		sprintf (respuesta,"Password incorrecto");
		int eliminar=DamePosicionSocket(miLista,sock_conn);
		EliminarPosicion(miLista,eliminar);
	
}

	
int signIn(MYSQL *conn ,char respuesta[1000],char usuario [20],char password [20]){

	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	char nombre[20];
	char consulta [80];
	
	strcpy (consulta, "INSERT INTO JUGADOR VALUES ('");
	strcat (consulta, usuario); 
	strcat (consulta, "','");
	//concatenamos el nombre 
	strcat (consulta, password); 
	strcat (consulta, "');");
	
	printf("consulta = %s\n", consulta);
	// Ahora ya podemos realizar la insercion 
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	else 
		sprintf (respuesta,"Usuario registrado correctamente");
}


void *AtenderCliente (void *socket, int posicion){

	
	
	
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	char notificacion[100];
	int ret;
	
	MYSQL *conn;
	int err;
	/*Estructura especial para almacenar resultados de consultas */
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [80];
	/*Creamos una conexion al servidor MYSQL */
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "juego", 0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		printf("buenas\n");
		char usuario[30];
		char password[30];
		
		if ((codigo==1)||(codigo==2))
		{
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			
			printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, usuario, password);

		}
		
		if (codigo ==0){ //petici?n de desconexi?n
			terminar=1;
			int eliminado=Eliminar (&miLista,usuario); //eliminar de la lista de conectados
			if (eliminado==-1)
				strcpy(respuesta,"0/1/Error en la desconexion");
			else
				strcpy(respuesta,"0/2/Desconexion OK");
			char conectados[1000];
			DameConectados(&miLista,conectados);
		}
		
		else if (codigo ==1)
		{ //log in
			
			printf("Iniciando sesion\n");
/*			pthread_mutex_lock (&mutex);*/
			int log = LogIn(conn,respuesta,usuario,password,&miLista,sock_conn,notificacion, posicion);
			Pon (&miLista, usuario, socket);
/*			pthread_mutex_unlock (&mutex);*/
			
		}
		
		else if (codigo ==2)
		{ //sign in
			
			printf("Registrando\n");
			pthread_mutex_lock( &mutex);
			int sign=signIn (conn,respuesta,usuario,password);  
			pthread_mutex_unlock( &mutex);	
			
		}
		
		else if (codigo ==4)
		{ 
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			printf(usuario);
			
			Consulta_1(conn,respuesta, usuario);
			
/*			sprintf(consulta," SELECT PARTIDA.ID FROM (JUGADOR, PARTIDA) WHERE PARTIDA.GANADOR = JUGADOR.NICK AND JUGADOR.NICK = '%s'", usuario);*/
/*			err=mysql_query (conn, consulta);*/
/*			if (err!=0) {*/
/*				sprintf (respuesta,"Usuario incorrecto");*/
				//exit (1);
/*			}*/
/*			resultado = mysql_store_result (conn);*/
/*			row = mysql_fetch_row (resultado);*/
/*			if (row == NULL)*/
/*			{*/
/*				sprintf (respuesta,"No se han obtenido datos en la consulta");					*/
/*			}*/
/*			else*/
/*				while (row != NULL){*/
/*					sprintf (respuesta,"La ultima partida ganada por el jugador %s es la partida numero %s", usuario, row[0]);*/
/*					row = mysql_fetch_row (resultado);*/
/*			}		*/
		}
		
		else if (codigo ==5)
		{ //log in
			
			
			printf("buenas");
			
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			
			sprintf(consulta," SELECT PUNTUACIONES.PUNTOS FROM (PUNTUACIONES) WHERE PUNTUACIONES.PLAYER = '%s'", usuario);
			err=mysql_query (conn, consulta);
			if (err!=0) {
				sprintf (respuesta,"Usuario incorrecto");
				//exit (1);
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
				sprintf (respuesta,"No se han obtenido datos en la consulta\n");
			else
				while (row !=NULL) {
					sprintf (respuesta,"El jugador %s tiene %s puntos", usuario, row[0]);
					row = mysql_fetch_row (resultado);
			}
		}
		
		else if (codigo ==6)
		{ //sign in
			
			char misConectados [300];
			DameConectados (&miLista, misConectados);
			sprintf (respuesta,misConectados);
			write (sock_conn, respuesta, strlen(respuesta));
					
		}
		
		if ((codigo !=0)||(codigo !=6))
		{
			
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if ((codigo ==1)||(codigo==2)||(codigo==3)||(codigo==4)||(codigo==5))
		{
			pthread_mutex_lock( &mutex ); //No me interrumpas ahora
			contador = contador +1;
			pthread_mutex_unlock( &mutex); //ya puedes interrumpirme
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
}


int main(int argc, char *argv[]){

	miLista.num =0;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9022);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	MYSQL *conn;
	int err;
	/* Estructura especial para almacenar resultados de consultas */
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [80];
	/*Creamos una conexion al servidor MYSQL */
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "juego", 0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	contador =0;
	int numsocket;
	int sockets[100];
	pthread_t thread;
	numsocket=0;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		int anadir = Pon(&miLista,nombre,sock_conn);
		if (anadir == 0)
		{
			int posicion=DamePosicion(&miLista,nombre);
			printf ("He recibido conexion\n");
			pthread_t thread;
			pthread_create(&thread,NULL,AtenderCliente,&miLista.conectados[posicion].socket);
			
		}
		else if (anadir==-1)
		{
			printf ("No ha sido posible establecer conexion: servidor lleno\n");
			
		}
		
		
		
/*		printf ("He recibido conexion\n");*/
		/*sock_conn es el socket que usaremos para este cliente*/
/*		sockets[numsocket] =sock_conn;*/
/*		sock_conn es el socket que usaremos para este cliente*/
		
		/* Crear thead y decirle lo que tiene que hacer*/
		
/*		pthread_create (&thread, NULL, AtenderCliente,&sockets[numsocket]);*/
/*		numsocket=numsocket+1;*/
	}
}


