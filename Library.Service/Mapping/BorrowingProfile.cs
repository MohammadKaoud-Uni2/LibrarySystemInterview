﻿using AutoMapper;
using Library.Service.Dtos;
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Mapping
{
    public  class BorrowingProfile:Profile
    {
        public BorrowingProfile()
        {
            CreateMap<Borrowing, GetBorrowedBookDto>();

        }
    }
}
