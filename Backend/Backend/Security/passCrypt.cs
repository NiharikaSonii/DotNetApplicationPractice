using System.Text;

namespace Backend.Security
{
    public class passCrypt
    {
        public string Key { get; set; }
        public passCrypt(string s) {
            byte[] encode = new byte[s.Length];
            encode = Encoding.UTF8.GetBytes(s);
            Key = Convert.ToBase64String(encode);
        }
    }
}
