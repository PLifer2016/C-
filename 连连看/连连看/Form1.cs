using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//System.Guid;

namespace 连连看
{
    public partial class Form1 : Form
    {
        PictureBox[,] picmap=new PictureBox[6,6];//地图
        //Boolean isGameOver = false;
        int first = 1;  //第一张图片被选中的标志
        PictureBox firTemp;
        PictureBox secTemp;
        int flag = 0;   //图片被清空的标志

        public Form1()
        {
            InitializeComponent();
            picmap=new PictureBox[,]{
                {pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,pictureBox6},
                {pictureBox7,pictureBox8,pictureBox9,pictureBox10,pictureBox11,pictureBox12},
                {pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17,pictureBox18},
                {pictureBox19,pictureBox20,pictureBox21,pictureBox22,pictureBox23,pictureBox24},
                {pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30},
                {pictureBox31,pictureBox32,pictureBox33,pictureBox34,pictureBox35,pictureBox36}
            };
            initpicboxs();
        }

        private void initpicboxs()
        {
            int num;
            int[] n=new int[9];
            //isGameOver = false;
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    Random ran = new Random(Guid.NewGuid().GetHashCode());  //随机生成数字
                lab1:
                    num = ran.Next() % 9;

                    if (n[num] != 4)    //加载图片，一张图片出现4次
                    {
                        n[num]++;
                        picmap[i, j].Visible = true;
                        picmap[i, j].Name = num.ToString();
                        picmap[i, j].Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\C#\\连连看\\图片素材\\" + num + ".jpg");
                    }
                    else
                    {
                        goto lab1;  
                    }
                }       
            }
            //初始化数据
            //isGameOver = false;
            first = 1;
            firTemp = secTemp = null;
            flag = 0;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

            PictureBox temp = (PictureBox)sender;

            //选中第二个可以看见的图片
            if (first == 0 && temp.Visible == true)
            {
                secTemp = temp;
                if (firTemp.Name == secTemp.Name && (firTemp.Location.X != secTemp.Location.X 
                    || firTemp.Location.Y != secTemp.Location.Y))       //判断两个图片是否相同且不是同一张图片
                {
                    firTemp.Visible = secTemp.Visible = false;
                    first = 1;
                    flag += 2;
                    if (flag == 36)     //判断图片是否清除完毕
                    {
                        //isGameOver = true;
                        MessageBox.Show("祝贺你完成游戏！","遊戲結束",MessageBoxButtons.OK);
                        initpicboxs();
                    }
                }
                else
                {
                    first = 1;
                    firTemp = secTemp = null;
                }
            }
            else
            {
                first = 1;
                firTemp = secTemp = null;
            }

            //选中第一个可以看见的图片
            if (first == 1 && temp.Visible == true) 
            {
                firTemp=temp;
                first = 0;
            }
            else
            {
                first = 1;
                firTemp = null; 
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            initpicboxs();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
