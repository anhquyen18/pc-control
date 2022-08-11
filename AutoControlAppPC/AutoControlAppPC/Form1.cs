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
    }
}
