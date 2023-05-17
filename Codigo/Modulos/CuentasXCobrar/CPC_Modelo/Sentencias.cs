﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPC_Modelo
{
    public class Sentencias
    {

        Conexion conexion = new Conexion();
        public OdbcDataAdapter DisplayReportes(string tabla)// metodo  que obtinene el contenio de la tabla reportes
        {
            string sql = "SELECT * FROM " + tabla + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter();
            try
            {
                dataTable = new OdbcDataAdapter(sql, conexion.conexion());
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + " \nNo se pudo consultar la tabla " + tabla);
            }
            return dataTable;
        }

        public OdbcDataReader llenarcbxIdCliente()
        {
            string sql = "select Pk_idCliente from tbl_clientes;";
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public OdbcDataReader llenartxtNCliente(string id_cliente)
        {
            string sql = "select Nombres_cl from tbl_clientes where Pk_idCliente = '" + id_cliente + "';";

            try
            {
                OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader leer = cmd.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public void newPago(string values)
        {
            string campos = "pk_comprobante_cxc,fk_id_factura,fk_id_almacen_venta,fk_id_almacen_pago,fk_id_cliente,fk_id_tipoPago," +
                "fk_id_moneda,fk_id_concepto_cxc,fecha_emision_cxc,fecha_pago_cxc,cambio_moneda_pago_cxc,monto_cobro_cxc,monto_pago_cxc,estado_cxc";
            string sql = "INSERT INTO tbl_CuentaPorCobrar(" + campos + ") VALUES (" + values + ");";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en insertar en la tabla de tbl_CuentaPorCobrar"); }
        }

        public int getNewId()
        {
            string sql = "SELECT COALESCE(MAX(pk_comprobante_cxc), 0) FROM tbl_CuentaPorCobrar;";
            int id = 0;
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader.GetValue(0).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener el id de la tabla de tbl_CuentaPorCobrar"); }
            return id;
        }

        public string[] getAlmacenes()
        {
            string[] datos = new string[3];

            string sql = "SELECT codigo_almacen, nombre_almacen FROM tbl_almacen WHERE estatus_almacen = 1;";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    datos[i] = reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString();
                    i++;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener el almacen de la tabla de tbl_almacen"); }


            return datos;
        }

        public List<string> getSaldoCliente(string id_cliente)
        {
            List<string> datos = new List<string>();


            string sql = "SELECT SActual_clientes, CargoMes_clientes, AbonosMes_clientes FROM tbl_clientes WHERE Pk_idClientes = " + id_cliente + ";";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos.Add(reader.GetValue(0).ToString()+"-"+ reader.GetValue(1).ToString() + "-" + reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener el saldo de los clientes de la tabla de tbl_clientes"); }
            return datos;
        }

        public void updateCargosClientes(string id_cliente, string saldo)
        {
            string sql = "UPDATE tbl_clientes SET AbonosMes_clientes = '"+saldo+"' WHERE (`Pk_idClientes` = "+id_cliente+");";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en actualizar en la tabla de tbl_clientes"); }
        }

        public void updateSaldoMensual(string id_cliente, string saldo)
        {
            string sql = "UPDATE tbl_clientes SET SActual_clientes = '" + saldo + "' WHERE (`Pk_idClientes` = " + id_cliente + ");";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en actualizar en la tabla de tbl_clientes"); }
        }

        public List<string> getClientes(string id_cliente)
        {
            List<string> datos = new List<string>();


            string sql = "SELECT Nombres_clientes, Apellidos_clientes FROM tbl_clientes WHERE Pk_idClientes = " + id_cliente + ";";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener los clientes de la tabla de tbl_clientes"); }
            return datos;
        }

        public List<string> getMoneda()
        {
            List<string> datos = new List<string>();

            string sql = "SELECT pk_id_moneda, nombre_moneda, cambio_moneda FROM tbl_moneda WHERE estado_moneda = 1;";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos.Add(reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString() + "-" + reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener la moneda de la tabla de tbl_moneda"); }
            return datos;
        }

        public List<string> getConceptoXCobrar()
        {
            List<string> datos = new List<string>();

            string sql = "SELECT pk_id_concepto_cxc, descripcion_concepto_cxc, tipoconcepto_concepto_cxc FROM tbl_conceptocuentaporcobrar WHERE estado_concepto_cxc = 1;";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener los conceptos por cobrar de la tabla de tbl_conceptocuentaporcobrar"); }
            return datos;
        }

        public List<string> getVenta(string id_venta, string id_almacen)
        {
            List<string> datos = new List<string>();

            string sql = "SELECT fecha_venta, Total_venta, Pk_idClientes FROM tbl_venta WHERE Pk_idVenta = " + id_venta + " and codigo_almacen = " + id_almacen + ";";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos.Add(reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString() + "-" + reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener la venta de la tabla de tbl_venta"); }
            return datos;
        }

        public string[] getUltimoPago(string id_factura, string id_almacen)
        {
            string[] datos = new string[4];

            string sql = "SELECT fk_id_cliente, fecha_emision_cxc, monto_cobro_cxc, monto_pago_cxc FROM tbl_CuentaPorCobrar WHERE fk_id_factura = " + id_factura + " AND fk_id_almacen_venta = " + id_almacen + " ORDER BY pk_comprobante_cxc DESC LIMIT 1; ";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, conexion.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos[0] = reader.GetValue(0).ToString();
                    datos[1] = reader.GetValue(1).ToString();
                    datos[2] = reader.GetValue(2).ToString();
                    datos[3] = reader.GetValue(3).ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtener el pago anterior de la tabla de tbl_CuentaPorCobrar"); }


            return datos;
        }

    }
}
