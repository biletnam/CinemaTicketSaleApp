using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMaster.Helper
{
    public static class ClearForm
    {
        public static void Clear(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if(control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if(control is MaskedTextBox)
                {
                    ((MaskedTextBox)control).Clear();
                }
                else if(control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if(control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if(control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                //else if (control is ListBox)
                //{
                //    ((ListBox)control).SelectedIndex = -1;
                //}
                else if(control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if(control is CheckedListBox)
                {
                    for (int i = 0; i < ((CheckedListBox)control).Items.Count; i++)
                    {
                        ((CheckedListBox)control).SetItemChecked(i, false);
                    }
                }
                else if(control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                }
                else if(control is PictureBox)
                {
                    ((PictureBox)control).Image = null;
                }
            }
        }

        public static void DisposePanels(Form form)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is Panel)
                {
                    ((Panel)ctrl).Dispose();
                }
            }
        }
    }
}
