namespace AzGuidance.Domain.Entities;

public class Cliente
{
    public int ClienteID { get; set; }
    public bool Permitido { get; set; }
    public int TipoEmailID { get; set; }
    public int EnviarParaID { get; set; }
    public int FormaEnvioID { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
}

