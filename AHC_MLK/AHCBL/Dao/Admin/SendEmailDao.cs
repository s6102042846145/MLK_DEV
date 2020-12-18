using AHCBL.Component.Common;
using AHCBL.Dto.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao.Admin
{
    public class SendEmailDao : BaseDao<SendEmailDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<SendEmailDto> GetEmailList()
        {
            try
            {
                dt = new DataTable();
                List<SendEmailDto> email = new List<SendEmailDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD005_GET_EMAILS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                param.Clear();
                AddSQLParam(param, "@member_id", Util.NVLString(1));

                conn.Open();
                cmd.ExecuteNonQuery();
                sd.Fill(dt);
                conn.Close();
             
                foreach (DataRow dr in dt.Rows)
                {
                    email.Add(
                        new SendEmailDto
                        {
                            id = Util.NVLInt(dr["id"]),
                            name = Util.NVLString(dr["name"]),
                            detail = Util.NVLString(dr["detail"])
                        });
                }
          
                return email;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }


        public string SaveEmail(SendEmailDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD002_SAVE_EMAIL", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@id", Util.NVLInt(model.id));
                AddSQLParam(param, "@name", Util.NVLString(model.name));
                AddSQLParam(param, "@active", Util.NVLInt(model.active));
                AddSQLParam(param, "@status", action);

                conn.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    result = read.GetString(0).ToString();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
        }
    }
}
