using APIBanHang.Data;
using System.Linq;
using System.Threading;
using CsvHelper.Configuration.Attributes;
namespace APIBanHang.Models
{
    public class MAccount
    {
        public string MaAccount { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwords { get; set; } = string.Empty;
    }
}
