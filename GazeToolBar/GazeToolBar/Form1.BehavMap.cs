using EyeXFramework;
using System;

namespace GazeToolBar
{
    partial class Form1
    {
        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavMapDoubleClick);
            Program.EyeXHost.Connect(bhavMapRightClick);
            Program.EyeXHost.Connect(bhavMapSingleClick);
            Program.EyeXHost.Connect(bhavMapSettings);

            bhavMapDoubleClick.Add(btnDoubleClick, new ActivatableBehavior(OnBtnDoubleClick));
            bhavMapRightClick.Add(btnRightClick, new ActivatableBehavior(OnBtnRightClick));
            bhavMapSingleClick.Add(btnSingleClick, new ActivatableBehavior(OnBtnSingleClick));
            bhavMapSettings.Add(btnSettings, new ActivatableBehavior(OnBtnSettings));
        }

        private void OnBtnDoubleClick(object sender, EventArgs e)
        {
            btnDoubleClick.PerformClick();
        }

        private void OnBtnRightClick(object sender, EventArgs e)
        {
            btnRightClick.PerformClick();
        }

        private void OnBtnSingleClick(object sender, EventArgs e)
        {
            btnSingleClick.PerformClick();
        }

        private void OnBtnSettings(object sender, EventArgs e)
        {
            btnSettings.PerformClick();
        }
    }
}
