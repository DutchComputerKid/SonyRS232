// By Quintus Snitjer.
// PDF used for programming: https://starin.info/Product%20Info/-%20-%20Archive/Sony%20Pro%20Audio/Manuals/Archive/CDP-D11%20-%20Protocol.pdf
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SonyRS232
{
    public partial class MainForm : Form
    {
        // First, declare all serial commands which are in hexadecimal.

        // Make CDP remote on status. *This  function  is  not  acceptable  when  a  Disc  Error  status.
        public byte[] remoteon = { 0x7E, 0x07, 0x05, 0x41, 0x10, 0x01, 0xFF };
        // Make CDP remote OFF status.
        public byte[] remotestop = { 0x7E, 0x07, 0x05, 0x41, 0x10, 0x02, 0xFF };
        // This command starts playback.
        public byte[] start = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x01, 0xFF };
        // This command stops during playback/pause status
        public byte[] stop = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x02, 0xFF };
        // This command changes playback mode to  pause  mode,  and  pause  mode  to  playback mode.
        public byte[] pausebutton = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x03, 0xFF };
        // To stop REW/FF/SLOW REW/SLOW FF command.
        public byte[] keyoff = { 0x7E, 0x06, 0x05, 0x41, 0x00, 0xFF };
        // This command has the same function when REW key in a remote control is pressed. Top stop REW, send “FF/REW OFF” command.
        public byte[] rewind = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x13, 0xFF };
        // This command has the same function when FF key in the remote control is pressed. To stop FF, send “KEY OFF” command.
        public byte[] fastforward = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x14, 0xFF };
        // This command has the same function when SLOW REW key in the remote control is pressed.  To stop the SLOW REW, transmit a KEY OFF command.
        public byte[] slowrewind = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x17, 0xFF };
        // This command has the same function when SLOW FF key in the remote control is pressed. To stop the SLOW FF, transmit a KEY OFF command.
        public byte[] slowfastforward = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x18, 0xFF };
        /// <summary>
        /// This command has the same function when AMS- key in the  main  unit  is  pressed(Acceptable  for  playback/pause  status)  
        /// When this command is sent in the top of a track in playback pause  mode(Less  than  a  second,  except  first  track),  playback starting point goes back to the top of  the  previous  track,  and  playback  pause  mode  is  remained.
        /// this command is sent in the middle of a track in playback  pause  mode(  more  than  a  second,  except  CUE search/PAUSE), starting point goes back to the top of the  current  track,  and  playback  pause  mode  is  remained.
        /// </summary>
        public byte[] previous = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x15, 0xFF };
        /// <summary>
        /// This command has the same function when AMS+ key in  the main unit is pressed.
        /// When this command is sent during playback (except last track), playback starts from the next track.
        /// </summary>
        public byte[] next = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x16, 0xFF };
        // Select-from track is a tad more complex, thus it is located it in's own void. For more info look at StartFromButton_Click
        public byte[] startselection = { 0x7E, 0x09, 0x05, 0x41, 0x03, 0x42, 0x01 };
        // Pausing from a selected track is the same deal:
        public byte[] pauseselection = { 0x7E, 0x09, 0x05, 0x41, 0x03, 0x43, 0x01, };
        // Eject the disc out of the unit.
        public byte[] ejectdisc = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x40, 0xFF };
        // Playback modes:
        public byte[] continousplay = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x80, 0xFF };
        public byte[] onetrackpausemode = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x81, 0xFF };
        // Repeat modes:
        public byte[] repeatoff = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xA0, 0xFF };
        public byte[] repeatall = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xA1, 0xFF };
        public byte[] repeatonetrack = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xA2, 0xFF };
        // Recieving commands        
        public byte[] modeldata = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x10, 0xFF }; // CDP outputs MODEL DATA(Disc number, Feature(function)),  when  it  receives  this  command.  1 Disc and PROGRAM WRITE of feature for CDP-D11
        public byte[] statusdata = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x20, 0xFF }; // CDP outputs this data when it receives this command.
        public byte[] discdata = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x21, 0xFF }; // CDP outputs this data when it receives this command.
        public byte[] modelname = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x22, 0xFF };  // CDP outputs MODEL NAME packet when it receives this command.
        public byte[] tocdata = { 0x7E, 0x08, 0x05, 0x41, 0x20, 0x24, 0x01, 0xFF }; // CDP outputs TOC DATA when it receives this command.  It  would  be  need  to  request  again  if  you  change  the  speed  in Vari Speed On status.       
        // Speed control
        public byte[] varispeedon = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xC1, 0xFF}; // Turn on variable speed.
        public byte[] varispeedoff = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xC0, 0xFF }; // Turn off variable speed.
        public byte[] speedcontroller = { 0x7E, 0x08, 0x05, 0x41, 0x02, 0xC2}; // Ranges from E7 to 19. -24% to +12.5%

        // Declarations
        public string modelnumber;
        public string CurrentHEXResponse;
        delegate void SetTextCallback(string text);
        private Queue<byte> recievedData = new Queue<byte>();
        public SerialPort sp = new SerialPort();
        public MainForm()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit); // Override exit so that the CD player gets remote turned off.
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Add program information:

            // Autoselect and open COM port.
            try
            {
                //Get all ports
                var ports = SerialPort.GetPortNames();
                cmbSerialPorts.DataSource = ports;
                //Add them to the combobox.
                if (cmbSerialPorts.SelectedIndex > -1)
                {
                    AddToLog(String.Format("Selected port '{0}'", cmbSerialPorts.SelectedItem));
                    //MessageBox.Show(cmbSerialPorts.SelectedItem.ToString());
                    //Connect using first available port.
                    Connect(cmbSerialPorts.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a port first");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while selecting serial port: " + error.Message);
            }
            // Set form up so that it looks nice
            ModeComboBox.SelectedIndex = 0;
            RepeatComboBox.SelectedIndex = 0;            
            logBox.SelectedIndex = logBox.Items.Count - 1;
            logBox.SelectedIndex = -1;
            // To not allow control while device is not accepting commands:
            DeInitButton.Enabled = false;
            playbackControls.Enabled = false;
            TransportControls.Enabled = false;
            VariSpeedGroup.Enabled = false;
            AddToLog("Ready!");
        }
        private void Connect(string portName)
        {
            //sp = SerialPort(portName);
            try
            {
                //Serial settings for the CDP.
                AddToLog("Initalizing " + portName +  "...");
                sp.PortName = portName;
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Open();
                sp.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); // Thread for recieving status data.
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read incoming data stream
            int bytesToRead = sp.BytesToRead;
            byte[] data = new byte[bytesToRead];
            //int actualBytesRead = 0;
            for (int offset = 0; offset < data.Length;)
            {
                int n = sp.Read(data, offset, data.Length - offset);
                offset += n;
            }
            // Make it a HEX string.
            CurrentHEXResponse = ByteArrayToString(data);
            // Send to the function for decoding
            DecodeCDStatusCode(CurrentHEXResponse, data);
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }
        private void SetText1(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InfoBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.InfoBox1.AppendText(text);
                this.InfoBox1.AppendText(Environment.NewLine);
            }
        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            AddToLog("Sending Remote ON");
            sp.Write(remoteon, 0, remoteon.Length);
            InitButton.Enabled = false;
            DeInitButton.Enabled = true;
            playbackControls.Enabled = true;
            TransportControls.Enabled = true;
            VariSpeedGroup.Enabled = true;
            // Display unit information:
            //sp.Write(modeldata, 0, modeldata.Length);
            //sp.Write(statusdata, 0, statusdata.Length);
            //sp.Write(discdata, 0, discdata.Length);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Staring playback...");
                sp.Write(start, 0, start.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Stopping playback...");
                sp.Write(stop, 0, stop.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                sp.Write(remotestop, 0, remotestop.Length);
                sp.Close();
                sp.Dispose();
                sp = null;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error upon closing SonyRS232: " + error.Message);
            }
        }

        private void DeInitButton_Click(object sender, EventArgs e)
        {
            // Turn remote control off.
            try
            {
                AddToLog("Sending Remote OFF");
                sp.Write(remotestop, 0, remotestop.Length);
                InitButton.Enabled = true;
                DeInitButton.Enabled = false;
                playbackControls.Enabled = false;
                TransportControls.Enabled = false;
                VariSpeedGroup.Enabled = false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }
        private void AddToLog(String e)
        {
            // Autoscroll to last added value.
            logBox.Items.Add(e);
            logBox.SelectedIndex = logBox.Items.Count - 1;
            logBox.SelectedIndex = -1;
        }

        private void PauseButton_click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Pausing playback...");
                sp.Write(pausebutton, 0, pausebutton.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void KeyOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Stopping all transport commands...");
                sp.Write(keyoff, 0, keyoff.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void RewindButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Rewinding...");
                sp.Write(rewind, 0, rewind.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void FFButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Fast Forwarding...");
                sp.Write(fastforward, 0, fastforward.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void SlowRewindButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Slowly Rewinding...");
                sp.Write(slowrewind, 0, slowrewind.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void SlowFastForwardButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Slowly Fast Forwarding...");
                sp.Write(slowfastforward, 0, slowfastforward.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Previous track...");
                sp.Write(previous, 0, previous.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Next track...");
                sp.Write(next, 0, next.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void StartFromButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  This is the command to start playback from the specified  track by entering the track number. PROGRAM MODE is not acceptable for this command.                     
                int intValue = Convert.ToInt32(TrackSelectorUpDown.Value);
                AddToLog("Starting at selected track " + intValue + "...");
                // First, send data to start selection.
                sp.Write(startselection, 0, startselection.Length);
                // Send track number plus end data.                  
                byte[] tracknumber = { Convert.ToByte( "0x" + intValue.ToString("X"), 16), 0xFF };
                sp.Write(tracknumber, 0, tracknumber.Length);
                // Now start at that track.
                sp.Write(start, 0, start.Length);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while starting track: " + error.Message);
            }
        }

        private void PauseOnSelection_Click(object sender, EventArgs e)
        {
            try
            {
                //  This is the command to pause playback at the top of the  specified track by entering the track number. PROGRAM MODE is not acceptable for this command.                     
                int intValue = Convert.ToInt32(TrackSelectorUpDown.Value);
                AddToLog("Pausing at selected track " + intValue + "...");
                // First, send data to start selection. 
                sp.Write(pauseselection, 0, pauseselection.Length);
                // Convert then send track number plus end data.               
                byte[] tracknumber = { Convert.ToByte("0x" + intValue.ToString("X"), 16), 0xFF };
                sp.Write(tracknumber, 0, tracknumber.Length);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while starting track: " + error.Message);
            }
        }

        private void EjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Ejecting...");
                sp.Write(ejectdisc, 0, ejectdisc.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void SetVariSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Setting Speed...");
                // Start setting up.
                int intValue = Convert.ToInt32(SpeedUpDown1.Value);
                sp.Write(speedcontroller, 0, speedcontroller.Length);
                // Send speed in HEX + end chain.
                // Send track number plus end data.                
                //Convert.ToByte("0x" + intValue.ToString("X")
                byte[] varispeedspeed = { Convert.ToByte("0x"+ intValue.ToString("X"), 16), 0xFF }; // Convert Int to HEX with 0x at the beginning plus 0xFF end notation.
                sp.Write(varispeedspeed, 0, varispeedspeed.Length);          
            }            
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void VariSpeedOn_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Enabling VariSpeed...");
                sp.Write(varispeedon, 0, varispeedon.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }

        private void VariSpeedOff_Click(object sender, EventArgs e)
        {
            try
            {
                AddToLog("Disabling VariSpeed...");
                sp.Write(varispeedoff, 0, varispeedoff.Length);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation, did you Initialize beforehand?");
            }
        }
        private void ModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Switch case to look at mode and set it accordingly.
            switch (ModeComboBox.Text)
            {

                case "Continous":
                    AddToLog("Selecting Continous mode...");
                    sp.Write(continousplay, 0, continousplay.Length);
                    break;

                case "1-Track-Pause":
                    AddToLog("Selecting 1-Track-Pause mode...");
                    sp.Write(onetrackpausemode, 0, onetrackpausemode.Length);
                    break;
            }
        }

        private void RepeatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Switch case to look at mode and set it accordingly.
            switch (RepeatComboBox.Text)
            {
                case "Off":
                    AddToLog("Repeat is now off.");
                    sp.Write(repeatoff, 0, repeatoff.Length);
                    break;

                case "All":
                    AddToLog("Repeat all tracks.");
                    sp.Write(repeatall, 0, repeatall.Length);
                    break;
                case "1 Track":
                    AddToLog("Repeat 1 track.");
                    sp.Write(repeatonetrack, 0, repeatonetrack.Length);
                    break;
            }
        }

        private void ModelButton_Click(object sender, EventArgs e)
        {
            // Force CDP to output its model name.
            sp.Write(modelname, 0, modelname.Length);
        }

        public void DecodeCDStatusCode(string input, byte[] bytes)
        {
            // This function serves as the decoder, where it takes the output of the CD player and makes it human-readable.
            // Send output as the two values and save them.
            string RawHEX = ByteArrayToString(bytes);
            string ASCIIHEX = ConvertHex(ByteArrayToString(bytes));
            SetText1(RawHEX); // Set raw hex in box 1.            

            //Some command add extra FF's so a starting with-check is done with all commands.
            //Starts with 0805412093: No disc in drive.
            //Starts with 0805412095: Table Of Contents ready.
            //Starts with 6f0705412081: TOC Fully read
            //Starts with 6f0705412080: There is no CD or CD that specified request command.
            //Starts with 6f0705410240: Disc ejected.
            //Starts with 6f0705410202: Playback stopped
            //Starts with 6f0705410203: Playback paused
            //Starts with 0705410202: Operation  has  stopped
            //Starts with 6f0c054120200280: Repeat set to off.
            //Starts with 6f0c054120200290: Repeat set to all.
            //Starts with 6f0c0541202002a0: Repeat set to 1 track.
            //Starts with 6f0705412083: Track End. (For pause on 1 track mode)
            //Starts with 6f0705412084: Last 30 seconds of track are now!
            //Starts with 6f0b0541205001: Track selection successful. Add two extra for track number.
            //Starts with 6f0705410201: Started playback.
            //Is 0403ff: Impossible command recieved

            if (RawHEX.StartsWith("0805412093")) // This looks at the command 93. No disc in drive.
            {
                //Starts with 0805412093: No disc in drive.
                if (InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            SystemStatus.AppendText("No disc in drive!" + Environment.NewLine);
                        }));
                    }
            }
            if (RawHEX.StartsWith("0805412095"))
            {
                //Starts with 0805412095: Table Of Contents ready.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("TOC Ready." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705412081")) 
            {
                //Starts with 6f0705412081: TOC Fully read
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("TOC Fully read." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705412080"))
            {
                //Starts with 6f0705412080: There is no CD or CD that specified request command.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("No CD or non-requested command." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705410240")) 
            {
                //Starts with 6f0705410240: Disc ejected.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Disc ejected." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705410202")) 
            {
                //Starts with 6f0705410202: Playback stopped
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Playback stopped." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705410203"))
            {
                //Starts with 6f0705410203: Playback paused
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Playback paused." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("0705410202"))
            {
                //Starts with 0705410202: Operation  has  stopped
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Operation stopped." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0c054120200280")) 
            {
                //Starts with 6f0c054120200280: Repeat set to off.

                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Repeat set to off." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0c054120200290")) 
            {
                //Starts with 6f0c054120200290: Repeat set to all.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Repeat set to all tracks." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0c0541202002a0")) 
            {
                //Starts with 6f0c0541202002a0: Repeat set to 1 track.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Repeat set to 1 track." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705412083"))
            {
                //Starts with 6f0705412083: Track End. (For pause on 1 track mode)
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Track ended." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705412084"))
            {
                //Starts with 6f0705412084: Last 30 seconds of track are now!
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Track's got 30 sec. left." + Environment.NewLine);
                    }));
                }
            }


            if (RawHEX.StartsWith("6f0b0541205001"))
            {
                //Starts with 6f0b0541205001: Track selection successful. Add two extra for track number.
                // Todo, 6f0b0541205001 has one hex value at the end which is the track number.
                string TrackHEX = RawHEX.Substring(RawHEX.Length - 2);
                int TrackNumber = int.Parse(TrackHEX, System.Globalization.NumberStyles.HexNumber);
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Track switch to " + TrackNumber + " successful!" + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("6f0705410201")) 
            {
                //Starts with 6f0705410201: Start-From command executed.
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Started playing." + Environment.NewLine);
                    }));
                }
            }
            if (RawHEX.StartsWith("0403ff")) 
            {
                //Is 0403ff: Impossible command recieved
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        SystemStatus.AppendText("Impossible action requested?" + Environment.NewLine);
                    }));
                }
            }        
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(Application.ProductName + "Controller for Sony CDP-D1x." 
                + Environment.NewLine + "Version: " + Application.ProductVersion
                + Environment.NewLine + "Allows for system control via a nullmodel cable to PC.");
        }
    }
}
