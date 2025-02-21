using System;
using System.Collections.Generic;

namespace PRN212_PE_SU24_544198;

public partial class CourseCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
