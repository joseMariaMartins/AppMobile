namespace LoginTeste
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Main", typeof(MainPage));
            Routing.RegisterRoute("Login", typeof(LoginPage));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            string usuario = Preferences.Default.Get("usuario", "");

            if (!usuario.Equals(String.Empty))
                Shell.Current.GoToAsync("Main");
        }
    }
}
