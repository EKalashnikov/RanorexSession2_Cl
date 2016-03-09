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
    public class DisplayQAJobs : ITestModule
    {
    	public static Session2_CLRepository repo = Session2_CLRepository.Instance; 
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DisplayQAJobs()
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
            
            //Opening all available positions and reporting requirements for them to the log
            int i = 0;
            string strJobDescription;
            string strLinkPath;
            //Regex to search for requirements
            string strReqPatern = "[r|R]equirements(.*)";
            for (i=1;i<iResultsNumber;i++){
            	//Building xpath to find next link to click and clicking
            	strLinkPath = repo.CLMiamiList.List.SelfInfo.AbsolutePath
            		+ "/div[@class='content']/p[" + i.ToString() 
            		+ "]/span/span/a[@href~'miami.cr']";
            	IList<ATag> localResTemp = Host.Local.Find<ATag>(strLinkPath);
            	localResTemp[0].Click();           	
            	//Getting requirements for position and reporting to the log
            	repo.CLMiamiDetail.sectionPostInfo.WaitForExists(30000);
            	strJobDescription = repo.CLMiamiDetail.sectionPost.Element.GetAttributeValueText("InnerText");
            	Match matchReqs = Regex.Match(strJobDescription, strReqPatern, RegexOptions.Singleline);
            	Report.Info(matchReqs.Groups[0].Value);
            	//Going back
            	Host.Local.Click();
            	Host.Local.PressKeys("{BACK}");            	
            }
        }
    }
}
