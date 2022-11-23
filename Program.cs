var valoresX = new int?[] { 1, 2, 3, 4, 5 };
var valoresO = new int?[] { 1, 2, 3, 4, 5 };

var posicoes = new Peca[3, 3];
for (var l = 0; l < 3; l++)
{
    for (var c = 0; c < 3; c++)
    {
        posicoes[l, c] = new Peca();
    }
}

bool acabou = false;
int validas = 0;
int tentativas = 0;
DateTime inicio = DateTime.Now;
Jogar();

void Jogar()
{
    bool valida = true;
    for (var l = 0; l < 3; l++)
    {
        for (var c = 0; c < 3; c++)
        {
            for (var p = 1; p <= 5; p++)
            {
                for (var j = 1; j <= 2; j++)
                {
                    valida = JogadaValida(l, c, p, j);
                    if (valida)
                    {
                        posicoes[l, c].Jogador = j;
                        posicoes[l, c].Valor = p;
                        MostrarJogo(posicoes);
                        VerificaVencedor(posicoes);
                        SetarPecaIndisponivel(j, p);
                        validas++;
                    }
                    tentativas++;
                }
            }
        }
    }
}

DateTime fim = DateTime.Now;
var tempo = (fim - inicio).TotalMilliseconds;
Console.WriteLine("tempo: " + tempo);
Console.WriteLine("tentativas: " + tentativas);
Console.WriteLine("válidas: " + validas);

void MostrarJogo(Peca[,] posicoes)
{
    Console.Clear();
    string matriz = "\n";
    for (var i = 0; i < 3; i++)
    {
        for (var j = 0; j < 3; j++)
        {
            matriz += $" {(posicoes[i, j].Jogador == 1 ? "X" : posicoes[i, j].Jogador == 2 ? "O" : " ")}{(posicoes[i, j].Valor != 0 ? posicoes[i, j].Valor : " ")} ";
            if (j < 2)
            {
                matriz += "|";
            }
        }
        if (i < 2)
            matriz += "\n----|----|----\n";
    }
    Console.WriteLine(matriz);
}

bool JogadaValida(int linha, int coluna, int peca, int jogador)
{
    if (posicoes[linha, coluna].Jogador == jogador)
    {
        return false;
    }

    if (posicoes[linha, coluna].Valor >= peca)
    {
        return false;
    }

    if (!VerificarDisponivel(jogador, peca))
    {
        return false;
    }

    return true;
}

bool VerificarDisponivel(int jogador, int peca)
{
    var valores = jogador == 1 ? valoresX : valoresO;
    foreach (var i in valores) if (i == peca) return true;
    return false;
}

void SetarPecaIndisponivel(int jogador, int peca)
{
    var valores = jogador == 1 ? valoresX : valoresO;
    for (var i = 0; i < valores.Length; i++)
    {
        if (valores[i] == peca)
        {
            valores[i] = null;
        }
    }
}

void VerificaVencedor(Peca[,] posicoes)
{
    if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[0, 1].Jogador && posicoes[0, 1].Jogador == posicoes[0, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[1, 0].Jogador != 0 && (posicoes[1, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[1, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[1, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[2, 0].Jogador != 0 && (posicoes[2, 0].Jogador == posicoes[2, 1].Jogador && posicoes[2, 1].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[2, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[1, 0].Jogador && posicoes[1, 0].Jogador == posicoes[2, 0].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 1].Jogador != 0 && (posicoes[0, 1].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 1].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[0, 1].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 2].Jogador != 0 && (posicoes[0, 2].Jogador == posicoes[1, 2].Jogador && posicoes[1, 2].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[0, 2].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[2, 0].Jogador != 0 && (posicoes[2, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[0, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, '{(posicoes[2, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
}