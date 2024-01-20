using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para PhTextBox2.xaml
    /// </summary>
    public partial class PhTextBox : TextBox, INotifyPropertyChanged
    {
        private Visibility mPnOn;

        public PhTextBox()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(PhTextBox);
            this.TextChanged += OnPhTextChanged;
        }

        #region EVENTOS

        private void OnPhTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                PHOn = Visibility.Visible;
            }
            else
            {
                PHOn = Visibility.Hidden;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion EVENTOS

        #region PROPIEDADES IMAGEN RIGHT

        public ImageSource ImgSourceRight
        {
            get => (ImageSource)GetValue(ImgSourceRightProperty);
            set => SetValue(ImgSourceRightProperty, value);
        }

        public static readonly DependencyProperty ImgSourceRightProperty = DependencyProperty.Register("ImgSourceRight", typeof(ImageSource), typeof(PhTextBox), new PropertyMetadata(null));

        public double ImgAnchoRight
        {
            get => (double)GetValue(ImgAnchoRightProperty);
            set => SetValue(ImgAnchoRightProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoRightProperty = DependencyProperty.Register("ImgAnchoRight", typeof(double), typeof(PhTextBox), new PropertyMetadata((double)0));

        public double ImgAltoRight
        {
            get => (double)GetValue(ImgAltoRightProperty);
            set => SetValue(ImgAltoRightProperty, value);
        }

        public static readonly DependencyProperty ImgAltoRightProperty = DependencyProperty.Register("ImgAltoRight", typeof(double), typeof(PhTextBox), new PropertyMetadata((double)0));

        public Stretch ImgStretchRight
        {
            get => (Stretch)GetValue(ImgStretchRightProperty);
            set => SetValue(ImgStretchRightProperty, value);
        }

        public static readonly DependencyProperty ImgStretchRightProperty = DependencyProperty.Register("ImgStretchRight", typeof(Stretch), typeof(PhTextBox), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargenRight
        {
            get => (Thickness)GetValue(ImgMargenRightProperty);
            set => SetValue(ImgMargenRightProperty, value);
        }

        public static readonly DependencyProperty ImgMargenRightProperty =
        DependencyProperty.Register("ImgMargenRight", typeof(Thickness), typeof(PhTextBox), new PropertyMetadata((Thickness)new(0, 0, 0, 0)));

        public VerticalAlignment ImgVerticalAlignmentRight
        {
            get => (VerticalAlignment)GetValue(ImgVerticalAlignmentRightProperty);
            set => SetValue(ImgVerticalAlignmentRightProperty, value);
        }

        public static readonly DependencyProperty ImgVerticalAlignmentRightProperty =
        DependencyProperty.Register("ImgVerticalAlignmentRight", typeof(VerticalAlignment), typeof(PhTextBox), new PropertyMetadata(VerticalAlignment.Top));

        public HorizontalAlignment ImgHorizontalAlignmentRight
        {
            get => (HorizontalAlignment)GetValue(ImgHorizontalAlignmentRightProperty);
            set => SetValue(ImgHorizontalAlignmentRightProperty, value);
        }

        public static readonly DependencyProperty ImgHorizontalAlignmentRightProperty =
        DependencyProperty.Register("ImgHorizontalAlignmentRight", typeof(HorizontalAlignment), typeof(PhTextBox), new PropertyMetadata(HorizontalAlignment.Right));

        #endregion PROPIEDADES IMAGEN RIGHT

        #region PROPIEDADES IMAGEN LEFT

        public ImageSource ImgSourceLeft
        {
            get => (ImageSource)GetValue(ImgSourceLeftProperty);
            set => SetValue(ImgSourceLeftProperty, value);
        }

        public static readonly DependencyProperty ImgSourceLeftProperty = DependencyProperty.Register("ImgSourceLeft", typeof(ImageSource), typeof(PhTextBox), new PropertyMetadata(null));

        public double ImgAnchoLeft
        {
            get => (double)GetValue(ImgAnchoLeftProperty);
            set => SetValue(ImgAnchoLeftProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoLeftProperty = DependencyProperty.Register("ImgAnchoLeft", typeof(double), typeof(PhTextBox), new PropertyMetadata((double)0));

        public double ImgAltoLeft
        {
            get => (double)GetValue(ImgAltoLeftProperty);
            set => SetValue(ImgAltoLeftProperty, value);
        }

        public static readonly DependencyProperty ImgAltoLeftProperty = DependencyProperty.Register("ImgAltoLeft", typeof(double), typeof(PhTextBox), new PropertyMetadata((double)0));

        public Stretch ImgStretchLeft
        {
            get => (Stretch)GetValue(ImgStretchLeftProperty);
            set => SetValue(ImgStretchLeftProperty, value);
        }

        public static readonly DependencyProperty ImgStretchLeftProperty = DependencyProperty.Register("ImgStretchLeft", typeof(Stretch), typeof(PhTextBox), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargenLeft
        {
            get => (Thickness)GetValue(ImgMargenLeftProperty);
            set => SetValue(ImgMargenLeftProperty, value);
        }

        public static readonly DependencyProperty ImgMargenLeftProperty = DependencyProperty.Register("ImgMargenLeft", typeof(Thickness), typeof(PhTextBox), new PropertyMetadata((Thickness)new(0, 0, 0, 0)));

        public VerticalAlignment ImgVerticalAlignmentLeft
        {
            get => (VerticalAlignment)GetValue(ImgVerticalAlignmentLeftProperty);
            set => SetValue(ImgVerticalAlignmentLeftProperty, value);
        }

        public static readonly DependencyProperty ImgVerticalAlignmentLeftProperty =
        DependencyProperty.Register("ImgVerticalAlignmentLeft", typeof(VerticalAlignment), typeof(PhTextBox), new PropertyMetadata(VerticalAlignment.Top));

        public HorizontalAlignment ImgHorizontalAlignmentLeft
        {
            get => (HorizontalAlignment)GetValue(ImgHorizontalAlignmentLeftProperty);
            set => SetValue(ImgHorizontalAlignmentLeftProperty, value);
        }

        public static readonly DependencyProperty ImgHorizontalAlignmentLeftProperty =
        DependencyProperty.Register("ImgHorizontalAlignmentLeft", typeof(HorizontalAlignment), typeof(PhTextBox), new PropertyMetadata(HorizontalAlignment.Left));

        #endregion PROPIEDADES IMAGEN LEFT

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PhTextBox), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region PROPIEDADES PANEL

        public Orientation Orientacion
        {
            get => (Orientation)GetValue(OrientacionProperty);
            set => SetValue(OrientacionProperty, value);
        }

        public static readonly DependencyProperty OrientacionProperty = DependencyProperty.Register("Orientacion", typeof(Orientation), typeof(PhTextBox), new PropertyMetadata(Orientation.Horizontal));

        #endregion PROPIEDADES PANEL

        #region PROPIEDADES PH FUENTE

        public Brush PHForeground
        {
            get => (Brush)GetValue(PHForegroundProperty);
            set => SetValue(PHForegroundProperty, value);
        }

        public static readonly DependencyProperty PHForegroundProperty = DependencyProperty.Register("PHForeground", typeof(Brush), typeof(PhTextBox), new PropertyMetadata(ColorTool.ColorHxa("#7C8591")));

        public FontStyle PHFontStyle
        {
            get => (FontStyle)GetValue(PHFontStyleProperty);
            set => SetValue(PHFontStyleProperty, value);
        }

        public static readonly DependencyProperty PHFontStyleProperty = DependencyProperty.Register("PHFontStyle", typeof(FontStyle), typeof(PhTextBox), new PropertyMetadata(FontStyles.Oblique));

        public double PHFontSize
        {
            get => (double)GetValue(PHFontSizeProperty);
            set => SetValue(PHFontSizeProperty, value);
        }

        public static readonly DependencyProperty PHFontSizeProperty = DependencyProperty.Register("PHFontSize", typeof(double), typeof(PhTextBox), new PropertyMetadata((double)12));

        public FontFamily PHFontFamily
        {
            get => (FontFamily)GetValue(PHFontFamilyProperty);
            set => SetValue(PHFontFamilyProperty, value);
        }

        public static readonly DependencyProperty PHFontFamilyProperty = DependencyProperty.Register("PHFontFamily", typeof(FontFamily), typeof(PhTextBox), new PropertyMetadata(null));

        public FontStretch PHFontStretch
        {
            get => (FontStretch)GetValue(PHFontStretchProperty);
            set => SetValue(PHFontStretchProperty, value);
        }

        public static readonly DependencyProperty PHFontStretchProperty = DependencyProperty.Register("PHFontStretch", typeof(FontStretch), typeof(PhTextBox), new PropertyMetadata(FontStretches.Normal));

        public FontWeight PHFontWeight
        {
            get => (FontWeight)GetValue(PHFontWeightProperty);

            set => SetValue(PHFontWeightProperty, value);
        }

        public static readonly DependencyProperty PHFontWeightProperty = DependencyProperty.Register("PHFontWeight", typeof(FontWeight), typeof(PhTextBox), new PropertyMetadata(FontWeights.Normal));

        #endregion PROPIEDADES PH FUENTE

        #region PROPIEDADES PH PRENSENTACION

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set
            {
                SetValue(PlaceholderTextProperty, value);
                PHOn = Visibility.Visible;
            }
        }

        public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PhTextBox), new PropertyMetadata("PhTextBox1"));

        public VerticalAlignment PHVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(PHVerticalAlignmentlProperty);
            set => SetValue(PHVerticalAlignmentlProperty, value);
        }

        public static readonly DependencyProperty PHVerticalAlignmentlProperty =
        DependencyProperty.Register("PHVerticalAlignment", typeof(VerticalAlignment), typeof(PhTextBox), new PropertyMetadata(VerticalAlignment.Stretch));

        public HorizontalAlignment PHHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(PHHorizontalAlignmentProperty);
            set => SetValue(PHHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty PHHorizontalAlignmentProperty =
        DependencyProperty.Register("PHHorizontalAlignment", typeof(HorizontalAlignment), typeof(PhTextBox), new PropertyMetadata(HorizontalAlignment.Stretch));

        public Thickness PHPadding
        {
            get => (Thickness)GetValue(PHPaddingProperty);
            set => SetValue(PHPaddingProperty, value);
        }

        public static readonly DependencyProperty PHPaddingProperty =
        DependencyProperty.Register("PHPadding", typeof(Thickness), typeof(PhTextBox), new PropertyMetadata((Thickness)new(5, 0, 0, 0)));

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

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
        DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(PhTextBox), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        public Brush KeyboardFocusedBorderBrush
        {
            get => (Brush)GetValue(KeyboardFocusedBorderBrushProperty);
            set => SetValue(KeyboardFocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty KeyboardFocusedBorderBrushProperty =
        DependencyProperty.Register("KeyboardFocusedBorderBrush", typeof(Brush), typeof(PhTextBox), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        public Thickness KeyboardFocusedBorderThickness
        {
            get => (Thickness)GetValue(KeyboardFocusedBorderThicknessProperty);
            set => SetValue(KeyboardFocusedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty KeyboardFocusedBorderThicknessProperty =
        DependencyProperty.Register("KeyboardFocusedBorderThickness", typeof(Thickness), typeof(PhTextBox), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        //public Thickness IsEnabledBorderThickness
        //{
        //    get { return (Thickness)GetValue(IsEnabledBorderThicknessProperty); }
        //    set { SetValue(IsEnabledBorderThicknessProperty, value); }
        //}

        //public static readonly DependencyProperty IsEnabledBorderThicknessProperty =
        //    DependencyProperty.Register("IsEnabledBorderThickness", typeof(Thickness), typeof(PhTextBox));

        //public Thickness IsDisabledBorderThickness
        //{
        //    get { return (Thickness)GetValue(IsDisabledBorderThicknessProperty); }
        //    set { SetValue(IsDisabledBorderThicknessProperty, value); }
        //}

        //public static readonly DependencyProperty IsDisabledBorderThicknessProperty =
        //    DependencyProperty.Register("IsDisabledBorderThickness", typeof(Thickness), typeof(PhTextBox), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEADES DE VISUALISACION

        private void imgLeft_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            Image img = sender as Image;
            ImgAltoLeft = img.Height;
            ImgAnchoLeft= img.Width;
        }

        private void imgRight_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            Image img = sender as Image;
            ImgAltoRight = img.Height;
            ImgAnchoRight= img.Width;

        }
    }
}