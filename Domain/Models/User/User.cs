using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.User
{
    public class User :BaseEntities
    {
        public Guid UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }


        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^09[0|1|2|3][0-9]{8}$", ErrorMessage = "شماره تلفن همراه خود را به درستی وارد نمایید")]

        public string Mobile { get; set; } = string.Empty;
             

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
       

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }


        #region Relations
        public virtual UserDetail UserDetail { get; set; }
       

        #endregion
    }
}
