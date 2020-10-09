using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCFS
{
    public partial class Form1 : Form
    {
        List<Process> processList;

        public Form1()
        {
            InitializeComponent();
            txtDisplay.Text = "Process \t Priority \t Arrival \t Burst ";
        }

        private void addProcess()
        {

        }

        private void displayProcess(string name,int p,int aT,int bT)
        {
            string newLine = Environment.NewLine;
            txtDisplay.AppendText(newLine + name+"\t"+p+"\t"+aT+"\t"+bT);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Process temp = new Process();
            temp.name = txtName.Text;
            temp.priority = Convert.ToInt32(txtPriority.Text);
            temp.arrivalTime = Convert.ToInt32(txtArrival.Text);
            temp.burstTime = Convert.ToInt32(txtBurst.Text);
            displayProcess(temp.name, temp.priority, temp.arrivalTime, temp.burstTime);
        }

        //private List<Person> getProcesses(){

        //    return;
        //}

    }
}
