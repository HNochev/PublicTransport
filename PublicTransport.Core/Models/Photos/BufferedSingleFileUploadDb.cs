using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Photos
{
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "Качете снимка")]
        public IFormFile PhotoFile { get; set; }
    }
}
