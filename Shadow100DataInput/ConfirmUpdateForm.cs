using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shadow100DataInput.Classes;

namespace Shadow100DataInput
{
    public partial class ConfirmUpdateForm : Form
    {
        public ConfirmUpdateForm()
        {
            InitializeComponent();

        }

        public ConfirmUpdateForm(uint oldTimeMilli, uint newTimeMilli)
        {
            InitializeComponent();

            var common = Common.Instance;

            oldTimeStringLabel.Text = common.TimeInString(oldTimeMilli);
            newTimeStringLabel.Text = common.TimeInString(newTimeMilli);
        }
    }
}
