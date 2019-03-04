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
using System.Management;
using XRedPC.ClassUnit;

namespace XRedPC.MenuForm
{
    public partial class ucGraphics : XtraUserControl
    {
        private static ucGraphics _instance;
        public static ucGraphics Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucGraphics();
                return _instance;
            }
        }

        GetInfoHardware HardwareInfo = new GetInfoHardware();

        public ucGraphics()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            CB_GIndex.Properties.Items.Clear();
            L_GVendor.Text = "";
            L_GName.Text = "";
            L_GType.Text = "";
            L_GDriverVersion.Text = "";
            L_GDriverDate.Text = "";
            L_GVRAMSize.Text = "";
            L_GIsAttached.Text = "";
        }

        private void GraphicsDisplay(Boolean status)
        {
            if(status == true)
            {
                L_DeviceMonitor.Visible = true;
                L_DM_Separator.Visible = true;
                L_LTotalColor.Visible = true;
                L_TotalColor.Visible = true;
                L_LCurrentRes.Visible = true;
                L_CurrentRes.Visible = true;
            }
            else
            {
                L_DeviceMonitor.Visible = false;
                L_DM_Separator.Visible = false;
                L_LTotalColor.Visible = false;
                L_TotalColor.Visible = false;
                L_LCurrentRes.Visible = false;
                L_CurrentRes.Visible = false;
            }
        }

        private void GraphicsLogo()
        {
            if(CB_GIndex.Text != "")
            {
                int Indexer = CB_GIndex.SelectedIndex;
                if (DataAdapter.DtGraphics.Rows[Indexer][1].ToString() == "NVIDIA")
                {
                    PB_Graphics.Image = Properties.Resources.nVidia;
                }
                else if (DataAdapter.DtGraphics.Rows[Indexer][1].ToString() == "AMD")
                {
                    PB_Graphics.Image = Properties.Resources.AMRA;
                }
                else if (DataAdapter.DtGraphics.Rows[Indexer][1].ToString() == "Intel Corporation")
                {
                    PB_Graphics.Image = Properties.Resources.Intel;
                }
                PB_Graphics.Visible = true;
                PB_Graphics.Enabled = true;
            }
        }

        private void GraphicsData()
        {
            if (CB_GIndex.Text != "")
            {
                int Indexer = CB_GIndex.SelectedIndex;
                L_GVendor.Text = DataAdapter.DtGraphics.Rows[Indexer][1].ToString();
                L_GName.Text = DataAdapter.DtGraphics.Rows[Indexer][2].ToString();
                L_GType.Text = DataAdapter.DtGraphics.Rows[Indexer][3].ToString();
                L_GDriverVersion.Text = DataAdapter.DtGraphics.Rows[Indexer][4].ToString();
                L_GDriverDate.Text = DataAdapter.DtGraphics.Rows[Indexer][5].ToString();
                L_GVRAMSize.Text = DataAdapter.DtGraphics.Rows[Indexer][6].ToString() + " MB";
                if (DataAdapter.DtGraphics.Rows[Indexer][7].ToString() == "True")
                {
                    L_GIsAttached.Text = DataAdapter.DtGraphics.Rows[Indexer][7].ToString();
                    GraphicsDisplay(true);
                    L_CurrentRes.Text = DataAdapter.DtGraphics.Rows[Indexer][8].ToString() + " x " + DataAdapter.DtGraphics.Rows[Indexer][9].ToString() + " @ " + DataAdapter.DtGraphics.Rows[Indexer][10].ToString() + " Hz";
                    L_TotalColor.Text = DataAdapter.DtGraphics.Rows[Indexer][11].ToString() + " Color"; 
                }
                else
                {
                    L_GIsAttached.Text = "False";
                    L_CurrentRes.Text = "";
                    L_TotalColor.Text = "";
                    GraphicsDisplay(false);
                }
                GraphicsLogo();
            }
            else
            {
                for (int x = 0; x < DataAdapter.DtGraphics.Rows.Count; x++)
                {
                    CB_GIndex.Properties.Items.Add(DataAdapter.DtGraphics.Rows[x][0].ToString());
                }
            }
        }

        private void ucGraphics_Load(object sender, EventArgs e)
        {
            ClearAll();
            GraphicsData();
            GraphicsDisplay(false);
            PB_Graphics.Visible = false;
            PB_Graphics.Enabled = false;
        }

        private void CB_GIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphicsData();
        }
    }
}
