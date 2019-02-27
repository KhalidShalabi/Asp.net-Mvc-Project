//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            this.StudentsGrades = new HashSet<StudentsGrade>();
            this.StudySchedules = new HashSet<StudySchedule>();
            this.TeacherCourses = new HashSet<TeacherCours>();
        }
    
        public int CoursesId { get; set; }
        public string CoursesTitle { get; set; }
        public string Description { get; set; }
        public int ClassId { get; set; }
        public int ClassMaterialsId { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual ClassMaterial ClassMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsGrade> StudentsGrades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudySchedule> StudySchedules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherCours> TeacherCourses { get; set; }
    }
}
