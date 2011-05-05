using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Threading;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using ToolSet.DatabaseExtractorCode;
using ToolSet.DatabaseExtractorCode.DBExtractor;

namespace Sql_Database_Extraction
{
    public partial class Main : Form
    {
        private DbExtractor DatabaseExtractor = new DbExtractor();
        private InjectionInfos InjectInfos;
        private CookieCollection CookieCol;
        private NetworkCredential netCred;

        public Main()
        {
            InitializeComponent();
            System.Net.ServicePointManager.DefaultConnectionLimit = 32;
            CookieCol = new CookieCollection();
            netCred = new NetworkCredential();
        }

        #region Variables
        private bool awaitingFinish = false;
        private int DBindex = 0;
        private int Tableindex = 0;
        private string uRLBegin = string.Empty;
        private string fullpath = string.Empty;
        private string gewählterOrdner = string.Empty;
        private string dbName;
        private string tName;
        #endregion

        #region Form

        private void raBu_Choose_CheckedChanged(object sender, EventArgs e)
        {
            if (raBu_Choose.Checked == false)
            {
                txt_Post.Enabled = false;
            }
            else
            {
                txt_Preview.Text = string.Empty;
                txt_Post.Enabled = true;
                PostAufteilen(txt_Post.Text);
            }
        }

        private void raBu_Direct_CheckedChanged(object sender, EventArgs e)
        {
            if (raBu_Direct.Checked == true)
            {
                txt_Preview.Text = string.Empty;
                Zerhäcksler(txt_URL.Text);
            }
        }

        private void txt_URL_TextChanged(object sender, EventArgs e)
        {
            if (raBu_Direct.Checked == true)
            {
                Zerhäcksler(txt_URL.Text);
            }
        }

        private void txt_Post_TextChanged(object sender, EventArgs e)
        {
            if (raBu_Choose.Checked == true)
            {
                PostAufteilen(txt_Post.Text);
            }
        }

        private void txt_Parameter_TextChanged(object sender, EventArgs e)
        {
            UpdateParameter(txt_Parameter.Text);
        }
        #endregion

        #region ListView


        public void PostAufteilen(string postdata)
        {
            lv_Parameterized.Items.Clear();
            string stück;
            string substück;
            string[] stücke;
            ListViewItem Item;
            bool firstItem;

            if (postdata.Contains("&"))
            {
                firstItem = true;
                stücke = postdata.Split(new char[] { ';' });
                
                foreach (string s in stücke)
                {
                    if (s.Contains("="))
                    {
                    Item = new ListViewItem();

                    if (firstItem == true)
                    { stück = s.Substring(0, s.IndexOf("=")) + "="; }
                    else
                    { stück = ";" + s.Substring(0, s.IndexOf("=")) + "="; }

                    substück = s.Substring(s.IndexOf("=") + 1);
                    Item.Text = stück;
                    Item.SubItems.Add(substück);
                    lv_Parameterized.Items.Add(Item);
                    }
                    firstItem = false;
                }
            }
            else if (postdata.Contains ("="))
            {
                Item = new ListViewItem();
                stück = txt_Post.Text.Substring(0, txt_Post.Text.IndexOf("=")) + "=";
                substück = txt_Post.Text.Substring(txt_Post.Text.IndexOf("=") + 1);
                Item.Text = stück;
                Item.SubItems.Add(substück);
                lv_Parameterized.Items.Add(Item);
            }
            ShowPreview();
        }

        public void Zerhäcksler(string url)
        {
            lv_Parameterized.Items.Clear();
            string[] stücke;
            string stück;
            string substück;
            string teil;
            string unterteil;
            bool firstItem;

            if (url == null)
            {
                Console.WriteLine("URL wird nicht gesetzt");
            }

            else if (url.Contains("?"))
            {
                firstItem = true;
                if ((url.LastIndexOf("?") + 1) == url.Length)
                {
                    return;
                }

                teil = url.Remove(url.LastIndexOf("?") + 1);
                uRLBegin = teil;
                unterteil = url.Replace(teil, "");
                stücke = unterteil.Split(new char[] { '&' });


                foreach (string s in stücke)
                {

                    ListViewItem Item = new ListViewItem();
                    Item.Text = s;
                    if (s.Contains("="))
                    {

                        if (firstItem == true)
                        {
                            stück = s.Substring(0, s.IndexOf("=")) + "=";
                        }
                        else 
                        { stück = "&" + s.Substring(0, s.IndexOf("=")) + "="; }
                        Item.Text = stück;
                        substück = s.Substring(s.IndexOf("=") + 1);
                        Item.SubItems.Add(substück);
                    }
                    lv_Parameterized.Items.Add(Item);
                    firstItem = false;
                }
                ShowPreview();
            }
        } 
        private void lv_Parameterized_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ShowPreview();
        }

        private void ShowPreview()
        {
            if (lv_Parameterized.Items.Count > 0)
            {
                bool check = false;
                string url = string.Empty;
                foreach (ListViewItem URLItem in lv_Parameterized.Items)
                {
                    if (URLItem.Checked == true)
                        check = true;
                }
                if (check == true)
                    CheckedTrue();
                if (check == false)
                    CheckedFalse();
            }
        }

        private void CheckedFalse()
        {
            string url = string.Empty;
            if (raBu_Choose.Checked == true)
            {
                foreach (ListViewItem URLItem in lv_Parameterized.Items)
                {
                    url += URLItem.Text;
                    if (URLItem.SubItems.Count == 2)
                        url += URLItem.SubItems[1].Text;
                }
                txt_Preview.Text = url + "{Inject}";
            }
            else
            {
                foreach (ListViewItem URLItem in lv_Parameterized.Items)
                {
                    url += URLItem.Text;
                    if (URLItem.SubItems.Count == 2)
                        url += URLItem.SubItems[1].Text;
                }
                txt_Preview.Text = uRLBegin + url + "{Inject}";
            }
        }

 
        private void CheckedTrue()
        {
            string url = string.Empty;
            if (raBu_Choose.Checked == true)
            {
                for (int i = 0; i < lv_Parameterized.Items.Count; i++)
                {
                    if (lv_Parameterized.Items[i].Checked == true)
                    {
                        url += lv_Parameterized.Items[i].Text + lv_Parameterized.Items[i].SubItems[1].Text + "{Inject}";
                    }
                    else url += lv_Parameterized.Items[i].Text + lv_Parameterized.Items[i].SubItems[1].Text;
                }
                txt_Preview.Text = url;
            }
            else
            {
                for (int i = 0; i < lv_Parameterized.Items.Count; i++)
                {
                    if (lv_Parameterized.Items[i].Checked == true)
                    {
                        url += lv_Parameterized.Items[i].Text + lv_Parameterized.Items[i].SubItems[1].Text + "{Inject}";
                    }
                    else url += lv_Parameterized.Items[i].Text + lv_Parameterized.Items[i].SubItems[1].Text;
                }
                txt_Preview.Text = uRLBegin + url;
            }
        }

        private void UpdateParameter(string value)
        {
            foreach (ListViewItem item in lv_Parameterized.Items)
            {
                if (item.Checked == true)
                {
                    item.SubItems[1].Text = value;
                }

            }
            ShowPreview();
        }

        private void lv_Parameterized_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue == CheckState.Checked)
                {
                    foreach (ListViewItem item in lv_Parameterized.Items)
                    {
                        if (item.Checked == true && item.Index != e.Index)
                        {
                            item.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Stackoverflow in itemcheck" + " " + ex); }
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            if (testForWrongInPut())
            {
                //InjectInfos

                DatabaseExtractor.MinColumns = Convert.ToInt32(nud_Min.Value);
                DatabaseExtractor.MaxColumns = Convert.ToInt32(nud_Max.Value);
                DatabaseExtractor.EncodeCharacter = cb_EncodeCharacter.Checked;
                DatabaseExtractor.EncodeWhiteSpace = cb_EncodeWhiteSpaces.Checked;

                InjectInfos = new InjectionInfos();

                if (raBu_Choose.Checked == true)
                {
                    if (txt_Preview.Text == string.Empty)
                    { InjectInfos.POST = txt_Post.Text + "{Inject}"; }
                    else
                    {
                        InjectInfos.POST = txt_Preview.Text;
                    }
                InjectInfos.URL = txt_URL.Text;
                }
                else
                {
                    InjectInfos.URL = txt_Preview.Text;
                    InjectInfos.POST = txt_Post.Text; 
                }
                InjectInfos.InjectableParameter = "";
                InjectInfos.DefaultValue = "";

                if (raBu_Choose.Checked == true)
                    InjectInfos.ModifyType = ModifyType.POST;
                else InjectInfos.ModifyType = ModifyType.GET;

                InjectInfos.Success = txt_Success.Text;
                InjectInfos.CustomCookieCollection = CookieCol;
                DatabaseExtractor.Prepare(InjectInfos);
                lv_Status.Items.Clear();
                tv_Database.Nodes.Clear();
                lv_Database.Clear();
                DatabaseExtractor.ExtractingInfos.Status.Clear();
                tc_1.SelectedTab = tc_1.TabPages[1];
                btn_GetDatabase.Enabled = false;
                btn_ReadColumns.Enabled = false;
                btn_ReadRows.Enabled = false;
                btn_ReadTables.Enabled = false;
                awaitingFinish = true;
                DatabaseExtractor.UserStartMethod();
                Thread thread = new Thread(new ThreadStart(DatabaseExtractor.TestParameterInjectable));
                thread.Start();
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            DatabaseExtractor.UserStopMethod();
            DatabaseExtractor.ExtractingInfos.Status.Add("New requests are stopped");
        }

        private void btn_ReadTables_Click(object sender, EventArgs e)
        {
            txt_CustomQueryOutput.Visible = false;
            btn_Stop.Enabled = true;
            DatabaseExtractor.UserStartMethod();
            btn_ReadTables.Enabled = false;
            int DBindex = tv_Database.SelectedNode.Index;
            Thread thread = new Thread(new ParameterizedThreadStart(DatabaseExtractor.GetTables));
            thread.Start(DBindex);
            awaitingFinish = true;
            fullpath = tv_Database.SelectedNode.FullPath;
            dbName = CutMe(tv_Database.SelectedNode.FullPath);
        }

        private string CutMe(string tocut)
        {
            if (tocut.Contains("\\"))
            {
                 string back = tocut.Substring(tocut.LastIndexOf("\\")+1);
                 return back;
            }
            else return tocut;
        }

        private void btn_ReadColumns_Click(object sender, EventArgs e)
        {
            txt_CustomQueryOutput.Visible = false;
            btn_Stop.Enabled = true;
            DatabaseExtractor.UserStartMethod();
            btn_ReadColumns.Enabled = false;
            int DBindex = tv_Database.SelectedNode.Parent.Index;
            int Tableindex = tv_Database.SelectedNode.Index;
            string Parameter = DBindex.ToString() + "," + Tableindex.ToString();
            Thread thread = new Thread(new ParameterizedThreadStart(DatabaseExtractor.GetColumns));
            thread.Start(Parameter);
            awaitingFinish = true;
            fullpath = tv_Database.SelectedNode.FullPath;
            tName = CutMe(tv_Database.SelectedNode.FullPath);
        }

        private void btn_ReadRows_Click(object sender, EventArgs e)
        {
            txt_CustomQueryOutput.Visible = false;
            btn_Stop.Enabled = true;
            DatabaseExtractor.UserStartMethod();
            btn_ReadRows.Enabled = false;
            btn_ReadColumns.Enabled = false;
            string Parameter = DBindex.ToString() + "," + Tableindex.ToString();
            Thread thread = new Thread(new ParameterizedThreadStart(DatabaseExtractor.GetRows));
            thread.Start(Parameter);
            awaitingFinish = true;
            fullpath = tv_Database.SelectedNode.FullPath;
        }

        private void btn_GetDatabase_Click(object sender, EventArgs e)
        {
            txt_CustomQueryOutput.Visible = false;
            btn_Stop.Enabled = true;
            DatabaseExtractor.UserStartMethod();
            Thread thread = new Thread(new ThreadStart(DatabaseExtractor.GetDatabases));
            thread.Start();
            awaitingFinish = true;
            fullpath = "MySQL\\Databases";
        }

        private void btn_ExecuteCustom_Click(object sender, EventArgs e)
        {
            txt_CustomQueryOutput.Visible = true;
            DatabaseExtractor.UserStartMethod();
            if (txt_CustomQuery.Text.ToLower().Contains("update") || txt_CustomQuery.Text.ToLower().Contains("truncate") || txt_CustomQuery.Text.ToLower().Contains("delete"))
            {
                MessageBox.Show("Alterations of SQL databases through this tool are not allowed", "Warning");
            }
            else txt_CustomQueryOutput.Text = DatabaseExtractor.ExecuteCustomQuery(txt_CustomQuery.Text);
        }
        #endregion

        #region Treeview
        public void TreeviewFüllen()
        {
            tv_Database.SuspendLayout();
            tv_Database.Nodes.Clear();
            if (DatabaseExtractor.ExtractingInfos.ParameterInjectable == true)
                fillTree();
            tv_Database.ExpandAll();
            tv_Database.ResumeLayout();
            if (fullpath != string.Empty)
            {
                TreeNode Node = FindNode(tv_Database.Nodes, fullpath);
                if (Node != null)
                {
                    TreeNode NextNode = Node.NextVisibleNode;
                    if (NextNode != null)
                    {
                        tv_Database.SelectedNode = NextNode;
                        tv_Database.SelectedNode.EnsureVisible();
                    }
                }
            }
        }

        private void fillTree()
        {
            btn_ReadColumns.Enabled = false;
            btn_ReadTables.Enabled = false;
            btn_ReadRows.Enabled = false;

            TreeNode nd1 = new TreeNode();
            TreeNode nd11 = new TreeNode();
            TreeNode nd12 = new TreeNode();
            TreeNode nd13 = new TreeNode();
            TreeNode nd14 = new TreeNode();
            TreeNode child2 = new TreeNode();

            nd1.Text = DatabaseExtractor.ExtractingInfos.DatabaseType;
            nd11.Text = DatabaseExtractor.ExtractingInfos.Version;
            nd1.Nodes.Add(nd11);
            nd12.Text = DatabaseExtractor.ExtractingInfos.User;
            nd1.Nodes.Add(nd12);
            nd13.Text = DatabaseExtractor.ExtractingInfos.CurrentDatabaseName;
            nd1.Nodes.Add(nd13);
            tv_Database.Nodes.Add(nd1);

            if (DatabaseExtractor.ExtractingInfos.DatabaseInfos.Count > 0)
            {
                nd14.Text = "Databases";
                nd1.Nodes.Add(nd14);
                foreach (DatabaseInfo item in DatabaseExtractor.ExtractingInfos.DatabaseInfos)
                {
                    TreeNode databaseNode = new TreeNode();
                    databaseNode.Text = item.DatabaseName;
                    nd14.Nodes.Add(databaseNode);
                    foreach (Table table in item.Tables)
                    {
                        TreeNode tableNode = new TreeNode();
                        tableNode.Text = table.TableName;

                        if (table.Fields.Count > 0)
                            foreach (Field field in table.Fields)
                                tableNode.Nodes.Add(field.FeldName + " : " + field.FeldTyp);

                        databaseNode.Nodes.Add(tableNode);
                    }
                }
            }
        }

        private void FillListView(Table table)
        {
            lv_Database.Items.Clear();
            lv_Database.Columns.Clear();
            for (int iField = 0; iField < table.Fields.Count; iField++)
            {
                Field field = table.Fields[iField];

                lv_Database.Columns.Add(new ColumnHeader() { DisplayIndex = iField, Text = field.FeldName + " : " + field.FeldTyp  });  

                for (int iWert = 0; iWert < table.Fields[iField].FeldWert.Count; iWert++)
                {
                    if (iField == 0)
                        lv_Database.Items.Add(table.Fields[iField].FeldWert[iWert]);
                    else
                        lv_Database.Items[iWert].SubItems.Add(table.Fields[iField].FeldWert[iWert]);
                }
            }
        }

        private void tv_Database_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btn_ReadTables.Enabled = false;
            btn_ReadColumns.Enabled = false;
            btn_ReadRows.Enabled = false;

            if (!DatabaseExtractor.ExtractingInfos.ParameterInjectable)
                return;

            if (e.Node.Level == 2)
                btn_ReadTables.Enabled = true;
            else if (e.Node.Level == 3)
            {
                btn_ReadColumns.Enabled = true;
                DBindex = e.Node.Parent.Index;
                Tableindex = e.Node.Index;

                if (DatabaseExtractor.ExtractingInfos.DatabaseInfos[DBindex].Tables[Tableindex].Fields.Count > 0)
                {
                    btn_ReadRows.Enabled = true;
                    FillListView(DatabaseExtractor.ExtractingInfos.DatabaseInfos[DBindex].Tables[Tableindex]);
                }
            }
            else if (e.Node.Level == 4)
            {
                btn_ReadColumns.Enabled = true;

                DBindex = e.Node.Parent.Parent.Index;
                Tableindex = e.Node.Parent.Index;
                if (DatabaseExtractor.ExtractingInfos.DatabaseInfos[DBindex].Tables[Tableindex].Fields.Count > 0)
                {
                    btn_ReadRows.Enabled = true;
                    FillListView(DatabaseExtractor.ExtractingInfos.DatabaseInfos[DBindex].Tables[Tableindex]);
                }
            }
        }

        private TreeNode FindNode(TreeNodeCollection TN, string FullPath)
        {
            TreeNode Node;
            tv_Database.Focus();
            foreach (TreeNode tn in TN)
            {
                if (FullPath == tn.FullPath)
                    return tn;

                if (FullPath.StartsWith(tn.FullPath + "\\"))
                {
                    Node = FindNode(tn.Nodes, FullPath);
                    if (Node != null)
                        return Node;
                }
            }
            return null;
        }

        #endregion

        private bool testForWrongInPut()
        {
            if (!txt_URL.Text.Contains("?") && raBu_Choose.Checked == false)
            {
                MessageBox.Show("The URL is not written correctly", "Input failure");
                return false;
            }
            else if (!txt_URL.Text.Contains("=") && raBu_Choose.Checked == false)
            {
                MessageBox.Show("There are no parameters in the URL to inject", "Input failure");
                return false;
            }
            else if (!txt_Post.Text.Contains("=") && raBu_Choose.Checked == true)
            {
                MessageBox.Show("The Post is not written correctly", "Input failure");
                return false;
            }
            else if (!txt_Post.Text.Contains("=") && raBu_Choose.Checked == true)
            {
                MessageBox.Show("There are no parameters in the Post to inject", "Input failure");
                return false;
            }
            else if (nud_Min.Value > nud_Max.Value)
            {
                MessageBox.Show("Minimum rows has to be lower than Maximum rows", "Input failure");
                return false;
            }
            else if (txt_Success.Text == string.Empty)
            {
                MessageBox.Show("Please define a success phrase", "Missing Input");
                return false;
            }
            else if (!txt_URL.Text.StartsWith("htt"))
            {
                MessageBox.Show("The URL has to start with http:// or https://. Please write it correctly. ", "Input failure");
                return false;
            }
            else return true;
        }

        private void timerUpdateGUI_Tick(object sender, EventArgs e)
        {
            if (lv_Database.Items.Count > 0)
                btn_Save.Enabled = true;
            else btn_Save.Enabled = false;

            if (DatabaseExtractor.ExtractingInfos.CurrentTestComplete == true)
                btn_ExecuteCustom.Enabled = true;
            else btn_ExecuteCustom.Enabled = false;

            if (DatabaseExtractor != null)
            {
                string status = string.Empty;
                try
                {
                    if (DatabaseExtractor.ExtractingInfos.Status.Count > lv_Status.Items.Count)
                    {
                        lock (DatabaseExtractor.ExtractingInfos.Status)
                            lv_Status.Items.Clear();
                        foreach (string text in DatabaseExtractor.ExtractingInfos.Status)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = text;
                            lv_Status.Items.Add(item);
                            item.EnsureVisible();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim ausgeben der Statusliste: " + ex);
                }
            }
            if (DatabaseExtractor.ExtractingInfos.CurrentTestComplete == true && DatabaseExtractor.ExtractingInfos.ParameterInjectable == true)
            {
                btn_GetDatabase.Enabled = true;
            }
            else btn_GetDatabase.Enabled = false;

            try
            {
                if (awaitingFinish == true && DatabaseExtractor.ExtractingInfos.CurrentTestComplete == true)
                {
                    btn_GetDatabase.Enabled = DatabaseExtractor.ExtractingInfos.ParameterInjectable;
                    TreeviewFüllen();
                    awaitingFinish = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim TimerUpdate" + ex);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = gewählterOrdner;
            saveFileDialog1.Filter = "DataTable (*.xml)|*.xml|All (*.*)|*.*";
            saveFileDialog1.FileName = "DataTable.xml";
            DialogResult ergebnis = saveFileDialog1.ShowDialog();
            if (ergebnis == DialogResult.OK)
            {
                Speichern(saveFileDialog1.FileName);
            }
        }

        private void Speichern(string dateiname)
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement databases = xmlDoc.CreateElement("databases");
            XmlElement databasename = xmlDoc.CreateElement("database");
            XmlElement tables = xmlDoc.CreateElement("tables");
            XmlElement tablename = xmlDoc.CreateElement("table");
            XmlElement columns = xmlDoc.CreateElement("columns");

            XmlAttribute dbattri = xmlDoc.CreateAttribute("name");
            XmlAttribute tattri = xmlDoc.CreateAttribute("name");

            dbattri.InnerText = dbName;
            databasename.Attributes.Append(dbattri);
            tattri.InnerText = tName;
            tablename.Attributes.Append(tattri);


            for (int i = 0; i < lv_Database.Columns.Count; i++)
            {
                XmlElement column = xmlDoc.CreateElement("column");
                XmlAttribute type = xmlDoc.CreateAttribute("type");
                XmlAttribute columnname = xmlDoc.CreateAttribute("name");
                type.InnerText = splitMe(lv_Database.Columns[i].Text)[1];
                columnname.InnerText = splitMe(lv_Database.Columns[i].Text)[0];
                column.Attributes.Append(columnname);
                column.Attributes.Append(type);
                columns.AppendChild(column);

                for (int z = 0; z < lv_Database.Items.Count; z++)
                {
                      XmlElement subitem = xmlDoc.CreateElement("data");
                      subitem.InnerText = lv_Database.Items[z].SubItems[i].Text;
                      column.AppendChild(subitem);
                }
            }
            tablename.AppendChild(columns);
            tables.AppendChild(tablename);
            databasename.AppendChild(tables);
            databases.AppendChild(databasename);
            xmlDoc.AppendChild(databases);
            xmlDoc.Save(dateiname);
        }

        private string[] splitMe(string tosplit)
        {
            string[] splitted = new string[2];

            if (tosplit.Contains(" : "))
            { 
            Regex splitter = new Regex(" : ");
            splitted = splitter.Split(tosplit);
            }
            return splitted;
        }

        private void buttonCustomCookies_Click(object sender, EventArgs e)
        {
            frmCustomCookies dialog = new frmCustomCookies();
            if (dialog.ShowDialog() == DialogResult.OK)
                this.CookieCol = dialog.CookieCol;
        }
    }
}
