using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Data.SqlClient;
//using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Water_wastewater.OPTIMIZATION_OF_PUMPING_MAIN_SEWAGE
{
    public partial class OPTIMIZATION_OF_PUMPING_MAIN_SEWAGE : System.Web.UI.Page
    {
        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        public double flow1, standby, flow2, phour, l_pmain, dis_elv, low_level, res_head, stn_loss, pow_tariff, esc_pow_tariff, ann_rate, esc_ann_rate;
        public double m, n, n1, n2, l_pipe, l_pump, vmax, vmin, pump_eff, motor_eff, cost_pump, omfac_pipe, omfac_pump, flow_total, dmax, dmin;
        public double flowphr1, flowphr2, flowps1, flowps2, d, vel_act, unit_rate = 0, cost_pipeline, loss_friction, loss_minor, st_head, pump_head, pump_kw;
        public double vel_act2, loss_friction2, loss_minor2, pump_head2, w_hammer1, w_hammer2, pump_kw2, cost_pumpset2, pow_py2, pow_costfy2, om_pumpset_py2, pw_pumpset_om2, total_pw1, total_pw2;
        public double cost_pumpset, pow_py, pow_costfy, om_pumpset_py, om_pipe_py, cost_pumpset_15y, Xf, pw_replace, pw_pow_cost, pw_pipeline_om, pw_pumpset_om, total_pw;
        public double tw, id, k, E, pr1, pr2, pr_ratio1, pr_ratio2, pw_pow_cost2, total_pw_pow_cost;
        public double pop1, pop2, pf1, pf2, avg_flowps1, avg_flowps2, peak_flowps1, peak_flowps2, pkfac_1, pkfac_2, non_peaktme, pump_tme, peak_tme, pw_capcostpumpset2;
        public double avg_flowphr1, avg_flowphr2, peak_flowphr1, peak_flowphr2, balflw1, balflw2;
        public double peak_flow1, peak_flow2, nonpeak_hrflw1, nonpeak_hrflw2, nonpeak_tme, loss_frictionpk, loss_frictionpk2,loss_minor1peak,loss_minor2peak,pump_headpk, pump_headpk2, pump_kwpk, pump_kwpk2, tot_pumpkw1, tot_pumpkw2;
        public double pow_pkpy1, pow_pkpy2, pow_nonpk1, pow_nonpk2, life_stage1plusstage2, stag2_year;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlm.SelectedIndex == 1)
            {
                TextBox39.Text = Convert.ToString(ddld1.Text);
            }
            if (ddlm.SelectedIndex == 2)
            {
                TextBox39.Text = Convert.ToString(ddld2.Text);
            }
            if (ddlm.SelectedIndex == 3)
            {
                TextBox39.Text = Convert.ToString(ddld3.Text);
            }
            if (ddlm.SelectedIndex == 4)
            {
                TextBox39.Text = Convert.ToString(ddld4.Text);
            }
            if (ddlm.SelectedIndex == 5)
            {
                TextBox39.Text = Convert.ToString(ddld5.Text);
            }
            if (ddlm.SelectedIndex == 6)
            {
                TextBox39.Text = Convert.ToString(ddld6.Text);
            }
            //database1();
            if (!Page.IsPostBack)
            {
                datastructure();
                datastructure1();
                datastructure2();
            }
        }

        protected void btn_maxmin_Click(object sender, EventArgs e)
        {
            btn_waterhammer.Enabled = true;
            button_calc.Enabled = false;
            btn_maxmin.Enabled = false;
            //peak factor calculation

            pump_tme = Convert.ToDouble(TextBox3.Text);
            peak_tme = Convert.ToDouble(txt_peakflowtime.Text);
            non_peaktme = (pump_tme - peak_tme);
            txt_nonpeakflowtime.Text = Convert.ToString(non_peaktme);

            pop1 = Convert.ToDouble(txt_pop1.Text);
            if (pop1 < 10000)
            {
                pf1 = 5 / (Math.Pow((pop1 / 1000), 0.2));
            }
            else if (pop1 >= 10000 && pop1 < 20000)
            {
                pf1 = 3;
            }
            else if (pop1 >= 20000 && pop1 < 50000)
            {
                pf1 = 2.5;
            }
            else if (pop1 >= 50000 && pop1 < 750000)
            {
                pf1 = 2.25;
            }
            else if (pop1 >= 750000)
            {
                pf1 = 2;
            }
            txt_peakfac1.Text = Convert.ToString(pf1);


            // for stage 2
            pop2 = Convert.ToDouble(txt_pop2.Text);
            if (pop2 < 10000)
            {
                pf2 = 5 / (Math.Pow((pop2 / 1000), 0.2));
            }
            else if (pop2 >= 10000 && pop2 < 20000)
            {
                pf2 = 3;
            }
            else if (pop2 >= 20000 && pop2 < 50000)
            {
                pf2 = 2.5;
            }
            else if (pop2 >= 50000 && pop2 < 750000)
            {
                pf2 = 2.25;
            }
            else if (pop2 >= 750000)
            {
                pf2 = 2;
            }
            txt_peakfac2.Text = Convert.ToString(pf2);

            //peak factor calculation end

          
            flow1 = Convert.ToDouble(TextBox1.Text);
            flow2 = Convert.ToDouble(TextBox2.Text);
            phour = Convert.ToDouble(TextBox3.Text);
            pkfac_1 = Convert.ToDouble(txt_peakfac1.Text);
            pkfac_2 = Convert.ToDouble(txt_peakfac2.Text);
            peak_tme = Convert.ToDouble(txt_peakflowtime.Text);
            nonpeak_tme = Convert.ToDouble(txt_nonpeakflowtime.Text);

            avg_flowphr1 = flow1 * 1000 / (phour);
            avg_flowphr2 = flow2 * 1000 / (phour);
           
            peak_flowphr1 = (avg_flowphr1 * pkfac_1);
            peak_flowphr2 = (avg_flowphr2 * pkfac_2);
           
            peak_flow1 = (avg_flowphr1 * pkfac_1 * peak_tme);
            peak_flow2 = (avg_flowphr2 * pkfac_2 * peak_tme);

            balflw1 = (flow1 * 1000 - peak_flow1);
            balflw2 = (flow2 * 1000 - peak_flow2);

            nonpeak_hrflw1 = (balflw1/nonpeak_tme);
            nonpeak_hrflw2 = (balflw2 /nonpeak_tme);

            avg_flowps1 = flow1 * 1000 /( phour*3600);
            avg_flowps2 = flow2 * 1000 / (phour * 3600);
            peak_flowps1 = (avg_flowps1 * pkfac_1);
            peak_flowps2 = (avg_flowps2 * pkfac_2);
            // for dmax and d min use peak flow of stage2
            dmax = Math.Sqrt(4 * peak_flowps2 / (3.14 * 1.2)) * 1000;
            dmin = Math.Sqrt(4 * peak_flowps2 / (3.14 * 3)) * 1000;


            TextBox94.Text = Convert.ToString(Math.Round(dmax));
            TextBox95.Text = Convert.ToString(Math.Round(dmin));

            txt_avgflo1.Text = Convert.ToString(Math.Round(avg_flowphr1, 2));
            txt_avgflo2.Text = Convert.ToString(Math.Round(avg_flowphr2, 2));
            txt_peakflo1.Text = Convert.ToString(Math.Round(peak_flow1, 2));
            txt_peakflo2.Text = Convert.ToString(Math.Round(peak_flow2, 2));
            txt_balflow1.Text = Convert.ToString(Math.Round(balflw1, 2));
            txt_balflow2.Text = Convert.ToString(Math.Round(balflw2, 2));
            txt_hrpeak1.Text = Convert.ToString(Math.Round(peak_flowphr1, 2));
            txt_hrpeak2.Text = Convert.ToString(Math.Round(peak_flowphr2, 2));
            txt_nonpeakflw1.Text = Convert.ToString(Math.Round(nonpeak_hrflw1, 2));
            txt_nonpeakflw2.Text = Convert.ToString(Math.Round(nonpeak_hrflw2, 2));

        }

        protected void ddlm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlm.SelectedIndex == 1)
            {
                paneld1.Visible = true;
                ddld1.Visible = true;
                paneld2.Visible = false;
                paneld3.Visible = false;
                paneld4.Visible = false;
                paneld5.Visible = false;
                paneld6.Visible = false;
                TextBox23.Text = "130";
                TextBox39.Text = Convert.ToString(ddld1.Text);

                cv1.Enabled = true;
                cv2.Enabled = false;
                cv3.Enabled = false;
                cv4.Enabled = false;
                cv5.Enabled = false;
                cv6.Enabled = false;
               

            }
            else if (ddlm.SelectedIndex == 2)
            {
                paneld1.Visible = false;
                ddld2.Visible = true;
                paneld2.Visible = true;
                paneld3.Visible = false;
                paneld4.Visible = false;
                paneld5.Visible = false;
                paneld6.Visible = false;
                TextBox23.Text = "130";
                TextBox39.Text = Convert.ToString(ddld2.Text);

                cv1.Enabled = false;
                cv2.Enabled = true;
                cv3.Enabled = false;
                cv4.Enabled = false;
                cv5.Enabled = false;
                cv6.Enabled = false;

            }
            else if (ddlm.SelectedIndex == 3)
            {
                paneld1.Visible = false;
                ddld3.Visible = true;
                paneld2.Visible = false;
                paneld3.Visible = true;
                paneld4.Visible = false;
                paneld5.Visible = false;
                paneld6.Visible = false;
                TextBox23.Text = "140";
                TextBox39.Text = Convert.ToString(ddld3.Text);

                cv1.Enabled = false;
                cv2.Enabled = false;
                cv3.Enabled = true;
                cv4.Enabled = false;
                cv5.Enabled = false;
                cv6.Enabled = false;

            }
            else if (ddlm.SelectedIndex == 4)
            {
                paneld1.Visible = false;
                paneld2.Visible = false;
                paneld3.Visible = false;
                paneld4.Visible = true;
                ddld4.Visible = true;
                paneld5.Visible = false;
                paneld6.Visible = false;
                TextBox23.Text = "130";
                TextBox39.Text = Convert.ToString(ddld4.Text);

                cv1.Enabled = false;
                cv2.Enabled = false;
                cv3.Enabled = false;
                cv4.Enabled = true;
                cv5.Enabled = false;
                cv6.Enabled = false;

            }
            else if (ddlm.SelectedIndex == 5)
            {
                paneld1.Visible = false;
                paneld2.Visible = false;
                paneld3.Visible = false;
                paneld4.Visible = false;
                paneld5.Visible = true;
                ddld5.Visible = true;
                paneld6.Visible = false;
                TextBox23.Text = "140";
                TextBox39.Text = Convert.ToString(ddld5.Text);

                cv1.Enabled = false;
                cv2.Enabled = false;
                cv3.Enabled = false;
                cv4.Enabled = false;
                cv5.Enabled = true;
                cv6.Enabled = false;

            }
            else if (ddlm.SelectedIndex == 6)
            {
                paneld1.Visible = false;
                paneld2.Visible = false;
                paneld3.Visible = false;
                paneld4.Visible = false;
                paneld5.Visible = false;
                paneld6.Visible = true;
                ddld6.Visible = true;
                TextBox23.Text = "130";
                TextBox39.Text = Convert.ToString(ddld6.Text);

                cv1.Enabled = false;
                cv2.Enabled = false;
                cv3.Enabled = false;
                cv4.Enabled = false;
                cv5.Enabled = false;
                cv6.Enabled = true;

            }
        }

        protected void btn_waterhammer_Click(object sender, EventArgs e)
        {
            button_calc.Enabled = true;
            btn_waterhammer.Enabled = false;

            flow1 = Convert.ToDouble(TextBox1.Text);
            flow2 = Convert.ToDouble(TextBox2.Text);
            phour = Convert.ToDouble(TextBox3.Text);
            pkfac_1 = Convert.ToDouble(txt_peakfac1.Text);
            pkfac_2 = Convert.ToDouble(txt_peakfac2.Text);
            peak_tme = Convert.ToDouble(txt_peakflowtime.Text);
            nonpeak_tme = Convert.ToDouble(txt_nonpeakflowtime.Text);

            l_pmain = Convert.ToDouble(TextBox4.Text);
            dis_elv = Convert.ToDouble(TextBox5.Text);
            low_level = Convert.ToDouble(TextBox6.Text);
            res_head = Convert.ToDouble(TextBox7.Text);
            stn_loss = Convert.ToDouble(TextBox8.Text);

            d = Convert.ToDouble(TextBox39.Text);

            tw = Convert.ToDouble(txt_tw.Text);
            id = Convert.ToDouble(txt_di.Text);
            k = Convert.ToDouble(txt_k.Text);
            E = Convert.ToDouble(txt_E.Text);
            pr1 = Convert.ToDouble(txt_pr1.Text);


            avg_flowphr1 = flow1 * 1000 / (phour);
            avg_flowphr2 = flow2 * 1000 / (phour);

            peak_flowphr1 = (avg_flowphr1 * pkfac_1);
            peak_flowphr2 = (avg_flowphr2 * pkfac_2);

            peak_flow1 = (avg_flowphr1 * pkfac_1 * peak_tme);
            peak_flow2 = (avg_flowphr2 * pkfac_2 * peak_tme);

            balflw1 = (flow1 * 1000 - peak_flow1);
            balflw2 = (flow2 * 1000 - peak_flow2);

            nonpeak_hrflw1 = (balflw1 / nonpeak_tme);
            nonpeak_hrflw2 = (balflw2 / nonpeak_tme);

            avg_flowps1 = flow1 * 1000 / (phour * 3600);
            avg_flowps2 = flow2 * 1000 / (phour * 3600);
            peak_flowps1 = (avg_flowps1 * pkfac_1);
            peak_flowps2 = (avg_flowps2 * pkfac_2);

            vel_act = peak_flowps1 / (0.7854 * Math.Pow((id / 1000), 2));
            vel_act2 = peak_flowps2 / (0.7854 * Math.Pow((id / 1000), 2));


            // loss in pipe during peak flow

            loss_frictionpk = Math.Pow(((peak_flowps1 * 3600) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
            loss_frictionpk2 = Math.Pow(((peak_flowps2 * 3600) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
           

            // loss in pipe during non peak flow flow

            loss_friction = Math.Pow(((nonpeak_hrflw1) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
            loss_friction2 = Math.Pow(((nonpeak_hrflw2) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
          
            // minor loss during peak flow
             loss_minor1peak = 0.07 * loss_frictionpk;
             loss_minor2peak = 0.07 * loss_frictionpk2;
          
            // minor loss during non peak flow

             loss_minor = 0.07 * loss_friction;
             loss_minor2 = 0.07 * loss_friction2;
             st_head = dis_elv - low_level;

            // Pump HEAD during peak hours

             pump_headpk = loss_frictionpk + loss_minor1peak + st_head + res_head + stn_loss;
             pump_headpk2 = loss_frictionpk2 + loss_minor2peak + st_head + res_head + stn_loss;

            // PUMP Head during non peak hours

            pump_head = loss_friction + loss_minor + st_head + res_head + stn_loss;
            pump_head2 = loss_friction2 + loss_minor2 + st_head + res_head + stn_loss;
          
            w_hammer1 = (vel_act / 9.81) * (1425 / Math.Sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
            w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.Sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));

            // here u may need to work if 
            pr_ratio1 = (w_hammer1 + pump_headpk) / (pr1);
            pr_ratio2 = (w_hammer2 + pump_headpk2) / (pr1);

            txt_waterhammer_1.Text = Convert.ToString(Math.Round(w_hammer1, 2));
            txt_waterhammer_2.Text = Convert.ToString(Math.Round(w_hammer2, 2));

            txtpump_headpeak1.Text = Convert.ToString(Math.Round(pump_headpk, 2));
            txtpump_headpeak2.Text = Convert.ToString(Math.Round(pump_headpk2, 2));   
            txtpump_head.Text = Convert.ToString(Math.Round(pump_head, 2));
            txtpump_head2.Text = Convert.ToString(Math.Round(pump_head2, 2));

            if (pr_ratio1 < 1.1)
            {
                Label3.Visible = true;
                Label1.Visible = false;
                Label2.Visible = false;

            }

            else if (pr_ratio1 >= 1.1 && pr_ratio1 <= 1.5)
            {
                Label2.Visible = true;
                Label1.Visible = false;
                Label3.Visible = false;
            }
            else if (pr_ratio1 > 1.5)
            {
                Label1.Visible = true;
                Label3.Visible = false;
                Label2.Visible = false;

            }

            if (pr_ratio2 <= 1.1)
            {
                Label6.Visible = true;
                Label4.Visible = false;
                Label5.Visible = false;

            }
            else if (pr_ratio2 >= 1.1 && pr_ratio2 <= 1.5)
            {
                Label5.Visible = true;
                Label4.Visible = false;
                Label6.Visible = false;
            }
            else if (pr_ratio2 > 1.5)
            {
                Label4.Visible = true;
                Label6.Visible = false;
                Label5.Visible = false;

            }
        }

        protected void button_calc_Click(object sender, EventArgs e)
        {
            button_calc.Enabled = false;
            btn_add.Enabled = true;
            btn_waterhammer.Enabled = false;
            btn_refresh.Enabled = true;
            btn_maxmin.Enabled = false;

            flow1 = Convert.ToDouble(TextBox1.Text);
            flow2 = Convert.ToDouble(TextBox2.Text);
            phour = Convert.ToDouble(TextBox3.Text);
            pkfac_1 = Convert.ToDouble(txt_peakfac1.Text);
            pkfac_2 = Convert.ToDouble(txt_peakfac2.Text);
            peak_tme = Convert.ToDouble(txt_peakflowtime.Text);
            nonpeak_tme = Convert.ToDouble(txt_nonpeakflowtime.Text);

            l_pmain = Convert.ToDouble(TextBox4.Text);
            dis_elv = Convert.ToDouble(TextBox5.Text);
            low_level = Convert.ToDouble(TextBox6.Text);
            res_head = Convert.ToDouble(TextBox7.Text);
            stn_loss = Convert.ToDouble(TextBox8.Text);
            pow_tariff = Convert.ToDouble(TextBox9.Text);
            esc_pow_tariff = Convert.ToDouble(TextBox10.Text);
            ann_rate = Convert.ToDouble(TextBox11.Text);
            esc_ann_rate = Convert.ToDouble(TextBox12.Text);
            n = Convert.ToDouble(TextBox13.Text); //years consider for stage 1
            stag2_year = Convert.ToDouble(TextBox96.Text);  
            l_pipe = Convert.ToDouble(TextBox14.Text);
            l_pump = Convert.ToDouble(TextBox15.Text);

            pump_eff = Convert.ToDouble(TextBox18.Text);
            motor_eff = Convert.ToDouble(TextBox19.Text);
            cost_pump = Convert.ToDouble(TextBox20.Text);
            omfac_pump = Convert.ToDouble(TextBox21.Text);
            omfac_pipe = Convert.ToDouble(TextBox22.Text);
            standby = Convert.ToDouble(txt_proposedstand.Text);
            // d = Convert.ToDouble(TextBox39.Text);

            tw = Convert.ToDouble(txt_tw.Text);
            id = Convert.ToDouble(txt_di.Text);
            k = Convert.ToDouble(txt_k.Text);
            E = Convert.ToDouble(txt_E.Text);

            //hourly average flow

            avg_flowphr1 = (flow1 * 1000) / (phour);
            avg_flowphr2 = (flow2 * 1000) / (phour);

            //Average flow per second in m3/s

            avg_flowps1 = (flow1 * 1000) / (phour * 3600);
            avg_flowps2 = (flow2 * 1000) / (phour * 3600);


            //hourly peak flow in m3/hr

            peak_flowphr1 = (avg_flowphr1 * pkfac_1);
            peak_flowphr2 = (avg_flowphr2 * pkfac_2);

            //Peak flow per second in m3/s

            peak_flowps1 = (avg_flowps1 * pkfac_1);
            peak_flowps2 = (avg_flowps2 * pkfac_2);

            //Peak flow during peak time in m3

            peak_flow1 = (avg_flowphr1 * pkfac_1 * peak_tme);
            peak_flow2 = (avg_flowphr2 * pkfac_2 * peak_tme);

            // Balance flow during non peak time in m3

            balflw1 = ((flow1 * 1000) - peak_flow1);
            balflw2 = ((flow2 * 1000) - peak_flow2);
            
            // non peak hourly flow or hourly balance flow in m3/hr

            nonpeak_hrflw1 = (balflw1 / nonpeak_tme);
            nonpeak_hrflw2 = (balflw2 / nonpeak_tme);

            // Actual velocity calculation

            vel_act = peak_flowps1 / (0.7854 * Math.Pow((id / 1000), 2));
            vel_act2 = peak_flowps2 / (0.7854 * Math.Pow((id / 1000), 2));

            // cost of pipeline

            cost_pipeline = Convert.ToDouble(TextBox38.Text) * l_pmain / 100000;

            // frictional loss in pipe during peak flow

            loss_frictionpk = Math.Pow(((peak_flowphr1) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
            loss_frictionpk2 = Math.Pow(((peak_flowphr2) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;


            // frictional loss in pipe during non peak flow flow

            loss_friction = Math.Pow(((nonpeak_hrflw1) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;
            loss_friction2 = Math.Pow(((nonpeak_hrflw2) / (1.292 * 0.00001 * Convert.ToDouble(TextBox23.Text) * Math.Pow(id, 2.63))), (1 / 0.54)) * l_pmain;

 
            // minor loss during peak flow

            loss_minor1peak = 0.07 * loss_frictionpk;
            loss_minor2peak = 0.07 * loss_frictionpk2;

            // minor loss during non peak flow

            loss_minor = 0.07 * loss_friction;
            loss_minor2 = 0.07 * loss_friction2;
             
            //static head 

            st_head = dis_elv - low_level;

            // total Pump HEAD during peak hours

            pump_headpk = loss_frictionpk + loss_minor1peak + st_head + res_head + stn_loss;
            pump_headpk2 = loss_frictionpk2 + loss_minor2peak + st_head + res_head + stn_loss;

            // total PUMP Head during non peak hours

            pump_head = loss_friction + loss_minor + st_head + res_head + stn_loss;
            pump_head2 = loss_friction2 + loss_minor2 + st_head + res_head + stn_loss;

            w_hammer1 = (vel_act / 9.81) * (1425 / Math.Sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
            w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.Sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
         
  
            //Pump kw DURING peak flow

            pump_kwpk = ((peak_flowphr1) * pump_headpk) / (367.25 * (pump_eff / 100) * (motor_eff / 100));
            pump_kwpk2 = ((peak_flowphr2) * pump_headpk2) / (367.25 *( pump_eff / 100) * (motor_eff / 100));

           // pUmp kw during non peak flow

            pump_kw = ((nonpeak_hrflw1) * pump_head) / (367.25 * (pump_eff / 100) * (motor_eff / 100));
            pump_kw2 = ((nonpeak_hrflw2) * pump_head2) / (367.25 * (pump_eff / 100) *( motor_eff / 100));

            // total pump kw during both peak flow and non peak flow 

            tot_pumpkw1 = pump_kwpk + pump_kw;
            tot_pumpkw2 = pump_kwpk2 + pump_kw2;

            //cAPITAL COST OF PUMPSET( THIS IS CORRECT FOR STAGE 1)// sir told to use peak flow only

            cost_pumpset = pump_kwpk * (1 + (standby / 100)) * cost_pump / 100000;

            //cAPITAL COST OF PUMPSET FOR STAGE 2  (as told by sir to use only peak flow)
            cost_pumpset2 = pump_kwpk2 * (1 + (standby / 100)) * cost_pump / 100000;

            //Cost of pumpsets after 15 years for replacement i.e this is the cost of pumps for second stage.

            cost_pumpset_15y = cost_pumpset2 * Math.Pow(1 + (esc_ann_rate / 100), 15);
           
            //PRESENT WORTH OF CAPITAL COST OF PUMPSET FOR STAGE 2
            pw_capcostpumpset2 = cost_pumpset_15y / Math.Pow(1 + (ann_rate / 100), l_pump);
          
            // see from here

            // power required in one year for peak flow

            pow_pkpy1 = pump_kwpk * peak_tme * 365;
            pow_pkpy2 = pump_kwpk2 * peak_tme * 365;

            //  power required in one year for non peak flow
            pow_nonpk1 = pump_kw * nonpeak_tme * 365;
            pow_nonpk2 = pump_kw2 * nonpeak_tme * 365;

            // total power required in one year from both peak flow and non peak flow

            pow_py = pow_pkpy1 + pow_nonpk1;
            pow_py2 = pow_pkpy2 + pow_nonpk2;
           
            // pOWER COST DURING FIRST YEAR

            pow_costfy = pow_py * pow_tariff / 100000;
            pow_costfy2 = pow_py2 * pow_tariff / 100000;

           
            // O&M COST OF PUMPSET PER YEAR

            om_pumpset_py = omfac_pump / 100 * cost_pumpset;
            om_pumpset_py2 = omfac_pump / 100 * cost_pumpset2;

            //O&M COST OF PIPELINE PER YEAR

            om_pipe_py = omfac_pipe / 100 * cost_pipeline;
           
            // X FACTOR

            Xf = (1 + (esc_ann_rate / 100)) / (1 + (ann_rate / 100));

            //Replacement Cost of Pumpsets - Present Worth

            pw_replace = cost_pumpset_15y / Math.Pow((1 + (ann_rate / 100)), l_pump);
            
           //Power COST for stage 1 present worth

            pw_pow_cost = pow_costfy * Xf * (1 - Math.Pow(Xf, n)) / (1 - Xf);

            //Power cost  for stage 2 present worth
         
            pw_pow_cost2 = (pow_costfy2 / (Math.Pow((1 + ann_rate / 100), l_pump)))* Xf * (1 - Math.Pow(Xf, l_pipe)) / (1 - Xf);
          
            // Total power cost for stage 1 and stage 2  present worth

             total_pw_pow_cost = pw_pow_cost + pw_pow_cost2;

            //Pipeline O&M COST PRESENT WORTH

             pw_pipeline_om = om_pipe_py * Xf * (1 - Math.Pow(Xf, l_pipe)) / (1 - Xf);

            // pumpset O&M cost for stage 1 Present worth

             pw_pumpset_om = om_pumpset_py * Xf * (1 - Math.Pow(Xf, l_pump)) / (1 - Xf);

            // pumpset o&m cost for stage 2 Present worth

             life_stage1plusstage2 = (n + stag2_year);   //considering stage 1 and stage 2 no of years together

             pw_pumpset_om2 = (om_pumpset_py2 /( Math.Pow((1 + ann_rate/100),l_pump))) * Xf * (1 - Math.Pow(Xf, l_pipe)) / (1 - Xf);
          
            
          
            //total net present value for stage 1 (excluding pipe)

             total_pw1 = cost_pumpset + pw_pow_cost + pw_pumpset_om;

            //total net present value for stage 2 (excluding pipe)

             total_pw2 = pw_capcostpumpset2 + pw_pow_cost2 + pw_pumpset_om2;

            //total net present value for both stage 1 and stage 2 including pipeline

           // total_pw = total_pw1 + total_pw2 + (pw_pipeline_om + cost_pipeline);

            total_pw = (pw_pipeline_om + cost_pipeline) + (cost_pumpset + pw_capcostpumpset2 +pw_pumpset_om +pw_pumpset_om2) +(pw_pow_cost+pw_pow_cost2) ;
           
            // actual velocity filling

            txtact_vel.Text = Convert.ToString(Math.Round(vel_act, 2));
            txtact_vel2.Text = Convert.ToString(Math.Round(vel_act2, 2));
            txtunitrate.Text = Convert.ToString(TextBox38.Text);
           
           // frictional loss in pipe filling

            txt_fripeak1.Text = Convert.ToString(Math.Round(loss_frictionpk, 2));
            txt_fripeak2.Text = Convert.ToString(Math.Round(loss_frictionpk2, 2));
            TextBox78.Text = Convert.ToString(Math.Round(loss_friction, 2));
            TextBox98.Text = Convert.ToString(Math.Round(loss_friction2, 2));

            // pump kw box filling

            txtpump_kwpeak1.Text = Convert.ToString(Math.Round(pump_kwpk, 2));
            txtpump_kwpeak2.Text = Convert.ToString(Math.Round(pump_kwpk2, 2));
            txtpump_kw.Text = Convert.ToString(Math.Round(pump_kw, 2));
            txtpump_kw2.Text = Convert.ToString(Math.Round(pump_kw2, 2));
            txttotpump_kw1.Text = Convert.ToString(Math.Round(tot_pumpkw1, 2));
            txttotpump_kw2.Text = Convert.ToString(Math.Round(tot_pumpkw2, 2));
           
            // cost of pumpset filling

            txtcost_pumpset.Text = Convert.ToString(Math.Round(cost_pumpset, 2));
            txtpw_replace.Text = Convert.ToString(Math.Round(cost_pumpset2, 2));

            TXT_PUMPSETCOST15.Text = Convert.ToString(Math.Round(cost_pumpset_15y, 2));

            TXT_PWREP_PUMPSET2.Text = Convert.ToString(Math.Round(pw_replace, 2));
           
            txtXf.Text = Convert.ToString(Math.Round(Xf, 3));
           
            // power required in one year 

            txtpow_pypeak1.Text = Convert.ToString(Math.Round(pow_pkpy1, 2));
            txtpow_pypeak2.Text = Convert.ToString(Math.Round(pow_pkpy2, 2));
            txtpow_nonpeak1.Text = Convert.ToString(Math.Round(pow_nonpk1, 2));
            txtpow_nonpeak2.Text = Convert.ToString(Math.Round(pow_nonpk2, 2));
            txtpow_py.Text = Convert.ToString(Math.Round(pow_py, 2));
            txtpow_py2.Text = Convert.ToString(Math.Round(pow_py2, 2));


            //power cost per year
            TXT_POWCSTPERYR1.Text = Convert.ToString(Math.Round(pow_costfy, 2));
            TXT_POWCSTPERYR2.Text = Convert.ToString(Math.Round(pow_costfy2, 2));
           
            // O & M cost for Pipeline PER YEAR
            TXT_OMPIPECOSTPERYR1.Text = Convert.ToString(Math.Round(om_pipe_py, 2));
            TXT_OMPIPECOSTPERYR2.Text = Convert.ToString(Math.Round(om_pipe_py, 2));

            //Net Present Value of O & M cost for Pipeline
            txtpw_pipeline_om.Text = Convert.ToString(Math.Round(pw_pipeline_om, 2));
           
            // pumpset o&m cost
            TXT_OMCOSTPERYR1.Text = Convert.ToString(Math.Round(om_pumpset_py, 2));
            TXT_OMCOSTPERYR2.Text = Convert.ToString(Math.Round(om_pumpset_py2, 2));

            txtpw_pumpset_om.Text = Convert.ToString(Math.Round(pw_pumpset_om, 2));
            txtpw_pumpset_om2.Text = Convert.ToString(Math.Round(pw_pumpset_om2, 2));

            // net present value of power cost 
            txtpw_pow_cost.Text = Convert.ToString(Math.Round(pw_pow_cost, 2));
            txtpw_pow_cost2.Text = Convert.ToString(Math.Round(pw_pow_cost2, 2));

            // net total power cost
            TextBox99.Text = Convert.ToString(Math.Round(total_pw_pow_cost, 2));

            //Total net present value escluding pipe

            txttotal_pw1.Text = Convert.ToString(Math.Round(total_pw1, 2));
            txttotal_pw2.Text = Convert.ToString(Math.Round(total_pw2, 2));
            
            //Total net present value including  pipe
            txttotal_pw.Text = Convert.ToString(Math.Round(total_pw, 2));

            txtpw_pipe.Text = Convert.ToString(Math.Round(cost_pipeline, 2));
            txtpw_pumpset.Text = Convert.ToString(Math.Round(cost_pumpset, 2));
            txtpw_pumpset2.Text = Convert.ToString(Math.Round(pw_capcostpumpset2, 2));

            // disabling the text box to remove error while printing

            txt_di.Enabled = false;
            txt_k.Enabled = false;
            txt_pr1.Enabled = false;
            TextBox38.Enabled = false;
            txt_tw.Enabled = false;
            txt_E.Enabled = false;
            ddld1.Enabled = false;
            ddld2.Enabled = false;
            ddld3.Enabled = false;
            ddld4.Enabled = false;
            ddld5.Enabled = false;
            ddld6.Enabled = false;
            TextBox1.Enabled = false;
            TextBox3.Enabled = false;
            TextBox5.Enabled = false;
            TextBox7.Enabled = false;
            TextBox9.Enabled = false;
            TextBox11.Enabled = false;
            ddlm.Enabled = false;
            TextBox13.Enabled = false;
            TextBox14.Enabled = false;
            TextBox18.Enabled = false;
            TextBox20.Enabled = false;
            TextBox22.Enabled = false;
            txt_proposedstand.Enabled = false;
            TextBox2.Enabled = false;
            TextBox4.Enabled = false;
            TextBox6.Enabled = false;
            TextBox8.Enabled = false;
            TextBox10.Enabled = false;
            TextBox12.Enabled = false;
            TextBox97.Enabled = false;
            TextBox96.Enabled = false;
            TextBox15.Enabled = false;
            TextBox19.Enabled = false;
            TextBox21.Enabled = false;
            TextBox23.Enabled = false;

            //new text box disable

            txt_pop1.Enabled = false;
            txt_pop2.Enabled = false;
            txt_peakflowtime.Enabled = false;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            btn_add.Enabled = false;
            btn_refresh.Enabled = true;
            btn_cont.Enabled = true;
            paninp_output.Visible = true;

            //take out the source from the viewstate object

            DataTable dtDatas = (DataTable)ViewState["dtDatas"];

            //initialise a new Datarow object

            DataRow drNewRow = dtDatas.NewRow();

            drNewRow["Diameter"] = TextBox39.Text;
            drNewRow["Inner Diameter"] = txt_di.Text;
   
            drNewRow["Average Hourly Flow for Stage I"] = txt_avgflo1.Text;
            drNewRow["Total Flow in Peak Flow Hours for Stage I"] = txt_peakflo1.Text;
            drNewRow["Hourly Peak Flow for Stage I"] = txt_hrpeak1.Text;
            drNewRow["Balance Flow during Non Peak Flow Hours for Stage I"] = txt_balflow1.Text;
            drNewRow["Non Peak Flow Hourly demand for Stage I"] = txt_nonpeakflw1.Text;

            drNewRow["Actual velocity_StageI"] = txtact_vel.Text;
            drNewRow["Pipe Friction Loss for Stage I during Peak Flow"] = txt_fripeak1.Text;
            drNewRow["Pipe Friction Loss for Stage I during Non Peak Flow"] = TextBox78.Text;
            drNewRow["Total Pump Head for Stage I during Peak Flow"] = txtpump_headpeak1.Text;

            drNewRow["Total Pump Head for Stage I during Non Peak Flow"] = txtpump_head.Text;
            drNewRow["Pump kW for Stage I during  Peak flow"] = txtpump_kwpeak1.Text;
            drNewRow["Pump kW for Stage I during Non  Peak Flow"] = txtpump_kw.Text;
           
            //drNewRow["Total Pump kW for Stage I "] = txttotpump_kw1.Text;

            drNewRow["Water Hammer Head for Stage I"] = txt_waterhammer_1.Text;

            drNewRow["Capital Cost of Pumpsets for Stage I"] = txtcost_pumpset.Text;
            drNewRow["X factor"] = txtXf.Text;
            drNewRow["Power Required in One Year for Stage I during Peak Flow"] = txtpow_pypeak1.Text;
            drNewRow["Power Required in One Year for Stage I during Non Peak Flow"] = txtpow_nonpeak1.Text;
            drNewRow["Total Power Required in One Year for Stage I"] = txtpow_py.Text;

            //new
            drNewRow["Power cost for Stage I  per year"] = TXT_POWCSTPERYR1.Text;
            drNewRow["O&M Cost for pumpsets per year for Stage I"] = TXT_OMCOSTPERYR1.Text;
            drNewRow["O&M Cost for Pipeline per year for Stage I"] = TXT_OMPIPECOSTPERYR1.Text;


            drNewRow["Net present value of Capital Cost for Pipeline_StageI"] = txtpw_pipe.Text;
            drNewRow["Net Present Value of O & M cost for Pipeline_StageI"] = txtpw_pipeline_om.Text;
            drNewRow["Net present value of Capital Cost for Pumpsets_StageI"] = txtpw_pumpset.Text;
            drNewRow["Net Present Value of O & M cost for Pumpsets_StageI"] = txtpw_pumpset_om.Text;
            drNewRow["Net Present value of Power cost_StageI"] = txtpw_pow_cost.Text;  
            drNewRow["Total Net Present Value for Stage I (Excluding Pipe)"] = txttotal_pw1.Text;

          
            //add this new row to the Datatable and commit changes
            dtDatas.Rows.Add(drNewRow);
            dtDatas.AcceptChanges();
            //now since you have your datasource,bind it to the grid
            gv1.DataSource = dtDatas;

            gv1.DataBind();

            //take out the source from the viewstate object

            DataTable dtDatas1 = (DataTable)ViewState["dtDatas1"];

            //initialise a new Datarow object

            DataRow drNewRow1 = dtDatas1.NewRow();


            // input 

            drNewRow1["Flow for stage 1"] = TextBox1.Text;
            drNewRow1["Flow for stage 2"] = TextBox2.Text;
            drNewRow1["Pumping hours"] = TextBox3.Text;
           
            //NEW
            drNewRow1["Peak flow hours per Day"] = txt_peakflowtime.Text;
            drNewRow1["Population for Stage I"] = txt_pop1.Text;
            drNewRow1["Population for Stage II"] = txt_pop2.Text;
            drNewRow1["Peak Factor for Stage I"] = txt_peakfac1.Text;
            drNewRow1["Peak Factor for Stage II"] = txt_peakfac2.Text;
            //
            drNewRow1["Length of Pumping Main"] = TextBox4.Text;
            drNewRow1["Discharge Point Elevation"] = TextBox5.Text;
            drNewRow1["Low water level at source"] = TextBox6.Text;
            drNewRow1["Residual Head"] = TextBox7.Text;
            drNewRow1["Station Losses"] = TextBox8.Text;
            drNewRow1["Power Tariff"] = TextBox9.Text;
            drNewRow1["Escalation of Power Tariff"] = TextBox10.Text;
            drNewRow1["Escalated rate"] = TextBox12.Text;
            drNewRow1["Annual Intrest Rate"] = TextBox11.Text;
            drNewRow1["Material Considered"] = ddlm.Text;
            drNewRow1["Nos of year to be considered (Design Period)"] = TextBox13.Text;
            drNewRow1["Life of Pipeline"] = TextBox14.Text;
            drNewRow1["Life of the pumpsets"] = TextBox15.Text;
            drNewRow1["Pump Efficiency"] = TextBox18.Text;
            drNewRow1["Motor Efficiency"] = TextBox19.Text;
            drNewRow1["Cost of Pumpsets"] = TextBox20.Text;
            drNewRow1["O & M cost factor for pumpset per year"] = TextBox21.Text;
            drNewRow1["O & M cost factor for pipeline per year"] = TextBox22.Text;
            drNewRow1["Hazen Williams Coefficient"] = TextBox23.Text;
            drNewRow1["Material Unit Rate"] = TextBox38.Text;
            drNewRow1["Wall Thickness of Pipe"] = txt_tw.Text;
            drNewRow1["Bulk Modulus of Water"] = txt_k.Text;
            drNewRow1["Modulus of Elasticity of Pipe Material"] = txt_E.Text;
            drNewRow1["Allowable Withstanding Pressure of Selected Pipe"] = txt_pr1.Text;
            drNewRow1["Proposed Standby"] = txt_proposedstand.Text;


            //add this new row to the Datatable and commit changes
            dtDatas1.Rows.Add(drNewRow1);
            dtDatas1.AcceptChanges();
            //now since you have your datasource,bind it to the grid
            gv2.DataSource = dtDatas1;

            gv2.DataBind();


            //take out the source from the viewstate object

            DataTable dtDatas2 = (DataTable)ViewState["dtDatas2"];

            //initialise a new Datarow object

            DataRow drNewRow2 = dtDatas2.NewRow();
 
           // OUTPUT STAGE 2

            drNewRow2["Average Hourly Flow for Stage II"] = txt_avgflo2.Text;
            drNewRow2["Total Flow in Peak Flow Hours for Stage II"] = txt_peakflo2.Text;
            drNewRow2["Hourly Peak Flow for Stage II"] = txt_hrpeak2.Text;
            drNewRow2["Balance Flow during Non Peak Flow Hours for Stage II"] = txt_balflow2.Text;
            drNewRow2["Non Peak Flow Hourly demand for Stage II"] = txt_nonpeakflw2.Text;
            
            drNewRow2["Actual velocity_StageII"] = txtact_vel2.Text;

            drNewRow2["Pipe Friction Loss for Stage II during Peak Flow"] = txt_fripeak2.Text;
            drNewRow2["Pipe Friction Loss for Stage II during Non Peak Flow"] = TextBox98.Text;
            drNewRow2["Total Pump Head for Stage II during Peak Flow"] = txtpump_headpeak2.Text;

            drNewRow2["Total Pump Head for Stage II during Non Peak Flow"] = txtpump_head2.Text;

            drNewRow2["Pump kW for Stage II during  Peak flow"] = txtpump_kwpeak2.Text;
            drNewRow2["Pump kW for Stage II during Non  Peak Flow"] = txtpump_kw2.Text;
            //drNewRow2["Total Pump kW for Stage II "] = txttotpump_kw2.Text;
           
            drNewRow2["Water Hammer Head for Stage II"] = txt_waterhammer_2.Text;



            drNewRow2["Capital cost of pumpsets_StageII"] = txtpw_replace.Text;
            drNewRow2["Power Required in One Year for Stage II during Peak Flow"] = txtpow_pypeak2.Text;
            drNewRow2["Power Required in One Year for Stage II during Non Peak Flow"] = txtpow_nonpeak2.Text;
            drNewRow2["Total Power Required in One Year for Stage II"] = txtpow_py2.Text;
            //new
            drNewRow2["Power cost for Stage II per year"] = TXT_POWCSTPERYR2.Text;
            drNewRow2["Cost of pumpsets after 15 years for replacement"] = TXT_PUMPSETCOST15.Text;
            drNewRow2["O&M Cost for pumpsets per year for Stage II"] = TXT_OMCOSTPERYR2.Text;
            drNewRow2["O&M Cost for Pipeline per year for Stage II"] = TXT_OMPIPECOSTPERYR2.Text;
            drNewRow2["Replacement Cost of Pumpsets - Present Worth i.e for stage II"] = TXT_PWREP_PUMPSET2.Text;
            
            
            
            drNewRow2["Net present value of Capital Cost for Pumpsets_StageII"] = txtpw_pumpset2.Text;
            drNewRow2["Net Present value of Power cost_StageII"] = txtpw_pow_cost2.Text;

            drNewRow2["Net Present Value of O & M cost for Pumpsets_StageII"] = txtpw_pumpset_om2.Text;
            drNewRow2["Total Net Present Value_StageII(Excluding Pipe)"] = txttotal_pw2.Text;
            drNewRow2["Total Net Present Value"] = txttotal_pw.Text;


            //add this new row to the Datatable and commit changes
            dtDatas2.Rows.Add(drNewRow2);
            dtDatas2.AcceptChanges();
            //now since you have your datasource,bind it to the grid
            gv3.DataSource = dtDatas2;

            gv3.DataBind();
        }

        protected void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_waterhammer.Enabled = false;
            button_calc.Enabled = false;
            btn_refresh.Enabled = false;
            btn_maxmin.Enabled = true;
            btn_add.Enabled = false;

            // enabling the text box so that user can input the value
            txt_di.Enabled = true;
            txt_k.Enabled = true;
            txt_pr1.Enabled = true;
            TextBox38.Enabled = true;
            txt_tw.Enabled = true;
            txt_E.Enabled = true;
            ddld1.Enabled = true;
            ddld2.Enabled = true;
            ddld3.Enabled = true;
            ddld4.Enabled = true;
            ddld5.Enabled = true;
            ddld6.Enabled = true;
            TextBox1.Enabled = true;
            TextBox3.Enabled = true;
            TextBox5.Enabled = true;
            TextBox7.Enabled = true;
            TextBox9.Enabled = true;
            TextBox11.Enabled = true;
            ddlm.Enabled = true;
            TextBox13.Enabled = true;
            TextBox14.Enabled = true;
            TextBox18.Enabled = true;
            TextBox20.Enabled = true;
            TextBox22.Enabled = true;
            txt_proposedstand.Enabled = true;
            TextBox2.Enabled = true;
            TextBox4.Enabled = true;
            TextBox6.Enabled = true;
            TextBox8.Enabled = true;
            TextBox10.Enabled = true;
            TextBox12.Enabled = true;
            TextBox97.Enabled = true;
            TextBox96.Enabled = true;
            TextBox15.Enabled = true;
            TextBox19.Enabled = true;
            TextBox21.Enabled = true;
            TextBox23.Enabled = true;

            // new text box enable
            txt_pop1.Enabled = true;
            txt_pop2.Enabled = true;
            txt_peakflowtime.Enabled = true;


            txt_di.Text = "";
            TextBox38.Text = "";

            // ouput changing to blank

            txtact_vel.Text = "";
            TextBox78.Text = "";
            txtpump_head.Text = "";
            txtpump_kw.Text = "";
            txt_waterhammer_1.Text = "";
            txtcost_pumpset.Text = "";
            txtXf.Text = "";
            txtpow_py.Text = "";
            txtpw_pipe.Text = "";
            txtpw_pipeline_om.Text = "";
            txtpw_pumpset.Text = "";
            txtpw_pumpset_om.Text = "";
            txtpw_pow_cost.Text = "";
            txttotal_pw1.Text = "";
            TextBox99.Text = "";
            
            txtact_vel2.Text = "";
            TextBox98.Text = "";
            txtpump_head2.Text = "";
            txtpump_kw2.Text = "";
            txt_waterhammer_2.Text = "";
            txtpw_replace.Text = "";
            txtpow_py2.Text = "";
            txtunitrate.Text = "";
            txtpw_pumpset2.Text = "";
            txtpw_pumpset_om2.Text = "";
            txtpw_pow_cost2.Text = "";
            txttotal_pw2.Text = "";
            txttotal_pw.Text = "";

            // new output putting to blank
           
            txt_nonpeakflowtime.Text = "";
            txt_peakfac1.Text = "";
            txt_peakfac2.Text = "";
            txt_avgflo1.Text = "";
            txt_avgflo2.Text = "";
            txt_peakflo1.Text = "";
            txt_peakflo2.Text = "";
            txt_hrpeak1.Text = "";
            txt_hrpeak2.Text = "";
            txt_balflow1.Text = "";
            txt_balflow2.Text = "";
            txt_nonpeakflw1.Text = "";
            txt_nonpeakflw2.Text = "";
            txt_fripeak1.Text = "";
            txt_fripeak2.Text = "";
            txtpump_headpeak1.Text = "";
            txtpump_headpeak2.Text = "";
            txtpump_kwpeak1.Text = "";
            txtpump_kwpeak2.Text = "";
            txttotpump_kw1.Text = "";
            txttotpump_kw2.Text = "";
            txtpow_pypeak1.Text = "";
            txtpow_pypeak2.Text = "";
            txtpow_nonpeak1.Text = "";
            txtpow_nonpeak2.Text = "";
            TextBox94.Text = "";
            TextBox95.Text = "";

            TXT_POWCSTPERYR1.Text = "";
            TXT_POWCSTPERYR2.Text = "";
            TXT_OMCOSTPERYR1.Text = "";
            TXT_OMCOSTPERYR2.Text = "";
            TXT_OMPIPECOSTPERYR1.Text = "";
            TXT_OMPIPECOSTPERYR2.Text = "";
            TXT_PWREP_PUMPSET2.Text = "";
            TXT_PUMPSETCOST15.Text = "";
            // water hammer label visible control

            Label1.Visible = false;
            Label3.Visible = false;
            Label2.Visible = false;
            Label4.Visible = false;
            Label6.Visible = false;
            Label5.Visible = false;


        }

        protected void btn_cont_Click(object sender, EventArgs e)
        {
            btn_optdia.Enabled = true;
            btn_refresh.Enabled = true;
            btn_cont.Enabled = false;
        }

        protected void btn_detresult_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }


        DataTable dtDatas = new DataTable();
        private void datastructure()
        {

            DataTable dtDatas = new DataTable();

            //add columns to the datatable

            // STAGE 1 OUTPUT...

            // NOMINAL DIAMETER I HAVE ADDED IN OUTPUT STAGE 1 BUT IN EXCEL IT IS IN  INPUT SIDE SO WHILE GRID VIEW BE CAREFUL IN COUNTING j,it should be including that

             dtDatas.Columns.Add("Diameter");
             dtDatas.Columns.Add("Inner Diameter");

             dtDatas.Columns.Add("Average Hourly Flow for Stage I");
             dtDatas.Columns.Add("Total Flow in Peak Flow Hours for Stage I");
             dtDatas.Columns.Add("Hourly Peak Flow for Stage I");
             dtDatas.Columns.Add("Balance Flow during Non Peak Flow Hours for Stage I");
             dtDatas.Columns.Add("Non Peak Flow Hourly demand for Stage I");
             dtDatas.Columns.Add("Actual velocity_StageI");
             dtDatas.Columns.Add("Pipe Friction Loss for Stage I during Peak Flow");
             dtDatas.Columns.Add("Pipe Friction Loss for Stage I during Non Peak Flow");
             dtDatas.Columns.Add("Total Pump Head for Stage I during Peak Flow");
             dtDatas.Columns.Add("Total Pump Head for Stage I during Non Peak Flow");
             dtDatas.Columns.Add("Pump kW for Stage I during  Peak flow");
             dtDatas.Columns.Add("Pump kW for Stage I during Non  Peak Flow");
             //dtDatas.Columns.Add("Total Pump kW for Stage I ");

            dtDatas.Columns.Add("Water Hammer Head for Stage I");

            dtDatas.Columns.Add("Capital Cost of Pumpsets for Stage I");
            dtDatas.Columns.Add("X factor");
            dtDatas.Columns.Add("Power Required in One Year for Stage I during Peak Flow");
            dtDatas.Columns.Add("Power Required in One Year for Stage I during Non Peak Flow");
            dtDatas.Columns.Add("Total Power Required in One Year for Stage I");

            //new
            dtDatas.Columns.Add("Power cost for Stage I  per year");
            dtDatas.Columns.Add("O&M Cost for pumpsets per year for Stage I");
            dtDatas.Columns.Add("O&M Cost for Pipeline per year for Stage I");

            dtDatas.Columns.Add("Net present value of Capital Cost for Pipeline_StageI");
            dtDatas.Columns.Add("Net Present Value of O & M cost for Pipeline_StageI");
            dtDatas.Columns.Add("Net present value of Capital Cost for Pumpsets_StageI");
            dtDatas.Columns.Add("Net Present Value of O & M cost for Pumpsets_StageI");
            dtDatas.Columns.Add("Net Present value of Power cost_StageI");
            dtDatas.Columns.Add("Total Net Present Value for Stage I (Excluding Pipe)");



            //store the state of the datatable into a ViewState object

            ViewState["dtDatas"] = dtDatas;
            //grid_rows();
            //grid_cell_extract();

        }

        DataTable dtDatas1 = new DataTable();
        private void datastructure1()
        {

            DataTable dtDatas1 = new DataTable();

            //add columns to the datatable

            //INPUT ENTERING

            dtDatas1.Columns.Add("Flow for stage 1");
            dtDatas1.Columns.Add("Flow for stage 2");
            dtDatas1.Columns.Add("Pumping hours");
            dtDatas1.Columns.Add("Peak flow hours per Day");
            dtDatas1.Columns.Add("Population for Stage I");
            dtDatas1.Columns.Add("Population for Stage II");
            dtDatas1.Columns.Add("Peak Factor for Stage I");
            dtDatas1.Columns.Add("Peak Factor for Stage II");

            dtDatas1.Columns.Add("Length of Pumping Main");
            dtDatas1.Columns.Add("Discharge Point Elevation");
            dtDatas1.Columns.Add("Low water level at source");
            dtDatas1.Columns.Add("Residual Head");
            dtDatas1.Columns.Add("Station Losses");
            dtDatas1.Columns.Add("Power Tariff");
            dtDatas1.Columns.Add("Escalation of Power Tariff");
            dtDatas1.Columns.Add("Escalated rate");
            dtDatas1.Columns.Add("Annual Intrest Rate");
            dtDatas1.Columns.Add("Material Considered");
            dtDatas1.Columns.Add("Nos of year to be considered (Design Period)");
            dtDatas1.Columns.Add("Life of Pipeline");
            dtDatas1.Columns.Add("Life of the pumpsets");
            dtDatas1.Columns.Add("Pump Efficiency");
            dtDatas1.Columns.Add("Motor Efficiency");
            dtDatas1.Columns.Add("Cost of Pumpsets");
            dtDatas1.Columns.Add("O & M cost factor for pumpset per year");
            dtDatas1.Columns.Add("O & M cost factor for pipeline per year");
            dtDatas1.Columns.Add("Hazen Williams Coefficient");
            dtDatas1.Columns.Add("Material Unit Rate");
            dtDatas1.Columns.Add("Wall Thickness of Pipe");
            dtDatas1.Columns.Add("Bulk Modulus of Water");
            dtDatas1.Columns.Add("Modulus of Elasticity of Pipe Material");
            dtDatas1.Columns.Add("Allowable Withstanding Pressure of Selected Pipe");
            dtDatas1.Columns.Add("Proposed Standby");



            //store the state of the datatable into a ViewState object

            ViewState["dtDatas1"] = dtDatas1;
            //grid_rows();
            //grid_cell_extract();

        }

        DataTable dtDatas2 = new DataTable();
        private void datastructure2()
        {

            DataTable dtDatas2 = new DataTable();

            //add columns to the datatable

            // STAGE 2 ADDING

            dtDatas2.Columns.Add("Average Hourly Flow for Stage II");
            dtDatas2.Columns.Add("Total Flow in Peak Flow Hours for Stage II");
            dtDatas2.Columns.Add("Hourly Peak Flow for Stage II");
            dtDatas2.Columns.Add("Balance Flow during Non Peak Flow Hours for Stage II");
            dtDatas2.Columns.Add("Non Peak Flow Hourly demand for Stage II");
            dtDatas2.Columns.Add("Actual velocity_StageII");
            dtDatas2.Columns.Add("Pipe Friction Loss for Stage II during Peak Flow");
            dtDatas2.Columns.Add("Pipe Friction Loss for Stage II during Non Peak Flow");
            dtDatas2.Columns.Add("Total Pump Head for Stage II during Peak Flow");
            dtDatas2.Columns.Add("Total Pump Head for Stage II during Non Peak Flow");
            dtDatas2.Columns.Add("Pump kW for Stage II during  Peak flow");
            dtDatas2.Columns.Add("Pump kW for Stage II during Non  Peak Flow");
            //dtDatas2.Columns.Add("Total Pump kW for Stage II ");
            dtDatas2.Columns.Add("Water Hammer Head for Stage II");
            dtDatas2.Columns.Add("Capital cost of pumpsets_StageII");
            dtDatas2.Columns.Add("Power Required in One Year for Stage II during Peak Flow");
            dtDatas2.Columns.Add("Power Required in One Year for Stage II during Non Peak Flow");
            dtDatas2.Columns.Add("Total Power Required in One Year for Stage II");

            //new
            dtDatas2.Columns.Add("Power cost for Stage II per year");
            dtDatas2.Columns.Add("Cost of pumpsets after 15 years for replacement");
            dtDatas2.Columns.Add("O&M Cost for pumpsets per year for Stage II");
            dtDatas2.Columns.Add("O&M Cost for Pipeline per year for Stage II");
            dtDatas2.Columns.Add("Replacement Cost of Pumpsets - Present Worth i.e for stage II");

            dtDatas2.Columns.Add("Net present value of Capital Cost for Pumpsets_StageII");
            dtDatas2.Columns.Add("Net Present value of Power cost_StageII");
            dtDatas2.Columns.Add("Net Present Value of O & M cost for Pumpsets_StageII");
            dtDatas2.Columns.Add("Total Net Present Value_StageII(Excluding Pipe)");
            dtDatas2.Columns.Add("Total Net Present Value");


            //store the state of the datatable into a ViewState object

            ViewState["dtDatas2"] = dtDatas2;
            //grid_rows();
            //grid_cell_extract();

        }


        public void grid_cell_extract()
        {
            //STAGE 1 OUTPUT this will include nominal dia also as we have added in rows and column under output stage 1
            //generally if u see excel output stage 1 it will be 26 number but as nominal dia to be incorporated so total 27

            string[,] arr = new string[gv1.Rows.Count, 29];

            for (int j = 0; j < gv1.Rows.Count; j++)
            {
                gv1.SelectedIndex = j;
                GridViewRow dg = gv1.SelectedRow;
                for (int i = 0; i < 29; i++)
                {
                    arr[j, i] = dg.Cells[i].Text.ToString();
                }
            }
            Session["arr"] = arr;

        }
        public void grid_cell_extract1()
        {

            //input=no of rows in input of excel

            string[,] arr1 = new string[gv2.Rows.Count, 33];

            for (int j = 0; j < gv2.Rows.Count; j++)
            {
                gv2.SelectedIndex = j;
                GridViewRow dg = gv2.SelectedRow;
                for (int i = 0; i < 33; i++)
                {
                    arr1[j, i] = dg.Cells[i].Text.ToString();
                }
            }
            Session["arr1"] = arr1;

        }
        public void grid_cell_extract2()
        {
            //output stage 2 excluding optimal dia row in excel

            string[,] arr2 = new string[gv3.Rows.Count, 27];

            for (int j = 0; j < gv3.Rows.Count; j++)
            {
                gv3.SelectedIndex = j;
                GridViewRow dg = gv3.SelectedRow;
                for (int i = 0; i < 27; i++)
                {
                    arr2[j, i] = dg.Cells[i].Text.ToString();
                }
            }
            Session["arr2"] = arr2;

        }

        protected void btn_downld_Click(object sender, EventArgs e)
        {
            //feedback
            string date1 = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            string mysql = "Insert into User_feedback(Empl_ID,Name,Usefulness,user_freindly,effort_reduction,MH,suggestion,application,fbdate)values(0 ,'" + "" + "','" + useful.SelectedItem.Text + "','" + friendly.SelectedItem.Text + "','" + mhsave.SelectedItem.Text + "','" + mh.Text + "','" + fb.Text + "','" + "opt_main_sewage" + "','" + date1.ToString() + "'" + ")";
            var survey = new common();
            survey.user_survey(mysql);

            grid_cell_extract();
            grid_cell_extract1();
            grid_cell_extract2();
            string fpath = "".ToString();
            string Std = "".ToString();
            fpath = Server.MapPath("Result_opmain_sewage.xlsx");
            string xlfile_name = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond);

            string xltypnewpath = Server.MapPath("//temp//" + "Result_opmain_sewage" + xlfile_name + ".xlsx");
            string pdfpath = Server.MapPath("//temp//" + "Result_opmain_sewage" + xlfile_name);
            double count = gv1.Rows.Count;
            double count1 = gv2.Rows.Count;
            double count2 = gv3.Rows.Count;
            excelout(fpath, xltypnewpath, pdfpath);

            //save(pdfpath + ".pdf".ToString());
        }

        public void excelout(string fpath, string newpath, string pdf)
        {
            string job_no = Convert.ToString(TextBox40.Text);
            string client_name = Convert.ToString(TextBox42.Text);
            string project_title = Convert.ToString(TextBox41.Text);
            string design_dev = Convert.ToString(TextBox43.Text);
            string emp_code = Convert.ToString(TextBox46.Text);

            DateTime date;
            date = DateTime.Now;
            DateTime date_input = date.Date;
            //to open excel sheet
            string xltyppath;
            string xltypnewpath;

            xltyppath = fpath.ToString();
            xltypnewpath = newpath.ToString();


            FileInfo file = new FileInfo(xltyppath);


            if (File.Exists(xltypnewpath))
            {
            }
            else
                file.CopyTo(xltypnewpath);

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(xltypnewpath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");


            //mapping of elements


            //mWSheet1.Cells[22, 22] = TextBox35.Text;
            string[,] arr = (string[,])Session["arr"];
            string[,] arr1 = (string[,])Session["arr1"];
            string[,] arr2 = (string[,])Session["arr2"];

            //output data
            for (int j = 0; j < gv1.Rows.Count; j++)
            {
                //adding to excel output stage 1


                mWSheet1.Cells[6, 14 + j] = arr[j, 0];//nominal dia
                mWSheet1.Cells[41, 14 + j] = arr[j, 1];
                mWSheet1.Cells[42, 14 + j] = arr[j, 2];
                mWSheet1.Cells[43, 14 + j] = arr[j, 3];
                mWSheet1.Cells[44, 14 + j] = arr[j, 4];
                mWSheet1.Cells[45, 14 + j] = arr[j, 5];
                mWSheet1.Cells[46, 14 + j] = arr[j, 6];
                mWSheet1.Cells[47, 14 + j] = arr[j, 7];
                mWSheet1.Cells[48, 14 + j] = arr[j, 8];
                mWSheet1.Cells[49, 14 + j] = arr[j, 9];
                mWSheet1.Cells[50, 14 + j] = arr[j, 10];
                mWSheet1.Cells[51, 14 + j] = arr[j, 11];
                mWSheet1.Cells[52, 14 + j] = arr[j, 12];
                mWSheet1.Cells[53, 14 + j] = arr[j, 13];
                mWSheet1.Cells[54, 14 + j] = arr[j, 14];
                mWSheet1.Cells[55, 14 + j] = arr[j, 15];
                mWSheet1.Cells[56, 14 + j] = arr[j, 16];
                mWSheet1.Cells[57, 14 + j] = arr[j, 17];
                mWSheet1.Cells[58, 14 + j] = arr[j, 18];
                mWSheet1.Cells[59, 14 + j] = arr[j, 19];
                mWSheet1.Cells[60, 14 + j] = arr[j, 20];
                mWSheet1.Cells[61, 14 + j] = arr[j, 21];
                mWSheet1.Cells[62, 14 + j] = arr[j, 22];
                mWSheet1.Cells[63, 14 + j] = arr[j, 23];
                mWSheet1.Cells[64, 14 + j] = arr[j, 24];
                mWSheet1.Cells[65, 14 + j] = arr[j, 25];
                mWSheet1.Cells[66, 14 + j] = arr[j, 26];
                mWSheet1.Cells[67, 14 + j] = arr[j, 27];
                mWSheet1.Cells[68, 14 + j] = arr[j, 28];
               

            }
            for (int j = 0; j < gv3.Rows.Count; j++)
            {
                //output stage 2

                mWSheet1.Cells[69, 14 + j] = arr2[j, 0];
                mWSheet1.Cells[70, 14 + j] = arr2[j, 1];
                mWSheet1.Cells[71, 14 + j] = arr2[j, 2];
                mWSheet1.Cells[72, 14 + j] = arr2[j, 3];
                mWSheet1.Cells[73, 14 + j] = arr2[j, 4];
                mWSheet1.Cells[74, 14 + j] = arr2[j, 5];
                mWSheet1.Cells[75, 14 + j] = arr2[j, 6];
                mWSheet1.Cells[76, 14 + j] = arr2[j, 7];
                mWSheet1.Cells[77, 14 + j] = arr2[j, 8];
                mWSheet1.Cells[78, 14 + j] = arr2[j, 9];
                mWSheet1.Cells[79, 14 + j] = arr2[j, 10];
                mWSheet1.Cells[80, 14 + j] = arr2[j, 11];
                mWSheet1.Cells[81, 14 + j] = arr2[j, 12];
                mWSheet1.Cells[82, 14 + j] = arr2[j, 13];
                mWSheet1.Cells[83, 14 + j] = arr2[j, 14];
                mWSheet1.Cells[84, 14 + j] = arr2[j, 15];
                mWSheet1.Cells[85, 14 + j] = arr2[j, 16];
                mWSheet1.Cells[86, 14 + j] = arr2[j, 17];
                mWSheet1.Cells[87, 14 + j] = arr2[j, 18];
                mWSheet1.Cells[88, 14 + j] = arr2[j, 19];
                mWSheet1.Cells[89, 14 + j] = arr2[j, 20];
                mWSheet1.Cells[90, 14 + j] = arr2[j, 21];
                mWSheet1.Cells[91, 14 + j] = arr2[j, 22];
                mWSheet1.Cells[92, 14 + j] = arr2[j, 23];
                mWSheet1.Cells[93, 14 + j] = arr2[j, 24];
                mWSheet1.Cells[94, 14 + j] = arr2[j, 25];
                mWSheet1.Cells[95, 14 + j] = arr2[j, 26];
              
               

            }

            //input data
            for (int j = 0; j < gv2.Rows.Count; j++)
            {

                // input 

                mWSheet1.Cells[7, 14 + j] = arr1[j, 0];
                mWSheet1.Cells[8, 14 + j] = arr1[j, 1];
                mWSheet1.Cells[9, 14 + j] = arr1[j, 2];
                mWSheet1.Cells[10, 14 + j] = arr1[j, 3];
                mWSheet1.Cells[11, 14 + j] = arr1[j, 4];
                mWSheet1.Cells[12, 14 + j] = arr1[j, 5];
                mWSheet1.Cells[13, 14 + j] = arr1[j, 6];
                mWSheet1.Cells[14, 14 + j] = arr1[j, 7];
                mWSheet1.Cells[15, 14 + j] = arr1[j, 8];
                mWSheet1.Cells[16, 14 + j] = arr1[j, 9];
                mWSheet1.Cells[17, 14 + j] = arr1[j, 10];
                mWSheet1.Cells[18, 14 + j] = arr1[j, 11];
                mWSheet1.Cells[19, 14 + j] = arr1[j, 12];
                mWSheet1.Cells[20, 14 + j] = arr1[j, 13];
                mWSheet1.Cells[21, 14 + j] = arr1[j, 14];
                mWSheet1.Cells[22, 14 + j] = arr1[j, 15];
                mWSheet1.Cells[23, 14 + j] = arr1[j, 16];
                mWSheet1.Cells[24, 14 + j] = arr1[j, 17];
                mWSheet1.Cells[25, 14 + j] = arr1[j, 18];
                mWSheet1.Cells[26, 14 + j] = arr1[j, 19];
                mWSheet1.Cells[27, 14 + j] = arr1[j, 20];
                mWSheet1.Cells[28, 14 + j] = arr1[j, 21];
                mWSheet1.Cells[29, 14 + j] = arr1[j, 22];
                mWSheet1.Cells[30, 14 + j] = arr1[j, 23];
                mWSheet1.Cells[31, 14 + j] = arr1[j, 24];
                mWSheet1.Cells[32, 14 + j] = arr1[j, 25];
                mWSheet1.Cells[33, 14 + j] = arr1[j, 26];
                mWSheet1.Cells[34, 14 + j] = arr1[j, 27];
                mWSheet1.Cells[35, 14 + j] = arr1[j, 28];
                mWSheet1.Cells[36, 14 + j] = arr1[j, 29];
                mWSheet1.Cells[37, 14 + j] = arr1[j, 30];
                mWSheet1.Cells[38, 14 + j] = arr1[j, 31];
                mWSheet1.Cells[39, 14 + j] = arr1[j, 32];
                

            }

            //project details
            mWSheet1.Cells[1, 30] = TextBox40.Text;
            mWSheet1.Cells[1, 3] = TextBox43.Text;
            mWSheet1.Cells[4, 16] = ddllocation.SelectedItem.Value.ToString();//DELIVERY CENTRE

            mWSheet1.Cells[3, 3] = TextBox57.Text;
            mWSheet1.Cells[3, 11] = TextBox41.Text;
            mWSheet1.Cells[2, 3] = date_input;

            mWSheet1.Cells[4, 22] = ddldiscipline.SelectedItem.Value.ToString();
            mWSheet1.Cells[4, 11] = ddlbusinessunit.SelectedItem.Value.ToString(); //buisness unit
            mWSheet1.Cells[2, 11] = TextBox42.Text;

            mWSheet1.Cells[2, 29] = txt_subj.Text;
            mWSheet1.Cells[3, 29] = txt_docno.Text;
            mWSheet1.Cells[4, 29] = txt_revno.Text;

            mWSheet1.Cells[2, 3] = date_input;

            mWSheet1.Cells[96, 14] = txtdia_opt.Text;


            oXL.Visible = false;
            mWorkBook.Save();
            mWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdf + ".pdf");

            mWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            mWSheet1 = null;
            mWorkBook = null;

            oXL.Quit();
            mWSheet1 = null;
            mWorkBook = null;
            oXL = null;
            GC.GetTotalMemory(false);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.GetTotalMemory(true);
            save(pdf + ".pdf");

        }

        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".csv":
                case ".xlsx":
                    return "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        public void save(string filepath)
        {
            try
            {
                // Create New instance of FileInfo class to get the properties of the file being downloaded
                FileInfo myfile = new FileInfo(filepath);

                // Checking if file exists
                if (myfile.Exists)
                {
                    // Clear the content of the response
                    Response.ClearContent();

                    // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                    // Add the file size into the response header
                    Response.AddHeader("Content-Length", myfile.Length.ToString());

                    // Set the ContentType
                    Response.ContentType = ReturnExtension(myfile.Extension.ToLower());
                    //  Response.AppendHeader("content-disposition", "attachment; filename=myfile.xlsx");
                    // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                    Response.TransmitFile(myfile.FullName);

                    // End the response
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
            }

        }

        public void msgalert(string a)
        {
            string message = a.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(message);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }


        // optimum dia calculation



        public double z, z1, z2, z3, d1, d2;
        public Int32 j;

        protected void btn_optdia_Click(object sender, EventArgs e)
        {
            btn_detresult.Enabled = true;
            btn_optdia.Enabled = false;

            grid_cell_extract();
            grid_cell_extract1();
            grid_cell_extract2();
            string[,] arr = (string[,])Session["arr"];
            string[,] arr1 = (string[,])Session["arr1"];
            string[,] arr2 = (string[,])Session["arr2"];

            if (gv1.Rows.Count == 1)
            {
                txtdia_opt.Text = arr[j, 0];
            }
            else
            {
           // as we need to compare total net present value which lies at 27 rd number in stage2 output so array2 will be from 0 to 22

                j = 1;
                TextBox54.Text = arr2[j, 26];
                TextBox55.Text = arr[j, 0];

                do
                {
                    z = Convert.ToDouble(arr2[j, 26]);
                    d1 = Convert.ToDouble(arr[j, 0]);
                    z1 = Convert.ToDouble(arr2[j - 1, 26]);
                    d2 = Convert.ToDouble(arr[j - 1, 0]);
                    TextBox50.Text = arr2[j, 26];
                    TextBox52.Text = arr2[j - 1, 26];
                    TextBox51.Text = arr[j, 0];
                    TextBox53.Text = arr[j - 1, 0];
                    z2 = Math.Min(z, z1);
                    z3 = Convert.ToDouble(TextBox54.Text);
                    if (z2 > Convert.ToDouble(TextBox54.Text))
                    {

                        txtdia_opt.Text = TextBox55.Text;

                    }
                    else
                    {
                        if (z <= z1)
                        {
                            txtdia_opt.Text = Convert.ToString(d1);
                            TextBox54.Text = Convert.ToString(z);
                            TextBox55.Text = Convert.ToString(d1);
                        }
                        else if (z > z1)
                        {
                            txtdia_opt.Text = Convert.ToString(d2);
                            TextBox54.Text = Convert.ToString(z1);
                            TextBox55.Text = Convert.ToString(d2);
                        }
                    }

                    j++;
                }
                while (j < gv1.Rows.Count);
            }
        }

        protected void btn_peakfac1_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}