using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMat
{
     public partial class Form1 : Form
     {
          private object txtNumbers;
          private object lblResult;

          public Form1()
          {
               InitializeComponent();
          }

          private void btnCalculate_Click(object sender, EventArgs e)
          {
               try
               {
                    string[] numbersString = txtNumbers.Text.Split(' ');

                    List<double> numbers = new List<double>();
                    foreach (string numStr in numbersString)
                    {
                         double num = double.Parse(numStr);
                         numbers.Add(num);
                    }

                    double average = numbers.Average();

                    var mode = numbers.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

                    var sortedNumbers = numbers.OrderBy(n => n).ToList();
                    double median;

                    if (sortedNumbers.Count % 2 == 0)
                    {
                         int midIndex = sortedNumbers.Count / 2;
                         median = (sortedNumbers[midIndex - 1] + sortedNumbers[midIndex]) / 2.0;
                    }
                    else
                    {
                         int midIndex = sortedNumbers.Count / 2;
                         median = sortedNumbers[midIndex];
                    }

                    lblResult.Text = $"Средно аритметично: {average}\nМода: {mode}\nМедиана: {median}";
               }
               catch (Exception ex)
               {
                    MessageBox.Show($"Грешка: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
          }

          private void Form1_Load(object sender, EventArgs e)
          {

          }
     }
}
