using System;
using System.Collections.Generic;
using System.Linq;

public class Dizi
{
    //Dizi sınıfının özellikleri ile sınıf oluşturalım.
    public string Ad { get; set; }  
    public int YapimYili { get; set; }  
    public string Tur { get; set; }  
    public int BaslangicYili { get; set; }  
    public string Yoneten { get; set; }  
    public string Platform { get; set; }  

    //Yeni Dizi nesnesi oluşturulurken bu metod çağrılır. Constructor.
    public Dizi(string ad, int yapimYili, string tur, int baslangicYili, string yoneten, string platform)
    {
        Ad = ad;
        YapimYili = yapimYili;
        Tur = tur;
        BaslangicYili = baslangicYili;
        Yoneten = yoneten;
        Platform = platform;
    }
}

public class KomediDizisi
{
    //Komedi türündeki dizilere ait sınıfın özellikleri
    public string Ad { get; set; }  
    public string Tur { get; set; }  
    public string Yoneten { get; set; } 

    //Yeni KomediDizisi nesnesi oluşturulurken bu metod çağrılır. Constructor.
    public KomediDizisi(string ad, string tur, string yoneten)
    {
        Ad = ad;
        Tur = tur;
        Yoneten = yoneten;
    }
}

public class Program
{
    public static void Main()
    {
        //Kullanıcının girdiği dizi nesnelerini tutacak olan liste
        List<Dizi> diziler = new List<Dizi>();

        //Kullanıcıdan dizi bilgilerini alıp listeye ekleyecek olan While döngüsü.
        while (true)
        {
            
            Console.WriteLine("Dizi Adı: ");
            string ad = Console.ReadLine();

            
            Console.WriteLine("Yapım Yılı: ");
            int yapimYili = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Türü: ");
            string tur = Console.ReadLine();

            
            Console.WriteLine("Yayınlanmaya Başlama Yılı: ");
            int baslangicYili = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Yönetmen: ");
            string yoneten = Console.ReadLine();

            
            Console.WriteLine("Yayınlandığı İlk Platform: ");
            string platform = Console.ReadLine();

            //Yeni bir Dizi nesnesi oluşturulur ve 'Add' ile listeye eklenir.
            diziler.Add(new Dizi(ad, yapimYili, tur, baslangicYili, yoneten, platform));

            //Kullanıcıya yeni bir dizi eklemek isteyip istemediği soralım.
            Console.WriteLine("Yeni bir dizi eklemek ister misiniz? (E/H)");
            string devamMi = Console.ReadLine();
            if (devamMi.ToUpper() != "E") break; //Kullanıcı "E" harfi dışında bir şey girerse döngü sonlanır.
        }

        //Komedi türündeki dizileri filtreleyerek yeni bir liste oluşturur.
        List<KomediDizisi> komediDizileri = diziler
            .Where(d => d.Tur.Contains("Komedi"))  //Komedi türündeki diziler seçilir.
            .Select(d => new KomediDizisi(d.Ad, d.Tur, d.Yoneten))  //KomediDizisi sınıfına dönüştürülür.
            .OrderBy(d => d.Ad)  //Diziler isimlerine göre sıralanır.
            .ThenBy(d => d.Yoneten)  //Yönetmenlerine göre sıralanır.
            .ToList();  //Listeye dönüştürülür.

        //Komedi dizilerinin bilgileri ekrana yazdırılır.
        Console.WriteLine("Komedi Dizileri Listesi:");
        foreach (var dizi in komediDizileri)
        {
            //Her bir komedi dizisi için ad, tür ve yönetmen bilgisi ekrana yazdırılır.
            Console.WriteLine($"Ad: {dizi.Ad}, Tür: {dizi.Tur}, Yönetmen: {dizi.Yoneten}");
        }
    }
}
