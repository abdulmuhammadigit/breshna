using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pro.ViewModels.Rent
{
    class RentShowListViewModel
    {
        [JsonProperty("Id")]
        public int? Id { get; set; }

        [Display(Name = "نام"), JsonProperty("نام")]
        public string Name { get; set; }

        [Display(Name = "نمبر فارم"), JsonProperty("نمبر فارم")]
        public string FormNumber { get; set; }


        [Display(Name = "نام پدر"), JsonProperty("نام پدر")]
        public string FatherName { get; set; }

        [Display(Name = "تخلص"), JsonProperty("تخلص")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربر"), JsonProperty("نام کاربر")]
        public string UserName { get; set; }



        [Display(Name = "ایمیل آدرس"), JsonProperty("ایمیل آدرس")]
        public string EmailAddress { get; set; }


        [Display(Name = "شماره تماس"), JsonProperty("شماره تماس")]
        public int Phone { get; set; }




        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [Display(Name = "تاریخ ثبت"), JsonProperty("تاریخ ثبت")]
        public string PersianRegisterDateTime { get; set; }


    }
}
