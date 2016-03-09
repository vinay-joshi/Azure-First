﻿using Azure_First.Web.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Azure_First.Web.Models
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }

        [StringLength(2048, MinimumLength = 5)]
        public string Pitch { get; set; }

        [DisplayName("Looking For")]
        [StringLength(2048, MinimumLength = 15,
          ErrorMessage = "{0} should between {2} and {1} characters")]
        public string LookingFor { get; set; }

        [StringLength(4096, MinimumLength = 25)]
        public string Introduction { get; set; }

        [DisplayName("Birthday")]
        [Required]
        [AgeRange(18, 120, ErrorMessage = "Your age must be between {1}-{2} in {0}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "{0} must be specified.")]
        public string Gender { get; set; }

        public string MemberName { get; set; }

        [DisplayName("Sexual Orientation")]
        [Required]
        public string Orientation { get; set; }
    }
}