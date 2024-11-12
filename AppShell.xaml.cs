namespace Requests
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register navigation route
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));
        }
    }
}
