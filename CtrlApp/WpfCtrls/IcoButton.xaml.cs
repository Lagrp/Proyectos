using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para BtnIco.xaml
    /// </summary>
    public partial class IcoButton : Button
    {
        public IcoButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(IcoButton);
        }

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty
        = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(IcoButton), new PropertyMetadata(null));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty
        = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(IcoButton), new PropertyMetadata(Stretch.Fill));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty
        = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IcoButton), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region MOUSE OVER

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
        DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(IcoButton), new PropertyMetadata(Brushes.Transparent));

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
        DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(IcoButton), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        public Thickness MouseOverBorderThickness
        {
            get => (Thickness)GetValue(MouseOverBorderThicknessProperty);
            set => SetValue(MouseOverBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderThicknessProperty =
        DependencyProperty.Register("MouseOverBorderThickness", typeof(Thickness), typeof(IcoButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion MOUSE OVER

        #region MOUSE PRESSED

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(IcoButton), new PropertyMetadata(Brushes.Transparent));

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(IcoButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PressedBorderThicknessProperty =
        DependencyProperty.Register("PressedBorderThickness", typeof(Thickness), typeof(IcoButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion MOUSE PRESSED
    }
}