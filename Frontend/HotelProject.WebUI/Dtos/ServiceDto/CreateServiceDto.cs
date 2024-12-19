namespace HotelProject.WebUI.Dtos.ServiceDto

{
    using System.ComponentModel.DataAnnotations;
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Servis İkonu Giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Servis Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Servis Başlığı En Fazla 100 Karakter Olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Servis Açıklama Giriniz")]
        [StringLength(400, ErrorMessage = "Servis Açıklaması En Fazla 400 Karakter Olabilir.")]
        public string Description { get; set; }
    }
}
 