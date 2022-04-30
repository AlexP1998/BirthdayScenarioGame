using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdayScenarioGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int MONTH_SCENARIOS_SIZE = 12; //Size of monthScenarios array.
            const int DAY_SCENARIOS_SIZE = 31; //Size of dayScenarios array.

            int month; //User-defined month.
            int day; //User-defined day.
            string scenario; //Computer-generated scenario.

            int index = 0; //Index to go through slots in array.

            //declare arrays.
            string[] monthScenarios = new string[MONTH_SCENARIOS_SIZE];
            string[] dayScenarios = new string[DAY_SCENARIOS_SIZE];

            StreamReader inputFile; //Declare variable to read files.

            //Read the MonthScenarios.txt file.
            inputFile = File.OpenText("MonthScenarios.txt"); //Open MonthScenarios.txt.
            while (index < monthScenarios.Length && !inputFile.EndOfStream) //While the index is less than monthScenarios.Length and the input file isn't at the end...
            {
                monthScenarios[index] = inputFile.ReadLine(); //Read the current line and set it equal to the current index in monthScenarios.
                index++; //Advance the index counter by one.
            }
            inputFile.Close(); //Close the file.

            index = 0; //Reset index counter to zero.

            //Read the DayScenarios.txt file.
            inputFile = File.OpenText("DayScenarios.txt"); //Open DayScenarios.txt.
            while (index < dayScenarios.Length && !inputFile.EndOfStream) //While the index is less than dayScenarios.Length and the input file isn't at the end...
            {
                dayScenarios[index] = inputFile.ReadLine(); //Read the current line and set it equal to the current index in dayScenarios.
                index++; //Advance the index counter by one.
            }
            inputFile.Close(); //Close the file.

            try
            {
                month = int.Parse(monthTextBox.Text) - 1; //Retrieve value from the month text box.
                day = int.Parse(dayTextBox.Text) - 1; //Retreive value from the day text box.
                scenario = monthScenarios[month] + dayScenarios[day]; //Create the scenario.
                scenarioLabel.Text = scenario; //Display the scenario.
            }
            catch
            {
                MessageBox.Show("Please enter a valid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
