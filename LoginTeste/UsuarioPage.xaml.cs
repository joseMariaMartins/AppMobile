using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace AppCadastro
{
    public partial class UsuarioPage : ContentPage
    {
        public UsuarioPage()
        {
            InitializeComponent();
            CarregarDadosUsuario();
        }

        private void CarregarDadosUsuario()
        {
            // Obter dados reais do usu�rio
            var nome = Preferences.Default.Get("usuario_nome", "Usu�rio");
            var senha = Preferences.Default.Get("usuario_senha", "senha123"); // Mostra a senha real

            lblNomeUsuario.Text = nome;
            lblSenhaUsuario.Text = senha;
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirmar", "Deseja realmente sair da conta?", "Sim", "N�o");
            if (confirm)
            {
                // Limpa todas as prefer�ncias de sess�o
                Preferences.Default.Clear();
                await Shell.Current.GoToAsync("//Login");
            }
        }

        private void ToggleTheme_Clicked(object sender, EventArgs e)
        {
            Application.Current.UserAppTheme =
                (Application.Current.UserAppTheme == AppTheme.Dark) ?
                AppTheme.Light : AppTheme.Dark;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}