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
using System.Text.RegularExpressions;

namespace XRedPC.MenuForm
{
    public partial class ucProcessor : XtraUserControl
    {
        private static ucProcessor _instance;

        public static ucProcessor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucProcessor();
                return _instance;
            }
        }

        GetInfoHardware HardwareInfo = new GetInfoHardware();
        String CodeName;
        String Series;

        //DataAdapter DaHardware = new DataAdapter();
        public ucProcessor()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            CB_PIndex.Properties.Items.Clear();
            L_PName.Text = "";
            L_PManufacturer.Text = "";
            L_PNumProcessor.Text = "";
            L_PCodeName.Text = "";
            L_PProcessorID.Text = "";
            L_PBaseSpeed.Text = "";
            L_PCoreCount.Text = "";
            L_PTEnabledCore.Text = "";
            L_PThread.Text = "";
            L_PSocket.Text = "";
            L_PVTX.Text = "";
            L_PVMM.Text = "";
            L_C1Size.Text = "";
            L_C2Size.Text = "";
            L_C3Size.Text = "";
        }

        private void ProcessorLogo()
        {
            if(CB_PIndex.Text != "")
            {
                int Indexer = CB_PIndex.SelectedIndex;
                if (DataAdapter.DtProcessor.Rows[Indexer][2].ToString() == "GenuineIntel")
                {
                    if (DataAdapter.DtProcessor.Rows[Indexer][2].ToString() == "GenuineIntel")
                    {
                        //For Image
                        if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon\b"))
                        {
                            if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon\(TM\) Platinum\b"))
                            {
                                PB_Processor.Image = Properties.Resources.xeon_platinum;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon\(TM\) Gold\b"))
                            {
                                PB_Processor.Image = Properties.Resources.xeon_gold;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon\(TM\) Silver\b"))
                            {
                                PB_Processor.Image = Properties.Resources.xeon_silver;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon\(TM\) Bronze\b"))
                            {
                                PB_Processor.Image = Properties.Resources.xeon_bronze;
                            }
                            else
                            {
                                PB_Processor.Image = Properties.Resources.xeon_universal;
                            }
                        }
                        else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCore\b"))
                        {
                            if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCore\(TM\) i9\b"))
                            {
                                PB_Processor.Image = Properties.Resources.core_i9x_logo;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCore\(TM\) i7\b"))
                            {
                                PB_Processor.Image = Properties.Resources.core_i7_logo;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCore\(TM\) i5\b"))
                            {
                                PB_Processor.Image = Properties.Resources.core_i5_logo;
                            }
                            else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCore\(TM\) i3\b"))
                            {
                                PB_Processor.Image = Properties.Resources.core_i3_logo;
                            }
                            else
                            {
                                PB_Processor.Image = Properties.Resources.Intel_core_1;
                            }
                        }
                        else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bPentium\b"))
                        {
                            PB_Processor.Image = Properties.Resources.intel_pentium;
                        }
                        else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bCeleron\b"))
                        {
                            PB_Processor.Image = Properties.Resources.intel_celeron;
                        }
                        else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bAtom\b"))
                        {
                            PB_Processor.Image = Properties.Resources.intel_atom;
                        }
                        else if (Regex.IsMatch(DataAdapter.DtProcessor.Rows[Indexer][1].ToString(), @"\bXeon Phi\b")) //This one is totally experimental feature
                        {
                            PB_Processor.Image = Properties.Resources.xeon_phi;
                        }

                        String temp_series = DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(25, 1);
                        if (temp_series == "X" || temp_series == "H" || temp_series == "M" || temp_series == "Q")
                        {
                            if (DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(25, 2).All(Char.IsLetter))
                            {
                                Series = DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(25, 2);
                            }
                            else
                            {
                                Series = DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(25, 1);
                            }
                        }
                        else
                        {
                            Series = DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(25, 1);
                        }

                        CodeName = DataAdapter.DtProcessor.Rows[Indexer][1].ToString().Substring(21, 1);
                        if (CodeName != null)
                        {
                            if (Series != null)
                            {
                                if (CodeName == "9")
                                {
                                    L_PCodeName.Text = "Canon Lake" + " " + Series + " Series";
                                }
                                else if (CodeName == "8")
                                {
                                    L_PCodeName.Text = "Coffee Lake" + " " + Series + " Series";
                                }
                                else if (CodeName == "7")
                                {
                                    L_PCodeName.Text = "Kaby Lake" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "6")
                                {
                                    L_PCodeName.Text = "Sky Lake" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "5")
                                {
                                    L_PCodeName.Text = "Broadwell" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "4")
                                {
                                    L_PCodeName.Text = "Haswell" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "3")
                                {
                                    L_PCodeName.Text = "Ivy Bridge" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "2")
                                {
                                    L_PCodeName.Text = "Sandy Bridge" + " " + Series + " Series"; ;
                                }
                                else if (CodeName == "1")
                                {
                                    L_PCodeName.Text = "Nehalem" + " " + Series + " Series"; ;
                                }
                            }
                        }
                        else
                        {
                            L_PCodeName.Text = "Another generation";
                        }
                        PB_Processor.Enabled = true;
                        PB_Processor.Visible = true;
                    }
                    else if (DataAdapter.DtProcessor.Rows[Indexer][2].ToString() == "AuthenticAMD")
                    {
                        L_PCodeName.Text = "AMD series will add in the future";
                    }
                    else
                    {
                        L_PCodeName.Text = "Another processor manufacturer";
                    }
                }
            }
        }

        private void ProcessorData()
        {
            if (CB_PIndex.Text != "")
            {
                int Indexer = CB_PIndex.SelectedIndex;
                L_PName.Text = DataAdapter.DtProcessor.Rows[Indexer][1].ToString();
                L_PManufacturer.Text = DataAdapter.DtProcessor.Rows[Indexer][2].ToString();
                ProcessorLogo();

                L_PProcessorID.Text = DataAdapter.DtProcessor.Rows[Indexer][3].ToString();
                L_PBaseSpeed.Text = DataAdapter.DtProcessor.Rows[Indexer][4].ToString() + " MHz";
                L_PCoreCount.Text = DataAdapter.DtProcessor.Rows[Indexer][5].ToString();
                L_PTEnabledCore.Text = DataAdapter.DtProcessor.Rows[Indexer][6].ToString();
                L_PThread.Text = DataAdapter.DtProcessor.Rows[Indexer][7].ToString();
                L_PSocket.Text = DataAdapter.DtProcessor.Rows[Indexer][8].ToString();
                L_PVTX.Text = DataAdapter.DtProcessor.Rows[Indexer][9].ToString();
                L_PVMM.Text = DataAdapter.DtProcessor.Rows[Indexer][10].ToString();

                L_C1Size.Text = DataAdapter.LC1 + " KB";
                L_C2Size.Text = DataAdapter.DtProcessor.Rows[Indexer][11].ToString() + " KB";
                L_C3Size.Text = DataAdapter.DtProcessor.Rows[Indexer][12].ToString() + " KB";
            }
            else
            {
                for(int x = 0; x < DataAdapter.DtProcessor.Rows.Count; x++)
                {
                    CB_PIndex.Properties.Items.Add(DataAdapter.DtProcessor.Rows[x][0].ToString());
                }
            } 
        }

        private void ucProcessor_Load(object sender, EventArgs e)
        {
            ClearAll();
            ProcessorData();
            L_PNumProcessor.Text = DataAdapter.NumOfProcessor;
            PB_Processor.Visible = false;
            PB_Processor.Enabled = false;
        }

        private void CB_PIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessorData();
        }
    }
}
