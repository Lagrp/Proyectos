using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para PhPasswordBox.xaml
    /// </summary>
    public partial class PhPasswordBox : UserControl, INotifyPropertyChanged
    {
        private Brush iniBb;
        private Thickness iniBt;

        public PhPasswordBox()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(PhPasswordBox);
            this.GotFocus += Enfoque;
        }

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PhPasswordBox), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(PhPasswordBox), new PropertyMetadata(null));

        public double ImgAncho
        {
            get => (double)GetValue(ImgAnchoProperty);
            set => SetValue(ImgAnchoProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoProperty = DependencyProperty.Register("ImgAncho", typeof(double), typeof(PhPasswordBox), new PropertyMetadata((double)0));

        public double ImgAlto
        {
            get => (double)GetValue(ImgAltoProperty);
            set => SetValue(ImgAltoProperty, value);
        }

        public static readonly DependencyProperty ImgAltoProperty = DependencyProperty.Register("ImgAlto", typeof(double), typeof(PhPasswordBox), new PropertyMetadata((double)0));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(PhPasswordBox), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargen
        {
            get => (Thickness)GetValue(ImgMargenProperty);
            set => SetValue(ImgMargenProperty, value);
        }

        public static readonly DependencyProperty ImgMargenProperty = DependencyProperty.Register("ImgMargen", typeof(Thickness), typeof(PhPasswordBox), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES PLACEHOLDER

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PhPasswordBox), new PropertyMetadata("PHPasswordBox1"));

        public Brush PHForeground
        {
            get => (Brush)GetValue(PHForegroundProperty);
            set => SetValue(PHForegroundProperty, value);
        }

        public static readonly DependencyProperty PHForegroundProperty = DependencyProperty.Register("PHForeground", typeof(Brush), typeof(PhPasswordBox), new PropertyMetadata(ColorTool.ColorHxa("#7C8591")));

        public FontStyle PHFontStyle
        {
            get => (FontStyle)GetValue(PHFontStyleProperty);
            set => SetValue(PHFontStyleProperty, value);
        }

        public static readonly DependencyProperty PHFontStyleProperty = DependencyProperty.Register("PHFontStyle", typeof(FontStyle), typeof(PhPasswordBox), new PropertyMetadata(FontStyles.Oblique));

        public double PHFontSize
        {
            get => (double)GetValue(PHFontSizeProperty);
            set => SetValue(PHFontSizeProperty, value);
        }

        public static readonly DependencyProperty PHFontSizeProperty = DependencyProperty.Register("PHFontSize", typeof(double), typeof(PhPasswordBox), new PropertyMetadata((double)12));

        public FontStretch PHFontStretch
        {
            get => (FontStretch)GetValue(PHFontStretchProperty);
            set => SetValue(PHFontStretchProperty, value);
        }

        public static readonly DependencyProperty PHFontStretchProperty = DependencyProperty.Register("PHFontStretch", typeof(FontStretch), typeof(PhPasswordBox), new PropertyMetadata(FontStretches.Normal));

        public FontWeight PHFontWeight
        {
            get => (FontWeight)GetValue(PHFontWeightProperty);
            set => SetValue(PHFontWeightProperty, value);
        }

        public static readonly DependencyProperty PHFontWeightProperty = DependencyProperty.Register("PHFontWeight", typeof(FontWeight), typeof(PhPasswordBox), new PropertyMetadata(FontWeights.Normal));

        public Thickness PHPadding
        {
            get => (Thickness)GetValue(PHPaddingProperty);
            set => SetValue(PHPaddingProperty, value);
        }

        public static readonly DependencyProperty PHPaddingProperty = DependencyProperty.Register("PHPadding", typeof(Thickness), typeof(PhPasswordBox), new PropertyMetadata((Thickness)new(5, 0, 0, 0)));

        #endregion PROPIEDADES PLACEHOLDER

        #region PROPIEADES DE VISUALIZACION

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
        DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(PhPasswordBox), new PropertyMetadata(ColorTool.ColorHxa("#FF7EB4EA")));

        public Brush KeyboardFocusedBorderBrush
        {
            get => (Brush)GetValue(KeyboardFocusedBorderBrushProperty);
            set => SetValue(KeyboardFocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty KeyboardFocusedBorderBrushProperty = DependencyProperty.Register("KeyboardFocusedBorderBrush", typeof(Brush), typeof(PhPasswordBox), new PropertyMetadata(ColorTool.ColorHxa("#FF569DE5")));

        public Thickness KeyboardFocusedBorderThickness
        {
            get => (Thickness)GetValue(KeyboardFocusedBorderThicknessProperty);
            set => SetValue(KeyboardFocusedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty KeyboardFocusedBorderThicknessProperty = DependencyProperty.Register("KeyboardFocusedBorderThickness", typeof(Thickness), typeof(PhPasswordBox), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        private Visibility pswOn;

        public Visibility PswOn
        {
            get => pswOn;
            set
            {
                pswOn = value;
                OnPropertyChanged(nameof(pswOn));
            }
        }

        private Visibility txtOn = Visibility.Hidden;

        public Visibility TxtOn
        {
            get => txtOn;
            set
            {
                txtOn = value;
                OnPropertyChanged(nameof(TxtOn));
            }
        }

        private Visibility phOn;

        public Visibility PhON
        {
            get => phOn;
            set
            {
                phOn = value;
                OnPropertyChanged(nameof(PhON));
            }
        }

        #endregion PROPIEADES DE VISUALIZACION

        #region PROPIEDADES AÑADIDAS

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(PhPasswordBox), new PropertyMetadata(string.Empty));

        #endregion PROPIEDADES AÑADIDAS

        #region EVENTOS

        private void tlgVer_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton tlg = sender as ToggleButton;
            if (tlg.IsChecked == true)
            {
                tlg.Background = ImageTool.LoadImageBrush("/Resourse/invisible_32px.png", Assembly.GetExecutingAssembly());
                PswOn = Visibility.Hidden;
                TxtOn = Visibility.Visible;
            }
            else
            {
                tlg.Background = ImageTool.LoadImageBrush("/Resourse/eye_32px.png", Assembly.GetExecutingAssembly());
                PasswordBox psw = (PasswordBox)this.Template.FindName("pswBox", this);
                psw.Password = Password;
                PswOn = Visibility.Visible;
                TxtOn = Visibility.Hidden;
            }
        }

        private void OnPlceHolderState()
        {
            if (string.IsNullOrEmpty(Password))
            {
                PhON = Visibility.Visible;
            }
            else
            {
                PhON = Visibility.Hidden;
            }
        }

        private void pswBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox psw = sender as PasswordBox;
            Password = psw.Password;
        }

        private void txtPsw_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtPsw = sender as TextBox;
            Password = txtPsw.Text;
            OnPlceHolderState();
        }

        private void Enfoque(object sender, RoutedEventArgs e)
        {
            iniBb = this.BorderBrush;
            iniBt = this.BorderThickness;

            this.BorderBrush = KeyboardFocusedBorderBrush;
            this.BorderThickness = KeyboardFocusedBorderThickness;
            PasswordBox psw = (PasswordBox)this.Template.FindName("pswBox", this);
            if (psw.IsVisible)
            {
                psw.Focus();
            }
            else
            {
                TextBox txt = (TextBox)this.Template.FindName("txtPsw", this);
                txt.Focus();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void phPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.BorderBrush = iniBb;
            this.BorderThickness = iniBt;
        }

        #endregion EVENTOS
    }
}