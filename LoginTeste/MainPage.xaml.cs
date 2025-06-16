using AppCadastro;
using AppCadastro.Resources.Theme;

namespace LoginTeste
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool darkTheme = false;
        public MainPage()
        {
            InitializeComponent();
        }




        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            Preferences.Default.Remove("usuario");

            await Shell.Current.GoToAsync("Login");
        }
        protected override bool OnBackButtonPressed() { return true; }

        private async void btnPagCadastro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroProdutoPage());
        }

        private async void btnProdutosPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProdutosPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                darkTheme = !darkTheme;
                if (darkTheme)
                {

                    mergedDictionaries.Add(new DarkTheme());
                }
                else
                {

                    mergedDictionaries.Add(new WhiteTheme());
                }
            }
        }

        private async void btnUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioPage());
        }
    }

}
