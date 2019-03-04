using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XRedPC.MenuForm;
using XRedPC.SystemForm;
using System.Management;
using XRedPC.ClassUnit;
using System.Threading;

namespace XRedPC
{
    public partial class ParentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        DataAdapter DaWare = new DataAdapter();
        public ParentForm()
        {
            InitializeComponent();
        }

        private void OpenWelcomeView()
        {
            container.Controls.Add(ucWelcome.Instance);
            ucWelcome.Instance.Dock = DockStyle.Fill;
            ucWelcome.Instance.BringToFront();
        }

        private void OpenOverView()
        {
            container.Controls.Add(ucOverview.Instance);
            ucOverview.Instance.Dock = DockStyle.Fill;
            ucOverview.Instance.BringToFront();
        }

        private void OpenOSView()
        {
            container.Controls.Add(ucOperatingSystem.Instance);
            ucOperatingSystem.Instance.Dock = DockStyle.Fill;
            ucOperatingSystem.Instance.BringToFront();
        }

        private void OpenMotherboardView()
        {
            container.Controls.Add(ucMotherboard.Instance);
            ucMotherboard.Instance.Dock = DockStyle.Fill;
            ucMotherboard.Instance.BringToFront();
        }

        private void OpenProcessorView()
        {
            container.Controls.Add(ucProcessor.Instance);
            ucProcessor.Instance.Dock = DockStyle.Fill;
            ucProcessor.Instance.BringToFront();
        }

        private void OpenRAMView()
        {
            container.Controls.Add(ucRAM.Instance);
            ucRAM.Instance.Dock = DockStyle.Fill;
            ucRAM.Instance.BringToFront();
        }

        private void OpenGraohicsView()
        {
            container.Controls.Add(ucGraphics.Instance);
            ucGraphics.Instance.Dock = DockStyle.Fill;
            ucGraphics.Instance.BringToFront();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            for(int x = 0; x < 100; x++)
            {
                Thread.Sleep(100);
            }
            
            //Call here !
            DaWare.TableMotherboard();
            DaWare.InsertDataMotherboard();
            DaWare.TableBIOS();
            DaWare.InsertDataBIOS();

            DaWare.TableProcessor();
            DaWare.InsertDataProcessor();

            DaWare.TableRAM();
            DaWare.InsertDataRAM();

            DaWare.TableGraphics();
            DaWare.InsertDataGraphics();

            aceMenu.Expanded = false;
            aceSystem.Expanded = false;
            if (!container.Controls.Contains(ucWelcome.Instance))
            {
                OpenWelcomeView();
            }
            ucWelcome.Instance.BringToFront();
        }

        private void aceOverview_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucOverview.Instance))
            {
                OpenOverView();
            }
            ucOverview.Instance.BringToFront();
        }

        private void aceOS_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucOperatingSystem.Instance))
            {
                OpenOSView();
            }
            ucOperatingSystem.Instance.BringToFront();
        }

        private void aceMotherboard_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucMotherboard.Instance))
            {
                OpenMotherboardView();
            }
            ucMotherboard.Instance.BringToFront();
        }

        private void aceCPU_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucProcessor.Instance))
            {
                OpenProcessorView();
            }
            ucProcessor.Instance.BringToFront();
        }

        private void aceRAM_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucRAM.Instance))
            {
                OpenRAMView();
            }
            ucRAM.Instance.BringToFront();
        }

        private void aceGraphics_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucGraphics.Instance))
            {
                OpenGraohicsView();
            }
            ucGraphics.Instance.BringToFront();
        }
    }
}