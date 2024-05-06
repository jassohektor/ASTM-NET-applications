using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using apiStatus = System.Int16;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ADVIA2120
{
    public class functions
    {
        public static string _fileXML = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\db.xml";

        #region CRCTable
        private readonly static ushort[] crcTable = {
        	0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
        	0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
        	0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
        	0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
        	0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
        	0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
        	0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
        	0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
        	0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
        	0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
        	0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
        	0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
        	0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
        	0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
        	0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
        	0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
        	0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
        	0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
        	0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
        	0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
        	0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
        	0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
        	0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
        	0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
        	0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
        	0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
        	0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
        	0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
        	0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
        	0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
        	0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
        	0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040 
        };
        #endregion

        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static string CheckSum(string mensaje)
        {
            int suma = 0;

            if (mensaje != string.Empty)
            {
                for (int i = 0; i <= mensaje.Length - 1; i++)
                {
                    int x = Convert.ToChar(mensaje.Substring(i, 1));
                    suma += x;
                }

                suma = suma % 256;
            }
            string sum = "0" + Microsoft.VisualBasic.Conversion.Hex(suma).ToString();
            return sum.Substring(sum.Length - 2, 2);
        }

        public static string Reverse(string theString)
        {
            char[] c = theString.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        public static char ReturnLRC(string RequestMessage)
        {
            int lrcAnswer = 0;
            for (int i = 0; i < RequestMessage.Length; i++)
            {
                char acii = Convert.ToChar(RequestMessage.Substring(i, 1));
                int c = Convert.ToInt32(acii);
                lrcAnswer = lrcAnswer ^ c;
            }
            return (Char)lrcAnswer;
        }

        public static byte[] CalculateCrc(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            ushort crc = ushort.MaxValue;
            byte tableIndex;

            foreach (byte b in data)
            {
                tableIndex = (byte)(crc ^ b);
                crc >>= 8;
                crc ^= crcTable[tableIndex];
            }

            return BitConverter.GetBytes(crc);
        }

        public static void GetConnectionParameters()
        {
    
            DataSet ds = new DataSet();
            COBAS.Cryptography cryp = new COBAS.Cryptography();
            ds.ReadXml(_fileXML);

            if (ds.Tables.Count > 0)
            {
                DataRow row = ds.Tables["DatabaseParameters"].Rows[0];
                frmAdvia.strConnection = "Data Source = " + row["Server"].ToString() + "; Initial Catalog = " + row["Database"].ToString() + "; User id = " + row["Username"].ToString() + "; Password = " + cryp.Decrypt(row["Password"].ToString());
            }
        }

        public static void SendResults(string user, string studio, string type, object result)
        {
            try
            {
                if (!String.IsNullOrEmpty((string)result))
                {
                    GetConnectionParameters();
                    SqlConnection sqlConn = new SqlConnection(frmAdvia.strConnection);
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 60000;
                    sqlCmd.CommandText = "sp_AddUserResult";
                    sqlCmd.Parameters.AddWithValue("@user", Convert.ToInt32(user).ToString());
                    sqlCmd.Parameters.AddWithValue("@system", frmAdvia.argumentos);
                    sqlCmd.Parameters.AddWithValue("@sample", studio);
                    sqlCmd.Parameters.AddWithValue("@type", type);
                    sqlCmd.Parameters.AddWithValue("@value", result);

                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                //MessageBox.Show(er.Message);
            }
        }

        public static DataTable getUserData(string user)
        {
            DataTable dt = new DataTable();
            try
            {

                // GetConnectionParameters();
                GetConnectionParameters();
                SqlConnection sqlConn = new SqlConnection(frmAdvia.strConnection);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandTimeout = 60000;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_GetUserData";
                sqlCmd.Parameters.AddWithValue("@user", user.Trim());

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return dt;
        }

        public static Object property(string type, Object row)
        {
            Object obj = new Object();
            byte obyte = new byte();
            Byte[] obytes = new Byte[] { };
            bool oVal = new bool();

            if (type == "System.Byte") obj = (row is DBNull) ? obyte : Convert.ToByte(row);
            else if (type == "System.String") obj = (row is DBNull) ? string.Empty : Convert.ToString(row);
            else if (type == "System.Char") obj = (row is DBNull) ? string.Empty : Convert.ToString(row);
            else if (type == "System.Decimal") obj = (row is DBNull) ? 0 : Convert.ToDecimal(row);
            else if (type == "System.Double") obj = (row is DBNull) ? 0 : Convert.ToDouble(row);
            else if (type == "System.Int16") obj = (row is DBNull) ? row : Convert.ToInt16(row);
            else if (type == "System.Int32") obj = (row is DBNull) ? 0 : Convert.ToInt32(row);
            else if (type == "System.Int64") obj = (row is DBNull) ? 0 : Convert.ToInt64(row);
            else if (type == "System.SByte") obj = (row is DBNull) ? row : Convert.ToSByte(row);
            else if (type == "System.Single") obj = (row is DBNull) ? row : Convert.ToSingle(row);
            else if (type == "System.UInt16") obj = (row is DBNull) ? row : Convert.ToUInt16(row);
            else if (type == "System.UInt32") obj = (row is DBNull) ? 0 : Convert.ToUInt32(row);
            else if (type == "System.UInt64") obj = (row is DBNull) ? 0 : Convert.ToUInt64(row);
            else if (type == "System.DateTime") obj = (row is DBNull) ? DateTime.Now : Convert.ToDateTime(row);
            else if (type == "System.Boolean") obj = (row is DBNull) ? oVal : Convert.ToBoolean(row);
            else if (type == "System.Byte[]") obj = (row is DBNull) ? obytes : ((Byte[])(row));
            else obj = Convert.ToString(row);
            return obj;
        }

        /*
         System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
         byte[] toLRC = encoding.GetBytes(MT + "I " + (CR + LF));
         byte LRC = functions.CalculateLrc(toLRC);
         byte[] myByte = new byte[] {LRC};
         string val = System.Text.Encoding.ASCII.GetString(myByte);
         */
    }
}
