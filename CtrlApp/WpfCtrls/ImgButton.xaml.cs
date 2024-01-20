using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ImgButton : Button
    {
        public ImgButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(ImgButton);
            this.Content = "ImgButton1";
        }

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(ImgButton), new PropertyMetadata(null));

        public double ImgAncho
        {
            get => (double)GetValue(ImgAnchoProperty);
            set => SetValue(ImgAnchoProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoProperty = DependencyProperty.Register("ImgAncho", typeof(double), typeof(ImgButton), new PropertyMetadata((double)25));

        public double ImgAlto
        {
            get => (double)GetValue(ImgAltoProperty);
            set => SetValue(ImgAltoProperty, value);
        }

        public static readonly DependencyProperty ImgAltoProperty = DependencyProperty.Register("ImgAlto", typeof(double), typeof(ImgButton), new PropertyMetadata((double)25));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(ImgButton), new PropertyMetadata(Stretch.UniformToFill));

        public Thickness ImgMargen
        {
            get => (Thickness)GetValue(ImgMargenProperty);
            set => SetValue(ImgMargenProperty, value);
        }

        public static readonly DependencyProperty ImgMargenProperty = DependencyProperty.Register("ImgMargen", typeof(Thickness), typeof(ImgButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES PANEL

        public Orientation Orientacion
        {
            get => (Orientation)GetValue(OrientacionProperty);
            set => SetValue(OrientacionProperty, value);
        }

        public static readonly DependencyProperty OrientacionProperty = DependencyProperty.Register("Orientacion", typeof(Orientation), typeof(ImgButton), new PropertyMetadata(Orientation.Horizontal));

        #endregion PROPIEDADES PANEL

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ImgButton), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region MOUSE OVER

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(ImgButton), new PropertyMetadata(ColorTool.ColorHxa("#E1F4FE")));

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set => SetValue(MouseOverForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(ImgButton), new PropertyMetadata(ColorTool.ColorHxa("#000000")));

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(ImgButton), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        public double MouseOverFontSize
        {
            get => (double)GetValue(MouseOverFontSizeProperty);
            set => SetValue(MouseOverFontSizeProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontSizeProperty = DependencyProperty.Register("MouseOverFontSize", typeof(double), typeof(ImgButton), new PropertyMetadata((double)13));

        public FontWeight MouseOverFontWeight
        {
            get => (FontWeight)GetValue(MouseOverFontWeightProperty);
            set => SetValue(MouseOverFontWeightProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontWeightProperty = DependencyProperty.Register("MouseOverFontWeight", typeof(FontWeight), typeof(ImgButton), new PropertyMetadata(FontWeights.Medium));

        public FontStyle MouseOverFontStyle
        {
            get => (FontStyle)GetValue(MouseOverFontStyleProperty);
            set => SetValue(MouseOverFontStyleProperty, value);
        }

        public static readonly DependencyProperty MouseOverFontStyleProperty = DependencyProperty.Register("MouseOverFontStyle", typeof(FontStyle), typeof(ImgButton), new PropertyMetadata(FontStyles.Italic));

        public Thickness MouseOverBorderThickness
        {
            get { return (Thickness)GetValue(MouseOverBorderThicknessProperty); }
            set { SetValue(MouseOverBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBorderThicknessProperty =
        DependencyProperty.Register("MouseOverBorderThickness", typeof(Thickness), typeof(ImgButton), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        #endregion MOUSE OVER

        #region MOUSE PRESSED

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(ImgButton), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(ImgButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PressedBorderThicknessProperty = DependencyProperty.Register("PressedBorderThickness", typeof(Thickness), typeof(ImgButton), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        #endregion MOUSE PRESSED
    }
}