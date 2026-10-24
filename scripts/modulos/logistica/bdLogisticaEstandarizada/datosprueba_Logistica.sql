use dbLogistica;

-- TERMINUS ERP / LOGISTICA: 5 DATOS DE PRUEBA POR TABLA
-- SOLO EJECUTAR EN LA BD DE PRUEBAS VACIA CREADA POR EL SCRIPT.
-- Usa identificadores explicitos 1-5, respetando todas las FK y UNIQUE.
-- No ejecutar dos veces: ya existen PK/UNIQUE y generara errores.
-- No usar en produccion. El campo imagenProducto contiene una imagen PNG minima de ejemplo.

USE dbLogistica;
START TRANSACTION;

-- tblEmpresaTransportista
INSERT INTO tblEmpresaTransportista (
    Pk_EmpresaTransportista,
    nombreEmpresaTransportista,
    contactoEmpresaTransportista,
    telefonoEmpresaTransportista
) VALUES
    (1, 'Translogistica Maya', 'Ana Morales', '5550-1001'),
    (2, 'Carga Chapina', 'Luis Perez', '5550-1002'),
    (3, 'Transportes del Valle', 'Maria Lopez', '5550-1003'),
    (4, 'Frio Express GT', 'Carlos Gomez', '5550-1004'),
    (5, 'Rutas del Pacifico', 'Elena Ruiz', '5550-1005');

-- tblTipoServicio
INSERT INTO tblTipoServicio (
    Pk_TipoServicio,
    nombreTipoServicio
) VALUES
    (1, 'Refrigerado'),
    (2, 'Congelado'),
    (3, 'Carga seca'),
    (4, 'Carga especial'),
    (5, 'Distribucion local');

-- tblTarifaTransporte
INSERT INTO tblTarifaTransporte (
    Pk_TarifaTransporte,
    nombreTarifaTransporte
) VALUES
    (1, 'Tarifa por kilometro'),
    (2, 'Tarifa refrigerada'),
    (3, 'Tarifa carga seca'),
    (4, 'Tarifa por tonelada'),
    (5, 'Tarifa urbana');

-- tblEstado
INSERT INTO tblEstado (
    Pk_Estado,
    tipoEstado
) VALUES
    (1, 'ACTIVO'),
    (2, 'INACTIVO'),
    (3, 'MANTENIMIENTO'),
    (4, 'DISPONIBLE'),
    (5, 'SUSPENDIDO');

-- tblTipoTransporte
INSERT INTO tblTipoTransporte (
    Pk_TipoTransporte,
    nombreTipoTransporte
) VALUES
    (1, 'Camion refrigerado'),
    (2, 'Panel'),
    (3, 'Camion pesado'),
    (4, 'Pickup'),
    (5, 'Furgon');

-- tblTransporte
INSERT INTO tblTransporte (
    Pk_Transporte,
    nroPlacaTransporte,
    marcaTransporte,
    modeloTransporte,
    anioTransporte,
    esRefrigeradoTransporte,
    Fk_Estado_Codigo,
    Fk_TipoTransporte_Codigo
) VALUES
    (1, 'P101ABC', 'Hino', '300', 2020, 1, 1, 1),
    (2, 'P102ABC', 'Isuzu', 'NQR', 2021, 1, 2, 2),
    (3, 'P103ABC', 'Mitsubishi', 'Canter', 2022, 1, 3, 3),
    (4, 'P104ABC', 'Toyota', 'Hilux', 2023, 1, 4, 4),
    (5, 'P105ABC', 'Hyundai', 'HD78', 2024, 1, 5, 5);

-- tblCamaraRefrigeracion
INSERT INTO tblCamaraRefrigeracion (
    Pk_CamaraRefrigeracion,
    Fk_Transporte_Codigo,
    marcaEquipoCamaraRefrigeracion,
    tempMinimaCelsiusCamaraRefrigeracion,
    tempMaximaCelsiusCamaraRefrigeracion,
    estadoOperativoCamaraRefrigeracion
) VALUES
    (1, 1, 'Thermo King', -2, 5, 'OPERATIVO'),
    (2, 2, 'Carrier', -2, 5, 'OPERATIVO'),
    (3, 3, 'Thermo King', -2, 5, 'OPERATIVO'),
    (4, 4, 'Carrier', -2, 5, 'OPERATIVO'),
    (5, 5, 'Frigoblock', -2, 5, 'OPERATIVO');

-- tblConductor
INSERT INTO tblConductor (
    Pk_Conductor,
    codigoConductor,
    nombreCompletoConductor,
    numeroLicenciaConductor,
    fechaVencimientoDocConductor,
    Fk_Estado_Codigo
) VALUES
    (1, 'COND-001', 'Juan Perez Lopez', 'LIC-GT-1001', '2028-05-10', 1),
    (2, 'COND-002', 'Pedro Garcia', 'LIC-GT-1002', '2028-05-11', 2),
    (3, 'COND-003', 'Luis Morales', 'LIC-GT-1003', '2028-05-12', 3),
    (4, 'COND-004', 'Marco Soto', 'LIC-GT-1004', '2028-05-13', 4),
    (5, 'COND-005', 'David Ramirez', 'LIC-GT-1005', '2028-05-14', 5);

-- tblInspeccionSanitaria
INSERT INTO tblInspeccionSanitaria (
    Pk_InspeccionSanitaria,
    Fk_Transporte_Codigo,
    fechaInspeccionSanitaria,
    sanitizadoCorrectoInspeccionSanitaria,
    libreOloresContamInspeccionSanitaria,
    aprobadoParaCargaInspeccionSanitaria,
    observacionesInspeccionSanitaria
) VALUES
    (1, 1, '2026-10-02 07:00:00', 1, 1, 1, 'Vehiculo limpio y aprobado'),
    (2, 2, '2026-10-03 07:00:00', 1, 1, 1, 'Vehiculo limpio y aprobado'),
    (3, 3, '2026-10-04 07:00:00', 1, 1, 1, 'Vehiculo limpio y aprobado'),
    (4, 4, '2026-10-05 07:00:00', 1, 1, 1, 'Vehiculo limpio y aprobado'),
    (5, 5, '2026-10-06 07:00:00', 1, 1, 1, 'Vehiculo limpio y aprobado');

-- tblLoteProducto
INSERT INTO tblLoteProducto (
    Pk_LoteProducto,
    codigoLoteProducto,
    descripcionLoteProducto,
    requiereFrioLoteProducto,
    fechaFabricacionLoteProducto,
    fechaVencimientoLoteProducto,
    tempRequeridaMinLoteProducto,
    tempRequeridaMaxLoteProducto
) VALUES
    (1, 'LOT-001', 'Lote de jamon cocido', 1, '2026-08-10', '2026-12-10', -2, 5),
    (2, 'LOT-002', 'Lote de salchichas', 1, '2026-08-11', '2026-12-11', -2, 5),
    (3, 'LOT-003', 'Lote de chorizo', 1, '2026-08-12', '2026-12-12', -2, 5),
    (4, 'LOT-004', 'Lote de mortadela', 1, '2026-08-13', '2026-12-13', -2, 5),
    (5, 'LOT-005', 'Lote de tocino', 1, '2026-08-14', '2026-12-14', -2, 5);

-- tblEncabezadoViaje
INSERT INTO tblEncabezadoViaje (
    Pk_EncabezadoViaje,
    fechaDocumentoEncabezadoViaje,
    horaSalidaEncabezadoViaje,
    horaLlegadaEncabezadoViaje,
    requiereCadenaFrioEncabezadoViaje,
    estadoViajeEncabezadoViaje,
    pesoTotalEncabezadoViaje,
    Fk_Transporte_Codigo,
    Fk_Conductor_Codigo
) VALUES
    (1, '2026-10-02 07:00:00', '2026-10-02 08:00:00', '2026-10-02 12:00:00', 1, 'FINALIZADO', 135, 1, 1),
    (2, '2026-10-03 07:00:00', '2026-10-03 08:00:00', '2026-10-03 12:00:00', 1, 'FINALIZADO', 145, 2, 2),
    (3, '2026-10-04 07:00:00', '2026-10-04 08:00:00', '2026-10-04 12:00:00', 1, 'FINALIZADO', 155, 3, 3),
    (4, '2026-10-05 07:00:00', '2026-10-05 08:00:00', '2026-10-05 12:00:00', 1, 'FINALIZADO', 165, 4, 4),
    (5, '2026-10-06 07:00:00', '2026-10-06 08:00:00', '2026-10-06 12:00:00', 1, 'FINALIZADO', 175, 5, 5);

-- tblDetalleViaje
INSERT INTO tblDetalleViaje (
    Pk_DetalleViaje,
    Fk_EncabezadoViaje_Codigo,
    ordenDetalleViaje,
    descripcionDetalleViaje,
    cantidadDetalleViaje,
    pesoDetalleViaje
) VALUES
    (1, 1, 1, 'Cajas de jamon', 21, 55),
    (2, 2, 1, 'Cajas de salchicha', 22, 60),
    (3, 3, 1, 'Cajas de chorizo', 23, 65),
    (4, 4, 1, 'Cajas de mortadela', 24, 70),
    (5, 5, 1, 'Cajas de tocino', 25, 75);

-- tblDetalleViajeLoteProducto
INSERT INTO tblDetalleViajeLoteProducto (
    Fk_DetalleViaje_Codigo,
    Fk_LoteProducto_Codigo,
    cantidadCajasDetalleViajeLoteProducto,
    pesoKgDetalleViajeLoteProducto
) VALUES
    (1, 1, 11, 55),
    (2, 2, 12, 60),
    (3, 3, 13, 65),
    (4, 4, 14, 70),
    (5, 5, 15, 75);

-- tblTelemetriaTemperatura
INSERT INTO tblTelemetriaTemperatura (
    Pk_TelemetriaTemperatura,
    Fk_EncabezadoViaje_Codigo,
    fechaHoraTelemetriaTemperatura,
    temperaturaCelsiusTelemetriaTemperatura,
    humedadRelativaTelemetriaTemperatura,
    puertaAbiertaTelemetriaTemperatura,
    ubicacionGpsTelemetriaTemperatura
) VALUES
    (1, 1, '2026-10-02 07:00:00', 8, '.6500', 0, 'Ciudad de Guatemala'),
    (2, 2, '2026-10-03 07:00:00', 9, '.6500', 0, 'Mixco'),
    (3, 3, '2026-10-04 07:00:00', 10, '.6500', 0, 'Villa Nueva'),
    (4, 4, '2026-10-05 07:00:00', 7, '.6500', 0, 'Amatitlan'),
    (5, 5, '2026-10-06 07:00:00', 11, '.6500', 0, 'Escuintla');

-- tblAlertaCadenaFrio
INSERT INTO tblAlertaCadenaFrio (
    Pk_AlertaCadenaFrio,
    Fk_EncabezadoViaje_Codigo,
    Fk_TelemetriaTemperatura_Codigo,
    tipoAlertaCadenaFrio,
    temperaturaRegistradaAlertaCadenaFrio,
    atendidaAlertaCadenaFrio,
    observacionCalidadAlertaCadenaFrio
) VALUES
    (1, 1, 1, 'TEMPERATURA_ALTA', 8, 0, 'Alerta registrada para pruebas'),
    (2, 2, 2, 'TEMPERATURA_ALTA', 9, 0, 'Alerta registrada para pruebas'),
    (3, 3, 3, 'TEMPERATURA_ALTA', 10, 0, 'Alerta registrada para pruebas'),
    (4, 4, 4, 'TEMPERATURA_ALTA', 7, 0, 'Alerta registrada para pruebas'),
    (5, 5, 5, 'TEMPERATURA_ALTA', 11, 0, 'Alerta registrada para pruebas');

-- tblSucursal
INSERT INTO tblSucursal (
    Pk_Sucursal,
    nombreSucursal,
    descripcionSucursal,
    ubicacionSucursal,
    paisSucursal
) VALUES
    (1, 'Sucursal Central', 'Dato de prueba 1', 'Zona 12, Ciudad de Guatemala', 'Guatemala'),
    (2, 'Sucursal Mixco', 'Dato de prueba 2', 'Mixco, Guatemala', 'Guatemala'),
    (3, 'Sucursal Villa Nueva', 'Dato de prueba 3', 'Villa Nueva, Guatemala', 'Guatemala'),
    (4, 'Sucursal Amatitlan', 'Dato de prueba 4', 'Amatitlan, Guatemala', 'Guatemala'),
    (5, 'Sucursal Escuintla', 'Dato de prueba 5', 'Escuintla, Escuintla', 'Guatemala');

-- tblBodega
INSERT INTO tblBodega (
    Pk_Bodega,
    nombreBodega,
    Fk_Sucursal_Codigo,
    paisBodega
) VALUES
    (1, 'Bodega Central', 1, 'Guatemala'),
    (2, 'Bodega Mixco', 2, 'Guatemala'),
    (3, 'Bodega Villa Nueva', 3, 'Guatemala'),
    (4, 'Bodega Amatitlan', 4, 'Guatemala'),
    (5, 'Bodega Escuintla', 5, 'Guatemala');

-- tblCategoria
INSERT INTO tblCategoria (
    Pk_Categoria,
    nombreCategoria,
    porcentajeComisionCategoria
) VALUES
    (1, 'Embutidos', '.05'),
    (2, 'Carnes frias', '.05'),
    (3, 'Ahumados', '.05'),
    (4, 'Congelados', '.05'),
    (5, 'Especialidades', '.05');

-- tblLinea
INSERT INTO tblLinea (
    Pk_Linea,
    nombreLinea,
    porcentajeComisionLinea
) VALUES
    (1, 'Tradicional', '.05'),
    (2, 'Premium', '.05'),
    (3, 'Familiar', '.05'),
    (4, 'Economica', '.05'),
    (5, 'Gourmet', '.05');

-- tblMarca
INSERT INTO tblMarca (
    Pk_Marca,
    nombreMarca,
    porcentajeComisionMarca
) VALUES
    (1, 'Embutidos Maya', '.05'),
    (2, 'Del Campo', '.05'),
    (3, 'La Granja', '.05'),
    (4, 'Sabor Chapin', '.05'),
    (5, 'Tradicion GT', '.05');

-- tblProducto
INSERT INTO tblProducto (
    Pk_Producto,
    skuProducto,
    clasificacionProducto,
    nombreProducto,
    Fk_Marca_Codigo,
    Fk_Categoria_Codigo,
    Fk_Linea_Codigo,
    descripcionProducto,
    imagenProducto,
    paisProducto,
    precioCompraProducto,
    precioVentaProducto,
    porcentajeComisionProducto,
    stockMinimoProducto,
    stockMaximoProducto,
    pesoProducto
) VALUES
    (1, 'EMB-0001', 'EMB01', 'Jamon cocido', 1, 1, 1, 'Jamon cocido empacado', 0x89504e470d0a1a0a0000000d4948445200000001000000010804000000b51c0c020000000b4944415478da63fcff1f0002eb01f5897543a90000000049454e44ae426082, 'Guatemala', 18.5, 26, '.05', 10, 500, '.75'),
    (2, 'EMB-0002', 'EMB02', 'Salchicha de pollo', 2, 2, 2, 'Salchicha de pollo empacada', 0x89504e470d0a1a0a0000000d4948445200000001000000010804000000b51c0c020000000b4944415478da63fcff1f0002eb01f5897543a90000000049454e44ae426082, 'Guatemala', 13.75, 20, '.05', 10, 500, '.75'),
    (3, 'EMB-0003', 'EMB03', 'Chorizo criollo', 3, 3, 3, 'Chorizo criollo empacado', 0x89504e470d0a1a0a0000000d4948445200000001000000010804000000b51c0c020000000b4944415478da63fcff1f0002eb01f5897543a90000000049454e44ae426082, 'Guatemala', 21, 30, '.05', 10, 500, '.75'),
    (4, 'EMB-0004', 'EMB04', 'Mortadela especial', 4, 4, 4, 'Mortadela empacada', 0x89504e470d0a1a0a0000000d4948445200000001000000010804000000b51c0c020000000b4944415478da63fcff1f0002eb01f5897543a90000000049454e44ae426082, 'Guatemala', 17.25, 25, '.05', 10, 500, '.75'),
    (5, 'EMB-0005', 'EMB05', 'Tocino ahumado', 5, 5, 5, 'Tocino ahumado empacado', 0x89504e470d0a1a0a0000000d4948445200000001000000010804000000b51c0c020000000b4944415478da63fcff1f0002eb01f5897543a90000000049454e44ae426082, 'Guatemala', 29, 42, '.05', 10, 500, '.75');

-- tblStock
INSERT INTO tblStock (
    Pk_Stock,
    Fk_Sucursal_Codigo,
    Fk_Bodega_Codigo,
    Fk_Producto_Codigo,
    stockFisicoStock,
    stockVirtualStock,
    estadoVentaStock,
    estadoCompraStock
) VALUES
    (1, 1, 1, 1, 110, 100, 1, 1),
    (2, 2, 2, 2, 120, 110, 1, 1),
    (3, 3, 3, 3, 130, 120, 1, 1),
    (4, 4, 4, 4, 140, 130, 1, 1),
    (5, 5, 5, 5, 150, 140, 1, 1);

-- tblTipoMovimiento
INSERT INTO tblTipoMovimiento (
    Pk_TipoMovimiento,
    nombreTipoMovimiento,
    descripcionTipoMovimiento,
    signoTipoMovimiento
) VALUES
    (1, 'Entrada por compra', 'Ingreso de mercaderia', '+'),
    (2, 'Salida por venta', 'Egreso por venta', '-'),
    (3, 'Ajuste positivo', 'Ajuste por sobrante', '+'),
    (4, 'Ajuste negativo', 'Ajuste por faltante', '-'),
    (5, 'Devolucion de cliente', 'Devolucion recibida', '+');

-- tblMovimientoInventario
INSERT INTO tblMovimientoInventario (
    Pk_MovimientoInventario,
    Fk_TipoMovimiento_Codigo,
    Fk_Bodega_Origen_Codigo,
    Fk_Bodega_Destino_Codigo,
    Fk_Transporte_Codigo,
    fechaMovimientoInventario,
    observacionesMovimientoInventario
) VALUES
    (1, 1, 1, 2, 1, '2026-10-02 07:00:00', 'Movimiento de inventario de prueba'),
    (2, 2, 2, 3, 2, '2026-10-03 07:00:00', 'Movimiento de inventario de prueba'),
    (3, 3, 3, 4, 3, '2026-10-04 07:00:00', 'Movimiento de inventario de prueba'),
    (4, 4, 4, 5, 4, '2026-10-05 07:00:00', 'Movimiento de inventario de prueba'),
    (5, 5, 5, 1, 5, '2026-10-06 07:00:00', 'Movimiento de inventario de prueba');

-- tblDetalleMovimiento
INSERT INTO tblDetalleMovimiento (
    Pk_DetalleMovimiento,
    Fk_MovimientoInventario_Codigo,
    loteMovimientoInventario,
    Fk_Producto_Codigo,
    cantidadDetalleMovimiento,
    precioCompraDetalleMovimiento
) VALUES
    (1, 1, 'LOT-001', 1, 11, 18.5),
    (2, 2, 'LOT-002', 2, 12, 13.75),
    (3, 3, 'LOT-003', 3, 13, 21),
    (4, 4, 'LOT-004', 4, 14, 17.25),
    (5, 5, 'LOT-005', 5, 15, 29);

-- tblTraslado
INSERT INTO tblTraslado (
    Pk_Traslado,
    codigoTraslado,
    Fk_Bodega_Origen_Codigo,
    Fk_Bodega_Destino_Codigo,
    Fk_Transporte_Codigo,
    fechaSolicitudTraslado,
    fechaSalidaTraslado,
    fechaLlegadaTraslado,
    estadoTraslado,
    observacionesTraslado
) VALUES
    (1, 'TRA-0001', 1, 2, 1, '2026-10-02 07:00:00', '2026-10-02 08:00:00', '2026-10-02 12:00:00', 'RECIBIDO', 'Traslado de prueba para logistica'),
    (2, 'TRA-0002', 2, 3, 2, '2026-10-03 07:00:00', '2026-10-03 08:00:00', '2026-10-03 12:00:00', 'RECIBIDO', 'Traslado de prueba para logistica'),
    (3, 'TRA-0003', 3, 4, 3, '2026-10-04 07:00:00', '2026-10-04 08:00:00', '2026-10-04 12:00:00', 'RECIBIDO', 'Traslado de prueba para logistica'),
    (4, 'TRA-0004', 4, 5, 4, '2026-10-05 07:00:00', '2026-10-05 08:00:00', '2026-10-05 12:00:00', 'EN_TRANSITO', 'Traslado de prueba para logistica'),
    (5, 'TRA-0005', 5, 1, 5, '2026-10-06 07:00:00', '2026-10-06 08:00:00', '2026-10-06 12:00:00', 'SOLICITADO', 'Traslado de prueba para logistica');

-- tblDetalleTraslado
INSERT INTO tblDetalleTraslado (
    Fk_Traslado_Codigo,
    Fk_Producto_Codigo,
    cantidadDetalleTraslado
) VALUES
    (1, 1, 11),
    (2, 2, 12),
    (3, 3, 13),
    (4, 4, 14),
    (5, 5, 15);

-- tblAuditoriaInventario
INSERT INTO tblAuditoriaInventario (
    Pk_AuditoriaInventario,
    Fk_MovimientoInventario_Codigo,
    fechaAuditoriaInventario,
    resultadoAuditoriaInventario,
    observacionesCalidadAuditoriaInventario,
    detallesAuditoriaInventario
) VALUES
    (1, 1, '2026-10-02 07:00:00', 'CONFORME', 'Revision de inventario realizada', 'Conteo de inventario de prueba'),
    (2, 2, '2026-10-03 07:00:00', 'CONFORME', 'Revision de inventario realizada', 'Conteo de inventario de prueba'),
    (3, 3, '2026-10-04 07:00:00', 'DIFERENCIA', 'Revision de inventario realizada', 'Conteo de inventario de prueba'),
    (4, 4, '2026-10-05 07:00:00', 'CONFORME', 'Revision de inventario realizada', 'Conteo de inventario de prueba'),
    (5, 5, '2026-10-06 07:00:00', 'DIFERENCIA', 'Revision de inventario realizada', 'Conteo de inventario de prueba');

-- tblCierreMovimiento
INSERT INTO tblCierreMovimiento (
    Pk_CierreMovimiento,
    nombreCierreMovimiento,
    fechaInicioCierreMovimiento,
    fechaFinCierreMovimiento,
    estadoCierreMovimiento,
    esCierreAnualCierreMovimiento,
    toleranciaCierreMovimiento,
    diferenciaUnidadesCierreMovimiento,
    diferenciaMontoCierreMovimiento,
    motivoAceptacionCierreMovimiento,
    motivoAnulacionCierreMovimiento,
    observacionesCierreMovimiento
) VALUES
    (1, 'Cierre junio 2026', '2026-06-01', '2026-06-30', 'CERRADO', 0, 0, 0, 0, 'Cierre de prueba aceptado', 'Sin anulacion', 'Cierre mensual de prueba'),
    (2, 'Cierre julio 2026', '2026-07-01', '2026-07-31', 'CERRADO', 0, 0, 0, 0, 'Cierre de prueba aceptado', 'Sin anulacion', 'Cierre mensual de prueba'),
    (3, 'Cierre agosto 2026', '2026-08-01', '2026-08-31', 'CERRADO', 0, 0, 0, 0, 'Cierre de prueba aceptado', 'Sin anulacion', 'Cierre mensual de prueba'),
    (4, 'Cierre septiembre 2026', '2026-09-01', '2026-09-30', 'CERRADO', 0, 0, 0, 0, 'Cierre de prueba aceptado', 'Sin anulacion', 'Cierre mensual de prueba'),
    (5, 'Cierre octubre 2026', '2026-10-01', '2026-10-31', 'ABIERTO', 0, 0, 0, 0, 'Cierre de prueba aceptado', 'Sin anulacion', 'Cierre mensual de prueba');

-- tblDetalleCierre
INSERT INTO tblDetalleCierre (
    Pk_DetalleCierre,
    Fk_CierreMovimiento_Codigo,
    Fk_Stock_Codigo
) VALUES
    (1, 1, 1),
    (2, 2, 2),
    (3, 3, 3),
    (4, 4, 4),
    (5, 5, 5);

-- tblServicioTransporteExterno
INSERT INTO tblServicioTransporteExterno (
    Pk_ServicioTransporteExterno,
    Fk_EmpresaTransportista_Codigo,
    Fk_TipoServicio_Codigo,
    Fk_Traslado_Codigo,
    numeroGuiaServicioTransporteExterno,
    estadoServicioTransporteExterno,
    origenServicioTransporteExterno,
    direccionOrigenServicioTransporteExterno,
    destinoServicioTransporteExterno,
    direccionDestinoServicioTransporteExterno,
    fechaContratacionServicioTransporteExterno,
    fechaEstimadaEntregaServicioTransporteExterno,
    fechaEntregaRealServicioTransporteExterno
) VALUES
    (1, 1, 1, 1, 'GUIA-0001', 'Entregado', 'Guatemala', 'Zona 12', 'Mixco', 'Calzada Roosevelt', '2026-10-02', '2026-10-04', '2026-10-04'),
    (2, 2, 2, 2, 'GUIA-0002', 'Entregado', 'Mixco', 'Calzada Roosevelt', 'Villa Nueva', 'Villa Nueva centro', '2026-10-03', '2026-10-05', '2026-10-05'),
    (3, 3, 3, 3, 'GUIA-0003', 'Entregado', 'Villa Nueva', 'Villa Nueva centro', 'Amatitlan', 'Amatitlan centro', '2026-10-04', '2026-10-06', '2026-10-06'),
    (4, 4, 4, 4, 'GUIA-0004', 'En tránsito', 'Amatitlan', 'Amatitlan centro', 'Escuintla', 'Escuintla centro', '2026-10-05', '2026-10-07', '2026-10-07'),
    (5, 5, 5, 5, 'GUIA-0005', 'Programado', 'Escuintla', 'Escuintla centro', 'Guatemala', 'Zona 12', '2026-10-06', '2026-10-08', '2026-10-08');

-- tblCostoTransporte
INSERT INTO tblCostoTransporte (
    Pk_CostoTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    Fk_TarifaTransporte_Codigo,
    cantidadCostoTransporte,
    costoUnitarioTransporte,
    costoTotalTransporte,
    monedaCostoTransporte,
    tipoPagoCostoTransporte
) VALUES
    (1, 1, 1, 1, 275, 275, 'GTQ', 'Transferencia'),
    (2, 2, 2, 1, 300, 300, 'GTQ', 'Efectivo'),
    (3, 3, 3, 1, 325, 325, 'GTQ', 'Transferencia'),
    (4, 4, 4, 1, 350, 350, 'GTQ', 'Efectivo'),
    (5, 5, 5, 1, 375, 375, 'USD', 'Transferencia');

-- tblVehiculoTransporte
INSERT INTO tblVehiculoTransporte (
    Pk_VehiculoTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    placaVehiculoTransporte,
    tipoVehiculoTransporte,
    capacidadVehiculoTransporte
) VALUES
    (1, 1, 'C201XYZ', 'Camion refrigerado', '5 toneladas'),
    (2, 2, 'C202XYZ', 'Panel', '2 toneladas'),
    (3, 3, 'C203XYZ', 'Camion pesado', '8 toneladas'),
    (4, 4, 'C204XYZ', 'Pickup', '1 tonelada'),
    (5, 5, 'C205XYZ', 'Furgon', '4 toneladas');

-- tblConductorTransporte
INSERT INTO tblConductorTransporte (
    Pk_ConductorTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    nombreConductorTransporte,
    telefonoConductorTransporte
) VALUES
    (1, 1, 'Juan Perez Lopez', '5550-1001'),
    (2, 2, 'Pedro Garcia', '5550-1002'),
    (3, 3, 'Luis Morales', '5550-1003'),
    (4, 4, 'Marco Soto', '5550-1004'),
    (5, 5, 'David Ramirez', '5550-1005');

-- tblProductoTransporte
INSERT INTO tblProductoTransporte (
    Pk_ProductoTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    Fk_Producto_Codigo,
    cantidadProductoTransporte,
    unidadMedidaProductoTransporte
) VALUES
    (1, 1, 1, 11, 'Cajas'),
    (2, 2, 2, 12, 'Cajas'),
    (3, 3, 3, 13, 'Cajas'),
    (4, 4, 4, 14, 'Cajas'),
    (5, 5, 5, 15, 'Cajas');

-- tblUbicacionTransporte
INSERT INTO tblUbicacionTransporte (
    Pk_UbicacionTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    ubicacionActualTransporte,
    fechaActualizacionUbicacionTransporte
) VALUES
    (1, 1, 'Centro de distribucion zona 12', '2026-10-02 07:00:00'),
    (2, 2, 'Ruta Interamericana', '2026-10-03 07:00:00'),
    (3, 3, 'Bodega Villa Nueva', '2026-10-04 07:00:00'),
    (4, 4, 'Autopista Palín', '2026-10-05 07:00:00'),
    (5, 5, 'Bodega Escuintla', '2026-10-06 07:00:00');

-- tblIncidenciaTransporte
INSERT INTO tblIncidenciaTransporte (
    Pk_IncidenciaTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    codigoIncidenciaTransporte,
    fechaIncidenciaTransporte,
    tipoIncidenciaTransporte,
    descripcionIncidenciaTransporte,
    responsableIncidenciaTransporte,
    estadoIncidenciaTransporte
) VALUES
    (1, 1, 'INC-0001', '2026-10-02 07:00:00', 'Retraso', 'Evento de prueba registrado', 'Ana Morales', 'Resuelta'),
    (2, 2, 'INC-0002', '2026-10-03 07:00:00', 'Desvio', 'Evento de prueba registrado', 'Luis Perez', 'Resuelta'),
    (3, 3, 'INC-0003', '2026-10-04 07:00:00', 'Averia menor', 'Evento de prueba registrado', 'Maria Lopez', 'Resuelta'),
    (4, 4, 'INC-0004', '2026-10-05 07:00:00', 'Espera', 'Evento de prueba registrado', 'Carlos Gomez', 'En proceso'),
    (5, 5, 'INC-0005', '2026-10-06 07:00:00', 'Documentacion', 'Evento de prueba registrado', 'Elena Ruiz', 'Pendiente');

-- tblHistorialTransporte
INSERT INTO tblHistorialTransporte (
    Pk_HistorialTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    fechaMovimientoHistorial,
    tipoMovimientoHistorial,
    descripcionMovimientoHistorial,
    estadoTransporteHistorial
) VALUES
    (1, 1, '2026-10-02 07:00:00', 'Salida', 'Seguimiento de transporte de prueba', 'Entregado'),
    (2, 2, '2026-10-03 07:00:00', 'En ruta', 'Seguimiento de transporte de prueba', 'Entregado'),
    (3, 3, '2026-10-04 07:00:00', 'Llegada', 'Seguimiento de transporte de prueba', 'Entregado'),
    (4, 4, '2026-10-05 07:00:00', 'Inspeccion', 'Seguimiento de transporte de prueba', 'En tránsito'),
    (5, 5, '2026-10-06 07:00:00', 'Entrega', 'Seguimiento de transporte de prueba', 'Programado');

-- tblSolicitudPagoTransporte
INSERT INTO tblSolicitudPagoTransporte (
    Pk_SolicitudPagoTransporte,
    Fk_ServicioTransporteExterno_Codigo,
    codigoSolicitudPagoTransporte,
    estadoSolicitudPagoTransporte,
    referenciaBancariaSolicitudPagoTransporte,
    fechaPagoSolicitudPagoTransporte
) VALUES
    (1, 1, 'SP-000001', 'Pagado', 'BAN-REF-0001', '2026-10-11'),
    (2, 2, 'SP-000002', 'Pagado', 'BAN-REF-0002', '2026-10-12'),
    (3, 3, 'SP-000003', 'Pagado', 'BAN-REF-0003', '2026-10-13'),
    (4, 4, 'SP-000004', 'Pagado', 'BAN-REF-0004', '2026-10-14'),
    (5, 5, 'SP-000005', 'Pagado', 'BAN-REF-0005', '2026-10-15');

COMMIT;

USE dbLogistica;

-- ============================================
-- TRANSPORTE INTERNO
-- ============================================

SELECT * FROM tblEmpresaTransportista;
SELECT * FROM tblTipoServicio;
SELECT * FROM tblTarifaTransporte;
SELECT * FROM tblEstado;
SELECT * FROM tblTipoTransporte;
SELECT * FROM tblTransporte;
SELECT * FROM tblCamaraRefrigeracion;
SELECT * FROM tblConductor;
SELECT * FROM tblInspeccionSanitaria;
SELECT * FROM tblLoteProducto;
SELECT * FROM tblEncabezadoViaje;
SELECT * FROM tblDetalleViaje;
SELECT * FROM tblDetalleViajeLoteProducto;
SELECT * FROM tblTelemetriaTemperatura;
SELECT * FROM tblAlertaCadenaFrio;

-- ============================================
-- INVENTARIOS
-- ============================================

SELECT * FROM tblSucursal;
SELECT * FROM tblBodega;
SELECT * FROM tblCategoria;
SELECT * FROM tblLinea;
SELECT * FROM tblMarca;
SELECT * FROM tblProducto;
SELECT * FROM tblStock;
SELECT * FROM tblTipoMovimiento;
SELECT * FROM tblMovimientoInventario;
SELECT * FROM tblDetalleMovimiento;

-- ============================================
-- TRASLADOS
-- ============================================

SELECT * FROM tblTraslado;
SELECT * FROM tblDetalleTraslado;

-- ============================================
-- AUDITORÍA Y MUESTREO
-- ============================================

SELECT * FROM tblAuditoriaInventario;

-- ============================================
-- CIERRE DE INVENTARIO
-- ============================================

SELECT * FROM tblCierreMovimiento;
SELECT * FROM tblDetalleCierre;

SELECT
    cm.Pk_CierreMovimiento AS 'ID Cierre',
    cm.nombreCierreMovimiento AS 'Nombre Cierre',
    cm.fechaInicioCierreMovimiento AS 'Fecha Inicio',
    cm.fechaFinCierreMovimiento AS 'Fecha Fin',
    cm.estadoCierreMovimiento AS 'Estado Cierre',

    p.Pk_Producto AS 'ID Producto',
    p.nombreProducto AS 'Producto',
    p.skuProducto AS 'Código Producto',

    b.nombreBodega AS 'Bodega',

    s.stockFisicoStock AS 'Stock Físico',
    s.stockVirtualStock AS 'Stock Virtual',

    (s.stockFisicoStock - s.stockVirtualStock) AS 'Diferencia',

    p.precioCompraProducto AS 'Precio Compra',
    p.precioVentaProducto AS 'Precio Venta',

    (s.stockFisicoStock * p.precioCompraProducto)
        AS 'Costo Total Físico',

    (s.stockVirtualStock * p.precioCompraProducto)
        AS 'Costo Total Virtual',

    ((s.stockFisicoStock - s.stockVirtualStock)
        * p.precioCompraProducto) AS 'Diferencia Monetaria',

    (s.stockFisicoStock * p.precioVentaProducto)
        AS 'Valor Total Venta'

FROM tblCierreMovimiento cm

INNER JOIN tblDetalleCierre dc
    ON cm.Pk_CierreMovimiento = dc.Fk_CierreMovimiento_Codigo

INNER JOIN tblStock s
    ON dc.Fk_Stock_Codigo = s.Pk_Stock

INNER JOIN tblProducto p
    ON s.Fk_Producto_Codigo = p.Pk_Producto

INNER JOIN tblBodega b
    ON s.Fk_Bodega_Codigo = b.Pk_Bodega

WHERE cm.Pk_CierreMovimiento = 1

ORDER BY p.nombreProducto;

-- ============================================
-- TRANSPORTE EXTERNO
-- ============================================

SELECT * FROM tblServicioTransporteExterno;
SELECT * FROM tblCostoTransporte;
SELECT * FROM tblVehiculoTransporte;
SELECT * FROM tblConductorTransporte;
SELECT * FROM tblProductoTransporte;
SELECT * FROM tblUbicacionTransporte;
SELECT * FROM tblIncidenciaTransporte;
SELECT * FROM tblHistorialTransporte;
SELECT * FROM tblSolicitudPagoTransporte;

-- Verificacion: deben ser 5 registros en cada tabla.
SELECT (SELECT COUNT(*) FROM tblEmpresaTransportista) AS EmpresaTransportista,
       (SELECT COUNT(*) FROM tblTipoServicio) AS TipoServicio,
       (SELECT COUNT(*) FROM tblTarifaTransporte) AS TarifaTransporte,
       (SELECT COUNT(*) FROM tblEstado) AS Estado,
       (SELECT COUNT(*) FROM tblTipoTransporte) AS TipoTransporte,
       (SELECT COUNT(*) FROM tblTransporte) AS Transporte,
       (SELECT COUNT(*) FROM tblCamaraRefrigeracion) AS CamaraRefrigeracion,
       (SELECT COUNT(*) FROM tblConductor) AS Conductor,
       (SELECT COUNT(*) FROM tblInspeccionSanitaria) AS InspeccionSanitaria,
       (SELECT COUNT(*) FROM tblLoteProducto) AS LoteProducto,
       (SELECT COUNT(*) FROM tblEncabezadoViaje) AS EncabezadoViaje,
       (SELECT COUNT(*) FROM tblDetalleViaje) AS DetalleViaje,
       (SELECT COUNT(*) FROM tblDetalleViajeLoteProducto) AS DetalleViajeLoteProducto,
       (SELECT COUNT(*) FROM tblTelemetriaTemperatura) AS TelemetriaTemperatura,
       (SELECT COUNT(*) FROM tblAlertaCadenaFrio) AS AlertaCadenaFrio,
       (SELECT COUNT(*) FROM tblSucursal) AS Sucursal,
       (SELECT COUNT(*) FROM tblBodega) AS Bodega,
       (SELECT COUNT(*) FROM tblCategoria) AS Categoria,
       (SELECT COUNT(*) FROM tblLinea) AS Linea,
       (SELECT COUNT(*) FROM tblMarca) AS Marca,
       (SELECT COUNT(*) FROM tblProducto) AS Producto,
       (SELECT COUNT(*) FROM tblStock) AS Stock,
       (SELECT COUNT(*) FROM tblTipoMovimiento) AS TipoMovimiento,
       (SELECT COUNT(*) FROM tblMovimientoInventario) AS MovimientoInventario,
       (SELECT COUNT(*) FROM tblDetalleMovimiento) AS DetalleMovimiento,
       (SELECT COUNT(*) FROM tblTraslado) AS Traslado,
       (SELECT COUNT(*) FROM tblDetalleTraslado) AS DetalleTraslado,
       (SELECT COUNT(*) FROM tblAuditoriaInventario) AS AuditoriaInventario,
       (SELECT COUNT(*) FROM tblCierreMovimiento) AS CierreMovimiento,
       (SELECT COUNT(*) FROM tblDetalleCierre) AS DetalleCierre,
       (SELECT COUNT(*) FROM tblServicioTransporteExterno) AS ServicioTransporteExterno,
       (SELECT COUNT(*) FROM tblCostoTransporte) AS CostoTransporte,
       (SELECT COUNT(*) FROM tblVehiculoTransporte) AS VehiculoTransporte,
       (SELECT COUNT(*) FROM tblConductorTransporte) AS ConductorTransporte,
       (SELECT COUNT(*) FROM tblProductoTransporte) AS ProductoTransporte,
       (SELECT COUNT(*) FROM tblUbicacionTransporte) AS UbicacionTransporte,
       (SELECT COUNT(*) FROM tblIncidenciaTransporte) AS IncidenciaTransporte,
       (SELECT COUNT(*) FROM tblHistorialTransporte) AS HistorialTransporte,
       (SELECT COUNT(*) FROM tblSolicitudPagoTransporte) AS SolicitudPagoTransporte;
