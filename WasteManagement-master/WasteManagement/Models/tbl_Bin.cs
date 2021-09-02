using AAJdbController;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class tbl_Bin : AAJ
    {
        dbcontrol s = new dbcontrol();
        [Display(Name = "ID")]
        public Int32 ID { get; set; }

        [Display(Name = "Bin ID")]
        public String BinID { get; set; }

        [Display(Name = "Max Capacity")]
        public Decimal? MaxCapacity { get; set; }

        [Display(Name = "Current Capacity")]
        public Decimal? CurrentCapacity { get; set; }

        [Display(Name = "Location")]
        public String Location { get; set; }

        [Display(Name = "Collector Phone")]
        public String CollectorPhone { get; set; }

        [Display(Name = "Deployment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DeploymentDate { get; set; }

        public string Status
        {
            get
            {
                var result = "";
                decimal? getremaining = MaxCapacity - (MaxCapacity - CurrentCapacity);
                if (getremaining >= 0.61m && getremaining <= 1)
                {
                    result = "text-danger";
                }
                else if (getremaining >= 0.41m && getremaining <= 0.6m)
                {
                    result = "text-warning";
                }
                else if (getremaining >= 0.2m && getremaining <= 0.4m)
                {
                    result = "text-success";
                }
                else 
                {
                    result = "";
                }
                return result;
            }
        }

        public tbl_Bin()
        {
        }
        public tbl_Bin(DataRow r) : base(r)
        {
        }
        public List<tbl_Bin> List_tbl_Bin()
        {
            var list = new List<tbl_Bin>();
            s.Query("SELECT * FROM tbl_Bin").ForEach(r =>
            {
                var item = new tbl_Bin(r);
                list.Add(item);
            });
            return list;
        }
        public tbl_Bin Find_tbl_Bin(int ID)
        {
            var item = new tbl_Bin();
            s.Query("SELECT * FROM tbl_Bin WHERE ID = @ID", p => p.Add("@ID", ID)).ForEach(r =>
            {
                var tempItem = new tbl_Bin(r);
                item = tempItem;
            });
            return item;
        }
        public void Create(tbl_Bin obj)
        {
            s.Insert("tbl_Bin", p =>
            {
                p.Add("BinID", obj.BinID);
                p.Add("MaxCapacity", obj.MaxCapacity);
                p.Add("CurrentCapacity", obj.CurrentCapacity);
                p.Add("Location", obj.Location);
                p.Add("CollectorPhone", obj.CollectorPhone);
                p.Add("DeploymentDate", obj.DeploymentDate);
            });
        }
        public void Update(tbl_Bin obj)
        {
            s.Update("tbl_Bin", obj.ID, p =>
            {
                p.Add("BinID", obj.BinID);
                p.Add("MaxCapacity", obj.MaxCapacity);
                p.Add("CurrentCapacity", obj.CurrentCapacity);
                p.Add("Location", obj.Location);
                p.Add("CollectorPhone", obj.CollectorPhone);
                p.Add("DeploymentDate", obj.DeploymentDate);
            });
        }
        public void Delete(tbl_Bin obj)
        {
            s.Query("DELETE FROM tbl_Bin WHERE ID = @ID", p =>
            {
                p.Add("@ID", obj.ID);
            });
        }
    }


}