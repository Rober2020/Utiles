﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspFiles.Models.ViewModel
{
    public class UploadModel
    {
        public IFormFile MyFile { get; set; }
    }
}
