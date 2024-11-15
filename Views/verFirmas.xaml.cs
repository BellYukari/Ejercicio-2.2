using Microsoft.Maui.Controls;
using SQLite;
using System.Collections.ObjectModel;
using Tarea2._2FirmaDigital.Controllers;
using Tarea2._2FirmaDigital.Models;

namespace Tarea2._2FirmaDigital.Views;

public partial class verFirmas : ContentPage
{
    private firmaController controller;
    private ObservableCollection<firmaDigital> firmas = new ObservableCollection<firmaDigital>();

    public verFirmas()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        controller = new firmaController();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            firmas = new ObservableCollection<firmaDigital>(await controller.getListFirmas());
            collectionViewFirmas.ItemsSource = firmas;
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error cargando firmas: {ex.Message}");
        }
    }

}