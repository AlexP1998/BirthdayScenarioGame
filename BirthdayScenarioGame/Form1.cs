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
        const int MONTH_SCENARIOS_SIZE = 12; //Size of monthScenarios array.
        const int DAY_SCENARIOS_SIZE = 31; //Size of dayScenarios array.

        //declare arrays.
        string[] monthScenarios = new string[MONTH_SCENARIOS_SIZE];
        string[] dayScenarios = new string[DAY_SCENARIOS_SIZE];

        private void generateButton_Click(object sender, EventArgs e)
        {

            int month; //User-defined month.
            int day; //User-defined day.
            string scenario; //Computer-generated scenario.

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

        private void Form1_Load(object sender, EventArgs e) 
        {
            monthScenarios = ReadFile("monthScenarios.txt", MONTH_SCENARIOS_SIZE);
            dayScenarios = ReadFile("dayScenarios.txt", DAY_SCENARIOS_SIZE);
        }

        private string[] ReadFile(string fileName, int arraySize)
        {
            string[] outputArray = new string[arraySize];
            int index = 0; //Index to go through slots in array.

            StreamReader inputFile; //Declare variable to read files.

            //Read the MonthScenarios.txt file.
            try
            {
                inputFile = File.OpenText(fileName); //Open MonthScenarios.txt.
                while (index < outputArray.Length && !inputFile.EndOfStream) //While the index is less than monthScenarios.Length and the input file isn't at the end...
                {
                    outputArray[index] = inputFile.ReadLine(); //Read the current line and set it equal to the current index in monthScenarios.
                    index++; //Advance the index counter by one.
                }
                inputFile.Close(); //Close the file.

                if (arraySize < index)
                {
                    MessageBox.Show(fileName + " must have " + arraySize.ToString() + " lines.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show(fileName + " not found. Please make sure it is in the same folder as the .exe file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            return outputArray;
        }
    }
}
