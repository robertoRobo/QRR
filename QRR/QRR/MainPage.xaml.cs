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
        
        private void Button_Clicked1(object sender, EventArgs e)
        {
            var viewModel = BindingContext;

            BindingContext = null;
            InitializeComponent();

            BindingContext = viewModel;
            
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
                    barcode.BarcodeOptions.Width = 800;
                    barcode.BarcodeOptions.Height = 800;
                    barcode.BarcodeValue = contentEntry.Text.Trim();
                    qrResult.Content = barcode;
                    qrResult.WidthRequest = 100;
                    qrResult.HeightRequest = 100;
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

   
    }
}
