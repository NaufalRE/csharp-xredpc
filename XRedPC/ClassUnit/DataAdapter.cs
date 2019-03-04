using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Management;
using DevExpress.XtraEditors;

namespace XRedPC.ClassUnit
{
    class DataAdapter
    {
        GetInfoHardware HardwareInfo = new GetInfoHardware();

        //[LOAD]Every table is declared here (#^.^#)
        public static DataTable DtProcessor;
        public static String NumOfProcessor = "";
        public static String LC1 = "";

        public static DataTable DtGraphics;

        public static DataTable DtMotherboard;
        public static DataTable DtBIOS;

        public static DataTable DtRAM;
        public static String RAMSocketAvilable = "";

        public void TableMotherboard()
        {
            DtMotherboard = new DataTable();
            DtMotherboard.Columns.Add("mo_manufacturer");
            DtMotherboard.Columns.Add("mo_product");
            DtMotherboard.Columns.Add("mo_version");
            DtMotherboard.Columns.Add("mo_serial_number");
            DtMotherboard.Columns.Add("mo_status");
            DtMotherboard.Columns.Add("mo_powered_on");
            DtMotherboard.Columns.Add("mo_can_replace");
        }

        public void TableBIOS()
        {
            DtBIOS = new DataTable();
            DtBIOS.Columns.Add("bios_manufacture");
            DtBIOS.Columns.Add("bios_version");
            DtBIOS.Columns.Add("bios_f_version");
            DtBIOS.Columns.Add("bios_date");
            DtBIOS.Columns.Add("bios_serial_number");
            DtBIOS.Columns.Add("bios_charachter");
            DtBIOS.Columns.Add("bios_status");
            DtBIOS.Columns.Add("bios_is_primary");
        }

        public void TableProcessor()
        {
            DtProcessor = new DataTable();
            DtProcessor.Columns.Add("cpu_index");            //0
            DtProcessor.Columns.Add("cpu_name");             //1
            DtProcessor.Columns.Add("cpu_manufacture");      //2
            DtProcessor.Columns.Add("cpu_id");               //3
            DtProcessor.Columns.Add("cpu_base_speed");       //4
            DtProcessor.Columns.Add("cpu_core_count");       //5
            DtProcessor.Columns.Add("cpu_core_e_count");     //6
            DtProcessor.Columns.Add("cpu_thread");           //7
            DtProcessor.Columns.Add("cpu_socket");           //8
            DtProcessor.Columns.Add("cpu_v");                //9
            DtProcessor.Columns.Add("cpu_vm");               //10

            //Dt.Columns.Add("cpu_c1");
            DtProcessor.Columns.Add("cpu_c2");               //11
            DtProcessor.Columns.Add("cpu_c3");               //12
        }

        public void TableGraphics()
        {
            DtGraphics = new DataTable();
            DtGraphics.Columns.Add("gpu_index");
            DtGraphics.Columns.Add("gpu_vendor");
            DtGraphics.Columns.Add("gpu_name");
            DtGraphics.Columns.Add("gpu_type");
            DtGraphics.Columns.Add("gpu_driver_version");
            DtGraphics.Columns.Add("gpu_driver_date");
            DtGraphics.Columns.Add("gpu_vram");
            DtGraphics.Columns.Add("gpu_is_attached_to_display"); //Read which graphics card attached to monitor [TAKE]VideoModeDescription
            DtGraphics.Columns.Add("gpu_attached_current_display_horizontal");
            DtGraphics.Columns.Add("gpu_attached_current_display_vertical");
            DtGraphics.Columns.Add("gpu_attached_current_display_refresh_rate");
            DtGraphics.Columns.Add("gpu_attached_current_display_current_number_color");
        }

        public void TableRAM()
        {
            DtRAM = new DataTable();
            DtRAM.Columns.Add("ram_index");
            DtRAM.Columns.Add("ram_manufacturer");
            DtRAM.Columns.Add("ram_part_number");
            DtRAM.Columns.Add("ram_serial_number");
            DtRAM.Columns.Add("ram_form_factor");
            DtRAM.Columns.Add("ram_capacity");
            DtRAM.Columns.Add("ram_min_voltage");
            DtRAM.Columns.Add("ram_max_voltage");
            DtRAM.Columns.Add("ram_conf_voltage");
            DtRAM.Columns.Add("ram_clock_speed");
            DtRAM.Columns.Add("ram_conf_clock_speed");
            DtRAM.Columns.Add("ram_data_rate");
        }

        public void InsertDataMotherboard()
        {
            DtMotherboard.Rows.Add(new Object[] { "" });
            DtMotherboard.Rows[0].SetField(0, HardwareInfo.StringGetComponent("Win32_BaseBoard", "Manufacturer", ""));
            DtMotherboard.Rows[0].SetField(1, HardwareInfo.StringGetComponent("Win32_BaseBoard", "Product", ""));
            DtMotherboard.Rows[0].SetField(2, HardwareInfo.StringGetComponent("Win32_BaseBoard", "Version", ""));
            DtMotherboard.Rows[0].SetField(3, HardwareInfo.StringGetComponent("Win32_BaseBoard", "SerialNumber", ""));
            DtMotherboard.Rows[0].SetField(4, HardwareInfo.StringGetComponent("Win32_BaseBoard", "Status", ""));
            DtMotherboard.Rows[0].SetField(5, HardwareInfo.StringGetComponent("Win32_BaseBoard", "PoweredOn", ""));
            DtMotherboard.Rows[0].SetField(6, HardwareInfo.StringGetComponent("Win32_BaseBoard", "Replaceable", ""));
        }

        public void InsertDataBIOS()
        {
            DtBIOS.Rows.Add(new Object[] { "" });
            DtBIOS.Rows[0].SetField(0, HardwareInfo.StringGetComponent("Win32_BIOS", "Manufacturer", ""));
            DtBIOS.Rows[0].SetField(1, HardwareInfo.ArrayStringGetComponent("Win32_BIOS", "BIOSVersion", ""));
            DtBIOS.Rows[0].SetField(2, HardwareInfo.StringGetComponent("Win32_BIOS", "SMBIOSBIOSVersion", ""));

            String[] CDate = new String[3] { "", "", "" };
            CDate[0] = HardwareInfo.StringGetComponent("Win32_BIOS", "ReleaseDate", "").Substring(0, 4);
            CDate[1] = HardwareInfo.StringGetComponent("Win32_BIOS", "ReleaseDate", "").Substring(4, 2);
            CDate[2] = HardwareInfo.StringGetComponent("Win32_BIOS", "ReleaseDate", "").Substring(6, 2);

            String _temper = "";
            for(int indexOf = 0; indexOf < 3; indexOf++)
            {
                if(indexOf < 2)
                {
                    _temper += CDate[indexOf] + "/";
                }
                else
                {
                    _temper += CDate[indexOf];
                }
            }
            DtBIOS.Rows[0].SetField(3, _temper);
            DtBIOS.Rows[0].SetField(4, HardwareInfo.StringGetComponent("Win32_BIOS", "SerialNumber", ""));
            DtBIOS.Rows[0].SetField(5, HardwareInfo.StringGetComponent("Win32_BIOS", "Status", ""));
            DtBIOS.Rows[0].SetField(6, HardwareInfo.ArrayIntGetComponent("Win32_BIOS", "BiosCharacteristics", ""));
            DtBIOS.Rows[0].SetField(7, HardwareInfo.StringGetComponent("Win32_BIOS", "PrimaryBIOS", ""));
        }

        public void InsertDataProcessor()
        {
            for (int x = 0; x < HardwareInfo.HardwareIndexer("Win32_Processor", "DeviceId").Rows.Count; x++)
            {
                DtProcessor.Rows.Add(new Object[] { HardwareInfo.HardwareIndexer("Win32_Processor", "DeviceId").Rows[x][0].ToString() });
            }
            String IndexerP;
            if (DtProcessor.Rows.Count != 0)
            {
                for (int x = 0; x < DtProcessor.Rows.Count; x++)
                {
                    IndexerP = " WHERE DeviceId=" + "'" + DtProcessor.Rows[x][0].ToString() + "'";
                    DtProcessor.Rows[x].SetField(1, HardwareInfo.StringGetComponent("Win32_Processor", "Name", IndexerP));
                    DtProcessor.Rows[x].SetField(2, HardwareInfo.StringGetComponent("Win32_Processor", "Manufacturer", IndexerP));
                    DtProcessor.Rows[x].SetField(3, HardwareInfo.StringGetComponent("Win32_Processor", "ProcessorId", IndexerP));
                    DtProcessor.Rows[x].SetField(4, HardwareInfo.StringGetComponent("Win32_Processor", "MaxClockSpeed", IndexerP));
                    DtProcessor.Rows[x].SetField(5, HardwareInfo.StringGetComponent("Win32_Processor", "NumberOfCores", IndexerP));
                    DtProcessor.Rows[x].SetField(6, HardwareInfo.StringGetComponent("Win32_Processor", "NumberOfEnabledCore", IndexerP));
                    DtProcessor.Rows[x].SetField(7, HardwareInfo.StringGetComponent("Win32_Processor", "NumberOfLogicalProcessors", IndexerP));
                    DtProcessor.Rows[x].SetField(8, HardwareInfo.StringGetComponent("Win32_Processor", "SocketDesignation", IndexerP));
                    DtProcessor.Rows[x].SetField(9, HardwareInfo.StringGetComponent("Win32_Processor", "VirtualizationFirmwareEnabled", IndexerP));
                    DtProcessor.Rows[x].SetField(10, HardwareInfo.StringGetComponent("Win32_Processor", "VMMonitorModeExtensions", IndexerP));
                    DtProcessor.Rows[x].SetField(11, HardwareInfo.StringGetComponent("Win32_Processor", "L2CacheSize", IndexerP));
                    DtProcessor.Rows[x].SetField(12, HardwareInfo.StringGetComponent("Win32_Processor", "L3CacheSize", IndexerP));
                }
                NumOfProcessor = HardwareInfo.StringGetComponent("Win32_ComputerSystem", "NumberOfProcessors", "");
                LC1 = HardwareInfo.StringGetComponent("Win32_CacheMemory", "MaxCacheSize", " WHERE DeviceId = 'Cache Memory 0'");
            }
            else
            {
                XtraMessageBox.Show("Something went wrong we can't find any data of processor !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertDataGraphics()
        {
            for (int x = 0; x < HardwareInfo.HardwareIndexer("Win32_VideoController", "DeviceId").Rows.Count; x++)
            {
                DtGraphics.Rows.Add(new Object[] { HardwareInfo.HardwareIndexer("Win32_VideoController", "DeviceId").Rows[x][0].ToString() });
            }
            String IndexerG;
            if (DtGraphics.Rows.Count != 0)
            {
                for (int x = 0; x < DtGraphics.Rows.Count; x++)
                {
                    IndexerG = " WHERE DeviceId=" + "'" + DtGraphics.Rows[x][0].ToString() + "'";
                    DtGraphics.Rows[x].SetField(1, HardwareInfo.StringGetComponent("Win32_VideoController", "AdapterCompatibility", IndexerG));
                    DtGraphics.Rows[x].SetField(2, HardwareInfo.StringGetComponent("Win32_VideoController", "Name", IndexerG));
                    DtGraphics.Rows[x].SetField(3, HardwareInfo.StringGetComponent("Win32_VideoController", "AdapterDACType", IndexerG));
                    DtGraphics.Rows[x].SetField(4, HardwareInfo.StringGetComponent("Win32_VideoController", "DriverVersion", IndexerG));

                    String[] CDate = new String[3] { "", "", "" };
                    CDate[0] = HardwareInfo.StringGetComponent("Win32_VideoController", "DriverDate", IndexerG).Substring(0, 4);
                    CDate[1] = HardwareInfo.StringGetComponent("Win32_VideoController", "DriverDate", IndexerG).Substring(4, 2);
                    CDate[2] = HardwareInfo.StringGetComponent("Win32_VideoController", "DriverDate", IndexerG).Substring(6, 2);

                    String _temper = "";
                    for (int indexOf = 0; indexOf < 3; indexOf++)
                    {
                        if(indexOf < 2)
                        {
                            _temper += CDate[indexOf] + "/";
                        }
                        else
                        {
                            _temper += CDate[indexOf];

                        }
                        DtGraphics.Rows[x].SetField(5, _temper);
                    }

                    //This one will display [TOTAL APPROX MEMORY] for each Graphics Adapter
                    String VRAMSIZE = Convert.ToString(Double.Parse(HardwareInfo.StringGetComponent("Win32_VideoController", "AdapterRAM", IndexerG)) / 1048576);
                    DtGraphics.Rows[x].SetField(6, VRAMSIZE);
                    if(HardwareInfo.StringGetComponent("Win32_VideoController", "VideoModeDescription", IndexerG) != "")
                    {
                        DtGraphics.Rows[x].SetField(7, "True");
                    }
                    else
                    {
                        DtGraphics.Rows[x].SetField(7, "False");
                    }
                    DtGraphics.Rows[x].SetField(8, HardwareInfo.StringGetComponent("Win32_VideoController", "CurrentHorizontalResolution", IndexerG));
                    DtGraphics.Rows[x].SetField(9, HardwareInfo.StringGetComponent("Win32_VideoController", "CurrentVerticalResolution", IndexerG));
                    DtGraphics.Rows[x].SetField(10, HardwareInfo.StringGetComponent("Win32_VideoController", "CurrentRefreshRate", IndexerG));
                    DtGraphics.Rows[x].SetField(11, HardwareInfo.StringGetComponent("Win32_VideoController", "CurrentNumberOfColors", IndexerG));
                }
            }
            else
            {
                XtraMessageBox.Show("Something went wrong we can't find any data of Graphics !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertDataRAM()
        {
            RAMSocketAvilable = HardwareInfo.StringGetComponent("Win32_PhysicalMemoryArray", "MemoryDevices", "");
            for (int x = 0; x < HardwareInfo.HardwareIndexer("Win32_PhysicalMemory", "Tag").Rows.Count; x++)
            {
                DtRAM.Rows.Add(new Object[] { HardwareInfo.HardwareIndexer("Win32_PhysicalMemory", "Tag").Rows[x][0].ToString() });
            }
            String IndexerR;
            if (DtRAM.Rows.Count != 0)
            {
                for(int x = 0; x < DtRAM.Rows.Count; x++)
                {
                    IndexerR = " WHERE Tag=" + "'" + DtRAM.Rows[x][0].ToString() + "'";
                    DtRAM.Rows[x].SetField(1, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "Manufacturer", IndexerR));
                    DtRAM.Rows[x].SetField(2, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "PartNumber", IndexerR));
                    DtRAM.Rows[x].SetField(3, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "SerialNumber", IndexerR));
                    String FormFactorResult = HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "FormFactor", IndexerR);
                    if (FormFactorResult == "1")
                    {
                        DtRAM.Rows[x].SetField(4, "Other");
                    }
                    else if (FormFactorResult == "2")
                    {
                        DtRAM.Rows[x].SetField(4, "SIP");
                    }
                    else if (FormFactorResult == "3")
                    {
                        DtRAM.Rows[x].SetField(4, "DIP");
                    }
                    else if (FormFactorResult == "4")
                    {
                        DtRAM.Rows[x].SetField(4, "ZIP");
                    }
                    else if (FormFactorResult == "5")
                    {
                        DtRAM.Rows[x].SetField(4, "SOJ");
                    }
                    else if (FormFactorResult == "6")
                    {
                        DtRAM.Rows[x].SetField(4, "Proprietary");
                    }
                    else if (FormFactorResult == "7")
                    {
                        DtRAM.Rows[x].SetField(4, "SIMM");
                    }
                    else if (FormFactorResult == "8")
                    {
                        DtRAM.Rows[x].SetField(4, "DIMM");
                    }
                    else if (FormFactorResult == "9")
                    {
                        DtRAM.Rows[x].SetField(4, "TSOP");
                    }
                    else if (FormFactorResult == "10")
                    {
                        DtRAM.Rows[x].SetField(4, "PGA");
                    }
                    else if (FormFactorResult == "11")
                    {
                        DtRAM.Rows[x].SetField(4, "RIMM");
                    }
                    else if (FormFactorResult == "12")
                    {
                        DtRAM.Rows[x].SetField(4, "SODIMM");
                    }
                    else if (FormFactorResult == "13")
                    {
                        DtRAM.Rows[x].SetField(4, "SRIMM");
                    }
                    else if (FormFactorResult == "14")
                    {
                        DtRAM.Rows[x].SetField(4, "SMD");
                    }
                    else if (FormFactorResult == "15")
                    {
                        DtRAM.Rows[x].SetField(4, "SSMP");
                    }
                    else if (FormFactorResult == "16")
                    {
                        DtRAM.Rows[x].SetField(4, "QFP");
                    }
                    else if (FormFactorResult == "17")
                    {
                        DtRAM.Rows[x].SetField(4, "TQFP");
                    }
                    else if (FormFactorResult == "18")
                    {
                        DtRAM.Rows[x].SetField(4, "SOIC");
                    }
                    else if (FormFactorResult == "19")
                    {
                        DtRAM.Rows[x].SetField(4, "LCC");
                    }
                    else if (FormFactorResult == "20")
                    {
                        DtRAM.Rows[x].SetField(4, "PLCC");
                    }
                    else if (FormFactorResult == "21")
                    {
                        DtRAM.Rows[x].SetField(4, "BGA");
                    }
                    else if (FormFactorResult == "22")
                    {
                        DtRAM.Rows[x].SetField(4, "FPBGA");
                    }
                    else if (FormFactorResult == "23")
                    {
                        DtRAM.Rows[x].SetField(4, "LGA");
                    }
                    else
                    {
                        DtRAM.Rows[x].SetField(4, "Unknown");
                    }

                    String RAMSize = Convert.ToString(Double.Parse(HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "Capacity", IndexerR)) / 1048576) + " MB";
                    DtRAM.Rows[x].SetField(5, RAMSize);

                    String RAMMinVolt = Convert.ToString(Double.Parse(HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "MinVoltage", IndexerR)) / 1000);
                    DtRAM.Rows[x].SetField(6, RAMMinVolt);

                    String RAMMaxVolt = Convert.ToString(Double.Parse(HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "MaxVoltage", IndexerR)) / 1000);
                    DtRAM.Rows[x].SetField(7, RAMMaxVolt);

                    DtRAM.Rows[x].SetField(8, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "ConfiguredVoltage", IndexerR));
                    DtRAM.Rows[x].SetField(9, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "Speed", IndexerR));
                    DtRAM.Rows[x].SetField(10, HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "ConfiguredClockSpeed", IndexerR));

                    String SMBIOSMemoryTypeResult = HardwareInfo.StringGetComponent("Win32_PhysicalMemory", "SMBIOSMemoryType", IndexerR);
                    if (SMBIOSMemoryTypeResult == "2")
                    {
                        DtRAM.Rows[x].SetField(11, "DRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "3")
                    {
                        DtRAM.Rows[x].SetField(11, "Synchronus DRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "4")
                    {
                        DtRAM.Rows[x].SetField(11, "Cache DRAm");
                    }
                    else if (SMBIOSMemoryTypeResult == "5")
                    {
                        DtRAM.Rows[x].SetField(11, "EDO");
                    }
                    else if (SMBIOSMemoryTypeResult == "6")
                    {
                        DtRAM.Rows[x].SetField(11, "EDRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "7")
                    {
                        DtRAM.Rows[x].SetField(11, "VRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "8")
                    {
                        DtRAM.Rows[x].SetField(11, "SRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "9")
                    {
                        DtRAM.Rows[x].SetField(11, "RAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "10")
                    {
                        DtRAM.Rows[x].SetField(11, "ROM");
                    }
                    else if (SMBIOSMemoryTypeResult == "11")
                    {
                        DtRAM.Rows[x].SetField(11, "Flash");
                    }
                    else if (SMBIOSMemoryTypeResult == "12")
                    {
                        DtRAM.Rows[x].SetField(11, "EEPROM");
                    }
                    else if (SMBIOSMemoryTypeResult == "13")
                    {
                        DtRAM.Rows[x].SetField(11, "FEPROM");
                    }
                    else if (SMBIOSMemoryTypeResult == "14")
                    {
                        DtRAM.Rows[x].SetField(11, "EPROM");
                    }
                    else if (SMBIOSMemoryTypeResult == "15")
                    {
                        DtRAM.Rows[x].SetField(11, "CDRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "16")
                    {
                        DtRAM.Rows[x].SetField(11, "3DRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "17")
                    {
                        DtRAM.Rows[x].SetField(11, "SDRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "18")
                    {
                        DtRAM.Rows[x].SetField(11, "SGRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "19")
                    {
                        DtRAM.Rows[x].SetField(11, "RDRAM");
                    }
                    else if (SMBIOSMemoryTypeResult == "20")
                    {
                        DtRAM.Rows[x].SetField(11, "DDR");
                    }
                    else if (SMBIOSMemoryTypeResult == "21")
                    {
                        DtRAM.Rows[x].SetField(11, "DDR2");
                    }
                    else if (SMBIOSMemoryTypeResult == "22")
                    {
                        DtRAM.Rows[x].SetField(11, "DDR2 FB-DIMM");
                    }
                    else if (SMBIOSMemoryTypeResult == "23")
                    {
                        DtRAM.Rows[x].SetField(11, "Not Listed");
                    }
                    else if (SMBIOSMemoryTypeResult == "24")
                    {
                        DtRAM.Rows[x].SetField(11, "DDR3");
                    }
                    else if (SMBIOSMemoryTypeResult == "25")
                    {
                        DtRAM.Rows[x].SetField(11, "FBD2");
                    }
                    else if (SMBIOSMemoryTypeResult == "26")
                    {
                        DtRAM.Rows[x].SetField(11, "DDR4");
                    }
                    else
                    {
                        DtRAM.Rows[x].SetField(11, "Other");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Something went wrong we can't find any data of RAM !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
