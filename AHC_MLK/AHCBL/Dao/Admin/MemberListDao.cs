using AHCBL.Component.Common;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao.Admin
{
    public class MemberListDao : BaseDao<MemberListDao>
    {
        private SqlConnection conn;
        private DataTable dt;
        public List<MemberListDto> GetMemberList()
        {
            try
            {
                dt = new DataTable();
                List<MemberListDto> MemberList = new List<MemberListDto>();
                conn = CreateConnection();
                SqlCommand cmd = new SqlCommand("PD003_GET_MEMBERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection param = cmd.Parameters;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                param.Clear();
                AddSQLParam(param, "@member_id", Util.NVLString(1));

                conn.Open();
                cmd.ExecuteNonQuery();
                sd.Fill(dt);
                conn.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    MemberList.Add(
                        new MemberListDto
                        {
                            id = Util.NVLInt(dr["id"]),
                            username = Util.NVLString(dr["username"]),
                            //password = Util.NVLString(dr["username"]),
                            fullname = Util.NVLString(dr["fullname"]),
                            nickname = Util.NVLString(dr["nickname"]),
                            level = dr["member_level"].ToString() == "" ? 0 : Util.NVLInt(dr["member_level"]),
                            point = dr["point"].ToString() == "" ? 0 : Util.NVLInt(dr["point"]),
                            email = Util.NVLString(dr["email"]),
                            homepage = Util.NVLString(dr["homepage"]),
                            telephone = Util.NVLString(dr["telephone"]),
                            mobile = Util.NVLString(dr["mobile"]),
                            certify_case = Util.NVLString(dr["certify_case"]),
                            certify = Util.NVLString(dr["certify"]),
                            address = Util.NVLString(dr["address"]),
                            address1 = Util.NVLString(dr["address1"]),
                            address2 = Util.NVLString(dr["address2"]),
                            address3 = Util.NVLString(dr["address3"]),
                            icon = Util.NVLString(dr["icon"]),
                            img = Util.NVLString(dr["img"]),
                            mailling = Util.NVLString(dr["mailling"]),
                            sms = Util.NVLString(dr["sms"]),
                            open = Util.NVLString(dr["member_open"]),
                            signature = Util.NVLString(dr["signature"]),
                            profile = Util.NVLString(dr["profile"]),
                            memo = Util.NVLString(dr["memo"]),
                            adviser = Util.NVLString(dr["adviser"]),
                            leave_date = Util.NVLString(dr["leave_date"]),
                            intercept_date = Util.NVLString(dr["intercept_date"]),
                            txt1 = Util.NVLString(dr["txt1"]),
                            txt2 = Util.NVLString(dr["txt2"]),
                            txt3 = Util.NVLString(dr["txt3"]),
                            txt4 = Util.NVLString(dr["txt4"]),
                            txt5 = Util.NVLString(dr["txt5"]),
                            txt6 = Util.NVLString(dr["txt6"]),
                            txt7 = Util.NVLString(dr["txt7"]),
                            txt8 = Util.NVLString(dr["txt8"]),
                            txt9 = Util.NVLString(dr["txt9"]),
                            txt10 = Util.NVLString(dr["txt10"]),
                            status = Util.NVLString(dr["status"])

                        });
                }
                return MemberList;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }


        public string SaveMember(MemberListDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                SqlCommand cmd = new SqlCommand("PD001_SAVE_MEMBERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@id", Util.NVLInt(model.id));
                AddSQLParam(param, "@username", Util.NVLString(model.username));
                //AddSQLParam(param, "@password", Util.NVLString(model.password));
                AddSQLParam(param, "@password", action == "del" ? "" : Util.NVLString(DataCryptography.Encrypt(model.password)));
                AddSQLParam(param, "@fullname", Util.NVLString(model.fullname));
                AddSQLParam(param, "@nickname", Util.NVLString(model.nickname));
                AddSQLParam(param, "@member_level", Util.NVLString(model.level));
                AddSQLParam(param, "@point", Util.NVLInt(model.point));
                AddSQLParam(param, "@email", Util.NVLString(model.email));
                AddSQLParam(param, "@homepage", Util.NVLString(model.homepage));
                AddSQLParam(param, "@telephone", Util.NVLString(model.telephone));
                AddSQLParam(param, "@mobile", Util.NVLString(model.mobile));
                AddSQLParam(param, "@certify_case", Util.NVLString(model.certify_case));
                AddSQLParam(param, "@certify", Util.NVLString(model.certify));
                AddSQLParam(param, "@address", Util.NVLString(model.address));
                AddSQLParam(param, "@address1", Util.NVLString(model.address1));
                AddSQLParam(param, "@address2", Util.NVLString(model.address2));
                AddSQLParam(param, "@address3", Util.NVLString(model.address3));
                AddSQLParam(param, "@icon", Util.NVLString(model.icon));
                AddSQLParam(param, "@img", Util.NVLString(model.img));
                AddSQLParam(param, "@mailling", Util.NVLString(model.mailling));
                AddSQLParam(param, "@sms", Util.NVLString(model.sms));
                AddSQLParam(param, "@member_open", Util.NVLString(model.open));
                AddSQLParam(param, "@signature", Util.NVLString(model.signature));
                AddSQLParam(param, "@profile", Util.NVLString(model.profile));
                AddSQLParam(param, "@memo", Util.NVLString(model.memo));
                AddSQLParam(param, "@adviser", Util.NVLString(model.adviser));
                AddSQLParam(param, "@leave_date", Util.NVLString(model.leave_date));
                AddSQLParam(param, "@intercept_date", Util.NVLString(model.intercept_date));
                AddSQLParam(param, "@txt1", Util.NVLString(model.txt1));
                AddSQLParam(param, "@txt2", Util.NVLString(model.txt2));
                AddSQLParam(param, "@txt3", Util.NVLString(model.txt3));
                AddSQLParam(param, "@txt4", Util.NVLString(model.txt4));
                AddSQLParam(param, "@txt5", Util.NVLString(model.txt5));
                AddSQLParam(param, "@txt6", Util.NVLString(model.txt6));
                AddSQLParam(param, "@txt7", Util.NVLString(model.txt7));
                AddSQLParam(param, "@txt8", Util.NVLString(model.txt8));
                AddSQLParam(param, "@txt9", Util.NVLString(model.txt9));
                AddSQLParam(param, "@txt10", Util.NVLString(model.txt10));
                AddSQLParam(param, "@member_id", Util.NVLInt(1));
                AddSQLParam(param, "@active", Util.NVLInt(model.active));
                AddSQLParam(param, "@status", action);

                conn.Open();
                SqlDataReader read = cmd.ExecuteReader();
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
