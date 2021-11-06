# DesignPatterns.MediatR
This is a demonstration from my DesignPattern series.

Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. 
The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

In this app, there is a Product, which also holds an Image. The Entire product should be created.
We mimic the backup of Azure Storage, with some business logic on top of that.

So in order to create a Product: 
- first the Archive Service archivates the image BLOB
- then it gets saved in a "cold" storage (for long time storage)
- also it gets saved in a "hot" storage (for quick access storage)
- finally the Product Service saves the Product in a database

Such a scenario would normally require ProductService to have too much dependencies (in all above mentioned services). 

However, with this Design Pattern it can simply just notify the MediatR object, which in turn will pass the request to all required services.
