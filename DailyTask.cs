using System;
using System.Collections.Generic;

namespace DemoApp.DBFirst;

public partial class DailyTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Count { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
