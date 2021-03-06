using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricsLib
{
    public class TinkoffBankAccount : BankAccount
    {
        internal TinkoffBankAccount(decimal balance = 0, accountType type = accountType.Current) : base(balance, type) {/*Nothing*/}

        public override string ToString() => $"{base.ToString()}\nБанк: Тинькофф";
    }
}
