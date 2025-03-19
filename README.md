                                                    Ege Denizi Balıkları Listesi Uygulaması
Proje Açıklaması:
Bu proje, Ege Denizi'nde bulunan balık türlerinin listelenmesi ve çeşitli veri yapıları üzerinde işlenmesi amacıyla geliştirilmiştir.
C# dili kullanılarak balık türleri ile ilgili bilgiler Generic List, Stack, Queue ve Priority Queue veri yapıları içerisinde modellenmiş ve farklı işlemler gerçekleştirilmiştir.
Projede, balikturleri.com web sitesinden alınan veriler kullanılmıştır.

İçerik ve Özellikler:
EgeDeniziB Sınıfı ve Generic List Uygulaması
EgeDeniziB isminde bir sınıf tasarlanmıştır ve şu alanları içermektedir:

Balık_Adı: Balığın ismi.
Diğer_Adı: Balığın varsa diğer adı.
Boyut: Balığın boyut bilgisi (metre, cm vb.).
Bilgi: Balık hakkında genel bilgiler.
Ortam: Balığın yaşadığı denizler (Ege, Akdeniz, Karadeniz vb.) — List<string> yapısı ile tutulmuştur.
Veriler kod içerisinde string manipülasyonları ile ayrıştırılarak EgeDeniziB sınıfı nesneleri oluşturulmuş ve toplamda 38 balık bilgisi içeren bir Generic List yapısına eklenmiştir.
Daha sonra, bu 38 balık, 4 farklı grup halinde (her biri içinde 10'ar balık olacak şekilde) bir Generic List dizisine bölünerek gruplandırılmıştır.
Her bir grup içerisindeki balık bilgileri ve grupta kaç balığın "Diğer_Adı" olduğu bilgisi ekrana yazdırılmıştır.

Yığın (Stack) ve Kuyruk (Queue) Uygulaması:
Yığın (Stack): EgeDeniziB nesneleri Stack veri yapısına eklenmiş ve ardından tüm balıklar yığından çıkarılarak bilgileri ekrana yazdırılmıştır.
Kuyruk (Queue): Aynı işlemler FIFO yapısındaki Kuyruk veri yapısında gerçekleştirilmiş ve tüm balıklar kuyruğa eklenip çıkarılarak bilgileri yazdırılmıştır.

Öncelikli Kuyruk (Priority Queue) Uygulaması:
Öncelikli Kuyruk: Balık nesnelerini içeren bir Priority Queue veri yapısı geliştirilmiştir.
Eleman ekleme işlemi O(1) karmaşıklığındadır (listenin sonuna eklenir).
Silme işlemi sırasında alfabetik olarak adı en küçük olan balık bulunup kuyruktan silinir.
Kuyrukta tutulan tüm balıklar alfabetik sıraya göre silinerek ekrana yazdırılmıştır.
Market Kuyruğu ve Öncelikli Kuyruk Simülasyonu
Market Kuyruk Simülasyonu: FIFO kuyruğu kullanılarak, sepetlerinde farklı sayıda ürün olan müşterilerin işlem süreleri hesaplanmıştır (Her ürün 3.3 saniye sürede okutulmuştur).

Öncelikli Kuyruk Simülasyonu: Aynı müşteri verileri, ürün sayısına göre önceliklendirilen bir Priority Queue yapısında işlenmiş ve müşterilerin işlem tamamlanma süreleri hesaplanmıştır.

Sonuç Karşılaştırması:
FIFO kuyruğunda müşteriler geliş sırasına göre işlenirken,
Öncelikli Kuyruk yapısında daha az ürünü olan müşteriler öne alınmış ve ortalama işlem süresi azalmıştır.
Ancak, bu yöntem bazı müşterilerin bekleme süresini artırmıştır.

Kullanılan Teknolojiler:
C# (Console Application)
Object-Oriented Programming (OOP)
Veri Yapıları: Generic List, Stack, Queue, Priority Queue
String manipülasyonu
