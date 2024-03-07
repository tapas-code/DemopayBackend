﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace spayserver.Data.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
