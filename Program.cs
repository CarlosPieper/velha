var posicoes = new Peca[3, 3];

for (var i = 0; i < 3; i++)
{
    for (var j = 0; j < 3; j++)
    {
        posicoes[i, j] = new Peca();
    }
}

var valoresX = new int?[] { 1, 2, 3, 4, 5 };
var valoresO = new int?[] { 1, 2, 3, 4, 5 };

bool acabou = false;

int jogada = 0;
while (!acabou && jogada < 9)
{
    string jogador = (jogada % 2 == 0 ? "X" : "O");
    MostrarJogo(posicoes);
    PedirJogada(jogador);
    VerificaVencedor(posicoes, jogador);
    jogada++;
}

if (!acabou && jogada >= 9)
{
    TerminarJogo(posicoes, "");
}

void MostrarJogo(Peca[,] posicoes)
{
    string matriz = "\n";
    for (var i = 0; i < 3; i++)
    {
        for (var j = 0; j < 3; j++)
        {
            matriz += $" {posicoes[i, j].Jogador}{(posicoes[i, j].Valor != 0 ? posicoes[i, j].Valor : " ")} ";
            if (j < 2)
            {
                matriz += "|";
            }
        }
        matriz += "\n----|----|----\n";
    }

    //string matriz = $"\n {posicoes[0, 0].Jogador}{posicoes[0, 0].Valor} | {posicoes[0, 1].Jogador} | {posicoes[0, 2].Jogador} \n---|---|---\n {posicoes[1, 0].Jogador} | {posicoes[1, 1].Jogador} | {posicoes[1, 2].Jogador} \n---|---|---\n {posicoes[2, 0].Jogador} | {posicoes[2, 1].Jogador} | {posicoes[2, 2].Jogador}";
    Console.WriteLine(matriz);
}

void PedirJogada(string jogador)
{
    Console.WriteLine("Informe a posição em que quer jogar");
    var posicao = 0;
    try
    {
        posicao = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Posição inválida, tem que ser um valor entre 1 e 9, jogue novamente");
        PedirJogada(jogador);
        return;
    }

    if (posicao > 9 || posicao < 1)
    {
        Console.WriteLine("Posição inválida, tem que ser um valor entre 1 e 9, jogue novamente");
        PedirJogada(jogador);
        return;
    }

    int linha = 0, coluna = 0;

    if (posicao == 2)
    {
        linha = 0;
        coluna = 1;
    }
    else if (posicao == 3)
    {
        linha = 0;
        coluna = 2;
    }
    else if (posicao == 4)
    {
        linha = 1;
        coluna = 0;
    }
    else if (posicao == 5)
    {
        linha = 1;
        coluna = 1;
    }
    else if (posicao == 6)
    {
        linha = 1;
        coluna = 2;
    }
    else if (posicao == 7)
    {
        linha = 2;
        coluna = 0;
    }
    else if (posicao == 8)
    {
        linha = 2;
        coluna = 1;
    }
    else if (posicao == 9)
    {
        linha = 2;
        coluna = 2;
    }

    int valor = PedirValor(jogador, posicoes[linha, coluna]);
    if (valor == 0)
    {
        PedirJogada(jogador);
        return;
    }

    posicoes[linha, coluna].Jogador = jogador;
    posicoes[linha, coluna].Valor = valor;

}

int PedirValor(string jogador, Peca posicao)
{
    Console.WriteLine("Informe o valor da peça que quer jogar");
    var valor = 0;
    try
    {
        valor = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Valor inválido, tem que ser um valor entre 1 e 5 ainda não usado");
        return 0;
    }
    bool valorValido = true;

    valorValido = VerificarDisponivel(jogador, valor);

    if (!valorValido)
    {
        Console.WriteLine("Valor inválido, tem que ser um valor entre 1 e 5 ainda não usado");
        return 0;
    }

    if (valor <= posicao.Valor)
    {
        Console.WriteLine("Valor inválido, deve ser maior que o valor já presente na posição");
        return 0;
    }

    SetarPecaIndisponivel(jogador, valor);

    return valor;
}

bool VerificarDisponivel(string jogador, int valor)
{
    var valores = jogador == "X" ? valoresX : valoresO;
    foreach (var i in valores) if (i == valor) return true;
    return false;
}

void SetarPecaIndisponivel(string jogador, int valor)
{
    var valores = jogador == "X" ? valoresX : valoresO;
    for (var i = 0; i < valores.Length; i++)
    {
        if (valores[i] == valor)
        {
            valores[i] = null;
        }
    }
}

void VerificaVencedor(Peca[,] posicoes, string jogador)
{
    acabou =
    (posicoes[0, 0].Jogador == jogador && (posicoes[0, 0].Jogador == posicoes[0, 1].Jogador && posicoes[0, 1].Jogador == posicoes[0, 2].Jogador)) ||
    (posicoes[1, 0].Jogador == jogador && (posicoes[1, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[1, 2].Jogador)) ||
    (posicoes[2, 0].Jogador == jogador && (posicoes[2, 0].Jogador == posicoes[2, 1].Jogador && posicoes[2, 1].Jogador == posicoes[2, 2].Jogador)) ||
    (posicoes[0, 0].Jogador == jogador && (posicoes[0, 0].Jogador == posicoes[1, 0].Jogador && posicoes[1, 0].Jogador == posicoes[2, 0].Jogador)) ||
    (posicoes[0, 1].Jogador == jogador && (posicoes[0, 1].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 1].Jogador)) ||
    (posicoes[0, 2].Jogador == jogador && (posicoes[0, 2].Jogador == posicoes[1, 2].Jogador && posicoes[1, 2].Jogador == posicoes[2, 2].Jogador)) ||
    (posicoes[0, 0].Jogador == jogador && (posicoes[0, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 2].Jogador)) ||
    (posicoes[2, 0].Jogador == jogador && (posicoes[2, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[0, 2].Jogador));

    if (acabou)
    {
        TerminarJogo(posicoes, jogador);
    }
}

void TerminarJogo(Peca[,] posicoes, string jogador)
{
    MostrarJogo(posicoes);
    Console.WriteLine($"Fim do jogo, {(string.IsNullOrWhiteSpace(jogador) ? "velha" : $"'{jogador}' venceu")}");
}