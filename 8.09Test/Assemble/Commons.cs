using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assemble
{
    public class Commons
    {
        public static string conn = "Server= 222.235.141.8; Database=TEAM1;Uid=TEAM_1;Pwd=1234;";
        public static bool cLogInSF;
        public static string cLogInId;
        public static string cUserName;
        public static ArrayList arrayList;
        public static bool PopTag;
        public DataTable Combo1()
        {
            DataTable dTTemp = new DataTable();

            // 데이터베이스 접속
            SqlConnection Con = new SqlConnection(conn);
            Con.Open();
            try
            {
                // sMajorCode 별 공통코드 정보를 받아오는 SQL 구문 작성.
                string comboStr1 = string.Empty;

                comboStr1 += " SELECT '' AS cbItemCode         ";
                comboStr1 += "       , '선택' AS cbItemName  ";
                comboStr1 += " UNION                        ";


                comboStr1 += "  SELECT ItemCode                    AS cbItemCode       ";
                comboStr1 += "      ,concat('[' , ItemCode , ']', ItemName)  AS cbItemNam  ";
                comboStr1 += "    From ITEM_MASTER_01                                   ";
                         


                SqlDataAdapter Adapter = new SqlDataAdapter(comboStr1, Con);
                Adapter.Fill(dTTemp);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Con.Close();
            }
            return dTTemp;
        }
        public DataTable Combo2()
        {
            // 공통코드(시스템코드)테이블에서 sMajorCode에 관련된 항목들을 DataTable 형식으로 Return
            DataTable dTTemp = new DataTable();

            // 데이터베이스 접속
            SqlConnection Con = new SqlConnection(conn);
            Con.Open();
            try
            {
                // sMajorCode 별 공통코드 정보를 받아오는 SQL 구문 작성.
                string comboStr2 = string.Empty;

                comboStr2 += " SELECT '' AS ValueType         ";
                comboStr2 += "       , '선택' AS DPType  ";
                comboStr2 += " UNION                        ";


                comboStr2 += " SELECT DISTINCT ItemType AS ValueType         ";
                comboStr2 += " ,concat(                                      ";
                comboStr2 += "     '[', ItemType, ']',                       ";
                comboStr2 += "         CASE                                  ";
                comboStr2 += "         WHEN(ItemType = 'FERT') THEN '완제품' ";
                comboStr2 += "         WHEN(ItemType = 'HARB') THEN '반제품' ";
                comboStr2 += "         WHEN(ItemType = 'ROH') THEN '자재'    ";
                comboStr2 += "                                               ";
                comboStr2 += "         ELSE ''                               ";
                comboStr2 += "                                               ";
                comboStr2 += "         END                                   ";
                comboStr2 += "        ) AS DPType                            ";
                comboStr2 += "  From ITEM_MASTER_01                             ";



                SqlDataAdapter Adapter = new SqlDataAdapter(comboStr2, Con);
                Adapter.Fill(dTTemp);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Con.Close();
            }
            return dTTemp;
        }

    }
}
