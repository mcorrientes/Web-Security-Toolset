using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Reflection;
using System.IO;


namespace SelfregisterConfigClient
{
    [RunInstaller(true)]
    public partial class Register : Installer
    {
        public Register()
        {
            InitializeComponent();
            this.Committed += new InstallEventHandler(Register_Committed);
        }

        void Register_Committed(object sender, InstallEventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Selfregister x86.BAT");
            }
            catch (Exception)
            {
                //tja dann funktionierts hald nich
            }
        }


        //private static void RunBatch()
        //{
        //    Process proc = new Process();

        //    proc.StartInfo.FileName = "Selfregister x86.BAT";

        //    proc.StartInfo.Arguments = prg;

        //    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        //    proc.StartInfo.ErrorDialog = false;

        //    proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(prg);

        //    proc.Start();

        //    proc.WaitForExit();

        //    if (proc.ExitCode != 0)

        //        throw new Exception("Error executing Selfregister");

        //}
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    }
}
