namespace Queue;
using System.Collections;

class Sira_Ornek2
{

    public static void Main2() 
    {
        // Queue sınıfından bir nesne oluşturalım:
        Queue sira = new Queue();

        // Nesnemize Enqueue metodu ile değerler girelim:
        sira.Enqueue(12);
        sira.Enqueue(3);
        sira.Enqueue(18);
        sira.Enqueue(7);
        sira.Enqueue(20);

        // sıra isimli nesnemizin eleman sayısı:
        Console.WriteLine( "\n Eleman Sayısı: " + sira.Count);

        // sira isimli nesnemizin elemanları:
        Console.WriteLine( "\n Elemanlar:" ); 
        SortBy( sira );

        //Contains metodunun kullanımı:
        int sayi=7;

        if(sira.Contains(7))
            Console.WriteLine("Sırada " + sayi + " var.");
        else 
            Console.WriteLine("Sırada " + sayi + " yok.");

        // sıramızın içindeki elemanları silelim:
        sira.Clear();

        // Sıramızı temizledikten sonra kaç tane 
        // eleman bulunduğunu bulup yazalım.
        int elemanSayisi= sira.Count;

        Console.WriteLine("\n Sıramizda şu anda {0} tane eleman vardır.", elemanSayisi);
    }

    public static void SortBy( IEnumerable Collection ) 
    {
        IEnumerator Enum = Collection.GetEnumerator();

        while ( Enum.MoveNext() )
            Console.Write( "\t{0}", Enum.Current );

        Console.WriteLine();
    }
}