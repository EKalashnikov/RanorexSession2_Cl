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
			int iAttempts;
			bool bDetailsOpened;
			
			foreach (ATag job in localResults){
				iAttempts = 3;
				bDetailsOpened = false;
				
				while (!bDetailsOpened && iAttempts > 0){
					//Report.Info((!bDetailsOpened).ToString() + iAttempts.ToString() + (!bDetailsOpened || iAttempts > 0).ToString());
					//Opening job details in new tab
					try
					{
						Host.Local.PressKeys("{Shift down}");
						job.Click();
						Host.Local.PressKeys("{Shift up}");
						repo.CLMiamiDetail.sectionPostInfo.WaitForExists(9000);
						WebDocument wdJobDetail = "/dom[@pageurl='" + job.Href + "']";
						wdJobDetail.EnsureVisible();
						
						//Getting requirements with regex
						strJobDescription = repo.CLMiamiDetail.sectionPost.Element.GetAttributeValueText("InnerText");
						Match matchReqs = Regex.Match(strJobDescription, strReqPatern, RegexOptions.Singleline);
						Report.Info(job.Href + " : " + matchReqs.Groups[0].Value);
						bDetailsOpened = true;
						//Delay.Milliseconds(1000);
						//Closing job details
						wdJobDetail.Close();
					}
					catch (Ranorex.RanorexException)
					{
//						Host.Local.FindSingle("/form[@title='Untitled - Google Chrome']/element").EnsureVisible();
//						Host.Local.PressKeys("{Control down}w{Control up}");
						Keyboard.Press("{Alt down}{F4}{ALT up}");
//					    WebDocument wdJobDetail = "/form[@title='Untitled - Google Chrome']";
//						IList<Form> myAutForms = Host.Local.Find <Form> ("/form[@processname='chrome']");
//						foreach(Form form in myAutForms)
//							if (form.As<NativeWindow>().IsAppHung) form.Close();
						
						
//						WebDocument wdJobDetail = "/dom[@pageurl='" + job.Href + "']";
//						wdJobDetail.EnsureVisible();
//					    wdJobDetail.Close();
						Report.Info("Not able to open job detail for " + job.Href);
						Delay.Milliseconds(5000);
						iAttempts--;
						
					}
				}
				
			}
		}
	}
}
