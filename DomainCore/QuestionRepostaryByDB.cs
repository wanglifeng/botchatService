using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class QuestionRepostaryByDB : IQuestionRepositary
    {
        public Models.Question GetByQuestion(string q)
        {
            using(var c = new ChatContext())
            {
                return c.Questions.FirstOrDefault(t=>t.Content.Contains(q));
            }
        }

        public void Save(Models.Question q)
        {
            using (var c = new ChatContext())
            {
                c.Questions.Add(q);
                c.SaveChanges();
            }
        }

        public List<Models.Question> List()
        {
            using (var c = new ChatContext())
            {
                return c.Questions.ToList();
            }
        }
    }
}
