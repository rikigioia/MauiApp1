namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private const string HomeUrl = "https://www.google.com";

        public MainPage()
        {
            InitializeComponent();
            Browser.Source = HomeUrl;
        }

        protected override bool OnBackButtonPressed()
        {
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
                return true;
            }

            return base.OnBackButtonPressed();
        }

        private void OnBrowserNavigating(object? sender, WebNavigatingEventArgs e)
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;
            ErrorPanel.IsVisible = false;
        }

        private void OnBrowserNavigated(object? sender, WebNavigatedEventArgs e)
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;

            if (e.Result == WebNavigationResult.Failure)
            {
                ErrorMessage.Text = "Impossibile caricare la pagina. Controlla la connessione e riprova.";
                ErrorPanel.IsVisible = true;
            }
        }

        private void OnBackClicked(object? sender, EventArgs e)
        {
            if (Browser.CanGoBack)
                Browser.GoBack();
        }

        private void OnHomeClicked(object? sender, EventArgs e)
        {
            Browser.Source = HomeUrl;
        }

        private void OnRefreshClicked(object? sender, EventArgs e)
        {
            Browser.Reload();
        }

        private void OnRetryClicked(object? sender, EventArgs e)
        {
            Browser.Reload();
        }
    }
}
