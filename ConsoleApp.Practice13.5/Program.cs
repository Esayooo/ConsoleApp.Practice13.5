using System;
using System.Collections;

// Класс для представления песни
class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }
}

// Класс для представления компакт-диска
class CompactDisc
{
    public string Title { get; set; }
    public ArrayList Songs { get; set; }

    public CompactDisc(string title)
    {
        Title = title;
        Songs = new ArrayList();
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        Songs.Remove(song);
    }

    public void Display()
    {
        Console.WriteLine($"Compact Disc: {Title}");
        foreach (Song song in Songs)
        {
            Console.WriteLine($"  - {song.Title} by {song.Artist}");
        }
    }
}

// Класс для представления каталога музыкальных компакт-дисков
class MusicCatalog
{
    private Hashtable catalog;

    public MusicCatalog()
    {
        catalog = new Hashtable();
    }

    public void AddCompactDisc(CompactDisc cd)
    {
        catalog.Add(cd.Title, cd);
    }

    public void RemoveCompactDisc(string title)
    {
        catalog.Remove(title);
    }

    public void DisplayCatalog()
    {
        Console.WriteLine("Music Catalog:");
        foreach (DictionaryEntry entry in catalog)
        {
            CompactDisc cd = (CompactDisc)entry.Value;
            cd.Display();
            Console.WriteLine();
        }
    }

    public void DisplayDisc(string title)
    {
        if (catalog.ContainsKey(title))
        {
            CompactDisc cd = (CompactDisc)catalog[title];
            cd.Display();
        }
        else
        {
            Console.WriteLine($"Compact Disc with title '{title}' not found.");
        }
    }

    public void SearchByArtist(string artist)
    {
        Console.WriteLine($"Search results for artist '{artist}':");
        foreach (DictionaryEntry entry in catalog)
        {
            CompactDisc cd = (CompactDisc)entry.Value;
            foreach (Song song in cd.Songs)
            {
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"  - {song.Title} from {cd.Title}");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание экземпляра каталога
        MusicCatalog catalog = new MusicCatalog();

        // Создание и добавление компакт-дисков
        CompactDisc cd1 = new CompactDisc("CD1");
        cd1.AddSong(new Song("Лиловая", "Jah Khailb"));
        cd1.AddSong(new Song("Lonely", "Justin Bieber"));
        catalog.AddCompactDisc(cd1);

        CompactDisc cd2 = new CompactDisc("CD2");
        cd2.AddSong(new Song("Oh my love", "Raim"));
        cd2.AddSong(new Song("Доча", "Jah Khailb"));
        catalog.AddCompactDisc(cd2);

        // Вывод каталога
        catalog.DisplayCatalog();

        Console.WriteLine("\n-----------------------------\n");

        // Удаление компакт-диска и вывод обновленного каталога
        catalog.RemoveCompactDisc("CD1");
        catalog.DisplayCatalog();

        Console.WriteLine("\n-----------------------------\n");

        // Вывод содержимого отдельного диска
        catalog.DisplayDisc("CD2");

        Console.WriteLine("\n-----------------------------\n");

        // Поиск записей по исполнителю
        catalog.SearchByArtist("Jah Khailb");
    }
}
