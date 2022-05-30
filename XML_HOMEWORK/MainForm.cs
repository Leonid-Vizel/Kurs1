using System;
using System.IO;
using System.Windows.Forms;

namespace XML_HOMEWORK
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BaggageRepository repository;
            try
            {
                using (MemoryStream stream = new MemoryStream(File.ReadAllBytes("BaggageRepository.xml")))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BaggageRepository));
                    repository = (BaggageRepository)serializer.Deserialize(stream);
                }
            }
            catch
            {
                BaggageRepository.Generate();
            }
            using (MemoryStream stream = new MemoryStream(File.ReadAllBytes("BaggageRepository.xml")))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BaggageRepository));
                repository = (BaggageRepository)serializer.Deserialize(stream);
            }
            //Заполняю таблицу работников
            foreach (Worker worker in repository.Workers)
            {
                workersDataGridView.Rows.Add(new object[5] { worker.Id, worker.Name, worker.Age, worker.Sex, worker.Profession });
            }
            //Заполняю таблицу посетителей
            foreach (Visitor visitor in repository.Visitors)
            {
                visitorGridView.Rows.Add(new object[8] { visitor.Id, visitor.Name, visitor.Age, visitor.Sex, visitor.Cash, visitor.Aim, visitor.Days, visitor.Baggage.Weight });
            }
            //Заполняю таблицу хранилища
            foreach (Cell cell in repository.Cells)
            {
                cellsGridView.Rows.Add(new object[6] { cell.Id, cell.WeightLimit, cell.Baggage.Id, cell.Baggage.OwnerId, cell.Baggage.Weight, cell.Baggage.Color });
            }
            //Загрузка прочей информации
            locationLabel.Text += repository.Location;
            maxQueueLabel.Text += repository.MaxQueue;
            profitLabel.Text += repository.Profit;
        }
    }
}
