using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Exceptions
{
    public class BankException : Exception
    {
        private readonly string name;

        public BankException(string name)
        {
            this.name = name;
        }
    }
}
