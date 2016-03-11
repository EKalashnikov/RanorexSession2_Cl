/*
 * Created by Ranorex
 * User: automation
 * Date: 3/11/2016
 * Time: 2:17 PM
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
    /// Description of CheckJobsRange.
    /// </summary>
    [TestModule("B88760FC-DE8A-414D-85A9-3570EF2806ED", ModuleType.UserCode, 1)]
    public class CheckJobsRange : ITestModule
    {
    	public static Session2_CLRepository repo = Session2_CLRepository.Instance;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckJobsRange()
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
            
            //Counting number for available positions (links) and comparing to displayed range
			//Getting range
			repo.CLMiamiList.List.spanRangeToInfo.WaitForExists(10000);
			int iRangeTo = Convert.ToInt16(repo.CLMiamiList.List.spanRangeTo.InnerText);
			//Getting number for available positions (links)
			IList<ATag> localResults = Host.Local.Find<ATag>(repo.CLMiamiList.List.SelfInfo.AbsolutePath
			                                                 + "/div[@class='content']/p/span/span/a[@href~'miami.cr']");
			int iResultsNumber = localResults.Count;
			//Comparing
			string strIfEqual = "";
			if (iResultsNumber != iRangeTo) strIfEqual = "NOT ";
			Report.Info("Number of links (" + iResultsNumber.ToString() + ") is " + strIfEqual
			            + "equal to rangeTo ("+ iRangeTo.ToString() + ")");
        }
    }
}
