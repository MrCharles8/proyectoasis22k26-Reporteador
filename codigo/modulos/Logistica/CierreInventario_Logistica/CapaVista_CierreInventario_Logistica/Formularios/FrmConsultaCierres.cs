/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA
 * FORMULARIO: FrmConsultaCierre
 *
 * DESCRIPCIÓN:
 * Formulario que aborda la interfafz del cierre de inventario
 *
 * RESPONSABLE: Nills Berducido Gómez
 * CARNÉ: 0901 23 14275
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_CierreInventario_Logistica;

namespace CapaVista_CierreInventario_Logistica.Formularios
{
    public partial class FrmConsultaCierres : Form
    {
        private readonly ClsControladorCierreInventario controlador = new ClsControladorCierreInventario();
        public FrmConsultaCierres()
        {
            InitializeComponent();
            Load += FrmConsultaCierres_Load;
            LogisticaBtnBuscar.Click += LogisticaBtnBuscar_Click;
        }
        private void FrmConsultaCierres_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable sucursales = controlador.ObtenerSucursales();
                DataRow todas = sucursales.NewRow();
                todas["idSucursal"] = 0;
                todas["nombreSucursal"] = "Todas las sucursales";
                sucursales.Rows.InsertAt(todas, 0);
                LogisticaCboSucursal.DisplayMember = "nombreSucursal";
                LogisticaCboSucursal.ValueMember = "idSucursal";
                LogisticaCboSucursal.DataSource = sucursales;
                LogisticaCboSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
                LogisticaDtpFechaInicialCierre.Value = new DateTime(DateTime.Today.Year, 1, 1);
                LogisticaDtpFechaFinalCierre.Value = DateTime.Today;
                LogisticaTxtNombreCierre.Text = "";
                LogisticaDvgCierre.ReadOnly = true;
                LogisticaDvgCierre.AllowUserToAddRows = false;
                LogisticaDvgCierre.AllowUserToDeleteRows = false;
                LogisticaDvgCierre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                LogisticaDvgCierre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Buscar();
            }
            catch (Exception ex) { MostrarError(ex); }
        }
        private void LogisticaBtnBuscar_Click(object sender, EventArgs e) { Buscar(); }
        private void Buscar()
        {
            try
            {
                int id = Convert.ToInt32(LogisticaCboSucursal.SelectedValue);
                int? sucursal = id == 0 ? (int?)null : id;
                LogisticaDvgCierre.DataSource = controlador.ConsultarCierres(sucursal,
                    LogisticaDtpFechaInicialCierre.Value.Date,
                    LogisticaDtpFechaFinalCierre.Value.Date,
                    LogisticaTxtNombreCierre.Text);
            }
            catch (Exception ex) { MostrarError(ex); }
        }
        private void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Consulta de cierres", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

