using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using earCompressManager;
using earCompressManager.Util;
using Microsoft.Win32;
using WPFFolderBrowser;

namespace earCompressWPF {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
                
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtRutaDestino.Text = path;
        }

        private void StatusSet(string Msg = "") {
            stText.Text = Msg;
        }

        private void CmdAbrirArchivo_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private async void CmdAbrirArchivo_Executed(object sender, ExecutedRoutedEventArgs e) {
            await AbrirArchivo();
        }

        private void CmdSeleccionarCarpetaDestino_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void CmdSeleccionarCarpetaDestino_Executed(object sender, ExecutedRoutedEventArgs e) {
            SeleccionarCarpetaDestino();
        }

        private void CmdExtraerSeleccionados_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if(lstListadeArchivos == null) { return; }
            e.CanExecute = lstListadeArchivos.SelectedItems.Count > 0;
        }

        private void CmdExtraerSeleccionados_Executed(object sender, ExecutedRoutedEventArgs e) {
            ExtraerSeleccionados();
        }

        private void CmdExtraerTodos_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (lstListadeArchivos == null) { return; }
            e.CanExecute = lstListadeArchivos.Items.Count > 0;
        }

        private void CmdExtraerTodos_Executed(object sender, ExecutedRoutedEventArgs e) {
            ExtraerTodos();
        }

        private async Task AbrirArchivo() {
            OpenFileDialog lxOFDlg = new OpenFileDialog();

            lxOFDlg.InitialDirectory = "C:\\";
            lxOFDlg.Filter = "Todos (*.*)|*.*|Archivos rar (*.rar)|*.rar|Archivos zip (*.zip)|*.zip|Archivos 7zip (*.7z)|*.7z";

            if (lxOFDlg.ShowDialog() == true) {
                lstListadeArchivos.DataContext = null;

                txtNombreArchivo.Text = lxOFDlg.FileName;

                var lxExt = txtNombreArchivo.Text.GetFileExtension();

                switch (lxExt) {
                    case ".7z":
                    case ".cbr":
                    case ".cbz":
                    case ".rar":
                    case ".tar":
                    case ".zip":
                        StatusSet($"Abriendo {txtNombreArchivo.Text}...");
                        var lst = await Compress.GetListFiles(txtNombreArchivo.Text);
                        lstListadeArchivos.DataContext = lst;
                        break;
                    default:
                        break;
                }
            }
            StatusSet();
        }

        private void SeleccionarCarpetaDestino() {
            WPFFolderBrowserDialog fd = new WPFFolderBrowserDialog {
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                Title = "Seleccionar carpeta destino",
                ShowPlacesList = true
            };

            if (fd.ShowDialog() == true) {
                txtRutaDestino.Text = fd.FileName;
            }
        }

        private void ExtraerSeleccionados() {

            StatusSet("Extrayendo...");
            List<string> lst = new List<string>();
            foreach (InfoArchivo lxItm in lstListadeArchivos.SelectedItems) {
                lst.Add(lxItm.Nombre);
            }

            Compress.ExtraerArchivosSeleccionados(txtNombreArchivo.Text, txtRutaDestino.Text, lst);
            StatusSet();
        }

        private void ExtraerTodos() {
            StatusSet("Extrayendo...");
            Compress.ExtraerTodo(txtNombreArchivo.Text, txtRutaDestino.Text);
            StatusSet();
        }
    }
}
