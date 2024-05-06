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
    public partial class frmDimension : Form
    {

        enum Estatus { None, Idle, Tx, Rx };       
        Estatus estatus = Estatus.None;


        public String muestra = "", estudios = "";
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
        char CR = Convert.ToChar(13); //?
        char FS = Convert.ToChar(28);

        public frmDimension(string[] args)
        {
            InitializeComponent();
            rdRutina.Checked = true;
            if (args != null)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (argumentos != string.Empty) argumentos += "";
                    argumentos += args[i];
                }
            }
        }

        #region Event to receive data from port
        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            do
            {
                char chrRecibido = '\'';
                chrRecibido = Convert.ToChar(port.ReadChar());

                //if (chrRecibido.Equals(STX))
                //    port.Write(ACK.ToString());

                if (chrRecibido.Equals(STX))
                {
                    this.estatus = Estatus.Tx;

                }

                if (chrRecibido != ACK)
                {
                    this.mensaje += chrRecibido.ToString();
                }

                this.texto += chrRecibido.ToString();

                if (chrRecibido.Equals(ENQ))
                {
                    estatus = Estatus.Idle;
                    this.mensaje = string.Empty;
                    this.port.Write(ACK.ToString());
                }
                if (chrRecibido.Equals(ETX))
                {
                    this.Invoke(new MethodInvoker(AddResult));
                    this.texto = string.Empty;
                    estatus = Estatus.Idle;
                    this.port.Write(ACK.ToString());
                    this.Invoke(new MethodInvoker(ManageData));
                }
               
            }
            while (!((port.BytesToRead == 0)));
        }

        #endregion


        #region Control panel events
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
                    string results = string.Empty;
                    foreach (ListViewItem item in lstResultados.Items)
                    {
                        results += item.Text;
                        results += Environment.NewLine;
                    }
                    wr.WriteLine(results);
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
            this.lstResultados.Items.Clear();
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

                msje = msje.Replace("|", "-");

                msje = msje.Replace(FS.ToString(), "|");
                ListViewItem item = new ListViewItem(msje);
                item.ForeColor = Color.Coral;
                lstResultados.Items.Add(item);
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
                lstResultados.Items.Add(item);
                //Thread.Sleep(300);
            }
        }

        void AddResult()
        {
            texto = texto.Replace(STX.ToString(), "<STX>");
            texto = texto.Replace(ETX.ToString(), "<ETX>");
            texto = texto.Replace(CR.ToString(), "<CR>");
            texto = texto.Replace(LF.ToString(), "<LF>");
            texto = texto.Replace(ETB.ToString(), "<ETB>");
            texto = texto.Replace(ENQ.ToString(), "<ENQ>");
            texto = texto.Replace(ACK.ToString(), "<ACK>");
            texto = texto.Replace(NAK.ToString(), "<NAK>");
            texto = texto.Replace(FS.ToString(), "<FS>");
            lstResultados.Items.Add(new ListViewItem(texto));
            lstResultados.ForeColor = Color.LimeGreen;
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
            if (mensaje != string.Empty)
            {
                if (mensaje.Substring(0, 3).Contains("M"))
                {
                    sender = ACK.ToString();
                    port.Write(ACK.ToString());
                    this.Invoke(new MethodInvoker(addToSender));
                }
                // P - INTENTA REALIZAR LA COMUNICACION LE CONTESTAS CON UNA N DE QUE NO HAY NADA POR PROCESAR
                // ESTO SE HACE NADAMAS UNA VEZ CUANDO EL EQUIPO TE LO PIDE
                else if (mensaje.Substring(0, 2).Contains("P"))
                {
                    //E - <STX>P<FS>92300<FS>0<FS>1<FS>1<FS>A<FS>C9<ETX>
                    //H - <STX>N<FS>6A<ETX>
                    sendSampleComm();
                }
                // C - CALIBRACION NO LO TOMES EN CUENTA NOMAS LE CONTESTAS
                else if (mensaje.Substring(0, 2).Contains("C"))
                {
                    //E - <STX>M<FS>R<FS>1<FS>24<ETX>
                    SendResponseMeasurement();
                    // H - <STX>M<FS>A<FS><FS>E2<ETX>
                }
                // R - RESPUESTA EL EQUIPO TE ESTA ENVIANDO RESULTADO EN RELACION A UNA MUESTA 
                
                else if (mensaje.Substring(0, 2).Contains("R"))
                {
                    // E - <STX>R<FS><FS>279-38-000<FS>043092005<FS>1<FS><FS>
                    //0<FS>174513190302<FS>1<FS>1<FS>2<FS>GLU<FS>85.00<FS>
                    //mg/dL<FS>
                    //<FS>BUN<FS>7<FS>mg/dL<FS><FS>0C<ETX>
                    // CONTESTAS QUE SE RECIBIO EL RESULTADO CON 
                    //H - <STX>M<FS>R<FS>1<FS>24<ETX>
                    SendResponseMeasurement();
                    // Y ACA HACES LO NECESARIO PARA ENVIAR A LA BD LOS RESULTADOS.            

                    //Insert
                    string result = writeToSender(mensaje);
                    string[] paciente = result.Split('|');

                    //MessageBox.Show("Paciente: " + paciente[2] + "  Fecha: " + paciente[7].Substring(6, 6));
                    if (paciente[3].Length >= 4)
                    {
                        for (int i = 11; i <= paciente.Length; i = i + 4)
                        {
                            /*
                            R|*|YOLANDA SALAZAR|38|1||0|411321110211|1|1|4|
                            URCA|3.7|mg/dL||
                            GLU|170|mg/dL||
                            BUN|12|mg/dL||
                            CREA|0.8|mg/dL||62
                            */
                            
                                if (i >= paciente.Length - 2)
                                    break;
                                else
                                    SendResults(paciente[3], paciente[i].Trim(), paciente[4], paciente[i + 1].Trim());
                        }
                    }

                    //SendResults(result, result, result);

                }
                // I - EL EQUIPO LEYO EL CODIGO DE BARRAS Y PREGUNTA QUE LE  VA HACER A LA MUESTRA DETECTADA
                else if (mensaje.Substring(0, 2).Contains("I"))
                {
                    try
                    {
                        string result = writeToSender(mensaje);
                        string[] paciente = result.Split('|');
                        //I|10264249|1D
                        /*
                        <STX>D<FS>0<FS>0<FS><FS>A<FS><FS>10264258<FS>1<FS><FS>1<FS>1<FS>**<FS>1<FS>1<FS>URIC<FS><FS>
                        */
                        int i = 0;
                        DataTable dt = new DataTable();
                        if (paciente[1] != null) dt = getSamples(paciente[1]);
                        muestra = paciente[1];
                        if (dt.Rows.Count > 0)
                        {

                            sender = ACK.ToString();
                            port.Write(ACK.ToString());
                            this.Invoke(new MethodInvoker(addToSender));

                            i = 0;
                            sender = "";
                            estudios = "";
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (sender == "")
                                {
                                    int prioridad = 0;
                                    if (rdRutina.Checked == true) prioridad = 0;
                                    else if (rdUrgente.Checked == true) prioridad = 1;

                                    if (dr["paciente"].ToString().Length > 25) dr["paciente"] = dr["paciente"].ToString().Substring(0, 25).Trim();
                                    if (muestra.Length > 12) muestra = muestra.Substring(0, 12);

                                    sender = "D" + FS +//Tipo D campo default.
                                    "0" + FS +//ID del portador de la muestra 0, A o B.
                                    "0" + FS +//Load list 0-99 (0 indica una petici�n de una sola muestra).
                                    "A" + FS +//Indica al DRL agregar una solicitud de muestra asociada a un n�mero de muestra.
                                    dr["paciente"].ToString().Trim() + FS +//Nombre o numero de paciente.
                                    muestra + FS + //Campo Id muestra asignado por el operador.
                                    dr["tubo"].ToString().Replace("0", "").Substring(0, 1).Trim() + FS + //Dependiendo el tipo de tubo que es asigna accion.
                                    "LAB" + FS + //Ubicaci�n del paciente en el hospital o NULL.
                                    prioridad + FS + //Prioridad.
                                    "1" + FS + //Numero de copas para muestra.
                                    "**" + FS + //Posicion de la copa.
                                    "1" + FS; //Diluci�n, valor defecto.
                                }
                                estudios = estudios + FS + dr["estudio"].ToString().Trim();
                                i = i + 1;
                            }
                            sender = sender + i.ToString() + estudios + FS;
                            sender = STX + sender + CheckSum(sender) + ETX;
                            muestra = "";
                            port.Write(sender);
                            this.Invoke(new MethodInvoker(addToSender));
                        }
                    }
                    catch (Exception ex)
                    { 
                        MessageBox.Show(ex.Message); 
                    }
                }

            }
            this.mensaje = string.Empty;
        }


        /// <summary>
        /// 
        /// </summary>
        void sendSampleComm()
        {

            
            sender = STX + "N" + FS + CheckSum("N" + FS) + ETX;

            //sender = ENQ.ToString();
            port.Write(sender);
            this.Invoke(new MethodInvoker(addToSender));
           

        }


        /// <summary>
        /// Esta 
        /// </summary>
        void SendResponseMeasurement()
        {
            sender = STX + "M" + FS + "A" + FS + FS + "E2" + ETX;
            port.Write(sender);
            this.Invoke(new MethodInvoker(addToSender));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="muestra"></param>
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        void SendResults(string user, string studio, string type, object result)
        {
            try
            {
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

                //PerformSynchronization();
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
                    this.utxtEstatus.Text = rd["EqSta"] == DBNull.Value ? "No Activo" : "Activo";
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