﻿using PublicTransport.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IUserService
    {
        public string IdByUser(string userId);

        public UserDetailsModel UserDetails(string id);
    }
}
