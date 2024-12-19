using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Lütden Oda Numarasını Yazınız")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütden Fiyat Bilgisini Yazınız")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütden Oda Başlığını Yazınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütden Yatak Sayısını Yazınız")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütden Banyo Sayısını Yazınız")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
