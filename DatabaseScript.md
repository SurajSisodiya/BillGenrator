# BillGenrator



create database EBillDB;

use EBillDB;

create table tbl_BillDetails (
	Id int primary key identity,
	CustomerName varchar(255),
	MobileNumber varchar(12),
	Address varchar(255),
	TotalAmount int
);

create table tbl_BillItems (
	Id int primary key identity,
	ProductName varchar(255),
	Price int,
	Quantity int,
	BillId int foreign key references tbl_BillDetails(Id)
);

-- this id will store in tbl_BillItems(BillId)
-- Saving All Bill Details

create procedure spt_saveEBillDetails
@CustomerName varchar(255),
@MobileNumber varchar(12),
@Address varchar(255),
@TotalAmount int,
@Id int output
as
begin
insert into tbl_BillDetails(CustomerName,MobileNumber,Address,TotalAmount)
values(@CustomerName,@MobileNumber,@Address,@TotalAmount);

select @Id = SCOPE_IDENTITY();
end





-- for getting all details

create procedure spt_getAllEBillDetails
as
begin
select * from tbl_BillDetails;
end



-- for getting one record


create procedure spt_getEBillDetails
@Id int
as
begin
select d.Id as 'BillId', d.CustomerName, d.MobileNumber, d.Address, d.TotalAmount,
i.Id as 'ItemId', i.ProductName, i.Price, i.Quantity
from tbl_BillDetails d inner join tbl_BillItems i
on d.Id = i.BillId
where d.Id = @Id;
end


select * from tbl_BillDetails


select * from tbl_BillItems
