using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.InfraestructuraADO.V1.Repository
{
    public class ManejoDeBDRepository : RepositoryBase
    {

        public ManejoDeBDRepository(MySqlConnection context, MySqlTransaction transaction)
        {
            this.transaction = transaction;
            this.context = context;
        }
        public void EjecutarScriptDeBD(string scriptDeBD)
        {
            try
            {

                using (MySqlCommand comandoSQL = CreateCommand(scriptDeBD))
                {
                    using (MySqlBackup mb = new MySqlBackup(comandoSQL))
                    {
                        mb.ImportFromString(scriptDeBD);
                    }

                }
            }
            catch
            {

                throw;
            }



        }
        public void EjecutarAltoNivelScript(string scriptDeBD)
        {

            MySqlCommand comandoSQL = CreateCommand(scriptDeBD);
            comandoSQL.ExecuteNonQuery();

        }

        public void CrearBackUp(string scriptDeBD)
        {


        }

    }
}