using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_AppDomain_Additional
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseAssemblyBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Executables (*.exe) |*.exe";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    assemblyPathBox.Text = dialog.FileName;
                }
            }
            launchBtn.Enabled = true;
        }

        private void launchBtn_Click(object sender, EventArgs e)
        {
            string targetExe = assemblyPathBox.Text;

            if (string.IsNullOrEmpty(targetExe) || !File.Exists(targetExe))
            {
                MessageBox.Show("This file doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PermissionSet permissions = new PermissionSet(PermissionState.None);
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));


            if (checkGuiPermission.Checked)
            {
                permissions.AddPermission(new UIPermission(UIPermissionWindow.AllWindows));
            }

            if (checkFileRW.Checked)
            {
                permissions.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
            }

            if (checkNetworkAccess.Checked)
            {
                permissions.AddPermission(new WebPermission(PermissionState.Unrestricted));
            }

            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = Path.GetDirectoryName(targetExe);

            AppDomain sandboxDomain = AppDomain.CreateDomain(
                Path.GetFileName(targetExe),
                null,
                setup,
                permissions,
                null
            );

            try
            {
                MessageBox.Show($"Executing assembly {Path.GetFileName(targetExe)} in new domain...", "Sandbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sandboxDomain.ExecuteAssembly(targetExe);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AppDomain.Unload(sandboxDomain);
            }
        }
    }
}
