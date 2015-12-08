USE TenebrosaOLTP
go

SELECT * FROM PEDIDO

SELECT * FROM DETAPEDIDO
SELECT * FROM CLIENTE


CREATE PROCEDURE SP_ListarPedidos
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

SELECT * FROM V_Cliente

CREATE VIEW V_Personal AS
	SELECT Personal, nombre FROM PERSONAL

SELECT * FROM V_Personal

CREATE VIEW V_FormaPago AS
	SELECT FormaPago, descripcion FROM FORMAPAGO

SELECT * FROM V_FormaPago

CREATE VIEW V_Marca AS
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

SELECT * FROM DETAPEDIDO
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




ALTER PROCEDURE SP_ListarDocumentos
(
	@inicio date=null,
	@fin date=null
)AS
BEGIN
	
	SELECT D.Documento AS 'Código', P.Pedido, D.FormaPago AS [Forma de pago], PR.Nombre AS 'Empleado', C.Nombre AS 'Cliente', D.Fecha, D.Estado
		FROM DOCUMENTO D
		JOIN CLIENTE C ON D.Cliente = C.Cliente 
		JOIN PEDIDO P ON D.Pedido = P.Pedido
		JOIN PERSONAL PR ON D.Personal = PR.Personal
		
		WHERE D.Fecha BETWEEN @inicio AND @fin
END
GO

EXECUTE SP_ListarDocumentos @inicio = '1887-01-15', @fin = '2015-12-15'

select * from DETADOC

ALTER PROCEDURE SP_MostrarDetalleDoc
(
	@documento char(9)
) 
AS
BEGIN
	
		SELECT DD.Documento , PT.Producto AS 'Código de Producto', DD.TipoDoc as 'Tipo documento', PT.Descripcion, DD.Cantidad, DD.Igv, DD.PrecUnit, DD.Cantidad*DD.PrecUnit AS 'Subtotal'
			FROM DETADOC DD
			JOIN PRODUCTO PT ON DD.Producto = PT.Producto
			WHERE DD.Documento = @documento
END
GO

ALTER VIEW V_Proveedor AS
	SELECT Proveedor AS proveedor, RazonSocial AS razon FROM PROVEEDOR
GO

CREATE VIEW V_Pedido AS
	SELECT Pedido AS pedido FROM PEDIDO
GO

CREATE VIEW V_TipoDoc AS
	SELECT TipoDoc AS tipo, Descripcion As descripcion FROM TIPODOC
GO

select * from DOCUMENTO where Documento = '2333'

EXECUTE SP_MostrarDetalleDoc @documento = '100000017'

-- Registrar nuevo documento
--Documento, TipoDoc, Proveedor, Cliente, Fecha, Personal, Pagado, FormaPago
CREATE PROCEDURE SP_RegistrarDocumento
(
	@Documento char(9),
	@TipoDoc char(1),
	@Pedido char(9), 
	@Proveedor char(4), 
	@Cliente char(4), 
	@Fecha date, 
	@Personal char(2), 
	@Pagado decimal(9,2), 
	@FormaPago char(1)
) 
	AS
BEGIN
	INSERT DOCUMENTO (Documento, TipoDoc, Proveedor, Pedido, Cliente, Fecha, Estado, Personal, pagado, IdTienda, FormaPago)
	VALUES (@Documento, @TipoDoc, @Proveedor, @Pedido, @Cliente, @Fecha, 'C', @Personal, @Pagado, '01', @FormaPago)
END
GO

-- Registrar nuevo detalle de documento
CREATE PROCEDURE SP_RegistrarDetaDoc(@Documento char(9), @TipoDoc char(1), @Producto char(4), @Cantidad decimal(9, 2), @Igv decimal(9, 2), @PrecUnit decimal(9, 2)) AS
BEGIN
	INSERT DETADOC(Documento, TipoDoc, Producto, Cantidad, Igv, PrecUnit)
	VALUES (@Documento, @TipoDoc, @Producto, @Cantidad, @Igv, @PrecUnit)
END
GO

ALTER PROCEDURE SP_ModificarDetaDoc
(
	@Documento char(9), 
	@Producto char(4), 
	@Cantidad decimal(9, 2), 
	@Igv decimal(9, 2), 
	@PrecUnit decimal(9, 2)
	) 
	AS
BEGIN
	UPDATE DETADOC
	SET Cantidad = @Cantidad, Igv = @Igv, PrecUnit = @PrecUnit
	WHERE Documento = @Documento and Producto = @Producto
END
GO

select * from DETADOC

CREATE PROCEDURE SP_EliminarDetaDoc
(
	@Documento char(9), 
	@Producto char(4)
	) 
	AS
BEGIN
	DELETE FROM DETADOC
	WHERE Documento = @Documento and Producto = @Producto
END
GO