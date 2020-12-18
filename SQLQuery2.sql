USE [Sis_Ventas_MrTec]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[insertar_Producto]
		@Descripcion = N'PRODUC1TO122',
		@Imagen = N'.',
		@Id_grupo = 1,
		@Usa_inventarios = N'SI',
		@Stock = N'10',
		@Precio_de_compra = 100,
		@Fecha_de_vencimiento = N'NO APLICA',
		@Precio_de_venta = 150,
		@Codigo = N'152324DMRTEC',
		@Se_vende_a = N'UNIDAD',
		@Impuesto = N'0',
		@Stock_minimo = 2,
		@Precio_mayoreo = 120,
		@A_partir_de = 3,
		@Fecha = N'30/12/2020',
		@Motivo = N'REGISTRO INICIAL DE PRODUCTO',
		@Cantidad = 20,
		@Id_Usuario = 9,
		@Tipo = N'ENTRADA',
		@Estado = N'CONFIRMADO',
		@Id_caja = 1

SELECT	@return_value as 'Return Value'

GO
