<h1 align="center"> Pix Api </h1>

Api maded for practice my logic with a challange of build a pix simulator, business roles follow below:

# Business Roles:
1 - Challange:

You must develop a service that makes Pix payments, the payment must be do with a Client(A) realize a transaction with your pix key for a pix key of Client(B).

2 - Your Api must do:

Register an Pix Key with following options (E-MAIL, CELLPHONE OR CPF), and register in the SqlServer Database.

Realize a payment with your Pix Key and register this transactions in the SqlServer Database.

Realize a search of transactions madeds with determinate Pix Key

#EndPoints:

Base Url: https://localhost:7025/

Client End Points:

Get - GetAll : /client/getAll;

Get - GetByName: /client/getByName, 
 Parameters: string clientName;

Post - Regiter: /client/register,
 Parameters: ClientModel newCliente,

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

 

 


