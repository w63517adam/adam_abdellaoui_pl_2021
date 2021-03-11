using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private IEnumerable<string> ReadFile()
        {
            var path = textBox1.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist. Cannot proceed");
                return null;
            }

            var lines = File.ReadAllLines(path).Skip(1);
            return lines;
        }

        private List<Expense> ListOfExpenses()
        {
            var lines = ReadFile();

            var expenses = new List<Expense>();
            foreach (var line in lines)
            {
                var split = line.Split('|');
                var date = DateTime.ParseExact(split[0], "yyyy-MM-dd", null);
                var price = Convert.ToDecimal(split[1].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                var category = split[2];



                var expense = new Expense(date, price, category);
                expenses.Add(expense);
            }
            return expenses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = ListOfExpenses();
            var numbOfCateg = result
                .GroupBy(x => x.Category)
                .Count();
            var totalExpenses = result
                .Sum(x => x.Price);

            textBox2.Text = $"Number of categories: {numbOfCateg}, total expenses: {totalExpenses}";

            textBox2.Text +=
                $"\r\nCategories: {string.Join(", ", result.GroupBy(x => x.Category).Select(x => x.Key))}";
            textBox2.Text +=
                $"\r\nDates: {string.Join(", ", result.GroupBy(x => x.Date.ToString("dd/MM/yyyy")).Select(x => x.Key))}";

            
        }
    }

    public class Expense
    {
        public DateTime Date { get; }
        public decimal Price { get; }
        public string Category { get; }

        public Expense(DateTime date, decimal price, string categ)
        {
            Date = date;
            Price = price;
            Category = categ;
        }
    }
}
