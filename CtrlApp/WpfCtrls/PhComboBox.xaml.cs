using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para PhComboBox.xaml
    /// </summary>
    public partial class PhComboBox : ComboBox, INotifyPropertyChanged
    {
        private Visibility mPnOn;

        public PhComboBox()
        {
            InitializeComponent();

            this.DefaultStyleKey = typeof(PhComboBox);
            this.SelectionChanged += PhOnSelectionChanged;
        }

        #region EVENTOS

        private void PART_EditableTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ph = sender as TextBox;
            if (string.IsNullOrEmpty(ph.Text))
            {
                PHOn = Visibility.Visible;
            }
            else
            {
                PHOn = Visibility.Hidden;
            }
        }

        private void PhOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectedIndex == -1)
            {
                PHOn = Visibility.Visible;
            }
            else
            {
                PHOn = Visibility.Hidden;
            }
        }

        #endregion EVENTOS

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(PhComboBox), new PropertyMetadata(null));

        public double ImgAncho
        {
            get => (double)GetValue(ImgAnchoProperty);
            set => SetValue(ImgAnchoProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoProperty = DependencyProperty.Register("ImgAncho", typeof(double), typeof(PhComboBox), new PropertyMetadata((double)0));

        public double ImgAlto
        {
            get => (double)GetValue(ImgAltoProperty);
            set => SetValue(ImgAltoProperty, value);
        }

        public static readonly DependencyProperty ImgAltoProperty = DependencyProperty.Register("ImgAlto", typeof(double), typeof(PhComboBox), new PropertyMetadata((double)0));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(PhComboBox), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargen
        {
            get => (Thickness)GetValue(ImgMargenProperty);
            set => SetValue(ImgMargenProperty, value);
        }

        public static readonly DependencyProperty ImgMargenProperty = DependencyProperty.Register("ImgMargen", typeof(Thickness), typeof(PhComboBox), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES PH FUENTE

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PhComboBox), new PropertyMetadata("PhComboBox1"));

        public Brush PHForeground
        {
            get => (Brush)GetValue(PHForegroundProperty);
            set => SetValue(PHForegroundProperty, value);
        }

        public static readonly DependencyProperty PHForegroundProperty = DependencyProperty.Register("PHForeground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#7C8591")));

        public FontStyle PHFontStyle
        {
            get => (FontStyle)GetValue(PHFontStyleProperty);
            set => SetValue(PHFontStyleProperty, value);
        }

        public static readonly DependencyProperty PHFontStyleProperty = DependencyProperty.Register("PHFontStyle", typeof(FontStyle), typeof(PhComboBox), new PropertyMetadata(FontStyles.Italic));

        public double PHFontSize
        {
            get => (double)GetValue(PHFontSizeProperty);
            set => SetValue(PHFontSizeProperty, value);
        }

        public static readonly DependencyProperty PHFontSizeProperty = DependencyProperty.Register("PHFontSize", typeof(double), typeof(PhComboBox), new PropertyMetadata((double)12));

        public FontFamily PHFontFamily
        {
            get => (FontFamily)GetValue(PHFontFamilyProperty);
            set => SetValue(PHFontFamilyProperty, value);
        }

        public static readonly DependencyProperty PHFontFamilyProperty = DependencyProperty.Register("PHFontFamily", typeof(FontFamily), typeof(PhComboBox), new PropertyMetadata(null));

        public FontStretch PHFontStretch
        {
            get => (FontStretch)GetValue(PHFontStretchProperty);
            set => SetValue(PHFontStretchProperty, value);
        }

        public static readonly DependencyProperty PHFontStretchProperty = DependencyProperty.Register("PHFontStretch", typeof(FontStretch), typeof(PhComboBox), new PropertyMetadata(FontStretches.Normal));

        public FontWeight PHFontWeight
        {
            get => (FontWeight)GetValue(PHFontWeightProperty);
            set => SetValue(PHFontWeightProperty, value);
        }

        public static readonly DependencyProperty PHFontWeightProperty = DependencyProperty.Register("PHFontWeight", typeof(FontWeight), typeof(PhComboBox), new PropertyMetadata(FontWeights.Normal));

        #endregion PROPIEDADES PH FUENTE

        #region PROPIEDADES PH PRENSENTACION

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PhComboBox), new PropertyMetadata(null));

        public VerticalAlignment PHVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(PHVerticalAlignmentlProperty);
            set => SetValue(PHVerticalAlignmentlProperty, value);
        }

        public static readonly DependencyProperty PHVerticalAlignmentlProperty = DependencyProperty.Register("PHVerticalAlignment", typeof(VerticalAlignment), typeof(PhComboBox), new PropertyMetadata(VerticalAlignment.Top));

        public HorizontalAlignment PHHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(PHHorizontalAlignmentProperty);
            set => SetValue(PHHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty PHHorizontalAlignmentProperty = DependencyProperty.Register("PHHorizontalAlignment", typeof(HorizontalAlignment), typeof(PhComboBox), new PropertyMetadata(HorizontalAlignment.Left));

        public Thickness PHPadding
        {
            get => (Thickness)GetValue(PHPaddingProperty);
            set => SetValue(PHPaddingProperty, value);
        }

        public static readonly DependencyProperty PHPaddingProperty = DependencyProperty.Register("PHPadding", typeof(Thickness), typeof(PhComboBox), new PropertyMetadata((Thickness)new(1, 0, 0, 0)));

        public Visibility PHOn
        {
            get => mPnOn;

            set
            {
                mPnOn = value;
                OnPropertyChanged(nameof(PHOn));
            }
        }

        #endregion PROPIEDADES PH PRENSENTACION

        #region PROPIEADES DE VISUALISACION

        public Brush KeyboardFocusedBorderBrush
        {
            get => (Brush)GetValue(KeyboardFocusedBorderBrushProperty);

            set
            {
                SetValue(KeyboardFocusedBorderBrushProperty, value);
                OnPropertyChanged(nameof(KeyboardFocusedBorderBrush));
            }
        }

        public static readonly DependencyProperty KeyboardFocusedBorderBrushProperty = DependencyProperty.Register("KeyboardFocusedBorderBrush", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(null));

        public Thickness KeyboardFocusedBorderThickness
        {
            get => (Thickness)GetValue(KeyboardFocusedBorderThicknessProperty);
            set => SetValue(KeyboardFocusedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty KeyboardFocusedBorderThicknessProperty =
        DependencyProperty.Register("KeyboardFocusedBorderThickness", typeof(Thickness), typeof(PhComboBox), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        public Brush DisabledBackground
        {
            get => (Brush)GetValue(DisabledBackgroundProperty);
            set => SetValue(DisabledBackgroundProperty, value);
        }

        public static readonly DependencyProperty DisabledBackgroundProperty =
        DependencyProperty.Register("DisabledBackground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#FFF0F0F0")));

        #endregion PROPIEADES DE VISUALISACION

        #region MOUSE OVER

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(Brushes.White));

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set => SetValue(MouseOverForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#000000")));

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        public double MouseOverFontSize
        {
            get => (double)GetValue(MouseOverFontSizeProperty);
            set => SetValue(MouseOverFontSizeProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontSizeProperty = DependencyProperty.Register("MouseOverFontSize", typeof(double), typeof(PhComboBox), new PropertyMetadata((double)10));

        public FontWeight MouseOverFontWeight
        {
            get => (FontWeight)GetValue(MouseOverFontWeightProperty);
            set => SetValue(MouseOverFontWeightProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontWeightProperty = DependencyProperty.Register("MouseOverFontWeight", typeof(FontWeight), typeof(PhComboBox), new PropertyMetadata(FontWeights.Medium));

        public FontStyle MouseOverFontStyle
        {
            get => (FontStyle)GetValue(MouseOverFontStyleProperty);
            set => SetValue(MouseOverFontStyleProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontStyleProperty = DependencyProperty.Register("MouseOverFontStyle", typeof(FontStyle), typeof(PhComboBox), new PropertyMetadata(FontStyles.Italic));

        public Thickness MouseOverBorderThickness
        {
            get => (Thickness)GetValue(MouseOverBorderThicknessProperty);
            set => SetValue(MouseOverBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderThicknessProperty = DependencyProperty.Register("MouseOverBorderThickness", typeof(Thickness), typeof(OptButton), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        #endregion MOUSE OVER

        #region MOUSE PRESSED

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PressedBorderThicknessProperty = DependencyProperty.Register("PressedBorderThickness", typeof(Thickness), typeof(PhComboBox), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        #endregion MOUSE PRESSED

        #region MOUSE CHECKED

        public Brush CheckedBackground
        {
            get => (Brush)GetValue(CheckedBackgroundProperty);
            set => SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty = DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush CheckedBorderBrush
        {
            get => (Brush)GetValue(CheckedBorderBrushProperty);
            set => SetValue(CheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty = DependencyProperty.Register("CheckedBorderBrush", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness CheckedBorderThickness
        {
            get => (Thickness)GetValue(CheckedBorderThicknessProperty);
            set => SetValue(CheckedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderThicknessProperty = DependencyProperty.Register("CheckedBorderThickness", typeof(Thickness), typeof(PhComboBox), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        public Brush CheckedForeground
        {
            get => (Brush)GetValue(CheckedForegroundProperty);
            set => SetValue(CheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty CheckedForegroundProperty = DependencyProperty.Register("CheckedForeground", typeof(Brush), typeof(PhComboBox), new PropertyMetadata(ColorTool.ColorHxa("#000000")));

        #endregion MOUSE CHECKED

        #region PROPERTYCHANGED

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PROPERTYCHANGED

        private void imgL_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            Image img = sender as Image;

            ImgAlto = img.Height;
            ImgAncho = img.Width;

        }
    }
}