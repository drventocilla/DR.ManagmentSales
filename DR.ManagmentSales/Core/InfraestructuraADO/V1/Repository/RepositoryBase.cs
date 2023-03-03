using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.InfraestructuraADO.V1.Repository
{


    public abstract class RepositoryBase

    {
        /// <summary>
        /// Esta propiedad de va eliminar la siguiente semana
        /// </summary>
        protected string selectQuery = "";
        protected MySqlTransaction transaction;
        protected MySqlConnection context;


        protected MySqlCommand CreateCommand(string query)
        {
            MySqlCommand comandoSQL = new MySqlCommand(query, context, transaction);
            comandoSQL.CommandTimeout = 900;

            return comandoSQL;
        }
        protected MySqlCommand CreateCommand()
        {
            MySqlCommand comandoSQL = new MySqlCommand(context, transaction);
            comandoSQL.CommandTimeout = 900;

            return comandoSQL;
        }

    }
}
