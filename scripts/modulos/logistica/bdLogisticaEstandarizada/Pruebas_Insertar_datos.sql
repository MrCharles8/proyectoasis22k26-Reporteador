-- TERMINUS ERP | Datos de prueba para las 39 tablas de Logística
-- Compatible con el esquema compartido (columnas Pk_*, Fk_*).
-- Agrega DOS registros de prueba por tabla, además de los existentes.
-- Reejecutable: evita duplicados mediante identificadores o combinaciones de prueba.
-- NO modifica ni elimina registros existentes. Solo para ambiente de desarrollo.
USE dbsistemaembutidos;
START TRANSACTION;

-- tblSucursal
select * from tblsucursal;
INSERT INTO tblSucursal (nombreSucursal, descripcionSucursal, ubicacionSucursal, paisSucursal)
SELECT 'Sucursal Demo Oriente', 'Sucursal adicional de pruebas', 'Guatemala, zona 10', 'Guatemala'
WHERE NOT EXISTS (SELECT 1 FROM tblSucursal WHERE nombreSucursal='Sucursal Demo Oriente');

INSERT INTO tblSucursal (nombreSucursal, descripcionSucursal, ubicacionSucursal, paisSucursal)
SELECT 'Sucursal Demo Occidente', 'Sucursal adicional de pruebas', 'Quetzaltenango', 'Guatemala'
WHERE NOT EXISTS (SELECT 1 FROM tblSucursal WHERE nombreSucursal='Sucursal Demo Occidente');

SET @suc1 = (SELECT Pk_Sucursal FROM tblSucursal WHERE nombreSucursal = 'Sucursal Demo Oriente' LIMIT 1);
SET @suc2 = (SELECT Pk_Sucursal FROM tblSucursal WHERE nombreSucursal = 'Sucursal Demo Occidente' LIMIT 1);

-- tblBodega
INSERT INTO tblBodega (nombreBodega, Fk_Sucursal_Codigo, paisBodega)
SELECT 'Bodega Demo Oriente', @suc1, 'Guatemala'
WHERE NOT EXISTS (SELECT 1 FROM tblBodega WHERE nombreBodega='Bodega Demo Oriente' AND Fk_Sucursal_Codigo=@suc1);

INSERT INTO tblBodega (nombreBodega, Fk_Sucursal_Codigo, paisBodega)
SELECT 'Bodega Demo Occidente', @suc2, 'Guatemala'
WHERE NOT EXISTS (SELECT 1 FROM tblBodega WHERE nombreBodega='Bodega Demo Occidente' AND Fk_Sucursal_Codigo=@suc2);

SET @bod1 = (SELECT Pk_Bodega FROM tblBodega WHERE nombreBodega = 'Bodega Demo Oriente' LIMIT 1);
SET @bod2 = (SELECT Pk_Bodega FROM tblBodega WHERE nombreBodega = 'Bodega Demo Occidente' LIMIT 1);

-- tblCategoria
INSERT INTO tblCategoria (nombreCategoria, porcentajeComisionCategoria)
SELECT 'Embutidos Demo', 0.05
WHERE NOT EXISTS (SELECT 1 FROM tblCategoria WHERE nombreCategoria='Embutidos Demo');

INSERT INTO tblCategoria (nombreCategoria, porcentajeComisionCategoria)
SELECT 'Carnes Frias Demo', 0.08
WHERE NOT EXISTS (SELECT 1 FROM tblCategoria WHERE nombreCategoria='Carnes Frias Demo');

SET @cat1 = (SELECT Pk_Categoria FROM tblCategoria WHERE nombreCategoria = 'Embutidos Demo' LIMIT 1);
SET @cat2 = (SELECT Pk_Categoria FROM tblCategoria WHERE nombreCategoria = 'Carnes Frias Demo' LIMIT 1);

-- tblLinea
INSERT INTO tblLinea (nombreLinea, porcentajeComisionLinea)
SELECT 'Linea Refrigerada Demo', 0.03
WHERE NOT EXISTS (SELECT 1 FROM tblLinea WHERE nombreLinea='Linea Refrigerada Demo');

INSERT INTO tblLinea (nombreLinea, porcentajeComisionLinea)
SELECT 'Linea Congelada Demo', 0.04
WHERE NOT EXISTS (SELECT 1 FROM tblLinea WHERE nombreLinea='Linea Congelada Demo');

SET @lin1 = (SELECT Pk_Linea FROM tblLinea WHERE nombreLinea = 'Linea Refrigerada Demo' LIMIT 1);
SET @lin2 = (SELECT Pk_Linea FROM tblLinea WHERE nombreLinea = 'Linea Congelada Demo' LIMIT 1);

-- tblMarca
INSERT INTO tblMarca (nombreMarca, porcentajeComisionMarca)
SELECT 'Marca Norte Demo', 0.02
WHERE NOT EXISTS (SELECT 1 FROM tblMarca WHERE nombreMarca='Marca Norte Demo');

INSERT INTO tblMarca (nombreMarca, porcentajeComisionMarca)
SELECT 'Marca Sur Demo', 0.02
WHERE NOT EXISTS (SELECT 1 FROM tblMarca WHERE nombreMarca='Marca Sur Demo');

SET @mar1 = (SELECT Pk_Marca FROM tblMarca WHERE nombreMarca = 'Marca Norte Demo' LIMIT 1);
SET @mar2 = (SELECT Pk_Marca FROM tblMarca WHERE nombreMarca = 'Marca Sur Demo' LIMIT 1);

-- tblProducto
INSERT INTO tblProducto (skuProducto, clasificacionProducto, nombreProducto, Fk_Marca_Codigo, Fk_Categoria_Codigo, Fk_Linea_Codigo, descripcionProducto, paisProducto, precioCompraProducto, precioVentaProducto, porcentajeComisionProducto, stockMinimoProducto, stockMaximoProducto, pesoProducto)
SELECT 'LOG-DEMO-001', 'A001', 'Salchicha Demo', @mar1, @cat1, @lin1, 'Salchicha de prueba', 'Guatemala', 10.5000, 15.7500, 0.05, 5, 500, 0.50
WHERE NOT EXISTS (SELECT 1 FROM tblProducto WHERE skuProducto='LOG-DEMO-001');

INSERT INTO tblProducto (skuProducto, clasificacionProducto, nombreProducto, Fk_Marca_Codigo, Fk_Categoria_Codigo, Fk_Linea_Codigo, descripcionProducto, paisProducto, precioCompraProducto, precioVentaProducto, porcentajeComisionProducto, stockMinimoProducto, stockMaximoProducto, pesoProducto)
SELECT 'LOG-DEMO-002', 'A002', 'Jamon Demo', @mar2, @cat2, @lin2, 'Jamon de prueba', 'Guatemala', 20.0000, 29.5000, 0.05, 5, 500, 0.75
WHERE NOT EXISTS (SELECT 1 FROM tblProducto WHERE skuProducto='LOG-DEMO-002');

SET @prod1 = (SELECT Pk_Producto FROM tblProducto WHERE skuProducto = 'LOG-DEMO-001' LIMIT 1);
SET @prod2 = (SELECT Pk_Producto FROM tblProducto WHERE skuProducto = 'LOG-DEMO-002' LIMIT 1);

-- tblEstado
INSERT INTO tblEstado (tipoEstado)
SELECT 'ACTIVO DEMO'
WHERE NOT EXISTS (SELECT 1 FROM tblEstado WHERE tipoEstado='ACTIVO DEMO');

INSERT INTO tblEstado (tipoEstado)
SELECT 'MANTENIMIENTO DEMO'
WHERE NOT EXISTS (SELECT 1 FROM tblEstado WHERE tipoEstado='MANTENIMIENTO DEMO');

SET @est1 = (SELECT Pk_Estado FROM tblEstado WHERE tipoEstado = 'ACTIVO DEMO' LIMIT 1);
SET @est2 = (SELECT Pk_Estado FROM tblEstado WHERE tipoEstado = 'MANTENIMIENTO DEMO' LIMIT 1);

-- tblTipoTransporte
INSERT INTO tblTipoTransporte (nombreTipoTransporte)
SELECT 'Camion Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoTransporte WHERE nombreTipoTransporte='Camion Demo');

INSERT INTO tblTipoTransporte (nombreTipoTransporte)
SELECT 'Furgon Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoTransporte WHERE nombreTipoTransporte='Furgon Demo');

SET @tipot1 = (SELECT Pk_TipoTransporte FROM tblTipoTransporte WHERE nombreTipoTransporte = 'Camion Demo' LIMIT 1);
SET @tipot2 = (SELECT Pk_TipoTransporte FROM tblTipoTransporte WHERE nombreTipoTransporte = 'Furgon Demo' LIMIT 1);

-- tblTransporte
INSERT INTO tblTransporte (nroPlacaTransporte, marcaTransporte, modeloTransporte, anioTransporte, esRefrigeradoTransporte, Fk_Estado_Codigo, Fk_TipoTransporte_Codigo)
SELECT 'DEM-101', 'Isuzu', 'NPR', 2022, TRUE, @est1, @tipot1
WHERE NOT EXISTS (SELECT 1 FROM tblTransporte WHERE nroPlacaTransporte='DEM-101');

INSERT INTO tblTransporte (nroPlacaTransporte, marcaTransporte, modeloTransporte, anioTransporte, esRefrigeradoTransporte, Fk_Estado_Codigo, Fk_TipoTransporte_Codigo)
SELECT 'DEM-102', 'Hino', '300', 2023, FALSE, @est2, @tipot2
WHERE NOT EXISTS (SELECT 1 FROM tblTransporte WHERE nroPlacaTransporte='DEM-102');

SET @trans1 = (SELECT Pk_Transporte FROM tblTransporte WHERE nroPlacaTransporte = 'DEM-101' LIMIT 1);
SET @trans2 = (SELECT Pk_Transporte FROM tblTransporte WHERE nroPlacaTransporte = 'DEM-102' LIMIT 1);

-- tblConductor
INSERT INTO tblConductor (codigoConductor, nombreCompletoConductor, numeroLicenciaConductor, fechaVencimientoDocConductor, Fk_Estado_Codigo)
SELECT 'COND-DEMO-01', 'Luis Perez Prueba', 'LIC-DEMO-01', '2028-12-31', @est1
WHERE NOT EXISTS (SELECT 1 FROM tblConductor WHERE codigoConductor='COND-DEMO-01');

INSERT INTO tblConductor (codigoConductor, nombreCompletoConductor, numeroLicenciaConductor, fechaVencimientoDocConductor, Fk_Estado_Codigo)
SELECT 'COND-DEMO-02', 'Ana Lopez Prueba', 'LIC-DEMO-02', '2028-11-30', @est1
WHERE NOT EXISTS (SELECT 1 FROM tblConductor WHERE codigoConductor='COND-DEMO-02');

SET @cond1 = (SELECT Pk_Conductor FROM tblConductor WHERE codigoConductor = 'COND-DEMO-01' LIMIT 1);
SET @cond2 = (SELECT Pk_Conductor FROM tblConductor WHERE codigoConductor = 'COND-DEMO-02' LIMIT 1);

-- tblCamaraRefrigeracion
INSERT INTO tblCamaraRefrigeracion (Fk_Transporte_Codigo, marcaEquipoCamaraRefrigeracion, tempMinimaCelsiusCamaraRefrigeracion, tempMaximaCelsiusCamaraRefrigeracion, estadoOperativoCamaraRefrigeracion)
SELECT @trans1, 'Thermo Demo A', -5.00, 5.00, 'OPERATIVO'
WHERE NOT EXISTS (SELECT 1 FROM tblCamaraRefrigeracion WHERE Fk_Transporte_Codigo=@trans1);

INSERT INTO tblCamaraRefrigeracion (Fk_Transporte_Codigo, marcaEquipoCamaraRefrigeracion, tempMinimaCelsiusCamaraRefrigeracion, tempMaximaCelsiusCamaraRefrigeracion, estadoOperativoCamaraRefrigeracion)
SELECT @trans2, 'Thermo Demo B', -10.00, 4.00, 'OPERATIVO'
WHERE NOT EXISTS (SELECT 1 FROM tblCamaraRefrigeracion WHERE Fk_Transporte_Codigo=@trans2);

-- tblInspeccionSanitaria
INSERT INTO tblInspeccionSanitaria (Fk_Transporte_Codigo, fechaUtcInspeccionSanitaria, sanitizadoCorrectoInspeccionSanitaria, libreOloresContamInspeccionSanitaria, aprobadoParaCargaInspeccionSanitaria, observacionesInspeccionSanitaria)
SELECT @trans1, '2026-10-20 08:00:00', TRUE, TRUE, TRUE, 'Inspeccion de prueba 1'
WHERE NOT EXISTS (SELECT 1 FROM tblInspeccionSanitaria WHERE Fk_Transporte_Codigo=@trans1 AND observacionesInspeccionSanitaria='Inspeccion de prueba 1');

INSERT INTO tblInspeccionSanitaria (Fk_Transporte_Codigo, fechaUtcInspeccionSanitaria, sanitizadoCorrectoInspeccionSanitaria, libreOloresContamInspeccionSanitaria, aprobadoParaCargaInspeccionSanitaria, observacionesInspeccionSanitaria)
SELECT @trans2, '2026-10-20 09:00:00', TRUE, TRUE, FALSE, 'Inspeccion de prueba 2'
WHERE NOT EXISTS (SELECT 1 FROM tblInspeccionSanitaria WHERE Fk_Transporte_Codigo=@trans2 AND observacionesInspeccionSanitaria='Inspeccion de prueba 2');

-- tblLoteProducto
INSERT INTO tblLoteProducto (codigoLoteProducto, descripcionLoteProducto, requiereFrioLoteProducto, fechaFabricacionLoteProducto, fechaVencimientoLoteProducto, tempRequeridaMinLoteProducto, tempRequeridaMaxLoteProducto)
SELECT 'LOTE-DEMO-01', 'Lote de salchichas demo', TRUE, '2026-10-01', '2026-12-01', 0.00, 5.00
WHERE NOT EXISTS (SELECT 1 FROM tblLoteProducto WHERE codigoLoteProducto='LOTE-DEMO-01');

INSERT INTO tblLoteProducto (codigoLoteProducto, descripcionLoteProducto, requiereFrioLoteProducto, fechaFabricacionLoteProducto, fechaVencimientoLoteProducto, tempRequeridaMinLoteProducto, tempRequeridaMaxLoteProducto)
SELECT 'LOTE-DEMO-02', 'Lote de jamon demo', TRUE, '2026-10-02', '2026-12-02', 0.00, 4.00
WHERE NOT EXISTS (SELECT 1 FROM tblLoteProducto WHERE codigoLoteProducto='LOTE-DEMO-02');

SET @lote1 = (SELECT Pk_LoteProducto FROM tblLoteProducto WHERE codigoLoteProducto = 'LOTE-DEMO-01' LIMIT 1);
SET @lote2 = (SELECT Pk_LoteProducto FROM tblLoteProducto WHERE codigoLoteProducto = 'LOTE-DEMO-02' LIMIT 1);

-- tblEncabezadoViaje
INSERT INTO tblEncabezadoViaje (fechaDocumentoEncabezadoViaje, horaSalidaUtcEncabezadoViaje, horaLlegadaUtcEncabezadoViaje, requiereCadenaFrioEncabezadoViaje, estadoViajeEncabezadoViaje, pesoTotalEncabezadoViaje, Fk_Transporte_Codigo, Fk_Conductor_Codigo)
SELECT '2026-10-20 08:00:00', '2026-10-20 09:00:00', NULL, TRUE, 'EN_CURSO', 125.500, @trans1, @cond1
WHERE NOT EXISTS (SELECT 1 FROM tblEncabezadoViaje WHERE Fk_Transporte_Codigo=@trans1 AND fechaDocumentoEncabezadoViaje='2026-10-20 08:00:00');

INSERT INTO tblEncabezadoViaje (fechaDocumentoEncabezadoViaje, horaSalidaUtcEncabezadoViaje, horaLlegadaUtcEncabezadoViaje, requiereCadenaFrioEncabezadoViaje, estadoViajeEncabezadoViaje, pesoTotalEncabezadoViaje, Fk_Transporte_Codigo, Fk_Conductor_Codigo)
SELECT '2026-10-20 10:00:00', '2026-10-20 11:00:00', '2026-10-20 13:00:00', FALSE, 'FINALIZADO', 85.000, @trans2, @cond2
WHERE NOT EXISTS (SELECT 1 FROM tblEncabezadoViaje WHERE Fk_Transporte_Codigo=@trans2 AND fechaDocumentoEncabezadoViaje='2026-10-20 10:00:00');

SET @via1 = (SELECT Pk_EncabezadoViaje FROM tblEncabezadoViaje WHERE Fk_Transporte_Codigo=@trans1 AND fechaDocumentoEncabezadoViaje='2026-10-20 08:00:00' LIMIT 1);
SET @via2 = (SELECT Pk_EncabezadoViaje FROM tblEncabezadoViaje WHERE Fk_Transporte_Codigo=@trans2 AND fechaDocumentoEncabezadoViaje='2026-10-20 10:00:00' LIMIT 1);

-- tblDetalleViaje
INSERT INTO tblDetalleViaje (Fk_EncabezadoViaje_Codigo, ordenDetalleViaje, descripcionDetalleViaje, cantidadDetalleViaje, pesoDetalleViaje)
SELECT @via1, 1, 'Carga refrigerada demo', 10.000, 50.000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleViaje WHERE Fk_EncabezadoViaje_Codigo=@via1 AND ordenDetalleViaje=1);

INSERT INTO tblDetalleViaje (Fk_EncabezadoViaje_Codigo, ordenDetalleViaje, descripcionDetalleViaje, cantidadDetalleViaje, pesoDetalleViaje)
SELECT @via2, 1, 'Carga seca demo', 8.000, 40.000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleViaje WHERE Fk_EncabezadoViaje_Codigo=@via2 AND ordenDetalleViaje=1);

SET @dvia1 = (SELECT Pk_DetalleViaje FROM tblDetalleViaje WHERE Fk_EncabezadoViaje_Codigo=@via1 AND ordenDetalleViaje=1 LIMIT 1);
SET @dvia2 = (SELECT Pk_DetalleViaje FROM tblDetalleViaje WHERE Fk_EncabezadoViaje_Codigo=@via2 AND ordenDetalleViaje=1 LIMIT 1);

-- tblDetalleViajeLoteProducto
INSERT INTO tblDetalleViajeLoteProducto (Fk_DetalleViaje_Codigo, Fk_LoteProducto_Codigo, cantidadCajasDetalleViajeLoteProducto, pesoKgDetalleViajeLoteProducto)
SELECT @dvia1, @lote1, 10, 50.000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleViajeLoteProducto WHERE Fk_DetalleViaje_Codigo=@dvia1 AND Fk_LoteProducto_Codigo=@lote1);

INSERT INTO tblDetalleViajeLoteProducto (Fk_DetalleViaje_Codigo, Fk_LoteProducto_Codigo, cantidadCajasDetalleViajeLoteProducto, pesoKgDetalleViajeLoteProducto)
SELECT @dvia2, @lote2, 8, 40.000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleViajeLoteProducto WHERE Fk_DetalleViaje_Codigo=@dvia2 AND Fk_LoteProducto_Codigo=@lote2);

-- tblTelemetriaTemperatura
INSERT INTO tblTelemetriaTemperatura (Fk_EncabezadoViaje_Codigo, fechaHoraUtcTelemetriaTemperatura, temperaturaCelsiusTelemetriaTemperatura, humedadRelativaTelemetriaTemperatura, puertaAbiertaTelemetriaTemperatura, ubicacionGpsTelemetriaTemperatura)
SELECT @via1, '2026-10-20 09:15:00', 3.50, 0.6500, FALSE, 'Guatemala Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTelemetriaTemperatura WHERE Fk_EncabezadoViaje_Codigo=@via1 AND fechaHoraUtcTelemetriaTemperatura='2026-10-20 09:15:00');

INSERT INTO tblTelemetriaTemperatura (Fk_EncabezadoViaje_Codigo, fechaHoraUtcTelemetriaTemperatura, temperaturaCelsiusTelemetriaTemperatura, humedadRelativaTelemetriaTemperatura, puertaAbiertaTelemetriaTemperatura, ubicacionGpsTelemetriaTemperatura)
SELECT @via2, '2026-10-20 11:15:00', 6.00, 0.7000, TRUE, 'Escuintla Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTelemetriaTemperatura WHERE Fk_EncabezadoViaje_Codigo=@via2 AND fechaHoraUtcTelemetriaTemperatura='2026-10-20 11:15:00');

SET @tele1 = (SELECT Pk_TelemetriaTemperatura FROM tblTelemetriaTemperatura WHERE Fk_EncabezadoViaje_Codigo=@via1 AND fechaHoraUtcTelemetriaTemperatura='2026-10-20 09:15:00' LIMIT 1);
SET @tele2 = (SELECT Pk_TelemetriaTemperatura FROM tblTelemetriaTemperatura WHERE Fk_EncabezadoViaje_Codigo=@via2 AND fechaHoraUtcTelemetriaTemperatura='2026-10-20 11:15:00' LIMIT 1);

-- tblAlertaCadenaFrio
INSERT INTO tblAlertaCadenaFrio (Fk_EncabezadoViaje_Codigo, Fk_TelemetriaTemperatura_Codigo, tipoAlertaCadenaFrio, temperaturaRegistradaAlertaCadenaFrio, atendidaAlertaCadenaFrio, observacionCalidadAlertaCadenaFrio)
SELECT @via1, @tele1, 'CONTROL', 3.50, TRUE, 'Alerta de prueba A'
WHERE NOT EXISTS (SELECT 1 FROM tblAlertaCadenaFrio WHERE Fk_TelemetriaTemperatura_Codigo=@tele1 AND observacionCalidadAlertaCadenaFrio='Alerta de prueba A');

INSERT INTO tblAlertaCadenaFrio (Fk_EncabezadoViaje_Codigo, Fk_TelemetriaTemperatura_Codigo, tipoAlertaCadenaFrio, temperaturaRegistradaAlertaCadenaFrio, atendidaAlertaCadenaFrio, observacionCalidadAlertaCadenaFrio)
SELECT @via2, @tele2, 'TEMPERATURA', 6.00, FALSE, 'Alerta de prueba B'
WHERE NOT EXISTS (SELECT 1 FROM tblAlertaCadenaFrio WHERE Fk_TelemetriaTemperatura_Codigo=@tele2 AND observacionCalidadAlertaCadenaFrio='Alerta de prueba B');

-- tblStock
INSERT INTO tblStock (Fk_Sucursal_Codigo, Fk_Bodega_Codigo, Fk_Producto_Codigo, stockFisicoStock, stockVirtualStock, estadoVentaStock, estadoCompraStock)
SELECT @suc1, @bod1, @prod1, 100, 95, TRUE, TRUE
WHERE NOT EXISTS (SELECT 1 FROM tblStock WHERE Fk_Sucursal_Codigo=@suc1 AND Fk_Bodega_Codigo=@bod1 AND Fk_Producto_Codigo=@prod1);

INSERT INTO tblStock (Fk_Sucursal_Codigo, Fk_Bodega_Codigo, Fk_Producto_Codigo, stockFisicoStock, stockVirtualStock, estadoVentaStock, estadoCompraStock)
SELECT @suc2, @bod2, @prod2, 80, 80, TRUE, TRUE
WHERE NOT EXISTS (SELECT 1 FROM tblStock WHERE Fk_Sucursal_Codigo=@suc2 AND Fk_Bodega_Codigo=@bod2 AND Fk_Producto_Codigo=@prod2);

-- tblTipoMovimiento
INSERT INTO tblTipoMovimiento (nombreTipoMovimiento, descripcionTipoMovimiento, signoTipoMovimiento)
SELECT 'Entrada Demo', 'Entrada por prueba', '+'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoMovimiento WHERE nombreTipoMovimiento='Entrada Demo');

INSERT INTO tblTipoMovimiento (nombreTipoMovimiento, descripcionTipoMovimiento, signoTipoMovimiento)
SELECT 'Salida Demo', 'Salida por prueba', '-'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoMovimiento WHERE nombreTipoMovimiento='Salida Demo');

SET @tmov1 = (SELECT Pk_TipoMovimiento FROM tblTipoMovimiento WHERE nombreTipoMovimiento = 'Entrada Demo' LIMIT 1);
SET @tmov2 = (SELECT Pk_TipoMovimiento FROM tblTipoMovimiento WHERE nombreTipoMovimiento = 'Salida Demo' LIMIT 1);

-- tblMovimientoInventario
INSERT INTO tblMovimientoInventario (Fk_TipoMovimiento_Codigo, Fk_Bodega_OrigenCodigo, Fk_Bodega_DestinoCodigo, Fk_Transporte_Codigo, fechaMovimientoInventario, observacionesMovimientoInventario)
SELECT @tmov1, NULL, @bod1, @trans1, '2026-10-20 08:30:00', 'Movimiento demo 1'
WHERE NOT EXISTS (SELECT 1 FROM tblMovimientoInventario WHERE observacionesMovimientoInventario='Movimiento demo 1');

INSERT INTO tblMovimientoInventario (Fk_TipoMovimiento_Codigo, Fk_Bodega_OrigenCodigo, Fk_Bodega_DestinoCodigo, Fk_Transporte_Codigo, fechaMovimientoInventario, observacionesMovimientoInventario)
SELECT @tmov2, @bod2, NULL, @trans2, '2026-10-20 10:30:00', 'Movimiento demo 2'
WHERE NOT EXISTS (SELECT 1 FROM tblMovimientoInventario WHERE observacionesMovimientoInventario='Movimiento demo 2');

SET @mov1 = (SELECT Pk_MovimientoInventario FROM tblMovimientoInventario WHERE observacionesMovimientoInventario='Movimiento demo 1' LIMIT 1);
SET @mov2 = (SELECT Pk_MovimientoInventario FROM tblMovimientoInventario WHERE observacionesMovimientoInventario='Movimiento demo 2' LIMIT 1);

-- tblDetalleMovimiento
INSERT INTO tblDetalleMovimiento (Fk_MovimientoInventario_Codigo, loteMovimientoInventario, Fk_Producto_Codigo, cantidadDetalleMovimiento, precioCompraDetalleMovimiento)
SELECT @mov1, 'LOTE-DEMO-01', @prod1, 20, 10.5000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleMovimiento WHERE Fk_MovimientoInventario_Codigo=@mov1 AND Fk_Producto_Codigo=@prod1 AND loteMovimientoInventario='LOTE-DEMO-01');

INSERT INTO tblDetalleMovimiento (Fk_MovimientoInventario_Codigo, loteMovimientoInventario, Fk_Producto_Codigo, cantidadDetalleMovimiento, precioCompraDetalleMovimiento)
SELECT @mov2, 'LOTE-DEMO-02', @prod2, 12, 20.0000
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleMovimiento WHERE Fk_MovimientoInventario_Codigo=@mov2 AND Fk_Producto_Codigo=@prod2 AND loteMovimientoInventario='LOTE-DEMO-02');

-- tblTraslado
INSERT INTO tblTraslado (codigoTraslado, Fk_Bodega_OrigenCodigo, Fk_Bodega_DestinoCodigo, Fk_Transporte_Codigo, fechaSolicitudTraslado, fechaSalidaTraslado, fechaLlegadaTraslado, estadoTraslado, observacionesTraslado)
SELECT 'TR-LOG-DEMO-001', @bod1, @bod2, @trans1, '2026-10-20 08:00:00', NULL, NULL, 'SOLICITADO', 'Traslado de prueba pendiente'
WHERE NOT EXISTS (SELECT 1 FROM tblTraslado WHERE codigoTraslado='TR-LOG-DEMO-001');

INSERT INTO tblTraslado (codigoTraslado, Fk_Bodega_OrigenCodigo, Fk_Bodega_DestinoCodigo, Fk_Transporte_Codigo, fechaSolicitudTraslado, fechaSalidaTraslado, fechaLlegadaTraslado, estadoTraslado, observacionesTraslado)
SELECT 'TR-LOG-DEMO-002', @bod2, @bod1, @trans2, '2026-10-20 10:00:00', '2026-10-20 11:00:00', '2026-10-20 13:00:00', 'RECIBIDO', 'Traslado de prueba recibido'
WHERE NOT EXISTS (SELECT 1 FROM tblTraslado WHERE codigoTraslado='TR-LOG-DEMO-002');

SET @tras1 = (SELECT Pk_Traslado FROM tblTraslado WHERE codigoTraslado = 'TR-LOG-DEMO-001' LIMIT 1);
SET @tras2 = (SELECT Pk_Traslado FROM tblTraslado WHERE codigoTraslado = 'TR-LOG-DEMO-002' LIMIT 1);

-- tblDetalleTraslado
INSERT INTO tblDetalleTraslado (Fk_Traslado_Codigo, Fk_Producto_Codigo, cantidadDetalleTraslado)
SELECT @tras1, @prod1, 10
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleTraslado WHERE Fk_Traslado_Codigo=@tras1 AND Fk_Producto_Codigo=@prod1);

INSERT INTO tblDetalleTraslado (Fk_Traslado_Codigo, Fk_Producto_Codigo, cantidadDetalleTraslado)
SELECT @tras2, @prod2, 12
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleTraslado WHERE Fk_Traslado_Codigo=@tras2 AND Fk_Producto_Codigo=@prod2);

-- tblAuditoriaInventario
INSERT INTO tblAuditoriaInventario (Fk_MovimientoInventario_Codigo, fechaAuditoriaInventario, resultadoAuditoriaInventario, observacionesCalidadAuditoriaInventario, detallesAuditoriaInventario)
SELECT @mov1, '2026-10-20 14:00:00', 'Sin diferencias', 'Auditoria demo A', 'Conteo correcto'
WHERE NOT EXISTS (SELECT 1 FROM tblAuditoriaInventario WHERE Fk_MovimientoInventario_Codigo=@mov1 AND observacionesCalidadAuditoriaInventario='Auditoria demo A');

INSERT INTO tblAuditoriaInventario (Fk_MovimientoInventario_Codigo, fechaAuditoriaInventario, resultadoAuditoriaInventario, observacionesCalidadAuditoriaInventario, detallesAuditoriaInventario)
SELECT @mov2, '2026-10-20 15:00:00', 'Con diferencias', 'Auditoria demo B', 'Pendiente de ajuste'
WHERE NOT EXISTS (SELECT 1 FROM tblAuditoriaInventario WHERE Fk_MovimientoInventario_Codigo=@mov2 AND observacionesCalidadAuditoriaInventario='Auditoria demo B');

-- tblCierreMovimiento
INSERT INTO tblCierreMovimiento (nombreCierreMovimiento, fechaInicioCierreMovimiento, fechaFinCierreMovimiento, estadoCierreMovimiento, esCierreAnualCierreMovimiento, toleranciaCierreMovimiento, diferenciaUnidadesCierreMovimiento, diferenciaMontoCierreMovimiento, observacionesCierreMovimiento)
SELECT 'Cierre Demo Octubre A', '2026-10-01', '2026-10-15', 'ABIERTO', FALSE, 5, 0, 0.0000, 'Cierre de prueba A'
WHERE NOT EXISTS (SELECT 1 FROM tblCierreMovimiento WHERE nombreCierreMovimiento='Cierre Demo Octubre A');

INSERT INTO tblCierreMovimiento (nombreCierreMovimiento, fechaInicioCierreMovimiento, fechaFinCierreMovimiento, estadoCierreMovimiento, esCierreAnualCierreMovimiento, toleranciaCierreMovimiento, diferenciaUnidadesCierreMovimiento, diferenciaMontoCierreMovimiento, observacionesCierreMovimiento)
SELECT 'Cierre Demo Octubre B', '2026-10-16', '2026-10-31', 'ABIERTO', FALSE, 5, 0, 0.0000, 'Cierre de prueba B'
WHERE NOT EXISTS (SELECT 1 FROM tblCierreMovimiento WHERE nombreCierreMovimiento='Cierre Demo Octubre B');

SET @cie1 = (SELECT Pk_CierreMovimiento FROM tblCierreMovimiento WHERE nombreCierreMovimiento = 'Cierre Demo Octubre A' LIMIT 1);
SET @cie2 = (SELECT Pk_CierreMovimiento FROM tblCierreMovimiento WHERE nombreCierreMovimiento = 'Cierre Demo Octubre B' LIMIT 1);

-- tblDetalleCierre
INSERT INTO tblDetalleCierre (Fk_CierreMovimiento_Codigo, Fk_Sucursal_Codigo, Fk_Bodega_Codigo, Fk_Producto_Codigo)
SELECT @cie1, @suc1, @bod1, @prod1
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleCierre WHERE Fk_CierreMovimiento_Codigo=@cie1 AND Fk_Bodega_Codigo=@bod1 AND Fk_Producto_Codigo=@prod1);

INSERT INTO tblDetalleCierre (Fk_CierreMovimiento_Codigo, Fk_Sucursal_Codigo, Fk_Bodega_Codigo, Fk_Producto_Codigo)
SELECT @cie2, @suc2, @bod2, @prod2
WHERE NOT EXISTS (SELECT 1 FROM tblDetalleCierre WHERE Fk_CierreMovimiento_Codigo=@cie2 AND Fk_Bodega_Codigo=@bod2 AND Fk_Producto_Codigo=@prod2);

-- tblEmpresaTransportista
INSERT INTO tblEmpresaTransportista (nombreEmpresaTransportista, contactoEmpresaTransportista, telefonoEmpresaTransportista)
SELECT 'Transportadora Demo Uno', 'Carlos Ramirez', '55550001'
WHERE NOT EXISTS (SELECT 1 FROM tblEmpresaTransportista WHERE nombreEmpresaTransportista='Transportadora Demo Uno');

INSERT INTO tblEmpresaTransportista (nombreEmpresaTransportista, contactoEmpresaTransportista, telefonoEmpresaTransportista)
SELECT 'Transportadora Demo Dos', 'Maria Perez', '55550002'
WHERE NOT EXISTS (SELECT 1 FROM tblEmpresaTransportista WHERE nombreEmpresaTransportista='Transportadora Demo Dos');

SET @emp1 = (SELECT Pk_EmpresaTransportista FROM tblEmpresaTransportista WHERE nombreEmpresaTransportista = 'Transportadora Demo Uno' LIMIT 1);
SET @emp2 = (SELECT Pk_EmpresaTransportista FROM tblEmpresaTransportista WHERE nombreEmpresaTransportista = 'Transportadora Demo Dos' LIMIT 1);

-- tblTipoServicio
INSERT INTO tblTipoServicio (nombreTipoServicio)
SELECT 'Refrigerado Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoServicio WHERE nombreTipoServicio='Refrigerado Demo');

INSERT INTO tblTipoServicio (nombreTipoServicio)
SELECT 'Carga seca Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTipoServicio WHERE nombreTipoServicio='Carga seca Demo');

SET @servt1 = (SELECT Pk_TipoServicio FROM tblTipoServicio WHERE nombreTipoServicio = 'Refrigerado Demo' LIMIT 1);
SET @servt2 = (SELECT Pk_TipoServicio FROM tblTipoServicio WHERE nombreTipoServicio = 'Carga seca Demo' LIMIT 1);

-- tblTarifaTransporte
INSERT INTO tblTarifaTransporte (nombreTarifaTransporte)
SELECT 'Tarifa kilometro Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTarifaTransporte WHERE nombreTarifaTransporte='Tarifa kilometro Demo');

INSERT INTO tblTarifaTransporte (nombreTarifaTransporte)
SELECT 'Tarifa fija Demo'
WHERE NOT EXISTS (SELECT 1 FROM tblTarifaTransporte WHERE nombreTarifaTransporte='Tarifa fija Demo');

SET @tar1 = (SELECT Pk_TarifaTransporte FROM tblTarifaTransporte WHERE nombreTarifaTransporte = 'Tarifa kilometro Demo' LIMIT 1);
SET @tar2 = (SELECT Pk_TarifaTransporte FROM tblTarifaTransporte WHERE nombreTarifaTransporte = 'Tarifa fija Demo' LIMIT 1);

-- tblServicioTransporteExterno
INSERT INTO tblServicioTransporteExterno (Fk_EmpresaTransportista_Codigo, Fk_TipoServicio_Codigo, Fk_Traslado_Codigo, numeroGuiaServicioTransporteExterno, estadoServicioTransporteExterno, origenServicioTransporteExterno, direccionOrigenServicioTransporteExterno, destinoServicioTransporteExterno, direccionDestinoServicioTransporteExterno, fechaContratacionServicioTransporteExterno, fechaEstimadaEntregaServicioTransporteExterno, fechaEntregaRealServicioTransporteExterno)
SELECT @emp1, @servt1, @tras1, 'GUIA-LOG-DEMO-001', 'Programado', 'Guatemala', 'Bodega Demo Oriente', 'Quetzaltenango', 'Bodega Demo Occidente', '2026-10-20', '2026-10-23', NULL
WHERE NOT EXISTS (SELECT 1 FROM tblServicioTransporteExterno WHERE numeroGuiaServicioTransporteExterno='GUIA-LOG-DEMO-001');

INSERT INTO tblServicioTransporteExterno (Fk_EmpresaTransportista_Codigo, Fk_TipoServicio_Codigo, Fk_Traslado_Codigo, numeroGuiaServicioTransporteExterno, estadoServicioTransporteExterno, origenServicioTransporteExterno, direccionOrigenServicioTransporteExterno, destinoServicioTransporteExterno, direccionDestinoServicioTransporteExterno, fechaContratacionServicioTransporteExterno, fechaEstimadaEntregaServicioTransporteExterno, fechaEntregaRealServicioTransporteExterno)
SELECT @emp2, @servt2, @tras2, 'GUIA-LOG-DEMO-002', 'Entregado', 'Quetzaltenango', 'Bodega Demo Occidente', 'Guatemala', 'Bodega Demo Oriente', '2026-10-19', '2026-10-22', '2026-10-21'
WHERE NOT EXISTS (SELECT 1 FROM tblServicioTransporteExterno WHERE numeroGuiaServicioTransporteExterno='GUIA-LOG-DEMO-002');

SET @ste1 = (SELECT Pk_ServicioTransporteExterno FROM tblServicioTransporteExterno WHERE numeroGuiaServicioTransporteExterno = 'GUIA-LOG-DEMO-001' LIMIT 1);
SET @ste2 = (SELECT Pk_ServicioTransporteExterno FROM tblServicioTransporteExterno WHERE numeroGuiaServicioTransporteExterno = 'GUIA-LOG-DEMO-002' LIMIT 1);

-- tblCostoTransporte
INSERT INTO tblCostoTransporte (Fk_ServicioTransporteExterno_Codigo, Fk_TarifaTransporte_Codigo, cantidadCostoTransporte, costoUnitarioTransporte, costoTotalTransporte, monedaCostoTransporte, tipoPagoCostoTransporte)
SELECT @ste1, @tar1, 10.0000, 75.0000, 750.0000, 'GTQ', 'Transferencia'
WHERE NOT EXISTS (SELECT 1 FROM tblCostoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1);

INSERT INTO tblCostoTransporte (Fk_ServicioTransporteExterno_Codigo, Fk_TarifaTransporte_Codigo, cantidadCostoTransporte, costoUnitarioTransporte, costoTotalTransporte, monedaCostoTransporte, tipoPagoCostoTransporte)
SELECT @ste2, @tar2, 1.0000, 500.0000, 500.0000, 'GTQ', 'Efectivo'
WHERE NOT EXISTS (SELECT 1 FROM tblCostoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2);

-- tblVehiculoTransporte
INSERT INTO tblVehiculoTransporte (Fk_ServicioTransporteExterno_Codigo, placaVehiculoTransporte, tipoVehiculoTransporte, capacidadVehiculoTransporte)
SELECT @ste1, 'DEM-101', 'Camion', '3 toneladas'
WHERE NOT EXISTS (SELECT 1 FROM tblVehiculoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1);

INSERT INTO tblVehiculoTransporte (Fk_ServicioTransporteExterno_Codigo, placaVehiculoTransporte, tipoVehiculoTransporte, capacidadVehiculoTransporte)
SELECT @ste2, 'DEM-102', 'Furgon', '2 toneladas'
WHERE NOT EXISTS (SELECT 1 FROM tblVehiculoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2);

-- tblConductorTransporte
INSERT INTO tblConductorTransporte (Fk_ServicioTransporteExterno_Codigo, nombreConductorTransporte, telefonoConductorTransporte)
SELECT @ste1, 'Luis Perez Prueba', '55550101'
WHERE NOT EXISTS (SELECT 1 FROM tblConductorTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1);

INSERT INTO tblConductorTransporte (Fk_ServicioTransporteExterno_Codigo, nombreConductorTransporte, telefonoConductorTransporte)
SELECT @ste2, 'Ana Lopez Prueba', '55550102'
WHERE NOT EXISTS (SELECT 1 FROM tblConductorTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2);

-- tblProductoTransporte
INSERT INTO tblProductoTransporte (Fk_ServicioTransporteExterno_Codigo, Fk_Producto_Codigo, cantidadProductoTransporte, unidadMedidaProductoTransporte)
SELECT @ste1, @prod1, 10.0000, 'cajas'
WHERE NOT EXISTS (SELECT 1 FROM tblProductoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1 AND Fk_Producto_Codigo=@prod1);

INSERT INTO tblProductoTransporte (Fk_ServicioTransporteExterno_Codigo, Fk_Producto_Codigo, cantidadProductoTransporte, unidadMedidaProductoTransporte)
SELECT @ste2, @prod2, 12.0000, 'cajas'
WHERE NOT EXISTS (SELECT 1 FROM tblProductoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2 AND Fk_Producto_Codigo=@prod2);

-- tblUbicacionTransporte
INSERT INTO tblUbicacionTransporte (Fk_ServicioTransporteExterno_Codigo, ubicacionActualTransporte, fechaActualizacionUbicacionTransporte)
SELECT @ste1, 'Ciudad de Guatemala, punto demo 1', '2026-10-20 12:00:00'
WHERE NOT EXISTS (SELECT 1 FROM tblUbicacionTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1 AND ubicacionActualTransporte='Ciudad de Guatemala, punto demo 1');

INSERT INTO tblUbicacionTransporte (Fk_ServicioTransporteExterno_Codigo, ubicacionActualTransporte, fechaActualizacionUbicacionTransporte)
SELECT @ste2, 'Quetzaltenango, punto demo 2', '2026-10-20 13:00:00'
WHERE NOT EXISTS (SELECT 1 FROM tblUbicacionTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2 AND ubicacionActualTransporte='Quetzaltenango, punto demo 2');

-- tblIncidenciaTransporte
INSERT INTO tblIncidenciaTransporte (Fk_ServicioTransporteExterno_Codigo, codigoIncidenciaTransporte, fechaIncidenciaTransporte, tipoIncidenciaTransporte, descripcionIncidenciaTransporte, responsableIncidenciaTransporte, estadoIncidenciaTransporte)
SELECT @ste1, 'INC-LOG-DEMO-001', '2026-10-20 12:15:00', 'Retraso', 'Retraso simulado de prueba', 'Supervisor Demo', 'Pendiente'
WHERE NOT EXISTS (SELECT 1 FROM tblIncidenciaTransporte WHERE codigoIncidenciaTransporte='INC-LOG-DEMO-001');

INSERT INTO tblIncidenciaTransporte (Fk_ServicioTransporteExterno_Codigo, codigoIncidenciaTransporte, fechaIncidenciaTransporte, tipoIncidenciaTransporte, descripcionIncidenciaTransporte, responsableIncidenciaTransporte, estadoIncidenciaTransporte)
SELECT @ste2, 'INC-LOG-DEMO-002', '2026-10-20 13:15:00', 'Temperatura', 'Incidencia simulada de temperatura', 'Calidad Demo', 'Resuelto'
WHERE NOT EXISTS (SELECT 1 FROM tblIncidenciaTransporte WHERE codigoIncidenciaTransporte='INC-LOG-DEMO-002');

-- tblHistorialTransporte
INSERT INTO tblHistorialTransporte (Fk_ServicioTransporteExterno_Codigo, fechaMovimientoHistorial, tipoMovimientoHistorial, descripcionMovimientoHistorial, estadoTransporteHistorial)
SELECT @ste1, '2026-10-20 12:00:00', 'Registro', 'Historial demo 1', 'Programado'
WHERE NOT EXISTS (SELECT 1 FROM tblHistorialTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1 AND descripcionMovimientoHistorial='Historial demo 1');

INSERT INTO tblHistorialTransporte (Fk_ServicioTransporteExterno_Codigo, fechaMovimientoHistorial, tipoMovimientoHistorial, descripcionMovimientoHistorial, estadoTransporteHistorial)
SELECT @ste2, '2026-10-20 13:00:00', 'Entrega', 'Historial demo 2', 'Entregado'
WHERE NOT EXISTS (SELECT 1 FROM tblHistorialTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2 AND descripcionMovimientoHistorial='Historial demo 2');

-- tblSolicitudPagoTransporte
INSERT INTO tblSolicitudPagoTransporte (Fk_ServicioTransporteExterno_Codigo, codigoSolicitudPagoTransporte, estadoSolicitudPagoTransporte, referenciaBancariaSolicitudPagoTransporte, fechaPagoSolicitudPagoTransporte)
SELECT @ste1, 'SP-LOG-DEMO-001', 'Solicitado', NULL, NULL
WHERE NOT EXISTS (SELECT 1 FROM tblSolicitudPagoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste1);

INSERT INTO tblSolicitudPagoTransporte (Fk_ServicioTransporteExterno_Codigo, codigoSolicitudPagoTransporte, estadoSolicitudPagoTransporte, referenciaBancariaSolicitudPagoTransporte, fechaPagoSolicitudPagoTransporte)
SELECT @ste2, 'SP-LOG-DEMO-002', 'Pagado', 'REF-DEMO-002', '2026-10-21'
WHERE NOT EXISTS (SELECT 1 FROM tblSolicitudPagoTransporte WHERE Fk_ServicioTransporteExterno_Codigo=@ste2);

COMMIT;
-- Verificacion: mostrar cantidad total de registros en cada tabla.

SELECT 'tblEmpresaTransportista' AS tabla, COUNT(*) AS registros FROM tblEmpresaTransportista;
SELECT 'tblTipoServicio' AS tabla, COUNT(*) AS registros FROM tblTipoServicio;
SELECT 'tblTarifaTransporte' AS tabla, COUNT(*) AS registros FROM tblTarifaTransporte;
SELECT 'tblEstado' AS tabla, COUNT(*) AS registros FROM tblEstado;
SELECT 'tblTipoTransporte' AS tabla, COUNT(*) AS registros FROM tblTipoTransporte;
SELECT 'tblTransporte' AS tabla, COUNT(*) AS registros FROM tblTransporte;
SELECT 'tblCamaraRefrigeracion' AS tabla, COUNT(*) AS registros FROM tblCamaraRefrigeracion;
SELECT 'tblConductor' AS tabla, COUNT(*) AS registros FROM tblConductor;
SELECT 'tblInspeccionSanitaria' AS tabla, COUNT(*) AS registros FROM tblInspeccionSanitaria;
SELECT 'tblLoteProducto' AS tabla, COUNT(*) AS registros FROM tblLoteProducto;
SELECT 'tblEncabezadoViaje' AS tabla, COUNT(*) AS registros FROM tblEncabezadoViaje;
SELECT 'tblDetalleViaje' AS tabla, COUNT(*) AS registros FROM tblDetalleViaje;
SELECT 'tblDetalleViajeLoteProducto' AS tabla, COUNT(*) AS registros FROM tblDetalleViajeLoteProducto;
SELECT 'tblTelemetriaTemperatura' AS tabla, COUNT(*) AS registros FROM tblTelemetriaTemperatura;
SELECT 'tblAlertaCadenaFrio' AS tabla, COUNT(*) AS registros FROM tblAlertaCadenaFrio;
SELECT 'tblSucursal' AS tabla, COUNT(*) AS registros FROM tblSucursal;
SELECT 'tblBodega' AS tabla, COUNT(*) AS registros FROM tblBodega;
SELECT 'tblCategoria' AS tabla, COUNT(*) AS registros FROM tblCategoria;
SELECT 'tblLinea' AS tabla, COUNT(*) AS registros FROM tblLinea;
SELECT 'tblMarca' AS tabla, COUNT(*) AS registros FROM tblMarca;
SELECT 'tblProducto' AS tabla, COUNT(*) AS registros FROM tblProducto;
SELECT 'tblStock' AS tabla, COUNT(*) AS registros FROM tblStock;
SELECT 'tblTipoMovimiento' AS tabla, COUNT(*) AS registros FROM tblTipoMovimiento;
SELECT 'tblMovimientoInventario' AS tabla, COUNT(*) AS registros FROM tblMovimientoInventario;
SELECT 'tblDetalleMovimiento' AS tabla, COUNT(*) AS registros FROM tblDetalleMovimiento;
SELECT 'tblTraslado' AS tabla, COUNT(*) AS registros FROM tblTraslado;
SELECT 'tblDetalleTraslado' AS tabla, COUNT(*) AS registros FROM tblDetalleTraslado;
SELECT 'tblAuditoriaInventario' AS tabla, COUNT(*) AS registros FROM tblAuditoriaInventario;
SELECT 'tblCierreMovimiento' AS tabla, COUNT(*) AS registros FROM tblCierreMovimiento;
SELECT 'tblDetalleCierre' AS tabla, COUNT(*) AS registros FROM tblDetalleCierre;
SELECT 'tblServicioTransporteExterno' AS tabla, COUNT(*) AS registros FROM tblServicioTransporteExterno;
SELECT 'tblCostoTransporte' AS tabla, COUNT(*) AS registros FROM tblCostoTransporte;
SELECT 'tblVehiculoTransporte' AS tabla, COUNT(*) AS registros FROM tblVehiculoTransporte;
SELECT 'tblConductorTransporte' AS tabla, COUNT(*) AS registros FROM tblConductorTransporte;
SELECT 'tblProductoTransporte' AS tabla, COUNT(*) AS registros FROM tblProductoTransporte;
SELECT 'tblUbicacionTransporte' AS tabla, COUNT(*) AS registros FROM tblUbicacionTransporte;
SELECT 'tblIncidenciaTransporte' AS tabla, COUNT(*) AS registros FROM tblIncidenciaTransporte;
SELECT 'tblHistorialTransporte' AS tabla, COUNT(*) AS registros FROM tblHistorialTransporte;
SELECT 'tblSolicitudPagoTransporte' AS tabla, COUNT(*) AS registros FROM tblSolicitudPagoTransporte;
