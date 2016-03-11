/*
 * Created by Ranorex
 * User: automation
 * Date: 3/11/2016
 * Time: 2:19 PM
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
    /// Description of ReportingJobsReqs.
    /// </summary>
    [TestModule("9DD8C4A6-E1DA-4349-88E9-32142DC2700B", ModuleType.UserCode, 1)]
    public class ReportingJobsReqs : ITestModule
    {
        public static Session2_CLRepository repo = Session2_CLRepository.Instance;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ReportingJobsReqs()
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
            
            //Getting available positions (links)
			IList<ATag> localResults = Host.Local.Find<ATag>(repo.CLMiamiList.List.SelfInfo.AbsolutePath
			                                                 + "/div[@class='content']/p/span/span/a[@href~'miami.cr']");
			
			//Opening all available positions and reporting requirements for them to the log
			string strJobDescription;
			
			//Regex to search for requirements
			string strReqPatern = "[r|R]equirements(.*)";
			
			foreach (ATag job in localResults){
				
				//Opening job details in new tab
				try
				{
					Host.Local.PressKeys("{Control down}");
					job.Click();
					Host.Local.PressKeys("{Control up}");
					repo.CLMiamiDetail.sectionPostInfo.WaitForExists(5000);
					WebDocument wdJobDetail = "/dom[@pageurl='" + job.Href + "']";
					wdJobDetail.EnsureVisible();
					
					
					//check if the page is loaded correctly.
					//This code won't fail and re-attempt one time to close failed to load tab and do again.
					if (!repo.CLMiamiDetail.linkCLInfo.Exists(5000)){
						wdJobDetail.Close();
						Host.Local.PressKeys("{Control down}");
						job.Click();
						Host.Local.PressKeys("{Control up}");
						wdJobDetail = "/dom[@pageurl='" + job.Href + "']";
						wdJobDetail.EnsureVisible();
						repo.CLMiamiDetail.sectionPostInfo.WaitForExists(30000);
					}
					
					//Getting requirements with regex
					strJobDescription = repo.CLMiamiDetail.sectionPost.Element.GetAttributeValueText("InnerText");
					Match matchReqs = Regex.Match(strJobDescription, strReqPatern, RegexOptions.Singleline);
					Report.Info(matchReqs.Groups[0].Value);
					//Delay.Milliseconds(1000);
					//Closing job details
					wdJobDetail.Close();
				}
				catch (Ranorex.RanorexException)
				{
					//WebDocument wdJobDetail = "/form[@title='Untitled - Google Chrome']";
					//wdJobDetail.EnsureVisible();
					//wdJobDetail.Close();
					Report.Info("Not able to open job detail for " + job.Href);
				}
			}
        }
    }
}
