﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CARBOGRES_SAS
{
    public partial class editarSalida : Form

    {
       
        SqlConnection conn = new SqlConnection("data source = LAPTOP-R48K33BI\\SQLEXPRESS01 ; Initial catalog = CARBOGRES; integrated Security = true ");

        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable tb;
        int TblMaterialSAL;
        public editarSalida()
        {


            InitializeComponent();
            displayData();
        }
        public void displayData()
        {
            conn.Open();

            adpt = new SqlDataAdapter("Select * From TblMaterialSAL", conn);
            tb = new DataTable();
            adpt.Fill(tb);
            Data.DataSource = tb;
            conn.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            MENUSALIDA atras = new MENUSALIDA();
            atras.Show();
            this.Hide();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Data.DataSource = SalidaDAL.BuscarMaterial (TXTBuscar.Text, TXTBUSCARFECHA.Text, TXTBUSCARMATERIAL.Text,TXTBUSCAROBRA.Text);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        { 
          conn.Open();
            cmd = new SqlCommand("Delete From TblMaterialSAL  Where Hora = '" + TXTHora.Text + "'", conn);
        cmd.ExecuteNonQuery();
            MessageBox.Show("Datos Eliminados Con Exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();

            displayData();
        TXTFecha.Clear();
            TXTHora.Clear();
            TXTMaterial.Clear();
            TXTCantidad.Clear();
            TXTVEHICULO.Clear();
            TXTObsevaciones.Clear();
            TXTObras.Clear();
        }

    private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTFecha.Text = Data.Rows[e.RowIndex].Cells[0].Value.ToString();
            TXTHora.Text = Data.Rows[e.RowIndex].Cells[1].Value.ToString();
            TXTMaterial.Text = Data.Rows[e.RowIndex].Cells[2].Value.ToString();
            TXTCantidad.Text = Data.Rows[e.RowIndex].Cells[3].Value.ToString();
            TXTVEHICULO.Text = Data.Rows[e.RowIndex].Cells[4].Value.ToString();
            TXTObsevaciones.Text = Data.Rows[e.RowIndex].Cells[5].Value.ToString();
            TXTObras.Text = Data.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void editarSalida_Load(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            {
                {
                    {
                        try
                        {
                            conn.Open();
                            cmd = new SqlCommand("update TblMaterialSAL set Fecha = '" + TXTFecha.Text + "',Hora = '" + TXTHora.Text + "',Materiales = '" + TXTMaterial.Text + "',Cantidad  = '" + TXTCantidad.Text + "' ,Vehiculo = '" + TXTVEHICULO.Text + "',Observaciones  = '" + TXTObsevaciones.Text + "',Obras = '" + TXTObras.Text + "' where Vehiculo ='" + TXTVEHICULO.Text + "' and Hora ='" + TXTHora.Text + "'", conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Datos Editados Con Exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            displayData();

                        }

                        catch (Exception)
                        {

                        }

                    }
                }
                TXTFecha.Clear();
                TXTHora.Clear();
                TXTMaterial.Clear();
                TXTCantidad.Clear();
                TXTVEHICULO.Clear();
                TXTObsevaciones.Clear();
                TXTObras.Clear();
                displayData();

            }
        }
    }
    }

