using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class Registration
    {
        public int RegistrationID { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int RegistrationProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationSerialNumber { get; set; }

        [Required]
        public bool RegistrationVerified { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationAddress { get; set; }

        [Required]
        public string RegistrationState { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationCity { get; set;  }

        [Required]
        [StringLength(10)]
        public string RegistrationZip { get; set; }

        [Required]
        [StringLength(15)]
        public string RegistrationPhone { get; set; }

    }
}