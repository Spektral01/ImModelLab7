using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImModelLab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool isStart=false;
        public double Doctors, LifeQual, AllPatients;
        public double  dt = 0.1;
        private void button1_Click(object sender, EventArgs e)
        {
            Doctors = (double)DocEd.Value;
            LifeQual = (double)LifeEd.Value;
            AllPatients = (double)PatientEd.Value;

            if (!isStart)
            {
                isStart = true;
                timer1.Start();
            }
            else
            {
                isStart = false;
                timer1.Stop();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public double viruses=10, factory=10, docInfect=5, patientInfect=15, healthyPerson=0, medicine=100, medicineForHospital=5, trash=0;
        public int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            viruses = viruses + (factory - AllPatients)*1.6;
            factory = factory+(LifeQual*0.2);
            AllPatients = AllPatients + viruses - patientInfect; 
            patientInfect = patientInfect + (AllPatients + Doctors - healthyPerson)*1.6;
            Doctors = Doctors + LifeQual;
            docInfect = Doctors * 0.5 + patientInfect * 2 + docInfect;
            healthyPerson = healthyPerson + (patientInfect+medicineForHospital)*0.03;
            medicine = medicine + factory * 1.2 - medicineForHospital * 0.5;
            medicineForHospital = medicineForHospital + (medicine - trash) * 0.5;
            trash = trash + medicineForHospital * 0.2;
            chart1.Series[0].Points.AddXY(i, healthyPerson);
            chart1.Series[1].Points.AddXY(i, viruses);
            chart1.Series[2].Points.AddXY(i, patientInfect);
            i++;

        }
    }
}
