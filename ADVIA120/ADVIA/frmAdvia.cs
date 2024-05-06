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

namespace ADVIA2120
{
    public partial class frmAdvia : Form
    {

        enum Estatus { None, Idle, Tx, Rx };
        Estatus estatus = Estatus.None;
        public String muestra = "", estudios = "";
        bool arrastre, _existeInterfaz;
        bool isConnected;
        public static string strConnection, argumentos;
        int ex, ey;
        string mensaje = string.Empty;
        string texto = string.Empty;
        string sender = string.Empty;
        char ENQ = Convert.ToChar(5);
        char ACK = Convert.ToChar(6);
        char NAK = Convert.ToChar(21);
        char ETX = Convert.ToChar(3);
        char EOT = Convert.ToChar(4);
        char STX = Convert.ToChar(2);
        char ETB = Convert.ToChar(23);
        char FS = Convert.ToChar(28);
        char CR = Convert.ToChar(13);
        char LF = Convert.ToChar(10);

        public static int next = 48;
        char MT = Convert.ToChar(next); //48 to 90

        string[] equip;
        public frmAdvia(string[] args)
        {
            InitializeComponent();
            equip = args;


            if (args != null)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (argumentos != string.Empty) argumentos += "";
                    argumentos += args[i];
                }
            }
            timer.Enabled = true;
            timer.Interval = 15000;
            timer.Start();


            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        #region Events to receive data from port

        string cadena;
        char LRC;
        string send;
        bool into = false;
        string ruta = Directory.GetCurrentDirectory() + "\\";
        DirectoryInfo dir;
        StreamWriter writer;
        FileStream stream;
        string Filename;
        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (into == false)
            {
                //dir = new DirectoryInfo(ruta);
                //Filename = Path.Combine(ruta, "port.txt");
                //stream = new FileStream(Filename, FileMode.Create, FileAccess.Write);
                //writer = new StreamWriter(stream);
                into = true;
                //if (!dir.Exists)
                //{
                //    dir.Create();
                //}
            }

            System.Threading.Thread.Sleep(1000);
            port.ReadTimeout = 60000;

            do
            {
                char chrRecibido = '\'';

                chrRecibido = Convert.ToChar(port.ReadChar());
                
                //writer.Write(chrRecibido);
                //writer.Flush();
                System.Windows.Forms.Application.DoEvents();
                int bytes = port.BytesToRead;
                if (port.BytesToRead > 0)
                {
                    cadena += chrRecibido.ToString();
                }
                else if (port.BytesToRead == 0 & cadena != null)
                {
                    cadena += chrRecibido.ToString();
                    string test = "";
                    if (cadena.Length > 1 & cadena.Contains(" ")) test = cadena.Replace(STX.ToString(), null).Substring(0, cadena.IndexOf(" ")).ToString().Trim();

                    if (test.Contains("S") || test.Contains("Q") & test.Length > 1 || test.Contains("E") & test.Length > 1 || test.Contains("R") & test.Length > 1)
                    {
                        isConnected = true;
                        next = next + 1;
                        //if (test.Length > 1)
                        if (test.Contains(Convert.ToChar((next > 90) ? next = 48 : next).ToString()) & cadena.Substring(3, 1).Trim() != "R")
                        {
                            MT = Convert.ToChar(next);
                            send = MT.ToString();
                            port.Write(send);

                            //writer.Write(send);
                            //writer.Flush();
                            if (Convert.ToInt32(MT) != 90)
                            {
                                next = next + 1;
                                MT = Convert.ToChar(next);
                            }
                            else
                            {
                                next = 48;
                                MT = Convert.ToChar(next);
                            }
                            workOrder(test);
                            //writer.Write(send);
                            //writer.Flush();
                        }
                        else
                        {
                            if (cadena.Substring(3, 1).Trim() == "R")
                            {
                                MT = Convert.ToChar(next);
                                send = MT.ToString();
                                port.Write(send);
                                //writer.Write(send);
                                //writer.Flush();
                            }
                            else
                            {
                                send = MT.ToString();
                                port.Write(send);
                                MT = Convert.ToChar(next);
                                //writer.Write(send);
                                //writer.Flush();
                            }
                            workOrder(test);
                            //writer.Write(send);
                            //writer.Flush();
                        }
                    }
                    cadena = String.Empty;
                }
                else if (chrRecibido.ToString() == MT.ToString())
                {
                    isConnected = true;
                    next = next + 1;
                    MT = Convert.ToChar(next);
                    LRC = functions.ReturnLRC(MT.ToString() + "S          " + (CR.ToString() + LF.ToString()));
                    if (Convert.ToInt32(LRC) == 3) LRC = Convert.ToChar(127);
                    send = STX.ToString() + MT.ToString() + "S          " + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
                    port.Write(send);
                }
                this.Invoke(new MethodInvoker(Received));
            }
            while (!((port.BytesToRead == 0)));
            
        }

        private void workOrder(String type)
        {
            string character = cadena.Substring(3, 1).Trim();
            if (character == "Q")
            {
                //string result = cadena.Replace(STX.ToString(), "").Replace(MT.ToString(), "").Replace("Q", "Q|").Replace(" ", "").Replace(LRC.ToString(), "").Replace(ETX.ToString(), "");
                //string[] paciente = result.Split('|');
                //int i = 0;
                //DataTable dt = new DataTable();
                //if (paciente[1] != null) dt = getSamples(paciente[1]);
                //muestra = paciente[1];
                //if (dt.Rows.Count > 0)
                //{
                //    i = 0;
                //    sender = "";
                //    estudios = "";
                //    if (sender == "")
                //    {
                //        sender = STX.ToString() +//Start of Text            1.
                //        MT.ToString() +//Message Toggle code                1.
                //        "Y" +//ID Code                                      1.
                //        "  " +//Spaces                                      2.
                //        " " +//STAT INDICATOR U:STAT order or Space:No STAT 1.
                //        " " +//Space: New order begin transm or A: Update   1.
                //        " " + //Space                                       1.
                //        paciente[1].ToString() + //Sample Id Number         14.
                //        "                         " + FS + //Spaces         25.
                //        paciente[1].ToString() +//Patient Id(hospital#)     14.
                //        "   " +//Spaces                                     3.
                //        dt.Rows[0]["paciente"].ToString() +//Patient Name (name)    30.
                //        " " +//Space                                        1.
                //        "12/01/1987" + //Date Of Birth XX/XX/XXXX           10.
                //        " " +//Space                                        1.
                //        "M" +//(SEX): M= male, F= female, Space= Unknown    1.
                //        " " +//Space                                        1.
                //        DateTime.Now.Month.ToString("MM") +
                //        "/" +
                //        DateTime.Now.Day.ToString("DD") +
                //        "/" +
                //        DateTime.Now.Year.ToString("YY") +//Collection DateXX/XX/XX     8.
                //        " " +//Space                                        1.
                //        DateTime.Now.Hour.ToString("HH") +
                //        DateTime.Now.Minute.ToString("mm") +//Collection Time XXXX      4.
                //        " " + //Space                                       1.
                //        "LAB" +//Location                                   6.
                //        " " +//Space                                        1.
                //        "Doctor" +//Doctor                                  6.
                //        " " +//Space                                        1.
                //        (CR.ToString() + LF.ToString()) +//CR LF            2.
                //        paciente[1].Substring(paciente[1].Length - 3, 3) +
                //            //Test number for Test Request #1 (Use test number entered into the Host 
                //            //Number field of the Test Dictionary window.) Test number must be padded
                //            //with zeroes (e.g. 005, 079)                   3.

                //        //* "D" + DateTime.Now.Month.ToString("MM") + DateTime.Now.Day.ToString("DD") + DateTime.Now.Year.ToString("YY") +
                //            //Optional*   7.
                //            //* "?????" +//Previous Result value  //Optional*   5.
                //        paciente[1].Substring(paciente[1].Length - 3, 3) +//Test number for Test Request #2. Test number must be padded with zeroes (e.g. 005, 079)
                //            //  3.
                //        paciente[1].Substring(paciente[1].Length - 3, 3) + //??????
                //        (CR.ToString() + LF.ToString());//CR LF            2.

                //        LRC = functions.ReturnLRC(sender.Replace(STX.ToString(), ""));

                //        sender = sender + LRC.ToString() + ETX.ToString();


                //        /*
                //         * Sample identification number (IDee) can be from 4 to 14 bytes. If other than 14, the definition of IDee in the
                //        TRAME.PAR file must be changed to match. See Appendix.
                //        ** The patient�s age is calculated using the date of birth (DOB) and the collection date. If DOB is downloaded, the
                //        collection date must also be downloaded so that the age can be properly calculated.
                //         */
                //        i = i + 1;
                //    }
                //    muestra = "";
                //    port.Write(sender);
                //}
            }
            else if (character == "E")
            {
                //Validate
                string pass = cadena;
            }
            else if (character == "R")
            {
                //Send response measurement-device();
                string advia = "";
                string result = "";
                string mystr = cadena.Replace("   ", " ").Replace("  ", " ").Replace(" ", "|").ToString();
                string[] paciente = mystr.Split('|');
                if (paciente[1].Length > 0)
                {
                    for (int i = 5; i <= paciente.Length - 1; i = i + 1)
                    {
                        
                        if (i + 1 < paciente.Length)
                            if (functions.IsNumeric(paciente[i]) & functions.IsNumeric(paciente[i + 1].Replace(",",".")))
                            {
                                if (paciente[i].Contains(","))
                                {
                                    advia = (advia == "")?"1":Convert.ToInt32(Convert.ToInt32(advia) + 1).ToString();
                                    result = paciente[i];
                                }
                                else
                                {
                                    advia = paciente[i];
                                    result = paciente[i + 1].Replace(",", ".").Trim();
                                }
                                if (!advia.Contains(",")) functions.SendResults(paciente[1], advia, "1", result);

                                if (paciente[i].Contains(",") == false)
                                {
                                    if (Convert.ToInt32(paciente[i]) >= 1) i = i + 1;
                                }
                                //if (!functions.IsNumeric(paciente[i + 1].Replace(",", "."))) i = i + 1;
                                //else i = i + 1;
                                //.Substring(0,paciente[2].IndexOf("-"))
                            }
                    }
                }
                isConnected = true;
                next = next + 1;
                MT = Convert.ToChar(next);
                LRC = functions.ReturnLRC(MT.ToString() + "Z                 " + " 0" + (CR.ToString() + LF.ToString()));
                if (Convert.ToInt32(LRC) == 3) LRC = Convert.ToChar(127);
                send = STX.ToString() + MT.ToString() + "Z                 " + " 0" + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
                port.Write(send);
                //STX/MT/Z#/VALID/LRC/ETX
            }
            if (cadena.Substring(2, 1).Trim() == "S")
            {
                LRC = functions.ReturnLRC(MT.ToString() + "S          " + (CR.ToString() + LF.ToString()));
                if (Convert.ToInt32(LRC) == 3) LRC = Convert.ToChar(127);
                send = STX.ToString() + MT.ToString() + "S          " + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
                port.Write(send);
            }
        }

        private void workOrder2(String type)
        {
            if (cadena.Substring(2, 1).Trim() == "Q")
            {
                string result = cadena.Replace(STX.ToString(), "").Replace(MT.ToString(), "").Replace("Q", "Q|").Replace(" ", "").Replace(LRC.ToString(), "").Replace(ETX.ToString(), "");
                string[] paciente = result.Split('|');
                int i = 0;
                DataTable dt = new DataTable();
                if (paciente[1] != null) dt = getSamples(paciente[1]);
                muestra = paciente[1];
                if (dt.Rows.Count > 0)
                {
                    i = 0;
                    sender = "";
                    estudios = "";
                        if (sender == "")
                        {
                            sender = STX.ToString() +//Start of Text            1.
                            MT.ToString() +//Message Toggle code                1.
                            "Y" +//ID Code                                      1.
                            "  " +//Spaces                                      2.
                            " " +//STAT INDICATOR U:STAT order or Space:No STAT 1.
                            " " +//Space: New order begin transm or A: Update   1.
                            " " + //Space                                       1.
                            paciente[1].ToString() + //Sample Id Number         14.
                            "                         " + FS + //Spaces         25.
                            paciente[1].ToString() +//Patient Id(hospital#)     14.
                            "   " +//Spaces                                     3.
                            dt.Rows[0]["paciente"].ToString() +//Patient Name (name)    30.
                            " " +//Space                                        1.
                            "12/01/1987" + //Date Of Birth XX/XX/XXXX           10.
                            " " +//Space                                        1.
                            "M" +//(SEX): M= male, F= female, Space= Unknown    1.
                            " " +//Space                                        1.
                            DateTime.Now.Month.ToString("MM") +
                            "/" +
                            DateTime.Now.Day.ToString("DD") +
                            "/" +
                            DateTime.Now.Year.ToString("YY") +//Collection DateXX/XX/XX     8.
                            " " +//Space                                        1.
                            DateTime.Now.Hour.ToString("HH") +
                            DateTime.Now.Minute.ToString("mm") +//Collection Time XXXX      4.
                            " " + //Space                                       1.
                            "LAB" +//Location                                   6.
                            " " +//Space                                        1.
                            "Doctor" +//Doctor                                  6.
                            " " +//Space                                        1.
                            (CR.ToString() + LF.ToString()) +//CR LF            2.
                            paciente[1].Substring(paciente[1].Length - 3, 3) +
                                //Test number for Test Request #1 (Use test number entered into the Host 
                                //Number field of the Test Dictionary window.) Test number must be padded
                                //with zeroes (e.g. 005, 079)                   3.

                            //* "D" + DateTime.Now.Month.ToString("MM") + DateTime.Now.Day.ToString("DD") + DateTime.Now.Year.ToString("YY") +
                                //Optional*   7.
                                //* "?????" +//Previous Result value  //Optional*   5.
                            paciente[1].Substring(paciente[1].Length - 3, 3) +//Test number for Test Request #2. Test number must be padded with zeroes (e.g. 005, 079)
                                //  3.
                            paciente[1].Substring(paciente[1].Length - 3, 3) + //??????
                            (CR.ToString() + LF.ToString());//CR LF            2.

                            LRC = functions.ReturnLRC(sender.Replace(STX.ToString(),""));

                            sender = sender + LRC.ToString() + ETX.ToString();


                            /*
                             * Sample identification number (IDee) can be from 4 to 14 bytes. If other than 14, the definition of IDee in the
                            TRAME.PAR file must be changed to match. See Appendix.
                            ** The patient�s age is calculated using the date of birth (DOB) and the collection date. If DOB is downloaded, the
                            collection date must also be downloaded so that the age can be properly calculated.
                             */
                        i = i + 1;
                    }
                    muestra = "";
                    port.Write(sender);
                }
            }
            else if (cadena.Substring(2, 1).Trim() == "E")
            {
                //Validate
                string pass = cadena;
            }
            else if (cadena.Substring(2, 1).Trim() == "R")
            {
                //Send response measurement-device();
                string[] paciente = cadena.Replace(STX.ToString(), "").Replace(MT.ToString(),"").Replace("R","").Replace(" ","|").Split('|');
                if (paciente[3].Length >= 4)
                {
                    for (int i = 11; i <= paciente.Length; i = i + 4)
                    {
                        if (i >= paciente.Length - 2)
                            break;
                        else
                            functions.SendResults(paciente[1], paciente[i].Trim(), paciente[4], paciente[i + 1].Trim());
                    }
                }

                //STX/MT/Z#/VALID/LRC/ETX
            }
            if (cadena.Substring(2, 1).Trim() =="S")
            {
                LRC = functions.ReturnLRC(MT.ToString() + "S          " + (CR.ToString() + LF.ToString()));
                if (Convert.ToInt32(LRC) == 3) LRC = Convert.ToChar(127);
                send = STX.ToString() + MT.ToString() + "S          " + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
                port.Write(send);
            }
        }

        string lastCadena;
        void Received()
        {
            this.lstResultados.ForeColor = Color.Green;
            if (Convert.ToString((cadena != null) ? cadena.Trim() : "") != Convert.ToString((lastCadena != null) ? lastCadena.Trim() : ""))
            {
                if (cadena.Length > 4) lstResultados.Items.Add(new ListViewItem(cadena));
                if (Convert.ToInt32(MT) >= 89) lstResultados.Items.Clear();
                cont = lstResultados.Items.Count;
            }
            lastCadena = cadena;
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
                    foreach (ListViewItem item in lstResultados.Items)
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
            this.lstResultados.Items.Clear();
        }

        private void utbnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to exit application, no data will be received?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        
        private void frm_shown(object sender, EventArgs e)
        {
            argumentos = equip[0];
            if (argumentos != string.Empty)
            {
                loadConfig(argumentos);
                if (!_existeInterfaz)
                {
                    MessageBox.Show("Interface does not exists: " + argumentos);
                    this.Close();
                }
                else
                {
                    try
                    {
                        port.PortName = this.utxtPuerto.Text;
                        port.BaudRate = int.Parse(this.utxtVelocidad.Text);
                        port.Parity = (this.utxtParidad.Text.Trim() == string.Empty) ? Parity.None : (Parity)Enum.Parse(typeof(Parity), this.utxtParidad.Text.Trim());
                        port.DataBits = int.Parse(this.utxtBitsDatos.Text);
                        port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Convert.ToDecimal(Convert.ToInt32((this.utxtBitsParo.Text == "") ? 0 : Convert.ToInt32(this.utxtBitsParo.Text))).ToString());
                        port.Handshake = (Handshake)Enum.Parse(typeof(Handshake), this.utxtHandShaking.Text);
                        port.ReadTimeout = 10;

                        LRC = functions.ReturnLRC(MT.ToString() + "I " + (CR.ToString() + LF.ToString()));
                        send = STX.ToString() + MT.ToString() + "I " + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
                        int lg = send.Length;
                        port.Open();
                        port.Write(send);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                        this.Close();
                    }
                }
            }
        }

        #region Events to move form
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

        #region Methods to get listed samples and send results

        DataTable getSamples(string muestra)
        {
            DataTable dt = new DataTable();
            try
            {
                functions.GetConnectionParameters();
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

        #endregion

        #region port configuration

        void loadConfig(string argumentos)
        {
            try
            {
                functions.GetConnectionParameters();
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
                    this.port.ParityReplace = (rd["EqPaRe"].ToString().Trim() == string.Empty)? Convert.ToByte(0) : Convert.ToByte(rd["EqPaRe"].ToString());
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

        #endregion

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            LRC = functions.ReturnLRC(MT.ToString() + "I " + (CR.ToString() + LF.ToString()));
            send = STX.ToString() + MT.ToString() + "I " + (CR.ToString() + LF.ToString()) + LRC.ToString() + ETX.ToString();
            int lg = send.Length;
            port.Write(send); 
        }


        public int cont = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (lstResultados.Items.Count != cont)
            {
                frmloading.ad.Close();
                frmloading.ad = null;
            }
            cont = cont + 1;
        }
    }
}