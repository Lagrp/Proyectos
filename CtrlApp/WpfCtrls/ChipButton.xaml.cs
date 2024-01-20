using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para ChipButton.xaml
    /// </summary>
    public partial class ChipButton : Label
    {
        public ChipButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(ChipButton);
            this.Content = "ChipButton1";
        }

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(ChipButton), new PropertyMetadata(null));

        public double ImgAncho
        {
            get => (double)GetValue(ImgAnchoProperty);
            set => SetValue(ImgAnchoProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoProperty = DependencyProperty.Register("ImgAncho", typeof(double), typeof(ChipButton), new PropertyMetadata((double)25));

        public double ImgAlto
        {
            get => (double)GetValue(ImgAltoProperty);
            set => SetValue(ImgAltoProperty, value);
        }

        public static readonly DependencyProperty ImgAltoProperty = DependencyProperty.Register("ImgAlto", typeof(double), typeof(ChipButton), new PropertyMetadata((double)25));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(ChipButton), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargen
        {
            get => (Thickness)GetValue(ImgMargenProperty);
            set => SetValue(ImgMargenProperty, value);
        }

        public static readonly DependencyProperty ImgMargenProperty = DependencyProperty.Register("ImgMargen", typeof(Thickness), typeof(ChipButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES PANEL

        public Orientation Orientacion
        {
            get => (Orientation)GetValue(OrientacionProperty);
            set => SetValue(OrientacionProperty, value);
        }

        public static readonly DependencyProperty OrientacionProperty = DependencyProperty.Register("Orientacion", typeof(Orientation), typeof(ChipButton), new PropertyMetadata(Orientation.Horizontal));

        #endregion PROPIEDADES PANEL

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ChipButton), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE
    }
}