using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRR
{
	public partial class MainPage : ContentPage
	{
        ZXingBarcodeImageView barcode;
        public MainPage()
		{
			InitializeComponent();
		}
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (contentEntry.Text != string.Empty)
                {
                    
                    barcode = new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    };
                    barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    barcode.BarcodeOptions.Width = 500;
                    barcode.BarcodeOptions.Height = 500;
                    barcode.BarcodeValue = contentEntry.Text.Trim();
                    qrResult.Content = barcode;
                }
                else
                {
                    DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
            }
        }
        private const string Url = "http://www.nactem.ac.uk/software/acromine/dictionary.py?sf={0}";

        public async Task<string> GetResultAsync(string SearchString)
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(string.Format(Url, SearchString));
                return json.ToString();
            }
            catch (System.Exception exception)
            {
                return null;
            }

        }
    }
}
