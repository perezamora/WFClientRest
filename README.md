# Cliente REST en Windows Form

## Introduccion

Se realiza un sencillo cliente REST con windows form, para realizar un CRUD de un Student via WEB API.
Operaciones REST realizadas via HttpRequest:
	* C (create)
	* R (Read)
	* U (Update)
	* D (Delete)

En .NET para realizar peticiones REST hay diferentes marcos:

> Clases diferentes de consumir APIs REST: HttpWebRequest, WebClient, HttpClient. 
> La comunidad de código abierto creó otra biblioteca llamada RestSharp.

En este proyecto utilizaremso HttpClient, a tener en cuenta que ser requiere .NETFRAMEWORK 4.5 o superior.
