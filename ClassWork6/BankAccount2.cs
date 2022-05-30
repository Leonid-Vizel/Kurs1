namespace ClassWork6
{
    class BankAccount2
    {
        private long ID;
        private decimal balance;
        private accountType type;
        private static int IDcounter = 0;
        public BankAccount2(decimal balance, accountType type)
        {
            ID = IDcounter++;
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
}