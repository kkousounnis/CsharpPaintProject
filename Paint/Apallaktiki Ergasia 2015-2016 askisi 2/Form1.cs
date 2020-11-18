using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apallaktiki_Ergasia_2015_2016_askisi_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //einai klasis pou xrisimopoiountai gia na sxediasoun mia perioxi me parallilogramma kuklous klp
        private Pen mypen;
        private Pen shapeeraser;
        //einai klasis pou xrisimopoiountai gia na gemisoun mia perioxi me parallilogramma kuklous klp
        private Brush myBrush;
        private Brush Rubber;
        //einai antikeimeno mygraphics pou antiproswpeuei thn perioxh poy tha sxediasoume
        private Graphics myGraphics;
        private bool paint = false;
        private bool createline = false;
        private bool createcircle = false;
        private bool rectangle = false;
        private bool rubber1 = false;
        private bool house = false;
        private bool Ship = false;
        private bool star = false;
        public int a,b,counteraser,d,f,g,h,k,l;
        class coordinates
        {
            public int startpointx1;
            public int startpointy1;
            public int secondpointx2;
            public int secondpointy2;
        }
        class Painting
        {
            public int paxospenas;          
        }
        //dimiourgia antikeimenou  tupou painting me onoma p
        Painting p = new Painting();
        //dimiourgia antikeimenou  tupou coordinates me onoma c
        coordinates c = new coordinates();
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            shapeeraser = new Pen(White.BackColor);
            if (paint == true  )
            {
                //mou dinei thn dunatothta na sxediasw einai mia methodos 
                myGraphics = pictureBox1.CreateGraphics();
                //edw zwgrafizw me to pinelo kathe fora poy pataw arstero click kai kounaw to pontiki
                myGraphics.FillEllipse(myBrush, e.X, e.Y, p.paxospenas, p.paxospenas);
            }
            //thn metabliti k tin bazw gia na mhn mporw na zwgrafisw an exw balei na sxediasei ena apo ta  tria sxedia me tous timer
            if (createline == true && a==1)
            {
                if (c.secondpointx2 != 0 && counteraser==1)
                myGraphics.DrawLine(shapeeraser, c.startpointx1, c.startpointy1, c.secondpointx2, c.secondpointy2);
                c.secondpointx2 = e.X;
                c.secondpointy2 = e.Y;
                myGraphics = pictureBox1.CreateGraphics();
                if(c.startpointx1!=0 && k==0)
                myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.secondpointx2, c.secondpointy2);      
            }
            if (createcircle == true && b == 1)
            {         
                myGraphics=pictureBox1.CreateGraphics();
                if(counteraser==1)
                    myGraphics.DrawEllipse(shapeeraser, c.startpointx1, c.startpointy1, c.secondpointx2-c.startpointx1,c.secondpointy2-c.startpointy1);
                c.secondpointx2 = e.X;
                c.secondpointy2 = e.Y;
                if (c.startpointx1 != 0 && k==0)
                    myGraphics.DrawEllipse(mypen, c.startpointx1, c.startpointy1, c.secondpointx2 - c.startpointx1, c.secondpointy2 - c.startpointy1);                
            }
            if (rectangle == true)
            {
                myGraphics = pictureBox1.CreateGraphics();
                if (counteraser == 1)
                    myGraphics.DrawRectangle(shapeeraser, c.startpointx1, c.startpointy1, c.secondpointx2 - c.startpointx1, c.secondpointy2 - c.startpointy1);
                c.secondpointx2 = e.X;
                c.secondpointy2 = e.Y;
                if(c.startpointx1!=0 && k==0)
                myGraphics.DrawRectangle(mypen, c.startpointx1, c.startpointy1, c.secondpointx2 - c.startpointx1, c.secondpointy2 - c.startpointy1);
            }
            if (rubber1 == true)
            {
                if (f != 1)
                {
                    Rubber = new SolidBrush(White.BackColor);
                    myGraphics = pictureBox1.CreateGraphics();
                    myGraphics.FillEllipse(Rubber, e.X, e.Y, p.paxospenas, p.paxospenas);
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (myBrush == null)
            {
                myBrush = new SolidBrush(black.BackColor);
                mypen = new Pen(black.BackColor);
            }
            if(a==0 && b==0 && d==0 && f==0 && house==false && Ship==false && star==false)paint = true;
            if (a==1 && k==0)
            {              
                createline = true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                counteraser = 1;
            }
            if (b == 1 && k==0)
            {                
                createcircle = true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                c.secondpointx2 = e.X;
                c.secondpointy2 = e.Y;
                counteraser = 1;
            }
            if(d==1 && k==0)
            {
                rectangle=true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                c.secondpointx2 = e.X;
                c.secondpointy2 = e.Y;
                counteraser = 1;
            }
            if (f == 1) 
            { 
                rubber1 = true;
                f = 2;
            }
            if (house == true && k==0)
            {
                timer1.Enabled = true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                g = 1;
            }
            if (Ship == true && k==0)
            {
                timer2.Enabled = true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                h = 1;
            }
            if (star == true && k == 0)
            {
                timer3.Enabled = true;
                c.startpointx1 = e.X;
                c.startpointy1 = e.Y;
                l = 1;
            }
            
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {        
            paint = false;
            if (createline == true && k==0)
            {
                createline = false;
                myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.secondpointx2, c.secondpointy2);
                c.startpointx1 = 0;
                c.startpointy1 = 0;
                c.secondpointx2 = 0;
                c.secondpointy2 = 0;
            }
            if (createcircle == true && k==0)
            {
                createcircle = false;
                c.startpointx1 = 0;
                c.startpointy1 = 0;
                c.secondpointx2 = 0;
                c.secondpointy2 = 0;
            }
            if (rectangle == true && k==0)
            {
                rectangle = false;
                c.startpointx1 = 0;
                c.startpointy1 = 0;
                c.secondpointx2 = 0;
                c.secondpointy2 = 0;

            }
            if (rubber1 == true) 
            { 
                rubber1 = false;
                f = 1;
            }
             
        }
        private void black_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(black.BackColor);
            mypen = new Pen(black.BackColor);
        
        }

        private void White_Click(object sender, EventArgs e)
        {
            myBrush=new SolidBrush(White.BackColor);
            mypen = new Pen(White.BackColor);
         
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Brown.BackColor);
            mypen = new Pen(Brown.BackColor);
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Gray.BackColor);
            mypen = new Pen(Gray.BackColor);
        }

        private void Red_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Red.BackColor);
            mypen = new Pen(Red.BackColor);
        }

        private void pink_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(pink.BackColor);
            mypen = new Pen(pink.BackColor);
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Orange.BackColor);
            mypen = new Pen(Orange.BackColor);
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(yellow.BackColor);
            mypen = new Pen(yellow.BackColor);
        }

        private void Green_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Green.BackColor);
            mypen = new Pen(Green.BackColor);
        }

        private void lightgreen_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(lightgreen.BackColor);
            mypen = new Pen(lightgreen.BackColor);
        }

        private void blue_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(blue.BackColor);
            mypen = new Pen(blue.BackColor);
        }

        private void lightblue_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(lightblue.BackColor);
            mypen = new Pen(lightblue.BackColor);
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            myBrush = new SolidBrush(Purple.BackColor);
            mypen = new Pen(Purple.BackColor);
        }

        private void editcolors_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                myBrush = new SolidBrush(colorDialog1.Color);
                mypen = new Pen(colorDialog1.Color);
            }
        }

        private void thin_CheckedChanged(object sender, EventArgs e)
        {
            
            p.paxospenas = 5;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(p.paxospenas==0)
            {
                p.paxospenas = 5;
            }
            
        }

        private void Regular_CheckedChanged(object sender, EventArgs e)
        {
            p.paxospenas = 10;
    
        }

        private void thick_CheckedChanged(object sender, EventArgs e)
        {
            p.paxospenas = 20;
        }
        private void ChangeBrushsize_Click(object sender, EventArgs e)
        {
            if (int.Parse(numericUpDown1.Text) <= 25)
                p.paxospenas = int.Parse(numericUpDown1.Text);
            else
                MessageBox.Show("The value you put must be lower or equal to 25");
        }

        private void line_Click(object sender, EventArgs e)
        {
            createline = true;
            createcircle = false;
            a = 1;
            b = 0;
            counteraser = 0;
            d = 0;
            f = 0;
            house = false;
            Ship = false;
            star = false;
        }

        private void brush_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            d = 0;
            f = 0;
            house = false;
            Ship = false;
            star = false;
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            createcircle = true;
            b = 1;
            a = 0;
            counteraser = 0;
            d = 0;
            f = 0;
            house = false;
            Ship = false;
            star = false;           
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            rectangle = true;
            d = 1;
            counteraser = 0;
            a = 0;
            b = 0;
            f = 0;
            house = false;
            Ship = false;
            star = false;
        }

        private void rubber_Click(object sender, EventArgs e)
        {
            rubber1 = true;
            f = 1;
            d = 0;
            counteraser = 0;
            a = 0;
            b = 0;
            house = false;
             Ship = false;
             star = false;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          if(c.startpointx1!=0) 
          {
            k = 1;
            myGraphics = pictureBox1.CreateGraphics(); 
            if(g==1)
            {
            myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 , c.startpointy1+100 );
            g = 2;
            }
            if (g == 3)
            {
                myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1 + 100, c.startpointx1 + 50, c.startpointy1 + 100);
                g = 4;
            }
            if (g == 5)
            {
                g = 6;
                myGraphics.DrawLine(mypen, c.startpointx1 + 50, c.startpointy1 + 100, c.startpointx1 + 50, c.startpointy1);
            }
            if (g == 7)
            {
                g = 8;
                myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 25, c.startpointy1 - 70);
            }
            if (g == 9)
            {
                g = 10;
                myGraphics.DrawLine(mypen, c.startpointx1 + 50, c.startpointy1, c.startpointx1 + 25, c.startpointy1 - 70);
            }
            if (g == 11)
            {
                g = 12;
                myGraphics.DrawLine(mypen, c.startpointx1 + 25, c.startpointy1 - 70, c.startpointx1 + 200, c.startpointy1 - 70);
            }
            if (g == 13)
            {
                g = 14;
                myGraphics.DrawLine(mypen, c.startpointx1 + 200, c.startpointy1 - 70, c.startpointx1 + 225, c.startpointy1);
            }
            if (g == 15)
            {
                g = 16;
                myGraphics.DrawLine(mypen, c.startpointx1 + 225, c.startpointy1, c.startpointx1 + 225, c.startpointy1 + 100);
            }
            if (g == 17)
            {
                g = 18;
                myGraphics.DrawLine(mypen, c.startpointx1 + 225, c.startpointy1 + 100, c.startpointx1, c.startpointy1 + 100);
            }
            if (g == 19)
            {
                g = 20;
                myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 225, c.startpointy1);
            }
            if (g == 21)
            {
                g = 22;
                myGraphics.DrawLine(mypen, c.startpointx1 + 18, c.startpointy1 - 50, c.startpointx1 - 5, c.startpointy1 - 60);
            }
            if (g == 23)
            {
                g = 24;
                myGraphics.DrawLine(mypen, c.startpointx1 + 20, c.startpointy1 - 60, c.startpointx1, c.startpointy1 - 70);
            }
            if (g == 25)
            {
                g = 26;
                myGraphics.DrawLine(mypen, c.startpointx1 - 5, c.startpointy1 - 60, c.startpointx1, c.startpointy1 - 70);
            }
            if (g == 27)
            {
                g = 28;
                myGraphics.DrawLine(mypen, c.startpointx1 - 4, c.startpointy1 - 64, c.startpointx1 - 10, c.startpointy1 - 68);
            }
            if (g == 29)
            {
                g = 30;
                myGraphics.DrawLine(mypen, c.startpointx1 - 12, c.startpointy1 - 68, c.startpointx1 - 15, c.startpointy1 - 72);
            }
            if (g == 31)
            {
                g = 32;
                myGraphics.DrawLine(mypen, c.startpointx1 + 20, c.startpointy1 + 100, c.startpointx1 + 20, c.startpointy1 + 70);
            }
            if (g == 33)
            {
                g = 34;
                myGraphics.DrawLine(mypen, c.startpointx1 + 40, c.startpointy1 + 100, c.startpointx1 + 40, c.startpointy1 + 70);
            }
            if (g == 35)
            {
                g = 36;
                myGraphics.DrawLine(mypen, c.startpointx1 + 20, c.startpointy1 + 70, c.startpointx1 + 40, c.startpointy1 + 70);
            }
            if (g == 37)
            {
                myGraphics.DrawLine(mypen, c.startpointx1+40, c.startpointy1+70, c.startpointx1+40, c.startpointy1+90);
                g = 38;
            }
            if (g == 39)
            {
                g = 40;
                myGraphics.DrawLine(mypen, c.startpointx1 + 20, c.startpointy1 + 70, c.startpointx1 + 40, c.startpointy1 + 70);
            }
            g = g + 1;
            if (g == 41)
              {
                    g = 1;
                    c.startpointx1 = 0;
                    c.startpointy1 = 0;
                    timer1.Enabled = false;
                    k = 0;                       
              }
          }
        }

        private void house1_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            d = 0;
            f = 0;
            g = 1;
            house = true;
            Ship = false;
            star = false;
        }

        private void ship_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            d = 0;
            f = 0;
            g = 0;
            h = 1;
            Ship = true;
            house = false;
            star = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            k = 1;
            myGraphics = pictureBox1.CreateGraphics();
            if (c.startpointx1 != 0 )
            {
                if (h == 1)
                {
                    h = 2;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 50, c.startpointy1 + 50);
                }
                if (h == 3)
                {
                    h = 4;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 50, c.startpointy1 + 50, c.startpointx1 + 200, c.startpointy1 + 50);
                }
                if (h == 5)
                {
                    h = 6;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 200, c.startpointy1 + 50, c.startpointx1 + 300, c.startpointy1 );
                }
                if (h == 7)
                {
                    h = 8;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 300, c.startpointy1);
                }
                if (h == 9)
                {
                    h = 10;
                    myGraphics.DrawLine(mypen, c.startpointx1+150, c.startpointy1, c.startpointx1 + 150, c.startpointy1-70);
                }
                if (h == 11)
                {
                    h = 12;
                    myGraphics.DrawLine(mypen, c.startpointx1+220, c.startpointy1, c.startpointx1+220 , c.startpointy1-40);
                }
                if (h == 13)
                {
                    h = 14;
                    myGraphics.DrawLine(mypen, c.startpointx1+125, c.startpointy1-60, c.startpointx1+175, c.startpointy1-60);
                }
                if (h == 15)
                {
                    h = 16;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 135, c.startpointy1 - 40, c.startpointx1 + 165, c.startpointy1 - 40);
                }
                if (h == 17)
                {
                    h = 18;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 210, c.startpointy1 - 35, c.startpointx1 + 230, c.startpointy1 - 35);  
                }
                if (h == 19)
                {
                    h = 20;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 10, c.startpointy1 , c.startpointx1+10 , c.startpointy1-50 );
                }
                if (h == 21)
                {
                    h = 22;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 90, c.startpointy1 , c.startpointx1 + 90, c.startpointy1 - 50);
                }
                if (h == 23)
                {
                    h = 24;
                    myGraphics.DrawLine(mypen, c.startpointx1 + 10, c.startpointy1 - 50, c.startpointx1 + 90, c.startpointy1 - 50);
                }
                h = h + 1;
                if (h == 25)
                {
                    h = 1;
                    c.startpointx1 = 0;
                    c.startpointy1 = 0;
                    timer2.Enabled = false;
                    k = 0;
                }
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            d = 0;
            f = 0;
            g = 0;
            h = 0;
            l = 1;
            Ship = false; ;
            house = false;
            star = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            k = 1;
            myGraphics = pictureBox1.CreateGraphics();
            if (c.startpointx1 != 0)
            {
                if (l == 1)
                {
                    l = 2;
                    myGraphics.DrawLine(mypen, c.startpointx1 , c.startpointy1, c.startpointx1 , c.startpointy1 -60);
                }
                if (l == 3)
                {
                    l=5;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1, c.startpointy1 + 30);
                }
                if (l ==6 )
                {
                    l = 7;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1-60, c.startpointy1 + 60);
                }
                if (l == 8)
                {
                    l = 9;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 30, c.startpointy1 - 30);
                }
                if (l == 10)
                {
                    l = 11;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1+30, c.startpointx1 - 60, c.startpointy1 + 60);
                }
                if (l == 12)
                {
                    l = 13;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 + 60, c.startpointy1 + 60);
                }
                if (l == 14)
                {
                    l = 15;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 - 30, c.startpointy1 - 30);
                }
                if (l == 16)
                {
                    l = 17;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1+30, c.startpointx1 + 60, c.startpointy1 + 60);
                }
                if (l == 18)
                {
                    l = 19;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1-60, c.startpointx1 + 30, c.startpointy1 - 30);
                }
                if (l == 20)
                {
                    l = 21;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1 - 60, c.startpointx1 - 30, c.startpointy1 - 30);
                }
                if (l == 22)
                {
                    l = 23;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1 , c.startpointx1 -30, c.startpointy1 +10 );
                }
                if (l == 24)
                {
                    l = 25;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1 , c.startpointx1 +60, c.startpointy1 - 15);
                }
                if (l == 26)
                {
                    l = 27;
                    myGraphics.DrawLine(mypen, c.startpointx1-30, c.startpointy1 +10, c.startpointx1 - 60, c.startpointy1 + 60);
                }
                if (l == 28)
                {
                    l = 29;
                    myGraphics.DrawLine(mypen, c.startpointx1+60, c.startpointy1 - 15, c.startpointx1+30 , c.startpointy1 - 30);
                }
                if (l == 30)
                {
                    l = 31;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1, c.startpointx1 - 60, c.startpointy1 - 15);
                }
                if (l == 32)
                {
                    l = 33;
                    myGraphics.DrawLine(mypen, c.startpointx1-60, c.startpointy1 -15, c.startpointx1 -30, c.startpointy1 - 30);
                }
                if (l == 34)
                {
                    l = 35;
                    myGraphics.DrawLine(mypen, c.startpointx1-60, c.startpointy1 - 15, c.startpointx1 - 30, c.startpointy1 +10);
                }
                if (l == 36)
                {
                    l = 37;
                    myGraphics.DrawLine(mypen, c.startpointx1, c.startpointy1 , c.startpointx1 + 30, c.startpointy1 + 10);
                }
                if (l == 38)
                {
                    l = 39;
                    myGraphics.DrawLine(mypen, c.startpointx1+30, c.startpointy1 +10, c.startpointx1+60 , c.startpointy1-15 );
                }
                if (l == 40)
                {
                    l = 41;
                    myGraphics.DrawLine(mypen, c.startpointx1+30, c.startpointy1 +10, c.startpointx1 + 60, c.startpointy1 + 60);
                }
                l = l + 1;
                if (l == 42)
                {
                    l = 1;
                    c.startpointx1 = 0;
                    c.startpointy1 = 0;
                    timer3.Enabled = false;
                    k = 0;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
