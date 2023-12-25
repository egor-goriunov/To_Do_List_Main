using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Create columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
           
            //Point datagridview to datasource
            ToDoListView.DataSource = todoList;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Fill text fields with data from table
            TitleTextBox.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            DescriptionTextBox.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            { 
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(isEditing) 
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Title"] = TitleTextBox.Text;
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = DescriptionTextBox.Text;
            }
            else
            {
                todoList.Rows.Add(TitleTextBox.Text, DescriptionTextBox.Text);
            }
            // Clear field
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}
