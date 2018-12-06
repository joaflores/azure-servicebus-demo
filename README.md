# Demo de Azure Service Bus
Demo de Service Bus usando Functions para representar una solución orientada a eventos. 
La demo esta compuesta por 2 proyectos de Azure Functions, una de las functions se encarga de enviar un mensaje a un topic y la otra function esta suscrita al topic, recibe el mensaje y lo guarda en un blob storage.

# Correr el demo
1- Ingresar en Azure Portal.  
2- Crear un grupo de recursos para contener los servicios usados en esta demo.  
3- Agregar recurso Azure Service Bus.  
4- Crear un topic, crear una suscripción y copiar la cadena de conexión.  
5- Agregar recurso Storage Account de tipo blob storage, copiar cadena de conexión.  
6- Clonar repositorio azure-servicebus-demo y abrir con Visual Studio 2017.  
7- Modificar MessageSender.cs y cambiar el valor de la variable ServiceBusConnectionString con la cadena de conexion de ServiceBus recien aprovisionado.  
8- Cambiar el valor de la variable TopicName con el nombre del topic recien creado.  
9- En el proyecto FunctionMsgReceiver modificar local.settings.json y cambiar las cadenas de conexion para Service Bus y Blob Storage.  

