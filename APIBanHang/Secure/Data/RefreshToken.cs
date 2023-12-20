using APIBanHang.Data;
using APIBanHang.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBanHang.Secure.Data
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }

        public string MaAccount { get; set; } 
        [ForeignKey(nameof(MaAccount))]
        public Account account { get; set; }

        //refresh token
        public string Token { get; set; }
        //access token
        public string JwtID { get; set; }

        //đã sử dụng ?
        public bool IsUsed { get; set; }
        //đã thu hồi ?
        public bool IsRevoked { get; set; }
        //tạo ra ngày ?
        public DateTime IssuedAt { get; set; }
        //hết hạn lúc ?
        public DateTime ExpireAt { get; set; }

    }
}
