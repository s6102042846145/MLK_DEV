using AHCBL.Component.Common;
using AHCBL.Dto.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao.Admin
{
    public class FAQDao : BaseDao<FAQDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<FAQDto> GetFAQ()
        {
            try
            {
                dt = new DataTable();
                List<FAQDto> list = new List<FAQDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD007_GET_FAQ", conn);
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
                    list.Add(
                        new FAQDto
                        {
                            id = Util.NVLInt(dr["id"]),
                            name = Util.NVLString(dr["name"])
                        });
                }

                return list;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }


        public string SaveFAQ(FAQDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD007_SAVE_FAQ", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@id", Util.NVLInt(model.id));
                AddSQLParam(param, "@name", Util.NVLString(model.name));
                AddSQLParam(param, "@img_head", Util.NVLString(model.img_head));
                AddSQLParam(param, "@img_tail", Util.NVLString(model.img_tail));
                AddSQLParam(param, "@detail_hot", Util.NVLString(model.detail_hot));
                AddSQLParam(param, "@detail_tail", Util.NVLString(model.detail_tail));
                AddSQLParam(param, "@detail_hot_mobile", Util.NVLString(model.detail_hot_mobile));
                AddSQLParam(param, "@detail_tail_mobile", Util.NVLString(model.detail_tail_mobile));
                AddSQLParam(param, "@faq_order", Util.NVLString(model.faq_order));
                AddSQLParam(param, "@member_id", Util.NVLInt(1));
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
