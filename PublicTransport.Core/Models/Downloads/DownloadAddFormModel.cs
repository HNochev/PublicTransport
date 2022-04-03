using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Downloads
{
    public class DownloadAddFormModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Заглавие на качваният файл")]
        public string FileName { get; set; }

        [StringLength(100)]
        [Display(Name = "Описание на файлът")]
        public string? Description { get; set; }

        [BindProperty]
        public BufferedSinglePDFFileUploadDb FileUpload { get; set; }
    }
}
