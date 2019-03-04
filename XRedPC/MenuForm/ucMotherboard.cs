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
    public partial class ucMotherboard : XtraUserControl
    {
        private static ucMotherboard _instance;

        public static ucMotherboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucMotherboard();
                return _instance;
            }
        }

        int[] Default_Position_B_MCopy = new int[2] { 254, 149};
        int[] Default_Position_B_BCopy = new int[2] { 254, 469};

        public ucMotherboard()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            L_MManufacture.Text = "";
            L_MProduct.Text = "";
            L_MVersion.Text = "";
            L_MSerialNumber.Text = "";
            L_MStatus.Text = "";
            L_MPowered.Text = "";
            L_MCanReplace.Text = "";

            L_BManufacture.Text = "";
            L_BVersion.Text = "";
            L_BFVersion.Text = "";
            L_BDate.Text = "";
            L_BSerialNumber.Text = "";
            L_BCharacter.Text = "";
            L_BStatus.Text = "";
            L_BPrimaryBIOS.Text = "";
        }

        //Apperance of B_Copy
        private void B_CopyAppearanceEditor(string button, string parameter)
        {
            if(button == "B_MCopy")
            {
                if (parameter == "Move")
                {
                    B_MCopy.Location = new Point(L_MSerialNumber.Location.X + L_MSerialNumber.Size.Width + 9, 149);
                }
                else if (parameter == "Restore")
                {
                    B_MCopy.Location = new Point(Default_Position_B_MCopy[0], Default_Position_B_MCopy[1]);
                }
                else
                {
                    XtraMessageBox.Show("[UNEXPECTED]Error parameter !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(button == "B_BCopy")
            {
                if(parameter == "Move")
                {
                    B_BCopy.Location = new Point(L_BSerialNumber.Location.X + L_BSerialNumber.Size.Width + 9, 469);
                }
                else if(parameter == "Restore")
                {
                    B_MCopy.Location = new Point(Default_Position_B_BCopy[0], Default_Position_B_BCopy[1]);
                }
                else
                {
                    XtraMessageBox.Show("[UNEXPECTED]Error parameter !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("[UNEXPECTED]Error parameter !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MotherboardData()
        {
            L_MManufacture.Text = DataAdapter.DtMotherboard.Rows[0][0].ToString();
            L_MProduct.Text = DataAdapter.DtMotherboard.Rows[0][1].ToString();
            L_MVersion.Text = DataAdapter.DtMotherboard.Rows[0][2].ToString();
            if(DataAdapter.DtMotherboard.Rows[0][3].ToString() != "")
            {
                L_MSerialNumber.Text = DataAdapter.DtMotherboard.Rows[0][3].ToString();
                QR_Motherboard.Text = DataAdapter.DtMotherboard.Rows[0][3].ToString();
                B_CopyAppearanceEditor("B_MCopy", "Move");
                QR_Motherboard.Visible = true;
                B_MCopy.Enabled = true;
            }
            else
            {
                QR_Motherboard.Visible = false;
                QR_Motherboard.Text = "";
                B_MCopy.Enabled = false;
                B_CopyAppearanceEditor("B_MCopy", "Restore");
            }
            L_MStatus.Text = DataAdapter.DtMotherboard.Rows[0][4].ToString();
            L_MPowered.Text = DataAdapter.DtMotherboard.Rows[0][5].ToString();
            L_MCanReplace.Text = DataAdapter.DtMotherboard.Rows[0][6].ToString();
        }

        private void BIOSData()
        {
            L_BManufacture.Text = DataAdapter.DtBIOS.Rows[0][0].ToString();
            L_BFVersion.Text = DataAdapter.DtBIOS.Rows[0][1].ToString();
            L_BVersion.Text = DataAdapter.DtBIOS.Rows[0][2].ToString();
            L_BDate.Text = DataAdapter.DtBIOS.Rows[0][3].ToString();
            if(DataAdapter.DtBIOS.Rows[0][4].ToString() != "")
            {
                L_BSerialNumber.Text = DataAdapter.DtBIOS.Rows[0][4].ToString();
                QR_BIOS.Text = DataAdapter.DtBIOS.Rows[0][4].ToString();
                B_CopyAppearanceEditor("B_BCopy", "Move");
                QR_BIOS.Visible = true;
                B_BCopy.Enabled = true;
            }
            else
            {
                QR_BIOS.Visible = false;
                QR_BIOS.Text = "";
                B_BCopy.Enabled = false;
                B_CopyAppearanceEditor("B_BCopy", "Restore");
            }
            L_BStatus.Text = DataAdapter.DtBIOS.Rows[0][5].ToString();
            L_BCharacter.Text = DataAdapter.DtBIOS.Rows[0][6].ToString();
            L_BPrimaryBIOS.Text = DataAdapter.DtBIOS.Rows[0][7].ToString();
        }

        private void CopyThing(string CopyParam)
        {
            if(CopyParam == "MotherboardSN")
            {
                Clipboard.SetText(L_MSerialNumber.Text);
            }
            else if (CopyParam == "BIOSSN")
            {
                Clipboard.SetText(L_BSerialNumber.Text);
            }
            else
            {
                XtraMessageBox.Show("[UNEXPECTED]Error !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucMotherboard_Load(object sender, EventArgs e)
        {
            ClearAll();
            MotherboardData();
            BIOSData();
        }

        private void B_MCopy_Click(object sender, EventArgs e)
        {
            if(L_MSerialNumber.Text != "")
            {
                CopyThing("MotherboardSN");
            }
            else
            {
                XtraMessageBox.Show("You have nothing to copy", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void B_BCopy_Click(object sender, EventArgs e)
        {
            if (L_BSerialNumber.Text != "")
            {
                CopyThing("BIOSSN");
            }
            else
            {
                XtraMessageBox.Show("You have nothing to copy", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
