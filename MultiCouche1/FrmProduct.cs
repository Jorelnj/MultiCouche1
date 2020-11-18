using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCouche1
{
    public partial class FrmProduct : Form
    {
        private User oldUser;

        private IUserRepository userRepository { get; }
        
        public FrmProduct(IUserRepository userRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadGrid(IEnumerable<User> users)
        {         
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(txtUser.Text, txtPwd.Text, txtFull.Text);
                if (this.oldUser == null)
                    this.userRepository.Add(user, LoadGrid);
                else
                    this.userRepository.Set(this.oldUser, user, LoadGrid);
                    //this.userRepository.Add(user, LoadGrid);
                //LoadGrid(this.userRepository.GetAll());
                MessageBox.Show
                (
                    "Save Done!",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.oldUser = null;
                txtFull.Clear();
                txtPwd.Clear();
                txtUser.Clear();
            }
            catch (Exception ex)
            {
                //TODO log error
                MessageBox.Show
                (
                    "An error occured!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );               
            }            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmUser_Load(object sender, EventArgs e)
        {           
            LoadGrid(this.userRepository.GetAll());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {           
                List<User> users = new List<User>();
                for(int i=0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    users.Add(dataGridView1.SelectedRows[i].DataBoundItem as User);
                                   
                }
                this.userRepository.Delete(users, LoadGrid);
                MessageBox.Show
                (
                    "Delete done !",
                    "Confirmationx",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.oldUser = dataGridView1.SelectedRows[0].DataBoundItem as User;
            txtFull.Text = this.oldUser.FullName;
            txtPwd.Text = this.oldUser.Password;
            txtUser.Text = this.oldUser.UserName;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.userRepository.Find
            (
                x => 
                x.UserName.ToLower().Contains(txtSearch.Text.ToLower()) ||
                x.FullName.ToLower().Contains(txtSearch.Text.ToLower()),
                LoadGrid
            );
        }
    }
}
