-- Obtener lista de precios de todos los productos

select NombreProducto, Precio from Producto

-- obtener lista de productos cuya existencia sea <= 5	

select * from Producto where Inventario <= 5

-- lista de clientes menores de 35 que hayan realizado compras entre 1 de febrero de 2000 y 25 de mayo del 2000

Declare @Edad int = 35,
		@FechaInicio date = '2000-02-01',
		@FechaFin date = '2000-05-25'
BEGIN
    Select
	 Compra.ClienteId,
	 Cliente.Nombre,
	 CompraProducto.FechaCompra
	From Compra (NoLock)
	 Inner Join Cliente (NoLock) On Cliente.Id = Compra.ClienteId
	 Inner Join CompraProducto (NoLock) On CompraProducto.CompraId = Compra.Id
	Where Cliente.Edad <= @Edad
	And CompraProducto.FechaCompra BETWEEN @FechaInicio and @FechaFin
END

-- valor total vendido por cada producto en el año 2000

Declare @i int,
		@fin int,
		@fechafinal date = '2000-12-31'

declare @tabla table (NombreProducto varchar(256), sumatoria int)

set @i = (select min(ProductoId) as maximo from CompraProducto)
set @fin = (select max(ProductoId) as maximo from CompraProducto)

while (@i <= @fin )
if exists (select 
			Producto.NombreProducto, SUM(ValorProducto) as suma
			from CompraProducto (NoLock)
			Inner Join Producto (NoLock) On Producto.Id = CompraProducto.ProductoId
			where ProductoId = @i
			and CompraProducto.FechaCompra <= @fechafinal
			group by Producto.NombreProducto)

Begin
		insert into @tabla (NombreProducto, sumatoria)
		select 
			Producto.NombreProducto, SUM(ValorProducto) as suma
			from CompraProducto (NoLock)
			Inner Join Producto (NoLock) On Producto.Id = CompraProducto.ProductoId
			where ProductoId = @i
			and CompraProducto.FechaCompra <= @fechafinal
			group by Producto.NombreProducto
			set @i = @i + 1;
end
else
begin
	set @i = @i + 1;
end

select * from @tabla

-- ultima fecha del cliente y en que fecha volverá a comprar

declare @clienteId int = 4,
		@menor int = 1,
		@j date,
		@K date,
		@fechamayor date,
		@diferencia int,
		@conteo int,
		@dif int = 0,
		@dift int,
		@final int

declare @tabFecha table (Id int, fechaprom date)
declare @tabdif table (cont int)

		insert into @tabFecha (Id, fechaprom)
		select 
		ROW_NUMBER() OVER(ORDER BY fechacompra ASC) AS Id, FechaCompra
		from CompraProducto (nolock)
		inner join compra (nolock) on compra.Id = CompraProducto.CompraId
		inner join Cliente (nolock) on Cliente.Id = Compra.ClienteId
		where Compra.ClienteId = @clienteId

set @conteo = (select count(fechaprom) from @tabFecha)
set @fechamayor = (select top 1 fechaprom from @tabFecha order by fechaprom desc)

while (@menor <= @conteo)
begin 
	insert into @tabdif(cont) values (@dif)
	set @j = (select fechaprom
	from @tabFecha where Id = @menor)
	set @k = (select fechaprom
	from @tabFecha where Id = @menor + 1)
	set @diferencia = (SELECT DATEDIFF(day, @j, @K))
	set @dif = @dif + @diferencia

	set @menor = @menor + 1

end

set @final = (select top 1 * from @tabdif order by cont desc)

	set @dift = @final/(@conteo - 1)

select DATEADD(day, @dift, @fechamayor) as 'Fecha tentativa'

-- queris de ingreso de datos a tablas

insert into Cliente (Nombre, Edad) values ('', )

insert into Compra (ClienteId) values ()

insert into CompraProducto (CompraId, ProductoId, Cantidad, ValorProducto, FechaCompra) values ( , , , , )

insert into Producto (NombreProducto, Precio, Inventario) values ('', , )