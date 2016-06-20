using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repositories
{
    public class AvailableAnswerRepository : RepositoryBase, IRepository<AvailableAnswer>
    {
        public AvailableAnswerRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public AvailableAnswer Add(AvailableAnswer entity)
        {
            throw new NotImplementedException();
        }

        public AvailableAnswer[] AddRange(AvailableAnswer[] entities)
        {
            AvailableAnswer[] answers = this.DataContext.AvailableAnswer.AddRange(entities).ToArray();
            this.DataContext.SaveChanges();
            return answers;
        }

        public void Delete(AvailableAnswer entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(AvailableAnswer[] entities)
        {
            this.DataContext.AvailableAnswer.RemoveRange(entities);
        }

        public AvailableAnswer Get(int id)
        {
            return this.DataContext.AvailableAnswer.SingleOrDefault(aa => aa.ID == id);
        }

        public AvailableAnswer[] List()
        {
            throw new NotImplementedException();
        }

        public AvailableAnswer[] List(int questionID)
        {
            return this.DataContext.AvailableAnswer
                .Where(aa => aa.QuestionID == questionID)
                .ToArray();
        }

        public void Update(AvailableAnswer entity)
        {
            throw new NotImplementedException();
        }
    }
}
