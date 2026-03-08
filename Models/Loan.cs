using System;
using System.Collections.Generic;

namespace LibreriaApi.Models;

public partial class Loan
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateTime? LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
