using System;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal bakiye = 25000;
            string sifre = "ab18";
            string inputSifre;
            int deneme = 0;

            while (true) // kartsız işlemi seçtiğimizde ana menüye getirmek için oluşturduğum sonsuz döngü
            {
                Console.WriteLine("Kartlı işlem için 1");
                Console.WriteLine("Kartsız işlem için 2");
                Console.Write("Seçiminizi yapın (1 ya da 2): ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    // Kartlı işlem
                    while (deneme < 3)
                    {
                        Console.Write("Şifre giriniz: ");
                        inputSifre = Console.ReadLine();

                        if (inputSifre == sifre)
                        {
                            Console.WriteLine("Hoşgeldiniz!");
                            AnaMenu(ref bakiye);
                            break;
                        }
                        else
                        {
                            deneme++;
                            Console.WriteLine($"Yanlış şifre! Kalan deneme hakkı: {3 - deneme}");
                        }
                    }
                    if (deneme == 3)
                    {
                        Console.WriteLine("3 deneme hakkınız doldu.");
                    }
                }
                else if (secim == "2")
                {
                    // Kartsız işlem
                    Console.WriteLine("Kartsız işlem seçtiniz. Bakım çalışmasındayız.");
                    Console.WriteLine("Ana menüye yönlendiriliyorsunuz...");
                }
                else
                {
                    Console.WriteLine("Yanlış tuşladınız!");
                }
            }
        }

        static void AnaMenu(ref decimal bakiye)
        {
            while (true)
            {
                Console.WriteLine("------TheMenu------");
                Console.WriteLine("Para Çekmek İçin 1");
                Console.WriteLine("Para Yatırmak İçin 2");
                Console.WriteLine("Para Transferleri İçin 3");
                Console.WriteLine("Eğitim Ödemeleri İçin 4");
                Console.WriteLine("Ödemeler İçin 5");
                Console.WriteLine("Bilgi Güncelleme İçin 6");
                Console.WriteLine("Çıkmak İçin 0");
                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        ParaCek(ref bakiye);
                        break;
                    case "2":
                        ParaYatir(ref bakiye);
                        break;
                    case "3":
                        ParaTransferleri(ref bakiye);
                        break;
                    case "4":
                        Console.WriteLine("Eğitim Ödemeleri sayfası arızalı.");
                        break;
                    case "5":
                        OdemeYap(ref bakiye);
                        break;
                    case "6":
                        SifreDegistir();
                        break;
                    case "0":
                        Console.WriteLine("Çıkış yapılıyor....");
                        return;
                    default:
                        Console.WriteLine("Yanlış tuşladınız!");
                        break;
                }
            }
        }

        static void ParaCek(ref decimal bakiye)
        {
            Console.Write("Çekmek istediğiniz tutar: ");
            decimal miktar = decimal.Parse(Console.ReadLine());

            if (miktar <= bakiye)
            {
                bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Kalan bakiye: {bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        static void ParaYatir(ref decimal bakiye)
        {
            Console.Write("Yatırmak istediğiniz tutar: ");
            decimal miktar = decimal.Parse(Console.ReadLine());
            bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {bakiye} TL");
        }

        static void ParaTransferleri(ref decimal bakiye)
        {
            Console.WriteLine("Başka Hesaba EFT için 1");
            Console.WriteLine("Başka Hesaba Havale için 2");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            Console.Write("Göndermek istediğiniz tutar: ");
            decimal miktar = decimal.Parse(Console.ReadLine());
            if (miktar > bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
                return;
            }

            if (secim == "1")
            {
                Console.Write("EFT numarası giriniz (TR ile başlamalı ve 14 haneli): ");
                string eFtn = Console.ReadLine();
                if (eFtn.StartsWith("TR") && eFtn.Length == 14)
                {
                    bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL EFT işlemi gerçekleştirildi. Kalan bakiye: {bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Geçersiz EFT numarası!");
                }
            }
            else if (secim == "2")
            {
                Console.Write("Hesap numarası giriniz (11 haneli): ");
                string hesapNo = Console.ReadLine();
                if (hesapNo.Length == 11)
                {
                    bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL havale işlemi gerçekleştirildi. Kalan bakiye: {bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Geçersiz hesap numarası!");
                }
            }
        }

        static void OdemeYap(ref decimal bakiye)
        {
            Console.WriteLine("Elektrik Faturası İçin 1");
            Console.WriteLine("Telefon Faturası İçin 2");
            Console.WriteLine("İnternet Faturası İçin 3");
            Console.WriteLine("Su Faturası İçin 4");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            Console.Write("Fatura tutarını giriniz: ");
            decimal tutar = decimal.Parse(Console.ReadLine());

            if (tutar <= bakiye)
            {
                bakiye -= tutar;
                Console.WriteLine($"{tutar} TL ödendi. Kalan bakiye: {bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        static void SifreDegistir()
        {
            Console.Write("Yeni şifreyi giriniz: ");
            string yeniSifre = Console.ReadLine();
            Console.WriteLine("Şifre başarıyla değiştirildi.");
        }
    }
}
