using System;
using System.Collections.Generic;

public class DataModel
{
    public int Count { get; set; }
    public List<Guid> Guids { get; set; } = new List<Guid>();
    public bool Checked { get; set; }
}