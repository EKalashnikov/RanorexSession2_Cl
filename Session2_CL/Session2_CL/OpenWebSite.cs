/*
 * Created by Ranorex
 * User: automation
 * Date: 2/28/2016
 * Time: 3:28 PM
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
    /// Description of OpenWebSite.
    /// </summary>
    [TestModule("9B78D80C-7370-470A-9B3C-7C683029EF41", ModuleType.UserCode, 1)]
    public class OpenWebSite : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenWebSite()
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
            
            Host.Local.OpenBrowser("http://miami.craigslist.org/","chrome",true, true);
            
        }
    }
}
