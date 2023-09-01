using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AspMVC_WebApi.Models
{
    public class giris
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Bırakılamaz"),DisplayName("Kullanıcı Adını Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage ="Şifre Boş Bırakılamaz"),DisplayName("Şifre Giriniz") ,DataType(DataType.Password)]
        public string password { get; set; }
    }
}