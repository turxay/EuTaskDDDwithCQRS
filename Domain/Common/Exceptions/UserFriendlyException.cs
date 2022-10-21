﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions
{
    internal class UserFriendlyException : Exception
    {
        public UserFriendlyException(string errorMessage) : this(errorMessage, null)
        {

        }
        public UserFriendlyException(string errorMessage, Exception exc) : base($"The following error occurred \"{errorMessage}\"", exc)
        {

        }
    }
}
