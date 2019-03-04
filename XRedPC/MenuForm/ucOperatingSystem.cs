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
    public partial class ucOperatingSystem : XtraUserControl
    {
        private static ucOperatingSystem _instance;

        public static ucOperatingSystem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucOperatingSystem();
                return _instance;
            }
        }
        public ucOperatingSystem()
        {
            InitializeComponent();
        }
    }
}
