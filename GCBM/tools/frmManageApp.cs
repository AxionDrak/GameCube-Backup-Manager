using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace GCBM.tools
{
    public partial class frmManageApp : Form
    {
        #region Main Form

        public frmManageApp()
        {
            InitializeComponent();
        }

        #endregion

        #region Rename Files

        /// <summary>
        ///     Renomear automaticamente todos os arquivos 'boot.elf' para 'boot.dol'.
        /// </summary>
        /// <param name="folder"></param>
        private void RenameFiles(string folder)
        {
            //var findFolder = Directory.GetDirectories(folder, "*", SearchOption.AllDirectories);
            //var findFiles = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);

            var curFile = Path.DirectorySeparatorChar + "boot.elf";

            foreach (var dir in Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly))
            foreach (var file in Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly))
                if (File.Exists(dir + curFile))
                    try
                    {
                        File.Move(file, file.Replace("boot.elf", "boot.dol"));
                    }
                    catch (FileNotFoundException ex)
                    {
                        GlobalNotifications(ex.Message);
                    }
                else
                    DisplayFilesFolder(folder, dgvAppList);
        }

        #endregion

        #region Compress Folder

        /// <summary>
        ///     Compactar pastas, subpastas e todos os arquivos dentro das pastas.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="dest"></param>
        private void CompressFolder()
        {
            //int? selectedRowCount = Convert.ToInt32(dgvAppList.Rows.GetRowCount(DataGridViewElementStates.Selected));
            var _selectedGameRowCount = dgvAppList.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (dgvAppList.RowCount == 0)
            {
                EmptyAppsList();
            }
            else
            {
                if (_selectedGameRowCount == 0)
                    SelectAppFromList();
                else
                    try
                    {
                        //string checkFile = dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip";
                        var checkFile = dgvAppList.CurrentRow.Cells[0].Value.ToString();
                        var checkDirectory = dgvAppList.CurrentRow.Cells[3].Value.ToString();

                        //if (File.Exists(checkFileExist))
                        //{

                        var frmPackage = new frmCreatePackage(checkFile, checkDirectory, fbd.SelectedPath);
                        frmPackage.ShowDialog();
                        frmPackage.Dispose();

                        //    //MessageBox.Show(dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip" + " Arquivo já existe!");
                        //    //Apagar arquivo compactado se existir!
                        //    //File.Delete(Path.GetDirectoryName(dgvAppList.CurrentRow.Cells[0].Value.ToString()) + ".zip");
                        //    File.Delete(dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip");
                        //    //Compactação correta! - RÁPIDA - MENOR COMPACTAÇÃO
                        //    ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvAppList.CurrentRow.Cells[3].Value.ToString()),
                        //        dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip", CompressionLevel.Fastest, true);
                        //}
                        //else
                        //{
                        //    frmCreatePackage _frmPackage = new frmCreatePackage(dgvAppList);
                        //    _frmPackage.ShowDialog();
                        //    _frmPackage.Dispose();

                        //    //Compactação correta! - RÁPIDA - MENOR COMPACTAÇÃO
                        //    ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvAppList.CurrentRow.Cells[3].Value.ToString()),
                        //        dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip", CompressionLevel.Fastest, true);

                        //    //Compactação correta! - LENTA - MAIOR COMPACTAÇÃO
                        //    //ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvAppList.CurrentRow.Cells[3].Value.ToString()), 
                        //    //    dgvAppList.CurrentRow.Cells[0].Value.ToString() + ".zip", CompressionLevel.Optimal, true);

                        //}
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message);
                    }
            }
        }

        #endregion

        #region DisplayFilesFolder

        private void DisplayFilesFolder(string sourceFolder, DataGridView dgv)
        {
            try
            {
                // Create and load the XmlDocument
                var xmlDoc = new XmlDocument();

                var filtersXML = new[] { "xml" };
                var filtersDOL = new[] { "dol" };

                var isRecursive = true;

                var filesXML = GetFilesXMLFolder(sourceFolder, filtersXML, isRecursive);
                var filesDOL = GetFilesDOLFolder(sourceFolder, filtersDOL, isRecursive);

                // Creates a DataTable with file data.
                var _table = new DataTable();
                _table.Columns.Add("Nome do APP");
                _table.Columns.Add("Versão");
                _table.Columns.Add("Tamanho");
                _table.Columns.Add("Caminho do Arquivo");

                FileInfo _fileXML = null;
                FileInfo _fileDOL = null;

                for (var i = 0; i < filesDOL.Length; i++)
                {
                    _fileXML = new FileInfo(filesXML[i]);
                    _fileDOL = new FileInfo(filesDOL[i]);

                    xmlDoc.Load(_fileXML.FullName);
                    var xnList = xmlDoc.GetElementsByTagName("app");
                    var _getSize = DisplayFormatFileSize(_fileDOL.Length, 1);

                    //Usando foreach para imprimir na tela
                    foreach (XmlNode xn in xnList)
                        _table.Rows.Add(xn["name"].InnerText, xn["version"].InnerText, _getSize, _fileDOL.FullName);
                    //_table.Rows.Add(xn["name"].InnerText, xn["version"].InnerText, _getSize);
                }

                // Displays data in DataGridView.
                dgv.DataSource = _table;
                dgv.RowHeadersVisible = false;
                dgv.ColumnHeadersVisible = true;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                //Checkbox
                //dgv.Columns[0].ReadOnly = true;
                //dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //dgv.Columns[0].Width = 100;
                //Nome do Arquivo
                //dgv.Columns[1].ReadOnly = true;
                dgv.Columns[1].Width = 100;
                //Tipo
                //dgv.Columns[2].ReadOnly = true;
                dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[2].Width = 100;
                //Tamanho
                //dgv.Columns[3].ReadOnly = true;
                //dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //dgv.Columns[3].Width = 70;
                //Caminho do Arquivo
                //dgv.Columns[4].ReadOnly = true;
                //dgv.Columns[4].Width = 100;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message);
            }
        }

        #endregion

        #region DisplayFormatFileSize

        public static string DisplayFormatFileSize(long i, int k)
        {
            // Obtém o valor absoluto
            var i_absolute = i < 0 ? -i : i;
            string suffix;
            double reading;

            if (k == 0)
            {
                if (i_absolute >= 0x1000000000000000) // Exabyte
                {
                    suffix = "EB";
                    reading = i >> 50;
                }
                else if (i_absolute >= 0x4000000000000) // Petabyte
                {
                    suffix = "PB";
                    reading = i >> 40;
                }
                else if (i_absolute >= 0x10000000000) // Terabyte
                {
                    suffix = "TB";
                    reading = i >> 30;
                }
                else if (i_absolute >= 0x40000000) // Gigabyte
                {
                    suffix = "GB";
                    reading = i >> 20;
                }
                else if (i_absolute >= 0x100000) // Megabyte
                {
                    suffix = "MB";
                    reading = i >> 10;
                }
                else if (i_absolute >= 0x400) // Kilobyte
                {
                    suffix = "KB";
                    reading = i;
                }
                else
                {
                    return i.ToString("0 bytes"); // Byte
                }
            }
            else if (k == 1) // Kilobyte
            {
                suffix = "KB";
                reading = i;
            }
            else if (k == 2) // Megabyte
            {
                suffix = "MB";
                reading = i >> 10;
            }
            else if (k == 3) // Gigabyte
            {
                suffix = "GB";
                reading = i >> 20;
            }
            else if (k == 4) // Terabyte
            {
                suffix = "TB";
                reading = i >> 30;
            }
            else
            {
                return i.ToString("0 bytes"); // Byte
            }

            // Divide by 1024 to get the fractional value.
            reading = reading / 1024;
            // Returns the suffix formatted number.
            return reading.ToString("0.## ") + suffix;
        }

        #endregion

        #region GetFilesFolder

        private string[] GetFilesXMLFolder(string rootFolder, string[] filters, bool isRecursive)
        {
            var filesFound = new List<string>();

            try
            {
                var optionSearch = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                foreach (var filter in filters)
                    filesFound.AddRange(Directory.GetFiles(rootFolder, string.Format("meta.{0}", filter),
                        optionSearch));
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message);
            }

            return filesFound.ToArray();
        }

        private string[] GetFilesDOLFolder(string rootFolder, string[] filters, bool isRecursive)
        {
            var filesFound = new List<string>();

            try
            {
                var optionSearch = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                foreach (var filter in filters)
                    filesFound.AddRange(Directory.GetFiles(rootFolder, string.Format("*.{0}", filter), optionSearch));
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message);
            }

            return filesFound.ToArray();
        }

        #endregion

        #region Notifications

        private void GlobalNotifications(string ex)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", ex, ToolTipIcon.Info);
        }

        private static void EmptyAppsList()
        {
            MessageBox.Show("A lista de aplicativos homebrews está vazia!", "Informação", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private static void SelectAppFromList()
        {
            MessageBox.Show("Por favor, selecione um aplicativo homebrew da lista!", "Informação", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private static DialogResult DialogResultDelete()
        {
            var dr = MessageBox.Show("Deseja realmente excluir o aplicativo homebrew?" + Environment.NewLine +
                                     Environment.NewLine +
                                     "Esse procedimento é irreversível e não será possivel recuperar o aplicativo homebrew!",
                "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dr;
        }

        #endregion

        #region Buttons

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnListApp_Click(object sender, EventArgs e)
        {
            try
            {
                fbd.Description = "Selecione a pasta que contém os app's:";
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.OK)
                    //DisplayFilesFolder(fbd.SelectedPath, dgvAppList);
                    RenameFiles(fbd.SelectedPath);
            }
            catch (Exception ex)
            {
                //tbLog.AppendText(">> ERRO: " + ex.Message + Environment.NewLine);
                GlobalNotifications(ex.Message);
            }
        }

        private void btnRemoveApp_Click(object sender, EventArgs e)
        {
            var _selectedGameRowCount = dgvAppList.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (dgvAppList.RowCount == 0)
            {
                EmptyAppsList();
            }
            else
            {
                if (_selectedGameRowCount == 0)
                    SelectAppFromList();
                else if (DialogResultDelete() == DialogResult.Yes)
                    try
                    {
                        //Apagar a pasta e todo conteúdo do app homebrew
                        Directory.Delete(Path.GetDirectoryName(dgvAppList.CurrentRow.Cells[3].Value.ToString()), true);
                        //Recarregar o datagridview
                        DisplayFilesFolder(fbd.SelectedPath, dgvAppList);
                        notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "Aplicativo removido com sucesso!",
                            ToolTipIcon.Info);
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message);
                    }
            }
        }

        private void btnPackageApp_Click(object sender, EventArgs e)
        {
            CompressFolder();
        }

        private void btnInstallApp_Click(object sender, EventArgs e)
        {
            //frmInstallApp _frmInstall = new frmInstallApp();
            //_frmInstall.ShowDialog();
            //_frmInstall.Dispose();
        }

        #endregion
    }
}