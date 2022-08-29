namespace MauiActionSheet;

using Microsoft.Maui.Platform;
using System;
using LayoutAlignment = Microsoft.Maui.Primitives.LayoutAlignment;


public partial class SimplePopup : CommunityToolkit.Maui.Views.Popup
{
    public List<Button> Actions = new();

	public SimplePopup(List<ActionSheetItemArguments> actions)
	{
		InitializeComponent();

        Color = Colors.Transparent;
        VerticalOptions = LayoutAlignment.End;
        HorizontalOptions = LayoutAlignment.Start;

        // var w = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo.Width;

        TheGrid.WidthRequest = 400;

        foreach (var action in actions)
        {
            AddItem(action.iconGlyph, action.label, action.value);
        }

        AnimateAppearance();
    }

    public void AddItem(string iconGlyph, string label, object value)
    {
        var action = new Button
        {
            Text = $"{label} - {iconGlyph}",
            Margin = new Thickness(0, 10, 0, 0),
            Padding = new Thickness(20, 10),
            BackgroundColor = Colors.White,
            TextColor = Colors.Blue,
            Opacity = 0,
        };

        void handler(object sender, object args)
        {
            Close(value);
            action.Clicked -= handler;
        }

        action.Clicked += handler;

        Actions.Add(action);
        TheGrid.Insert(0, action);
    }

    private async void AnimateAppearance()
    {
        foreach (var action in Actions)
        {
            await action.FadeTo(100, length: 100);
        }
    }
}