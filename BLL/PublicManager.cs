﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PublicManager
    {
        public static ExtraitPublic GetExtraitPublic()
        {
            return ExtraitPublicDB.GetExtraitPublic();
        } 

    }
}
