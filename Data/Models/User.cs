using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace spayserver.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal? Amount { get; set; }
    
    public string Phone { get; set; } = string.Empty!;

    public string imgUrl { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
