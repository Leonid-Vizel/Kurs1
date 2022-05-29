using System;

namespace ClassWork7
{
    class BankTrasaction
    {
        public readonly long ID;
        public readonly long senderID;
        public readonly long receiverID;
        public readonly decimal value;
        public readonly DateTime timeExecuted;

        private static long counterID = 0;

        static BankTrasaction()
        {
            counterID = 0;
        }

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
            else if (senderID != -1 && receiverID == -1)
            {
                return $"Транзакция #{ID}|Снятие со счёта [ID:{senderID}]. Сумма снятия: {value} условных единиц|Была произведена {timeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
            else if (senderID == -1 && receiverID == -1)
            {
                return $"Транзакция #{ID}|ОШИБКА";
            }
            else
            {
                return $"Транзакция #{ID}|От [ID:{senderID}] к [ID:{receiverID}]|Сумма перевода: {value} условных единиц|Была произведена {timeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is BankAccount)
            {
                BankTrasaction instance = obj as BankTrasaction;
                return (senderID == instance.senderID) && (receiverID == instance.receiverID) && (value == instance.value) && (timeExecuted == instance.timeExecuted);
            }
            else
            {
                return false;
            }
        }
    }
}
