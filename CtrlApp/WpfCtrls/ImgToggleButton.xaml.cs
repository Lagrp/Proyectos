﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para ImgToggleButton.xaml
    /// </summary>
    public partial class ImgToggleButton : ToggleButton
    {
        //private Visibility _ContentVisibility;

        public ImgToggleButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(ImgToggleButton);
            this.Content = "ImgToggleButton1";
        }

        #region PROPIEDADES IMAGEN

        public ImageSource ImgSource
        {
            get => (ImageSource)GetValue(ImgSourceProperty);
            set => SetValue(ImgSourceProperty, value);
        }

        public static readonly DependencyProperty ImgSourceProperty =
        DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(ImgToggleButton), new PropertyMetadata(null));

        public double ImgAncho
        {
            get => (double)GetValue(ImgAnchoProperty);
            set => SetValue(ImgAnchoProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoProperty = DependencyProperty.Register("ImgAncho", typeof(double), typeof(ImgToggleButton), new PropertyMetadata((double)25));

        public double ImgAlto
        {
            get => (double)GetValue(ImgAltoProperty);
            set => SetValue(ImgAltoProperty, value);
        }

        public static readonly DependencyProperty ImgAltoProperty = DependencyProperty.Register("ImgAlto", typeof(double), typeof(ImgToggleButton), new PropertyMetadata((double)25));

        public Stretch ImgStretch
        {
            get => (Stretch)GetValue(ImgStretchProperty);
            set => SetValue(ImgStretchProperty, value);
        }

        public static readonly DependencyProperty ImgStretchProperty = DependencyProperty.Register("ImgStretch", typeof(Stretch), typeof(ImgToggleButton), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargen
        {
            get => (Thickness)GetValue(ImgMargenProperty);
            set => SetValue(ImgMargenProperty, value);
        }

        public static readonly DependencyProperty ImgMargenProperty = DependencyProperty.Register("ImgMargen", typeof(Thickness), typeof(ImgToggleButton), new PropertyMetadata((Thickness)new(1, 1, 1, 1)));

        #endregion PROPIEDADES IMAGEN

        #region PROPIEDADES PANEL

        public Orientation Orientacion
        {
            get => (Orientation)GetValue(OrientacionProperty);
            set => SetValue(OrientacionProperty, value);
        }

        public static readonly DependencyProperty OrientacionProperty = DependencyProperty.Register("Orientacion", typeof(Orientation), typeof(ImgToggleButton), new PropertyMetadata(Orientation.Horizontal));

        #endregion PROPIEDADES PANEL

        #region PROPIEDADES BORDE

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ImgToggleButton), new PropertyMetadata(null));

        #endregion PROPIEDADES BORDE

        #region MOUSE OVER

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#E1F4FE")));

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set => SetValue(MouseOverForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#000000")));

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set => SetValue(MouseOverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#3DBAFD")));

        #endregion MOUSE OVER

        #region MOUSE CHECKED

        public Brush CheckedBackground
        {
            get => (Brush)GetValue(CheckedBackgroundProperty);
            set => SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty = DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush CheckedBorderBrush
        {
            get => (Brush)GetValue(CheckedBorderBrushProperty);
            set => SetValue(CheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty = DependencyProperty.Register("CheckedBorderBrush", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Brush CheckedForeground
        {
            get => (Brush)GetValue(CheckedForegroundProperty);
            set => SetValue(CheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty CheckedForegroundProperty = DependencyProperty.Register("CheckedForeground", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#000000")));

        public Thickness CheckedBorderThickness
        {
            get => (Thickness)GetValue(CheckedBorderThicknessProperty);
            set => SetValue(CheckedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderThicknessProperty = DependencyProperty.Register("CheckedBorderThickness", typeof(Thickness), typeof(ImgToggleButton), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        public double CheckedFontSize
        {
            get => (double)GetValue(CheckedFontSizeProperty);
            set => SetValue(CheckedFontSizeProperty, value);
        }

        public static readonly DependencyProperty CheckedFontSizeProperty = DependencyProperty.Register("CheckedFontSize", typeof(double), typeof(ImgToggleButton), new PropertyMetadata((double)13));

        public FontWeight CheckedFontWeight
        {
            get => (FontWeight)GetValue(CheckedFontWeightProperty);
            set => SetValue(CheckedFontWeightProperty, value);
        }

        public static readonly DependencyProperty CheckedFontWeightProperty = DependencyProperty.Register("CheckedFontWeight", typeof(FontWeight), typeof(ImgToggleButton), new PropertyMetadata(FontWeights.Medium));

        public FontStyle CheckedFontStyle
        {
            get => (FontStyle)GetValue(CheckedFontStyleProperty);
            set => SetValue(CheckedFontStyleProperty, value);
        }

        public static readonly DependencyProperty CheckedFontStyleProperty = DependencyProperty.Register("CheckedFontStyle", typeof(FontStyle), typeof(ImgToggleButton), new PropertyMetadata(FontStyles.Italic));

        #endregion MOUSE CHECKED

        #region MOUSE PRESSED

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#A6DFFE")));

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(ImgToggleButton), new PropertyMetadata(ColorTool.ColorHxa("#49C1FE")));

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PressedBorderThicknessProperty = DependencyProperty.Register("PressedBorderThickness", typeof(Thickness), typeof(ImgToggleButton), new PropertyMetadata((Thickness)new(2, 2, 2, 2)));

        #endregion MOUSE PRESSED
    }
}