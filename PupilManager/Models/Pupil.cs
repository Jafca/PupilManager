using System;

namespace PupilManager.Models
{
    public class Pupil
    {
        public int ID { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; } // false/true = boy/girl
        public string MedicalConditions { get; set; }
    }
}
