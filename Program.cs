using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Web;
using System.Threading;
//break each section into methods
//parse table at bottom of code
//jenkins args to make it configurable for user
namespace selenium
{
    static class Global  
    {  
        public static string? currentURL;  
        public static string? newURL;  
         
    }  

    class Program
    {
        //initialize driver
        public static IWebDriver driver = new FirefoxDriver();
        
        public void ClassicURL(){
            Thread.Sleep(2000);
            Global.currentURL = driver.Url.Substring(0, driver.Url.LastIndexOf(".com") + 4);
            Thread.Sleep(2000);
        }
        public void AssessmentURL(){
            Thread.Sleep(5000);
            Global.newURL = driver.Url;
            Thread.Sleep(5000);
        }
        //check pop ups that could appear on pages
        public void PopUpChecker()

        {

            Thread.Sleep(5000);
            List<IWebElement> regPhone = new List<IWebElement>();
            Thread.Sleep(10000);
            regPhone.AddRange(driver.FindElements(By.LinkText("I Don't Want to Register My Phone")));
            Thread.Sleep(5000);
            if (regPhone.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.LinkText("I Don't Want to Register My Phone")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Phone page not present");
                Thread.Sleep(1000);
            }

            List<IWebElement> newGC = new List<IWebElement>();
            Thread.Sleep(5000);
            newGC.AddRange(driver.FindElements(By.XPath("//*[text() ='Meet the new Guidance Center']")));
            Thread.Sleep(5000);
            if (newGC.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("lightning-button-icon[class='close slds-popover__close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Blue focuesd content not present");
                Thread.Sleep(1000);
            }

            List<IWebElement> gC = new List<IWebElement>();
            Thread.Sleep(5000);
            gC.AddRange(driver.FindElements(By.CssSelector("h2[title='Guidance Center']")));
            Thread.Sleep(5000);
            if (gC.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("lightning-button-icon[class='slds-panel__close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Focused content not present");
                Thread.Sleep(1000);
            }

            List<IWebElement> stayAhead = new List<IWebElement>();
            Thread.Sleep(5000);
            stayAhead.AddRange(driver.FindElements(By.XPath("//*[text() ='Stay ahead of incidents']")));
            Thread.Sleep(5000);
            if (stayAhead.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("button[title='Close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Close not present1");
                Thread.Sleep(1000);
            }

            List<IWebElement> gA = new List<IWebElement>();
            Thread.Sleep(5000);
            gA.AddRange(driver.FindElements(By.CssSelector("h2[title='Generally Available']")));
            Thread.Sleep(5000);
            if (gA.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("button[title='Close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Close not present1");
                Thread.Sleep(1000);
            }

            List<IWebElement> mobile = new List<IWebElement>();
            Thread.Sleep(5000);
            mobile.AddRange(driver.FindElements(By.CssSelector("h2[title='Go Mobile']")));
            Thread.Sleep(5000);
            if (mobile.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("button[title='Close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Close not present1");
                Thread.Sleep(1000);
            }

            List<IWebElement> mfa = new List<IWebElement>();
            Thread.Sleep(5000);
            mfa.AddRange(driver.FindElements(By.CssSelector("h2[title='MFA Auto-Enablement Is Coming']")));
            Thread.Sleep(5000);
            if (mfa.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("button[title='Close']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Close not present");
                Thread.Sleep(1000);
            }

            List<IWebElement> closeDialog = new List<IWebElement>();
            Thread.Sleep(5000);
            closeDialog.AddRange(driver.FindElements(By.CssSelector("button[title='Close This Dialog']")));
            Thread.Sleep(5000);
            if (closeDialog.Count > 0)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("button[title='Close This Dialog']")).Click();
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(5000);
                Console.WriteLine("dialog not present");
                Thread.Sleep(5000);
            }
            Thread.Sleep(5000);

        }
        public void FrameSearch()
        {
            Thread.Sleep(6000);
            IWebElement frame = driver.FindElement(By.XPath("//iframe[contains(@name,'vfFrameId')]"));
            Thread.Sleep(5000);
            System.Console.WriteLine("found iframe");
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(frame);
            Thread.Sleep(6000);
        }
        public void ExamConfig(){
            Thread.Sleep(3000);
            Boolean link = driver.FindElement(By.LinkText("ExAM Configuration")).Displayed && driver.FindElement(By.LinkText("ExAM Configuration")).Enabled;
            Thread.Sleep(3000);
            if (link == true)
            {
                Thread.Sleep(3000);
                System.Console.WriteLine("not null");
                driver.FindElement(By.LinkText("ExAM Configuration")).Click();
                Thread.Sleep(3000);
            }
            else
            {
                Thread.Sleep(3000);
                System.Console.WriteLine("null");
                driver.FindElement(By.ClassName("slds-dropdown")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("ExAM Configuration")).Click();
                Thread.Sleep(3000);
            }
        }
        public void ExamLight(){
            Thread.Sleep(5000);
            driver.FindElement(By.ClassName("slds-icon-waffle")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button[aria-label='View All Applications']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//p[text() ='ExAM Lightning']")).Click();
            Thread.Sleep(5000);
        }
        public void SaleClassic(){
            Program pro = new Program();
            Thread.Sleep(8000);
            driver.FindElement(By.CssSelector("button[class='slds-button branding-userProfile-button slds-button slds-global-actions__avatar slds-global-actions__item-action forceHeaderButton']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Switch to Salesforce Classic")).Click();
            Thread.Sleep(8000);
            //save url
            pro.ClassicURL();
            Thread.Sleep(3000);
            //Back to lightning Experience
            driver.FindElement(By.LinkText("Switch to Lightning Experience")).Click();
            Thread.Sleep(8000);
        }
        public void AssessAny(){
            Program pro = new Program();
            pro.FrameSearch();
            Boolean saveED = driver.FindElement(By.XPath("//*[text()='Save Endpoint URL']")).Displayed && driver.FindElement(By.XPath("//*[text()='Save Endpoint URL']")).Enabled;
            if (saveED == true)
            {
                System.Console.WriteLine("not null");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("domainName")).SendKeys(Global.currentURL);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[text()='Save Endpoint URL']")).Click();
                Thread.Sleep(8000);
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
            }
            else
            {
                System.Console.WriteLine("null");
                Thread.Sleep(3000);
                var editED = driver.FindElement(By.XPath("//*[text()='Edit Endpoint URL']"));
                Thread.Sleep(3000);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editED);
                Thread.Sleep(3000);
                editED.Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("domainName")).Clear();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("domainName")).SendKeys(Global.currentURL);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[text()='Save Endpoint URL']")).Click();
                Thread.Sleep(8000);
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
            }
        }
        public void SetupPage(){
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("div[class='setupGear']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("related_setup_app_home")).Click();
            Thread.Sleep(3000);
        }
        public void RemoteSites(){
            Program pro = new Program();
            driver.FindElement(By.CssSelector("input[class='filter-box input']")).SendKeys("Remote site settings");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Remote Site Settings")).Click();
            pro.FrameSearch();
            driver.FindElement(By.LinkText("MetaDataEndPoint")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.XPath(".//td[@id='topButtonRow']/input[@name='edit']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
        }
        public void PublicSiteURL(){
            Thread.Sleep(3000);
            driver.FindElement(By.Id("EndpointUrl")).SendKeys(Global.currentURL);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//td[@id='topButtonRow']/input[@name='save']")).Click();
            Thread.Sleep(8000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void AssessStatus(){
            Program pro = new Program();
            pro.FrameSearch();
            driver.FindElement(By.XPath("//input[@value='Edit']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("statusValId")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("option[label='Completed']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@ng-click='savestatusInBackEnd()']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("selectSample1")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//option[@label='Contact']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[text()='Create ExAM to Object']")).Click();
            Thread.Sleep(3000);
            var alertOK2 = driver.SwitchTo().Alert();
            Thread.Sleep(5000);
            alertOK2.Accept();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void NaviSites(){
            Program pro = new Program();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[class='filter-box input']")).SendKeys("Sites");
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Sites")).Click();
            pro.FrameSearch();
        }
        public void SiteCreation(){
            Program pro = new Program();
            Thread.Sleep(5000);
            Boolean newSite = driver.FindElement(By.Id("thePage:theForm:setDomainPB:termsCB")).Displayed && driver.FindElement(By.Id("thePage:theForm:setDomainPB:termsCB")).Enabled;
            Thread.Sleep(5000);
            if(newSite == true){
                Thread.Sleep(5000);
                driver.FindElement(By.Id("thePage:theForm:setDomainPB:termsCB")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("thePage:theForm:setDomainPB:registerDomain")).Click();
                Thread.Sleep(5000);
                var alertOK = driver.SwitchTo().Alert();
                Thread.Sleep(5000);
                alertOK.Accept();
            }else{
                Thread.Sleep(5000);
                System.Console.WriteLine("domain already created");
            }
            //handle alert pop up
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.Id("thePage:form:new")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockSection:labelSection:MasterLabel")).SendKeys("Assessment");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockSection:urlPathPrefixSection:UrlPathPrefix")).SendKeys("assessment");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockSection:ActiveSec:Status")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockSection:IndexPageSec:IndexPage")).SendKeys("PublicAssessmentPage");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockSection:clickjackProtectionLevelSection:clickjackProtectionLevel")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("option[value='A']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("thePage:theForm:thePageBlock:thePageBlockButtons:bottom:save")).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            System.Console.WriteLine("COMPLETED");
            Thread.Sleep(5000);
        }
        public void EnableVisual(){
            Program pro = new Program();
            pro.FrameSearch();
            //edit visual pages that need to be enabled
            driver.FindElement(By.CssSelector("input[name='edit']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            //select all visiual pages that need to be enabled
            //use javascript to have it scroll
            var answer = driver.FindElement(By.XPath("//*[text()='ExAM.AMAndAnswerCreationPage']"));
            Thread.Sleep(3000);
            var viewer = driver.FindElement(By.XPath("//*[text()='ExAM.AssessmentViewer']"));
            Thread.Sleep(3000);
            var viewerPage = driver.FindElement(By.XPath("//*[text()='ExAM.AssessmentViewerPage']"));
            Thread.Sleep(3000);
            var dashboard = driver.FindElement(By.XPath("//*[text()='ExAM.Dashboard']"));
            Thread.Sleep(3000);
            var fileUpload = driver.FindElement(By.XPath("//*[text()='ExAM.FileUpload']"));
            Thread.Sleep(3000);
            var sessionID = driver.FindElement(By.XPath("//*[text()='ExAM.GetSessionId']"));
            Thread.Sleep(3000);
            var home = driver.FindElement(By.XPath("//*[text()='ExAM.PublicAssessmentHome']"));
            Thread.Sleep(3000);
            var add = driver.FindElement(By.CssSelector("img[title='Add']"));
            Thread.Sleep(3000);
            var save = driver.FindElement(By.CssSelector("input[value=' Save ']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", answer);
            Thread.Sleep(1000);
            answer.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", viewer);
            Thread.Sleep(1000);
            viewer.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", viewerPage);
            Thread.Sleep(1000);
            viewerPage.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", dashboard);
            Thread.Sleep(1000);
            dashboard.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fileUpload);
            Thread.Sleep(1000);
            fileUpload.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sessionID);
            Thread.Sleep(1000);
            sessionID.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", home);
            Thread.Sleep(1000);
            home.Click();
            Thread.Sleep(1000);
            add.Click();
            Thread.Sleep(1000);
            save.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("scrolled to element");
            Thread.Sleep(10000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void NaviSiteURL(){
            Program pro = new Program();
            pro.FrameSearch();
            driver.FindElement(By.XPath("//*[text()='Back to List:  Sites']")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            //navigate to grab site url
            driver.FindElement(By.CssSelector("a[target='_blank']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.NewTab(3);
            //copy site url
            pro.AssessmentURL();
            driver.Close();
            pro.NewTab(2);
        }
        public void PasteSiteURL(){
            Program pro = new Program();
            pro.FrameSearch();
            //paste site url
            driver.FindElement(By.CssSelector("input[value='Edit Configuration']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input[placeholder='Enter Site Url']")).SendKeys(Global.newURL);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@ng-click='validateUsrEnteredUrl()']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void NaviExAMPerm(){
            Program pro = new Program();
            pro.ViewAllAssess();
            driver.FindElement(By.CssSelector("input[value='View Users']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.LinkText("Site Guest User, Assessment")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
        }
        public void ExAMAssign(){
            Thread.Sleep(5000);
            var assign = driver.FindElement(By.CssSelector("input[title='Assign Licenses']"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", assign);
            Thread.Sleep(5000);
            assign.Click();
            Thread.Sleep(5000);
        }
        public void ViewAllAssess(){
            Program pro = new Program();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Assessment")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.CssSelector("a[name='thePage:form:thePageBlock:pageBlockButtons:pas']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
        }
        public void ExAMLicenseAdd(){
            Thread.Sleep(5000);
            IWebElement frameLicenses = driver.FindElement(By.XPath("//iframe[@name='available']"));
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(frameLicenses);
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[value='1']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[value=' Add ']")).Click();
            Thread.Sleep(10000);
            driver.Close();
            Thread.Sleep(5000);
        }
        public void SetSystemPerm(){  
            Program pro = new Program();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Sites")).Click();
            pro.FrameSearch();
            pro.ViewAllAssess();
            driver.FindElement(By.XPath(".//td[@id='topButtonRow']/input[@name='edit']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            //set system permissions
            var accessActivities = driver.FindElement(By.XPath(".//input[@title='Access Libraries']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", accessActivities);
            Thread.Sleep(3000);
            accessActivities.Click();
            Thread.Sleep(3000);
            var accessLibraries = driver.FindElement(By.XPath(".//input[@title='Access Activities']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", accessLibraries);
            Thread.Sleep(3000);
            accessLibraries.Click();
            Thread.Sleep(3000);
            var apdm = driver.FindElement(By.XPath(".//input[@title='Add People to Direct Messages']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", apdm);
            Thread.Sleep(3000);
            apdm.Click();
            Thread.Sleep(3000);
            var aaca = driver.FindElement(By.XPath(".//input[@title='Allow Access to Customized Actions']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", aaca);
            Thread.Sleep(3000);
            aaca.Click();
            Thread.Sleep(3000);
            var pne = driver.FindElement(By.XPath(".//select[@id='PasswordExpiration']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", pne);
            Thread.Sleep(3000);
            pne.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[text()='Never expires']")).Click();
            Thread.Sleep(3000);
            var sfs = driver.FindElement(By.XPath(".//input[@title='Select Files from Salesforce']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sfs);
            Thread.Sleep(3000);
            sfs.Click();
            Thread.Sleep(3000);
            var som = driver.FindElement(By.XPath(".//input[@title='Send Outbound Messages']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", som);
            Thread.Sleep(3000);
            som.Click();
            Thread.Sleep(3000);
            var salc = driver.FindElement(By.XPath(".//input[@title='Show App Launcher in Experience Cloud Sites']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", salc);
            Thread.Sleep(3000);
            salc.Click();
            Thread.Sleep(3000);
            var scncr = driver.FindElement(By.XPath(".//input[@title='Show Company Name as Site Role']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", scncr);
            Thread.Sleep(3000);
            scncr.Click();
            Thread.Sleep(3000);
            var vacs = driver.FindElement(By.XPath(".//input[@title='View All Custom Settings']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", vacs);
            Thread.Sleep(3000);
            vacs.Click();
            Thread.Sleep(3000);
        }
        public void SetObjectPerm(){
            Thread.Sleep(5000);
            var cop = driver.FindElement(By.XPath(".//input[@title='Create Answers']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", cop);
            Thread.Sleep(3000);
            cop.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Create Answer Options']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Read Assessable Fields Mappings']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Create Assessment Templates']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Create Assignment Managers']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Read Dashboard Details']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Read Distributions']")).Click();
            Thread.Sleep(3000);
            var cop2 = driver.FindElement(By.XPath(".//input[@title='Read ExAM Configurations']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", cop2);
            Thread.Sleep(3000);
            cop2.Click();
            Thread.Sleep(3000);
            var cop3 = driver.FindElement(By.XPath(".//input[@title='Read Layout Configurations']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", cop3);
            Thread.Sleep(3000);
            cop3.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Read Lookup Filter Templates']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Create Public Assessments']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@title='Create Question Templates']")).Click();
            Thread.Sleep(3000);
            var save2 = driver.FindElement(By.XPath(".//td[@id='bottomButtonRow']/input[@name='save']"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", save2);
            Thread.Sleep(3000);
            save2.Click();
            Thread.Sleep(8000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void CustomPerm(){
            Program pro = new Program();
            pro.FrameSearch();
            var ecsda = driver.FindElement(By.XPath("//input[contains(@onclick,'ProfileCustomSettingPermissionEdit')]"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ecsda);
            Thread.Sleep(3000);
            ecsda.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            var eac = driver.FindElement(By.XPath("//*[text()='ExAM.ExAM.Admin Configuration']"));
            Thread.Sleep(3000);
            eac.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("img[title='Add']")).Click();
            Thread.Sleep(3000);
            var keys = driver.FindElement(By.XPath("//*[text()='ExAM.ExAM.ExAM API Keys']"));
            Thread.Sleep(3000);
            keys.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("img[title='Add']")).Click();
            Thread.Sleep(3000);
            var sfsd = driver.FindElement(By.XPath("//*[text()='ExAM.ExAM.SF sub-domain']"));
            Thread.Sleep(3000);
            sfsd.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("img[title='Add']")).Click();
            Thread.Sleep(3000);
            var sdo = driver.FindElement(By.XPath("//*[text()='ExAM.ExAM.Static Data Object']"));
            Thread.Sleep(3000);
            sdo.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("img[title='Add']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input[value=' Save ']")).Click();;
            Thread.Sleep(8000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void FieldLevelSecurity(){
            Program pro = new Program();
            pro.FrameSearch();
            //185 changes each exam: custom account object
            //parse custom field level table to map out to answers and assignmentmanger&&same for their field security
            /*IWebElement allCustomFieldLevelSecurity = driver.FindElement(By.XPath("//div[@id='ep']/div[2]/div[9]/table/tbody"));
            List<IWebElement> rows = allCustomFieldLevelSecurity.FindElements(By.TagName("tr")).ToList();
            foreach (IWebElement row in rows) {
                List<IWebElement> cols = row.FindElements(By.TagName("td")).ToList();
                foreach (IWebElement col in cols) {
                    //counter to track position
                    //if col = assignment manger
                    //if col = answers
                    System.Console.WriteLine(col.Text + "\t");
                }
                System.Console.WriteLine();
            }*/
            var fpAnswer = driver.FindElement(By.XPath("(//div[@id='ep']/div[2]/div[9]/table/tbody/tr/td[contains(text(),'Answer')]/following-sibling::td/a)"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fpAnswer);
            Thread.Sleep(3000);
            fpAnswer.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.XPath(".//input[@name='save']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            //changes each exam: contact row 10 column 3/4
            driver.FindElement(By.XPath("//td[starts-with(text(),'Contact')]/following-sibling::td[@class='dataCell readonlyCol']/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//td[starts-with(text(),'Contact')]/following-sibling::td[@class='dataCell displayedCol']/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@name='save']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.XPath(".//input[@value='Back to Profile']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            var fpAM = driver.FindElement(By.XPath("(//div[@id='ep']/div[2]/div[9]/table/tbody/tr/td[contains(text(),'Assignment Manager')]/following-sibling::td/a)"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fpAM);
            Thread.Sleep(3000);
            fpAM.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.XPath(".//input[@name='save']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            //doesnt change but could change each exam: Assignment manager row 29 column 3/4
            driver.FindElement(By.XPath("//td[starts-with(text(),'Contact')]/following-sibling::td[@class='dataCell readonlyCol']/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//td[starts-with(text(),'Contact')]/following-sibling::td[@class='dataCell displayedCol']/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//input[@name='save']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            pro.FrameSearch();
            driver.FindElement(By.XPath(".//input[@value='Back to Profile']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }
        public void NewTab(int i){
            Thread.Sleep(5000);
            var child = driver.WindowHandles[i];
            Thread.Sleep(5000);
            driver.SwitchTo().Window(child);
            Thread.Sleep(5000);
        }
        //Configure ExAM
        static void Main(string[] args)
        {

            Program pro = new Program();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
            Thread.Sleep(10000);
            //login to ExAM
            driver.Manage().Window.Maximize();
            Thread.Sleep(30000);
            //overall endpoint
            Console.WriteLine(args[0]);
            driver.Navigate().GoToUrl(args[0]);
            Thread.Sleep(10000);
            Console.WriteLine(args[1]);
            driver.FindElement(By.Id("username")).SendKeys(args[1]);
            Thread.Sleep(1000);
            Console.WriteLine(args[2]);
            driver.FindElement(By.Id("password")).SendKeys(args[2]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(1000);
            
           /* driver.Navigate().GoToUrl(examURL);
            Thread.Sleep(30000);
            driver.FindElement(By.Id("username")).SendKeys(examUsername);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("password")).SendKeys(examPassword);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Login")).Click();*/
            Thread.Sleep(1000);
            //check pop ups
            pro.PopUpChecker();
            //navigate to ExAM lightning
            pro.ExamLight();
            //check pop ups
            pro.PopUpChecker();
            //navigate to salesforce classic
            pro.SaleClassic();
            //navigate to ExAM Configuration
            pro.ExamConfig();
            //paste url from salesforce classic
            pro.AssessAny();
            //navigate to setup page
            pro.SetupPage();
            //swap to new tab window
            pro.NewTab(1);
            //navigating to remote sites
            pro.RemoteSites();  
            //paste url from salesforce classic
            pro.PublicSiteURL();
            //navigate ExAM configuration
            pro.ExamLight();
            //going to exam config page
            pro.ExamConfig();
            //Assess Anything and changing overall Status
            pro.AssessStatus();
            //handles assess anything pop up
            //navigate to sites
            pro.SetupPage();
            //change to new tab window
            pro.NewTab(2);
            pro.NaviSites();
            //create site name
            pro.SiteCreation();
            pro.EnableVisual();
            pro.NaviSiteURL();
            //navigate to ExAM lightning
            pro.ExamLight();
            pro.ExamConfig();
            pro.PasteSiteURL();
            pro.SetupPage();
            //switch to new tab window
            pro.NewTab(3);
            //navigate to sites
            pro.NaviSites();
            //navigate to give user ExAM permission
            pro.NaviExAMPerm();
            //assign ExAM licenses
            pro.ExAMAssign();
            //change to new tab window
            pro.NewTab(4);
            //check box and add licenses
            pro.ExAMLicenseAdd();
            //set System permissions
            pro.NewTab(3);
            pro.SetSystemPerm();
            //set object permissions read/create
            pro.SetObjectPerm();
            //set custom permissions
            pro.CustomPerm();
            //set field permissions
            //copy here
            pro.FieldLevelSecurity();
            driver.Quit();
        }
    }
}