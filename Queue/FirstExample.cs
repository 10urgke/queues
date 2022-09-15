using System.Collections;
namespace Queue
{
    class Sira_Ornek1
{

    public static void Main()
    {
        // Queue sınıfından bir nesne oluşturalım:
        System.Collections.Queue sira = new System.Collections.Queue();

        // Nesnemize Enqueue metodu ile değerler girelim:
        sira.Enqueue("1");
        sira.Enqueue("2");
        sira.Enqueue("3");
        sira.Enqueue("4");
        sira.Enqueue("5");

        // sira isimli nesnemizin eleman sayısı:
        Console.WriteLine( "\n Eleman Sayısı: " + sira.Count);

        // sira isimli nesnemizin elemanları:
        Console.WriteLine( "\n Elemanlar: " ); 
        SortBy( sira );

        //sira isimli nesmemizden bir eleman alalım: 
        string eleman= (string)sira.Dequeue();
        Console.WriteLine(" \n Sırası gelen eleman: " + eleman);

        //şimdi ise siranin en başındaki nesneyi öğrenelim.
        // Ama onu siradan çıkartmayacağız:
        eleman= (string)sira.Peek();
        Console.WriteLine(" \n Sıradaki eleman " + eleman);

    }
    
    

    public static void SortBy( IEnumerable Collection ) 
    {
        IEnumerator Enum = Collection.GetEnumerator();

        while ( Enum.MoveNext() )
            Console.Write( "\t{0}", Enum.Current );

        Console.WriteLine();
    }
}
}
