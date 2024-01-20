using Microsoft.Win32;
using Sgcm.App.DTOs.AuxiliaryDto;
using Sgcm.UI.Desktop.VistaModelo;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCtrls;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para PersonEditView.xaml
    /// </summary>
    public partial class PersonEditView : Window
    {
        private PersonEditVM _vm;

        public PersonEditView(EditUIModeEnum editUIMode = EditUIModeEnum.Paciente)
        {
            InitializeComponent();
            _vm = new PersonEditVM(editUIMode);
            this.DataContext = _vm;
            cboDepartamento.SelectionChanged += cboDpto_SelectionChanged;
            cboProvincia.SelectionChanged += cboProv_SelectionChanged;
            cboTipoDoc.Focus();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btiPassCancel_Click(object sender, RoutedEventArgs e) => this.Close();

        private void cboTipoDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var td = (DocumentTypeDto)cboTipoDoc.SelectedItem;
            if (td == null)
            {
                return;
            }
            txtDni.Text = "";
            txtDni.ImgSourceLeft = ImageTool.LoadImageSource(td.Tdoc_icon);
            txtDni.ToolTip = td.Tdoc_name;
            txtDni.Focus();
        }

        private void pboNetType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhComboBox? pboNetType = sender as PhComboBox;
            var tn = (NetTypesDto)pboNetType.SelectedItem;
            if (tn == null) return;
            pboNetType.ImgSource = ImageTool.LoadImageSource(tn.Nett_ico);
        }

        private async void cboDpto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbo = (DptoDto)cboDepartamento.SelectedItem;
            if (cbo == null)
            {
                cboProvincia.ItemsSource = null;
                return;
            }
            var provById = await _vm.AuxiliaryData.GetProvinciasByDptoId(cbo.UbDep_id);
            cboProvincia.ItemsSource = provById;
            cboProvincia.SelectedValue = _vm.PersonData.Per_UbProvId;
        }

        private async void cboProv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbo = (ProvinciaDto)cboProvincia.SelectedItem;
            if (cbo == null)
            {
                cboDistrito.ItemsSource = null;
                return;
            }
            var distById = await _vm.AuxiliaryData.GetUbigeoByProvId(cbo.UbProv_id);
            cboDistrito.ItemsSource = distById;
            cboDistrito.SelectedValue = _vm.PersonData.Per_UbdisId;
        }

        private void btiSalir_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btiSearchPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archivos de imagenes | *.*";
            bool? success = fileDialog.ShowDialog();
            if (success == true)
                DocFoto.Fill = ImageTool.LoadImageBrush(fileDialog.FileName);
        }
    }
}