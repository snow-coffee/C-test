using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //textboxから実行したいプロセス名を取得
            string pstext = textBox1.Text;

            //引数用のtextbox2から引数を取得
            string tmptext = textBox2.Text;

            //Processオブジェクトを作成する
            System.Diagnostics.Process psstart = new System.Diagnostics.Process();
            //実行するプロセスを指定する
            psstart.StartInfo.FileName = (pstext);
            //textbox2に文字列が入力されていた場合は引数として渡す
            if (tmptext != "") {
                psstart.StartInfo.Arguments = (tmptext);

            }
            //プロセスを実行する
            psstart.Start();
            //プロセス終了後のmessagebox用にプロセス名を取得する
            string psname = psstart.ProcessName.ToString();
            //同期状態で待機する
            psstart.WaitForExit();

            //プロセスが終了した後にメッセージボックスで結果を表示
            MessageBox.Show("実行していたプロセスが終了しました。\n\n実行プロセス名 : "+ psname + 
                "\n引数 : "+ tmptext + "\n終了コード : " + psstart.ExitCode.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //終了ボタンで終了する。
            Application.Exit();
        }
    }
}
