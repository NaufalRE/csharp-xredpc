namespace XRedPC
{
    partial class ParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::XRedPC.SystemForm.SplashLoad), true, true);
            this.container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceOverview = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceOS = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceMotherboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceCPU = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceRAM = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceGraphics = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceStorage = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceNetwork = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSystem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceAbout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 100;
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(260, 30);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(540, 570);
            this.container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceMenu,
            this.aceSystem});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 570);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // aceMenu
            // 
            this.aceMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceOverview,
            this.aceOS,
            this.aceMotherboard,
            this.aceCPU,
            this.aceRAM,
            this.aceGraphics,
            this.aceStorage,
            this.aceNetwork});
            this.aceMenu.Expanded = true;
            this.aceMenu.Name = "aceMenu";
            this.aceMenu.Text = "Menu";
            // 
            // aceOverview
            // 
            this.aceOverview.Name = "aceOverview";
            this.aceOverview.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceOverview.Text = "Overview";
            this.aceOverview.Click += new System.EventHandler(this.aceOverview_Click);
            // 
            // aceOS
            // 
            this.aceOS.Name = "aceOS";
            this.aceOS.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceOS.Text = "Operating System";
            this.aceOS.Click += new System.EventHandler(this.aceOS_Click);
            // 
            // aceMotherboard
            // 
            this.aceMotherboard.Name = "aceMotherboard";
            this.aceMotherboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceMotherboard.Text = "Motherboard";
            this.aceMotherboard.Click += new System.EventHandler(this.aceMotherboard_Click);
            // 
            // aceCPU
            // 
            this.aceCPU.Name = "aceCPU";
            this.aceCPU.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceCPU.Text = "CPU";
            this.aceCPU.Click += new System.EventHandler(this.aceCPU_Click);
            // 
            // aceRAM
            // 
            this.aceRAM.Name = "aceRAM";
            this.aceRAM.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceRAM.Text = "RAM";
            this.aceRAM.Click += new System.EventHandler(this.aceRAM_Click);
            // 
            // aceGraphics
            // 
            this.aceGraphics.Name = "aceGraphics";
            this.aceGraphics.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceGraphics.Text = "Graphics";
            this.aceGraphics.Click += new System.EventHandler(this.aceGraphics_Click);
            // 
            // aceStorage
            // 
            this.aceStorage.Name = "aceStorage";
            this.aceStorage.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceStorage.Text = "Storage";
            // 
            // aceNetwork
            // 
            this.aceNetwork.Name = "aceNetwork";
            this.aceNetwork.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceNetwork.Text = "Network";
            // 
            // aceSystem
            // 
            this.aceSystem.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceAbout});
            this.aceSystem.Expanded = true;
            this.aceSystem.Name = "aceSystem";
            this.aceSystem.Text = "System";
            // 
            // aceAbout
            // 
            this.aceAbout.Name = "aceAbout";
            this.aceAbout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceAbout.Text = "About";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(800, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlContainer = this.container;
            this.Controls.Add(this.container);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "ParentForm";
            this.NavigationControl = this.accordionControl1;
            this.Text = "X Red PC";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.ParentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceMenu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceOverview;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceOS;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceMotherboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceCPU;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceRAM;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceGraphics;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceStorage;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceNetwork;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceSystem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAbout;
    }
}