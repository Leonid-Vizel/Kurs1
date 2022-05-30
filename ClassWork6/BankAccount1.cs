namespace ClassWork6
{
    class BankAccount1
    {
        private long ID;
        private decimal balance;
        private accountType type;

        public BankAccount1(long ID, decimal balance, accountType type)
        {
            this.ID = ID;
            this.balance = balance;
            this.type = type;
        }

        public long GetID() => ID;
        public decimal GetBalance() => balance;
        public accountType GetAccType() => type;
        public void setType(accountType type) => this.type = type;

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