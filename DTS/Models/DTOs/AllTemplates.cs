﻿using DTS.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS.Models
{
    public class AllTemplates
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TemplateState { get; set; }
        public int VersionCount { get; set; }
        public UserDTO Owner { get; set; }
    }
}