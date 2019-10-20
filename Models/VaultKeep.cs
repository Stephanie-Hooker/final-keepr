using final_keepr.Interfaces;

namespace final_keepr.Models
{
  public class VaultKeep : IVaultKeep

  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
  }
}