using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Commander.Data
{
    public class SqlHerramienta : IDisposable
    {
        #region Constructor estatico y variables globales
        private MySqlConnection _clsSqlConnection = null;
        private MySqlCommand _clsSqlCommand = null;
        bool _blnConectado = false;
        bool _blnPreparado = false;


        private SqlHerramienta()
        {

        }


        public static SqlHerramienta Conectar(string strConnectionString)
        {
            SqlHerramienta modSql = new SqlHerramienta()
            {
                _clsSqlConnection = new MySqlConnection(strConnectionString)
            };

            try
            {
                modSql._clsSqlConnection.Open();
                modSql._blnConectado = true;
            }
            catch (Exception ex)
            {
               //
            }
            return modSql;
        }
        #endregion


        #region Métodos publicos
        public void PrepararProcedimiento(string strNombreProcedimiento, List<MySqlParameter> lstParametros, CommandType enuTipoComando = CommandType.StoredProcedure)
        {
            if (_blnConectado)
            {
                _clsSqlCommand = new MySqlCommand(strNombreProcedimiento, _clsSqlConnection)
                {
                    CommandTimeout = 0,
                    CommandType = enuTipoComando
                };
                _clsSqlCommand.Parameters.AddRange(lstParametros.ToArray());

                _blnPreparado = true;
            }
            else
            {
                throw new Exception("No hay conexion con la bd");
            }
        }

        public int EjecutarProcedimiento()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlCommand.ExecuteNonQuery();

            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }

        public object EjecutarScalar()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlCommand.ExecuteScalar();
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }

        public object EjecutarProcedimientoOutput()
        {
            object objValor = null;
            if (_blnPreparado)
            {
                
                _blnPreparado = false;
                _clsSqlCommand.ExecuteScalar();

                foreach (MySqlParameter clsParameter in _clsSqlCommand.Parameters)
                {
                    if (clsParameter.Direction == ParameterDirection.ReturnValue || clsParameter.Direction == ParameterDirection.Output)
                    {
                        objValor = clsParameter.Value;
                        break;
                    }
                }
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
            return objValor;
        }

        public DataTableReader EjecutarTableReader()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                DataTable clsDataTable = new DataTable();
                MySqlDataAdapter clsDataAdapter = new MySqlDataAdapter(_clsSqlCommand);
                clsDataAdapter.Fill(clsDataTable);
                return clsDataTable.CreateDataReader();
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }

        public DataTable EjecutarTable()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                DataTable clsDataTable = new DataTable();
                MySqlDataAdapter clsDataAdapter = new MySqlDataAdapter(_clsSqlCommand);
                clsDataAdapter.Fill(clsDataTable);
                return clsDataTable.Copy();
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }
        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                Desconectar();
                _clsSqlConnection.Dispose();
                _clsSqlCommand.Dispose();
                _blnPreparado = false;
            }
            catch { }
        }
        public void Desconectar()
        {
            _clsSqlConnection.Close();
        }



        #endregion
    }
}
