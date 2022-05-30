using System.Collections.Generic;
using System.IO;

namespace XML_HOMEWORK
{
    [System.Xml.Serialization.XmlRoot("BaggageRepository")]
    public class BaggageRepository
    {
        [System.Xml.Serialization.XmlElement("Location")]
        public string Location { get; set; }
        [System.Xml.Serialization.XmlElement("BaggageCells")]
        public List<Cell> Cells { get; set; }
        [System.Xml.Serialization.XmlElement("Workers")]
        public List<Worker> Workers { get; set; }
        [System.Xml.Serialization.XmlElement("Visitors")]
        public List<Visitor> Visitors { get; set; }
        [System.Xml.Serialization.XmlElement("QueueLimit")]
        public int MaxQueue { get; set; }
        [System.Xml.Serialization.XmlElement("Profit")]
        public int Profit { get; set; }

        public static void Generate()
        {
            BaggageRepository repository = new BaggageRepository()
            {
                Location = "Улица Пушкина Дом Колотушника",
                Workers = new List<Worker>()
                {
                    new Worker()
                    {
                        Id = 0,
                        Name = "Вася Пупкин",
                        Age = 22,
                        Sex = Sex.Man,
                        Profession = Profession.Security
                    },
                    new Worker()
                    {
                        Id = 1,
                        Name = "Вера Иванова",
                        Age = 23,
                        Sex = Sex.Woman,
                        Profession = Profession.Cashier
                    },
                    new Worker()
                    {
                        Id = 2,
                        Name = "Абоба Абибов",
                        Age = 24,
                        Sex = Sex.TransGender,
                        Profession = Profession.Security
                    }
                },
                Visitors = new List<Visitor>()
                {
                    new Visitor()
                    {
                        Id = 3,
                        Name = "1Вася Пупкин1",
                        Age = 22,
                        Sex = Sex.Man,
                        Cash = 100,
                        Baggage = new Baggage()
                        {
                            Id = 0,
                            OwnerId = 3,
                            Weight = 25,
                            Color = "#008800",
                            Inside = new string[2] { "Ботинок","Носок" }
                        },
                        Aim = Aim.Give,
                        Days = 10
                    },
                    new Visitor()
                    {
                        Id = 4,
                        Name = "2Вера Иванова2",
                        Age = 23,
                        Sex = Sex.Woman,
                        Cash = 100,
                        Baggage = new Baggage()
                        {
                            Id = 0,
                            OwnerId = 4,
                            Weight = 25,
                            Color = "#008800",
                            Inside = new string[2] { "Куртка","Кружка" }
                        },
                        Aim = Aim.Give,
                        Days = 10
                    },
                    new Visitor()
                    {
                        Id = 5,
                        Name = "3Абоба Абибов3",
                        Age = 24,
                        Sex = Sex.TransGender,
                        Cash = 100,
                        Baggage = new Baggage()
                        {
                            Id = 0,
                            OwnerId = 5,
                            Weight = 25,
                            Color = "#008800",
                            Inside = new string[2] { "Ковёр","Микрофон" }
                        },
                        Aim = Aim.Give,
                        Days = 10
                    }
                },
                Cells = new List<Cell>()
                {
                    new Cell()
                    {
                        Id = 0,
                        WeightLimit = 100,
                        Baggage = new Baggage()
                        {
                            Id = 100,
                            OwnerId = 228,
                            Weight = 99,
                            Color = "Классный цвет)))",
                            Inside = new string[3] { "Что-то одно", "Что-то другое", "Шлёпа)"}
                        }
                    },
                    new Cell()
                    {
                        Id = 1,
                        WeightLimit = 100,
                        Baggage = new Baggage()
                        {
                            Id = 101,
                            OwnerId = 228,
                            Weight = 99,
                            Color = "Классный цвет)))",
                            Inside = new string[3] { "Что-то одно", "Что-то другое", "Шлёпа)"}
                        }
                    },
                    new Cell()
                    {
                        Id = 2,
                        WeightLimit = 100,
                        Baggage = new Baggage()
                        {
                            Id = 102,
                            OwnerId = 228,
                            Weight = 99,
                            Color = "Классный цвет)))",
                            Inside = new string[3] { "Что-то одно", "Что-то другое", "Шлёпа)"}
                        }
                    }
                },
                MaxQueue = 12345,
                Profit = 1000000
            };
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(BaggageRepository));
            FileStream fileSream = File.Create("BaggageRepository.xml");
            writer.Serialize(fileSream, repository);
            fileSream.Close();
        }
    }
}
