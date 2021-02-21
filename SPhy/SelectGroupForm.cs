using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESPlus.Rapid;

namespace OVCS
{
    public partial class SelectGroupForm : Form
    {
        #region IsCreator
        private bool isCreator = true;
        public bool IsCreator
        {
            get { return isCreator; }
        } 
        #endregion
        #region OwnerID
        private string ownerID;
        public string OwnerID
        {
            get { return ownerID; }
        } 
        #endregion    

        
        private IRapidPassiveEngine rapidPassiveEngine;       

        string currentUserID;
        public SelectGroupForm(string memberID, IRapidPassiveEngine _rapidPassiveEngine)
        {
            InitializeComponent();
            this.currentUserID = memberID;            
            this.rapidPassiveEngine = _rapidPassiveEngine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.isCreator = false;
            this.ownerID = this.textBox_ownerID.Text.Trim();

            try
            {
                if (this.textBox_ownerID.Text.Trim() == "")
                {
                    MessageBox.Show("房主 ID不能为空！");
                    return;
                }

                if (!this.rapidPassiveEngine.BasicOutter.IsUserOnline(this.ownerID))
                {
                    MessageBox.Show("主人不在线，不能加入该房间！");
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, "SelectGroupForm.button_goinSelfGroup_Click", ESBasic.Loggers.ErrorLevel.High);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button_goinSelfGroup_Click(object sender, EventArgs e)
        {
            this.isCreator = true;
            this.ownerID = this.currentUserID;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }        
    }
}
