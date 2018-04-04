using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PupilManager.Models
{
    public class Pupil
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("First Name(s)")]
        public string FirstNames { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
        public bool Gender { get; set; } // false/true = boy/girl
        [DisplayName("Medical Conditions")]
        public string MedicalConditions { get; set; }
    }
}
