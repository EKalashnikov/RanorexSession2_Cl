/*
 * Created by Ranorex
 * User: automation
 * Date: 3/20/2016
 * Time: 3:52 PM
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
	using data = Session2_CL.SettingVar2PassBetween;
	/// <summary>
	/// Description of SettingVar2PB_2.
	/// </summary>
	[TestModule("0AD812F0-CCA7-4F85-9FFF-B589E4B8D3A7", ModuleType.UserCode, 1)]
	public class SettingVar2PB_2 : ITestModule
	{
		public static Session2_CLRepository repo = Session2_CLRepository.Instance;
		
		
		string _ModuleVariableInSecondClass = "";
		[TestVariable("A80F894F-9B40-402A-BCF6-FF2325C8BCF8")]
		public string ModuleVariableInSecondClass
		{
			get { return _ModuleVariableInSecondClass; }
			set { _ModuleVariableInSecondClass = value; }
		}
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public SettingVar2PB_2()
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
			//int VarToPass = int.Parse(repo.repoGlobalVar);
			//int VarToPass = int.Parse(ModuleVariableInSecondClass);
			
			//Report.Info(VarToPass.ToString());
			
			Report.Info(data.iPassingTheData.ToString());
			
		}
	}
}
