using ChatCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns
{
    public interface IPatternManager
    {
        bool IsChineseLastName(string value);
        bool IsSearchStartPattern(string value);
        bool IsUserProfileStart(string value);
        bool IsNewRegisterUser(string value);
        bool IsFeedBackPattern(string value);

        List<ErrorCodes> ValidMessages { get; }

        bool IsGoToNextPage(string p);

        bool IsGoToPrePage(string p);
    }
}
