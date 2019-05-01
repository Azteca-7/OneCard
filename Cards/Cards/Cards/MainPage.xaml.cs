using Cards.DataBase.SQLite;
using Cards.Model;
using Cards.Model.ModelTemporaryVariables;
using Cards.View;
using Cards.Webservice;
using Cards.Webservice.WSApis;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Cards
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Red;// color superior
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Green; //color del texto del titulo
            CrudSqlite cs = new CrudSqlite();
            cs.CreatenewtableOneCard(023007, "1084379");
        }

        private void ButtonRegistrarse_Clicked(object sender, EventArgs e)
        {

            try
            {
                Navigation.PushAsync(new CheckIn());
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                DisplayAlert("UPS hay un error!! ;(", error, "Ok");
            }
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)

                  await DisplayAlert("UPS hay un error!! ;(", "Habilite su internet", "OK");
                else

                {
                    if (String.IsNullOrWhiteSpace(User_Entry.Text))
                    {
                    await DisplayAlert("Error de Validación!", "Usuario Obligatorio", "OK");

                    }

                    else
                    {
                        //Valida que el formato del correo sea valido
                        bool isEmail = Regex.IsMatch(User_Entry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmail)
                        {
                         await DisplayAlert("Error de Validación!", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                        }

                        if (String.IsNullOrWhiteSpace(Password_Entry.Text))
                        {
                          await DisplayAlert("Error de Validación!", "Contraseña Obligatorio", "OK");
                        }

                        else
                        {
                            try
                            {
                                string user_ = User_Entry.Text;
                                string pass_ = Password_Entry.Text;
                                WsapisConfiguration wsconfi = new WsapisConfiguration();

                                var result = await wsconfi.Create1token("WebApi_PagosPro", "w3bp4g4dmg0s!", "password", "b60c00fd-87b7-4c98-9bf8-684fbc02cdc6");
                                var token = JsonConvert.DeserializeObject<Token>(result);

                                if (!string.IsNullOrEmpty(token.Access_token))
                                {
                                    var response = await wsconfi.Balanceservice(token.Access_token, 1085194, "287005");
                                    var balance = JsonConvert.DeserializeObject<Balance>(response);
                                 await Navigation.PushAsync(new Dashboard(balance));
                                    
                                }
                                else
                                {
                                    await DisplayAlert("¡Usuario no encontrado!", "Intente de nuevo", "Ok");
                                }
                            }
                            catch (Exception ex)
                            {
                                var error = ex.ToString();
                              await DisplayAlert("UPS hay un error!! ;(", error, "Ok");
                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                var error = ex.ToString();
              await  DisplayAlert("UPS hay un error!! ;(", error, "Ok");
            }

        }
    }
}
