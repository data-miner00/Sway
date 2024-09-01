namespace Sway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Favourite
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public bool IsValid { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
