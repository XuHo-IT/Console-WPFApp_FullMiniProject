﻿using System;
using System.Collections.Generic;

namespace PRN212_PE_SU24_544198;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public string? ReviewText { get; set; }

    public int? Rating { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
