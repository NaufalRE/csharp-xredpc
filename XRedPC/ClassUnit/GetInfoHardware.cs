using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace XRedPC.ClassUnit
{
    class GetInfoHardware
    {
        DataTable HardwareData;
        
        public String StringGetComponent(string hwClass, string query, string deField)
        {
            String _value = "";
            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM " + hwClass + deField);
                foreach (ManagementObject MO in MOS.Get())
                {
                    _value = (Convert.ToString(MO[query]));
                }
            }
            catch(ManagementException e)
            {
                XtraMessageBox.Show("We couldn't get data from WMI \n Error Code : " + e.Message + "Please make sure WMI Provider Host is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _value;
        }

        public String ArrayStringGetComponent(string hwClass, string query, string deField)
        {
            String _value = "";
            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM " + hwClass + deField);
                String[] arrBIOS;
                foreach (ManagementObject MO in MOS.Get())
                {
                    arrBIOS = (String[])(MO[query]);
                    foreach (string arrValue in arrBIOS)
                    {
                        _value += arrValue + " ";
                    }
                }
            }
            catch (ManagementException e)
            {
                XtraMessageBox.Show("We couldn't get data from WMI \n Error Code : " + e.Message + "Please make sure WMI Provider Host is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
            return _value;
        }

        public String ArrayIntGetComponent(string hwClass, string query, string deField)
        {
            String _value = "";
            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM " + hwClass + deField);
                foreach (ManagementObject MO in MOS.Get())
                {
                    UInt16[] arrBIOS = (UInt16[])(MO[query]);
                    foreach (int arrValue in arrBIOS)
                    {
                        _value += arrValue + " ";
                    }
                }
            }
            catch (ManagementException e)
            {
                XtraMessageBox.Show("We couldn't get data from WMI \n Error Code : " + e.Message + "Please make sure WMI Provider Host is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
            return _value;
        }

        //Indexer
        public DataTable HardwareIndexer(string table, string data)
        {
            HardwareData = new DataTable();
            HardwareData.Clear();
            HardwareData.Rows.Clear();
            HardwareData.Columns.Add("Indexer");
            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM " + table);
                foreach (ManagementObject MO in MOS.Get())
                {
                    HardwareData.Rows.Add(new Object[] { Convert.ToString(MO[data]) });
                }
            }
            catch (ManagementException e)
            {
                XtraMessageBox.Show("We couldn't get data from WMI \n Error Code : " + e.Message + "Please make sure WMI Provider Host is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return HardwareData;
        }
    }
}
