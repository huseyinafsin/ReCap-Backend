﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SystemDto<T> where T : new()
    {
        public string Name { get; set; }

    }
}
