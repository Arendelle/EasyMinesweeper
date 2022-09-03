/*========================================
 *  作者：朱弘懿
 *  地址：华北电力大学(保定) 电子系 电信1901班
 *  QQ：648222852 
   
 *  最后一次编辑：2019/12/10
   
 *  All rights reserved.
========================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 扫雷
{
    public partial class Form1 : Form
    {
        Button[] tile;
        Label[] grid;
        int[,] layout=new int[100,100];
        bool[,] isexpanded=new bool[100,100];
        bool[,] flaged = new bool[100, 100];
        int height, width;
        bool Keyblocker = false;
        bool Is_initalize = true;
        int[] mine_array;//存储了所有雷的一维坐标

        public Form1()
        {
            InitializeComponent();
        }
        private void tile_MouseUp(object sender, MouseEventArgs e) {
            if (Keyblocker) return;
            int index = int.Parse(((Button)sender).Name);//index为被按下的按钮的一维坐标
            if (Is_initalize) {                         //防止第一次就触雷
                Layout_generate(index);
                Is_initalize = false;
            }
            if (e.Button == MouseButtons.Left) {//雷盘左键按钮按下事件
                timer1.Enabled = true;
                if (layout[(index - 1) / width + 1, (index - 1) % width + 1] == 9)
                {//触雷，结算
                    tile[index].Visible = false;
                    Game_End();
                    return;
                }
                else if (layout[(index - 1) / width + 1, (index - 1) % width + 1] == 0)//按下了空格并扩展
                {
                    
                    Expand((index - 1) / width + 1, (index - 1) % width + 1);
                    //扩展
                }
                else if (flaged[(index - 1) / width + 1, (index - 1) % width + 1]) {//按下下面是数字的旗帜格子
                    flaged[(index - 1) / width + 1, (index - 1) % width + 1] = false;
                }
                tile[index].Visible = false;

            }
            else if (e.Button == MouseButtons.Right) {//右键按下插旗
                if (!flaged[(index - 1) / width + 1, (index - 1) % width + 1]) {
                    String str = System.Environment.CurrentDirectory;
                    flaged[(index - 1) / width + 1, (index - 1) % width + 1] = true;
                    tile[index].Image = Image.FromFile(str + "\\flag.jpg");
                    flag_display.Text = (int.Parse(flag_display.Text) - 1).ToString();
                } else {
                    flaged[(index - 1) / width + 1, (index - 1) % width + 1] = false;
                    tile[index].Image = null;
                    flag_display.Text = (int.Parse(flag_display.Text) + 1).ToString();
                }
            }
            TestVictory();
        }

        private void grid_MouseUp(object sender, MouseEventArgs e){//数字格按钮按下事件
            if (Keyblocker) return;
            int index = int.Parse(((Label)sender).Name);//index为被按下的格子的一维坐标
            int x = (index - 1) / width + 1, y = (index - 1) % width + 1;
            if (e.Button == MouseButtons.Right){//右键按下探雷

                if (Countflag(x, y) == layout[x, y] && Countflag(x, y) != 0)
                {//此处判断雷和旗是否重合，如果不，游戏结束
                    bool flag = true;
                    if (Inbound(x - 1, y - 1) && flaged[x - 1, y - 1] && layout[x - 1, y - 1] != 9) flag = false;
                    if (Inbound(x + 1, y + 1) && flaged[x + 1, y + 1] && layout[x + 1, y + 1] != 9) flag = false;
                    if (Inbound(x - 1, y + 1) && flaged[x - 1, y + 1] && layout[x - 1, y + 1] != 9) flag = false;
                    if (Inbound(x + 1, y - 1) && flaged[x + 1, y - 1] && layout[x + 1, y - 1] != 9) flag = false;
                    if (Inbound(x, y + 1) && flaged[x, y + 1] && layout[x, y + 1] != 9) flag = false;
                    if (Inbound(x, y - 1) && flaged[x, y - 1] && layout[x, y - 1] != 9) flag = false;
                    if (Inbound(x + 1, y) && flaged[x + 1, y] && layout[x + 1, y] != 9) flag = false;
                    if (Inbound(x - 1, y) && flaged[x - 1, y] && layout[x - 1, y] != 9) flag = false;

                    if (!flag) {
                        Game_End();
                        return;
                    }
                    else
                    {
                        if (Inbound(x - 1, y - 1) && layout[x - 1, y - 1] != 9) { tile[index - width - 1].Visible = false; if (layout[x - 1, y - 1] == 0) Expand(x - 1, y - 1); }
                        if (Inbound(x + 1, y + 1) && layout[x + 1, y + 1] != 9) { tile[index + width + 1].Visible = false; if (layout[x + 1, y + 1] == 0) Expand(x + 1, y + 1); }
                        if (Inbound(x - 1, y + 1) && layout[x - 1, y + 1] != 9) { tile[index - width + 1].Visible = false; if (layout[x - 1, y + 1] == 0) Expand(x - 1, y + 1); }
                        if (Inbound(x + 1, y - 1) && layout[x + 1, y - 1] != 9) { tile[index + width - 1].Visible = false; if (layout[x + 1, y - 1] == 0) Expand(x + 1, y - 1); }
                        if (Inbound(x, y - 1) && layout[x, y - 1] != 9) { tile[index - 1].Visible = false; if (layout[x, y - 1] == 0)Expand(x, y - 1); }
                        if (Inbound(x, y + 1) && layout[x, y + 1] != 9) { tile[index + 1].Visible = false; if (layout[x, y + 1] == 0)Expand(x, y + 1); }
                        if (Inbound(x - 1, y) && layout[x - 1, y] != 9) { tile[index - width].Visible = false; if (layout[x - 1, y] == 0)Expand(x - 1, y); }
                        if (Inbound(x + 1, y) && layout[x + 1, y] != 9) { tile[index + width].Visible = false; if (layout[x + 1, y] == 0)Expand(x + 1, y); }
                    }
                }
            }
            TestVictory();
        }

        public bool Inbound(int x, int y) {
            if (x > 0 && x <= height && y > 0 && y <= width) return true;
            else return false;
        }

        public void TestVictory(){                                      //测试是否达成胜利条件
            int temp = 0;
            for (int i = 1; i <= width * height; i++) {
                if (tile[i].Visible == false) temp++;
            }
            if (temp + int.Parse(text_mine.Text) == height * width)
            {
                timer1.Enabled = false;
                MessageBox.Show("你赢了！用时 " + timebar.Text + " 秒");
                button_restart.Visible = true;
                pic1.Visible = false;
                flag_display.Visible = false;
                timer1.Enabled = false;
                Keyblocker = true;
            }
        }

        private void Game_End() {
            String str = System.Environment.CurrentDirectory;
            for (int i = 1; i <= width * height; i++ ){
                if (flaged[(i - 1) / width + 1, (i - 1) % width + 1] && layout[(i - 1) / width + 1, (i - 1) % width + 1] != 9) tile[i].Image = Image.FromFile(str + "\\fakeflag.jpg");
                else if (!flaged[(i - 1) / width + 1, (i - 1) % width + 1] && layout[(i - 1) / width + 1, (i - 1) % width + 1] == 9) tile[i].Visible = false;
            }
            timer1.Enabled = false;
            MessageBox.Show("你触雷了，游戏结束");
            button_restart.Visible = true;
            pic1.Visible = false;
            pic2.Visible = false;
            timebar.Visible = false;
            flag_display.Visible = false;
            Keyblocker = true;
        }

        private int Countflag(int x, int y) {
            int total = 0;
            if (Inbound(x, y) && flaged[x, y]) total++;
            if (Inbound(x - 1, y - 1) && flaged[x - 1, y - 1]) total++;
            if (Inbound(x + 1, y + 1) && flaged[x + 1, y + 1]) total++;
            if (Inbound(x + 1, y - 1) && flaged[x + 1, y - 1]) total++;
            if (Inbound(x - 1, y + 1) && flaged[x - 1, y + 1]) total++;
            if (Inbound(x + 1, y) && flaged[x + 1, y]) total++;
            if (Inbound(x - 1, y) && flaged[x - 1, y]) total++;
            if (Inbound(x, y + 1) && flaged[x, y + 1]) total++;
            if (Inbound(x, y - 1) && flaged[x, y - 1]) total++;
            return total;
        }

        private int Countit(int x,int y) {                  //生成数字
            int total=0;
            if (Inbound(x, y) && layout[x, y] == 9) total++;
            if (Inbound(x-1, y-1) && layout[x-1, y-1] == 9) total++;
            if (Inbound(x+1, y+1) && layout[x+1, y+1] == 9) total++;
            if (Inbound(x+1, y-1) && layout[x+1, y-1] == 9) total++;
            if (Inbound(x-1, y+1) && layout[x-1, y+1] == 9) total++;
            if (Inbound(x+1, y) && layout[x+1, y] == 9) total++;
            if (Inbound(x-1, y) && layout[x-1, y] == 9) total++;
            if (Inbound(x, y+1) && layout[x, y+1] == 9) total++;
            if (Inbound(x, y-1) && layout[x, y-1] == 9) total++;
            return total;
        }

        private void Expand(int x, int y) {                     //空格子的扩展打开
            isexpanded[x, y] = true;

            if (Inbound(x - 1, y) && layout[x - 1, y] == 0 && !isexpanded[x - 1, y] && !flaged[x - 1, y]) { tile[(x - 2) * width + y].Visible = false; Expand(x - 1, y);  }
            if (Inbound(x + 1, y) && layout[x + 1, y] == 0 && !isexpanded[x + 1, y] && !flaged[x + 1, y]) { tile[(x) * width + y].Visible = false; Expand(x + 1, y);  }
            if (Inbound(x, y - 1) && layout[x, y - 1] == 0 && !isexpanded[x, y - 1] && !flaged[x, y - 1]) { tile[(x - 1) * width + y - 1].Visible = false; Expand(x, y - 1);  }
            if (Inbound(x, y + 1) && layout[x, y + 1] == 0 && !isexpanded[x, y + 1] && !flaged[x, y + 1]) { tile[(x - 1) * width + y + 1].Visible = false; Expand(x, y + 1);  }
            if (Inbound(x - 1, y - 1) && layout[x - 1, y - 1] == 0 && !isexpanded[x - 1, y - 1] && !flaged[x - 1, y - 1]) { tile[(x - 2) * width + y - 1].Visible = false; Expand(x - 1, y - 1);  }
            if (Inbound(x + 1, y + 1) && layout[x + 1, y + 1] == 0 && !isexpanded[x + 1, y + 1] && !flaged[x + 1, y + 1]) { tile[(x) * width + y + 1].Visible = false; Expand(x + 1, y + 1);  }
            if (Inbound(x + 1, y - 1) && layout[x + 1, y - 1] == 0 && !isexpanded[x + 1, y - 1] && !flaged[x + 1, y - 1]) { tile[(x) * width + y - 1].Visible = false; Expand(x + 1, y - 1);  }
            if (Inbound(x - 1, y + 1) && layout[x - 1, y + 1] == 0 && !isexpanded[x - 1, y + 1] && !flaged[x - 1, y + 1]) { tile[(x - 2) * width + y + 1].Visible = false; Expand(x - 1, y + 1);  }


            if (Inbound(x - 1, y - 1) && 1 <= layout[x - 1, y - 1] && layout[x - 1, y - 1] <= 8 && !isexpanded[x - 1, y - 1] && !flaged[x - 1, y - 1]){ tile[(x - 2) * width + y - 1].Visible = false;  }
            if (Inbound(x + 1, y + 1) && 1 <= layout[x + 1, y + 1] && layout[x + 1, y + 1] <= 8 && !isexpanded[x + 1, y + 1] && !flaged[x + 1, y + 1]){ tile[(x) * width + y + 1].Visible = false;  }
            if (Inbound(x + 1, y - 1) && 1 <= layout[x + 1, y - 1] && layout[x + 1, y - 1] <= 8 && !isexpanded[x + 1, y - 1] && !flaged[x + 1, y - 1]){ tile[(x) * width + y - 1].Visible = false;  }
            if (Inbound(x - 1, y + 1) && 1 <= layout[x - 1, y + 1] && layout[x - 1, y + 1] <= 8 && !isexpanded[x - 1, y + 1] && !flaged[x - 1, y + 1]){ tile[(x - 2) * width + y + 1].Visible = false;  }
            if (Inbound(x + 1, y) && 1 <= layout[x + 1, y] && layout[x + 1, y] <= 8 && !isexpanded[x + 1, y] && !flaged[x + 1, y]){ tile[x * width + y].Visible = false;  }
            if (Inbound(x - 1, y) && 1 <= layout[x - 1, y] && layout[x - 1, y] <= 8 && !isexpanded[x - 1, y] && !flaged[x - 1, y]){ tile[(x - 2) * width + y].Visible = false;  }
            if (Inbound(x, y + 1) && 1 <= layout[x, y + 1] && layout[x, y + 1] <= 8 && !isexpanded[x, y + 1] && !flaged[x, y + 1]){ tile[(x - 1) * width + y + 1].Visible = false;  }
            if (Inbound(x, y - 1) && 1 <= layout[x, y - 1] && layout[x, y - 1] <= 8 && !isexpanded[x, y - 1] && !flaged[x, y - 1]) { tile[(x - 1) * width + y - 1].Visible = false;  }

            return;
        }

        private void Layout_generate(int index)
        {
            String str = System.Environment.CurrentDirectory;
            mine_array = new int[int.Parse(text_mine.Text) + 1];
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(text_mine.Text); i++)
            {//生成雷
                //0=>空 1-8=>数字 9=>地雷!
                int temp = rand.Next(1, height * width + 1);
                if (layout[(temp - 1) / width + 1, (temp - 1) % width + 1] != 9 && temp != index)
                {
                    layout[(temp - 1) / width + 1, (temp - 1) % width + 1] = 9;
                    mine_array[i] = temp;
                    //grid[temp].BackColor = Color.Red;
                    grid[temp].Image = Image.FromFile(str + "\\mine.jpg");
                    Controls.Add(grid[i]);
                }
                else i--;
            }
            for (int i = 1; i <= width * height; i++)
            {
                if (layout[(i - 1) / width + 1, (i - 1) % width + 1] != 9)
                {
                    grid[i].Font = new Font(grid[i].Font.FontFamily, 14, FontStyle.Bold);
                    if (Countit((i - 1) / width + 1, (i - 1) % width + 1) == 0)
                        grid[i].Text = "";
                    else
                    {
                        grid[i].Text = (Countit((i - 1) / width + 1, (i - 1) % width + 1)).ToString();
                        switch (Countit((i - 1) / width + 1, (i - 1) % width + 1))
                        {
                            case 1:
                                grid[i].ForeColor = Color.Blue;
                                break;
                            case 2:
                                grid[i].ForeColor = Color.Green;
                                break;
                            case 3:
                                grid[i].ForeColor = Color.Red;
                                break;
                            case 4:
                                grid[i].ForeColor = Color.DarkBlue;
                                break;
                            case 5:
                                grid[i].ForeColor = Color.DarkRed;
                                break;
                            case 6:
                                grid[i].ForeColor = Color.MediumTurquoise;
                                break;
                            case 7:
                                grid[i].ForeColor = Color.Black;
                                break;
                            case 8:
                                grid[i].ForeColor = Color.Gray;
                                break;
                        }

                    }
                    layout[(i - 1) / width + 1, (i - 1) % width + 1] = Countit((i - 1) / width + 1, (i - 1) % width + 1);
                }
            }
        }
        
        private void button_generate_Click(object sender, EventArgs e)//生成雷盘，初始化地雷和数字
        {
            height = int.Parse(text_height.Text);//窗体等对象初始化
            width = int.Parse(text_width.Text);
            int mine_amount = int.Parse(text_mine.Text);
            if (height < 0 || height > 100 || width < 0 || width > 100 || mine_amount >= height * width) {
                MessageBox.Show("请键入有效的值");
                return;
            }
            
            text_height.Visible = false;
            text_width.Visible = false;
            button_generate.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            text_mine.Visible = false;
            timebar.Visible = true;
            this.Size = new Size(65 + width * 25 + 50, 150 + height * 25);
            timebar.Location = new Point(65,timebar.Top);
            flag_display.Location = new Point(this.Width - 105,timebar.Top);
            flag_display.Text = mine_amount.ToString();
            flag_display.Visible = true;
            button_restart.Location = new Point(this.Width / 2 - button_restart.Width / 2 ,button_restart.Top);
            pic1.Location = new Point(this.Width - 125,timebar.Top + 3);
            pic1.Visible = true;
            pic2.Visible = true;

            Random rand = new Random();

            Array.Clear(layout, 0, layout.Length);
            Array.Clear(isexpanded, 0, isexpanded.Length);
            Array.Clear(flaged, 0, flaged.Length);

            tile = new Button[height * width + 1];//创建按钮对象
            for (int i = 1; i < height * width + 1; i++)
            {
                tile[i] = new Button()
                {
                    //Text = i.ToString(),//设置按钮的文本信息
                    Size = new Size(25, 25),
                    Location = new Point(50 + ((i - 1) % width) * 25, 75 + ((i - 1) / width) * 25),//设置按钮位置
                    Name = i.ToString(),
                    TabStop = false

                };
                tile[i].MouseUp += new MouseEventHandler(tile_MouseUp);
                Controls.Add(tile[i]);
            }

            grid = new Label[height * width + 1];//创建标签对象
            for (int i = 1; i < height * width + 1; i++)
            {
                grid[i] = new Label()
                {
                    //Text = i.ToString(),//设置标签的文本信息
                    Size = new Size(25, 25),
                    Location = new Point(50 + ((i - 1) % width) * 25, 75 + ((i - 1) / width) * 25),//设置按钮位置
                    Name = i.ToString()

                };
                grid[i].MouseUp += new MouseEventHandler(grid_MouseUp);
                Controls.Add(grid[i]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timebar.Text = (int.Parse(timebar.Text)+1).ToString();
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            text_height.Visible = true;             //重新开始
            text_width.Visible = true;
            button_generate.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            text_mine.Visible = true;
            timebar.Visible = false;
            button_restart.Visible = false;
            pic2.Visible = false;
            timebar.Text = "0";
            Keyblocker = false;
            Is_initalize = true;
            //释放数组内存
            for (int i = 1; i < tile.Length; i++) tile[i] = null;
            for (int i = 1; i < grid.Length; i++) grid[i] = null;
            int[,] layout = new int[100,100];
            bool[,] isexpanded = new bool[100,100];
            bool[,] flaged = new bool[100, 100];

            int k = this.Controls.Count;
            for (int i = k-1; i > 0; i--) {
                Control t = this.Controls[i];
                if (t is Button) {
                    if (t.Width == 25)
                    {
                        this.Controls.Remove(t);
                    }
                }
            }
            int kk = this.Controls.Count;
            for (int i = kk-1; i > 0; i--)
            {
                Control t = this.Controls[i];
                if (t is Label)
                {
                    if (t.Width == 25)
                    {
                        this.Controls.Remove(t);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}