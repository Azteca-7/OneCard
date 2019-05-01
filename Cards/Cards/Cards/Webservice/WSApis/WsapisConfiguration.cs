using Cards.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Cards.Model.Interface;
using System.Net;
using System.IO;

namespace Cards.Webservice.WSApis
{
    public class WsapisConfiguration
    {
        HttpClient clien = new HttpClient();
        //Crea el token

        public async Task<string> Create1token(string WebApiPPro_, string w3b_, string passw_, string b60c_)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                { "username", WebApiPPro_ },
                { "password", w3b_},
                { "grant_type", passw_ },
                { "appId", b60c_ }
            };
                var content = new FormUrlEncodedContent(values);
                var response = clien.PostAsync("https://www.onecardservicios.mx/Extranet/Services/OneCard_WhiteLabel/Token", content).Result;
                var result = await response.Content.ReadAsStringAsync();
                
                return result;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                return error;
            }
        }

        public async Task<string> DoToken(string WebApiPPro_, string w3b_, string passw_, string b60c_)
        {
            try
            {
                Uri geturi = new Uri("https://www.onecardservicios.mx/Extranet/Services/OneCard_WhiteLabel/Token"); //replace your xml url 
                clien.BaseAddress = new Uri(geturi.ToString());
                clien.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var input = new TokenRequest() { username = WebApiPPro_, password = w3b_, grant_type = passw_, appId = b60c_ };
                string json = JsonConvert.SerializeObject(input);

                var response = await clien.PostAsync(geturi, new StringContent(json, Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                return ex.ToString();
            }

        }

        //Service Balance
        public async Task<string> Balanceservice(string TokenAutorization, long AccountId_V, string CardNumber_V)
        {
            try
            {
                Uri geturi = new Uri("https://www.onecardservicios.mx/Extranet/Services/OneCard_WhiteLabel/api/Cards/Balance"); //replace your xml url 
                clien.BaseAddress = new Uri(geturi.ToString());
                clien.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                clien.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAutorization);

                var input = new BalanceRequest() { AccountId = AccountId_V, CardNumber = CardNumber_V };
                string json = JsonConvert.SerializeObject(input);

                var response = await clien.PostAsync(geturi, new StringContent(json, Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                return result;

            }
            catch (Exception ex)
            {
                var error = ex.ToString();
               return error;
            }
        }
    }

    #region Clases Input
    public class TokenRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public string appId { get; set; }
    }
    public class BalanceRequest
    {
        public long AccountId { get; set; }
        public string CardNumber { get; set; }
    }
    #endregion

}
