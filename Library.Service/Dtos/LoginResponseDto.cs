﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Dtos
{
    public class LoginResponseDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
