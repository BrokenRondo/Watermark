using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using addOp;
using PSNR;
using WatermarkEmbed;
using System.IO;

namespace CSMATLAB8051056
{
    public partial class Form1 : Form
    {
        private string fCarrier="";
        private string fWatermark="";
        private string fMarked = "";
        private string fSrcIMG = "";
        private string textIMG = "text.ico";
        private string fKey = "";
        bool flag_Robust = false;
        bool haskey = false;
        string strength = "";
        int stren = 0;
        string len_str = "";
        int len = 0;
        string j_str = "";
        string i_str = "";
        int i, j = 0;
        double seed = 0.992;
        public enum Options
        {
            visible_direct,
            visible_add,
            visible_mult,
            LSB_PIXEL,
            LSB_DCT,
            ROBUST_SS,
            ROBUST_QIM,
            ROBUST_ANTITRANSFORM
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

         //     ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
         //     Color.White, 1, ButtonBorderStyle.Solid, //左边
　　　　　    //Color.White, 1, ButtonBorderStyle.Solid, //上边
　　　　　    //Color.DimGray, 1, ButtonBorderStyle.Solid, //右边
　　　　　    //Color.DimGray, 1, ButtonBorderStyle.Solid);//底边
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

 

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                fCarrier = openFileDialog.FileName;
                pictureBox3.Load(fCarrier);
                //Console.Write(fName);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //释放右边picturebox占用的资源
            try
            {
                this.pictureBox4.Image.Dispose();
                this.pictureBox4.Image = null;
            }catch
            {

            }
            if(comboBox2.SelectedIndex==-1)
            {
                DialogResult dr = MessageBox.Show("请选择嵌入方式！", "警告");
                return;
            }
            if (fCarrier == "")
            {
                DialogResult dr;
                dr = MessageBox.Show("请选择载体图片！", "警告", MessageBoxButtons.OKCancel);
                return;
            }
            if (fWatermark=="")
            {
                DialogResult dr;
                dr = MessageBox.Show("请选择水印图片！", "警告", MessageBoxButtons.OKCancel);
                return;
            }
            string seed_str = textBox1.Text.ToString();
            if (seed_str==""&&flag_Robust)
            {
                DialogResult dr = MessageBox.Show("未输入种子，将按照默认种子嵌入！", "提示", MessageBoxButtons.OKCancel);
                if(dr==DialogResult.OK)
                {
                    seed_str = "0.8";
                }
                else
                {
                    return;
                }
                //return;
            }
            double seed = 0;
            try
            {
                seed = System.Convert.ToDouble(seed_str);
            }catch
            {
                seed = 0.8;
            }
            if(flag_Robust&&(seed>=1||seed<=0.5)&&seed<4)
            {
                DialogResult dr = MessageBox.Show("种子不符合范围，是否采用默认种子？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    seed = 0.8;
                    textBox1.Text = "0.8";
                }
                else
                {
                    return;
                }
            }
            
            try
            {
                strength = comboBox1.SelectedItem.ToString();
            }catch
            {
                strength = "";
            }
            if(strength==""&& flag_Robust)
            {
                DialogResult dr = MessageBox.Show("未选择强度，将按照默认强度嵌入！", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    strength = "1";
                else
                {
                    return;
                }
                    
            }
            
            try
            {
                stren = System.Convert.ToInt32(strength);
            }catch
            {
                stren = 1;
            }
            
            try
            {
                len_str = textBox2.Text.ToString();
            }
            catch
            {
                len_str = "";
            }
            if(len_str==""&& flag_Robust)
            {
                DialogResult dr = MessageBox.Show("未选择扩频长度，将按照默认长度嵌入！", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    len_str = "5";
                }
                else
                    return;
            }

            try
            {
                len = Convert.ToInt32(len_str);
            }catch
            {
                len = 7;
            }
            try
            {
                j_str = textBox3.Text.ToString();
                i_str = textBox4.Text.ToString();
            }catch
            {
                i_str = "4";
                j_str = "4";
            }
           
            if(flag_Robust&&(i_str == ""||j_str==""))
            {
                DialogResult dr = MessageBox.Show("未选择嵌入密度，将按照默认密度嵌入！", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    i_str = "4";
                    j_str = "4";
                }
                else
                    return;
            }
            MessageBox.Show("正在嵌入密钥，在下一个提示框弹出前请勿关闭程序", "提示");
            
            try
            {
                i = Convert.ToInt32(i_str);
                j = Convert.ToInt32(j_str);
            }catch
            {
                i = 4;
                j = 4;
            }
            //addOp.Class1 hello = new addOp.Class1();
            //// double[] a = { 1, 2, 3, 4, 5, 6 };
            //double[,] a = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            ////double[] b = { 1, 2, 3, 4, 5, 6 };
            //double[,] b = new double[,] { { 1, 1, 1 }, { 1, 1, 1 } };
            //double[,] c = new double[2, 3];
            //double[,] d = new double[2, 3];
            //MWNumericArray ma = a;
            //MWNumericArray mb = b;//转成matlab的格式
            //MWArray[] argsOut = new MWArray[2];//表示两个输出参数
            //MWArray[] argsIn = new MWArray[] { ma, mb };

            //hello.addOp(2, ref argsOut, argsIn);
            //MWNumericArray x1 = argsOut[0] as MWNumericArray;
            //MWNumericArray x2 = argsOut[1] as MWNumericArray;
            //c = (double[,])x1.ToArray();
            //d = (double[,])x2.ToArray();
            //string add = "";
            //string sub = "";
            //for (int i1 = 0; i < 2; i++)
            //{
            //    for (int j1 = 0; j < 3; j++)
            //    {

            //        add += c[i1, j1].ToString() + "\t";
            //        sub += d[i1, j1].ToString() + "\t";

            //    }
            //    add += "\n";
            //    sub += "\n";
            //}
            //Console.WriteLine(add + "\n");
            //Console.WriteLine(sub + "\n");
            //richTextBox1.Text=add;
            string []key=new string[10];
            key[0] = seed_str;
            key[1] = strength;
            key[2] = len_str;
            key[3] = i_str;
            key[4] = j_str;
            System.IO.File.WriteAllLines("key.txt", key);

            int option = comboBox2.SelectedIndex;
            Options options = new Options();
            switch (option)
            {
                case 0:
                    visible_direct();
                    break;
                case 1:
                    visible_add();
                    break;
                case 2:
                    visible_mult();
                    break;
                case 3:
                    LSB_DCT();
                    break;
                case 4:
                    LSB_JPG();
                    break;
                case 5:
                    ROBUST_SS();
                    break;
                case 6:
                    ROBUST_QIM();
                    break;
                case 7:
                    ROBUST_ANTITRANSFORM();
                    break;
            }
            DialogResult dre = MessageBox.Show("水印嵌入已完成，密钥已保存在程序路径下key.txt中", "提示", MessageBoxButtons.OK);
            flag_Robust = false;
            haskey = false;
            strength = "";
            stren = 0;
            len_str = "";
            len = 0;
            j_str = "";
            i_str = "";
            j = 0;
            seed = 0.992;


    }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fWatermark = openFileDialog.FileName;
                pictureBox1.Load(fWatermark);
                //Console.Write(fName);

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fCarrier = openFileDialog.FileName;
                pictureBox3.Load(fCarrier);
                //Console.Write(fName);

            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;

            richTextBox1.ScrollToCaret();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex==5||comboBox2.SelectedIndex==6)
            {
                label1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                comboBox1.Visible = true;
                label5.Visible = true;
                label5.Text = "密钥种子";
                label6.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                flag_Robust = true;
                comboBox1.SelectedIndex = 2;
            }
            else if(comboBox2.SelectedIndex == 7)
            {
                label1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "8";
                comboBox1.Visible = true;
                label5.Text = "分块长宽";
                label6.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                flag_Robust = true;
                comboBox1.SelectedIndex = 2;
            }
            else
            {
                label1.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                comboBox1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fWatermark = openFileDialog.FileName;
                try
                {
                    pictureBox1.Load(fWatermark);
                }catch
                {
                    pictureBox1.Load(textIMG);
                }
            
                //Console.Write(fName);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        public void visible_direct()
        {
            Visible_Embed.Class1 visible_embed = new Visible_Embed.Class1();
            string mat_image = fCarrier;
            string mat_mark = fWatermark;
            int option = 0;
            try
            {
                visible_embed.Visible_Embed(mat_image, mat_mark, option);
            }catch
            {
                MessageBox.Show("嵌入出错！请检查水印和载体是否为三通道图像！", "警告");
                return;
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile("visibleMarked.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();

            pictureBox4.Image = bmp;
            fMarked = "visibleMarked.bmp";
        }
        public void visible_add()
        {
            Visible_Embed.Class1 visible_embed = new Visible_Embed.Class1();
            string mat_image = fCarrier;
            string mat_mark = fWatermark;
            int option = 1;
            try
            {
                visible_embed.Visible_Embed(mat_image, mat_mark, option);
            }
            catch
            {
                MessageBox.Show("嵌入出错！请检查水印和载体是否为三通道图像！", "警告");
                return;
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile("visibleMarked.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();

            pictureBox4.Image = bmp;
            fMarked = "visibleMarked.bmp";
        }
        public void visible_mult()
        {
            Visible_Embed.Class1 visible_embed = new Visible_Embed.Class1();
            string mat_image = fCarrier;
            string mat_mark = fWatermark;
            int option = 2;
            try
            {
                visible_embed.Visible_Embed(mat_image, mat_mark, option);
            }
            catch
            {
                MessageBox.Show("嵌入出错！请检查水印和载体是否为三通道图像！", "警告");
                return;
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile("visibleMarked.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();

            pictureBox4.Image = bmp;
            fMarked = "visibleMarked.bmp";
        }
        public void LSB_DCT()
        {
            visible_DCT.Class1 visible_dct = new visible_DCT.Class1();
            string src = fCarrier;
            string watermark = fWatermark;
            MWCharArray src_mw = src;
            MWCharArray watermark_mw = watermark;
            try
            {
                visible_dct.visible_DCT(src_mw, watermark_mw);
            }
            catch
            {
                MessageBox.Show("嵌入失败，请尝试其他图片", "提示");
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile("visible_DCT.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();
            pictureBox4.Image = bmp;
            fMarked = "visible_DCT.bmp";
        }
        public void LSB_JPG()
        {
            WatermarkEmbed.Class1 watermarkEmbed = new WatermarkEmbed.Class1();
            string mat_image = fCarrier;
            string LSB_Message = fWatermark;
            MWCharArray mat_image_mw = mat_image;
            MWCharArray LSB_Message_mw = LSB_Message;
            MWArray[] argsMatImage = new MWArray[] { mat_image_mw, LSB_Message_mw };
            try
            {
                watermarkEmbed.WatermarkEmbed(mat_image_mw, LSB_Message_mw);
            }
            catch
            {
                MessageBox.Show("嵌入失败！请注意是否选择了非JPG格式图片，或嵌入文本过长", "警告！");
                return;
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile("DCT_LSB.jpg");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();

            pictureBox4.Image = bmp;
            fMarked = "DCT_LSB.jpg";
            pictureBox4.Image = bmp;
            pictureBox2.Image = bmp;

        }
        public void ROBUST_SS()
        {
            Embed.Class1 embed = new Embed.Class1();
            MWCharArray src_img = fCarrier;
            MWCharArray watermark = fWatermark;
            int stren_mw = stren;
            try
            {
                embed.Embed(src_img, watermark, stren_mw, len, i, j, seed);
            }
            catch
            {
                MessageBox.Show("嵌入失败！请注意是否选择了非BMP格式图片，或嵌入文本过长", "警告！");
                return;
            }
            fMarked = "SSEmbeded.bmp";
            System.Drawing.Image img = System.Drawing.Image.FromFile("SSEmbeded.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();
            pictureBox4.Image = bmp;
            pictureBox2.Image = bmp;
        }
        public void ROBUST_QIM()
        {
            Embed2.Class1 embed2 = new Embed2.Class1();
            MWCharArray src_img = fCarrier;
            MWCharArray watermark_txt = fWatermark;
            try
            {
                embed2.Embed2(src_img, watermark_txt, len, i, j,seed);
            }
            catch
            {
                MessageBox.Show("嵌入失败！请检查图片与水印", "警告");
            }
            fMarked = "ROBUST_QIM.bmp";
            System.Drawing.Image img = System.Drawing.Image.FromFile("ROBUST_QIM.bmp");
            System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
            img.Dispose();
            pictureBox4.Image = bmp;
            pictureBox2.Image = bmp;
        }
        public void ROBUST_ANTITRANSFORM()
        {
            int blockLenWid = Convert.ToInt32(Math.Round(seed));
            xfin.Class1 xf = new xfin.Class1();
            MWCharArray cover = fCarrier;
            MWCharArray mark = fWatermark;
            try
            {
                xf.xfin(cover,mark,blockLenWid,len);
                fMarked = "ROBUST_ANTITRANSFORM.bmp";
                System.Drawing.Image img = System.Drawing.Image.FromFile("ROBUST_ANTITRANSFORM.bmp");
                System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
                img.Dispose();
                pictureBox4.Image = bmp;
                pictureBox2.Image = bmp;
            }
            catch
            {
                MessageBox.Show("嵌入失败！尝试使用能被图像长和宽整除的分块大小", "警告");
            }
            
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fMarked = openFileDialog.FileName;
                try
                {
                    pictureBox1.Load(fMarked);
                }
                catch
                {
                    pictureBox1.Load(textIMG);
                }

                //Console.Write(fName);
                pictureBox2.Load(fMarked);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if(comboBox3.SelectedIndex==0|| comboBox3.SelectedIndex == 1|| comboBox3.SelectedIndex == 2)
            //{
            //    Visible_Embed.Class1 visible_embed = new Visible_Embed.Class1();
            //    string mat_image = fCarrier;
            //    string mat_mark = fWatermark;
            //    int option = comboBox3.SelectedIndex;
            //    visible_embed.Visible_Embed(mat_image, mat_mark,option);
            //    pictureBox4.Load("visibleMarked.bmp");
            //}
            pictureBox5.Visible = false;
            if (comboBox3.SelectedIndex == 0)
            {
                LSB_WatermarkExtract.Class1 lSB_WatermarkExtract = new LSB_WatermarkExtract.Class1();
                string tobeExtracted = fMarked;
                MWCharArray tobeExtracted_mw = tobeExtracted;
                lSB_WatermarkExtract.LSB_WatermarkExtract(tobeExtracted);
                richTextBox1.LoadFile(@"DCT_LSBExtracted.txt", RichTextBoxStreamType.PlainText);
            }
            else if(comboBox3.SelectedIndex==1)
            {
                extract_robust.Class1 extract = new extract_robust.Class1();
                string tobeExtracted = fMarked;
                MWCharArray tobeExtracted_mw = tobeExtracted;
                try
                {
                    extract.extract_robust(fMarked, fSrcIMG, stren, len, i, j, seed);
                    richTextBox1.LoadFile(@"RobustExtracted.txt", RichTextBoxStreamType.PlainText);
                }
                catch
                {
                    MessageBox.Show("提取失败！请检查密钥和原图是否正确", "警告！");
                    return;
                }
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                extract_robust2.Class1 extract2 = new extract_robust2.Class1();
                MWCharArray src = fCarrier;
                MWCharArray watermarked = fMarked;
                try
                {
                    extract2.extract_robust2(watermarked, src, len, i, j, seed);
                    richTextBox1.LoadFile(@"QIMExtracted.txt", RichTextBoxStreamType.PlainText);
                }
                catch
                {
                    MessageBox.Show("提取失败！是否选取密钥和原图？", "警告");
                    return;
                }
            }
            else if(comboBox3.SelectedIndex==3)
            {
                int blockLenWid = Convert.ToInt32(Math.Round(seed));
                xfout.Class1 xfo = new xfout.Class1();
                MWCharArray marked = fMarked;
                try
                {
                    xfo.xfout(marked, blockLenWid, len);
                    pictureBox5.Visible = true;
                    System.Drawing.Image img = System.Drawing.Image.FromFile("ROBUST_ANTITRANSFORM_EXTRACT.bmp");
                    System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
                    img.Dispose();
                    pictureBox5.Image = bmp;
                   // pictureBox5.Load("ROBUST_ANTITRANSFORM_EXTRACT.bmp");
                }
                catch
                {
                    MessageBox.Show("提取失败，请检查密钥", "警告");
                }
            }
            else
            {
                MessageBox.Show("请选择提取方式", "警告");
                return;
            }
            
            MessageBox.Show("水印提取完成！请查看左下角窗口", "提示");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //打开的文件选择对话框上的标题
            saveFileDialog.Title = "请选择文件";
            //设置文件类型
            saveFileDialog.Filter = "图片文件(*.JPG)|*.JPG|BMP位图(*.bmp)|*.bmp|图片文件(*.png)|*.png|所有文件(*.*)|*.*";
            //设置默认文件类型显示顺序
            saveFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;
            //设置是否允许多选
            //saveFileDialog.Multiselect = false;
            //按下确定选择的按钮
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                //获取文件路径，不带文件名
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));
                //获取文件名，带后缀名，不带路径
                string fileNameWithSuffix = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                //去除文件后缀名
                string fileNameWithoutSuffix = fileNameWithSuffix.Substring(0, fileNameWithSuffix.LastIndexOf("."));
                string fileNameSuffix = fileNameWithSuffix.Substring(fileNameWithSuffix.LastIndexOf(".")+1);
                //在文件名前加上时间
                //string fileNameWithTime = DateTime.Now.ToString("yyyy-MM-dd ") + fileNameExt;
                //在文件名里加字符
                //string newFileName = localFilePath.Insert(1, "Tets");
                Bitmap bitmap = null;
                try
                {
                    bitmap = new Bitmap(fMarked);
                }
                catch
                {
                    bitmap = new Bitmap(pictureBox4.Width, pictureBox4.Height);
                }
                if (fileNameSuffix == "jpg" || fileNameSuffix == "JPG" || fileNameSuffix == "jpeg" || fileNameSuffix == "JPEG")
                    bitmap.Save(localFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (fileNameSuffix == "png" || fileNameSuffix == "PNG" || fileNameSuffix == "Png")
                    bitmap.Save(localFilePath, System.Drawing.Imaging.ImageFormat.Png);
                else if (fileNameSuffix == "bmp" || fileNameSuffix == "BMP" || fileNameSuffix == "Bmp")
                    bitmap.Save(localFilePath, System.Drawing.Imaging.ImageFormat.Png);
                else
                    bitmap.Save(fileNameWithoutSuffix + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fKey = openFileDialog.FileName;
                int counter = 0;
                string []line=new string[10];
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(fKey);
                while (counter<6)
                {
                    line[counter] = file.ReadLine();
                    counter++;
                }
                seed = Convert.ToDouble(line[0]);
                stren = Convert.ToInt32(line[1]);
                len = Convert.ToInt32(line[2]);
                i = Convert.ToInt32(line[3]);
                j = Convert.ToInt32(line[4]);
                file.Close();
                System.Console.WriteLine("There were {0} lines.", counter);
            }
            haskey = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fSrcIMG = openFileDialog.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PSNR.Class1 psnr = new PSNR.Class1();
            MWCharArray marked = fMarked;
            MWCharArray src = fCarrier;
            double result = 0;
            try
            {
                MWArray[] argsOut = new MWArray[1];//表示两个输出参数
                MWArray[] argsIn = new MWArray[] {marked,src };

                psnr.PSNR(1, ref argsOut, argsIn);
                MWNumericArray x = argsOut[0] as MWNumericArray;
                result = x.ToScalarDouble();
                MessageBox.Show("PSNR值为:"+result, "计算结果");
            }
            catch
            {
                MessageBox.Show("计算失败！请检查图片大小是否相等", "警告！");
                return;
            }
        }
    }


}
