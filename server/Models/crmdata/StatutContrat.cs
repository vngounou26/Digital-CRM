using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crmdata
{
  [Table("StatutContrat", Schema = "dbo")]
  public partial class StatutContrat
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }

    public IEnumerable<Contrat> Contrats { get; set; }
    public string Name
    {
      get;
      set;
    }
  }
}
