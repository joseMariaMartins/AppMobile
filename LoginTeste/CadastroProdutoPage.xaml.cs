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
        // Verifica se algum campo está vazio ou nulo
        if (string.IsNullOrWhiteSpace(nomeProd.Text) ||
            string.IsNullOrWhiteSpace(descProd.Text) ||
            string.IsNullOrWhiteSpace(categoriaProd.Text) ||
            string.IsNullOrWhiteSpace(precoProd.Text))
        {
            // Exibe um alerta informando que todos os campos são obrigatórios
            DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
            return; // Sai do método sem continuar
        }

        // Verifica se o preço é um número decimal válido
        if (!decimal.TryParse(precoProd.Text, out decimal preco))
        {
            DisplayAlert("Atenção", "Por favor, insira um preço válido.", "OK");
            return;
        }

        // Se todas as validações passarem, cria o novo produto
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

