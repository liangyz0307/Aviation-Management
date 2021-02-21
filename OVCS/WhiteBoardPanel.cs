using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive.WhiteBoard;
using ESBasic.ObjectManagement.Managers;

namespace OVCS
{
    public partial class WhiteBoardPanel : UserControl
    {
        private ObjectManager<int, WhiteBoardConnector> pageManager = new ObjectManager<int, WhiteBoardConnector>();

        public WhiteBoardPanel()
        {
            InitializeComponent();

            this.pageManager.Add(0, this.whiteBoardConnector1);
        }

        public void Initialize(string groupID, bool isManager)
        {

        }
    }
}
