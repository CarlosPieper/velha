var posicoes = new string[3, 3];
bool acabou = false;

for (var i = 0; i < 3; i++)
{
    for (var j = 0; j < 3; j++)
    {
        posicoes[i, j] = " ";
    }
}

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

void MostrarJogo(string[,] posicoes)
{
    string matriz = $"\n {posicoes[0, 0]} | {posicoes[0, 1]} | {posicoes[0, 2]} \n---|---|---\n {posicoes[1, 0]} | {posicoes[1, 1]} | {posicoes[1, 2]} \n---|---|---\n {posicoes[2, 0]} | {posicoes[2, 1]} | {posicoes[2, 2]}";
    Console.WriteLine(matriz);
}

void PedirJogada(string jogador)
{
    Console.WriteLine("Informe a posição em que quer jogar");
    var posicao = Convert.ToInt32(Console.ReadLine());

    if (posicao > 9 || posicao < 1)
    {
        Console.WriteLine("Posição inválida, tem que ser um valor entre 1 e 9, jogue novamente");
        PedirJogada(jogador);
        return;
    }

    int linha = 0, coluna = 0;

    if (posicao == 1)
    {
        linha = 0;
        coluna = 0;
    }
    else if (posicao == 2)
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

    if (!string.IsNullOrWhiteSpace(posicoes[linha, coluna]))
    {
        Console.WriteLine("Posição inválida, essa casa está ocupada");
        PedirJogada(jogador);
        return;
    }

    posicoes[linha, coluna] = jogador;
}

void VerificaVencedor(string[,] posicoes, string jogador)
{
    acabou =
    (posicoes[0, 0] == jogador && (posicoes[0, 0] == posicoes[0, 1] && posicoes[0, 1] == posicoes[0, 2])) ||
    (posicoes[1, 0] == jogador && (posicoes[1, 0] == posicoes[1, 1] && posicoes[1, 1] == posicoes[1, 2])) ||
    (posicoes[2, 0] == jogador && (posicoes[2, 0] == posicoes[2, 1] && posicoes[2, 1] == posicoes[2, 2])) ||
    (posicoes[0, 0] == jogador && (posicoes[0, 0] == posicoes[1, 0] && posicoes[1, 0] == posicoes[2, 0])) ||
    (posicoes[0, 1] == jogador && (posicoes[0, 1] == posicoes[1, 1] && posicoes[1, 1] == posicoes[2, 1])) ||
    (posicoes[0, 2] == jogador && (posicoes[0, 2] == posicoes[1, 2] && posicoes[1, 2] == posicoes[2, 2])) ||
    (posicoes[0, 0] == jogador && (posicoes[0, 0] == posicoes[1, 1] && posicoes[1, 1] == posicoes[2, 2])) ||
    (posicoes[2, 0] == jogador && (posicoes[2, 0] == posicoes[1, 1] && posicoes[1, 1] == posicoes[0, 2]));

    if (acabou)
    {
        TerminarJogo(posicoes, jogador);
    }
}

void TerminarJogo(string[,] posicoes, string jogador)
{
    MostrarJogo(posicoes);
    Console.WriteLine($"Fim do jogo, {(string.IsNullOrWhiteSpace(jogador) ? "velha" : $"'{jogador}' venceu")}");
}