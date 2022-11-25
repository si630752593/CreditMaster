using CreditMaster.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditMaster.Services
{
    public class AcstuentStorage : IAcstuentStorage
    {
        public const string Dbfilename = "creditmasterdb.sqlite3";
        //const是常量 值是不会变的 

        //static是属于类的一部分
        public static readonly string creditmasterdbPath = 
            Path.Combine(
            Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData
            ), Dbfilename);

        private SQLiteAsyncConnection _connection;

        public SQLiteAsyncConnection Connection =>
            _connection ??= new SQLiteAsyncConnection(creditmasterdbPath);

        public bool IsIntialize => 
            Preferences.Get(CreditmasterdbConstant.VersionKey, 0) ==
            CreditmasterdbConstant.Version; //true

        public async Task AddAsync(Acstudent acstudent)
        {
          await Connection.InsertAsync(acstudent);
        }

        public async Task Intialize()
        {
            await Connection.CreateTableAsync<Acstudent>();
        }

        public async Task<IEnumerable<Acstudent>> ListAsync()
        {
            return await Connection.Table<Acstudent>().ToListAsync();
        }

        Task<IEnumerable<Acstudent>> IAcstuentStorage.GetAcstudentsAsync(Expression<Func<Acstudent, bool>> where, int skip, int take)
        {
            throw new NotImplementedException();
        }

        Task<Acstudent> IAcstuentStorage.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
    public static class CreditmasterdbConstant
    {
        public const int Version =1;
        public  const string VersionKey =
            nameof(CreditmasterdbConstant) + "." + nameof(Version);
    }
}
