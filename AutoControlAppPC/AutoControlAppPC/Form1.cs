using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAutoHelper;

namespace AutoControlAppPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\User\\Downloads\\Telegram Desktop\\Ask Me Anything 16.12.21.docx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "/C ping -t howkteam.com";

            Process.Start("CMD.exe", strCmdText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = @"/C ""C:\\Users\\User\\Downloads\\Telegram Desktop\\Ask Me Anything 16.12.21.docx""";

            Process p = new Process();
            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = strCmdText;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

            //p.Kill();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmdCommand = "ping howkteam.com";

            Process cmd = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            //startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            cmd.StartInfo = startInfo;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            MessageBox.Show(cmd.StandardOutput.ReadToEnd());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = (int) numericUpDown1.Value;
            int y = (int) numericUpDown2.Value;

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.MouseClick(x, y,  mouseKey);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            //var hWnd = Process.GetProcessById(12012).MainWindowHandle;
            //var hWnd = Process.GetProcessesByName("Remote Desktop Connection")[0].MainWindowHandle;
            var hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            // Lấy ra tọa độ màn hình của tọa độ trên cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(hWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }
            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            var hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = IntPtr.Zero;
            // Tìm ra handle con mà thỏa điều kiện text và class y chang
            childhWnd = AutoControl.FindWindowExFromParent(hWnd, null, textBox2.Text);

            // Tìm ra handle con mà thỏa text hoặc class giống
            childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox1.Text);

            // Lấy ra tọa độ màn hình của tọa độ trên cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(childhWnd, 0, 0);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }
            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendKeyFocus(KeyCode.ENTER);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendMultiKeysFocus(new KeyCode[] {KeyCode.CONTROL, KeyCode.KEY_V });
        }

        private void button13_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.SendText(hWnd, "anhquyendeptrai");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, "ComboBoxEx32", null);

            AutoControl.SendText(childhWnd, "anhquyendeptrai");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);

            AutoControl.SendClickOnControlByHandle(childhWnd);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);

            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            // Phải click vào handle con. Không thể click vào handle window
            // Không phải ứng dụng nào cũng click được

            AutoControl.SendClickOnPosition(childhWnd, x, y);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.SendKeyBoardPress(hWnd, VKeys.VK_RETURN);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.png");

            var subBitmap = ImageScanOpenCV.GetImage("template.png");

            var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, (Bitmap)subBitmap);

            if (resBitmap != null)
            {
                resBitmap.Save("res.png");
                    
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.png");

            var subBitmap = ImageScanOpenCV.GetImage("template.png");

            var resBitmap = ImageScanOpenCV.FindOutPoint((Bitmap)screen, (Bitmap)subBitmap);

            if (resBitmap != null)
            {
                MessageBox.Show(resBitmap.ToString());

            }
        }
    }

}
