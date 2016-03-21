/*
 * Created by Ranorex
 * User: automation
 * Date: 3/21/2016
 * Time: 12:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.IO; //Added
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Session2_CL
{
    /// <summary>
    /// Description of UserCodeModule1.
    /// </summary>
    [TestModule("C5978B9C-AB4F-46A4-BDC1-B86060DA2757", ModuleType.UserCode, 1)]
    public class Exploring_C_Sharp : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Exploring_C_Sharp()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            int iFirstInt = 10;
            if (iFirstInt == 10)
            {
            	int iSecondInt = 20;
            	Report.Info(iFirstInt.ToString() + " " + iSecondInt.ToString());
            }
            
            DriveInfo DI = new DriveInfo(@"C:/");
            Report.Info(DI.TotalFreeSpace.ToString());
            Report.Info(DI.DriveFormat.ToString());
            Report.Info(DI.VolumeLabel);
            
            
            Report.Info(DI.RootDirectory.Attributes.ToString());
            
            DirectoryInfo DrI = new System.IO.DirectoryInfo(@"C:\RanorexSession2_Cl\Session2_CL\Session2_CL");
            FileInfo[] fileNames = DrI.GetFiles("*.*");
            foreach(FileInfo fi in fileNames)
            {
            	Report.Info(fi.Name + " : " + fi.LastAccessTime.ToString() + " : " + fi.Length.ToString());
            	if (fi.Name.Contains("S"))
            	{
            		break;
            	}
            	Report.Info(fi.Name + " : " + fi.LastAccessTime.ToString() + " : " + fi.Length.ToString());
            }
            
            foreach(FileInfo fi in fileNames)
            {
            	Report.Info(fi.Name + " : " + fi.LastAccessTime.ToString() + " : " + fi.Length.ToString());
            	if (fi.Name.Contains("S"))
            	{
            		continue;
            	}
            	Report.Info(fi.Name + " : " + fi.LastAccessTime.ToString() + " : " + fi.Length.ToString());
            }
        }
    }
}
