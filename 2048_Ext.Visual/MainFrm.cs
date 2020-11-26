using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2048_Ext.Logic;

namespace _2048_Ext.Visual
{
    public partial class mainfrm : Form
    {
        Game game;
        GameFrm gameFrm;

        public mainfrm()
        {
            InitializeComponent();
            game = new Logic.Game();     
        }

        

        private void newBttn_Click(object sender, EventArgs e)
        {
            game.NewGame(
                nameOfPlayertbx.Text,
                Convert.ToInt32(rowUpDwn.Value),
                Convert.ToInt32(columnUpDwn.Value)
                );
            
            Visible = false;

            gameFrm = new GameFrm(game);
            gameFrm.ShowDialog();

            Close();
        }
        
        private void loadBttn_Click_1(object sender, EventArgs e)
        {
            loadFDlog.ShowDialog();
            game.Load(loadFDlog.FileName);

            GameFrm gameFrm = new GameFrm(game);
            gameFrm.ShowDialog();
            Close();
        }

        private void exitBttn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
