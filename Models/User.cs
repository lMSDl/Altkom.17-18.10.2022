﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
