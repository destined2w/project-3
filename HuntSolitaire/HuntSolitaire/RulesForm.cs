using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntSolitaire
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();
            Text = "Правила пасьянса 'Охота'";
            Size = new Size(400, 300);

            TextBox textBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = "Правила пасьянса 'Охота':\n\n" +
                       "1. Используется колода из 36 карт\n" +
                       "2. Карты раскладываются в 9 стопок по 4 карты\n" +
                       "3. Игрок может убирать пары карт одинакового достоинства\n" +
                       "4. Цель игры - убрать все карты с поля"
            };

            Controls.Add(textBox);
        }
    }
}