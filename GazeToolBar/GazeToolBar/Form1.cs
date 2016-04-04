using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    public partial class Form1 : ShellLib.ApplicationDesktopToolbar
    {
        
        private bool isOnStart;
        private Settings settings;
        private ContextMenu contextMenu;
        private MenuItem menuItemExit;
        private MenuItem menuItemStartOnOff;
        private RegistryKey rkApp;

        public Form1()
        {
            InitializeComponent();
            Size = ReletiveSize.formSize;
            Edge = AppBarEdges.Right;
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            isOnStart = false;
            contextMenu = new ContextMenu();
            menuItemExit = new MenuItem();
            menuItemStartOnOff = new MenuItem();
            initMenuItem();
            setBtnSize();
            connectBehaveMap();
        }

        private void initMenuItem()
        {
            menuItemExit.Text = "Exit";
            menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            menuItemExit.Click += new EventHandler(menuItemExit_Click);
            menuItemStartOnOff.Click += new EventHandler(menuItemStartOnOff_Click);
            contextMenu.MenuItems.Add(menuItemStartOnOff);
            contextMenu.MenuItems.Add(menuItemExit);
            ntficGaze.ContextMenu = contextMenu;
        }

        private void setBtnSize()
        {
            btnSingleClick.Size = ReletiveSize.btnSize;
            btnDoubleClick.Size = ReletiveSize.btnSize;
            btnRightClick.Size = ReletiveSize.btnSize;
            btnSettings.Size = ReletiveSize.btnSize;
            btnSingleClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(2));
            btnDoubleClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(3));
            btnRightClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(1));
            btnSettings.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(4));
            panel.Location = new Point(panel.Location.X, ReletiveSize.panelPositionY);
            panel.Size = ReletiveSize.panelSize;
        }

        public void setAutoStartOnOff()
        {
            if (!isOnStart)
            {
                try
                {
                    rkApp.SetValue(ValueNeverChange.RES_NAME, Application.ExecutablePath.ToString());
                    isOnStart = true;
                    settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_ON;
                    menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_ON;
                }
                catch (UnauthorizedAccessException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                rkApp.DeleteValue(ValueNeverChange.RES_NAME, false);
                isOnStart = false;
                settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_OFF;
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemStartOnOff_Click(object sender, EventArgs e)
        {
            setAutoStartOnOff();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings = new Settings(this);
            settings.Show();
        }
    }
}
