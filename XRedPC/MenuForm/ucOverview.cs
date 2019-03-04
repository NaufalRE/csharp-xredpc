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

namespace XRedPC.MenuForm
{
    public partial class ucOverview : XtraUserControl
    {
        private static ucOverview _instance;

        public static ucOverview Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucOverview();
                return _instance;
            }
        }
        public ucOverview()
        {
            InitializeComponent();
        }
    }
}
