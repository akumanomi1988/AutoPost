using AutoPost.AnimationCanvas.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Models
{
    public class UserInfo
    {
        public string UserId { get; set; } = "";
        public long Likes { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsActive { get; set; }
        public string LastColor { get; set; } = "White";
        public BallElement? ball { get; set; }

        // Nuevas interacciones
        public int Shares { get; set; } = 0;
        public int Follows { get; set; } = 0;
        public int Gifts { get; set; } = 0;
        public int Comments { get; set; } = 0;
        public int Emotes { get; set; } = 0;

        // Métodos para incrementar los contadores
        public void AddShare() => Shares++;
        public void AddFollow() => Follows++;
        public void AddGift(int amount) => Gifts += amount;
        public void AddComment() => Comments++;
        public void AddEmote() => Emotes++;
    }
}
