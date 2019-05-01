using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.Model
{
    public class Token : ModelBaseResponse
    {
        #region Members
        private string refresh_token;
        private string scope;
        private string jti;
        private string error;
        private string error_description;

        public string access_token;
        public string token_type;
        public string expires_in;
        public int Expires;

        public string UserName { get; set; }
        public string Issued { get; set; }
        public string KEY { get; set; }
        public string VALUE { get; set; }
        #endregion

        #region Properties

        public string Access_token { get => access_token; set => access_token = value; }
        public string Token_type { get => token_type; set => token_type = value; }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        public int Expires_in { get => Expires; set => Expires = value; }
        public string Scope { get => scope; set => scope = value; }
        public string Jti { get => jti; set => jti = value; }
        public string Error { get => error; set => error = value; }
        public string Error_description { get => error_description; set => error_description = value; }
        #endregion
    }
}
