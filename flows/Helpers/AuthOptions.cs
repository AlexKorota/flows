using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace flows.Helpers
{
    public class AuthOptions
    {
		public const string ISSUER = "Flows";
		public const string AUDIENCE = "FlowsUser";
		const string KEY = "authentification_security_key!qwe123";
		public const int LIFETIME = 60;
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
		}
	}
}
