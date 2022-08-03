﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Entities
{
    public class Setting
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; } = null;
    }
}
