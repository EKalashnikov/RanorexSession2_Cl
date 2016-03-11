/*
 * Created by Ranorex
 * User: automation
 * Date: 2/28/2016
 * Time: 3:34 PM
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
	/// Description of DisplayQAJobs.
	/// </summary>
	[TestModule("11988A37-FCE2-45BA-B382-EF4EA500875F", ModuleType.UserCode, 1)]
	public class FilterJobs : ITestModule
	{
		public static Session2_CLRepository repo = Session2_CLRepository.Instance;
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public FilterJobs()
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
			
			//Sequence to delete existing symbols in the code
			string strClr = "{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}";
			
			//Filtering positions by word "developer"
			repo.CLMiamiList.List.SearchForm.inputSearchInfo.WaitForExists(10000);
			repo.CLMiamiList.List.SearchForm.inputSearch.PressKeys(strClr + "developer");
			repo.CLMiamiList.List.SearchForm.buttonSearch.Click();
			
		}
	}
}
