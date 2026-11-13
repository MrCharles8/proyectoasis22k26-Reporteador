-- ============================================================================
-- TERMINUS ERP | LOGÍSTICA - CINCO REGISTROS REALISTAS POR TABLA
-- Compatible con: Texto pegado(1).txt (script del 11/11/2026)
-- 44 tablas de Logística | 5 registros finales por tabla = 220 registros.

SET NAMES utf8mb4;
USE dbLogistica;

-- Recuperar IDs del catálogo general existente (sin suponer id=1).
SET @idProveedorLogistica = (SELECT MIN(idProveedor) FROM tblProveedor);
SET @idBancoLogistica = (SELECT MIN(idBanco) FROM tblBanco);
SET @idTipoCuentaLogistica = (SELECT MIN(idTipoCuentaBancaria) FROM tblTipoCuentaBancaria);
SET @idMonedaLogistica = (SELECT MIN(idMoneda) FROM tblMoneda);
SET @idPlazoLogistica = (SELECT MIN(idPlazo) FROM tblPlazo);

-- Confirmación: ninguno de los cinco IDs obligatorios puede ser NULL.
SELECT @idProveedorLogistica AS proveedor_existente,
       @idBancoLogistica AS banco_existente,
       @idTipoCuentaLogistica AS tipo_cuenta_existente,
       @idMonedaLogistica AS moneda_existente,
       @idPlazoLogistica AS plazo_existente;

-- Se buscan hasta cinco cuentas por pagar diferentes; si no existen, las
-- facturas conservan las tres columnas opcionales en NULL (sin FK inválida).
SET @cxp_serie_1 = (SELECT serieDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 0, 1);
SET @cxp_numero_1 = (SELECT numeroDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 0, 1);
SET @cxp_concepto_1 = (SELECT idConceptoProveedor FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 0, 1);
SET @cxp_serie_2 = (SELECT serieDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 1, 1);
SET @cxp_numero_2 = (SELECT numeroDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 1, 1);
SET @cxp_concepto_2 = (SELECT idConceptoProveedor FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 1, 1);
SET @cxp_serie_3 = (SELECT serieDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 2, 1);
SET @cxp_numero_3 = (SELECT numeroDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 2, 1);
SET @cxp_concepto_3 = (SELECT idConceptoProveedor FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 2, 1);
SET @cxp_serie_4 = (SELECT serieDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 3, 1);
SET @cxp_numero_4 = (SELECT numeroDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 3, 1);
SET @cxp_concepto_4 = (SELECT idConceptoProveedor FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 3, 1);
SET @cxp_serie_5 = (SELECT serieDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 4, 1);
SET @cxp_numero_5 = (SELECT numeroDocumentoCuentaPorPagar FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 4, 1);
SET @cxp_concepto_5 = (SELECT idConceptoProveedor FROM tblCuentaPorPagar ORDER BY serieDocumentoCuentaPorPagar, numeroDocumentoCuentaPorPagar, idConceptoProveedor LIMIT 4, 1);

-- ============================================================================
-- TABLA 01/44: tblEmpresaTransportista | 5 registros
-- ============================================================================
INSERT INTO tblEmpresaTransportista (
    idEmpresaTransportista,
    nombreEmpresaTransportista,
    contactoEmpresaTransportista,
    telefonoEmpresaTransportista,
    nitEmpresaTransportista,
    direccionEmpresaTransportista,
    estadoEmpresaTransportista
) VALUES
    -- Registro 1: Transporte Refrigerado del Altiplano, S.A.
    (1, 'Transporte Refrigerado del Altiplano, S.A.', 'María Fernanda Solís', '+502 2234-7812', '7246815-3', 'Calzada Roosevelt 15-42, zona 11, Ciudad de Guatemala', 1),
    -- Registro 2: Logística del Pacífico, S.A.
    (2, 'Logística del Pacífico, S.A.', 'Carlos Alberto Rivera', '+502 2478-3605', '6382504-1', 'Km 32.5, carretera al Pacífico, Amatitlán, Guatemala', 1),
    -- Registro 3: Distribuciones La Ceiba, S.A.
    (3, 'Distribuciones La Ceiba, S.A.', 'Andrea Lucía Méndez', '+502 7765-2098', '5827431-9', '4a avenida 6-18, zona 3, Quetzaltenango', 1),
    -- Registro 4: Carga Fría del Sur, S.A.
    (4, 'Carga Fría del Sur, S.A.', 'José Roberto Aguilar', '+502 7889-1436', '4109637-2', '3a calle 2-60, zona 1, Escuintla', 1),
    -- Registro 5: Transportes Valle Verde, S.A.
    (5, 'Transportes Valle Verde, S.A.', 'Paola Gabriela Morales', '+502 2431-8706', '9671240-5', '10a avenida 17-25, zona 10, Ciudad de Guatemala', 1);

-- ============================================================================
-- TABLA 02/44: tblTipoServicio | 5 registros
-- ============================================================================
INSERT INTO tblTipoServicio (
    idTipoServicio,
    nombreTipoServicio,
    estadoTipoServicio
) VALUES
    -- Registro 1: Transporte refrigerado
    (1, 'Transporte refrigerado', 1),
    -- Registro 2: Distribución urbana
    (2, 'Distribución urbana', 1),
    -- Registro 3: Entrega interdepartamental
    (3, 'Entrega interdepartamental', 1),
    -- Registro 4: Traslado entre centros regionales
    (4, 'Traslado entre centros regionales', 1),
    -- Registro 5: Reposición a centro de distribución
    (5, 'Reposición a centro de distribución', 1);

-- ============================================================================
-- TABLA 03/44: tblTarifaTransporte | 5 registros
-- ============================================================================
INSERT INTO tblTarifaTransporte (
    idTarifaTransporte,
    nombreTarifaTransporte,
    estadoTarifaTransporte
) VALUES
    -- Registro 1: Tarifa por kilómetro recorrido
    (1, 'Tarifa por kilómetro recorrido', 1),
    -- Registro 2: Tarifa por kilogramo transportado
    (2, 'Tarifa por kilogramo transportado', 1),
    -- Registro 3: Tarifa por viaje interdepartamental
    (3, 'Tarifa por viaje interdepartamental', 1),
    -- Registro 4: Tarifa por hora de espera
    (4, 'Tarifa por hora de espera', 1),
    -- Registro 5: Tarifa por entrega realizada
    (5, 'Tarifa por entrega realizada', 1);

-- ============================================================================
-- TABLA 04/44: tblEstado | 5 registros
-- ============================================================================
INSERT INTO tblEstado (
    idEstado,
    tipoEstado
) VALUES
    -- Registro 1: Disponible
    (1, 'Disponible'),
    -- Registro 2: En mantenimiento
    (2, 'En mantenimiento'),
    -- Registro 3: En ruta
    (3, 'En ruta'),
    -- Registro 4: Fuera de servicio
    (4, 'Fuera de servicio'),
    -- Registro 5: Reservado
    (5, 'Reservado');

-- ============================================================================
-- TABLA 05/44: tblTipoTransporte | 5 registros
-- ============================================================================
INSERT INTO tblTipoTransporte (
    idTipoTransporte,
    nombreTipoTransporte
) VALUES
    -- Registro 1: Camión refrigerado
    (1, 'Camión refrigerado'),
    -- Registro 2: Furgón refrigerado
    (2, 'Furgón refrigerado'),
    -- Registro 3: Camión de reparto refrigerado
    (3, 'Camión de reparto refrigerado'),
    -- Registro 4: Panel isotérmico
    (4, 'Panel isotérmico'),
    -- Registro 5: Cabezal con semirremolque refrigerado
    (5, 'Cabezal con semirremolque refrigerado');

-- ============================================================================
-- TABLA 06/44: tblTransporte | 5 registros
-- ============================================================================
INSERT INTO tblTransporte (
    idTransporte,
    nroPlacaTransporte,
    marcaTransporte,
    modeloTransporte,
    anioTransporte,
    esRefrigeradoTransporte,
    Fk_Estado_Codigo,
    Fk_Tipo_Transporte_Codigo
) VALUES
    -- Registro 1: C-428BKV
    (1, 'C-428BKV', 'Hino', '500 Series', 2022, 1, 1, 1),
    -- Registro 2: C-693FTR
    (2, 'C-693FTR', 'Isuzu', 'NQR', 2021, 1, 3, 2),
    -- Registro 3: C-185LPM
    (3, 'C-185LPM', 'Mitsubishi Fuso', 'Canter', 2023, 1, 1, 3),
    -- Registro 4: P-734KDS
    (4, 'P-734KDS', 'Hyundai', 'H100', 2020, 1, 3, 4),
    -- Registro 5: C-952RHG
    (5, 'C-952RHG', 'Freightliner', 'M2 106', 2024, 1, 1, 5);

-- ============================================================================
-- TABLA 07/44: tblCamaraRefrigeracion | 5 registros
-- ============================================================================
INSERT INTO tblCamaraRefrigeracion (
    idCamaraRefrigeracion,
    Fk_Transporte_Codigo,
    marcaEquipoCamaraRefrigeracion,
    tempMinimaCelsiusCamaraRefrigeracion,
    tempMaximaCelsiusCamaraRefrigeracion,
    estadoOperativoCamaraRefrigeracion
) VALUES
    -- Registro 1: Thermo King T-800
    (1, 1, 'Thermo King T-800', 0.0000, 5.0000, 'OPERATIVO'),
    -- Registro 2: Carrier Xarios 350
    (2, 2, 'Carrier Xarios 350', 0.0000, 6.0000, 'OPERATIVO'),
    -- Registro 3: Thermo King V-500
    (3, 3, 'Thermo King V-500', 1.0000, 5.0000, 'OPERATIVO'),
    -- Registro 4: Carrier Neos 100
    (4, 4, 'Carrier Neos 100', 0.0000, 5.0000, 'OPERATIVO'),
    -- Registro 5: Thermo King SLXi 400
    (5, 5, 'Thermo King SLXi 400', -2.0000, 5.0000, 'OPERATIVO');

-- ============================================================================
-- TABLA 08/44: tblConductor | 5 registros
-- ============================================================================
INSERT INTO tblConductor (
    idConductor,
    codigoConductor,
    nombreCompletoConductor,
    numeroLicenciaConductor,
    fechaVencimientoDocConductor,
    Fk_Estado_Codigo
) VALUES
    -- Registro 1: COND-001
    (1, 'COND-001', 'Luis Fernando García', 'LIC-A-471832', '2028-06-18', 1),
    -- Registro 2: COND-002
    (2, 'COND-002', 'José Manuel Pérez', 'LIC-A-628105', '2027-11-03', 3),
    -- Registro 3: COND-003
    (3, 'COND-003', 'Ricardo Antonio López', 'LIC-B-530972', '2029-02-27', 1),
    -- Registro 4: COND-004
    (4, 'COND-004', 'Marco Tulio Hernández', 'LIC-B-741260', '2027-08-14', 3),
    -- Registro 5: COND-005
    (5, 'COND-005', 'Edwin Alexander Castillo', 'LIC-A-893641', '2028-12-09', 1);

-- ============================================================================
-- TABLA 09/44: tblEncabezadoViaje | 5 registros
-- ============================================================================
INSERT INTO tblEncabezadoViaje (
    idEncabezadoViaje,
    fechaDocumentoEncabezadoViaje,
    horaSalidaEncabezadoViaje,
    horaLlegadaEncabezadoViaje,
    requiereCadenaFrioEncabezadoViaje,
    estadoViajeEncabezadoViaje,
    pesoTotalEncabezadoViaje,
    Fk_Transporte_Codigo,
    Fk_Conductor_Codigo
) VALUES
    -- Registro 1: FINALIZADO
    (1, '2026-10-20 05:30:00', '2026-10-20 06:00:00', '2026-10-20 10:45:00', 1, 'FINALIZADO', 850.0000, 1, 1),
    -- Registro 2: FINALIZADO
    (2, '2026-10-21 07:15:00', '2026-10-21 07:45:00', '2026-10-21 13:20:00', 1, 'FINALIZADO', 920.0000, 2, 2),
    -- Registro 3: FINALIZADO
    (3, '2026-10-22 04:45:00', '2026-10-22 05:30:00', '2026-10-22 11:15:00', 1, 'FINALIZADO', 735.0000, 3, 3),
    -- Registro 4: EN_CURSO
    (4, '2026-11-08 08:10:00', '2026-11-08 09:00:00', NULL, 1, 'EN_CURSO', 480.0000, 4, 4),
    -- Registro 5: FINALIZADO
    (5, '2026-10-24 06:10:00', '2026-10-24 06:30:00', '2026-10-24 16:40:00', 1, 'FINALIZADO', 1200.0000, 5, 5);

-- ============================================================================
-- TABLA 10/44: tblDetalleViaje | 5 registros
-- ============================================================================
INSERT INTO tblDetalleViaje (
    idDetalleViaje,
    Fk_Encabezado_Viaje_Codigo,
    ordenDetalleViaje,
    descripcionDetalleViaje,
    cantidadDetalleViaje,
    pesoDetalleViaje
) VALUES
    -- Registro 1: Despacho de salchichas refrigeradas a sucursal de Mixco
    (1, 1, 1, 'Despacho de salchichas refrigeradas a sucursal de Mixco', 1700.0000, 850.0000),
    -- Registro 2: Entrega de chorizo parrillero a sucursal de Villa Nueva
    (2, 2, 1, 'Entrega de chorizo parrillero a sucursal de Villa Nueva', 2044.0000, 920.0000),
    -- Registro 3: Envío de jamón de pierna a sucursal de Quetzaltenango
    (3, 3, 1, 'Envío de jamón de pierna a sucursal de Quetzaltenango', 2100.0000, 735.0000),
    -- Registro 4: Distribución de mortadela familiar hacia Escuintla
    (4, 4, 1, 'Distribución de mortadela familiar hacia Escuintla', 480.0000, 480.0000),
    -- Registro 5: Traslado de tocino ahumado a centro de distribución
    (5, 5, 1, 'Traslado de tocino ahumado a centro de distribución', 4800.0000, 1200.0000);

-- ============================================================================
-- TABLA 11/44: tblTelemetriaTemperatura | 5 registros
-- ============================================================================
INSERT INTO tblTelemetriaTemperatura (
    idTelemetriaTemperatura,
    Fk_Encabezado_Viaje_Codigo,
    fechaHoraTelemetriaTemperatura,
    temperaturaCelsiusTelemetriaTemperatura,
    humedadRelativaTelemetriaTemperatura,
    puertaAbiertaTelemetriaTemperatura,
    ubicacionGpsTelemetriaTemperatura
) VALUES
    -- Registro 1: Ruta Interamericana, Mixco, Guatemala
    (1, 1, '2026-10-20 07:30:00', 3.2000, 0.7250, 0, 'Ruta Interamericana, Mixco, Guatemala'),
    -- Registro 2: Calzada Aguilar Batres, Villa Nueva, Guatemala
    (2, 2, '2026-10-21 10:15:00', 7.1000, 0.6800, 0, 'Calzada Aguilar Batres, Villa Nueva, Guatemala'),
    -- Registro 3: Carretera a Quetzaltenango, Totonicapán
    (3, 3, '2026-10-22 09:40:00', 4.0000, 0.9100, 0, 'Carretera a Quetzaltenango, Totonicapán'),
    -- Registro 4: Carretera al Pacífico, km 87, Escuintla
    (4, 4, '2026-11-11 09:05:00', 3.6000, 0.7350, 1, 'Carretera al Pacífico, km 87, Escuintla'),
    -- Registro 5: Ruta al Pacífico, Santa Lucía Cotzumalguapa
    (5, 5, '2026-10-24 12:30:00', -3.5000, 0.7050, 0, 'Ruta al Pacífico, Santa Lucía Cotzumalguapa');

-- ============================================================================
-- TABLA 12/44: tblAlertaCadenaFrio | 5 registros
-- ============================================================================
INSERT INTO tblAlertaCadenaFrio (
    idAlertaCadenaFrio,
    Fk_Telemetria_Temperatura_Codigo,
    tipoAlertaCadenaFrio,
    atendidaAlertaCadenaFrio,
    observacionCalidadAlertaCadenaFrio
) VALUES
    -- Registro 1: REVISION_PREVENTIVA
    (1, 1, 'REVISION_PREVENTIVA', 1, 'Se verificó el termómetro de la cámara y se confirmó refrigeración estable.'),
    -- Registro 2: TEMPERATURA_ALTA
    (2, 2, 'TEMPERATURA_ALTA', 1, 'Temperatura superior al rango; se ajustó la unidad de frío.'),
    -- Registro 3: HUMEDAD_ALTA
    (3, 3, 'HUMEDAD_ALTA', 1, 'Se revisaron empaques y sellos de la cámara durante la parada técnica.'),
    -- Registro 4: PUERTA_ABIERTA
    (4, 4, 'PUERTA_ABIERTA', 1, 'Se confirmó apertura durante descarga y cierre inmediato de la puerta.'),
    -- Registro 5: TEMPERATURA_BAJA
    (5, 5, 'TEMPERATURA_BAJA', 0, 'Se solicitó verificar el termostato antes de completar la entrega.');

-- ============================================================================
-- TABLA 13/44: tblSucursal | 5 registros
-- ============================================================================
INSERT INTO tblSucursal (
    idSucursal,
    nombreSucursal,
    descripcionSucursal,
    ubicacionSucursal,
    paisSucursal
) VALUES
    -- Registro 1: Sucursal Central Guatemala
    (1, 'Sucursal Central Guatemala', 'Centro de distribución y atención mayorista', 'Avenida Petapa 32-36, zona 12, Ciudad de Guatemala', 'Guatemala'),
    -- Registro 2: Sucursal Mixco
    (2, 'Sucursal Mixco', 'Distribución para comercios del área occidental metropolitana', 'Calzada San Juan 10-80, zona 4, Mixco', 'Guatemala'),
    -- Registro 3: Sucursal Villa Nueva
    (3, 'Sucursal Villa Nueva', 'Almacenamiento y distribución del corredor sur', '5a avenida 4-55, zona 1, Villa Nueva', 'Guatemala'),
    -- Registro 4: Sucursal Quetzaltenango
    (4, 'Sucursal Quetzaltenango', 'Centro regional de distribución de occidente', '7a calle 14-26, zona 3, Quetzaltenango', 'Guatemala'),
    -- Registro 5: Sucursal Escuintla
    (5, 'Sucursal Escuintla', 'Centro regional de distribución de la costa sur', '2a avenida 5-14, zona 1, Escuintla', 'Guatemala');

-- ============================================================================
-- TABLA 14/44: tblBodega | 5 registros
-- ============================================================================
INSERT INTO tblBodega (
    idBodega,
    nombreBodega,
    Fk_Sucursal_Codigo,
    paisBodega
) VALUES
    -- Registro 1: Bodega Central de Refrigerados
    (1, 'Bodega Central de Refrigerados', 1, 'Guatemala'),
    -- Registro 2: Bodega Mixco
    (2, 'Bodega Mixco', 2, 'Guatemala'),
    -- Registro 3: Bodega Villa Nueva
    (3, 'Bodega Villa Nueva', 3, 'Guatemala'),
    -- Registro 4: Bodega Occidente
    (4, 'Bodega Occidente', 4, 'Guatemala'),
    -- Registro 5: Bodega Costa Sur
    (5, 'Bodega Costa Sur', 5, 'Guatemala');

-- ============================================================================
-- TABLA 15/44: tblCategoria | 5 registros
-- ============================================================================
INSERT INTO tblCategoria (
    idCategoria,
    nombreCategoria,
    porcentajeComisionCategoria
) VALUES
    -- Registro 1: Salchichas
    (1, 'Salchichas', 0.1000),
    -- Registro 2: Chorizos
    (2, 'Chorizos', 0.1200),
    -- Registro 3: Jamones
    (3, 'Jamones', 0.1500),
    -- Registro 4: Mortadelas
    (4, 'Mortadelas', 0.0800),
    -- Registro 5: Tocinos
    (5, 'Tocinos', 0.1100);

-- ============================================================================
-- TABLA 16/44: tblLinea | 5 registros
-- ============================================================================
INSERT INTO tblLinea (
    idLinea,
    nombreLinea,
    porcentajeComisionLinea
) VALUES
    -- Registro 1: Tradicional
    (1, 'Tradicional', 0.0500),
    -- Registro 2: Parrillera
    (2, 'Parrillera', 0.0700),
    -- Registro 3: Premium
    (3, 'Premium', 0.0900),
    -- Registro 4: Familiar
    (4, 'Familiar', 0.0600),
    -- Registro 5: Ahumados
    (5, 'Ahumados', 0.0800);

-- ============================================================================
-- TABLA 17/44: tblMarca | 5 registros
-- ============================================================================
INSERT INTO tblMarca (
    idMarca,
    nombreMarca,
    porcentajeComisionMarca
) VALUES
    -- Registro 1: Montesol
    (1, 'Montesol', 0.0600),
    -- Registro 2: Del Prado
    (2, 'Del Prado', 0.0700),
    -- Registro 3: La Hacienda
    (3, 'La Hacienda', 0.0800),
    -- Registro 4: Buen Sabor
    (4, 'Buen Sabor', 0.0500),
    -- Registro 5: Sierra Fresca
    (5, 'Sierra Fresca', 0.0900);

-- ============================================================================
-- TABLA 18/44: tblProducto | 5 registros
-- ============================================================================
INSERT INTO tblProducto (
    idProducto,
    skuProducto,
    clasificacionProducto,
    nombreProducto,
    idProveedorProductos,
    Fk_Marca_Codigo,
    Fk_Categoria_Codigo,
    Fk_Linea_Codigo,
    descripcionProducto,
    imagenProducto,
    paisProducto,
    precioCostoProducto,
    precioVentaProducto,
    porcentajeComisionProducto,
    stockMinimoProducto,
    stockMaximoProducto,
    pesoProducto
) VALUES
    -- Registro 1: SAL-VIE-500
    (1, 'SAL-VIE-500', 'REFRI', 'Salchicha vienesa 500 g', @idProveedorLogistica, 1, 1, 1, 'Paquete refrigerado de salchicha vienesa de 500 gramos', UNHEX('89504E470D0A1A0A0000000D49484452000000010000000108060000001F15C4890000000D49444154789C6378F6ECD97F00091A03B2703A80280000000049454E44AE426082'), 'Guatemala', 18.5000, 26.9000, 0.1000, 25, 350, 0.5000),
    -- Registro 2: CHO-PAR-450
    (2, 'CHO-PAR-450', 'REFRI', 'Chorizo parrillero 450 g', @idProveedorLogistica, 2, 2, 2, 'Chorizo para parrilla empacado al vacío, 450 gramos', UNHEX('89504E470D0A1A0A0000000D49484452000000010000000108060000001F15C4890000000D49444154789C6378F6ECD97F00091A03B2703A80280000000049454E44AE426082'), 'Guatemala', 22.7500, 33.5000, 0.1200, 20, 250, 0.4500),
    -- Registro 3: JAM-PIE-350
    (3, 'JAM-PIE-350', 'REFRI', 'Jamón de pierna 350 g', @idProveedorLogistica, 3, 3, 3, 'Jamón de pierna rebanado, presentación de 350 gramos', UNHEX('89504E470D0A1A0A0000000D49484452000000010000000108060000001F15C4890000000D49444154789C6378F6ECD97F00091A03B2703A80280000000049454E44AE426082'), 'Guatemala', 24.2000, 38.0000, 0.1500, 15, 200, 0.3500),
    -- Registro 4: MOR-FAM-1KG
    (4, 'MOR-FAM-1KG', 'REFRI', 'Mortadela familiar 1 kg', @idProveedorLogistica, 4, 4, 4, 'Mortadela cocida en presentación familiar de un kilogramo', UNHEX('89504E470D0A1A0A0000000D49484452000000010000000108060000001F15C4890000000D49444154789C6378F6ECD97F00091A03B2703A80280000000049454E44AE426082'), 'Guatemala', 36.0000, 49.5000, 0.0800, 30, 400, 1.0000),
    -- Registro 5: TOC-AHU-250
    (5, 'TOC-AHU-250', 'AHUMA', 'Tocino ahumado 250 g', @idProveedorLogistica, 5, 5, 5, 'Tocino ahumado y rebanado en presentación de 250 gramos', UNHEX('89504E470D0A1A0A0000000D49484452000000010000000108060000001F15C4890000000D49444154789C6378F6ECD97F00091A03B2703A80280000000049454E44AE426082'), 'Guatemala', 20.8000, 31.2500, 0.1100, 20, 220, 0.2500);

-- ============================================================================
-- TABLA 19/44: tblLoteProducto | 5 registros
-- ============================================================================
INSERT INTO tblLoteProducto (
    idLoteProducto,
    codigoLoteProducto,
    Fk_Producto_Codigo,
    descripcionLoteProducto,
    requiereFrioLoteProducto,
    fechaFabricacionLoteProducto,
    fechaVencimientoLoteProducto,
    tempRequeridaMinLoteProducto,
    tempRequeridaMaxLoteProducto
) VALUES
    -- Registro 1: L-SAL-261001
    (1, 'L-SAL-261001', 1, 'Producción de salchicha vienesa, turno matutino', 1, '2026-10-01', '2026-12-15', 0.0000, 5.0000),
    -- Registro 2: L-CHO-261004
    (2, 'L-CHO-261004', 2, 'Producción de chorizo parrillero de octubre', 1, '2026-10-04', '2026-12-08', 0.0000, 5.0000),
    -- Registro 3: L-JAM-261006
    (3, 'L-JAM-261006', 3, 'Jamón de pierna rebanado y empacado al vacío', 1, '2026-10-06', '2026-12-20', 0.0000, 5.0000),
    -- Registro 4: L-MOR-261008
    (4, 'L-MOR-261008', 4, 'Mortadela familiar, lote de distribución nacional', 1, '2026-10-08', '2026-12-18', 0.0000, 5.0000),
    -- Registro 5: L-TOC-261010
    (5, 'L-TOC-261010', 5, 'Tocino ahumado, producción de octubre', 1, '2026-10-10', '2027-01-15', -1.0000, 5.0000);

-- ============================================================================
-- TABLA 20/44: tblDetalleViajeLoteProducto | 5 registros
-- ============================================================================
INSERT INTO tblDetalleViajeLoteProducto (
    idDetalleViajeLoteProducto,
    Fk_Detalle_Viaje_Codigo,
    Fk_Lote_Producto_Codigo,
    cantidadCajasDetalleViajeLoteProducto,
    pesoKgDetalleViajeLoteProducto
) VALUES
    -- Registro 1: relación 1 - 1
    (1, 1, 1, 85, 850.0000),
    -- Registro 2: relación 2 - 2
    (2, 2, 2, 92, 920.0000),
    -- Registro 3: relación 3 - 3
    (3, 3, 3, 70, 735.0000),
    -- Registro 4: relación 4 - 4
    (4, 4, 4, 48, 480.0000),
    -- Registro 5: relación 5 - 5
    (5, 5, 5, 120, 1200.0000);

-- ============================================================================
-- TABLA 21/44: tblStock | 5 registros
-- ============================================================================
INSERT INTO tblStock (
    idStock,
    Fk_Sucursal_Codigo,
    Fk_Bodega_Codigo,
    Fk_Producto_Codigo,
    stockFisicoStock,
    stockVirtualStock,
    stockAnteriorStock,
    stockActualStock,
    cargosMesStock,
    abonosMesStock,
    cargosAcumuladosStock,
    abonosAcumuladosStock,
    apartadosStock,
    estadoVentaStock,
    estadoCompraStock
) VALUES
    -- Registro 1: sucursal 1, bodega 1, producto 1
    (1, 1, 1, 1, 135, 135, 120, 135, 35, 20, 400, 265, 12, 1, 1),
    -- Registro 2: sucursal 2, bodega 2, producto 2
    (2, 2, 2, 2, 82, 82, 80, 82, 20, 18, 250, 168, 5, 1, 1),
    -- Registro 3: sucursal 3, bodega 3, producto 3
    (3, 3, 3, 3, 50, 50, 60, 50, 15, 25, 220, 170, 3, 1, 1),
    -- Registro 4: sucursal 4, bodega 4, producto 4
    (4, 4, 4, 4, 160, 160, 150, 160, 50, 40, 580, 420, 20, 1, 0),
    -- Registro 5: sucursal 5, bodega 5, producto 5
    (5, 5, 5, 5, 100, 100, 95, 100, 20, 15, 330, 230, 8, 0, 1);

-- ============================================================================
-- TABLA 22/44: tblSaldos | 5 registros
-- ============================================================================
INSERT INTO tblSaldos (
    idSaldo,
    Fk_Producto_Codigo,
    Fk_Bodega_Codigo,
    saldoActualSaldo
) VALUES
    -- Registro 1: relación 1 - 1
    (1, 1, 1, 135),
    -- Registro 2: relación 2 - 2
    (2, 2, 2, 82),
    -- Registro 3: relación 3 - 3
    (3, 3, 3, 50),
    -- Registro 4: relación 4 - 4
    (4, 4, 4, 160),
    -- Registro 5: relación 5 - 5
    (5, 5, 5, 100);

-- ============================================================================
-- TABLA 23/44: tblTipoMovimiento | 5 registros
-- ============================================================================
INSERT INTO tblTipoMovimiento (
    idTipoMovimiento,
    nombreTipoMovimiento,
    descripcionTipoMovimiento,
    signoTipoMovimiento
) VALUES
    -- Registro 1: Ingreso por compra
    (1, 'Ingreso por compra', 'Incremento de inventario por recepción de mercadería', '+'),
    -- Registro 2: Salida por venta
    (2, 'Salida por venta', 'Reducción de inventario por despacho a cliente', '-'),
    -- Registro 3: Traslado de entrada
    (3, 'Traslado de entrada', 'Ingreso a bodega destino por traslado interno', '+'),
    -- Registro 4: Traslado de salida
    (4, 'Traslado de salida', 'Egreso de bodega origen por traslado interno', '-'),
    -- Registro 5: Ajuste positivo
    (5, 'Ajuste positivo', 'Incremento autorizado después de conciliación', '+');

-- ============================================================================
-- TABLA 24/44: tblTraslado | 5 registros
-- ============================================================================
INSERT INTO tblTraslado (
    idTraslado,
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
    -- Registro 1: TR-2026-0001
    (1, 'TR-2026-0001', 1, 2, 1, '2026-10-25 08:00:00', '2026-10-25 09:00:00', '2026-10-25 11:15:00', 'RECIBIDO', 'Mercadería recibida con temperatura de 3 grados Celsius.'),
    -- Registro 2: TR-2026-0002
    (2, 'TR-2026-0002', 2, 3, 2, '2026-10-26 07:30:00', '2026-10-26 08:20:00', '2026-10-26 10:45:00', 'RECIBIDO', 'Entrega conforme a guía de traslado y conteo de cajas.'),
    -- Registro 3: TR-2026-0003
    (3, 'TR-2026-0003', 3, 4, 3, '2026-10-27 05:50:00', '2026-10-27 06:30:00', '2026-10-27 14:20:00', 'RECIBIDO', 'Despacho interdepartamental sin novedades.'),
    -- Registro 4: TR-2026-0004
    (4, 'TR-2026-0004', 4, 5, 4, '2026-11-08 08:10:00', '2026-11-08 09:00:00', NULL, 'EN_TRANSITO', 'Unidad en carretera con entrega pendiente de confirmar.'),
    -- Registro 5: TR-2026-0005
    (5, 'TR-2026-0005', 5, 1, 5, '2026-11-10 10:00:00', NULL, NULL, 'SOLICITADO', 'Traslado programado para reposición en bodega central.');

-- ============================================================================
-- TABLA 25/44: tblDetalleTraslado | 5 registros
-- ============================================================================
INSERT INTO tblDetalleTraslado (
    idDetalleTraslado,
    Fk_Traslado_Codigo,
    Fk_Producto_Codigo,
    cantidadDetalleTraslado
) VALUES
    -- Registro 1: relación 1 - 1
    (1, 1, 1, 25),
    -- Registro 2: relación 2 - 2
    (2, 2, 2, 18),
    -- Registro 3: relación 3 - 3
    (3, 3, 3, 12),
    -- Registro 4: relación 4 - 4
    (4, 4, 4, 30),
    -- Registro 5: relación 5 - 5
    (5, 5, 5, 15);

-- ============================================================================
-- TABLA 26/44: tblCierreInventario | 5 registros
-- ============================================================================
INSERT INTO tblCierreInventario (
    idCierreInventario,
    nombreCierreInventario,
    Fk_Sucursal_Codigo,
    fechaInicioCierreInventario,
    fechaFinCierreInventario,
    esCierreAnualCierreInventario,
    diferenciaUnidadesCierreInventario,
    diferenciaMontoCierreInventario,
    motivoAceptacionCierreInventario,
    observacionesCierreInventario,
    fechaEjecucionCierreInventario
) VALUES
    -- Registro 1: Cierre octubre 2026 - Central
    (1, 'Cierre octubre 2026 - Central', 1, '2026-10-01', '2026-10-31', 0, 0, 0.0000, 'Conteo y saldos conciliados, sin diferencias.', 'Cierre mensual validado por el responsable de inventario.', '2026-11-01 08:00:00'),
    -- Registro 2: Cierre octubre 2026 - Mixco
    (2, 'Cierre octubre 2026 - Mixco', 2, '2026-10-01', '2026-10-31', 0, 0, 0.0000, 'Conteo y saldos conciliados, sin diferencias.', 'Cierre mensual conforme al kardex de la bodega.', '2026-11-01 08:20:00'),
    -- Registro 3: Cierre octubre 2026 - Villa Nueva
    (3, 'Cierre octubre 2026 - Villa Nueva', 3, '2026-10-01', '2026-10-31', 0, 0, 0.0000, 'Movimientos de entrada y salida verificados.', 'Cierre aprobado sin ajustes pendientes.', '2026-11-01 08:40:00'),
    -- Registro 4: Cierre octubre 2026 - Quetzaltenango
    (4, 'Cierre octubre 2026 - Quetzaltenango', 4, '2026-10-01', '2026-10-31', 0, 0, 0.0000, 'Existencias y reportes coincidentes.', 'Cierre del centro regional de occidente.', '2026-11-01 09:00:00'),
    -- Registro 5: Cierre octubre 2026 - Escuintla
    (5, 'Cierre octubre 2026 - Escuintla', 5, '2026-10-01', '2026-10-31', 0, 0, 0.0000, 'Saldos y conteos confirmados por encargado.', 'Cierre del centro regional de la costa sur.', '2026-11-01 09:20:00');

-- ============================================================================
-- TABLA 27/44: tblMovimientoInventario | 5 registros
-- ============================================================================
INSERT INTO tblMovimientoInventario (
    idMovimientoInventario,
    Fk_Tipo_Movimiento_Codigo,
    Fk_Sucursal_Origen_Codigo,
    Fk_Bodega_Origen_Codigo,
    Fk_Sucursal_Destino_Codigo,
    Fk_Bodega_Destino_Codigo,
    Fk_Transporte_Codigo,
    Fk_Traslado_Codigo,
    fechaMovimientoInventario,
    observacionesMovimientoInventario,
    estadoMovimientoInventario,
    Fk_Cierre_Inventario_Codigo
) VALUES
    -- Registro 1: Salida por traslado de salchichas hacia Mixco.
    (1, 4, 1, 1, 2, 2, 1, 1, '2026-10-25 09:00:00', 'Salida por traslado de salchichas hacia Mixco.', 'CERRADO', 1),
    -- Registro 2: Entrada por traslado recibido de chorizos.
    (2, 3, 2, 2, 3, 3, 2, 2, '2026-10-26 10:45:00', 'Entrada por traslado recibido de chorizos.', 'CERRADO', 2),
    -- Registro 3: Salida por traslado de jamones hacia occidente.
    (3, 4, 3, 3, 4, 4, 3, 3, '2026-10-27 06:30:00', 'Salida por traslado de jamones hacia occidente.', 'CERRADO', 3),
    -- Registro 4: Ingreso de mortadela procedente del área de producción.
    (4, 1, NULL, NULL, 4, 4, NULL, NULL, '2026-10-28 11:30:00', 'Ingreso de mortadela procedente del área de producción.', 'CERRADO', 4),
    -- Registro 5: Despacho de tocino ahumado para venta mayorista.
    (5, 2, 5, 5, NULL, NULL, NULL, NULL, '2026-10-29 15:10:00', 'Despacho de tocino ahumado para venta mayorista.', 'CERRADO', 5);

-- ============================================================================
-- TABLA 28/44: tblDetalleMovimiento | 5 registros
-- ============================================================================
INSERT INTO tblDetalleMovimiento (
    idDetalleMovimiento,
    Fk_Movimiento_Inventario_Codigo,
    Fk_Lote_Producto_Codigo,
    Fk_Producto_Codigo,
    cantidadDetalleMovimiento,
    precioCostoDetalleMovimiento
) VALUES
    -- Registro 1: relación 1 - 1
    (1, 1, 1, 1, 25, 18.5000),
    -- Registro 2: relación 2 - 2
    (2, 2, 2, 2, 18, 22.7500),
    -- Registro 3: relación 3 - 3
    (3, 3, 3, 3, 12, 24.2000),
    -- Registro 4: relación 4 - 4
    (4, 4, 4, 4, 50, 36.0000),
    -- Registro 5: relación 5 - 5
    (5, 5, 5, 5, 15, 20.8000);

-- ============================================================================
-- TABLA 29/44: tblAuditoriaInventario | 5 registros
-- ============================================================================
INSERT INTO tblAuditoriaInventario (
    idAuditoriaInventario,
    Fk_Movimiento_Inventario_Codigo,
    Fk_Bodega_Codigo,
    tipoAuditoriaInventario,
    estadoAuditoriaInventario,
    fechaAuditoriaInventario,
    encargadoBodegaAuditoriaInventario,
    responsableAuditoriaInventario,
    resultadoAuditoriaInventario,
    observacionesCalidadAuditoriaInventario
) VALUES
    -- Registro 1: INDIVIDUAL
    (1, 1, 1, 'INDIVIDUAL', 'FINALIZADA', '2026-11-03 08:30:00', 'Verónica Isabel Cruz', 'Carlos Eduardo Méndez', 'Sin diferencias', 'Conteo físico de salchichas coincide con el saldo registrado.'),
    -- Registro 2: INDIVIDUAL
    (2, 2, 2, 'INDIVIDUAL', 'FINALIZADA', '2026-11-04 09:15:00', 'Óscar David Ramos', 'Gabriela Fernanda López', 'Sin diferencias', 'Existencias de chorizo verificadas y documentadas.'),
    -- Registro 3: INDIVIDUAL
    (3, 3, 3, 'INDIVIDUAL', 'EN_PROCESO', '2026-11-05 10:00:00', 'Ana Lucía Castillo', 'Roberto Emilio Pérez', 'Diferencia pendiente', 'Se identificaron dos unidades faltantes para investigar.'),
    -- Registro 4: INDIVIDUAL
    (4, 4, 4, 'INDIVIDUAL', 'EN_PROCESO', '2026-11-06 11:45:00', 'Mario Estuardo Reyes', 'Daniela Sofía Vásquez', 'Diferencia pendiente', 'Una unidad adicional pendiente de conciliación documental.'),
    -- Registro 5: MULTIPLE
    (5, 5, 5, 'MULTIPLE', 'EN_PROCESO', '2026-11-10 14:00:00', 'Elena Patricia Herrera', 'Jorge Alejandro Castro', 'Conteo en proceso', 'Auditoría múltiple iniciada; quedan productos por agregar.');

-- ============================================================================
-- TABLA 30/44: tblDetalleAuditoria | 5 registros
-- ============================================================================
INSERT INTO tblDetalleAuditoria (
    idDetalleAuditoria,
    Fk_Auditoria_Inventario_Codigo,
    Fk_Stock_Codigo,
    stockTeoricoDetalleAuditoria,
    stockFisicoDetalleAuditoria,
    diferenciaDetalleAuditoria,
    observacionesDetalleAuditoria
) VALUES
    -- Registro 1: Concordancia completa con el saldo teórico.
    (1, 1, 1, 135, 135, 0, 'Concordancia completa con el saldo teórico.'),
    -- Registro 2: Cantidad física confirmada con la ubicación de bodega.
    (2, 2, 2, 82, 82, 0, 'Cantidad física confirmada con la ubicación de bodega.'),
    -- Registro 3: Dos unidades no localizadas; investigar despachos.
    (3, 3, 3, 50, 48, -2, 'Dos unidades no localizadas; investigar despachos.'),
    -- Registro 4: Una unidad adicional; revisar ingreso pendiente.
    (4, 4, 4, 160, 161, 1, 'Una unidad adicional; revisar ingreso pendiente.'),
    -- Registro 5: Primer artículo validado de la auditoría múltiple.
    (5, 5, 5, 100, 100, 0, 'Primer artículo validado de la auditoría múltiple.');

-- ============================================================================
-- TABLA 31/44: tblDetalleCierre | 5 registros
-- ============================================================================
INSERT INTO tblDetalleCierre (
    idDetalleCierre,
    Fk_Cierre_Inventario_Codigo,
    Fk_Stock_Codigo,
    stockAnteriorDetalleCierre,
    stockActualDetalleCierre,
    cargosMesDetalleCierre,
    abonosMesDetalleCierre,
    cargosAcumuladosDetalleCierre,
    abonosAcumuladosDetalleCierre
) VALUES
    -- Registro 1: cierre 1, stock 1
    (1, 1, 1, 120, 135, 35, 20, 400, 265),
    -- Registro 2: cierre 2, stock 2
    (2, 2, 2, 80, 82, 20, 18, 250, 168),
    -- Registro 3: cierre 3, stock 3
    (3, 3, 3, 60, 50, 15, 25, 220, 170),
    -- Registro 4: cierre 4, stock 4
    (4, 4, 4, 150, 160, 50, 40, 580, 420),
    -- Registro 5: cierre 5, stock 5
    (5, 5, 5, 95, 100, 20, 15, 330, 230);

-- ============================================================================
-- TABLA 32/44: tblHistoricoInventario | 5 registros
-- ============================================================================
INSERT INTO tblHistoricoInventario (
    idHistoricoInventario,
    Fk_Cierre_Inventario_Codigo,
    Fk_Stock_Codigo,
    Fk_Sucursal_Codigo,
    Fk_Bodega_Codigo,
    Fk_Producto_Codigo,
    stockFisicoStock,
    stockVirtualStock,
    stockAnteriorStock,
    stockActualStock,
    cargosMesStock,
    abonosMesStock,
    cargosAcumuladosStock,
    abonosAcumuladosStock,
    apartadosStock,
    estadoVentaStock,
    estadoCompraStock,
    fechaCorteHistoricoInventario
) VALUES
    -- Registro 1: cierre 1, stock 1
    (1, 1, 1, 1, 1, 1, 135, 135, 120, 135, 35, 20, 400, 265, 12, 1, 1, '2026-10-31'),
    -- Registro 2: cierre 2, stock 2
    (2, 2, 2, 2, 2, 2, 82, 82, 80, 82, 20, 18, 250, 168, 5, 1, 1, '2026-10-31'),
    -- Registro 3: cierre 3, stock 3
    (3, 3, 3, 3, 3, 3, 50, 50, 60, 50, 15, 25, 220, 170, 3, 1, 1, '2026-10-31'),
    -- Registro 4: cierre 4, stock 4
    (4, 4, 4, 4, 4, 4, 160, 160, 150, 160, 50, 40, 580, 420, 20, 1, 0, '2026-10-31'),
    -- Registro 5: cierre 5, stock 5
    (5, 5, 5, 5, 5, 5, 100, 100, 95, 100, 20, 15, 330, 230, 8, 0, 1, '2026-10-31');

-- ============================================================================
-- TABLA 33/44: tblServicioTransporteExterno | 5 registros
-- ============================================================================
INSERT INTO tblServicioTransporteExterno (
    idServicioTransporteExterno,
    Fk_Empresa_Transportista_Codigo,
    Fk_Tipo_Servicio_Codigo,
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
    -- Registro 1: GUIA-EXT-2601
    (1, 1, 1, 1, 'GUIA-EXT-2601', 'Entregado', 'Ciudad de Guatemala', 'Avenida Petapa 32-36, zona 12', 'Mixco', 'Calzada San Juan 10-80, zona 4', '2026-10-23', '2026-10-25', '2026-10-25'),
    -- Registro 2: GUIA-EXT-2602
    (2, 2, 2, 2, 'GUIA-EXT-2602', 'Entregado', 'Mixco', 'Calzada San Juan 10-80, zona 4', 'Villa Nueva', '5a avenida 4-55, zona 1', '2026-10-24', '2026-10-26', '2026-10-26'),
    -- Registro 3: GUIA-EXT-2603
    (3, 3, 3, 3, 'GUIA-EXT-2603', 'Entregado', 'Villa Nueva', '5a avenida 4-55, zona 1', 'Quetzaltenango', '7a calle 14-26, zona 3', '2026-10-25', '2026-10-27', '2026-10-27'),
    -- Registro 4: GUIA-EXT-2604
    (4, 4, 4, 4, 'GUIA-EXT-2604', 'En tránsito', 'Quetzaltenango', '7a calle 14-26, zona 3', 'Escuintla', '2a avenida 5-14, zona 1', '2026-11-07', '2026-11-11', NULL),
    -- Registro 5: GUIA-EXT-2605
    (5, 5, 5, 5, 'GUIA-EXT-2605', 'Programado', 'Escuintla', '2a avenida 5-14, zona 1', 'Ciudad de Guatemala', 'Avenida Petapa 32-36, zona 12', '2026-11-10', '2026-11-13', NULL);

-- ============================================================================
-- TABLA 34/44: tblCostoTransporte | 5 registros
-- ============================================================================
INSERT INTO tblCostoTransporte (
    idCostoTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    Fk_Tarifa_Transporte_Codigo,
    cantidadCostoTransporte,
    costoUnitarioCostoTransporte,
    costoTotalCostoTransporte,
    monedaCostoTransporte,
    tipoPagoCostoTransporte
) VALUES
    -- Registro 1: GTQ
    (1, 1, 1, 120.0000, 8.7500, 1050.0000, 'GTQ', 'Transferencia'),
    -- Registro 2: GTQ
    (2, 2, 2, 850.0000, 1.2500, 1062.5000, 'GTQ', 'Transferencia'),
    -- Registro 3: GTQ
    (3, 3, 3, 1.0000, 1250.0000, 1250.0000, 'GTQ', 'Transferencia'),
    -- Registro 4: GTQ
    (4, 4, 4, 3.0000, 150.0000, 450.0000, 'GTQ', 'Efectivo'),
    -- Registro 5: GTQ
    (5, 5, 5, 12.0000, 45.0000, 540.0000, 'GTQ', 'Transferencia');

-- ============================================================================
-- TABLA 35/44: tblVehiculoTransporte | 5 registros
-- ============================================================================
INSERT INTO tblVehiculoTransporte (
    idVehiculoTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    placaVehiculoTransporte,
    tipoVehiculoTransporte,
    capacidadVehiculoTransporte
) VALUES
    -- Registro 1: C-728GTF
    (1, 1, 'C-728GTF', 'Camión refrigerado', '5 toneladas'),
    -- Registro 2: C-431NVP
    (2, 2, 'C-431NVP', 'Furgón de reparto', '3 toneladas'),
    -- Registro 3: C-864SLM
    (3, 3, 'C-864SLM', 'Camión de carga', '8 toneladas'),
    -- Registro 4: P-502DRQ
    (4, 4, 'P-502DRQ', 'Panel isotérmico', '1.5 toneladas'),
    -- Registro 5: C-319JKA
    (5, 5, 'C-319JKA', 'Camión refrigerado', '6 toneladas');

-- ============================================================================
-- TABLA 36/44: tblConductorTransporte | 5 registros
-- ============================================================================
INSERT INTO tblConductorTransporte (
    idConductorTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    nombreConductorTransporte,
    telefonoConductorTransporte
) VALUES
    -- Registro 1: Héctor Orlando Gómez
    (1, 1, 'Héctor Orlando Gómez', '+502 5432-7810'),
    -- Registro 2: Rafael Enrique Juárez
    (2, 2, 'Rafael Enrique Juárez', '+502 5278-0631'),
    -- Registro 3: Saúl Ernesto Ramírez
    (3, 3, 'Saúl Ernesto Ramírez', '+502 5590-1427'),
    -- Registro 4: Juan Pablo Escobar
    (4, 4, 'Juan Pablo Escobar', '+502 5781-2369'),
    -- Registro 5: Miguel Ángel Méndez
    (5, 5, 'Miguel Ángel Méndez', '+502 5356-8042');

-- ============================================================================
-- TABLA 37/44: tblProductoTransporte | 5 registros
-- ============================================================================
INSERT INTO tblProductoTransporte (
    idProductoTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    Fk_Producto_Codigo,
    cantidadProductoTransporte,
    unidadMedidaProductoTransporte
) VALUES
    -- Registro 1: paquetes
    (1, 1, 1, 25.0000, 'paquetes'),
    -- Registro 2: paquetes
    (2, 2, 2, 18.0000, 'paquetes'),
    -- Registro 3: paquetes
    (3, 3, 3, 12.0000, 'paquetes'),
    -- Registro 4: kilogramos
    (4, 4, 4, 30.0000, 'kilogramos'),
    -- Registro 5: paquetes
    (5, 5, 5, 15.0000, 'paquetes');

-- ============================================================================
-- TABLA 38/44: tblUbicacionTransporte | 5 registros
-- ============================================================================
INSERT INTO tblUbicacionTransporte (
    idUbicacionTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    ubicacionActualUbicacionTransporte,
    fechaActualizacionUbicacionTransporte
) VALUES
    -- Registro 1: Centro de distribución de Mixco, Guatemala
    (1, 1, 'Centro de distribución de Mixco, Guatemala', '2026-10-25 11:15:00'),
    -- Registro 2: Bodega principal de Villa Nueva, Guatemala
    (2, 2, 'Bodega principal de Villa Nueva, Guatemala', '2026-10-26 10:45:00'),
    -- Registro 3: Centro regional de Quetzaltenango, Guatemala
    (3, 3, 'Centro regional de Quetzaltenango, Guatemala', '2026-10-27 14:20:00'),
    -- Registro 4: Ruta al Pacífico, km 87, Escuintla
    (4, 4, 'Ruta al Pacífico, km 87, Escuintla', '2026-11-11 10:15:00'),
    -- Registro 5: Patio de transportistas, Escuintla
    (5, 5, 'Patio de transportistas, Escuintla', '2026-11-10 16:00:00');

-- ============================================================================
-- TABLA 39/44: tblIncidenciaTransporte | 5 registros
-- ============================================================================
INSERT INTO tblIncidenciaTransporte (
    idIncidenciaTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    codigoIncidenciaTransporte,
    fechaIncidenciaTransporte,
    tipoIncidenciaTransporte,
    descripcionIncidenciaTransporte,
    responsableIncidenciaTransporte,
    estadoIncidenciaTransporte
) VALUES
    -- Registro 1: INC-2601
    (1, 1, 'INC-2601', '2026-10-25 09:20:00', 'Demora por tráfico', 'Se registraron 25 minutos de atraso en Calzada Roosevelt.', 'María Fernanda Solís', 'Resuelta'),
    -- Registro 2: INC-2602
    (2, 2, 'INC-2602', '2026-10-26 09:00:00', 'Revisión documental', 'Se verificó la guía de remisión antes de ingresar al destino.', 'Carlos Alberto Rivera', 'Resuelta'),
    -- Registro 3: INC-2603
    (3, 3, 'INC-2603', '2026-10-27 11:05:00', 'Variación de temperatura', 'La unidad registró 6 grados y se ajustó el sistema de refrigeración.', 'Andrea Lucía Méndez', 'Resuelta'),
    -- Registro 4: INC-2604
    (4, 4, 'INC-2604', '2026-11-11 08:45:00', 'Tránsito lento', 'Congestión vehicular en carretera; entrega todavía pendiente.', 'José Roberto Aguilar', 'En seguimiento'),
    -- Registro 5: INC-2605
    (5, 5, 'INC-2605', '2026-11-10 14:35:00', 'Reprogramación de carga', 'El área de despacho solicitó mover el horario de recolección.', 'Paola Gabriela Morales', 'Pendiente');

-- ============================================================================
-- TABLA 40/44: tblHistorialTransporte | 5 registros
-- ============================================================================
INSERT INTO tblHistorialTransporte (
    idHistorialTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    fechaMovimientoHistorialTransporte,
    tipoMovimientoHistorialTransporte,
    descripcionMovimientoHistorialTransporte,
    estadoTransporteHistorialTransporte
) VALUES
    -- Registro 1: Confirmación de entrega
    (1, 1, '2026-10-25 11:15:00', 'Confirmación de entrega', 'Entrega recibida y documentación firmada en Mixco.', 'Entregado'),
    -- Registro 2: Confirmación de entrega
    (2, 2, '2026-10-26 10:45:00', 'Confirmación de entrega', 'Recepción completa en Villa Nueva.', 'Entregado'),
    -- Registro 3: Confirmación de entrega
    (3, 3, '2026-10-27 14:20:00', 'Confirmación de entrega', 'Mercadería refrigerada recibida en Quetzaltenango.', 'Entregado'),
    -- Registro 4: Actualización de ruta
    (4, 4, '2026-11-11 10:15:00', 'Actualización de ruta', 'Vehículo reporta avance por carretera al Pacífico.', 'En tránsito'),
    -- Registro 5: Programación de despacho
    (5, 5, '2026-11-10 16:00:00', 'Programación de despacho', 'Se programó unidad para recolección y entrega.', 'Programado');

-- ============================================================================
-- TABLA 41/44: tblEstadoSolicitudPago | 5 registros
-- ============================================================================
INSERT IGNORE INTO tblEstadoSolicitudPago (
    idEstadoSolicitudPago,
    codigoEstadoSolicitudPago,
    nombreEstadoSolicitudPago,
    descripcionEstadoSolicitudPago
) VALUES
    -- Registro 1: SOLICITADO
    (1, 'SOLICITADO', 'Solicitado', 'Solicitud de pago registrada y pendiente de revisión.'),
    -- Registro 2: EN_REVISION
    (2, 'EN_REVISION', 'En revisión', 'Documentación de soporte en revisión.'),
    -- Registro 3: APROBADO
    (3, 'APROBADO', 'Aprobado', 'Solicitud autorizada para realizar el pago.'),
    -- Registro 4: PAGADO
    (4, 'PAGADO', 'Pagado', 'Pago realizado y confirmado.'),
    -- Registro 5: RECHAZADO
    (5, 'RECHAZADO', 'Rechazado', 'Solicitud devuelta por inconsistencia documental.');

-- ============================================================================
-- TABLA 42/44: tblSolicitudPagoTransporte | 5 registros
-- ============================================================================
INSERT INTO tblSolicitudPagoTransporte (
    idSolicitudPagoTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    codigoSolicitudPagoTransporte,
    Fk_Estado_Solicitud_Pago_Codigo,
    referenciaBancariaSolicitudPagoTransporte,
    fechaPagoSolicitudPagoTransporte
) VALUES
    -- Registro 1: SOL-PAG-2601
    (1, 1, 'SOL-PAG-2601', 4, 'TRF-20261028-001', '2026-10-28'),
    -- Registro 2: SOL-PAG-2602
    (2, 2, 'SOL-PAG-2602', 3, NULL, NULL),
    -- Registro 3: SOL-PAG-2603
    (3, 3, 'SOL-PAG-2603', 2, NULL, NULL),
    -- Registro 4: SOL-PAG-2604
    (4, 4, 'SOL-PAG-2604', 1, NULL, NULL),
    -- Registro 5: SOL-PAG-2605
    (5, 5, 'SOL-PAG-2605', 5, NULL, NULL);

-- ============================================================================
-- TABLA 43/44: tblFacturaTransporte | 5 registros
-- ============================================================================
INSERT INTO tblFacturaTransporte (
    idFacturaTransporte,
    Fk_Servicio_Transporte_Externo_Codigo,
    Fk_Plazo_Codigo,
    Fk_SerieDocumentoCuentaPorPagar,
    Fk_NumeroDocumentoCuentaPorPagar,
    Fk_IdConceptoProveedor,
    serieFacturaTransporte,
    numeroFacturaTransporte,
    fechaEmisionFacturaTransporte,
    montoFacturaTransporte,
    activaFacturaTransporte
) VALUES
    -- Registro 1: A-2026
    (1, 1, @idPlazoLogistica, @cxp_serie_1, @cxp_numero_1, @cxp_concepto_1, 'A-2026', '000184', '2026-10-25', 1050.0000, 1),
    -- Registro 2: A-2026
    (2, 2, @idPlazoLogistica, @cxp_serie_2, @cxp_numero_2, @cxp_concepto_2, 'A-2026', '000192', '2026-10-26', 1062.5000, 1),
    -- Registro 3: FEL-26
    (3, 3, @idPlazoLogistica, @cxp_serie_3, @cxp_numero_3, @cxp_concepto_3, 'FEL-26', '000847', '2026-10-27', 1250.0000, 1),
    -- Registro 4: FEL-26
    (4, 4, @idPlazoLogistica, @cxp_serie_4, @cxp_numero_4, @cxp_concepto_4, 'FEL-26', '000861', '2026-11-08', 450.0000, 1),
    -- Registro 5: B-2026
    (5, 5, @idPlazoLogistica, @cxp_serie_5, @cxp_numero_5, @cxp_concepto_5, 'B-2026', '000319', '2026-11-10', 540.0000, 1);

-- ============================================================================
-- TABLA 44/44: tblCuentaBancariaTransportista | 5 registros
-- ============================================================================
INSERT INTO tblCuentaBancariaTransportista (
    idCuentaBancariaTransportista,
    Fk_Empresa_Transportista_Codigo,
    Fk_Banco_Codigo,
    Fk_TipoCuentaBancaria_Codigo,
    Fk_Moneda_Codigo,
    numeroCuentaBancariaTransportista,
    titularCuentaBancariaTransportista,
    activaCuentaBancariaTransportista,
    predeterminadaCuentaBancariaTransportista
) VALUES
    -- Registro 1: 0102-0045-00876321
    (1, 1, @idBancoLogistica, @idTipoCuentaLogistica, @idMonedaLogistica, '0102-0045-00876321', 'Transporte Refrigerado del Altiplano, S.A.', 1, 1),
    -- Registro 2: 0102-0045-00876322
    (2, 2, @idBancoLogistica, @idTipoCuentaLogistica, @idMonedaLogistica, '0102-0045-00876322', 'Logística del Pacífico, S.A.', 1, 1),
    -- Registro 3: 0102-0045-00876323
    (3, 3, @idBancoLogistica, @idTipoCuentaLogistica, @idMonedaLogistica, '0102-0045-00876323', 'Distribuciones La Ceiba, S.A.', 1, 1),
    -- Registro 4: 0102-0045-00876324
    (4, 4, @idBancoLogistica, @idTipoCuentaLogistica, @idMonedaLogistica, '0102-0045-00876324', 'Carga Fría del Sur, S.A.', 1, 1),
    -- Registro 5: 0102-0045-00876325
    (5, 5, @idBancoLogistica, @idTipoCuentaLogistica, @idMonedaLogistica, '0102-0045-00876325', 'Transportes Valle Verde, S.A.', 1, 1);

-- COMPROBACIÓN: cuenta los registros cargados en cada tabla de Logística.
SELECT 'tblEmpresaTransportista' AS tabla, COUNT(*) AS cantidad FROM tblEmpresaTransportista
UNION ALL
SELECT 'tblTipoServicio' AS tabla, COUNT(*) AS cantidad FROM tblTipoServicio
UNION ALL
SELECT 'tblTarifaTransporte' AS tabla, COUNT(*) AS cantidad FROM tblTarifaTransporte
UNION ALL
SELECT 'tblEstado' AS tabla, COUNT(*) AS cantidad FROM tblEstado
UNION ALL
SELECT 'tblTipoTransporte' AS tabla, COUNT(*) AS cantidad FROM tblTipoTransporte
UNION ALL
SELECT 'tblTransporte' AS tabla, COUNT(*) AS cantidad FROM tblTransporte
UNION ALL
SELECT 'tblCamaraRefrigeracion' AS tabla, COUNT(*) AS cantidad FROM tblCamaraRefrigeracion
UNION ALL
SELECT 'tblConductor' AS tabla, COUNT(*) AS cantidad FROM tblConductor
UNION ALL
SELECT 'tblEncabezadoViaje' AS tabla, COUNT(*) AS cantidad FROM tblEncabezadoViaje
UNION ALL
SELECT 'tblDetalleViaje' AS tabla, COUNT(*) AS cantidad FROM tblDetalleViaje
UNION ALL
SELECT 'tblTelemetriaTemperatura' AS tabla, COUNT(*) AS cantidad FROM tblTelemetriaTemperatura
UNION ALL
SELECT 'tblAlertaCadenaFrio' AS tabla, COUNT(*) AS cantidad FROM tblAlertaCadenaFrio
UNION ALL
SELECT 'tblSucursal' AS tabla, COUNT(*) AS cantidad FROM tblSucursal
UNION ALL
SELECT 'tblBodega' AS tabla, COUNT(*) AS cantidad FROM tblBodega
UNION ALL
SELECT 'tblCategoria' AS tabla, COUNT(*) AS cantidad FROM tblCategoria
UNION ALL
SELECT 'tblLinea' AS tabla, COUNT(*) AS cantidad FROM tblLinea
UNION ALL
SELECT 'tblMarca' AS tabla, COUNT(*) AS cantidad FROM tblMarca
UNION ALL
SELECT 'tblProducto' AS tabla, COUNT(*) AS cantidad FROM tblProducto
UNION ALL
SELECT 'tblLoteProducto' AS tabla, COUNT(*) AS cantidad FROM tblLoteProducto
UNION ALL
SELECT 'tblDetalleViajeLoteProducto' AS tabla, COUNT(*) AS cantidad FROM tblDetalleViajeLoteProducto
UNION ALL
SELECT 'tblStock' AS tabla, COUNT(*) AS cantidad FROM tblStock
UNION ALL
SELECT 'tblSaldos' AS tabla, COUNT(*) AS cantidad FROM tblSaldos
UNION ALL
SELECT 'tblTipoMovimiento' AS tabla, COUNT(*) AS cantidad FROM tblTipoMovimiento
UNION ALL
SELECT 'tblTraslado' AS tabla, COUNT(*) AS cantidad FROM tblTraslado
UNION ALL
SELECT 'tblDetalleTraslado' AS tabla, COUNT(*) AS cantidad FROM tblDetalleTraslado
UNION ALL
SELECT 'tblCierreInventario' AS tabla, COUNT(*) AS cantidad FROM tblCierreInventario
UNION ALL
SELECT 'tblMovimientoInventario' AS tabla, COUNT(*) AS cantidad FROM tblMovimientoInventario
UNION ALL
SELECT 'tblDetalleMovimiento' AS tabla, COUNT(*) AS cantidad FROM tblDetalleMovimiento
UNION ALL
SELECT 'tblAuditoriaInventario' AS tabla, COUNT(*) AS cantidad FROM tblAuditoriaInventario
UNION ALL
SELECT 'tblDetalleAuditoria' AS tabla, COUNT(*) AS cantidad FROM tblDetalleAuditoria
UNION ALL
SELECT 'tblDetalleCierre' AS tabla, COUNT(*) AS cantidad FROM tblDetalleCierre
UNION ALL
SELECT 'tblHistoricoInventario' AS tabla, COUNT(*) AS cantidad FROM tblHistoricoInventario
UNION ALL
SELECT 'tblServicioTransporteExterno' AS tabla, COUNT(*) AS cantidad FROM tblServicioTransporteExterno
UNION ALL
SELECT 'tblCostoTransporte' AS tabla, COUNT(*) AS cantidad FROM tblCostoTransporte
UNION ALL
SELECT 'tblVehiculoTransporte' AS tabla, COUNT(*) AS cantidad FROM tblVehiculoTransporte
UNION ALL
SELECT 'tblConductorTransporte' AS tabla, COUNT(*) AS cantidad FROM tblConductorTransporte
UNION ALL
SELECT 'tblProductoTransporte' AS tabla, COUNT(*) AS cantidad FROM tblProductoTransporte
UNION ALL
SELECT 'tblUbicacionTransporte' AS tabla, COUNT(*) AS cantidad FROM tblUbicacionTransporte
UNION ALL
SELECT 'tblIncidenciaTransporte' AS tabla, COUNT(*) AS cantidad FROM tblIncidenciaTransporte
UNION ALL
SELECT 'tblHistorialTransporte' AS tabla, COUNT(*) AS cantidad FROM tblHistorialTransporte
UNION ALL
SELECT 'tblEstadoSolicitudPago' AS tabla, COUNT(*) AS cantidad FROM tblEstadoSolicitudPago
UNION ALL
SELECT 'tblSolicitudPagoTransporte' AS tabla, COUNT(*) AS cantidad FROM tblSolicitudPagoTransporte
UNION ALL
SELECT 'tblFacturaTransporte' AS tabla, COUNT(*) AS cantidad FROM tblFacturaTransporte
UNION ALL
SELECT 'tblCuentaBancariaTransportista' AS tabla, COUNT(*) AS cantidad FROM tblCuentaBancariaTransportista;

-- RESUMEN ESPERADO:
-- 44 tablas de Logística con 5 registros cada una (total 220).
-- NOTA: en la tabla tblEstadoSolicitudPago el id=1 proviene del script original;
-- INSERT IGNORE permite conservarlo y completar con los otros cuatro estados.
