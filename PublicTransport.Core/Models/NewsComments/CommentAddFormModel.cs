﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.NewsComments
{
    public class CommentAddFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(500, ErrorMessage = "{0} трябва да бъде по-късo от {1} символа")]
        [Display(Name = "Съдържание")]

        public string Content { get; set; }
    }
}
