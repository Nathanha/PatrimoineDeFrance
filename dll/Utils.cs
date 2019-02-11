using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace dll
{
    public class Utils
    {
        private static string connStr = "server=137.74.114.61;user=PatrimoineProjet;database=PatrimoineProjet;port=3306;password=mny2018";
        public static string GetConn { get => connStr; }

        public static async void ShowDialog(string title, string contenu)
        {

            ContentDialog infoDialog = new ContentDialog
            {
                Title = title,
                Content = contenu,
                CloseButtonText = "Ok" 
            };

            ContentDialogResult result = await infoDialog.ShowAsync();
        }
    }
}
