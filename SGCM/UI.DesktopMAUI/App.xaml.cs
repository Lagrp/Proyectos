namespace UI.DesktopMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        //protected override Window CreateWindow(IActivationState activationState)
        //{
        //    Window window = base.CreateWindow(activationState);

        //    // Get display size
        //    var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

        //    // Manipulate Window object
        //    window.Width = displayInfo.Width;
        //    window.Height = displayInfo.Height;

        //    // Center the window
        //    //window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
        //    //window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
        //    return window;
        //}
    }
}