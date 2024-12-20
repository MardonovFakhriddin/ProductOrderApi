create table Products
(
    productid    serial primary key,
    name  varchar(255),
    price int,
    stock int
);

create table Orders
(
    OrderId         Serial primary key,
    ProductId  int references products (productid),
    Quantity   int,
    TotalPrice int,
    OrderDate  timestamp
);
