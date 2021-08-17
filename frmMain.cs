using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace VPNStatus
{
    public partial class frmMain : Form
    {
        private string _executableLocation;
        private bool _formVisible;
        private bool _forceCloseForm;
        private bool _vpnConnected;
        private bool _debugMode;
        private string _vpnConnectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(Properties.Settings.Default.VPNConnectionName))
            {
                _vpnConnectionName = Properties.Settings.Default.VPNConnectionName;
            }
        }

        /// <summary>
        /// Checks the network connection.
        /// </summary>
        /// <param name="vpnName">Name of the VPN.</param>
        /// <returns></returns>
        private bool CheckNetworkConnection(string vpnName)
        {
            bool foundNetwork = false;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                foreach (NetworkInterface Interface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if(_debugMode)
                    { 
                        Debug.WriteLine(Interface.Name); 
                    }

                    if (Interface.Name == vpnName)
                    {
                        foundNetwork = true;
                        break;
                    }
                }
            }

            return foundNetwork;
        }

        /// <summary>
        /// Handles the Tick event of the vpnCheckTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void vpnCheckTimer_Tick(object sender, EventArgs e)
        {
            CheckVPN();
        }

        /// <summary>
        /// Checks the VPN.
        /// </summary>
        private void CheckVPN()
        {
            bool foundNetwork = CheckNetworkConnection(_vpnConnectionName);

            if (foundNetwork)
            {
                lblIsConnected.Text = "Yes";
                VPNCheckIcon.Icon = new Icon(_executableLocation + "\\Assets\\vpn_on.ico");
                _vpnConnected = true;
                tsConnect.Text = "Disconnect";
                VPNCheckIcon.Text = "VPNCheck - Connected";
            }
            else
            {
                lblIsConnected.Text = "No";
                VPNCheckIcon.Icon = new Icon(_executableLocation + "\\Assets\\vpn_off.ico");
                _vpnConnected = false; 
                tsConnect.Text = "Connect";
                VPNCheckIcon.Text = "VPNCheck - Disconnected";
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            _forceCloseForm = true;
            Close();
        }

        /// <summary>
        /// Handles the Load event of the frmMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            _executableLocation = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Visible = _formVisible;
            CheckVPN();
        }

        /// <summary>
        /// Handles the DoubleClick event of the VPNCheckIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void VPNCheckIcon_DoubleClick(object sender, EventArgs e)
        {
            _formVisible = !_formVisible;
            ShowForm(_formVisible);
        }

        /// <summary>
        /// Shows the form.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void ShowForm(bool show)
        {
            if (show)
            {
                //Form should be visible
                ShowInTaskbar = true;
                Visible = true;
                WindowState = FormWindowState.Normal;

                this.Activate();

                _formVisible = true;
            }
            else
            {
                //Form should be hidden
                ShowInTaskbar = false;
                Visible = false;
                WindowState = FormWindowState.Minimized;

                _formVisible = false;
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the frmMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_forceCloseForm)
            {
                e.Cancel = true;
                ShowForm(false);
            }
        }

        /// <summary>
        /// Handles the Click event of the tsConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsConnect_Click(object sender, EventArgs e)
        {
            if(!_vpnConnected)
            {
                ChangeVPNConnection(_vpnConnectionName, true);
                tsConnect.Text = "Disconnect";
                Thread.Sleep(2000);
                CheckVPN();
            }
            else
            {
                ChangeVPNConnection(_vpnConnectionName, false);
                tsConnect.Text = "Connect";
                Thread.Sleep(2000);
                CheckVPN();
            }
        }

        /// <summary>
        /// Changes the VPN connection.
        /// </summary>
        /// <param name="vpnName">Name of the VPN.</param>
        /// <param name="connect">if set to <c>true</c> [connect].</param>
        private void ChangeVPNConnection(string vpnName, bool connect)
        {
            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            if (connect && !_vpnConnected)
            {
                process.StartInfo.FileName = "rasdial";
                process.StartInfo.Arguments = $"\"{vpnName}\"";

                process.Start();
            }
            else if (!connect && _vpnConnected)
            {
                process.StartInfo.FileName = "rasdial";
                process.StartInfo.Arguments = $"\"{vpnName}\" /disconnect";

                process.Start();
            }
        }
    }
}