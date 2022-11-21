public class Peca
{
    public int Valor { get; set; }
    public string Jogador { get; set; } = " ";

    public override string ToString(){
        return "Jogador: " + this.Jogador + " Valor: " + this.Valor;
    }
}