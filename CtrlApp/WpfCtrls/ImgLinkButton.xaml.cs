using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para LinkButton.xaml
    /// </summary>
    public partial class ImgLinkButton : Border
    {
        public ImgLinkButton()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(ImgLinkButton);
        }

        #region PROPIEDADES HYPERLINK

        public string TextLink
        {
            get => (string)GetValue(TextLinkProperty);
            set => SetValue(TextLinkProperty, value);
        }

        public static readonly DependencyProperty TextLinkProperty =
        DependencyProperty.Register("TextLink", typeof(string), typeof(ImgLinkButton), new PropertyMetadata("ImgLinkButton1"));

        public Uri NavigateUri
        {
            get { return (Uri)GetValue(NavigateUriProperty); }
            set { SetValue(NavigateUriProperty, value); }
        }

        #endregion PROPIEDADES HYPERLINK

        #region PROPIEDADES PANEL

        public Orientation Orientacion
        {
            get => (Orientation)GetValue(OrientacionProperty);
            set => SetValue(OrientacionProperty, value);
        }

        public static readonly DependencyProperty OrientacionProperty =
        DependencyProperty.Register("Orientacion", typeof(Orientation), typeof(ImgLinkButton), new PropertyMetadata(Orientation.Horizontal));

        #endregion PROPIEDADES PANEL

        #region PROPIEDADES TEXTBLOCK

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(ImgLinkButton), new PropertyMetadata(ColorTool.ColorHxa("#BFCDDB")));

        public FontStyle FontStyle
        {
            get => (FontStyle)GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }

        public static readonly DependencyProperty FontStyleProperty =
        DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(ImgLinkButton), new PropertyMetadata(FontStyles.Normal));

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register("FontSize", typeof(double), typeof(ImgLinkButton), new PropertyMetadata((double)12));

        public FontFamily FontFamily
        {
            get => (FontFamily)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly DependencyProperty FontFamilyProperty =
        DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(ImgLinkButton), new PropertyMetadata(new FontFamily("Segoe UI")));

        public FontStretch FontStretch
        {
            get => (FontStretch)GetValue(FontStretchProperty);
            set => SetValue(FontStretchProperty, value);
        }

        public static readonly DependencyProperty FontStretchProperty = DependencyProperty.Register("FontStretch", typeof(FontStretch), typeof(ImgLinkButton), new PropertyMetadata(FontStretches.Normal));

        public FontWeight FontWeight
        {
            get => (FontWeight)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(ImgLinkButton), new PropertyMetadata(FontWeights.Normal));

        public TextTrimming TextTrimming
        {
            get => (TextTrimming)GetValue(TextTrimmingProperty);
            set => SetValue(TextTrimmingProperty, value);
        }

        public static readonly DependencyProperty TextTrimmingProperty =
        DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(ImgLinkButton), new PropertyMetadata(TextTrimming.None));

        public TextWrapping TextWrapping
        {
            get => (TextWrapping)GetValue(TextWrappingProperty);
            set => SetValue(TextWrappingProperty, value);
        }

        public static readonly DependencyProperty TextWrappingProperty =
        DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(ImgLinkButton), new PropertyMetadata(TextWrapping.NoWrap));

        public TextDecorationCollection TextDecorations
        {
            get => (TextDecorationCollection)GetValue(TextDecorationsProperty);
            set => SetValue(TextDecorationsProperty, value);
        }

        public static readonly DependencyProperty TextDecorationsProperty =
        DependencyProperty.Register("TextDecorations", typeof(TextDecorationCollection), typeof(ImgLinkButton), new PropertyMetadata(null));

        public HorizontalAlignment HorizontalContentAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty HorizontalContentAlignmentProperty =
        DependencyProperty.Register("HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(ImgLinkButton), new PropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment VerticalContentAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalContentAlignmentProperty);
            set => SetValue(VerticalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty VerticalContentAlignmentProperty =
        DependencyProperty.Register("VerticalContentAlignment", typeof(VerticalAlignment), typeof(ImgLinkButton), new PropertyMetadata(VerticalAlignment.Center));

        #endregion PROPIEDADES TEXTBLOCK

        // Using a DependencyProperty as the backing store for NavigateUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateUriProperty =
        DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(ImgLinkButton), new PropertyMetadata(null));

        #region PROPIEDADES IMAGEN RIGHT

        public ImageSource ImgSourceRight
        {
            get => (ImageSource)GetValue(ImgSourceRightProperty);
            set => SetValue(ImgSourceRightProperty, value);
        }

        public static readonly DependencyProperty ImgSourceRightProperty =
        DependencyProperty.Register("ImgSourceRight", typeof(ImageSource), typeof(ImgLinkButton), new PropertyMetadata(null));

        public double ImgAnchoRight
        {
            get => (double)GetValue(ImgAnchoRightProperty);
            set => SetValue(ImgAnchoRightProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoRightProperty =
        DependencyProperty.Register("ImgAnchoRight", typeof(double), typeof(ImgLinkButton), new PropertyMetadata((double)0));

        public double ImgAltoRight
        {
            get => (double)GetValue(ImgAltoRightProperty);
            set => SetValue(ImgAltoRightProperty, value);
        }

        public static readonly DependencyProperty ImgAltoRightProperty =
        DependencyProperty.Register("ImgAltoRight", typeof(double), typeof(ImgLinkButton), new PropertyMetadata((double)0));

        public Stretch ImgStretchRight
        {
            get => (Stretch)GetValue(ImgStretchRightProperty);
            set => SetValue(ImgStretchRightProperty, value);
        }

        public static readonly DependencyProperty ImgStretchRightProperty =
        DependencyProperty.Register("ImgStretchRight", typeof(Stretch), typeof(ImgLinkButton), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargenRight
        {
            get => (Thickness)GetValue(ImgMargenRightProperty);
            set => SetValue(ImgMargenRightProperty, value);
        }

        public static readonly DependencyProperty ImgMargenRightProperty =
        DependencyProperty.Register("ImgMargenRight", typeof(Thickness), typeof(ImgLinkButton), new PropertyMetadata((Thickness)new(0, 0, 0, 0)));

        public VerticalAlignment ImgVerticalAlignmentRight
        {
            get => (VerticalAlignment)GetValue(ImgVerticalAlignmentRightProperty);
            set => SetValue(ImgVerticalAlignmentRightProperty, value);
        }

        public static readonly DependencyProperty ImgVerticalAlignmentRightProperty =
        DependencyProperty.Register("ImgVerticalAlignmentRight", typeof(VerticalAlignment), typeof(ImgLinkButton), new PropertyMetadata(VerticalAlignment.Top));

        public HorizontalAlignment ImgHorizontalAlignmentRight
        {
            get => (HorizontalAlignment)GetValue(ImgHorizontalAlignmentRightProperty);
            set => SetValue(ImgHorizontalAlignmentRightProperty, value);
        }

        public static readonly DependencyProperty ImgHorizontalAlignmentRightProperty =
        DependencyProperty.Register("ImgHorizontalAlignmentRight", typeof(HorizontalAlignment), typeof(ImgLinkButton), new PropertyMetadata(HorizontalAlignment.Right));

        #endregion PROPIEDADES IMAGEN RIGHT

        #region PROPIEDADES IMAGEN LEFT

        public ImageSource ImgSourceLeft
        {
            get => (ImageSource)GetValue(ImgSourceLeftProperty);
            set => SetValue(ImgSourceLeftProperty, value);
        }

        public static readonly DependencyProperty ImgSourceLeftProperty =
        DependencyProperty.Register("ImgSourceLeft", typeof(ImageSource), typeof(ImgLinkButton), new PropertyMetadata(null));

        public double ImgAnchoLeft
        {
            get => (double)GetValue(ImgAnchoLeftProperty);
            set => SetValue(ImgAnchoLeftProperty, value);
        }

        public static readonly DependencyProperty ImgAnchoLeftProperty =
        DependencyProperty.Register("ImgAnchoLeft", typeof(double), typeof(ImgLinkButton), new PropertyMetadata((double)0));

        public double ImgAltoLeft
        {
            get => (double)GetValue(ImgAltoLeftProperty);
            set => SetValue(ImgAltoLeftProperty, value);
        }

        public static readonly DependencyProperty ImgAltoLeftProperty =
        DependencyProperty.Register("ImgAltoLeft", typeof(double), typeof(ImgLinkButton), new PropertyMetadata((double)0));

        public Stretch ImgStretchLeft
        {
            get => (Stretch)GetValue(ImgStretchLeftProperty);
            set => SetValue(ImgStretchLeftProperty, value);
        }

        public static readonly DependencyProperty ImgStretchLeftProperty =
        DependencyProperty.Register("ImgStretchLeft", typeof(Stretch), typeof(ImgLinkButton), new PropertyMetadata(Stretch.Fill));

        public Thickness ImgMargenLeft
        {
            get => (Thickness)GetValue(ImgMargenLeftProperty);
            set => SetValue(ImgMargenLeftProperty, value);
        }

        public static readonly DependencyProperty ImgMargenLeftProperty =
        DependencyProperty.Register("ImgMargenLeft", typeof(Thickness), typeof(ImgLinkButton), new PropertyMetadata((Thickness)new(0, 0, 0, 0)));

        public VerticalAlignment ImgVerticalAlignmentLeft
        {
            get => (VerticalAlignment)GetValue(ImgVerticalAlignmentLeftProperty);
            set => SetValue(ImgVerticalAlignmentLeftProperty, value);
        }

        public static readonly DependencyProperty ImgVerticalAlignmentLeftProperty =
        DependencyProperty.Register("ImgVerticalAlignmentLeft", typeof(VerticalAlignment), typeof(ImgLinkButton), new PropertyMetadata(VerticalAlignment.Top));

        public HorizontalAlignment ImgHorizontalAlignmentLeft
        {
            get => (HorizontalAlignment)GetValue(ImgHorizontalAlignmentLeftProperty);
            set => SetValue(ImgHorizontalAlignmentLeftProperty, value);
        }

        public static readonly DependencyProperty ImgHorizontalAlignmentLeftProperty =
        DependencyProperty.Register("ImgHorizontalAlignmentLeft", typeof(HorizontalAlignment), typeof(ImgLinkButton), new PropertyMetadata(HorizontalAlignment.Left));

        #endregion PROPIEDADES IMAGEN LEFT
    }
}