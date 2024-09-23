using System;
using System.IO;
using System.Windows.Forms;

namespace 便携式文件操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e) // 重命名文件
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string directoryPath = textBox1.Text;

                // 确保目标目录存在
                if (Directory.Exists(directoryPath))
                {
                    // 获取目录中的所有文件
                    string[] files = Directory.GetFiles(directoryPath);

                    // 遍历每个文件，重命名
                    for (int i = 0; i < files.Length; i++)
                    {
                        string oldFilePath = files[i];

                        // 获取文件的扩展名
                        string extension = Path.GetExtension(oldFilePath);

                        // 创建新的文件名
                        string newFileName = $"{i + 1}{extension}";
                        string newFilePath = Path.Combine(directoryPath, newFileName);

                        // 检查目标文件路径是否已经存在
                        if (File.Exists(newFilePath))
                        {
                            // 增加后缀数字确保唯一性
                            int count = 1;
                            while (File.Exists(newFilePath))
                            {
                                newFileName = $"{i + 1}_{count}{extension}";
                                newFilePath = Path.Combine(directoryPath, newFileName);
                                count++;
                            }
                        }

                        // 重命名文件
                        File.Move(oldFilePath, newFilePath);
                    }

                    label3.Text = "文件编号全部完成。";
                }
                else
                {
                    label3.Text = "指定的目录不存在。";
                }
            }
            else
            {
                label3.Text = "请指定要重命名的文件夹。";
            }
        }

        private void button2_Click(object sender, EventArgs e) // 添加前缀的按钮
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Text = "请指定文件夹路径。";
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label3.Text = "请提供前缀。";
                return;
            }

            string directoryPath = textBox1.Text;
            string prefix = textBox2.Text;

            // 确保目标目录存在
            if (Directory.Exists(directoryPath))
            {
                // 获取目录中的所有文件
                string[] files = Directory.GetFiles(directoryPath);

                // 遍历每个文件，添加前缀
                foreach (var file in files)
                {
                    string oldFilePath = file;
                    string extension = Path.GetExtension(oldFilePath);
                    string newFileName = $"{prefix}{Path.GetFileName(oldFilePath)}"; // 添加前缀到文件名
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (File.Exists(newFilePath))
                    {
                        // 如果新文件名已存在，添加后缀以避免冲突
                        int count = 1;
                        while (File.Exists(newFilePath))
                        {
                            newFileName = $"{prefix}{Path.GetFileNameWithoutExtension(oldFilePath)}_{count}{extension}";
                            newFilePath = Path.Combine(directoryPath, newFileName);
                            count++;
                        }
                    }

                    // 重命名文件
                    File.Move(oldFilePath, newFilePath);
                }

                label3.Text = "前缀添加完成。";
            }
            else
            {
                label3.Text = "指定的目录不存在。";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // 文件路径
        {
            // 你可以添加相应的事件处理代码
        }

        private void label3_Click(object sender, EventArgs e) // 提示信息的标签
        {
            // 你可以添加相应的事件处理代码
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)  
        {

        }
    }
}
