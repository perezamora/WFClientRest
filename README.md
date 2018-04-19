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

Metodos utilizados para los verbos REST API:
 * Create - POST/PUT -> PostAsJsonAsync
 * Read   - GET		 -> ReadAsAsync
 * Update - PUT		 -> PutAsJsonAsync
 * Delete - DELETE	 -> DeleteAsync

 En la comunicacion REST entre cliente - servidor, se utiliza el Media Type en formato JSON.

 Se han utilizado las siguientes ENDPOINTS para poder realizar la demo del REST API:

* api/Student/DeleteStudent/id  (delete de un student por id)
* api/Student/GetAllStudents    (Recupera la lista de students)
* api/Student/GetStudentById/id (Recupera el student por id)
* api/Student/AddStudent        (Inserta un nuevo student)

Para realizar la comunicacion se utiliza las TASKS.