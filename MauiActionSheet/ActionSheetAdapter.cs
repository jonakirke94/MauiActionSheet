using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiActionSheet;

public class ActionSheetAdapter
{
    static Page Page => Application.Current?.MainPage ?? throw new NullReferenceException();

    public Task<object> ShowMyPopup<TPopup>(TPopup popup) where TPopup : Popup
    {
        Page.ShowPopup(popup);

        var taskCompletionSource = new TaskCompletionSource<object>();

        void handler(object sender, PopupClosedEventArgs args)
        {
            taskCompletionSource.SetResult(args.Result);
            popup.Closed -= handler;
        }

        popup.Closed += handler;

        return taskCompletionSource.Task;
    }
}
