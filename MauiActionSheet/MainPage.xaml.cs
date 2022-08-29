namespace MauiActionSheet;
using CommunityToolkit.Maui.Views;

public partial class MainPage : ContentPage
{
    
	
	public MainPage()
	{
		InitializeComponent();
    }

    async void OnActionBtnClicked(object sender, EventArgs e)
	{
		var actions = new List<ActionSheetItemArguments>
		{
			new ActionSheetItemArguments("alskj", "Kamera", "Camera"),
            new ActionSheetItemArguments("asd", "Dokumenter", "Documents"),
            new ActionSheetItemArguments("fasdf", "Galleri", "Gallery"),
		};
		var popup = new SimplePopup(actions);
        var result = await new ActionSheetAdapter().ShowMyPopup(popup);

        LastClickedAction.Text = result.ToString();
    }
}

