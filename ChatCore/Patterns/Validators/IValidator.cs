using ChatCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns.Validators
{
    interface IValidator
    {
        bool Valid(string value, List<ErrorCodes> msg);
    }
}
