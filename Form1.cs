using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer1;
        private System.Timers.Timer timer2;
        private System.Timers.Timer timer3;
        private System.Timers.Timer timer4;

        private int h1, m1, s1;
        private int h2, m2, s2;
        private int h3, m3, s3;
        private int h4, m4, s4;

        public Form1()
        {
            InitializeComponent();
        }


        //All propertis related to Pause button
       private void SetPause(System.Timers.Timer timer,Guna2Button Pausebutton)
        {

            if (Pausebutton.Text == "Puase")

            {
                Pausebutton.Text = "Resume";
                Pausebutton.FillColor = Color.FromArgb(255, 128, 0);
                timer.Stop();
            }

            else
            {

                Pausebutton.Text = "Puase";
                Pausebutton.FillColor = Color.FromArgb(213, 218, 223);

                timer.Start();

            }
        }

        //All propertis related to Add button
       private bool  IsOkToEndThePeriod()
        {

            DialogResult result = MessageBox.Show("Are you sure to end this period?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Code to execute if OK is clicked
                MessageBox.Show("You clicked OK.", "Confirmation");
                return true;    
            }
            else 
            {
                // Code to execute if Cancel is clicked
                MessageBox.Show("You clicked Cancel.", "Cancelled");
                return false;
            }

           

        }

        // Ending Timer that you
     private void   EndTime(Label Label,System.Timers.Timer Time,Guna2TextBox Textbox,Label TeamName,Guna2Button Pause,Guna2Button start,Guna2Button end,Guna2Button Add)
        {

            if (!IsOkToEndThePeriod())
                return;


            Time.Stop();
            Label.Text = "00:00:00";
            TeamName.Text = "";
            Pause.Text = "Pause";
            

            Textbox.Text = "";
            Textbox.Enabled = true;

            start.Enabled = false;
            Pause.Enabled = false;
            end.Enabled = false;

            Add.Enabled = true;

            h1 = 0;
            m1 = 0;
            s1 = 0;

            h2 = 0;
            m2 = 0;
            s2 = 0;

            h3 = 0;
            m3 = 0;
            s3 = 0;


            h4 = 0;
            m4 = 0;
            s4 = 0;
        }
        //Ensur that team filled
      bool IsEmptyTeam(Label TeamName)
        {
            if (TeamName.Text == "")
            {
                MessageBox.Show("Chose your team ?", "notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
               return true;
            }
            else
            {
                return false;
            }
         
        }

        //to add team
        private void AddTeam(Guna2Button Add, Guna2TextBox Txt, Label lbl, Guna2Button btnStart, Guna2Button btnEnd, Guna2Button btnPause)
        {
            if (Txt.Text == "")
                return;

            btnStart.Enabled = true;
            btnStart.FillColor = Color.FromArgb(255, 128, 0);
            lbl.Text = Txt.Text.ToString();
         


        }

        //To Enable Buttons
        private void EnablingButton(Guna2Button btn3, Guna2Button btn1, Guna2Button btn2)
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.FillColor=Color.FromArgb(213, 218, 223);

        }

        //disable buttons
        private void DisEnablingButton( Guna2Button btn1, Guna2Button btn2,Guna2TextBox Txt)
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            Txt.Text = "";
            Txt.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDateOfDay.Text = DateTime.Now.ToLongDateString();


            btnStart1.Enabled = false;
            btnStart2.Enabled = false;
            btnStart3.Enabled = false;
            btnStart4.Enabled = false;

            btnPuase1.Enabled = false;
            btnPuase2.Enabled = false;
            btnPuase3.Enabled = false;
            btnPuase4.Enabled = false;

            btnEnd1.Enabled = false;
            btnEnd2.Enabled = false;
            btnEnd3.Enabled = false;
            btnEnd4.Enabled = false;
            // lblDateOfDay.Text = dTPicker.Value.ToString("dd-MM-yyyy");
        }


        //change backcolor of pictur if start
        private void ChangePicturBoxifStart(System.Windows.Forms.PictureBox picture)
        {
            picture.BackColor = Color.FromArgb(255, 128, 0);
        }

        //Properties of Buttons Start
        private void btnStart1_Click_1(object sender, EventArgs e)
        {

          
            if (IsEmptyTeam(lblStadiumTeam1))
                return;


            EnablingButton(btnStart1, btnPuase1, btnEnd1);
            ChangePicturBoxifStart(pictureBox1);

            if (timer1 == null)
            {
                timer1 = new System.Timers.Timer();
                timer1.Interval = 1000;
                timer1.Elapsed += (s, ev) => OnTimeEvent1();
            }

            timer1.Start();
            DisEnablingButton(btnStart1, btnStadiumAdding1,txtStadium1);

        }
        private void btnStart2_Click(object sender, EventArgs e)
        {
            if (IsEmptyTeam(lblStadiumTeam2))
                return;


            EnablingButton(btnStart2, btnPuase2, btnEnd2);
            ChangePicturBoxifStart(pictureBox2);


            if (timer2 == null)
            {
                timer2 = new System.Timers.Timer();
                timer2.Interval = 1000;
                timer2.Elapsed += (s, ev) => OnTimeEvent2();
            }

            timer2.Start();
            DisEnablingButton(btnStart2, btnStadiumAdding2,txtStadium2);

        }
        private void btnStart3_Click(object sender, EventArgs e)
        {
            if (IsEmptyTeam(lblStadiumTeam3))
                return;


            EnablingButton(btnStart3, btnPuase3, btnEnd3);
            ChangePicturBoxifStart(pictureBox4);

            if (timer3 == null)
            {
                timer3 = new System.Timers.Timer();
                timer3.Interval = 1000;
                timer3.Elapsed += (s, ev) => OnTimeEvent3();
            }

            timer3.Start();
            DisEnablingButton(btnStart3, btnStadiumAdding3, txtStadium3);

        }
        private void btnStart4_Click(object sender, EventArgs e)
        {
            if (IsEmptyTeam(lblStadiumTeam4))
                return;

            EnablingButton(btnStart4, btnPuase4, btnEnd4);

            ChangePicturBoxifStart(pictureBox3);

            if (timer4 == null)
            {
                timer4 = new System.Timers.Timer();
                timer4.Interval = 1000;
                timer4.Elapsed += (s, ev) => OnTimeEvent4();
            }

            timer4.Start();


            DisEnablingButton(btnStart4, btnStadiumAdding4, txtStadium4);

        }



        //Properties of Buttons End
        private void btnEnd1_Click(object sender, EventArgs e)
        {
          
            EndTime(lblStadium1Timer,timer1, txtStadium1,lblStadiumTeam1,btnPuase1 ,btnStart1, btnEnd1,btnStadiumAdding1);
          
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            EndTime(lblStadium2Timer, timer2, txtStadium2, lblStadiumTeam2, btnPuase2, btnStart2, btnEnd2, btnStadiumAdding2);
        }
        private void btnEnd3_Click(object sender, EventArgs e)
        {
            EndTime(lblStadium3Timer, timer3,txtStadium3,lblStadiumTeam3, btnPuase3, btnStart3, btnEnd3, btnStadiumAdding3);

        }
        private void btnEnd4_Click(object sender, EventArgs e)
        {

            EndTime(lblStadium4Timer, timer4, txtStadium4, lblStadiumTeam4, btnPuase4, btnStart4, btnEnd4, btnStadiumAdding4);

        }


        //Properties of Buttons Pause
        private void btnPuase1_Click(object sender, EventArgs e)
        {


            SetPause(timer1, btnPuase1);


        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SetPause(timer2, btnPuase2);

        }
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SetPause(timer3, btnPuase3);


        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            SetPause(timer4, btnPuase4);
        }



      
       
     //setting of  all timers
        private void OnTimeEvent1()
        {
            s1++;
            if (s1 == 60)
            {
                s1 = 0;
                m1++;
            }
            if (m1 == 60)
            {
                m1 = 0;
                h1++;
            }

            this.Invoke(new Action(() =>
            {
                lblStadium1Timer.Text = $"{h1:D2}:{m1:D2}:{s1:D2}";
            }));
        }
        private void OnTimeEvent2()
        {
            s2++;
            if (s2 == 60)
            {
                s2 = 0;
                m2++;
            }
            if (m2 == 60)
            {
                m2 = 0;
                h2++;
            }

            this.Invoke(new Action(() =>
            {
                lblStadium2Timer.Text = $"{h2:D2}:{m2:D2}:{s2:D2}";
            }));
        }
        private void OnTimeEvent3()
        {
            s3++;
            if (s3 == 60)
            {
                s3 = 0;
                m3++;
            }
            if (m3 == 60)
            {
                m3 = 0;
                h3++;
            }

            this.Invoke(new Action(() =>
            {
                lblStadium3Timer.Text = $"{h3:D2}:{m3:D2}:{s3:D2}";
            }));
        }
        private void OnTimeEvent4()
        {
            s4++;
            if (s4 == 60)
            {
                s4 = 0;
                m4++;
            }
            if (m4 == 60)
            {
                m4 = 0;
                h4++;
            }

            this.Invoke(new Action(() =>
            {
                lblStadium4Timer.Text = $"{h4:D2}:{m4:D2}:{s4:D2}";
            }));
        }



        //setting of all adding buttons
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddTeam(btnStadiumAdding1, txtStadium1, lblStadiumTeam1,btnStart1,btnEnd1, btnPuase1);
             
        }
        private void btnStadiumAdding2_Click(object sender, EventArgs e)
        {
            AddTeam(btnStadiumAdding2, txtStadium2, lblStadiumTeam2, btnStart2, btnEnd2, btnPuase2);



        }
        private void btnStadiumAdding3_Click(object sender, EventArgs e)
        {
            AddTeam(btnStadiumAdding3, txtStadium3, lblStadiumTeam3, btnStart3, btnEnd3, btnPuase3);
        }
        private void btnStadiumAdding4_Click(object sender, EventArgs e)
        {
            AddTeam(btnStadiumAdding4, txtStadium4, lblStadiumTeam4, btnStart4 , btnEnd4 , btnPuase4);
        }
    }
}
