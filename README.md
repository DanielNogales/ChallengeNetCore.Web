# ChallengeNetCore.Web
Challenge .Net Core

Desde una lista de stock de productos con sus respectivas categorias (PRODUNO, PRODDOS).

Se devuelve:

• Un único producto de cada categoría.

• Se ofrece el de mayor precio.

• El precio de ambos productos sumados debe ser menor o igual al presupuesto del cliente.

• El filtro solo debe aceptar valores enteros.

• Filtro debe permitir valores entre 0 y 1.000.000.

• En caso de no contar con un producto uno y un producto dos para ofrecer al cliente el resultado debe ser vacío.

• El monto total de la venta debe ser siempre el que menor diferencia tenga con el presupuesto del cliente.


Tipo de consulta:
1) A través de la página, input de presupuesto.
2) A través de la url, ej:
        Home/ProductsList/ <Presupuesto a consultar> 
