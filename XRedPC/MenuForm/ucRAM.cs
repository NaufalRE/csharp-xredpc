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
using XRedPC.ClassUnit;
using System.Management;

namespace XRedPC.MenuForm
{
    public partial class ucRAM : XtraUserControl
    {
        GetInfoHardware HardwareInfo = new GetInfoHardware();
        private static ucRAM _instance;
        public static ucRAM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucRAM();
                return _instance;
            }
        }

        private void ClearAll()
        {
            CB_RIndex.Properties.Items.Clear();
            L_RManufacturer.Text = "";
            L_RPartNumber.Text = "";
            L_RSerialNumber.Text = "";
            L_RTotalOfSocket.Text = "";
            L_RFormFactor.Text = "";
            L_RCapacity.Text = "";
            L_RMinMaxVolt.Text = "";
            L_RConfVolt.Text = "";
            L_RClockSpeed.Text = "";
            L_RConfClockSpeed.Text = "";
            
        }

        private void RAMData()
        {
            if(CB_RIndex.Text != "")
            {
                int Indexer = CB_RIndex.SelectedIndex;
                L_RManufacturer.Text = DataAdapter.DtRAM.Rows[Indexer][1].ToString();
                L_RPartNumber.Text = DataAdapter.DtRAM.Rows[Indexer][2].ToString();
                L_RSerialNumber.Text = DataAdapter.DtRAM.Rows[Indexer][3].ToString();
                L_RFormFactor.Text = DataAdapter.DtRAM.Rows[Indexer][4].ToString() + " " + DataAdapter.DtRAM.Rows[Indexer][11].ToString();
                L_RCapacity.Text = DataAdapter.DtRAM.Rows[Indexer][5].ToString();
                L_RMinMaxVolt.Text = DataAdapter.DtRAM.Rows[Indexer][6].ToString() + " V" + " / " + DataAdapter.DtRAM.Rows[Indexer][7].ToString() + " V";
                L_RConfVolt.Text = DataAdapter.DtRAM.Rows[Indexer][8].ToString() + " V";
                L_RClockSpeed.Text = DataAdapter.DtRAM.Rows[Indexer][9].ToString() + " MHz";
                L_RConfClockSpeed.Text = DataAdapter.DtRAM.Rows[Indexer][10].ToString() + " MHz";
            }
            else
            {
                for(int x = 0; x < DataAdapter.DtRAM.Rows.Count; x++)
                {
                    CB_RIndex.Properties.Items.Add(DataAdapter.DtRAM.Rows[x][0].ToString());
                }
            }
        }
        
        public ucRAM()
        {
            InitializeComponent();
        }

        private void ucRAM_Load(object sender, EventArgs e)
        {
            ClearAll();
            RAMData();
            L_RTotalOfSocket.Text = DataAdapter.DtRAM.Rows.Count.ToString() + " of " + DataAdapter.RAMSocketAvilable;
        }

        private void CB_RIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            RAMData();
        }
    }
}
