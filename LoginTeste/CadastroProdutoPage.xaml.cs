namespace AppCadastro;

public partial class CadastroProdutoPage : ContentPage
{
    bool darkTheme = false;
    public CadastroProdutoPage()
    {
        InitializeComponent();
    }

    private void btnConcluirCadastro_Clicked(object sender, EventArgs e)
    {
        // Verifica se algum campo est� vazio ou nulo
        if (string.IsNullOrWhiteSpace(nomeProd.Text) ||
            string.IsNullOrWhiteSpace(descProd.Text) ||
            string.IsNullOrWhiteSpace(categoriaProd.Text) ||
            string.IsNullOrWhiteSpace(precoProd.Text))
        {
            // Exibe um alerta informando que todos os campos s�o obrigat�rios
            DisplayAlert("Aten��o", "Por favor, preencha todos os campos.", "OK");
            return; // Sai do m�todo sem continuar
        }

        // Verifica se o pre�o � um n�mero decimal v�lido
        if (!decimal.TryParse(precoProd.Text, out decimal preco))
        {
            DisplayAlert("Aten��o", "Por favor, insira um pre�o v�lido.", "OK");
            return;
        }

        // Se todas as valida��es passarem, cria o novo produto
        var novoProduto = new Produtos.Produto
        {
            nomeProd = nomeProd.Text,
            descProd = descProd.Text,
            categoriaProd = categoriaProd.Text,
            precoProd = preco
        };

        AppData.Produtos.Add(novoProduto);

        DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

        nomeProd.Text = "";
        descProd.Text = "";
        categoriaProd.Text = "";
        precoProd.Text = "";
    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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

                mergedDictionaries.Add(new Resources.Theme.DarkTheme());
            }
            else
            {

                mergedDictionaries.Add(new Resources.Theme.WhiteTheme());
            }
        }
    }

    private async void CaixaButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

