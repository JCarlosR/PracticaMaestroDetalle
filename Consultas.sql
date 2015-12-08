USE TenebrosaOLTP
go

SELECT * FROM PEDIDO

SELECT * FROM DETAPEDIDO
SELECT * FROM CLIENTE


ALTER PROCEDURE SP_ListarPedidos
(
	@inicio date=null,
	@fin date=null
)AS
BEGIN
	
	SELECT P.Pedido AS 'Código', P.FormaPago AS [Forma de pago], PR.Nombre AS 'Empleado', C.Nombre AS 'Cliente', P.Fecha, P.Estado
		FROM PEDIDO P 
		JOIN CLIENTE C ON P.Cliente = C.Cliente 
		JOIN PERSONAL PR ON P.Personal = PR.Personal
		WHERE P.Fecha BETWEEN @inicio AND @fin
END

EXECUTE SP_ListarPedidos @inicio = '2003-01-15', @fin = '2004-12-15'


CREATE PROCEDURE SP_MostrarDetalle
(
	@pedido char(9)
) 
AS
BEGIN
	
		SELECT PT.Producto AS 'Código de Producto', PT.Descripcion, DP.Cantidad, DP.PrecUnit, DP.Cantidad*DP.PrecUnit AS 'Subtotal'
			FROM DETAPEDIDO DP
			JOIN PRODUCTO PT ON DP.Producto = PT.Producto
			WHERE DP.Pedido = @pedido
END

EXECUTE SP_MostrarDetalle @pedido = '000000003'

CREATE VIEW V_Clientes AS
	SELECT Cliente, nombre FROM Cliente

SELECT * FROM V_Clientes

CREATE VIEW V_Personal AS
	SELECT Personal, nombre FROM PERSONAL

SELECT * FROM V_Personal

CREATE VIEW V_FormaPago AS
	SELECT FormaPago, descripcion FROM FORMAPAGO

SELECT * FROM V_FormaPago

ALTER VIEW V_Marca AS
	SELECT DISTINCT M.Marca, M.descripcion 
	FROM MARCA M
	JOIN PRODUCTO P ON M.Marca = P.Marca

SELECT * FROM V_Marca

CREATE VIEW V_Producto AS
	SELECT Producto, descripcion FROM PRODUCTO

SELECT * FROM V_Producto

SELECT * FROM PRODUCTO

CREATE PROCEDURE SP_MarcaProducto
(
	@marca char(2)
)
AS
BEGIN
	
	SELECT Producto, descripcion FROM PRODUCTO
		WHERE Marca = @marca

END

EXECUTE SP_MarcaProducto @marca = '8'

CREATE PROCEDURE SP_PrecioProducto
(
	@producto char(4)
)
AS
BEGIN
	SELECT PrecVenta FROM PRODUCTO
		WHERE Producto = @producto
END

EXECUTE SP_PrecioProducto @producto = '1'

SELECT * FROM PEDIDO
ORDER BY Fecha DESC

SELECT * FROM DETAPEDIDO WHERE Pedido = '321321'

-- Registrar nuevo pedido
CREATE PROCEDURE SP_RegistrarPedido(@Pedido char(9), @FormaPago char(1), @Personal char(2), @Cliente char(4), @Fecha date) AS
BEGIN
	INSERT PEDIDO (Pedido, FormaPago, Personal, Cliente, Fecha, Estado)
	VALUES (@Pedido, @FormaPago, @Personal, @Cliente, @Fecha, 'P')
END

-- Registrar nuevo detalle de pedido
CREATE PROCEDURE SP_RegistrarDetaPedido(@Pedido char(9), @Producto char(4), @Cantidad decimal(9, 2), @PrecUnit decimal(9, 2)) AS
BEGIN
	INSERT DETAPEDIDO (Pedido, Producto, Cantidad, PrecUnit)
	VALUES (@Pedido, @Producto, @Cantidad, @PrecUnit)
END