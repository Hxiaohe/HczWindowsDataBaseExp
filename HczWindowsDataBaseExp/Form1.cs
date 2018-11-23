using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HczWindowsDataBaseExp
{
    public partial class Form1 : Form
    {
        private Database ds;
        public Form1()
        {	//初始化数据库对象
            ds = new Database();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

		//查询按钮的事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text))&& (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                String str = "SELECT ID,NAME FROM PEOPLE";
                DataTable d1 = ds.ExecuteQuery(str);
                if (d1 != null && d1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = d1;

                }
                else
                {
                    MessageBox.Show("数据库暂时没有记录！", "查询结果",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text))&& !(textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                String str = "SELECT ID,NAME FROM PEOPLE WHERE NAME like '%" + textBox2.Text + "%'";
                DataTable d1 = ds.ExecuteQuery(str);
                if (d1 != null && d1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = d1;

                }
                else
                {
                    MessageBox.Show("没有相关记录！", "查询结果",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!(textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                     (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                String str = "SELECT ID,NAME FROM PEOPLE WHERE ID like '%" + textBox1.Text + "%'";
                DataTable d1 = ds.ExecuteQuery(str);
                if (d1 != null && d1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = d1;

                }
                else
                {
                    MessageBox.Show("没有相关记录！", "查询结果",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                String str = "SELECT ID,NAME FROM PEOPLE WHERE ID like '%" + textBox1.Text + "%'AND NAME like '%" + textBox2.Text + "%'";
                DataTable d1 = ds.ExecuteQuery(str);
                if (d1 != null && d1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = d1;

                }
                else
                {
                    MessageBox.Show("没有相关记录！", "查询结果",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
		//添加按钮的事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            String str1 = textBox1.Text;
            String str2 = textBox2.Text;
            if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                MessageBox.Show("id不能为空！", "添加结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(!(textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                    (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("姓名不能为空！", "添加结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                    !(textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                MessageBox.Show("id不能为空！", "添加结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                String str = "INSERT INTO PEOPLE (ID,NAME) VALUES('" + str1 + "','" + str2 + "')";
                try
                {

                    int d2 = ds.ExecuteUpdate(str);
                    if (d2 != 0)
                    {
                        MessageBox.Show("添加成功！", "添加结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("添加失败！此id已存在！", "添加结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加失败！此id已存在！", "添加结果",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
		//更新按钮的事件处理
        private void button3_Click(object sender, EventArgs e)
        {
            String str1 = textBox1.Text;
            String str2 = textBox2.Text;
            if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                MessageBox.Show("id不能为空！", "更新结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!(textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                    (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("姓名不能为空！", "更新结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                    !(textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                MessageBox.Show("id不能为空！", "更新结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                String str = "UPDATE PEOPLE SET NAME='"+str2+"'WHERE ID='"+str1+"'";
                    int d2 = ds.ExecuteUpdate(str);
                    if (d2 != 0)
                    {
                        MessageBox.Show("更新成功！", "更新结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("更新失败！此id不存在！", "更新结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }
		//删除按钮的事件处理
        private void button4_Click(object sender, EventArgs e)
        {
            String str1 = textBox1.Text;
            String str2 = textBox2.Text;
            if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                MessageBox.Show("id，名字不能同时为空！", "删除结果",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!(textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                     (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {
                if (MessageBox.Show("你确认删除这个记录吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String str = "DELETE FROM PEOPLE WHERE ID='" + str1 + "'";

                    int d2 = ds.ExecuteUpdate(str);
                    if (d2 != 0)
                    {
                        MessageBox.Show("删除成功！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！此id不存在！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((textBox1.Text == "" || string.IsNullOrEmpty(textBox1.Text)) &&
                     !(textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text)))
            {

                if (MessageBox.Show("你确认删除这个记录吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String str = "DELETE FROM PEOPLE WHERE NAME='" + str2 + "'";

                    int d2 = ds.ExecuteUpdate(str);
                    if (d2 != 0)
                    {
                        MessageBox.Show("删除成功！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！此姓名不存在！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("你确认删除这个记录吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String str = "DELETE FROM PEOPLE WHERE NAME='" + str2 + "' AND ID='" + str1 + "'";

                    int d2 = ds.ExecuteUpdate(str);
                    if (d2 != 0)
                    {
                        MessageBox.Show("删除成功！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！该记录不存在！", "删除结果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }
                else
                {
                    return;
                }
            }

        }
    }
}
