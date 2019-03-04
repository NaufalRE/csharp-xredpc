using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace XRedPC.SystemForm
{
    public partial class ucWelcome : DevExpress.XtraEditors.XtraUserControl
    {
        private static ucWelcome _instance;

        public static ucWelcome Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucWelcome();
                return _instance;
            }
        }
        public ucWelcome()
        {
            InitializeComponent();
        }
    }
}
