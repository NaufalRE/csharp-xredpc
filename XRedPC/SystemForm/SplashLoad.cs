using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using XRedPC.ClassUnit;

namespace XRedPC.SystemForm
{
    public partial class SplashLoad : SplashScreen
    {
        public SplashLoad()
        {
            InitializeComponent();
            this.labelControl1.Text = "Copyright ©" + DateTime.Now.Year.ToString() + " RedCorp.";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}