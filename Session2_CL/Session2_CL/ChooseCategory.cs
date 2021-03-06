﻿/*
 * Created by Ranorex
 * User: automation
 * Date: 2/28/2016
 * Time: 6:18 PM
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
    /// Description of ChooseCategory.
    /// </summary>
    [TestModule("D60D95EB-BACF-44F2-950B-065A697DCF0E", ModuleType.UserCode, 1)]
    public class ChooseCategory : ITestModule
    {
    	public static Session2_CLRepository repo = Session2_CLRepository.Instance; 
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ChooseCategory()
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
            
            repo.CLMiamiCat.Categories.spanQA.Click();
        }
    }
}
