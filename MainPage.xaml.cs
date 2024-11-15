namespace Tarea2._2FirmaDigital
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var status = await Permissions.RequestAsync<Permissions.StorageWrite>();
        }

        private void btnAgregarFirma_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.agregarFirma());
        }

        private void btnVerFirmas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.verFirmas());
        }
    }

}
