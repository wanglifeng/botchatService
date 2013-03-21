using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Models
{
    public enum ErrorCodes
    {
        CHINESE_NAME_EMPTY,
        CHINESE_NAME_LENGTH_LESS_THAN_2,
        CHINESE_NAME_LENGTH_MORE_THAN_10,
        CHINESE_NAME_LAST_NAME_IS_INVALID
    }
}
