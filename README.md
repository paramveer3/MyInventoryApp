# MyInventoryApp

At first You should have .net SDK 6.0 or higher into the system.
You should have mongo db atlas account

Step 1 :
after pull the github source code you can check the file.
in the myinventoryapp there is a file app.setting.json in which you have add your username or password for db clusters
and also change the environment in the docker-compose.yml file  you should add your mongo db atlas cluster environment.

Step 2:
open the WSL2 and run the following commands:

docker compose up -d
-- 
{it will create a default network to run both the container on same network}

Or you can pull the image from docker hub also.

docker pull paramveer03/myinventoryapp
--

after pulling the image you can run
docker run -d --name anycontainername -p 5000:80 paramveer03/myinventoryapp

now you are ready to use inventory app to perform CRUD operation.

Here is the APIS for Application.

POST : http://localhost:5000/api/inventory
-
description : it will add the item in the Inventory
response : {
  "id": "id1",
  "name": "product_name",
  "quantity": 100,
  "price": 1000,
  "description": "Description of product"
}

Get :http://localhost:5000/api/inventory
-
description : it will give the list of items in the Inventory

Get :http://localhost:5000/api/inventory/{id}
-
description : Give the details of item 
result: {
        "id": "id2",
        "name": "television",
        "quantity": 12,
        "price": 30000,
        "description": "Electronic"
    }
    
Put :http://localhost:5000/api/inventory/{id}
-
description : update the item of the invetory by its id
//update any detail
response : {
        "id": "id3",
        "name": "television", 
        "quantity": 12,
        "price": 30000,
        "description": "Electronic"
    }
result : "Item update successfull!"

Delete : http://localhost:5000/api/inventory/{id}
-
description : it will delete the item from inventory by its id.
result : "Item delete Successfull id is id1"
