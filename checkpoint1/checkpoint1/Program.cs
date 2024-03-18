// gerenciador de músicas baseado na discografia da artista billie eilish :) - playlist manager

// mary araujo moreira speranzini - rm 550242

using System;
using System.Collections.Generic;

public abstract class EntidadeMusical
{
    public string Nome { get; set; }

    public EntidadeMusical(string nome)
    {
        Nome = nome;
    }
}

public class Artista : EntidadeMusical
{
    public int Idade { get; set; }
    public string Genero { get; set; }
    protected string GeneroPrincipal { get; set; }

    public Artista(string nome, int idade, string genero) : base(nome)
    {
        Idade = idade;
        Genero = genero;
        GeneroPrincipal = genero;
    }

    public void Apresentar()
    {
        Console.WriteLine($"nome: {Nome}");
        Console.WriteLine($"idade: {Idade} anos");
        Console.WriteLine($"gênero musical: {Genero}");
        Console.WriteLine($"gênero musical principal: {GeneroPrincipal}");
    }
}

public class Album : EntidadeMusical
{
    public int Ano { get; set; }
    public List<Musica> Musicas { get; set; }

    public Album(string nome, int ano) : base(nome)
    {
        Ano = ano;
        Musicas = new List<Musica>();
    }
}

public class Musica : EntidadeMusical
{
    public int Duracao { get; set; }
    public Artista Artista { get; set; }
    public Album Album { get; set; }

    public Musica(string nome) : base(nome)
    {
    }

    public virtual void Tocar()
    {
        Console.WriteLine($"tocando {Nome}...");
    }
}

public class MusicaAoVivo : Musica
{
    public MusicaAoVivo(string nome, Artista artista, Album album) : base(nome)
    {
        Artista = artista;
        Album = album;
    }

    public override void Tocar()
    {
        Console.WriteLine($"tocando {Nome} (versão ao vivo)...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Artista billieEilish = new Artista("billie eilish", 20, "pop");

        Console.WriteLine("info sobre a artista:");
        billieEilish.Apresentar();
        Console.WriteLine();

        Album albumBillie = new Album("when we all fall asleep, where do we go?", 2019);

        Musica badGuy = new Musica("bad guy");
        badGuy.Artista = billieEilish;
        badGuy.Album = albumBillie;

        Musica lovely = new Musica("lovely");
        lovely.Artista = billieEilish;
        lovely.Album = albumBillie;

        MusicaAoVivo whenThePartyIsOverAoVivo = new MusicaAoVivo("when the party's over", billieEilish, albumBillie);

        List<EntidadeMusical> playlist = new List<EntidadeMusical> { badGuy, lovely, whenThePartyIsOverAoVivo };

        foreach (var item in playlist)
        {
            if (item is Musica musica)
            {
                musica.Tocar();
            }
            else if (item is Artista artista)
            {
                Console.WriteLine($"Artista: {artista.Nome}");
            }
            else if (item is Album album)
            {
                Console.WriteLine($"Álbum: {album.Nome} ({album.Ano})");
            }
        }
    }
}
