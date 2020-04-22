namespace HomeOfficerService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this._homeOfficerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // _serviceProcessInstaller
            // 
            this._serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this._serviceProcessInstaller.Password = null;
            this._serviceProcessInstaller.Username = null;
            this._serviceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this._serviceProcessInstaller_AfterInstall);
            // 
            // _homeOfficerServiceInstaller
            // 
            this._homeOfficerServiceInstaller.DisplayName = "HomeOfficer";
            this._homeOfficerServiceInstaller.ServiceName = "HomeOfficerService";
            this._homeOfficerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this._homeOfficerServiceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this._homeOfficerServiceInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this._serviceProcessInstaller,
            this._homeOfficerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller _serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller _homeOfficerServiceInstaller;
    }
}