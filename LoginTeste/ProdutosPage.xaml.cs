using LoginTeste;

namespace AppCadastro;

public partial class ProdutosPage : ContentPage
{
    bool darkTheme = false;
    public ProdutosPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        listaProdutosView.ItemsSource = null;
        listaProdutosView.ItemsSource = AppData.Produtos;
    }

    private async void btnVoltar_Clicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
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
        await Navigation.PushAsync(new MainPage());
    }
}
