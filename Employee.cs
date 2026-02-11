using System;
using System.Collections.Generic;

namespace DemoApp.DBFirst;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<DailyTask> DailyTasks { get; set; } = new List<DailyTask>();
}
