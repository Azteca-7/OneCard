using Cards.DataBase.SQLite;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cards.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckIn : ContentPage
    {
       
        public CheckIn()
        {
            InitializeComponent();
        }

        private async void Button_ClickedCheckin(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)

                    await DisplayAlert("UPS hay un error!! ;(", "Habilite su internet", "OK");
                else

                {
                    if (String.IsNullOrWhiteSpace(Email_Entry.Text))
                    {
                        await DisplayAlert("Error de Validación!", "Email Obligatorio", "OK");

                    }

                    //else
                    //{
                    //Valida que el formato del correo sea valido
                    bool isEmail = Regex.IsMatch(Email_Entry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (!isEmail)
                    {
                        await DisplayAlert("Error de Validación!", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                    }

                    if (String.IsNullOrWhiteSpace(Password_Entry.Text))
                    {
                        await DisplayAlert("Error de Validación!", "Contraseña Obligatorio", "OK");
                    }

                    if (String.IsNullOrWhiteSpace(ConfirmationPassword_Entry.Text))
                    {
                        await DisplayAlert("Error de Validación!", "Confirmar Contraseña Obligatorio", "OK");
                    }


                    if (String.IsNullOrWhiteSpace(card_Entry.Text))
                    {
                        await DisplayAlert("Error de Validación!", "No. Tarjeta Obligatorio", "OK");
                    }
                    //Valida que solo se ingresen numeros
                    if (!card_Entry.Text.ToCharArray().All(Char.IsDigit))
                    {
                        await this.DisplayAlert("Advertencia", "El formato de la  tarejta es incorrecto, solo se aceptan numeros.", "OK");
                    }

                    if (card_Entry.Text.Length != 16)
                    {
                        await this.DisplayAlert("Advertencia", "Faltan digitos, favor de ingresar los 16 digitos.", "OK");
                    }
                    else
                    {
                        try
                        {
                            //Insert Sqlite
                           
                            var Email_v = Email_Entry.Text;
                            var Pass_v = Password_Entry.Text;
                            var ConfirPass_v = ConfirmationPassword_Entry.Text;
                            var Card_v = card_Entry.Text;
                            
                            CrudSqlite crudsqlite_obj = new CrudSqlite();
                            crudsqlite_obj.AddUserAppSqlite(Email_v,Pass_v, ConfirPass_v, Card_v);

                        }
                        catch (Exception ex)
                        {
                            var error = ex.ToString();
                            await DisplayAlert("UPS hay un error!! ;(", error, "Ok");
                        }


                    }
                    //  }
                }

            }
            catch (Exception ex)
            {

                var error = ex.ToString();


            }

        }
    }
}