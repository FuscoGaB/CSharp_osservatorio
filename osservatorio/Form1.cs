namespace osservatorio
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int partecipanteCorrente = 0;
        private int tempoRimanente = 10;
        private Partecipante[] partecipanti = new Partecipante[10];
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
        }

        public class Partecipante
        {
            public string Nome { get; set; }
            public string Stato { get; set; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tempoRimanente--;
            int minuti = tempoRimanente / 60;
            int secondi = tempoRimanente % 60;
            partecipanti[partecipanteCorrente].Stato = $"Osservando {minuti:D2}:{secondi:D2}";

            if (tempoRimanente <= 0)
            {
                partecipanti[partecipanteCorrente].Stato = "Finito";
                partecipanteCorrente++;
                tempoRimanente = 10;

                if (partecipanteCorrente < 10)
                {
                    partecipanti[partecipanteCorrente].Stato = "Osservazione";
                }
                else
                {
                    timer.Stop();
                }
            }

            aggiornaUI();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                partecipanti[0].Stato = "Osservazione";
                timer.Start();
            }
        }

        private void aggiornaUI()
        {
            for (int i = 0; i < 10; i++)
            {
                //Label label = Controls.Find("label" + (i + 1), true).FirstOrDefault() as Label;
                //if (label != null)
                //{
                //    label.Text = partecipanti[i].Nome + ": " + partecipanti[i].Stato;
                //}
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                partecipanti[i] = new Partecipante
                {
                    Nome = "Partecipante " + (i + 1),
                    Stato = "In attesa"
                };
            }

            aggiornaUI();
        }
    }
}
