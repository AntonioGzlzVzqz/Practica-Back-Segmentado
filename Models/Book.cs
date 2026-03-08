using System;
using System.Collections.Generic;

namespace LibreriaApi.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? Stock { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
