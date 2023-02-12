using Avalonia.Threading;
using PcNcCommClient;
using PcNcCommon;
using ReactiveUI;
using System;


namespace PanelControlTest1.ViewModels
{
    public class CoordClass : ReactiveObject
    {
        public INcClient iNcClient = null;
        public AbstractCommClientEx client = null;
        public bool isClientConnected = false;
        private ToolTableData toolTable;
        string x, y, z;
        public DispatcherTimer timer;
        private int _activeChanIndex = 0;

        private double Xpos, Ypos, Zpos;

        private double xPos = 10;
        private double yPos = 20;
        private double zPos = 30;
        public double XPos
        {
            get => xPos;
            set => this.RaiseAndSetIfChanged(ref xPos, value);
        }

        public double YPos
        {
            get => yPos;
            set => this.RaiseAndSetIfChanged(ref yPos, value);
        }
        public double ZPos
        {
            get => zPos;
            set => this.RaiseAndSetIfChanged(ref zPos, value);
        }


        //Подключение к NC
        public void Connecting()
        {
            if (!isClientConnected)
                Connect("localhost");
            else
                Disconnect();
        }

        private bool Connect(string targetName)
        {
            if (isClientConnected)
                return false;

            // this.button1.Enabled = false;

            if (iNcClient == null)
                iNcClient = new AbstractCommTcpClient();
            if (iNcClient == null)
            {
                var messageWindow1 = MessageBox.Avalonia.MessageBoxManager
   .GetMessageBoxStandardWindow("title1", "Не создан приёмопередатчик");
                messageWindow1.Show();

                // MessageBox.Show("Не создан приёмопередатчик");
                return false;
            }

            if (client == null)
                client = new AbstractCommClientEx(iNcClient);

            if (client == null)
            {
                var messageWindow2 = MessageBox.Avalonia.MessageBoxManager
  .GetMessageBoxStandardWindow("title2", "Не создан терминальный клиент");
                messageWindow2.Show();
                // MessageBox.Show("Не создан терминальный клиент");
                return false;
            }

            if (string.IsNullOrEmpty(targetName))
                targetName = PcNcConstants.TargetName;

            //this.Server = this.client;

            //if (this.client.EwiHandler != null)
            //  this.client.EwiHandler.EwiMessage += new OnEwiEvent(client_EwiMessage);
            client.ChangeServerState += new AbstractServer.OnChangeServerState(client_ChangeServerState);


            ErrorCodes error = ErrorCodes.NoError;
            error = client.InitServer(targetName);
            if (error != ErrorCodes.NoError)
            {
                var messageWindow3 = MessageBox.Avalonia.MessageBoxManager
  .GetMessageBoxStandardWindow("title2", "Ошибка при инициализации терминального клиента или ошибка соединения");
                messageWindow3.Show();
                // MessageBox.Show("Ошибка при инициализации терминального клиента или ошибка соединения");
                client.ChangeServerState -= new AbstractServer.OnChangeServerState(client_ChangeServerState);

                if (error == ErrorCodes.ExceptionError)
                    return false;

                return false;
            }

            AbstractChannel channel = client.ChanList.GetAt(_activeChanIndex);
            if (channel == null)
            {
                _activeChanIndex = 0;
                channel = client.ChanList.GetAt(_activeChanIndex);
                if (channel == null)
                {
                    _activeChanIndex = -1;
                }

                //try
                //{
                //  this.numericUpDown_channel.Value = this._activeChanIndex + 1;
                //}
                //catch
                //{
                //}
            }

            //if (channel != null)
            //{
            //  if ((channel.Msg != null)
            //      && (channel.Msg.Length > 0))
            //    AddChannelMsg(channel.Number, channel.Msg.Filepos, channel.Msg.FileIndex, channel.Msg.StackLevel,
            //      channel.Msg.Version, channel.Msg.Length, channel.Msg.Data);
            //}

            //if (channel != null)
            //{
            //  if ((channel.MdiString != null)
            //      && (!string.IsNullOrEmpty(channel.MdiString.MdiString)))
            //    AddChannelMdi(channel.Number, channel.MdiString.Version, channel.MdiString.MdiString);
            //}

            uint this_client_index = 0;
            error = client.NcFunctions.GetClientIndex(out this_client_index);
            string descr = "AxiOMA Test Data Collector " + this_client_index.ToString();
            error = client.NcFunctions.SetClientDescr(this_client_index, descr);
            error = client.NcFunctions.SetClientType(this_client_index, NcClientTypes.Debug);
            error = client.NcFunctions.SetClientState(this_client_index, NcClientStates.Active);

            toolTable = client.ToolTable;
            //AdviseChannelEvents(channel);
            // UpdateControls();
            return true;
        }
        private void Disconnect()
        {
            if (!isClientConnected
                || client == null)
                return;

            //this.Server = null;

            if (timer != null)
                timer.Stop();

            isClientConnected = false;

            //if (this.client.EwiHandler != null)
            //  this.client.EwiHandler.EwiMessage -= new OnEwiEvent(client_EwiMessage);
            client.ChangeServerState -= new AbstractServer.OnChangeServerState(client_ChangeServerState);

            AbstractChannel channel = null;
            if (client.ChanList != null)
                channel = client.ChanList.GetAt(_activeChanIndex);

            //UnAdviseChannelEvents(channel);

            if (client.NcClient != null)
            {
                client.NcClient.DestroyData();
            }

            if (client != null)
            {
                client.DestroyServer();
            }

            if (iNcClient != null)
            {
                iNcClient.DestroyData();
                iNcClient = null;
            }

            client = null;
            //UpdateControls();
        }
        public void client_ChangeServerState(object sender, AbstractServer.ChangeServerStateArgs args)
        {
            if (client.ConnectState != ConnectStates.Connected)
            {
                // iO_Digital_8_Control1.BitChanged -= IO_Digital_8_Control1_BitChanged;

                isClientConnected = false;
                if (timer != null)
                    timer.Stop();
                timer = null;
            }
            else
            {
                isClientConnected = true;

                // iO_Digital_8_Control1.BitChanged += IO_Digital_8_Control1_BitChanged;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(50);
                timer.Tick += Timer_Tick;
                timer.Start();

            }

            // UpdateControls();
        }
        //public void UpdateControls()
        //{
        //    if (this.isClientConnected)
        //    {
        //        textBtn = "Disconnect";
        //        enableConn = true;
        //    }
        //    else
        //    {
        //        textBtn = "Connect";
        //        enableConn = true;
        //    }
        //}

        public void Timer_Tick(object sender, EventArgs e)
        {

            //int filepos, level, subprog_version;
            //string filename;

            client.GetAxisDrPosValue(0, out XPos);
            xPos = Xpos;
            //Xpos.ToString();
            client.GetAxisDrPosValue(1, out yPos);
            yPos = Ypos;
            //Ypos.ToString();
            client.GetAxisDrPosValue(2, out zPos);
            zPos = Zpos;
            //Zpos.ToString();


            //this.client.GetFilePosition(1, out filename, out filepos, out level, out subprog_version);
            //filePosTextBox.Text = "Channel number: " + 1 + Environment.NewLine + "FileName: " + filename + Environment.NewLine + "File position: " + filepos + Environment.NewLine + "Level: " + level + Environment.NewLine + "Subprog version: " + subprog_version;

            //byte plcData;
            //this.client.GetPlcByte(PlcDeviceTypes.CommonPlcMemory, PlcDataKinds.Output, 1, out plcData);
            //// this.iO_Digital_8_Control2.ByteValue = plcData;
            ////byte[] plcDataArray = new byte[2];
            ////this.client.GetPlcData(PlcDeviceTypes.CommonPlcMemory, PlcDataKinds.Output, 0, 2, out plcDataArray);

            //string strPLCData = "Outputs: " + plcData + Environment.NewLine;

            //this.client.GetPlcByte(PlcDeviceTypes.CommonPlcMemory, PlcDataKinds.Input, 0, out plcData);
            //strPLCData += "Inputs: " + plcData + Environment.NewLine;
            //plcDataTextBox.Text = strPLCData;
        }

    }


}
