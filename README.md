# Super basic Azure/Azurite API - Graffiti wall

**C**reate Entry: 
> Name and Message 

**R**ead Entries: 
> List of Names + their Messages 

**U**pdate Entry: 
> Update a Name and Message, or just one one them... provide PartitionKey and RowKey as query params

**D**elete Entry: 
> Delete a Entry with the PartitionKey and RowKey


## Setup Azurite Container: 

Start Docker Desktop, run the following commands: 
> `docker pull mcr.microsoft.com/azure-storage/azurite`

> `docker run -p 10000:10000 -p 10001:10001 -p 10002:10002 mcr.microsoft.com/azure-storage/azurite`

The created Azuirte container can be inspected in Docker Desktop under Containers 
