using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TamagotchiHelp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void imenaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.imenaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbimenaDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbimenaDataSet.imena". При необходимости она может быть перемещена или удалена.
            this.imenaTableAdapter.Fill(this.dbimenaDataSet.imena);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить кличку? ", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) imenaBindingSource.RemoveCurrent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            DataSet changedRecords = dbimenaDataSet.GetChanges();
            if (changedRecords != null)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Закрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) imenaBindingNavigatorSaveItem_Click(sender, e);
                else this.imenaTableAdapter.Fill(this.dbimenaDataSet.imena);
            }

        }


        private void imenaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void imenaDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            const string disallowed = @"[^А-Яа-я\0]";
            var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
            imenaDataGridView.Rows[e.RowIndex].ErrorText = "";
            if (imenaDataGridView.Rows[e.RowIndex].IsNewRow) return;
            if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0) return;
            e.Cancel = true;
            //imenaDataGridView.Rows[e.RowIndex].ErrorText = "Некорректный символ!";
            MessageBox.Show("Неккоректное значение!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Program.f1.textBox1.Text = imenaDataGridView.CurrentRow.Cells[1].Value.ToString();
            //Program.f2.textBox2.Text = imenaDataGridView.CurrentRow.Cells[1].Value.ToString();
            this.Close();
        }
    }
}
