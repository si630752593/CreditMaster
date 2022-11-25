using CreditMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditMaster.Services
{
    public interface IAcstuentStorage
    {
        bool IsIntialize { get; }
        Task Intialize();

        Task AddAsync(Acstudent acstudent);

        Task<IEnumerable<Acstudent>> ListAsync();

        Task<Acstudent> GetByIdAsync(int id);

        Task<IEnumerable<Acstudent>> GetAcstudentsAsync(
            Expression<Func<Acstudent, bool>> where,int skip, int take);
         
    }
}
