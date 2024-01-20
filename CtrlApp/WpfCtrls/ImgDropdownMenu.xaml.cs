using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCtrls
{
    /// <summary>
    /// Lógica de interacción para ImgDropdownMenu.xaml
    /// </summary>
    public partial class ImgDropdownMenu : Expander
    {
        public ImgDropdownMenu()
        {
            InitializeComponent();
            this.DefaultStyleKey = typeof(ImgDropdownMenu);
            this.Header = "ImgDropdownMenu";
        }

        #region COLOR FLECHA

        //<SolidColorBrush x:Key="Expander.Static.Circle.Stroke" Color="#FF333333" />
        public SolidColorBrush ExpanderStaticCircleStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderStaticCircleStrokeProperty); }
            set { SetValue(ExpanderStaticCircleStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderStaticCircleStrokeProperty =
            DependencyProperty.Register("ExpanderStaticCircleStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<!--<SolidColorBrush x:Key="Expander.Static.Circle.Fill" Color="#FFFFFFFF" />-->
        public SolidColorBrush ExpanderStaticCircleFill
        {
            get { return (SolidColorBrush)GetValue(ExpanderStaticCircleFillProperty); }
            set { SetValue(ExpanderStaticCircleFillProperty, value); }
        }

        public static readonly DependencyProperty ExpanderStaticCircleFillProperty =
            DependencyProperty.Register("ExpanderStaticCircleFill", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<!--<SolidColorBrush x:Key="Expander.Static.Arrow.Stroke" Color="#FF333333" />-->
        public SolidColorBrush ExpanderStaticArrowStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderStaticArrowStrokeProperty); }
            set { SetValue(ExpanderStaticArrowStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderStaticArrowStrokeProperty =
            DependencyProperty.Register("ExpanderStaticArrowStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(ColorTool.ColorHxa("#FF333333")));

        //<!--<SolidColorBrush x:Key="Expander.MouseOver.Circle.Stroke" Color="#FF5593FF" />-->
        public SolidColorBrush ExpanderMouseOverCircleStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderMouseOverCircleStrokeProperty); }
            set { SetValue(ExpanderMouseOverCircleStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderMouseOverCircleStrokeProperty =
            DependencyProperty.Register("ExpanderMouseOverCircleStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<SolidColorBrush x:Key="Expander.MouseOver.Circle.Fill" Color="#FFF3F9FF" />
        public SolidColorBrush ExpanderMouseOverCircleFill
        {
            get { return (SolidColorBrush)GetValue(ExpanderouseOverCircleFillProperty); }
            set { SetValue(ExpanderouseOverCircleFillProperty, value); }
        }

        public static readonly DependencyProperty ExpanderouseOverCircleFillProperty =
            DependencyProperty.Register(" MyProperty", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<SolidColorBrush x:Key="Expander.MouseOver.Arrow.Stroke" Color="#FF000000" />
        public SolidColorBrush ExpanderMouseOverArrowStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderMouseOverArrowStrokeProperty); }
            set { SetValue(ExpanderMouseOverArrowStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderMouseOverArrowStrokeProperty =
            DependencyProperty.Register("ExpanderMouseOverArrowStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(ColorTool.ColorHxa("#FF000000")));

        //<SolidColorBrush x:Key="Expander.Pressed.Circle.Stroke" Color="#FF3C77DD" />
        public SolidColorBrush ExpanderPressedCircleStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderPressedCircleStrokeProperty); }
            set { SetValue(ExpanderPressedCircleStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderPressedCircleStrokeProperty =
            DependencyProperty.Register("ExpanderPressedCircleStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<SolidColorBrush x:Key="Expander.Pressed.Circle.Fill" Color="#FFD9ECFF" />
        public SolidColorBrush ExpanderPressedCircleFill
        {
            get { return (SolidColorBrush)GetValue(ExpanderPressedCircleFillProperty); }
            set { SetValue(ExpanderPressedCircleFillProperty, value); }
        }

        public static readonly DependencyProperty ExpanderPressedCircleFillProperty =
            DependencyProperty.Register("ExpanderPressedCircleFill", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(null));

        //<SolidColorBrush x:Key="Expander.Pressed.Arrow.Stroke" Color="#FF000000" />
        public SolidColorBrush ExpanderPressedArrowStroke
        {
            get { return (SolidColorBrush)GetValue(ExpanderPressedArrowStrokeProperty); }
            set { SetValue(ExpanderPressedArrowStrokeProperty, value); }
        }

        public static readonly DependencyProperty ExpanderPressedArrowStrokeProperty =
            DependencyProperty.Register("ExpanderPressedArrowStroke", typeof(SolidColorBrush), typeof(ImgDropdownMenu), new PropertyMetadata(ColorTool.ColorHxa("#FF000000")));

        #endregion COLOR FLECHA







    }
}