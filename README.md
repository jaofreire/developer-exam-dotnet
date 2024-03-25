<h1 align="center"> Pix Api </h1>

Api maded for practice my logic with a challange of build a pix simulator, business roles follow below:

# Business Roles:
1 - Challange:

You must develop a service that makes Pix payments, the payment must be do with a Client(A) realize a transaction with your pix key for a pix key of Client(B).

2 - Your Api must do:

Register an Pix Key with following options (E-MAIL, CELLPHONE OR CPF), and register in the SqlServer Database.

Realize a payment with your Pix Key and register this transactions in the SqlServer Database.

Realize a search of transactions madeds with determinate Pix Key

# EndPoints:

Base Url: https://localhost:7025/

# Client End Points:

Get - GetAll : /client/getAll;

Get - GetByName: /client/getByName, 
 Parameters: [string] clientName;

Post - Regiter: /client/register,
 Parameters: [ClientModel] newCliente;

 Model:

<pre>
<code >{
  "id": 0,
  "name": "string",
  "clientKeyId": 0,
  "key": {
    "id": 0,
    "typeKey": "string",
    "key": "string"
  }
}
</code>
  </pre>

Put - UpdateClient: /client/update/{id},
 Parameters: [ClientModel] model, [int] id;

Put - UpdateClientKey: /client/updateKey/{id},
 Parameters: [int] id, [int] KeyId;

Delete - RemoveClient: /api/Client/client/remove/{id},
 Parameters: [int] id;



# Keys EndPoints:

Get - GetAll: /key/getAll

Get - GetKey: /key/getkey/{key},
 Parameters: [string] key;

Get - GetByType: /key/getByType/{type},
 Parameters: [string] type;

Post - Register: /key/register,
 Parameters: [KeyModel] newKey;

 Model:

 <pre>
<code >
 {
  "id": 0,
  "typeKey": "string",
  "key": "string"
}
</code>
  </pre>

Patch - UpdateKey: /key/updateKey/{id},
 Parameters: [int] id, [string] newKey;

Put - Update: /key/update/{id},
 Parameters: [int] id, [KeyModel] model;

Delete - RemoveKey: /key/remove/{id}, 
 Parameters: [int] id;


# Transactions EndPoints:

Get - GetAll: /api/Transition/transition/getAll

Get - GetById: /api/Transition/transition/getById/{id},
 Parameters: [int] id

Get - GetByKey: /api/Transition/transition/getByKey/{key},
 Parameters: [string] Key;

 Post - Register: /api/Transition/transition/register/,
  Parameters: [string] issuerKey, [string] receiverKey, [double] depositvalue;

 Model:

<pre>
 <code>
 {
  "id": 0,
  "issuerClient": "string",
  "issuerClientKey": "string",
  "receiverClient": "string",
  "receiverClientKey": "string",
  "depositValue": 0
}
 </code>
 </pre>






 



 

 


