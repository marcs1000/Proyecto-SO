#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>


int main(int argc, char *argv[])
{
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
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
	serv_adr.sin_port = htons(9017);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
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
	
	
	
	int i;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
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
			
			if (codigo !=0)
			{
/*				p = strtok( NULL, "/");*/
/*				strcpy (usuario, p);*/
/*				p = strtok( NULL, "/");*/
/*				strcpy (password, p);*/
				// Ya tenemos el nombre
/*				printf("hola\n");*/
				
/*				printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, usuario, password);*/
/*				printf("hola");*/
			}
			
			if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			
			else if (codigo ==1)
			{ //log in
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				p = strtok( NULL, "/");
				strcpy (password, p);
				// Ya tenemos el nombre
				
				printf("codigo: %d, nombre: %s, password: %s\n", codigo, usuario, password);
				
				sprintf(consulta,"SELECT JUGADOR.PWD FROM (JUGADOR) WHERE JUGADOR.NICK = '%s'", usuario);
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta,"Usuario incorrecto");
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);

				char serverpassword[20];
				strcpy(serverpassword, row[0]);
				
				if (strcmp(serverpassword, password) == 0)
				{			
					sprintf (respuesta,"Sesion iniciada correctamente");									
				}
				else 
					sprintf (respuesta,"Password incorrecto");
					
			
			}
			
			else if (codigo ==2)
			{ //log in
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				p = strtok( NULL, "/");
				strcpy (password, p);
				// Ya tenemos el nombre
				
				
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
			
			else if (codigo ==4)
			{ //log in
				
				printf("buenas\n");
				
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				printf("buenas\n");
				printf(usuario);
				
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
			
			else //quiere saber si es alto
			{
				
			}
				
			if (codigo !=0)
			{
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
}
