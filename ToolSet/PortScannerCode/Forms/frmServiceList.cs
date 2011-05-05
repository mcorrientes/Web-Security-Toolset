using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace PortScanner
{
    public partial class frmServiceList : Form
    {
        public frmServiceList()
        {
            InitializeComponent();
        }


            private List<Services> info;
            public List<Services> Info
            {
                get { return info; }
            }

            private List<int> portRange;
            public List<int> PortRange
            {
                get { return portRange; }
                set { portRange = value; }
            }

            public string Service;
            public string Protocol;
            private int port;

            public void ReadText()
            {
                info = new List<Services>();
                string[] file = File.ReadAllLines(Application.StartupPath + @"\services.dat");

                foreach (string test in file)
                {
                    Regex mySplit = new Regex("/");
                    string text = test;
                    string[] stücke;
                    stücke = text.Split(new char[] { '\t' });
                    string service = stücke[0];
                    if (service != "unknown")
                    {
                        string[] portundprot = mySplit.Split(stücke[1]);
                        string portnumber = portundprot[0];
                        string protocol = portundprot[1];
                        ListViewItem item = new ListViewItem();
                        item.Checked = true;
                        item.Text = service;
                        item.SubItems.Add(portnumber);
                        item.SubItems.Add(protocol);
                        lv_Services.Items.Add(item);
                        info.Add(new Services { Port = portnumber, Protocol = protocol, Service = service });
                    }
                }
            }

            public string ReturnService (int port)
            { 
                Service = string.Empty;
                foreach (Services item in info)
                {
                    if (item.Port == Convert.ToString(port))
                    {
                        Service = item.Service;
                        return Service;
                    }
                }
                return Service;
            }

            public void lookForPort(int port)
            {
                Protocol = string.Empty;
                Service = string.Empty;
                foreach (Services item in info)
                {
                    if (item.Port == Convert.ToString(port))
                    {
                        Service = item.Service;
                        Protocol += item.Protocol + "  ";
                    }
                }
            }
            
            public List<int> PortArray()
            {
                portRange = new List<int>();
                foreach (ListViewItem item in lv_Services.Items)
                {
                    if (item.Checked == true)
                    {
                        port = Convert.ToInt32(item.SubItems[1].Text);
                        portRange.Add(port);
                    }
                }
                return portRange;
            }
        }
    }
