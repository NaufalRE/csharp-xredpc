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
    public partial class ucStorage : XtraUserControl
    {
        private static ucStorage _instance;

        public static ucStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucStorage();
                return _instance;
            }
        }

        public ucStorage()
        {
            InitializeComponent();
        }
    }
}
