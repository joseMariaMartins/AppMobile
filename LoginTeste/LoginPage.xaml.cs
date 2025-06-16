using AppCadastro.Resources.Theme;


namespace LoginTeste;

public partial class LoginPage : ContentPage
{
    List<Usuario> lista;
    bool darkTheme = false;
    public LoginPage()
	{
		InitializeComponent();
        lista = new List<Usuario>();

        lista.Add(
            new Usuario()
            {
                Nome = "jose",
                Senha = "123"
            }
        );

        lista.Add(
            new Usuario()
            {
                Nome = "mariana",
                Senha = "456"
            }
        );
        lista.Add(
        new Usuario()
        {
            Nome = "bruno",
            Senha = "789"
        }
        );

        lista.Add(
            new Usuario()
            {
                Nome = "leticia",
                Senha = "101112"
            }
        );
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        await ValidarUsuario();
    }

    private async Task ValidarUsuario()
    {
        try
        {
            var usuarioDigitado = new Usuario() { Nome = txtUsuario.Text, Senha = txtSenha.Text };

            bool valido = lista.Any(u => usuarioDigitado.Nome.Equals(u.Nome) && usuarioDigitado.Senha.Equals(u.Senha));

            if (valido)
            {
                Preferences.Default.Set("usuario", usuarioDigitado.Nome);
                await Shell.Current.GoToAsync("Main");
            }
            else
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro de exceção", ex.Message, "Fechar");
        }
    }

    protected override bool OnBackButtonPressed() { return true; }

    private async void txtSenha_Completed(object sender, EventArgs e)
    {
        txtSenha.HideSoftInputAsync(CancellationToken.None);
        await ValidarUsuario();
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
}
