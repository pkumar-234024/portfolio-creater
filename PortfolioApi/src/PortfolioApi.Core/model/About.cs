using System.ComponentModel.DataAnnotations.Schema;
using PortfolioApi.SharedKernel;
using PortfolioApi.SharedKernel.Interfaces;

namespace PortfolioApi.Core.model;
public class About : BaseEntity, IAggregateRoot
{
  [ForeignKey("Users")]
  public int UserId { get; set; }

  public string? AboutUsers { get; set; }

  public string? Description { get; set;}
}
