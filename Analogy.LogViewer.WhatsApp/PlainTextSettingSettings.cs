using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.WhatsApp.Managers;
using Newtonsoft.Json;

namespace Analogy.LogViewer.WhatsApp
{
    public partial class PlainTextSettingSettings : UserControl
    {
        public PlainTextSettingSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMapping();
        }
        private void SaveMapping()
        {

        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "Analogy Plain Text Settings (*.AnalogyPlainTextSettings)|*.AnalogyPlainTextSettings";
            //    saveFileDialog.Title = @"Export NLog settings";

            //    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //    {
            //        SaveMapping();
            //        try
            //        {
            //            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(LogParsersSettings));
            //            MessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);

            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }

            //    }
        }

        private void btnLoadLayout_Click(object sender, EventArgs e)
        {
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Analogy plain Text Settings (*.AnalogyPlainTextSettings)|*.AnalogyPlainTextSettings";
            openFileDialog1.Title = @"Import plain Text settings";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog1.FileName);
                    LogParserSettings nlog = JsonConvert.DeserializeObject<LogParserSettings>(json);
                    MessageBox.Show("File Imported. Save settings if desired", @"Import settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtbNLogDirectory.Text = fbd.SelectedPath;

                }
            }
        }

        private void NLogSettings_Load(object sender, EventArgs e)
        {
        }
    }
}
