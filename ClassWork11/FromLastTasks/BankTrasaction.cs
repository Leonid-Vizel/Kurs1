using System;

namespace ClassWork11
{
    class BankTrasaction
    {
        public long ID { get; }
        public long SenderID { get; }
        public long ReceiverID { get; }
        public decimal Value { get; }
        public DateTime TimeExecuted { get; }

        private static long counterID = 0;

        static BankTrasaction() => counterID = 0;

        public BankTrasaction(long senderID, long receiverID, decimal value, DateTime timeExecuted)
        {
            ID = counterID++;
            SenderID = senderID;
            ReceiverID = receiverID;
            Value = value;
            TimeExecuted = timeExecuted;
        }

        public BankTrasaction(long senderID, long receiverID, decimal value)
        {
            ID = counterID++;
            SenderID = senderID;
            ReceiverID = receiverID;
            Value = value;
            TimeExecuted = DateTime.Now;
        }

        public override string ToString()
        {
            if (SenderID == -1 && ReceiverID != -1)
            {
                return $"Транзакция #{ID}|Пополнение счёта [ID:{SenderID}]. Сумма пополнения: {Value} условных единиц|Была произведена {TimeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
            else if(SenderID != -1 && ReceiverID == -1)
            {
                return $"Транзакция #{ID}|Снятие со счёта [ID:{SenderID}]. Сумма снятия: {Value} условных единиц|Была произведена {TimeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
            else if(SenderID == -1 && ReceiverID == -1)
            {
                return $"Транзакция #{ID}|ОШИБКА";
            }
            else
            {
                return $"Транзакция #{ID}|От [ID:{SenderID}] к [ID:{ReceiverID}]|Сумма перевода: {Value} условных единиц|Была произведена {TimeExecuted:dd.MM.yyyy (HH:mm:ss)}";
            }
        }
    }
}
