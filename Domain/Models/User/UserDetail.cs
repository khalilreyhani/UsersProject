using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.User
{
    public class UserDetail :BaseEntities
        {
        [Display(Name = "سن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public int age { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public bool sex { get; set; }

        public int UserId { get; set; }


        #region Relations

        [ForeignKey("UserId")]

        public virtual User User { get; set; }



        #endregion


    }
}
