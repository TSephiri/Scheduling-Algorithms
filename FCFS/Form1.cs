﻿using System;
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
        List<Process> processList = new List<Process>();
        int totalBurst = 0;

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
            processList.Add(temp);

            //add burst times to total
            totalBurst += temp.burstTime;

            //display added process to textbox
            displayProcess(temp.name, temp.priority, temp.arrivalTime, temp.burstTime);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dataGridInit();
            initRows();
        }

        //initialise grid with total burst time;
        private void dataGridInit()
        {
            //creating process name column
            DataGridViewTextBoxColumn columnName = new DataGridViewTextBoxColumn();
            columnName.ReadOnly = true;
            columnName.Name = "Process";
            columnName.Resizable = DataGridViewTriState.False;
            //column1.SortMode = DataGridViewColumnSortMode.Automatic;
            columnName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnName.HeaderText =  "Process";
            columnName.Width = 100;

            //adding column to dataGridView
            dataGridView1.Columns.Add(columnName);
            //creating new columns
            for (int i = 1; i <= totalBurst; i++) { 
                DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                column1.ReadOnly = true;
                column1.Name = i+"";
                column1.Resizable = DataGridViewTriState.False;
                //column1.SortMode = DataGridViewColumnSortMode.Automatic;
                column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column1.HeaderText = i+"";
                column1.Width = 100;

                //adding column to dataGridView
                dataGridView1.Columns.Add(column1);
            }
        }
        //init rows in grid based on processes
        private void initRows()
        {
            foreach (Process p in processList)
            {
                dataGridView1.Rows.Add(p.name);
            }
        }
        
        private void displayInGrid()
        {
            List<Process> tempList = processList;
            int min = 0;
            int index = 0;
            foreach(Process p in tempList){
                if (p.arrivalTime < min)
                {
                    min = p.arrivalTime;
                    index = tempList.IndexOf(p);
                    
                }  
            }
        }


    }
}
