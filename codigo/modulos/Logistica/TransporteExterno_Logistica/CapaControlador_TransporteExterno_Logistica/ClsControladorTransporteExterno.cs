// ------------------------------------------------------
// Autor: Gabriela Pinto García
// Carné: 9959-23-1087
// Fecha: 21/10/2026
// Módulo: Logística - Transporte Externo
// ------------------------------------------------------
using System;
using System.Data;
using CapaModelo_TransporteExterno_Logistica.Repositorio;

namespace CapaControlador_TransporteExterno_Logistica
{
    public class ClsControladorTransporteExterno
    {
        private readonly ClsRepositorioTransporteExterno _Repositorio;

        public ClsControladorTransporteExterno()
        {
            _Repositorio = new ClsRepositorioTransporteExterno();
        }

        // Obtener todos los transportes.
        public DataTable LogisticaFuncObtenerTransportes()
        {
            return _Repositorio.LogisticaFuncObtenerTransportes();
        }

        // Obtener catálogo de empresas transportistas.
        public DataTable LogisticaFuncObtenerEmpresas()
        {
            return _Repositorio.LogisticaFuncObtenerEmpresas();
        }

        // Obtener catálogo de tipos de servicio.
        public DataTable LogisticaFuncObtenerTiposServicio()
        {
            return _Repositorio.LogisticaFuncObtenerTiposServicio();
        }

        // Obtener transportes registrados con sus datos relacionados.
        public DataTable LogisticaFuncObtenerRegistroTransportes()
        {
            return _Repositorio.LogisticaFuncObtenerRegistroTransportes();
        }

        // Obtener los próximos correlativos para mostrar
        // la vista previa de la guía y solicitud de pago.
        public DataTable LogisticaFuncObtenerProximosCodigos()
        {
            return _Repositorio.LogisticaFuncObtenerProximosCodigos();
        }

        // Registrar transporte, vehículo, conductor
        // y solicitud de pago.
        public DataTable LogisticaFuncAgregarTransporte(
            int empresa,
            int tipo,
            string estado,
            DateTime contratacion,
            DateTime estimada,
            DateTime? real,
            string placa,
            string tipoVehiculo,
            string capacidad,
            string conductor,
            string telefono)
        {
            return _Repositorio.LogisticaFuncAgregarTransporte(
                empresa,
                tipo,
                estado,
                contratacion,
                estimada,
                real,
                placa,
                tipoVehiculo,
                capacidad,
                conductor,
                telefono);
        }

        // Modificar un transporte existente.
        // Conserva su número de guía y solicitud de pago.
        public void LogisticaMetModificarTransporte(
            int id,
            int empresa,
            int tipo,
            string estado,
            DateTime contratacion,
            DateTime estimada,
            DateTime? real,
            string placa,
            string tipoVehiculo,
            string capacidad,
            string conductor,
            string telefono)
        {
            _Repositorio.LogisticaMetModificarTransporte(
                id,
                empresa,
                tipo,
                estado,
                contratacion,
                estimada,
                real,
                placa,
                tipoVehiculo,
                capacidad,
                conductor,
                telefono);
        }

        // Eliminar un transporte permitido.
        // El repositorio verifica el estado del transporte,
        // la solicitud de pago y sus registros relacionados.
        public void LogisticaMetEliminarTransporte(int id)
        {
            _Repositorio.LogisticaMetEliminarTransporte(id);
        }
    }
}
