
using MauiAppTest.Pages;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTest
{
    public class UIHelper
    {
        public static PageTest winTest;
        public static AboutPage winAbout;

        public static void ShowTestWindow()
        {
            if (winTest == null)
            {
                winTest = new PageTest();
            }

            App.Current.MainPage = winTest;
        }


        public static void ShowAboutWindow()
        {
            if (winAbout==null)
            {
                winAbout = new AboutPage();
            }

            App.Current.MainPage = winAbout;
        }
    }


    public class csMessage
    {
        public Page parentPage;

        public csMessage(Page _parentPage)
        {
            parentPage = _parentPage;
        }

        public async Task ShowMessage(string sMessage, string sTitle = "Info")
        {
            await parentPage.DisplayAlert(sTitle, sMessage, "OK");
        }


        public async Task<bool> ShowConfirm(string sMessage, string sTitle = "Info", string sOK = "OK", string sCancel = "Cancel")
        {
            return await parentPage.DisplayAlert(sTitle, sMessage, sOK, sCancel);
        }

        public async Task<string> ShowInput(string sMessage, string sTitle = "Info")
        {
            return await parentPage.DisplayPromptAsync(sTitle, sMessage);
        }

        public async Task<string> ShowSelection(string sMessage, params string[] buttons)
        {
            return await parentPage.DisplayActionSheet(sMessage, "Cancel", null, buttons);
        }
    }
}
