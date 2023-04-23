using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace webPreglednik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("www.google.com");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(txtSearch.Text);
            }
        }



        private void txtBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void txtForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void txtHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Niste na stranici!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                toolCombo1.Items.Add(txtSearch.Text);
                toolCombo1.SelectedItem = txtSearch.Text;
                toolCombo1.Focus();
            }
        }

        private async void toolCombo1_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                if (toolCombo1.SelectedItem == null)
                {
                    MessageBox.Show("Niste dodali niti jedan bookmark!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    browser.Navigate(toolCombo1.SelectedItem.ToString());
                    await Task.Delay(600);
                    txtSearch.Text = browser.Url.ToString();
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolCombo1.Items.Clear();
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Html File (*.html)|*.html| Htm File (*.htm)|*.htm";
                openFileDialog.FilterIndex = 1;

                StreamReader reader;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtHtml.Clear();
                    reader = new System.IO.StreamReader(openFileDialog.FileName);
                    txtHtml.Text = reader.ReadToEnd();
                    browser.Navigate(openFileDialog.FileName);
                    await Task.Delay(100);
                    txtSearch.Text = browser.Url.ToString();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Html File (*.html)|*.html| Htm File (*.htm)|*.htm";
            saveFileDialog.DefaultExt = "*.html";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(txtHtml.Text);
                }
            }
        }

        

        private void TabtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void NewTab()
        {
            TabPage tab = new TabPage();
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            WebBrowser browser = new WebBrowser() { ScriptErrorsSuppressed = true };
            browser.Parent = tab;
            browser.Dock = DockStyle.Fill;
            browser.Navigate("Google.com");
            txtSearch.Text = "Google.com";
            browser.DocumentCompleted += Browser_DocumentCompleted;
        }
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                tabControl1.SelectedTab.Text = browser.DocumentTitle;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewTab();
        }

        private void ClosetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void txtTab_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void allBookmarks_Click(object sender, EventArgs e)
        {

        }

        private void allBookmarks_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //webBrowser1.Navigate(allBookmarks.DropDownItems.ToString);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
