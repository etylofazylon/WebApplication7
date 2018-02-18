using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication7
{
    public partial class _Default : Page
    {
        protected void Page_Load(object snd, EventArgs e)
        {
            var client = new HttpClient();

            // tu podajesz uri do strony
            var getTextTask = client.GetAsync("https://gynvael.coldwind.pl");

            //to jest do walidacji certyfikatów ( strona używa ssl )
            ServicePointManager
                .ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

            getTextTask.ContinueWith(response =>
            {
                // tu pobierasz wynik i wpisujesz w kontrolkę..
                responseText.Text = response.Result.Content.
                ReadAsStringAsync().Result;
            });

        }
    }
}