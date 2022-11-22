var posicoes = new Peca[3, 3];
for (var l = 0; l < 3; l++)
{
    for (var c = 0; c < 3; c++)
    {
        posicoes[l, c] = new Peca();
    }
}

bool acabou = false;

for (var l = 0; l < 3; l++)
{
    for (var c = 0; c < 3; c++)
    {
        for (var p = 1; p < 6; p++)
        {
            for (var j = 1; j < 3; j++)
            {
                if (!(posicoes[l, c].Jogador == j || posicoes[l, c].Valor >= p))
                {
                    posicoes[l, c].Jogador = j;
                    posicoes[l, c].Valor = p;
                    MostrarJogo(posicoes);
                    VerificaVencedor(posicoes);
                    break;
                }
            }
        }
    }
}

void MostrarJogo(Peca[,] posicoes)
{
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
        matriz += "\n----|----|----\n";
    }
    Console.WriteLine(matriz);
}

void VerificaVencedor(Peca[,] posicoes)
{
    if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[0, 1].Jogador && posicoes[0, 1].Jogador == posicoes[0, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[1, 0].Jogador != 0 && (posicoes[1, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[1, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[1, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[2, 0].Jogador != 0 && (posicoes[2, 0].Jogador == posicoes[2, 1].Jogador && posicoes[2, 1].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[2, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[1, 0].Jogador && posicoes[1, 0].Jogador == posicoes[2, 0].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 1].Jogador != 0 && (posicoes[0, 1].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 1].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[0, 1].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 2].Jogador != 0 && (posicoes[0, 2].Jogador == posicoes[1, 2].Jogador && posicoes[1, 2].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[0, 2].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[0, 0].Jogador != 0 && (posicoes[0, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[2, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[0, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
    else if (posicoes[2, 0].Jogador != 0 && (posicoes[2, 0].Jogador == posicoes[1, 1].Jogador && posicoes[1, 1].Jogador == posicoes[0, 2].Jogador))
    {
        Console.WriteLine($"Fim do jogo, {(posicoes[2, 0].Jogador == 1 ? "X" : "O")}' venceu");
        acabou = true;
    }
}