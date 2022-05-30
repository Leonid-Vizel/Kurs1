using System;

namespace ClassWork11
{
    class BankTrasaction
    {
        public long ID { get; }
        public long senderID { get; }
        public long receiverID { get; }
        public decimal value { get; }
        public DateTime timeExecuted { get; }

        private static long counterID = 0;

        static BankTrasaction() => counterID = 0;

        public BankTrasaction(long senderID, long receiverID, decimal value, DateTime timeExecuted)
        {
            //Нельзя написать DateTime timeExecuted = DateTime.Now, так как выражение справа(дефолтное значение) должно быть константой компиляции
            ID = counterID++;
            this.senderID = senderID;
            this.receiverID = receiverID;
            this.value = value;
            this.timeExecuted = timeExecuted;
        }

        public BankTrasaction(long senderID, long receiverID, decimal value)
        {
            ID = counterID++;
            this.senderID = senderID;
            this.receiverID = receiverID;
            this.value = value;
            timeExecuted = DateTime.Now;
        }

        public override string ToString()
        {
            if (senderID == -1 && receiverID != -1)
            {
                return $"Транзакция #{ID}|Пополнение счёта [ID:{senderID}]. Сумма пополнения: {value} условных единиц|Была произведена {timeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
            else if(senderID != -1 && receiverID == -1)
            {
                return $"Транзакция #{ID}|Снятие со счёта [ID:{senderID}]. Сумма снятия: {value} условных единиц|Была произведена {timeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
            else if(senderID == -1 && receiverID == -1)
            {
                return $"Транзакция #{ID}|ОШИБКА";
            }
            else
            {
                return $"Транзакция #{ID}|От [ID:{senderID}] к [ID:{receiverID}]|Сумма перевода: {value} условных единиц|Была произведена {timeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
        }
    }
}
