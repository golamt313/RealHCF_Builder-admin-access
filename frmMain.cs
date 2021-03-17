// Decompiled with JetBrains decompiler
// Type: RealHCF_Builder.frmMain
// Assembly: RealHCF Builder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 848789C7-2401-4BD3-A543-CA0682BA649A
// Assembly location: C:\Users\Rasib\Desktop\RealHCF_Builder (admin access).exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RealHCF_Builder
{
  public class frmMain : Form
  {
    private SSToolInfo exeInfo = new SSToolInfo();
    private IContainer components = (IContainer) null;
    private Label lblName;
    private TextBox txtName;
    private Label lblCopyright;
    private TextBox txtCopyright;
    private Label lblExpiry;
    private NumericUpDown nudExpiry;
    private Label lblIcon;
    private Button btnIcon;
    private Label lblLogo;
    private Button btnLogo;
    private PictureBox picLogo;
    private Button btnCompile;
    private Button btnApplications;
    private Label lblApplications;
    private Label lblAbout;

    public frmMain() => this.InitializeComponent();

    private void showError(string msg)
    {
      int num = (int) MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void btnApplications_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Title = "Load Applications zip file.";
      openFileDialog1.Filter = "ZIP Files (*.zip)|*.zip";
      openFileDialog1.CheckFileExists = true;
      using (OpenFileDialog openFileDialog2 = openFileDialog1)
      {
        bool flag = true;
        if (openFileDialog2.ShowDialog() == DialogResult.OK && (flag = openFileDialog2.FileName.EndsWith(".zip")))
          this.exeInfo.ApplicationsPath = openFileDialog2.FileName;
        if (flag)
          return;
        this.showError("Invalid extension");
      }
    }

    private void btnIcon_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Title = "Select application icon.";
      openFileDialog1.Filter = "Icons (*.ico)|*.ico";
      openFileDialog1.CheckFileExists = true;
      using (OpenFileDialog openFileDialog2 = openFileDialog1)
      {
        bool flag = true;
        if (openFileDialog2.ShowDialog() == DialogResult.OK && (flag = openFileDialog2.FileName.EndsWith(".ico")))
          this.exeInfo.IconPath = openFileDialog2.FileName;
        if (flag)
          return;
        this.showError("Invalid extension");
      }
    }

    private void btnLogo_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Title = "Load logo.";
      openFileDialog1.Filter = "PNG Image Files (*.png)|*.png";
      openFileDialog1.CheckFileExists = true;
      using (OpenFileDialog openFileDialog2 = openFileDialog1)
      {
        bool flag = true;
        if (openFileDialog2.ShowDialog() == DialogResult.OK && (flag = openFileDialog2.FileName.EndsWith(".png")))
        {
          this.exeInfo.LogoPath = openFileDialog2.FileName;
          this.picLogo.Image = Image.FromFile(openFileDialog2.FileName);
        }
        if (flag)
          return;
        this.showError("Invalid extension");
      }
    }

    private void btnCompile_Click(object sender, EventArgs e)
    {
      if (this.exeInfo.ApplicationsPath == null)
        this.showError("You must select an icon.");
      else if (this.exeInfo.LogoPath == null)
        this.showError("You must select a logo.");
      else if (this.exeInfo.IconPath == null)
      {
        this.showError("You must select an icon.");
      }
      else
      {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Title = "Choose a path to export the exe file.";
        saveFileDialog1.Filter = "Windows Executable Files (*.exe)|*.exe";
        using (SaveFileDialog saveFileDialog2 = saveFileDialog1)
        {
          if (saveFileDialog2.ShowDialog() != DialogResult.OK)
            return;
          this.exeInfo.Name = this.txtName.Text;
          this.exeInfo.Copyright = this.txtCopyright.Text;
          this.exeInfo.Expiry = (int) this.nudExpiry.Value;
          this.exeInfo.Compile(saveFileDialog2.FileName);
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

    }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnApplications_Click("bob", e);
        }
    }
}
