using SQLite;
using System.Runtime.InteropServices;

namespace CreditMaster.Models
{
    public class Acstudent
    {
        [PrimaryKey, AutoIncrement]
        public int acId { get; set; }

        public string acName { get; set; } = String.Empty;

        public string actype { get; set; } = String.Empty;

        public string aclevel { get; set; } = String.Empty;

        public string aclprize { get; set; } = String.Empty;

        public string acimg { get; set; } = String.Empty;

        public string actime { get; set; } = String.Empty;

        private string _info;

        [Ignore]
        public string Info => _info ??= aclprize.Split('.')[0];

    }
} 
