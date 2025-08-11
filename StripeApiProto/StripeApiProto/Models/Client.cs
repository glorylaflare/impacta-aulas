﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StripeApiProto.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
