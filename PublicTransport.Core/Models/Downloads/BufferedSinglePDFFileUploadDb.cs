using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Downloads
{
    public class BufferedSinglePDFFileUploadDb
    {
        [Required]
        [Display(Name = "Качете PDF файл")]
        public IFormFile FilePDF { get; set; }
    }
}
