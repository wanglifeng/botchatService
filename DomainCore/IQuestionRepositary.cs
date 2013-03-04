using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace DomainCore
{
    public interface IQuestionRepositary
    {
        Question GetByQuestion(string q);

        void Save(Question q);

        List<Question> List();
    }
}
