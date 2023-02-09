#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   디비관련 클래스
//   수정날짜 : 2023-02-01  
// *---------------------------------------------------------------------------------------------*
#endregion
#region < using >
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace DH_LED_Controller
{
    class DBHelper
    {
        #region < DB 셋팅 >
        public static string uid = "sa";
        public static string password = "hntadmin";
        public static string database = "SF_DJFAB";
        public static string server = "118.39.27.73,1500";
        SqlConnection conn = new SqlConnection($"SERVER={server}; DATABASE={database}; UID={uid}; PASSWORD={password};");
        SqlCommand cmd = new SqlCommand();
        #endregion

        public void Connect()  // 디비 연결 메소드
        {
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("연결실패 " + ex);
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
        }
        public void DisConnect()  // 디비 연결 해제 메소드
        { 
            try
            {
                conn.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("연결실패 " + ex);
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
        }
        public string[] Query(string num)  // 쿼리문 실행 및 쿼리 실행 값 리턴 메소드
        {
            string[] query = new string[4];

            cmd.Connection = conn;

            // 품명 품번 그룹ID 노드ID 찾는 쿼리문
            // WHERE 절에는 품번이 같은 항목만 검색하게 하는 조건
            cmd.CommandText = "SELECT COD_ITEM, NAM_ITEM, COM_WARE, COM_SAVE FROM BP0100_ITEMS"+
                $"\r\nWHERE NAM_ITEM LIKE '{num}'";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
            SqlDataReader mdr = cmd.ExecuteReader();
            try
            {               
                mdr.Read();
                query[0] += (String)mdr["NAM_ITEM"];   // 품번코드
                query[1] += (String)mdr["COM_WARE"];   // 경광등 그룹아이디
                query[2] += (String)mdr["COM_SAVE"];   // 경광등 노드아이디
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
            finally
            {
                mdr.Close();
            }
            return query;
        }
    }
}
