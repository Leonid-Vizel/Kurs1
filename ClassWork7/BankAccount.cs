namespace ClassWork7
{
    class BankAccount
    {
        private long ID;
        private decimal balance;
        private accountType type;
        private static int IDcounter = 0;
        public BankAccount(decimal balance, accountType type)
        {
            ID = IDcounter++;
            this.balance = balance;
            this.type = type;
        }

        public long GetID() => ID;
        public decimal GetBalance() => balance;
        public decimal Withdraw(decimal inputValue)
        {
            if (balance < inputValue)
            {
                return 0;
            }
            else
            {
                balance -= inputValue;
                return inputValue;
            }
        }
        public void Add(decimal inputValue) => balance += inputValue;
        public accountType GetAccType() => type;
        public void SetType(accountType type) => this.type = type;

        public bool SendMoney(BankAccount receiver, decimal value)
        {
            bool result = balance >= value;
            receiver.Add(Withdraw(value));
            return result;
        }

        public override string ToString()
        {
            return $"Информация о счёте #{ID}\nТип: {type}\nБаланс: {balance} условных единиц";
        }
    }

    enum accountType
    {
        Current = 0,
        Savings = 1
    }
}
