using Me.WLF.IDAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Models;

namespace ChatCore.Patterns.Validators
{
    public class ChineseLastNameValidator : IValidator
    {
        [Inject]
        public IChineseLastNameRepositary ChineseLastNameRepositary { get; set; }

        public bool Valid(string value, List<ErrorCodes> msg)
        {
            msg = new List<ErrorCodes>();

            if (string.IsNullOrEmpty(value))
                msg.Add(ErrorCodes.CHINESE_NAME_EMPTY);
            else if (value.Length < 2)
                msg.Add(ErrorCodes.CHINESE_NAME_LENGTH_LESS_THAN_2);
            else if (value.Length > 10)
                msg.Add(ErrorCodes.CHINESE_NAME_LENGTH_MORE_THAN_10);
            else if (!ChineseLastNameRepositary.ValidChineseLastNames.Contains(value.Substring(0, 1)))
                msg.Add(ErrorCodes.CHINESE_NAME_LAST_NAME_IS_INVALID);

            return msg.Count == 0;
        }
    }
}
