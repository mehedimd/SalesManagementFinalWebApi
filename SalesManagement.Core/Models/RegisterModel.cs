﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Core.Models
{
    public class RegisterModel
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
