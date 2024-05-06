using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;

namespace DIMENSIONRL
{
    public partial class frmImmulite : Form
    {

        enum Estatus { None, Idle, Tx, Rx };       
        Estatus estatus = Estatus.None;


        public String muestra = "", estudios = "";
        public string noSolicitud;

        bool arrastre, _existeInterfaz;
        string strConnection, argumentos;

        int ex, ey;
        string mensaje = string.Empty;
        string texto = string.Empty;
        string sender = string.Empty;
        char ENQ = Convert.ToChar(5);
        char ACK = Convert.ToChar(6); //?
        char NAK = Convert.ToChar(21); //�
        char ETX = Convert.ToChar(3); //?
        char EOT = Convert.ToChar(4); //?
        char STX = Convert.ToChar(2); //?
        char ETB = Convert.ToChar(23); //?
        char LF = Convert.ToChar(10);  //?
        char CR = Convert.ToChar(13); //?u
        char FS = Convert.ToChar(28);

        public frmImmulite(string[] args)
        {
            InitializeComponent();
            if (args != null)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (argumentos != string.Empty) argumentos += "";
                    argumentos += args[i];
                }
            }
        }

        #region Events to receive data from port
        public int times = 0;
        public string cadena;
        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            do
            {
                char chrRecibido = '\'';
                chrRecibido = Convert.ToChar(port.ReadChar());
                if (times == 0)
                {
                    port.Write(EOT.ToString());
                    times = times + 1;
                }
                else if (chrRecibido.Equals(EOT))
                {
                    port.Write(ACK.ToString());
                }

                if (chrRecibido.Equals(ENQ))
                {
                    port.Write(ACK.ToString());
                }
                if (chrRecibido != ACK)
                {
                    cadena += chrRecibido.ToString();
                }

                if (chrRecibido.Equals(ETX))
                {
                    this.Invoke(new MethodInvoker(AddResult));
                    this.Invoke(new MethodInvoker(ManageData));
                    cadena = String.Empty;
                }
            }
            while (!((port.BytesToRead == 0)));
            port.Write(ACK.ToString());
        }

        #endregion


        #region Control Panel Events
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ubtnOcultar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (savDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter wr = new StreamWriter(savDialog.FileName, true);
                    string resultados = string.Empty;
                    foreach (ListViewItem item in listView.Items)
                    {
                        resultados += item.Text;
                        resultados += Environment.NewLine;
                    }
                    wr.WriteLine(resultados);
                    wr.Flush();
                    wr.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.listView.Items.Clear();
        }

        private void utbnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to exit the application, no data will be received?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        #endregion
        #region Events to move form
        private void frm_shown(object sender, EventArgs e)
        {
            if (argumentos != string.Empty)
            {
                loadConfig(argumentos);
                if (!_existeInterfaz)
                {
                    MessageBox.Show("System Interface does not exists: " + argumentos);
                    this.Close();
                }
                else
                {
                    setupPort();
                }
            }
        } 


        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            ex = e.X;
            ey = e.Y;
            this.arrastre = true;
        }

        private void frm_MouseUp(object sender, MouseEventArgs e)
        {
            this.arrastre = false;
        }

        private void frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastre) this.Location = this.PointToScreen(new Point(MousePosition.X - this.Location.X - ex, MousePosition.Y - this.Location.Y - ey));
        }

        #endregion

        #region Methods to write into a bound server

        private string writeToSender(string msje)
        {
            if (msje != string.Empty)
            {

                msje = msje.Replace(STX.ToString(), "");
                msje = msje.Replace(ETX.ToString(), "");
                msje = msje.Replace(CR.ToString(), "");
                msje = msje.Replace(LF.ToString(), "");
                msje = msje.Replace(ETB.ToString(), "");
                msje = msje.Replace(ENQ.ToString(), "");
                msje = msje.Replace(ACK.ToString(), "");
                msje = msje.Replace(NAK.ToString(), "");
                msje = msje.Replace(EOT.ToString(), "");

                //msje = msje.Replace("|", "-");

                msje = msje.Replace(FS.ToString(), "|");
                ListViewItem item = new ListViewItem(msje);
                item.ForeColor = Color.Coral;
                listView.Items.Add(item);
            }
            return msje;
        }

        void addToSender()
        {
            if (sender != string.Empty)
            {

                sender = sender.Replace(STX.ToString(), "<STX>");
                sender = sender.Replace(ETX.ToString(), "<ETX>");
                sender = sender.Replace(CR.ToString(), "<CR>");
                sender = sender.Replace(LF.ToString(), "<LF>");
                sender = sender.Replace(ETB.ToString(), "<ETB>");
                sender = sender.Replace(ENQ.ToString(), "<ENQ>");
                sender = sender.Replace(ACK.ToString(), "<ACK>");
                sender = sender.Replace(NAK.ToString(), "<NAK>");
                sender = sender.Replace(EOT.ToString(), "<EOT>");
                sender = sender.Replace(FS.ToString(), "<FS>");
                ListViewItem item = new ListViewItem(sender);
                item.ForeColor = Color.WhiteSmoke;
                listView.Items.Add(item);
                //Thread.Sleep(300);
            }
        }

        void AddResult()
        {
            cadena = cadena.Replace(STX.ToString(), "<STX>");
            cadena = cadena.Replace(ETX.ToString(), "<ETX>");
            cadena = cadena.Replace(CR.ToString(), "<CR>");
            cadena = cadena.Replace(LF.ToString(), "<LF>");
            cadena = cadena.Replace(ETB.ToString(), "<ETB>");
            cadena = cadena.Replace(ENQ.ToString(), "<ENQ>");
            cadena = cadena.Replace(ACK.ToString(), "<ACK>");
            cadena = cadena.Replace(NAK.ToString(), "<NAK>");
            cadena = cadena.Replace(FS.ToString(), "<FS>");
            listView.Items.Add(new ListViewItem(cadena));
            listView.ForeColor = Color.LimeGreen;
            this.texto = string.Empty;
        }

        static string CheckSum(string mensaje)
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
        
        static string _fileXML = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\db.xml";

        void GetConnectionParameters()
        {
            DataSet ds = new DataSet();
            COBAS.Cryptography cryp = new COBAS.Cryptography();
            ds.ReadXml(_fileXML);

            if (ds.Tables.Count > 0)
            {
                DataRow row = ds.Tables["DatabaseParameters"].Rows[0];
                strConnection = "Data Source = " + row["Server"].ToString() + "; Initial Catalog = " + row["Database"].ToString() + "; User id = " + row["Username"].ToString() + "; Password = " + cryp.Decrypt(row["Password"].ToString());
            }
        }

        #endregion

        #region Methods to get listed samples and send results

        DataTable getSamples(string muestra)
        {
            DataTable dt = new DataTable();
            try
            {
                GetConnectionParameters();
                SqlConnection sqlConn = new SqlConnection(strConnection);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandTimeout = 60000;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_GetUsertData";
                sqlCmd.Parameters.AddWithValue("@userRequest", muestra);
                sqlCmd.Parameters.AddWithValue("@system", argumentos);

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

        public bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
        /// <summary>
        /// En este metodo vamos a realizar todo lo necesario para poder o enviar las muestras que se van a procesar por
        /// </summary>
        void ManageData()
        {
            if (cadena != string.Empty)
            {
                /*
                      1H|\^&||||Flanders^New^Jersey^07836||973-927-2828|N81|||P|1|20120713131923
                      10
                      2P|1|||||||||||||||||||||||||||||||||
                      3B
                      3O|1|gilberto||^^^fPS||||||||||||||||||||||||||
                      C6
                      4R|1|^^^fPS|0.220|ng/mL|0.050\0.050^25.0\25.0|N|N|F|||20120711111543|20120711122603|
                      C6
                      5P|2|||||||||||||||||||||||||||||||||
                      3F
                      6O|1|mario santos||^^^fPS||||||||||||||||||||||||||
                      41
                      7R|1|^^^fPS|0.050|ng/mL|0.050\0.050^25.0\25.0|<|N|F|||20120709100009|20120709111030|
                      B9
                      1H|\^&||||Flanders^New^Jersey^07836||973-927-2828|N81|||P|1|20120713132419
                      11
                      2P|1|||||||||||||||||||||||||||||||||
                      3B
                      3O|1|armando||^^^PSA||||||||||||||||||||||||||
                      2B
                      4R|1|^^^PSA|0.939|ng/mL|0.040\0.040^150\150|N|N|F|||20120704112333|20120704120305|
                      51
                      5P|2|||||||||||||||||||||||||||||||||
                      3F
                      6O|1|armando||^^^TSH||||||||||||||||||||||||||
                      39
                      7R|1|^^^TSH|1.42|uIU/mL|0.400\0.004^4.00\75.0|N|N|F|||20120703102751|20120703113811|
                      C4
                      0O|2|armando||^^^T3||||||||||||||||||||||||||
                      CC
                      1R|1|^^^T3|100|ng/dL|40.0\40.0^600\600|N|N|F|||20120703102821|20120703110752|
                      1A
                      2O|3|armando||^^^F4||||||||||||||||||||||||||
                      C2
                      3R|1|^^^F4|1.32|ng/dL|0.300\0.300^6.00\6.00|N|N|F|||20120703102851|20120703110823|
                      FE
                      4O|4|armando||^^^T4||||||||||||||||||||||||||
                      D3
                      5R|1|^^^T4|8.61|ug/dL|1.00\1.00^24.0\24.0|N|N|F|||20120703102922|20120703110852|
                      BB
                      6O|5|armando||^^^TU||||||||||||||||||||||||||
                      F7
                      7R|1|^^^TU|35.0|Percent|10.0\10.0^70.0\70.0|N|N|F|||20120703102954|20120703110924|
                      F4
                      0P|3|||||||||||||||||||||||||||||||||
                      3B
                      1O|1|alejandra||^^^TSH||||||||||||||||||||||||||
                      F4
                      2R|1|^^^TSH|1.67|uIU/mL|0.400\0.004^4.00\75.0|N|N|F|||20120703103026|20120703114045|
                      C2
                      3P|4|||||||||||||||||||||||||||||||||
                      3F
                      1H|\^&||||Flanders^New^Jersey^07836||973-927-2828|N81|||P|1|20120823180514
                   */

                //Insert
                    string result = writeToSender(cadena);
                    string[] paciente = result.Split('|');

                    if (paciente.Length > 2)
                    {
                        if (!paciente[2].Contains("^") & IsNumeric(paciente[2]))
                        {
                            noSolicitud = paciente[2];
                        }

                        if (paciente.Length > 7)
                        {
                            if (paciente[2].Contains("^"))
                            {
                                paciente[2] = paciente[2].Replace("^", "");
                                if (IsNumeric(noSolicitud))
                                {
                                    sendResults(noSolicitud, paciente[2].Trim(), paciente[4], paciente[3].Trim());
                                }
                                //port.Write(EOT.ToString());
                            }
                        }
                    }
                //sendResults(result, result, result);
            }
            this.port.Write(ACK.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        void sendSampleComm()
        {
            //sender = STX + "N" + FS + CheckSum("N" + FS) + ETX;
            sender = ENQ.ToString();
            port.Write(sender);
            this.Invoke(new MethodInvoker(addToSender));
           

        }

        void sendResults(string user, string studio, string type, object result)
        {
            try
            {
                type = "";
                if (!String.IsNullOrEmpty((string)result))
                {
                    GetConnectionParameters();
                    SqlConnection sqlConn = new SqlConnection(strConnection);
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 60000;
                    sqlCmd.CommandText = "sp_AddUserResult";
                    sqlCmd.Parameters.AddWithValue("@user", Convert.ToInt32(user).ToString());
                    sqlCmd.Parameters.AddWithValue("@system", argumentos);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        DataTable getUserData(string user)
        {
            DataTable dt = new DataTable();
            try
            {

                // GetConnectionParameters();
                GetConnectionParameters();
                SqlConnection sqlConn = new SqlConnection(strConnection);
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

        #endregion

        #region Port Configuration

        private void setupPort()
        {
            try
            {
                port.PortName = this.utxtPuerto.Text;
                port.BaudRate = SetPortBaudRate(this.utxtVelocidad.Text);
                port.Parity = SetPortParity(this.utxtParidad.Text);
                port.DataBits = SetPortDataBits(this.utxtBitsDatos.Text);
                port.StopBits = SetPortStopBits(this.utxtBitsParo.Text);//this.utxtBitsParo.Text);
                port.Handshake = SetPortHandshake(this.utxtHandShaking.Text);
                port.ReadTimeout = 10;
                port.Open();
                port.Write(ENQ.ToString());

                //     RealizaSincronizaci�n();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                this.Close();
            }
        }

        void loadConfig(string argumentos)
        {
            try
            {
                GetConnectionParameters();
                SqlConnection sqlConn = new SqlConnection(strConnection);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"SELECT * FROM tblChemistrySystem cs
                                        INNER JOIN tblSystemInterface si ON cs.Code = si.Code
                                        WHERE si.Code = '" + argumentos + "'"; //db

                sqlConn.Open();
                SqlDataReader rd = sqlCmd.ExecuteReader();

                while (rd.Read())
                {
                    this.utxtEquipo.Text = argumentos;
                    this.utxtEstatus.Text = rd["EqSta"] == DBNull.Value ? "No Active" : "Active";
                    this.utxtPuerto.Text = "COM" + rd["EqComP"].ToString();
                    this.utxtVelocidad.Text = rd["EqVel"].ToString();
                    switch (rd["EqHand"].ToString())
                    {
                        case "0":
                            this.utxtHandShaking.Text = Handshake.None.ToString();
                            break;
                        case "1":
                            this.utxtHandShaking.Text = Handshake.RequestToSend.ToString();
                            break;
                        case "2":
                            this.utxtHandShaking.Text = Handshake.RequestToSendXOnXOff.ToString();
                            break;
                        case "3":
                            this.utxtHandShaking.Text = Handshake.XOnXOff.ToString();
                            break;
                    }
                    switch (rd["EqPar"].ToString())
                    {
                        case "N":
                            this.utxtParidad.Text = Parity.None.ToString();
                            break;
                    }

                    this.utxtBitsDatos.Text = rd["EqBitDat"].ToString();
                    this.utxtBitsParo.Text = rd["EqBitSto"].ToString().Substring(0, 1);
                    this.port.ParityReplace = rd["EqPaRe"].ToString().Trim() == string.Empty ? Convert.ToByte(0) : Convert.ToByte(rd["EqPaRe"].ToString());
                    this.port.RtsEnable = rd["EqRTSE"].ToString() == "0" ? false : true;
                    this.port.DiscardNull = rd["EqNulD"].ToString() == "0" ? false : true;
                    _existeInterfaz = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static SerialPort SetPortName(string portName)
        {

            return (SerialPort)Enum.Parse(typeof(SerialPort), portName); ;
        }

        public static int SetPortBaudRate(string baudRate)
        {
            return int.Parse(baudRate);
        }

        public static Parity SetPortParity(string parity)
        {
            if (parity.Trim() == string.Empty)
            {
                return Parity.None;
            }
            else
            {
                return (Parity)Enum.Parse(typeof(Parity), parity);
            }
        }

        public static int SetPortDataBits(string dataBits)
        {
            return int.Parse(dataBits);
        }

        public static string PortCom(string puerto)
        {
            return "COM " + puerto;
        }

        public static StopBits SetPortStopBits(string stopBits)
        {

            decimal bits = Convert.ToInt32(stopBits);

            return (StopBits)Enum.Parse(typeof(StopBits), bits.ToString());
        }

        public static Handshake SetPortHandshake(string handshake)
        {
            return (Handshake)Enum.Parse(typeof(Handshake), handshake);
        }

        #endregion

    }

}