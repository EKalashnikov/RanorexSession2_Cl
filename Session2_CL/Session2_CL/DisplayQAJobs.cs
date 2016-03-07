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
            
            //repo.CLMiami.List.SearchForm.inputSearch.Click();
            
            
            //Report.Info("Ready to search");
            //Delay.Milliseconds(3000);
            
            String strClr = "{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}";
           
            Validate.Exists(repo.CLMiami.List.SearchForm.inputSearchInfo);
            Report.Info("Search Found");
            repo.CLMiami.List.SearchForm.inputSearch.PressKeys(strClr + "developer");
            repo.CLMiami.List.SearchForm.buttonSearch.Click();
            Delay.Milliseconds(2500);
            
           
           
           
            IList<ATag> localResults = Host.Local.Find<ATag>(repo.CLMiami.List.SelfInfo.AbsolutePath + "/div[@class='content']/p/span/span/a[@href~'miami.cr']");
            
            
            Report.Info(localResults.Count.ToString());
            
            int i = 0;
            string ReqPatern = "requirements(.*)";
            string text;
            for (i=1;i<10;i++){
            	string s = repo.CLMiami.List.SelfInfo.AbsolutePath + "/div[@class='content']/p[" + i.ToString() + "]/span/span/a[@href~'miami.cr']";
            	IList<ATag> localResTemp = Host.Local.Find<ATag>(s);
            	//Report.Info(s);
            	localResTemp[0].Click();           	
            	Delay.Milliseconds(1000);
            	
            	text = repo.WebDocumentIE.sectionPost.Element.GetAttributeValueText("InnerText");
            	Match m = Regex.Match(text,ReqPatern, RegexOptions.Singleline);
            	var lp = m.Groups[0].Value;
            	Report.Info(lp);
            	//Delay.Milliseconds(1000);
            	Host.Local.Click();
            	Host.Local.PressKeys("{BACK}");
            	Delay.Milliseconds(1000);
            	
            }
//            foreach (ATag atag in localResults){
//            	atag.Click();
//            	Delay.Milliseconds(1000);
//            	Host.Local.PressKeys("{BACK}");
//            	Delay.Milliseconds(1000);
//            	i++;
//            	if (i>3) break;
//            }
            
            
            
            
            
            
        }
    }
}
