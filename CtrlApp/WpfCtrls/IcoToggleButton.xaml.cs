using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para IcoToggleButton.xaml
    /// </summary>
    public partial class IcoToggleButton : ToggleButton
    {
        public IcoToggleButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(IcoToggleButton);
        }

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IcoToggleButton), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty =
        DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(IcoToggleButton), new PropertyMetadata(null));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty =
        DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(IcoToggleButton), new PropertyMetadata(Stretch.Fill));

        #endregion PROPIEDADES IMAGEN

        #region MOUSE OVER

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
        DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#E1F4FE")));

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
        DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        #endregion MOUSE OVER

        #region MOUSE PRESSED

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty =
        DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PressedBorderBrushProperty =
        DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PressedBorderThicknessProperty =
        DependencyProperty.Register("PressedBorderThickness", typeof(Thickness), typeof(IcoToggleButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion MOUSE PRESSED

        #region MOUSE CHECKED

        public Brush CheckedBackground
        {
            get => (Brush)GetValue(CheckedBackgroundProperty);
            set => SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
        DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush CheckedBorderBrush
        {
            get => (Brush)GetValue(CheckedBorderBrushProperty);
            set => SetValue(CheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty =
        DependencyProperty.Register("CheckedBorderBrush", typeof(Brush), typeof(IcoToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness CheckedBorderThickness
        {
            get => (Thickness)GetValue(CheckedBorderThicknessProperty);
            set => SetValue(CheckedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderThicknessProperty =
        DependencyProperty.Register("CheckedBorderThickness", typeof(Thickness), typeof(IcoToggleButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion MOUSE CHECKED
    }
}