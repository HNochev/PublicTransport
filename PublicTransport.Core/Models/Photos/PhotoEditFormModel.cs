﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Photos
{
    public class PhotoEditFormModel
    {
        [StringLength(500)]
        [Display(Name = "Описание на снимката")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата на снимката")]
        public DateTime DateOfPicture { get; set; }

        [StringLength(100)]
        [Display(Name = "Място на снимката")]
        public string? Location { get; set; }

        [Display(Name = "Аз съм автор на тази снимка")]
        public bool IsAuthor { get; set; }

        [StringLength(500)]
        [Display(Name = "Пояснения към администратор")]
        public string? UserMessage { get; set; }

        public Guid Id { get; set; }

        public string ImgUrlFormDatabase { get; set; }

        public bool IsApproved { get; set; }
    }
}