using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace Water_wastewater
{
    public partial class IDF_Bell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static int noyr;



        double[] year = new double[noyr];
        double[] annrainfall = new double[noyr];
        double[] rainyday = new double[noyr];
        double[] max24hrrain = new double[noyr];
        double[] max24hrrainstd = new double[noyr];
        public double summax24hrrain=0;
        public double avgmax24hrrain;
        public double sumrainydays=0;
        public double avgrainydays;
        static public double P3060;
        public double returnperiod;
        public double tyrreturn;
        public double intensity;
        public double initialyr;
        double[] s5 = new double[6];
        double[] s10 = new double[6];
        double[] s15 = new double[6];
        double[] s30 = new double[6];
        double[] s45 = new double[6];
        double[] s60 = new double[6];
        double[] s90 = new double[6];
        double[] s120 = new double[6];
        double[] s150 = new double[6];
        double[] s180 = new double[6];
        double[] RP = new double[6];
        double[] MaxhrR = new double[6];
        double[] HrR = new double[6];
        double[] s5a = new double[6];
        double[] s10a = new double[6];
        double[] s15a = new double[6];
        double[] s30a = new double[6];
        double[] s45a = new double[6];
        double[] s60a = new double[6];
        double[] s90a = new double[6];
        double[] s120a = new double[6];
        double[] s150a = new double[6];
        double[] s180a = new double[6];
        


        protected void DDL_noofyears_SelectedIndexChanged(object sender, EventArgs e)
        {
            noyr = int.Parse(DDL_noofyears.SelectedValue);
            if (noyr == 10)
            {
                txt_year11.Visible = false;
                txt_ar11.Visible = false;
                txt_rd11.Visible = false;
                txt_maxrain11.Visible = false;
                txt_year12.Visible = false;
                txt_ar12.Visible = false;
                txt_rd12.Visible = false;
                txt_maxrain12.Visible = false;
                
                txt_year13.Visible = false;
                txt_ar13.Visible = false;
                txt_rd13.Visible = false;
                txt_maxrain13.Visible = false;
                
                txt_year14.Visible = false;
                txt_ar14.Visible = false;
                txt_rd14.Visible = false;
                txt_maxrain14.Visible = false;
                
                txt_year15.Visible = false;
                txt_ar15.Visible = false;
                txt_rd15.Visible = false;
                txt_maxrain15.Visible = false;
                
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
              
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
               
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
               
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
              
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
              
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
              
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
               
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
              
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
               
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
             
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
               
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
             
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
               
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
             

            }
            else if (noyr == 11)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
              
                txt_year12.Visible = false;
                txt_ar12.Visible = false;
                txt_rd12.Visible = false;
                txt_maxrain12.Visible = false;
          
                txt_year13.Visible = false;
                txt_ar13.Visible = false;
                txt_rd13.Visible = false;
                txt_maxrain13.Visible = false;
             
                txt_year14.Visible = false;
                txt_ar14.Visible = false;
                txt_rd14.Visible = false;
                txt_maxrain14.Visible = false;
            
                txt_year15.Visible = false;
                txt_ar15.Visible = false;
                txt_rd15.Visible = false;
                txt_maxrain15.Visible = false;
              
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
          
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
             
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
           
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
       
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;

                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
              
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
              
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
            
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
               
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
              
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
              
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
           
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
              

            }
            else if (noyr == 12)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
            
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
               
                txt_year13.Visible = false;
                txt_ar13.Visible = false;
                txt_rd13.Visible = false;
                txt_maxrain13.Visible = false;
               
                txt_year14.Visible = false;
                txt_ar14.Visible = false;
                txt_rd14.Visible = false;
                txt_maxrain14.Visible = false;
              
                txt_year15.Visible = false;
                txt_ar15.Visible = false;
                txt_rd15.Visible = false;
                txt_maxrain15.Visible = false;
         
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
             
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
             
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
               
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
               
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
               
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
              
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
               
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
               
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
               
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
            
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
          
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
                
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
              
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
              

            }
            else if (noyr == 13)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
             
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
            
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
             
                txt_year14.Visible = false;
                txt_ar14.Visible = false;
                txt_rd14.Visible = false;
                txt_maxrain14.Visible = false;
              
                txt_year15.Visible = false;
                txt_ar15.Visible = false;
                txt_rd15.Visible = false;
                txt_maxrain15.Visible = false;
              
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
               
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
              
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
               
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
               
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
                
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
               
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
               
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
              
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
               
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
               
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
            
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
              
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
     
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
          

            }
            else if (noyr == 14)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
                
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
                
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = false;
                txt_ar15.Visible = false;
                txt_rd15.Visible = false;
                txt_maxrain15.Visible = false;
          
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
             
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
            
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
            
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
           
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
               
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
              
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
             
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
            
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
            
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
             
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
              
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
              
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
               
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
             
            }
            else if (noyr == 15)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
              
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
              
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
               
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
           
                txt_year16.Visible = false;
                txt_ar16.Visible = false;
                txt_rd16.Visible = false;
                txt_maxrain16.Visible = false;
             
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
             
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
           
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
             
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
           
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
            
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
             
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
           
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
             
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
             
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
              
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
          
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
           
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
         
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
           
            }
            else if (noyr == 16)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
        
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
      
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
             
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
               
                txt_year17.Visible = false;
                txt_ar17.Visible = false;
                txt_rd17.Visible = false;
                txt_maxrain17.Visible = false;
           
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
             
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
       
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
         
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
         
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
           
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
            
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
           
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
              
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
           
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
             
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
            
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
            
            }
            else if (noyr == 17)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
              
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
           
        
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
            
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
            
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
           
                txt_year18.Visible = false;
                txt_ar18.Visible = false;
                txt_rd18.Visible = false;
                txt_maxrain18.Visible = false;
             
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
           
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
          
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
              
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
            
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
               
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
     
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
          
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
         
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
          
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
      
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
            
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
           
            }
            else if (noyr == 18)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
 
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
     
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
          
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
          
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
            
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
             
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
              
                txt_year19.Visible = false;
                txt_ar19.Visible = false;
                txt_rd19.Visible = false;
                txt_maxrain19.Visible = false;
            
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
               
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
                
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
              
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
             
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
             
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
               
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
             
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
            
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
             
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
             
            }
            else if (noyr == 19)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
           
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
            
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
             
         
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
              
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
           
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
            
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
            
                txt_year20.Visible = false;
                txt_ar20.Visible = false;
                txt_rd20.Visible = false;
                txt_maxrain20.Visible = false;
             
                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
            
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
          
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
            
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
           
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
           
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
          
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;

                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
     
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
          
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
      
            }
            else if (noyr == 20)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
            
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
              
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
            
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
              
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
          
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
            
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
        
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;

                txt_year21.Visible = false;
                txt_ar21.Visible = false;
                txt_rd21.Visible = false;
                txt_maxrain21.Visible = false;
          
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
            
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
             
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
          
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
               
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
       
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
           
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
              
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
               
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
            
            }
            else if (noyr == 21)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
              
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
               
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
             
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
             
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
          
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
             
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
             
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
             
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
            
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
            
                txt_year22.Visible = false;
                txt_ar22.Visible = false;
                txt_rd22.Visible = false;
                txt_maxrain22.Visible = false;
          
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
           
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
          
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
            
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
          
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
     
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
       
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
   
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
          
            }
            else if (noyr == 22)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
       
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
            
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
           
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
              
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
            
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
            
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
            
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
             
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
             
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
             
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
              
                txt_year23.Visible = false;
                txt_ar23.Visible = false;
                txt_rd23.Visible = false;
                txt_maxrain23.Visible = false;
            
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
           
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
                
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
               
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
              
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
               
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
              
            }
            else if (noyr == 23)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
               
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
              
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
              
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
               
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
               
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
                
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
             
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
             
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
          
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
               
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
             
                txt_year24.Visible = false;
                txt_ar24.Visible = false;
                txt_rd24.Visible = false;
                txt_maxrain24.Visible = false;
             
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
             
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
              
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
            
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
             
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
              
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
            
            }
            else if (noyr == 24)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
            
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
             
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
              
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
             
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
              
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
               
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
            
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
              
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
               
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
             
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
             
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
             
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
              
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
            
                txt_year25.Visible = false;
                txt_ar25.Visible = false;
                txt_rd25.Visible = false;
                txt_maxrain25.Visible = false;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
           
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
              
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
             
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
               
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
         
               
            }
            else if (noyr == 25)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
              
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
               
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
            
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
         
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
                
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
               
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
            
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
             
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
             
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
              
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
              
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
               
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
              
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
              
                txt_year26.Visible = false;
                txt_ar26.Visible = false;
                txt_rd26.Visible = false;
                txt_maxrain26.Visible = false;
             
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
               
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
             
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
            
            }
            else if (noyr == 26)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
                
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
             
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
            
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
              
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
             
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
              
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
               
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
            
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
               
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
              
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
             
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
               
                txt_year26.Visible = true;
                txt_ar26.Visible = true;
                txt_rd26.Visible = true;
                txt_maxrain26.Visible = true;
             
                txt_year27.Visible = false;
                txt_ar27.Visible = false;
                txt_rd27.Visible = false;
                txt_maxrain27.Visible = false;
            
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
           
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
             
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
             
            }
            else if (noyr == 27)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
             
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
            
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
            
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
              
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
              
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
               
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
             
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
              
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
                
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
             
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
               
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
              
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
               
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
               
                txt_year26.Visible = true;
                txt_ar26.Visible = true;
                txt_rd26.Visible = true;
                txt_maxrain26.Visible = true;
               
                txt_year27.Visible = true;
                txt_ar27.Visible = true;
                txt_rd27.Visible = true;
                txt_maxrain27.Visible = true;
               
                txt_year28.Visible = false;
                txt_ar28.Visible = false;
                txt_rd28.Visible = false;
                txt_maxrain28.Visible = false;
            
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
             
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
               
            }
            else if (noyr == 28)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
              
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
               
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
             
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
               
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
              
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
             
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
               
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
               
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
            
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
            
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
             
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
               
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
             
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
               
                txt_year26.Visible = true;
                txt_ar26.Visible = true;
                txt_rd26.Visible = true;
                txt_maxrain26.Visible = true;
               
                txt_year27.Visible = true;
                txt_ar27.Visible = true;
                txt_rd27.Visible = true;
                txt_maxrain27.Visible = true;
                
                txt_year28.Visible = true;
                txt_ar28.Visible = true;
                txt_rd28.Visible = true;
                txt_maxrain28.Visible = true;
               
                txt_year29.Visible = false;
                txt_ar29.Visible = false;
                txt_rd29.Visible = false;
                txt_maxrain29.Visible = false;
            
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
                
            }
            else if (noyr == 29)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
               
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
              
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
               
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
               
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
               
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
              
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
               
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
              
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
              
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
              
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
               
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
              
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
               
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
              
                txt_year26.Visible = true;
                txt_ar26.Visible = true;
                txt_rd26.Visible = true;
                txt_maxrain26.Visible = true;
              
                txt_year27.Visible = true;
                txt_ar27.Visible = true;
                txt_rd27.Visible = true;
                txt_maxrain27.Visible = true;
              
                txt_year28.Visible = true;
                txt_ar28.Visible = true;
                txt_rd28.Visible = true;
                txt_maxrain28.Visible = true;
                
                txt_year29.Visible = true;
                txt_ar29.Visible = true;
                txt_rd29.Visible = true;
                txt_maxrain29.Visible = true;
           
                txt_year30.Visible = false;
                txt_ar30.Visible = false;
                txt_rd30.Visible = false;
                txt_maxrain30.Visible = false;
            
            }
            else if (noyr == 30)
            {
                txt_year11.Visible = true;
                txt_ar11.Visible = true;
                txt_rd11.Visible = true;
                txt_maxrain11.Visible = true;
               
                txt_year12.Visible = true;
                txt_ar12.Visible = true;
                txt_rd12.Visible = true;
                txt_maxrain12.Visible = true;
            
                txt_year13.Visible = true;
                txt_ar13.Visible = true;
                txt_rd13.Visible = true;
                txt_maxrain13.Visible = true;
               
                txt_year14.Visible = true;
                txt_ar14.Visible = true;
                txt_rd14.Visible = true;
                txt_maxrain14.Visible = true;
              
                txt_year15.Visible = true;
                txt_ar15.Visible = true;
                txt_rd15.Visible = true;
                txt_maxrain15.Visible = true;
            
                txt_year16.Visible = true;
                txt_ar16.Visible = true;
                txt_rd16.Visible = true;
                txt_maxrain16.Visible = true;
              
                txt_year17.Visible = true;
                txt_ar17.Visible = true;
                txt_rd17.Visible = true;
                txt_maxrain17.Visible = true;
             
                txt_year18.Visible = true;
                txt_ar18.Visible = true;
                txt_rd18.Visible = true;
                txt_maxrain18.Visible = true;
            
                txt_year19.Visible = true;
                txt_ar19.Visible = true;
                txt_rd19.Visible = true;
                txt_maxrain19.Visible = true;
             
                txt_year20.Visible = true;
                txt_ar20.Visible = true;
                txt_rd20.Visible = true;
                txt_maxrain20.Visible = true;
            
                txt_year21.Visible = true;
                txt_ar21.Visible = true;
                txt_rd21.Visible = true;
                txt_maxrain21.Visible = true;
              
                txt_year22.Visible = true;
                txt_ar22.Visible = true;
                txt_rd22.Visible = true;
                txt_maxrain22.Visible = true;
            
                txt_year23.Visible = true;
                txt_ar23.Visible = true;
                txt_rd23.Visible = true;
                txt_maxrain23.Visible = true;
               
                txt_year24.Visible = true;
                txt_ar24.Visible = true;
                txt_rd24.Visible = true;
                txt_maxrain24.Visible = true;
            
                txt_year25.Visible = true;
                txt_ar25.Visible = true;
                txt_rd25.Visible = true;
                txt_maxrain25.Visible = true;
              
                txt_year26.Visible = true;
                txt_ar26.Visible = true;
                txt_rd26.Visible = true;
                txt_maxrain26.Visible = true;
               
                txt_year27.Visible = true;
                txt_ar27.Visible = true;
                txt_rd27.Visible = true;
                txt_maxrain27.Visible = true;
                
                txt_year28.Visible = true;
                txt_ar28.Visible = true;
                txt_rd28.Visible = true;
                txt_maxrain28.Visible = true;
             
                txt_year29.Visible = true;
                txt_ar29.Visible = true;
                txt_rd29.Visible = true;
                txt_maxrain29.Visible = true;
               
                txt_year30.Visible = true;
                txt_ar30.Visible = true;
                txt_rd30.Visible = true;
                txt_maxrain30.Visible = true;
               
            }
        }
        protected void txt_strtyr_TextChanged(object sender, EventArgs e)
        {
            initialyr = Convert.ToDouble(txt_strtyr.Text);
            for (int i = 0; i < noyr; i++)
            {
                year[i] = initialyr + i;
            }
            txt_year1.Text = year[0].ToString();
            txt_year2.Text = year[1].ToString();
            txt_year3.Text = year[2].ToString();
            txt_year4.Text = year[3].ToString();
            txt_year5.Text = year[4].ToString();
            txt_year6.Text = year[5].ToString();
            txt_year7.Text = year[6].ToString();
            txt_year8.Text = year[7].ToString();
            txt_year9.Text = year[8].ToString();
            txt_year10.Text = year[9].ToString();
            if (noyr > 10)
                txt_year11.Text = year[10].ToString();
            if (noyr > 11)
                txt_year12.Text = year[11].ToString();
            if (noyr > 12)
                txt_year13.Text = year[12].ToString();
            if (noyr > 13)
                txt_year14.Text = year[13].ToString();
            if (noyr > 14)
                txt_year15.Text = year[14].ToString();
            if (noyr > 15)
                txt_year16.Text = year[15].ToString();
            if (noyr > 16)
                txt_year17.Text = year[16].ToString();
            if (noyr > 17)
                txt_year18.Text = year[17].ToString();
            if (noyr > 18)
                txt_year19.Text = year[18].ToString();
            if (noyr > 19)
                txt_year20.Text = year[19].ToString();
            if (noyr > 20)
                txt_year21.Text = year[20].ToString();
            if (noyr > 21)
                txt_year22.Text = year[21].ToString();
            if (noyr > 22)
                txt_year23.Text = year[22].ToString();
            if (noyr > 23)
                txt_year24.Text = year[23].ToString();
            if (noyr > 24)
                txt_year25.Text = year[24].ToString();
            if (noyr > 25)
                txt_year26.Text = year[25].ToString();
            if (noyr > 26)
                txt_year27.Text = year[26].ToString();
            if (noyr > 27)
                txt_year28.Text = year[27].ToString();
            if (noyr > 28)
                txt_year29.Text = year[28].ToString();
            if (noyr > 29)
                txt_year30.Text = year[29].ToString();

        }
        protected void inputdata()
        {
            // input data
            year[0] = Convert.ToDouble(txt_year1.Text);
            annrainfall[0] = Convert.ToDouble(txt_ar1.Text);
            rainyday[0] = Convert.ToDouble(txt_rd1.Text);
            max24hrrain[0] = Convert.ToDouble(txt_maxrain1.Text);
            year[1] = Convert.ToDouble(txt_year2.Text);
            annrainfall[1] = Convert.ToDouble(txt_ar2.Text);
            rainyday[1] = Convert.ToDouble(txt_rd2.Text);
            max24hrrain[1] = Convert.ToDouble(txt_maxrain2.Text);
            year[2] = Convert.ToDouble(txt_year3.Text);
            annrainfall[2] = Convert.ToDouble(txt_ar3.Text);
            rainyday[2] = Convert.ToDouble(txt_rd3.Text);
            max24hrrain[2] = Convert.ToDouble(txt_maxrain3.Text);
            year[3] = Convert.ToDouble(txt_year4.Text);
            annrainfall[3] = Convert.ToDouble(txt_ar4.Text);
            rainyday[3] = Convert.ToDouble(txt_rd4.Text);
            max24hrrain[3] = Convert.ToDouble(txt_maxrain4.Text);
            year[4] = Convert.ToDouble(txt_year5.Text);
            annrainfall[4] = Convert.ToDouble(txt_ar5.Text);
            rainyday[4] = Convert.ToDouble(txt_rd5.Text);
            max24hrrain[4] = Convert.ToDouble(txt_maxrain5.Text);
            year[5] = Convert.ToDouble(txt_year6.Text);
            annrainfall[5] = Convert.ToDouble(txt_ar6.Text);
            rainyday[5] = Convert.ToDouble(txt_rd6.Text);
            max24hrrain[5] = Convert.ToDouble(txt_maxrain6.Text);
            year[6] = Convert.ToDouble(txt_year7.Text);
            annrainfall[6] = Convert.ToDouble(txt_ar7.Text);
            rainyday[6] = Convert.ToDouble(txt_rd7.Text);
            max24hrrain[6] = Convert.ToDouble(txt_maxrain7.Text);
            year[7] = Convert.ToDouble(txt_year8.Text);
            annrainfall[7] = Convert.ToDouble(txt_ar8.Text);
            rainyday[7] = Convert.ToDouble(txt_rd8.Text);
            max24hrrain[7] = Convert.ToDouble(txt_maxrain8.Text);
            year[8] = Convert.ToDouble(txt_year9.Text);
            annrainfall[8] = Convert.ToDouble(txt_ar9.Text);
            rainyday[8] = Convert.ToDouble(txt_rd9.Text);
            max24hrrain[8] = Convert.ToDouble(txt_maxrain9.Text);
            if (noyr >= 10)
            {
                year[9] = Convert.ToDouble(txt_year10.Text);
                annrainfall[9] = Convert.ToDouble(txt_ar10.Text);
                rainyday[9] = Convert.ToDouble(txt_rd10.Text);
                max24hrrain[9] = Convert.ToDouble(txt_maxrain10.Text);
            }
            if (noyr > 10)
            {
                year[10] = Convert.ToDouble(txt_year11.Text);
                annrainfall[10] = Convert.ToDouble(txt_ar11.Text);
                rainyday[10] = Convert.ToDouble(txt_rd11.Text);
                max24hrrain[10] = Convert.ToDouble(txt_maxrain11.Text);
            }
            if (noyr > 11)
            {
                year[11] = Convert.ToDouble(txt_year12.Text);
                annrainfall[11] = Convert.ToDouble(txt_ar12.Text);
                rainyday[11] = Convert.ToDouble(txt_rd12.Text);
                max24hrrain[11] = Convert.ToDouble(txt_maxrain12.Text);
            }
            if (noyr > 12)
            {
                year[12] = Convert.ToDouble(txt_year13.Text);
                annrainfall[12] = Convert.ToDouble(txt_ar13.Text);
                rainyday[12] = Convert.ToDouble(txt_rd13.Text);
                max24hrrain[12] = Convert.ToDouble(txt_maxrain13.Text);
            }
            if (noyr > 13)
            {
                year[13] = Convert.ToDouble(txt_year14.Text);
                annrainfall[13] = Convert.ToDouble(txt_ar14.Text);
                rainyday[13] = Convert.ToDouble(txt_rd14.Text);
                max24hrrain[13] = Convert.ToDouble(txt_maxrain14.Text);
            }
            if (noyr > 14)
            {
                year[14] = Convert.ToDouble(txt_year15.Text);
                annrainfall[14] = Convert.ToDouble(txt_ar15.Text);
                rainyday[14] = Convert.ToDouble(txt_rd15.Text);
                max24hrrain[14] = Convert.ToDouble(txt_maxrain15.Text);
            }
            if (noyr > 15)
            {
                year[15] = Convert.ToDouble(txt_year16.Text);
                annrainfall[15] = Convert.ToDouble(txt_ar16.Text);
                rainyday[15] = Convert.ToDouble(txt_rd16.Text);
                max24hrrain[15] = Convert.ToDouble(txt_maxrain16.Text);
            }
            if (noyr > 16)
            {
                year[16] = Convert.ToDouble(txt_year17.Text);
                annrainfall[16] = Convert.ToDouble(txt_ar17.Text);
                rainyday[16] = Convert.ToDouble(txt_rd17.Text);
                max24hrrain[16] = Convert.ToDouble(txt_maxrain17.Text);
            }
            if (noyr > 17)
            {
                year[17] = Convert.ToDouble(txt_year18.Text);
                annrainfall[17] = Convert.ToDouble(txt_ar18.Text);
                rainyday[17] = Convert.ToDouble(txt_rd18.Text);
                max24hrrain[17] = Convert.ToDouble(txt_maxrain18.Text);
            }
            if (noyr > 18)
            {
                year[18] = Convert.ToDouble(txt_year19.Text);
                annrainfall[18] = Convert.ToDouble(txt_ar19.Text);
                rainyday[18] = Convert.ToDouble(txt_rd19.Text);
                max24hrrain[18] = Convert.ToDouble(txt_maxrain19.Text);
            }
            if (noyr > 19)
            {
                year[19] = Convert.ToDouble(txt_year20.Text);
                annrainfall[19] = Convert.ToDouble(txt_ar20.Text);
                rainyday[19] = Convert.ToDouble(txt_rd20.Text);
                max24hrrain[19] = Convert.ToDouble(txt_maxrain20.Text);
            }
            if (noyr > 20)
            {
                year[20] = Convert.ToDouble(txt_year21.Text);
                annrainfall[20] = Convert.ToDouble(txt_ar21.Text);
                rainyday[20] = Convert.ToDouble(txt_rd21.Text);
                max24hrrain[20] = Convert.ToDouble(txt_maxrain21.Text);
            }
            if (noyr > 21)
            {
                year[21] = Convert.ToDouble(txt_year22.Text);
                annrainfall[21] = Convert.ToDouble(txt_ar22.Text);
                rainyday[21] = Convert.ToDouble(txt_rd22.Text);
                max24hrrain[21] = Convert.ToDouble(txt_maxrain22.Text);
            }
            if (noyr > 22)
            {
                year[22] = Convert.ToDouble(txt_year23.Text);
                annrainfall[22] = Convert.ToDouble(txt_ar23.Text);
                rainyday[22] = Convert.ToDouble(txt_rd23.Text);
                max24hrrain[22] = Convert.ToDouble(txt_maxrain23.Text);
            }
            if (noyr > 23)
            {
                year[23] = Convert.ToDouble(txt_year24.Text);
                annrainfall[23] = Convert.ToDouble(txt_ar24.Text);
                rainyday[23] = Convert.ToDouble(txt_rd24.Text);
                max24hrrain[23] = Convert.ToDouble(txt_maxrain24.Text);
            }
            if (noyr > 24)
            {
                year[24] = Convert.ToDouble(txt_year25.Text);
                annrainfall[24] = Convert.ToDouble(txt_ar25.Text);
                rainyday[24] = Convert.ToDouble(txt_rd25.Text);
                max24hrrain[24] = Convert.ToDouble(txt_maxrain25.Text);
            }
            if (noyr > 25)
            {
                year[25] = Convert.ToDouble(txt_year26.Text);
                annrainfall[25] = Convert.ToDouble(txt_ar26.Text);
                rainyday[25] = Convert.ToDouble(txt_rd26.Text);
                max24hrrain[25] = Convert.ToDouble(txt_maxrain26.Text);
            }
            if (noyr > 26)
            {
                year[26] = Convert.ToDouble(txt_year27.Text);
                annrainfall[26] = Convert.ToDouble(txt_ar27.Text);
                rainyday[26] = Convert.ToDouble(txt_rd27.Text);
                max24hrrain[26] = Convert.ToDouble(txt_maxrain27.Text);
            }
            if (noyr > 27)
            {
                year[27] = Convert.ToDouble(txt_year28.Text);
                annrainfall[27] = Convert.ToDouble(txt_ar28.Text);
                rainyday[27] = Convert.ToDouble(txt_rd28.Text);
                max24hrrain[27] = Convert.ToDouble(txt_maxrain28.Text);
            }
            if (noyr > 28)
            {
                year[28] = Convert.ToDouble(txt_year29.Text);
                annrainfall[28] = Convert.ToDouble(txt_ar29.Text);
                rainyday[28] = Convert.ToDouble(txt_rd29.Text);
                max24hrrain[28] = Convert.ToDouble(txt_maxrain19.Text);
            }
            if (noyr > 29)
            {
                year[29] = Convert.ToDouble(txt_year30.Text);
                annrainfall[29] = Convert.ToDouble(txt_ar30.Text);
                rainyday[29] = Convert.ToDouble(txt_rd30.Text);
                max24hrrain[29] = Convert.ToDouble(txt_maxrain30.Text);
            }
            
            
        }
       

        protected void excelprinting()
        {

            string xlfile_name = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond);
            string xltypenewpath = Server.MapPath("~//Temp//Output_IDFBell" + xlfile_name + ".xls");
            string pdfpath = Server.MapPath("~//Temp//Output_IDFBell" + xlfile_name);
            string xlpath = "";

            xlpath = Server.MapPath("~//Output_IDFBell.xls");
            File.Copy(xlpath, xltypenewpath);
            FileInfo file = new FileInfo(xltypenewpath);

            Microsoft.Office.Interop.Excel.Workbook mWorkBook;
            Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
            Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
            Microsoft.Office.Interop.Excel.Application oXL;


            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(xltypenewpath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            mWorkSheets = mWorkBook.Worksheets;
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet 1");



            mWSheet1.Cells[1, 2] = txt_ad.Text;
            mWSheet1.Cells[2, 2] = txt_dateinput.Text;
            mWSheet1.Cells[3, 2] = txt_bd.Text;
            mWSheet1.Cells[4, 2] = txt_datecheck.Text;
            mWSheet1.Cells[2, 5] = txt_clientname.Text;
            mWSheet1.Cells[3, 5] = txt_project.Text;
            mWSheet1.Cells[4, 5] = txt_jobno.Text;
            mWSheet1.Cells[4, 7] = txt_dc.Text;
            mWSheet1.Cells[4, 9] = txt_disc.Text;
            mWSheet1.Cells[1, 11] = txt_docno.Text;
            mWSheet1.Cells[2, 11] = txt_revno.Text;

            //INPUT//
            mWSheet1.Cells[9, 3] = txt_year1.Text;
            mWSheet1.Cells[9, 4] = txt_ar1.Text;
            mWSheet1.Cells[9, 5] = txt_rd1.Text;
            mWSheet1.Cells[9, 6] = txt_maxrain1.Text;
            mWSheet1.Cells[10, 3] = txt_year2.Text;
            mWSheet1.Cells[10, 4] = txt_ar2.Text;
            mWSheet1.Cells[10, 5] = txt_rd2.Text;
            mWSheet1.Cells[10, 6] = txt_maxrain2.Text;
            mWSheet1.Cells[11, 3] = txt_year3.Text;
            mWSheet1.Cells[11, 4] = txt_ar3.Text;
            mWSheet1.Cells[11, 5] = txt_rd3.Text;
            mWSheet1.Cells[11, 6] = txt_maxrain3.Text;
            mWSheet1.Cells[12, 3] = txt_year4.Text;
            mWSheet1.Cells[12, 4] = txt_ar4.Text;
            mWSheet1.Cells[12, 5] = txt_rd4.Text;
            mWSheet1.Cells[12, 6] = txt_maxrain4.Text;
            mWSheet1.Cells[13, 3] = txt_year5.Text;
            mWSheet1.Cells[13, 4] = txt_ar5.Text;
            mWSheet1.Cells[13, 5] = txt_rd5.Text;
            mWSheet1.Cells[13, 6] = txt_maxrain5.Text;
            mWSheet1.Cells[14, 3] = txt_year6.Text;
            mWSheet1.Cells[14, 4] = txt_ar6.Text;
            mWSheet1.Cells[14, 5] = txt_rd6.Text;
            mWSheet1.Cells[14, 6] = txt_maxrain6.Text;
            mWSheet1.Cells[15, 3] = txt_year7.Text;
            mWSheet1.Cells[15, 4] = txt_ar7.Text;
            mWSheet1.Cells[15, 5] = txt_rd7.Text;
            mWSheet1.Cells[15, 6] = txt_maxrain7.Text;
            mWSheet1.Cells[16, 3] = txt_year8.Text;
            mWSheet1.Cells[16, 4] = txt_ar8.Text;
            mWSheet1.Cells[16, 5] = txt_rd8.Text;
            mWSheet1.Cells[16, 6] = txt_maxrain8.Text;
            mWSheet1.Cells[17, 3] = txt_year9.Text;
            mWSheet1.Cells[17, 4] = txt_ar9.Text;
            mWSheet1.Cells[17, 5] = txt_rd9.Text;
            mWSheet1.Cells[17, 6] = txt_maxrain9.Text;
            mWSheet1.Cells[18, 3] = txt_year10.Text;
            mWSheet1.Cells[18, 4] = txt_ar10.Text;
            mWSheet1.Cells[18, 5] = txt_rd10.Text;
            mWSheet1.Cells[18, 6] = txt_maxrain10.Text;
            if (noyr > 10)
            {
                mWSheet1.Rows[19].hidden = false;
                mWSheet1.Cells[19, 3] = txt_year11.Text;
                mWSheet1.Cells[19, 4] = txt_ar11.Text;
                mWSheet1.Cells[19, 5] = txt_rd11.Text;
                mWSheet1.Cells[19, 6] = txt_maxrain11.Text;
            }
            if (noyr > 11)
            {
                mWSheet1.Rows[20].hidden = false;
                mWSheet1.Cells[20, 3] = txt_year12.Text;
                mWSheet1.Cells[20, 4] = txt_ar12.Text;
                mWSheet1.Cells[20, 5] = txt_rd12.Text;
                mWSheet1.Cells[20, 6] = txt_maxrain12.Text;
            }
            if (noyr > 12)
            {
                mWSheet1.Rows[21].hidden = false;
                mWSheet1.Cells[21, 3] = txt_year13.Text;
                mWSheet1.Cells[21, 4] = txt_ar13.Text;
                mWSheet1.Cells[21, 5] = txt_rd13.Text;
                mWSheet1.Cells[21, 6] = txt_maxrain13.Text;
            }
            if (noyr > 13)
            {
                mWSheet1.Rows[22].hidden = false;
                mWSheet1.Cells[22, 3] = txt_year14.Text;
                mWSheet1.Cells[22, 4] = txt_ar14.Text;
                mWSheet1.Cells[22, 5] = txt_rd14.Text;
                mWSheet1.Cells[22, 6] = txt_maxrain14.Text;
            }
            if (noyr > 14)
            {
                mWSheet1.Rows[23].hidden = false;
                mWSheet1.Cells[23, 3] = txt_year15.Text;
                mWSheet1.Cells[23, 4] = txt_ar15.Text;
                mWSheet1.Cells[23, 5] = txt_rd15.Text;
                mWSheet1.Cells[23, 6] = txt_maxrain15.Text;
            }
            if (noyr > 15)
            {
                mWSheet1.Rows[24].hidden = false;
                mWSheet1.Cells[24, 3] = txt_year16.Text;
                mWSheet1.Cells[24, 4] = txt_ar16.Text;
                mWSheet1.Cells[24, 5] = txt_rd16.Text;
                mWSheet1.Cells[24, 6] = txt_maxrain16.Text;
            }
            if (noyr > 16)
            {
                mWSheet1.Rows[25].hidden = false;
                mWSheet1.Cells[25, 3] = txt_year17.Text;
                mWSheet1.Cells[25, 4] = txt_ar17.Text;
                mWSheet1.Cells[25, 5] = txt_rd17.Text;
                mWSheet1.Cells[25, 6] = txt_maxrain17.Text;
            }
            if (noyr > 17)
            {
                mWSheet1.Rows[26].hidden = false;
                mWSheet1.Cells[26, 3] = txt_year18.Text;
                mWSheet1.Cells[26, 4] = txt_ar18.Text;
                mWSheet1.Cells[26, 5] = txt_rd18.Text;
                mWSheet1.Cells[26, 6] = txt_maxrain18.Text;
            }
            if (noyr > 18)
            {
                mWSheet1.Rows[27].hidden = false;
                mWSheet1.Cells[27, 3] = txt_year19.Text;
                mWSheet1.Cells[27, 4] = txt_ar19.Text;
                mWSheet1.Cells[27, 5] = txt_rd19.Text;
                mWSheet1.Cells[27, 6] = txt_maxrain19.Text;
            }
            if (noyr > 19)
            {
                mWSheet1.Rows[28].hidden = false;
                mWSheet1.Cells[28, 3] = txt_year20.Text;
                mWSheet1.Cells[28, 4] = txt_ar20.Text;
                mWSheet1.Cells[28, 5] = txt_rd20.Text;
                mWSheet1.Cells[28, 6] = txt_maxrain20.Text;
            }
            if (noyr > 20)
            {
                mWSheet1.Rows[29].hidden = false;
                mWSheet1.Cells[29, 3] = txt_year21.Text;
                mWSheet1.Cells[29, 4] = txt_ar21.Text;
                mWSheet1.Cells[29, 5] = txt_rd21.Text;
                mWSheet1.Cells[29, 6] = txt_maxrain21.Text;
            }
            if (noyr > 21)
            {
                mWSheet1.Rows[30].hidden = false;
                mWSheet1.Cells[30, 3] = txt_year22.Text;
                mWSheet1.Cells[30, 4] = txt_ar22.Text;
                mWSheet1.Cells[30, 5] = txt_rd22.Text;
                mWSheet1.Cells[30, 6] = txt_maxrain22.Text;
            }
            if (noyr > 22)
            {
                mWSheet1.Rows[31].hidden = false;
                mWSheet1.Cells[31, 3] = txt_year23.Text;
                mWSheet1.Cells[31, 4] = txt_ar23.Text;
                mWSheet1.Cells[31, 5] = txt_rd23.Text;
                mWSheet1.Cells[31, 6] = txt_maxrain23.Text;
            }
            if (noyr > 23)
            {
                mWSheet1.Rows[32].hidden = false;
                mWSheet1.Cells[32, 3] = txt_year24.Text;
                mWSheet1.Cells[32, 4] = txt_ar24.Text;
                mWSheet1.Cells[32, 5] = txt_rd24.Text;
                mWSheet1.Cells[32, 6] = txt_maxrain24.Text;
            }
            if (noyr > 24)
            {
                mWSheet1.Rows[33].hidden = false;
                mWSheet1.Cells[33, 3] = txt_year25.Text;
                mWSheet1.Cells[33, 4] = txt_ar25.Text;
                mWSheet1.Cells[33, 5] = txt_rd25.Text;
                mWSheet1.Cells[33, 6] = txt_maxrain25.Text;
            }
            if (noyr > 25)
            {
                mWSheet1.Rows[34].hidden = false;
                mWSheet1.Cells[34, 3] = txt_year26.Text;
                mWSheet1.Cells[34, 4] = txt_ar26.Text;
                mWSheet1.Cells[34, 5] = txt_rd26.Text;
                mWSheet1.Cells[34, 6] = txt_maxrain26.Text;
            }
            if (noyr > 26)
            {
                mWSheet1.Rows[35].hidden = false;
                mWSheet1.Cells[35, 3] = txt_year27.Text;
                mWSheet1.Cells[35, 4] = txt_ar27.Text;
                mWSheet1.Cells[35, 5] = txt_rd27.Text;
                mWSheet1.Cells[35, 6] = txt_maxrain27.Text;
            }
            if (noyr > 27)
            {
                mWSheet1.Rows[36].hidden = false;
                mWSheet1.Cells[36, 3] = txt_year28.Text;
                mWSheet1.Cells[36, 4] = txt_ar28.Text;
                mWSheet1.Cells[36, 5] = txt_rd28.Text;
                mWSheet1.Cells[36, 6] = txt_maxrain28.Text;
            }
            if (noyr > 28)
            {
                mWSheet1.Rows[37].hidden = false;
                mWSheet1.Cells[37, 3] = txt_year29.Text;
                mWSheet1.Cells[37, 4] = txt_ar29.Text;
                mWSheet1.Cells[37, 5] = txt_rd29.Text;
                mWSheet1.Cells[37, 6] = txt_maxrain29.Text;
            }
            if (noyr > 29)
            {
                mWSheet1.Rows[38].hidden = false;
                mWSheet1.Cells[38, 3] = txt_year30.Text;
                mWSheet1.Cells[38, 4] = txt_ar30.Text;
                mWSheet1.Cells[38, 5] = txt_rd30.Text;
                mWSheet1.Cells[38, 6] = txt_maxrain30.Text;
            }
            

            //OUTPUT//
            mWSheet1.Cells[47, 2] = L_5T9.Text;
            mWSheet1.Cells[48, 2] = L_5T10.Text;
            mWSheet1.Cells[49, 2] = L_5T11.Text;
            mWSheet1.Cells[50, 2] = L_5T13.Text;
            mWSheet1.Cells[51, 2] = L_5T14.Text;
            mWSheet1.Cells[52, 2] = L_5T15.Text;
            mWSheet1.Cells[47, 3] = L_10T9.Text;
            mWSheet1.Cells[48, 3] = L_10T10.Text;
            mWSheet1.Cells[49, 3] = L_10T11.Text;
            mWSheet1.Cells[50, 3] = L_10T13.Text;
            mWSheet1.Cells[51, 3] = L_10T14.Text;
            mWSheet1.Cells[52, 3] = L_10T15.Text;
            mWSheet1.Cells[47, 4] = L_15T9.Text;
            mWSheet1.Cells[48, 4] = L_15T10.Text;
            mWSheet1.Cells[49, 4] = L_15T11.Text;
            mWSheet1.Cells[50, 4] = L_15T13.Text;
            mWSheet1.Cells[51, 4] = L_15T14.Text;
            mWSheet1.Cells[52, 4] = L_15T15.Text;
            mWSheet1.Cells[47, 5] = L_30T9.Text;
            mWSheet1.Cells[48, 5] = L_30T10.Text;
            mWSheet1.Cells[49, 5] = L_30T11.Text;
            mWSheet1.Cells[50, 5] = L_30T13.Text;
            mWSheet1.Cells[51, 5] = L_30T14.Text;
            mWSheet1.Cells[52, 5] = L_30T15.Text;
            mWSheet1.Cells[47, 6] = L_45T9.Text;
            mWSheet1.Cells[48, 6] = L_45T10.Text;
            mWSheet1.Cells[49, 6] = L_45T11.Text;
            mWSheet1.Cells[50, 6] = L_45T13.Text;
            mWSheet1.Cells[51, 6] = L_45T14.Text;
            mWSheet1.Cells[52, 6] = L_45T15.Text;
            mWSheet1.Cells[47, 7] = L_60T9.Text;
            mWSheet1.Cells[48, 7] = L_60T10.Text;
            mWSheet1.Cells[49, 7] = L_60T11.Text;
            mWSheet1.Cells[50, 7] = L_60T13.Text;
            mWSheet1.Cells[51, 7] = L_60T14.Text;
            mWSheet1.Cells[52, 7] = L_60T15.Text;
            mWSheet1.Cells[47, 8] = L_90T9.Text;
            mWSheet1.Cells[48, 8] = L_90T10.Text;
            mWSheet1.Cells[49, 8] = L_90T11.Text;
            mWSheet1.Cells[50, 8] = L_90T13.Text;
            mWSheet1.Cells[51, 8] = L_90T14.Text;
            mWSheet1.Cells[52, 8] = L_90T15.Text;
            mWSheet1.Cells[47, 9] = L_120T9.Text;
            mWSheet1.Cells[48, 9] = L_120T10.Text;
            mWSheet1.Cells[49, 9] = L_120T11.Text;
            mWSheet1.Cells[50, 9] = L_120T13.Text;
            mWSheet1.Cells[51, 9] = L_120T14.Text;
            mWSheet1.Cells[52, 9] = L_120T15.Text;
            mWSheet1.Cells[47, 10] = L_150T9.Text;
            mWSheet1.Cells[48, 10] = L_150T10.Text;
            mWSheet1.Cells[49, 10] = L_150T11.Text;
            mWSheet1.Cells[50, 10] = L_150T13.Text;
            mWSheet1.Cells[51, 10] = L_150T14.Text;
            mWSheet1.Cells[52, 10] = L_150T15.Text;
            mWSheet1.Cells[47, 11] = L_180T9.Text;
            mWSheet1.Cells[48,11] = L_180T10.Text;
            mWSheet1.Cells[49, 11] = L_180T11.Text;
            mWSheet1.Cells[50, 11] = L_180T13.Text;
            mWSheet1.Cells[51, 11] = L_180T14.Text;
            mWSheet1.Cells[52, 11] = L_180T15.Text;




            mWorkBook.Save();
            mWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfpath + ".pdf");
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

            save(pdfpath + ".pdf");
            //Session["xltypenewpath"] = pdfpath.ToString() + ".pdf";               



        }
        private string ReturnExtension1(string fileExtension)
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
                Response.ContentType = ReturnExtension1(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                Response.End();
            }

        }

        protected void Button_output2_Click(object sender, EventArgs e)
        {
            try
            {

                string date1 = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
                string mysql = "Insert into User_feedback(Empl_ID,Name,Usefulness,user_freindly,effort_reduction,MH,suggestion,application,fbdate)values(0 ,'" + "" + "','" + useful.SelectedItem.Text + "','" + friendly.SelectedItem.Text + "','" + mhsave.SelectedItem.Text + "','" + txt_mh.Text + "','" + txt_fb.Text + "','" + "IDF_bell" + "','" + date1.ToString() + "'" + ")";
                var survey = new common();
                survey.user_survey(mysql);
                excelprinting();
                save(Session["xltypenewpath"].ToString());
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
            }
        }


        protected void Button_Next0_Click(object sender, EventArgs e)
        {
            try
            {

                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                pan_fb.Visible = false;

                inputdata();
                for (int i = 0; i < noyr; i++)
                {
                    summax24hrrain = summax24hrrain + max24hrrain[i];
                    sumrainydays = sumrainydays + rainyday[i];

                }
                avgmax24hrrain = summax24hrrain / noyr;
                avgrainydays = sumrainydays / noyr;
                L_meanannrainfall.Text = Math.Round(avgmax24hrrain, 1).ToString();
                L_meanrainydays.Text = Math.Round(avgrainydays, 1).ToString();
                if (avgmax24hrrain > 0 && avgmax24hrrain < 50)
                {
                    P3060 = 0.27 * avgmax24hrrain * (Math.Pow(avgrainydays, 0.33));
                }
                else if (avgmax24hrrain >= 50 && avgmax24hrrain < 115)
                {
                    P3060 = 0.97 * (Math.Pow(avgmax24hrrain, 0.67)) * (Math.Pow(avgrainydays, 0.33));
                }
                else
                {
                    Label2067.Visible = true;

                }

                L_P3060.Text = Math.Round(P3060, 1).ToString();
                L_P3060a.Text = Math.Round(P3060, 1).ToString();
                s5[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[0] = 0.924998663 * P3060;
                s180[0] = (0.21 * 0.69314718 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                s5[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[1] = 1.192426055 * P3060;
                s180[1] = (0.21 * 1.609437912 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                s5[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[2] = 1.394724067 * P3060;
                s180[2] = (0.21 * 2.302585093 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                s5[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[3] = 1.662154459 * P3060;
                s180[3] = (0.21 * 3.218875825 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                s5[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[4] = 1.864455471 * P3060;
                s180[4] = (0.21 * 3.912023005 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                s5[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 1.495348781) - 0.5) * P3060;
                s10[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 1.77827941) - 0.5) * P3060;
                s15[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 1.967989671) - 0.5) * P3060;
                s30[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 2.340347319) - 0.5) * P3060;
                s45[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 2.590020064) - 0.5) * P3060;
                s60[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 2.783157684) - 0.5) * P3060;
                s90[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 3.080070288) - 0.5) * P3060;
                s120[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 3.30975092) - 0.5) * P3060;
                s150[5] = 2.066756483 * P3060;
                s180[5] = (0.21 * 4.605170186 + 0.52) * ((0.54 * 3.662841501) - 0.5) * P3060;

                for (int i = 0; i < 6; i++)
                {
                    s5a[i] = s5[i] / 0.08333333333;
                    s10a[i] = s10[i] / 0.166666666;
                    s15a[i] = s15[i] / 0.25;
                    s30a[i] = s30[i] / 0.5;
                    s45a[i] = s45[i] / 0.75;
                    s60a[i] = s60[i];
                    s90a[i] = s90[i] / 1.5;
                    s120a[i] = s120[i] / 2;
                    s150a[i] = s150[i] / 2.5;
                    s180a[i] = s180[i] / 3;
                }
                L_5T1.Text = Math.Round(s5[0], 1).ToString();
                L_10T1.Text = Math.Round(s10[0], 1).ToString();
                L_15T1.Text = Math.Round(s15[0], 1).ToString();
                L_30T1.Text = Math.Round(s30[0], 1).ToString();
                L_45T1.Text = Math.Round(s45[0], 1).ToString();
                L_60T1.Text = Math.Round(s60[0], 1).ToString();
                L_90T1.Text = Math.Round(s90[0], 1).ToString();
                L_120T1.Text = Math.Round(s120[0], 1).ToString();
                L_150T1.Text = Math.Round(s150[0], 1).ToString();
                L_180T1.Text = Math.Round(s180[0], 1).ToString();

                L_5T2.Text = Math.Round(s5[1], 1).ToString();
                L_10T2.Text = Math.Round(s10[1], 1).ToString();
                L_15T2.Text = Math.Round(s15[1], 1).ToString();
                L_30T2.Text = Math.Round(s30[1], 1).ToString();
                L_45T2.Text = Math.Round(s45[1], 1).ToString();
                L_60T2.Text = Math.Round(s60[1], 1).ToString();
                L_90T2.Text = Math.Round(s90[1], 1).ToString();
                L_120T2.Text = Math.Round(s120[1], 1).ToString();
                L_150T2.Text = Math.Round(s150[1], 1).ToString();
                L_180T2.Text = Math.Round(s180[1], 1).ToString();

                L_5T3.Text = Math.Round(s5[2], 1).ToString();
                L_10T3.Text = Math.Round(s10[2], 1).ToString();
                L_15T3.Text = Math.Round(s15[2], 1).ToString();
                L_30T3.Text = Math.Round(s30[2], 1).ToString();
                L_45T3.Text = Math.Round(s45[2], 1).ToString();
                L_60T3.Text = Math.Round(s60[2], 1).ToString();
                L_90T3.Text = Math.Round(s90[2], 1).ToString();
                L_120T3.Text = Math.Round(s120[2], 1).ToString();
                L_150T3.Text = Math.Round(s150[2], 1).ToString();
                L_180T3.Text = Math.Round(s180[2], 1).ToString();

                L_5T5.Text = Math.Round(s5[3], 1).ToString();
                L_10T5.Text = Math.Round(s10[3], 1).ToString();
                L_15T5.Text = Math.Round(s15[3], 1).ToString();
                L_30T5.Text = Math.Round(s30[3], 1).ToString();
                L_45T5.Text = Math.Round(s45[3], 1).ToString();
                L_60T5.Text = Math.Round(s60[3], 1).ToString();
                L_90T5.Text = Math.Round(s90[3], 1).ToString();
                L_120T5.Text = Math.Round(s120[3], 1).ToString();
                L_150T5.Text = Math.Round(s150[3], 1).ToString();
                L_180T5.Text = Math.Round(s180[3], 1).ToString();

                L_5T6.Text = Math.Round(s5[4], 1).ToString();
                L_10T6.Text = Math.Round(s10[4], 1).ToString();
                L_15T6.Text = Math.Round(s15[4], 1).ToString();
                L_30T6.Text = Math.Round(s30[4], 1).ToString();
                L_45T6.Text = Math.Round(s45[4], 1).ToString();
                L_60T6.Text = Math.Round(s60[4], 1).ToString();
                L_90T6.Text = Math.Round(s90[4], 1).ToString();
                L_120T6.Text = Math.Round(s120[4], 1).ToString();
                L_150T6.Text = Math.Round(s150[4], 1).ToString();
                L_180T6.Text = Math.Round(s180[4], 1).ToString();

                L_5T7.Text = Math.Round(s5[5], 1).ToString();
                L_10T7.Text = Math.Round(s10[5], 1).ToString();
                L_15T7.Text = Math.Round(s15[5], 1).ToString();
                L_30T7.Text = Math.Round(s30[5], 1).ToString();
                L_45T7.Text = Math.Round(s45[5], 1).ToString();
                L_60T7.Text = Math.Round(s60[5], 1).ToString();
                L_90T7.Text = Math.Round(s90[5], 1).ToString();
                L_120T7.Text = Math.Round(s120[5], 1).ToString();
                L_150T7.Text = Math.Round(s150[5], 1).ToString();
                L_180T7.Text = Math.Round(s180[5], 1).ToString();

                L_5T9.Text = Math.Round(s5a[0], 1).ToString();
                L_10T9.Text = Math.Round(s10a[0], 1).ToString();
                L_15T9.Text = Math.Round(s15a[0], 1).ToString();
                L_30T9.Text = Math.Round(s30a[0], 1).ToString();
                L_45T9.Text = Math.Round(s45a[0], 1).ToString();
                L_60T9.Text = Math.Round(s60a[0], 1).ToString();
                L_90T9.Text = Math.Round(s90a[0], 1).ToString();
                L_120T9.Text = Math.Round(s120a[0], 1).ToString();
                L_150T9.Text = Math.Round(s150a[0], 1).ToString();
                L_180T9.Text = Math.Round(s180a[0], 1).ToString();

                L_5T10.Text = Math.Round(s5a[1], 1).ToString();
                L_10T10.Text = Math.Round(s10a[1], 1).ToString();
                L_15T10.Text = Math.Round(s15a[1], 1).ToString();
                L_30T10.Text = Math.Round(s30a[1], 1).ToString();
                L_45T10.Text = Math.Round(s45a[1], 1).ToString();
                L_60T10.Text = Math.Round(s60a[1], 1).ToString();
                L_90T10.Text = Math.Round(s90a[1], 1).ToString();
                L_120T10.Text = Math.Round(s120a[1], 1).ToString();
                L_150T10.Text = Math.Round(s150a[1], 1).ToString();
                L_180T10.Text = Math.Round(s180a[1], 1).ToString();

                L_5T11.Text = Math.Round(s5a[2], 1).ToString();
                L_10T11.Text = Math.Round(s10a[2], 1).ToString();
                L_15T11.Text = Math.Round(s15a[2], 1).ToString();
                L_30T11.Text = Math.Round(s30a[2], 1).ToString();
                L_45T11.Text = Math.Round(s45a[2], 1).ToString();
                L_60T11.Text = Math.Round(s60a[2], 1).ToString();
                L_90T11.Text = Math.Round(s90a[2], 1).ToString();
                L_120T11.Text = Math.Round(s120a[2], 1).ToString();
                L_150T11.Text = Math.Round(s150a[2], 1).ToString();
                L_180T11.Text = Math.Round(s180a[2], 1).ToString();

                L_5T13.Text = Math.Round(s5a[3], 1).ToString();
                L_10T13.Text = Math.Round(s10a[3], 1).ToString();
                L_15T13.Text = Math.Round(s15a[3], 1).ToString();
                L_30T13.Text = Math.Round(s30a[3], 1).ToString();
                L_45T13.Text = Math.Round(s45a[3], 1).ToString();
                L_60T13.Text = Math.Round(s60a[3], 1).ToString();
                L_90T13.Text = Math.Round(s90a[3], 1).ToString();
                L_120T13.Text = Math.Round(s120a[3], 1).ToString();
                L_150T13.Text = Math.Round(s150a[3], 1).ToString();
                L_180T13.Text = Math.Round(s180a[3], 1).ToString();

                L_5T14.Text = Math.Round(s5a[4], 1).ToString();
                L_10T14.Text = Math.Round(s10a[4], 1).ToString();
                L_15T14.Text = Math.Round(s15a[4], 1).ToString();
                L_30T14.Text = Math.Round(s30a[4], 1).ToString();
                L_45T14.Text = Math.Round(s45a[4], 1).ToString();
                L_60T14.Text = Math.Round(s60a[4], 1).ToString();
                L_90T14.Text = Math.Round(s90a[4], 1).ToString();
                L_120T14.Text = Math.Round(s120a[4], 1).ToString();
                L_150T14.Text = Math.Round(s150a[4], 1).ToString();
                L_180T14.Text = Math.Round(s180a[4], 1).ToString();

                L_5T15.Text = Math.Round(s5a[5], 1).ToString();
                L_10T15.Text = Math.Round(s10a[5], 1).ToString();
                L_15T15.Text = Math.Round(s15a[5], 1).ToString();
                L_30T15.Text = Math.Round(s30a[5], 1).ToString();
                L_45T15.Text = Math.Round(s45a[5], 1).ToString();
                L_60T15.Text = Math.Round(s60a[5], 1).ToString();
                L_90T15.Text = Math.Round(s90a[5], 1).ToString();
                L_120T15.Text = Math.Round(s120a[5], 1).ToString();
                L_150T15.Text = Math.Round(s150a[5], 1).ToString();
                L_180T15.Text = Math.Round(s180a[5], 1).ToString();
                Chart1.Series[0].Points.Clear();
                Chart1.Series[1].Points.Clear();
                Chart1.Series[2].Points.Clear();
                Chart1.Series[3].Points.Clear();
                Chart1.Series[4].Points.Clear();
                Chart1.Series[5].Points.Clear();

                Chart1.Visible = true;

                Chart1.Series[0].Points.AddXY(double.Parse(Label2065.Text), s5a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2051.Text), s10a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2052.Text), s15a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2053.Text), s30a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2054.Text), s45a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2055.Text), s60a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2056.Text), s90a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2057.Text), s120a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2058.Text), s150a[0]);
                Chart1.Series[0].Points.AddXY(double.Parse(Label2059.Text), s180a[0]);

                Chart1.Series[1].Points.AddXY(double.Parse(Label2065.Text), s5a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2051.Text), s10a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2052.Text), s15a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2053.Text), s30a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2054.Text), s45a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2055.Text), s60a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2056.Text), s90a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2057.Text), s120a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2058.Text), s150a[1]);
                Chart1.Series[1].Points.AddXY(double.Parse(Label2059.Text), s180a[1]);

                Chart1.Series[2].Points.AddXY(double.Parse(Label2065.Text), s5a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2051.Text), s10a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2052.Text), s15a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2053.Text), s30a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2054.Text), s45a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2055.Text), s60a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2056.Text), s90a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2057.Text), s120a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2058.Text), s150a[2]);
                Chart1.Series[2].Points.AddXY(double.Parse(Label2059.Text), s180a[2]);

                Chart1.Series[3].Points.AddXY(double.Parse(Label2065.Text), s5a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2051.Text), s10a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2052.Text), s15a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2053.Text), s30a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2054.Text), s45a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2055.Text), s60a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2056.Text), s90a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2057.Text), s120a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2058.Text), s150a[3]);
                Chart1.Series[3].Points.AddXY(double.Parse(Label2059.Text), s180a[3]);

                Chart1.Series[4].Points.AddXY(double.Parse(Label2065.Text), s5a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2051.Text), s10a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2052.Text), s15a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2053.Text), s30a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2054.Text), s45a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2055.Text), s60a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2056.Text), s90a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2057.Text), s120a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2058.Text), s150a[4]);
                Chart1.Series[4].Points.AddXY(double.Parse(Label2059.Text), s180a[4]);

                Chart1.Series[5].Points.AddXY(double.Parse(Label2065.Text), s5a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2051.Text), s10a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2052.Text), s15a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2053.Text), s30a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2054.Text), s45a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2055.Text), s60a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2056.Text), s90a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2057.Text), s120a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2058.Text), s150a[5]);
                Chart1.Series[5].Points.AddXY(double.Parse(Label2059.Text), s180a[5]);
                Button_Next1.Visible = true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
            }
        }

        protected void Button_Next1_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            pan_fb.Visible = true;
        }
    }
}