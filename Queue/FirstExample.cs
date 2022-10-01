using System.Collections;
namespace Tail
{
    class Sira_Ornek1
{

    public static void Main()
    {
        // Tail sınıfından bir nesne oluşturalım:
        Tail sira = new Tail();

        // Nesneye Enqueue() metodu ile değerler girelim:
        sira.Enqueue("1");
        sira.Enqueue("2");
        sira.Enqueue("3");
        sira.Enqueue("4");
        sira.Enqueue("5");

        // Sira isimli nesnemizin eleman sayısı:
        Console.WriteLine( "\n Eleman Sayısı: " + sira.Count);

        //Sira isimli nesmemizden bir eleman alalım: 
        string eleman= (string)sira.Dequeue();
        Console.WriteLine(" \n Sırası gelen eleman: " + eleman);

        //Simdi ise siranin en başındaki nesneyi öğrenelim.
        //Ama onu siradan çıkartmayacağız:
        eleman= (string)sira.Peek();
        Console.WriteLine(" \n Sıradaki eleman " + eleman);
        
        sira.Clear();
        Console.WriteLine($" \n Elemanlar silindi eleman sayısı = {sira.Count}");
        
    }
}
}
