namespace ClassWork6
{
    class BankAccount3
    {
        private long ID;
        private decimal balance;
        private accountType type;
        private static int IDcounter = 0;
        public BankAccount3(decimal balance, accountType type)
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
        public void setType(accountType type) => this.type = type;

        public override string ToString()
        {
            return $"Информация о счёте #{ID}\nТип: {type}\nБаланс: {balance} условных единиц";
        }
    }
}