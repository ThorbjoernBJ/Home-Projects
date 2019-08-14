using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster_Hunter_calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum SharpnessE
        {
            Red = 50,
            Orange = 75,
            Yellow = 100,
            Green = 105,
            Blue = 120,
            White = 132
        }



        public double BloatValue;
        public double PeakPerformanceC = 0;
        public double SharpnessC = 1.05;
        public double CriticalEyeC = 0;
        public double WeaknessExploitC = 0;
        public double NonElementalC = 0;
        public double CriticalBoostC = 1.25;
        public double MaximumMightC = 0;


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            PeakPerformance.Maximum = 3;
            CriticalBoost.Maximum = 3;
            AttackBoost.Maximum = 7;
            CriticalEye.Maximum = 7;
            WeaknessExploit.Maximum = 3;
            MaximumMight.Maximum = 6;
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            string AB = Convert.ToString(AffinityBox.Text);
            double BaseAffinity = double.Parse(AB);
            string WA = Convert.ToString(AttackValue.Text);
            double Weaponattack = double.Parse(WA);

            string Weapon = Convert.ToString(WeaponType.Text);

            string Sharp = Convert.ToString(SharpnessBox.Text);

            string PP = Convert.ToString(PeakPerformance.Text);
            int Peakp = Convert.ToInt16(PP);

            string WES = Convert.ToString(WeaknessExploit.Text);
            int WEI = Convert.ToInt16(WES);

            string CBS = Convert.ToString(CriticalBoost.Text);
            int CBI = Convert.ToInt16(CBS);

            string CEstring = Convert.ToString(CriticalEye.Text);
            int CEint = Convert.ToInt16(CEstring);

            string AttackUp = Convert.ToString(AttackBoost.Text);
            int AU = Convert.ToInt16(AttackUp);

            string MaximumMightS = Convert.ToString(MaximumMight.Text);
            int MMi = Convert.ToInt16(MaximumMightS);

            //bloatvalues
            if (Weapon=="GS")
            {
                BloatValue = 4.8;
            }
            else if (Weapon=="H")
            {
                BloatValue = 5.2;
            }
            else if (Weapon == "GL")
            {
                BloatValue = 2.3;
            }
            else if (Weapon=="LS")
            {
                BloatValue = 3.3;
            }
            else if (Weapon == "SA")
            {
                BloatValue = 3.5;
            }
            else if (Weapon =="Sword and Shield"||Weapon=="SS")
            {
                BloatValue = 1.4;
            }
            else if (Weapon == "CB")
            {
                BloatValue = 3.6;
            }
            else if (Weapon == "DB")
            {
                BloatValue = 1.4;
            }
            else if (Weapon == "IG")
            {
                BloatValue = 3.1;
            }
            else if (Weapon == "HH")
            {
                BloatValue = 4.2;
            }
            else if(Weapon == "L")
            {
                BloatValue = 2.3;
            }

            //Peakperformance
            if (Peakp == 1)
            {
                PeakPerformanceC = 5;
            }
            else if (Peakp == 2)
            {
                PeakPerformanceC = 10;
            }
            else if (Peakp ==3)
            {
                PeakPerformanceC = 20;
            }
            else
            {
                PeakPerformanceC = 0;
            }

            //Maxmum Might
            if (MMi == 1)
            {
                MaximumMightC = 10;
            }
            else if (MMi == 2)
            {
                MaximumMightC = 20;
            }
            else if (MMi == 3)
            {
                MaximumMightC = 30;
            }
            else
            {
                MaximumMightC = 0;
            }

            //Weakness Exploit
            if (WEI == 1)
            {
                WeaknessExploitC = 15;
            }
            else if (WEI == 2)
            {
                WeaknessExploitC = 30;
            }
            else if (WEI == 3)
            {
                WeaknessExploitC = 50;
            }
            else
            {
                WeaknessExploitC = 0;
            }

            //Weakness Exploit
            if (CBI == 1)
            {
                CriticalBoostC = 1.30;
            }
            else if (CBI == 2)
            {
                CriticalBoostC = 1.35;
            }
            else if (CBI == 3)
            {
                CriticalBoostC = 1.40;
            }
            else
            {
                CriticalBoostC = 1.25;
            }

            //Critical Eye
            if (CEint == 1)
            {
                CriticalEyeC = 3;
            }
            else if (CEint == 2)
            {
                CriticalEyeC = 6;
            }
            else if (CEint == 3)
            {
                CriticalEyeC = 10;
            }
            else if (CEint == 4)
            {
                CriticalEyeC = 15;
            }
            else if (CEint == 5)
            {
                CriticalEyeC = 20;
            }
            else if (CEint == 6)
            {
                CriticalEyeC = 25;
            }
            else if (CEint == 7)
            {
                CriticalEyeC = 30;
            }
            else
            {
                CriticalEyeC = 0;
            }

            //sharpness

            if (Sharp == "Green")
            {
                SharpnessC = 1.05;
            }
            else if (Sharp == "Blue")
            {
                SharpnessC = 1.20;
            }
            else if (Sharp =="White")
            {
                SharpnessC = 1.32;
            }

            //AttackValues over eller lig med 4
            if (AU >= 4)
            {
                BaseAffinity++;
                BaseAffinity++;
                BaseAffinity++;
                BaseAffinity++;
                BaseAffinity++;
            }

            //Non Elemental boost
            if (NonElemental.Checked == true)
            {
                NonElementalC = 1.05;
            }
            else
            {
                NonElementalC = 1;
            }

            //True Raw calc.
            double TrueRaw = ((Weaponattack / BloatValue)+PeakPerformanceC+(3*AU))*NonElementalC;

            //Affinity calc.
            double TrueAffinity = BaseAffinity + CriticalEyeC + WeaknessExploitC + MaximumMightC ;

            //True hit
            double TrueHit = ((SharpnessC*TrueRaw * TrueAffinity * CriticalBoostC) + (SharpnessC*TrueRaw * (100 - TrueAffinity))) / 100;

            TrueRawBox.Text = Convert.ToString(TrueRaw);
            TrueAffinityBox.Text = Convert.ToString(TrueAffinity);
            TrueHitBox.Text = Convert.ToString(TrueHit);




        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        // Maximum Might.
        private void MaximumMight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }



}
