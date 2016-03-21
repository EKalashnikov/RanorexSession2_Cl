/*
 * Created by Ranorex
 * User: automation
 * Date: 3/20/2016
 * Time: 3:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Session2_CL
{
    /// <summary>
    /// Description of SettingVar2PassBetween.
    /// </summary>
    [TestModule("411CA77E-E438-45BB-8F6E-9B47D5D9C64C", ModuleType.UserCode, 1)]
    public class SettingVar2PassBetween : ITestModule
    {
    	
    	string _NewModuleVariable = "";
    	[TestVariable("D6769E35-EDC9-4654-A2BE-A389C83CD7FC")]
    	public string NewModuleVariable
    	{
    		get { return _NewModuleVariable; }
    		set { _NewModuleVariable = value; }
    	}
    	
    	public static Session2_CLRepository repo = Session2_CLRepository.Instance;
    	public static int iPassingTheData;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SettingVar2PassBetween()
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
            
            int VarToPass = 17;
            //repo.repoGlobalVar = VarToPass.ToString();
            //NewModuleVariable = VarToPass.ToString();
            iPassingTheData = VarToPass;
            
        }
    }
}
