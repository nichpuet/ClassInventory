using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassInventory
{
    public partial class Form1 : Form
    {
        //create a List to store all inventory objects
        List<Player> PlayerList = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string position, name, team;
            int age;
            //  - gather all information from screen 
            position = positionInput.Text;
            name = nameInput.Text;
            team = teamInput.Text;
            age = Convert.ToInt16(ageInput.Text);


            //  - create object with gathered information
            Player newPlayer = new Player(name, team, position, age);
            //  - add object to global list
            PlayerList.Add(newPlayer);
            //  - display message to indicate addition made
            AddedLabel.Visible = true;
            RemovedLabel.Visible = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            //  - if object is in list remove it
            for (int i = 0; i < PlayerList.Count; i++)
            {
                if (PlayerList[i].name.Contains(removeInput.Text) == true)
                {
                    PlayerList.RemoveAt(i);
                    RemovedLabel.Visible = true;
                    AddedLabel.Visible = false;
                }
            }
            //  - display message to indicate deletion made
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // - if object entered exists in list show it
            for (int i = 0; i < PlayerList.Count; i++)
            {
                if (PlayerList[i].name.Contains(searchInput.Text) == true)
                {
                    outputLabel.Text = "Name: "+PlayerList[i].name + "\n";
                    outputLabel.Text += "Age: " + PlayerList[i].age + "\n";
                    outputLabel.Text += "Team " + PlayerList[i].team + "\n";
                    outputLabel.Text += "Position: " + PlayerList[i].team + "\n";
                    break;
                }
                else
                {
                    outputLabel.Text = "No player found";
                }

            }
            //  else show not found message

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // - show all objects in list
            outputLabel.Text = "All Players\n**************\n";
            for (int i = 0; i < PlayerList.Count; i++)
            {
                outputLabel.Text += "Name: " + PlayerList[i].name + "\n";
                outputLabel.Text += "Age: " + PlayerList[i].age + "\n";
                outputLabel.Text += "Team " + PlayerList[i].team + "\n";
                outputLabel.Text += "Position: " + PlayerList[i].team + "\n";
                outputLabel.Text += "**************\n";
            }
        }
    }
}
