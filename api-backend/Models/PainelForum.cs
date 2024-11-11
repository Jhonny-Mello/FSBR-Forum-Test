
namespace api_backend.Models;

public class PainelForum
{
    public PainelForum()
    {
    }

    public PainelForum(string search, int avaliacao, bool isdescending)
    {
        this.search = search;
        this.avaliacao = avaliacao;
        IsDescending = isdescending;
    }

    public string search { get; set; } = string.Empty;
    public int avaliacao { get; set; } = 0;
    public bool IsDescending { get; set; } = false;
}