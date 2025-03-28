﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {

        string balikBilgileri = @"
            1. Akya Balığı
Carangida familyasının bir üyesi olan akya balığı, boyutları ve zevkli avcılığı ile olta balıkçılarının avlanırken en çok heyecanlandığı deniz balıklarından biridir. Akya olarak bilinen bu tür, aynı zamanda liça balığı olarak da adlandırılır.

Maksimum yetişkin boyutları, 200 cm uzunluk ve 50 kg ağırlıktır. Ancak, genellikle Ege denizinde bulunanların 120 cm civarına kadar büyüdükleri görülmüştür.

Üreme dönemleri olan Mayıs ve Ağustos arasında yumurtlamak için gittikleri nehir birleşimlerinde kefaller ve sardalyaları yiyerek güç toplarlar. Ana besinleri kefal yavrularıdır.

Nehir ağızlarına yakın alanlarda daha küçük boyuttakiler bulunurken büyük boyutlu akyalar, 40-50 metre derinlikte ve kıyıya uzak olmayan alanlarda yaşar.

2. Yaygın Aslan Balığı (Şeytan ateş balığı)
Hint-Pasifik bölgesine özgü bir aslan balığı varyantı olan bu tür, bilimsel olarak Pterois miles olarak adlandırılmıştır. Benzerlikleri dolayısıyla kırmızı aslan balığı ile karışıtırılırlar.

Hint-Pasifik bölgesinin yanı sıra ülkemiz sularından Ege denizinde de yaşadıkları biliniyor. Genel aslan balığı çeşitleri gibi bu tür de zehirli bir türdür.

Sırtında toplamda 13 adet diken bulunur. Renkleri kırmızı, gri veya ten rengi tonlarındadır. Geceleri avlandıklarından gündüzleri pek aktif bir tür değillerdir. Küçük kabuklular ve balıklar ile beslenirler.

Yetişkin boyutları 35 cm’ye kadar ulaşabilir. Ege balıkları arasında olsalar da yaygın olarak Kızıldeniz’de ve Endenozya sularında görülürler.
3. Barbunya (Barbun)
Gerçek adı Barbunya balığı olsa da halk arasında Barbun adı ile bilinir. Mullidae familyasından olan bu türe Mullus barbatus bilimsel adı verilmiştir.

Ege denizi gibi sıcak ve ılıman suların kıyıya yakın kumlu ve çamurlu bölgelerinde yaşarlar. Nadiren de olsa kayalık alanlarda görülmektedirler. Tekir balığına benzerlikleri ile bilinirler. Aradaki farkı anlamak için burun, göz altı ve sırt yüzgecine bakılmalıdır.

Maksimum boyutları 40 cm’dir ancak, Ege Denizi bölgesindekiler genellikle 18-20 cm civarında olurlar. Ege balıkları arasında ticari öneme sahip, eti lezzetli balıklardandır.

4. Çipura
Çipura balığı diğer adıyla Çupra, Ege denizi balık türleri arasında yer alsa da aslında Akdeniz bölgesinde de yaşarlar.

Ilıman sulara sahip bölgelerin, kumlu ve çamurlu bölgelerinde yaşarlar. Zaman zaman nehir ağızları ve lagünlerde bulundukları da olur.

200 gr ve üzeri olanlar Çipura, bunun altında olanlar ise Lidaki olarak isimlendirilir. Kuvvetli bir çeneye sahiptir ve bu sayede kabukluları kolayca yiyebilir.

Avlanmak isteniyorsa yaz aylarında kıyıya yakın, kış aylarında 30-40 metre derinlikte avlanabilirler. Kışın boyut olarak daha iri Çipuralar daha derin noktalara inerler. Ticari değeri yüksek ve eti oldukça lezzetli ege denizi balıklarındandır.

5. Çitari (Sarpa)
Görüntü olarak Çipura balığına çok benzerdir. Halk arasında Sarpa balığı olarak bilinirler. Yüzeyden 70 metre derinliğe kadar uzanan yaşam alanları vardır.

Maviye çalan gri renkli üst kısımları, gümüş renkli yan kısımları vardır. Maksimum olarak 51 cm uzunluk ölçülmüş olup, genellikle 15-30 cm civarında görülürler.

Ege denizi balık türleri arasında ticari değeri yoktur. Yapılan araştırmalarda tam olarak tespit edilemese de balığın tükettiği bir alg neticesinde, sarpa yiyen insanlarda halüsinojenik balık sarhoşluğu denilen rahatsızlığa sebep olur.

6. Çizgili Hani Balığı (Yazılı Hani)
Hani balığı, Orfoz’un da içinde bulunduğu Serranidae familyasından ve Levreğin içinde bulunduğu Serraninae alt türünden bir balıktır. Bilimsel adı Serranus scriba’dır. Çizgili hani balığı Ege denizi balıkları arasında yer almaktadır ancak hani balıkları genel olarak Akdeniz ve Karadeniz’de yaygındırar.

Ülkemiz denizlerinden Ege Denizi’ne özgü Çizgili hani, 5 ila 150 metre arasında yaşam alanına sahiptir. Gündüzleri kayalıkların oluşturduğu mağaralarda geçirirken, alacakaranlık ve geceleri avlanmak için ortaya çıkar.

Genellikle yalnız yaşadıkları görülse de küçük sürüler halinde yüzdüklerine de rastlanmaktadır. Uzunlukları en fazla 25 cm’ye ulaşır. Kabuklular, kafadanbacaklılar ve küçük balıklar ile beslenir. Ticari değeri olmayan, eti lezzetli Ege balıklarından biridir.

7. Dikenli vatoz
Dikenli vatoz, Dasyatidae familyasından bir vatoz balığı türüdür. Akdeniz ve Karadeniz bölgelerimizde de görülen bu tür, daha fazla görülmesi sebebiyle Ege Denizi balık türleri arasında bulunmalıdır.

Çok derin sularda değil, genellikle 60 metre civarı derinlikte ve çamurlu alanlarda yaşarlar. Ana besinleri dipte yaşayan kabuklu türleridir. Ek olarak yumuşakçalar, solucanlar ve küçük balıklarla da beslenir.

Ege denizinde bulunan dikenli vatozlar, genellikle 40-45 cm civarında veya daha küçük boyuttadır. Tırtırlı kuyruk ve iğneleri yüzünden insanlar için tehlikeli balık türleri arasındadır. Ticari değeri yoktur.

8. Eşkina
Eşina balığı, Sciaenidae familyasından bir deniz balığı türüdür. Bilimsel adı Sciaena umbra olan bu tür, Akdeniz ve Ege Denizi bölgelerimizde bulunmaktadır. Eşkina balığı amatör avcılık yapanların sıklıkla karşılaştığı bir türdür.

Yavru eşkinalar kıyı şeritlere yakın nehir ağızlarında yaşarken, yetişkinler 5 metre ile 200 metre arasında yaşarlar. Ege balıkları listemize dahil ettiğimiz eşkina, en fazla 60 cm boyuta ulaşabilir ancak, ülkemiz sularında genellikle 30-40 cm civarında görülürler.

Bu balığı sıradışı kılan bir özelliği de vardır. Balığın kafasından, alın bölgesinden 1 cm çapında taş çıkar. Bilimsel olarak kanıtlanmamış olsa da bu taş limon ile eritilerek tüketildiğinde böbrek taşı rahatsızlığına iyi geldiği düşünülür.

Ticari değer açısından orta seviyelerdedir. Genellikle balık lokanlarında servis edilen, lezzetli bir türdür.

9. Horozbina Balığı
Horozbina, Blenniidae familyasından 900 civarı alt türe sahip, hem tuzlu hem de tatlı sularda (küçük bir bölümü) yaşayan alt varyantlara sahip balık türlerinin ortak adıdır.

Horozbina tür adı altında 150 farklı cins ve 900 civarı da varyant tanımlanmıştır. Tatlı su blennysi olarak bilinen bir türü, nadiren de olsa akvaryumlarda beslenmektedir.

Genellikle küçük boyutlara sahip olabilen bu balığın, yılan balığına benzer varyantlarıyla 55 cm boyutuna ulaştığı görülmüştür. İri bir göz ve ağız yapısına sahiptir.

Zamanlarının büyük kısmını deniz tabanında ve kayalık yarıklarında geçirirler. Ticari değeri olmayan, Akdeniz ve Ege Denizi balıklarından biridir.

10. İskaroz (Papağan Balığı)
Genellikle ılıman ve sıcak sulara sahip denizlerde yaşarlar. Bilimsel adı Sparisoma cretense olan tür Scaridae familyasındandır.

Parlak renklere sahip bir balıktır. Görünüşü itibariyle sazan balığının tropik halini andırır. Papağan isminin verilmesi ağızlarının papağan gagasına benzemesindendir.

Erkekler daha koyu tondaki renklere sahipken dişiler, kırmızı-turuncu tonlarındadır. Zamanlarının çoğu mercan resiflerinde geçer. Burada deniz yosunu ile beslenirler.

Yetişkin dönemlerinde en fazla 50 cm olabilirler ancak, ülkemizdeki iskaroz balıkları 20-30 cm civarındadır. Ticari değeri bulunmayan iskarozun eti orta lezzettedir.

11. İskorpit Balığı
İskorpit, Ege balıkları arasında zehirli türlerden biridir. Yüzgeçlerinde bulunan dikenlere dokunulduğunda kişiyi zehirler ve bölgede kızarıklık, şişlik görülür.

Bu etki 2-3 gün devam eder. Amonyak kullanılarak tedavi edilebilir. Özellikle amatör balıkçılar tarafından kırlangıç balığı ile karıştırılıp yaralanmalara sebep olmaktadır. Tutulduğunda dikenlerine dokunmamaya dikkat edilmelidir.

Kayıt edilmiş maksimum uzunluk 37 cm iken, ülkemiz sularında yetişkin olanları 20-25 cm civarında görülürler. Akdeniz, Karadeniz ve Ege denizi balık türlerinden biridir.

İskorpit, zehirli balıklardan biri olsa da eti lezzetli olan ve barındırdığı vitamin ve yağlar ile insan sağlığına çok yararlı bir balıktır.

12. İsparoz (İspari Balığı)
Sparidae familyasından olan isparinin bilimsel adı Diplodus annularis’dir. Bu balık genellikle ılıman sahil bölgelerine yakın alanlarda yaşar. Ege balıklarından biridir ve diğer denizlerimizde de bulunur.

Maksimum 25 cm uzunluğa erişebilirler. Ülkemiz sularında 15-18 cm civarında ispariler bulunur. Sportif balıkçılıkta sevilen bir balık türüdür. Genç olanları kışın lagünlere giderek beslenirler. Karides, yavru balıklar ve kurtçuklar ana besinleridir.

Ticari değeri düşüktür ve genellikle olta balıkçılığı ile avlanırlar. Eti lezzetli ve az kılçıklı bir balıktır.

13. İzmarit Balığı (İstrongilos)
İzmarit balığı, Ege denizi balık türleri arasında yer alıyor ancak Akdeniz bölgelemizde daha yaygın bulunur. Bilimsel adı Spicara smaris olan izmarit, Sparidae familyasından bir deniz balığı türüdür.

Ilık sulara sahip bölgelerin kayalık, çamurlu dip kısımlarında yaşamaktadır. En fazla 25 cm boyutuna (erkekler) ulaşan bu tür, ülkemizde genellikle 15 cm civarında görülür.

Ülkemiz sularında iki tür izmarit yaşamaktadır; İstargilos ve Menekşe izmarit. Eti lezzetli bir balıktır ve genellikle önce pişirilip sonra ayıklanır.


14. Kalkan Balığı
Kalkan balığı (Scophthalmus maximus), gözleri vücudunun solunda olan, Scophthalmidae familyasından bir deniz balığı türüdür. Vücudunun sağını deniz tabanına yatmak için kullanır.

Ülkemizin tüm denizlerinde yaşayan bir türdür. Yaşam alanları 20 metre ile 70 metre arasındadır. Tipik balık türlerinden farklı olarak yuvarlak bir vücuda sahiptir. Maksimum 1 metre uzunluğa erişebilirler. Ülkemiz denizlerinde ise yetişkinler 60-70 cm civarında görülür.

Henüz yavruyken gözleri sağda ve solda ayrı durmaktadır. 8-10 cm civarına ulaştıklarında sağ göz vücutlarının sol tarafına kaymaya başlar.

Ticari değeri yüksek, eti çok lezzetli ege balıkları arasındadır.

15. Karagöz Balığı
Karagöz balığının Çipura ile yakın akrabalığı bulunmaktadır. Sarmos, mırmır, sivri gaga gibi birkaç çeşidi vardır.

Maksimum 50 cm boyutuna ulaşabilir. Ülkemizde Akdeniz, Karadeniz ve Ege Denizi bölgelerimizde yaşarlar. Bu bölgelerde yaygın olarak 25 cm civarında görülür. Kayalık, kumlu alanlarda yaşarlar.

Görünüşü ile Çupra balığına benzemesinin yanı sıra lezzet olarak da benzerdir. Serin dönemlerde tüketimesi tavsiye edilir bu dönemlerde eti daha yağlı ve lezzetli olmaktadır.

16. Kolyoz Balığı
Uskumsugillerden olan kolyoz, Scombridae familyasından bir deniz balığıdır. Uskumruya çok benzeyen bir balıktır. Kuyruk yüzgecine bakılarak ayırt edilebilir. Bu türün kuyruk yüzgecinin ucu daha sivridir.

Genç olanlar kıyılara yakın kumlu alanlar ve yosun yataklarında yaşarken, yetişkin olanlar daha açıkta derin sularda yaşar.

Sürüler halinde yaşamlarını sürdürürler. En fazla 50 cm uzunluğa kadar büyüyebilir ancak ülkemiz sularında görülen yetişkinler ortalama 20-25 cm civarındadır. Eti lezzetli ege balıkları arasındadır.

17. Kırma Mercan
Kırma mercan balığı (Pagellus erythrinus) çipura ailesinden, Sparidae familyası mensubu, Akdeniz ve Ege balıklarından biridir. Özellikle Akdeniz ülkelerinde bolca tüketilen lezzetli bir balık türüdür.

İnce, oval yapıda bir vücuda sahip olan kırma mercan en fazla 50 cm boyutuna ulaşabilir. Genel olarak 15-30 cm arasında görülürler. Bu tür bir hermafrodittir; sonradan cinsiyet değiştirebilirler.

Genellikle hayatlarının ilk yıllarında dişi, sonraki yıllarında ise erkek olurlar. Hepçil bir balıktır ve ana besinleri küçük balıklar ve omurgasızlardan oluşur. Akdeniz ülkelerinde ticari değere sahip, lezzetli bir balıktır.

18. Lahoz Balığı (Grida balığı)
Lahoz balığı Hani balıkları ailesinden, Ege ve Akdeniz bölgelerinde bulunan bir türdür. Bu tür iri ege balıkları arasındadır. En fazla 125 cm uzunluk ve 25 kg ağırlığa ulaşabilirler.

People Also Read  Hayalet Balığı
Yaşam alanları 20-250 metre arasında kayalık, çakıllı ve taşlı alanlardır. Son derece yırtıcı etçil balıklardan biridir. Yiyebileceği her türlü balık, omurgasız ve kabuklu türleri ile beslenir.

Orfoz balığı ile yakından akrabadır ve ticari değeri bulunduğu bölgeye göre değişir. Özellikle Akdeniz bölgesinde etinin lezzetli ile bilinir.

Bu tür birkaç farklı isimle bilinir.

19. Levrek
Birçoğumuzun da yakından tanıdığı Levrek balığı, Dicentrarchus familyasından bir balık türüdür. Bilimsel olarak ilk kez 1758 yılında Dicentrarchus labrax olarak tanımlanmıştır.

Şimdiye kadar kayıt altına alınan en büyük boyutları 1m ve 12 kg olsa da yaygın olarak 50 cm ve 5 kg civarında görülürler. Akdeniz ve Ege başta olmak üzere tüm denizlerimizde yaşadıkları biliniyor.

Haliçler, lagünler, akarsuların denize döküldüğü yerler ana yaşam alanlarıdır. Kısa bir süreliğine tatlı sulara geçtikleri de bilinmektedir (tatlı su levreklerinin dışında).

Ticari değeri yüksek, etinin lezzetini kanıtlamış Ege denizi balık türlerinden biridir.

İnsanlar İçin Tehlikeli Deniz Balıkları
20. Lipsoz Balığı
Lipsoz balığı, görünümü ile iskorpit balığına benzeyen Scorpaenidae familyasından bir balık türüdür. Lipsos ismiyle de bilinen bu türün bilimsel adı Scorpaena scrofa’dır.

Ülkemiz sularında Akdeniz ve Ege Denizi türlerinden biridir, Karadeniz bölgesinde bulunmaz. S. porcus türü Karadeniz bölgesinde görülebilir. İskorpit balığı gibi bu balık da zehirli balıklardan biridir.

Vücut rengi kiremit rengi tonlarından, pembemsi tonlara kadar değişebilir. En fazla 50 cm ve 3 kg ağırlığa ulaştığı biliniyor ancak, sularımızdaki yetişkin lipsoz balıkları genellikle 25-30 cm civarındadır.

Yenilebilir balıklardan biridir, en çok çorba ve buğulama yapıldığında lezzetlidir.

21. Lüfer Balığı
Lüfer,  Pomatomidae familyasından bir balık türüdür. Ege balıkları arasında ekonomik değeri yüksek ve çok lezzetli bir balıktır. Bilimsel adı Pomatomus saltatrix olan lüfer, ülkemizin tüm denizlerinde bulunmaktadır.

Maksimum ölçülen boyutları 120 cm ve 14 kg’dır. Bölgemizde yaşayan yetişkin lüferler 30-60 cm arasında bulunurlar. Lüfer, gevşek ve küçük gruplar halinde yaşayan yırtıcı deniz balıklarından balıklardan biridir.

Lüfer çeşitli boyutlara göre farklı isimler almıştır:

Sarıkanat: 18 – 25 cm boyutlarında olan lüfer yavrusudur. 18 cm altının avlanması veya satılması yasaktır.
Lüfer: 28 – 35 cm boyutlarına ulaştığında lüfer adı verilir. Avlamak ve satış serbesttir.
Kofana: 35 cm üzerine çıkan lüferlere bu ad verilmiştir. Avlanması ve satılması serbesttir.
Sırtıkara: 50 cm’nin üzerindeki lüferlere verilmiş isimdir. Ülkemiz denizlerinde uzun süredir görülmemiştir. Avlamak ve satışını yapmak serbesttir.
Lüfer bir dönem koruma altına alınarak avlanılması ve satışı yapılması yasaklanmış balık türlerindendir. Ancak, günümüzde yasak bitirilerek 18 cm ve üzeri olanların avlanması ve satılması serbest bırakılmıştır.

22. Mahmuzlu camgöz köpek balığı
Mahmuzlu camgöz Squalidae familyasından, Akdeniz ve Ege Denizi başta olmak üzere ülkemiz sularında bulunmaktadır. Ülkemizde tüketilmese de Avrupa ülkelerinde tüketildiği bilinmektedir.

Ana besinleri balık sürüleri ve ahtapotlar olan bu türün, profesyonel balıkçıların ağlarına ciddi hasar verdiği biliniyor. Nadiren de olsa dip balıklarını avlayan amatör balıkçıların oltasına takıldığı görülmektedir.
En fazla 150 cm ve 10 kg boyutlarına eriştikleri tespit edilmiştir ancak, genellikle 80 cm ve 4 kg civarlarına ulaşırlar. Ticari değeri yoktur.

23. Mandagöz Mercan Balığı
Kırmızı (kızıl) çipura olarak da bilinen mandagöz mercan (Pagellus bogaraveo) Sparidae familyasından bir deniz balığıdır.

Akdeniz başta olmak üzere ılıman ve sıcak denizleri tercih eden bir türdür, ılıman ısısıyla Ege balıklarından da biridir. Bulunduğu bölgeye göre en fazla 400 ila 700 metre derine inebilen bir balıktır.

Kaydedilen en büyük uzunluk 70 cm, yaygın olarak da 30 cm ve 4 kg’dır. Eti lezzetli, ızgarada pişilmesi tercih edilen bir mercan varyantıdır.

24. Melanur Balığı (Melanurya)
Ege denizi balıkları, Melanur balığıPin
Melanur diğer adıyla Melanurya, Sparidae familyasından bir deniz türüdür. Ülkemizde Akdeniz, Marmara ve Ege bölgerinde bulunur. Bilimsel adı Oblada melanura olan melanur, Ege denizi balık türleri arasında yer alıyor.
Çok iri boyutlara ulaşabilen bir tür değildir. Kaydedilen maksimum boyutları, 38 cm ve 930 gr’dır. Ülkemiz sularında yaygın olarak 20 cm civarında görülürler. Hepçil olan türün ana besini omurgasızlardır.
Eti lezzetli türlerden biri olan melanurun ticari değeri orta seviyelerdedir.

25. Mersin Balığı
Mersin balığı birçok farklı türün ortak adıdır. Mersin balığı adı altında 19 farklı cins balık bulunmaktadır. Görünümlerindeki ufak farklılar ile ayrılırlar. Bu balıklar Acipenseridae familyasına aittir. Akdeniz bölgemizde daha yaygın olan tür, Ege balıkları arasında da bulunmaktadır.

Türe göre boyutları farketmektedir. Yetişkin mersin balıkları ortalama 140 ila 300 cm uzunluğa, 100 ila 200 kg ağırlığa ulaşabilirler. Şimdiye kadarki ölçülen en büyük boyutlar; 7.2 metre ve 1571 kilogramdır.

Mersin balığı altında bulunan 19 farklı tür şu şekildedir:

Sibirya mersini
Kısa burunlu mersin balığı
Yangtze mersin balığı
Göl mersin balığı
Rus mersin balığı
Yeşil mersin balığı
Sakhalin mersin balığı
Japon mersin balığı
Adriyatik mersin balığı
Şip balığı
Körfez mersinbalığı
Atlantik mersin balığı
İran mersin balığı
Çuka balığı
Amur mersin balığı
Çin mersin balığı
Yıldızlı mersin balığı
Kolan balığı
Beyaz mersin balığı
26. Mürekkepbalığı

Mürekkepbalığı Cephalopoda (Kafadanbacaklılar) sınıfından, deniz türleri arasında olan bir yumuşakça türüdür. İkisi diğerlerinden daha uzun olan toplam 10 adet kolları vardır ve iç bölgelerinde çok sayıda vantuz bulunur.
Ege denizi balıkları arasında yer alan mürekkepbalığı, sıcak sularda yaşayan bir türdür. Bu türün boyutları çok değişkendir. Cinse göre 20 cm ile 17 metre arasında değişen çeşitleri vardır. Yaygın olarak yetişkin olanları 50-60 cm arasındadır.
Ticari değeri olan, eti lezzetli bir yumuşakça türüdür.

27. Mırmır Balığı
Sparidae familyasından olan mırmır balığı, ekonomik değeri yüksek lezzetli balık türlerinden biridir. Denizin diplerinde ve kumlu kısımlarda yaşayan mırmır balığı sıklıkla avlanan Ege balıkları arasındadır.

People Also Read  Balon Gözlü Japon Balığı
Ülkemizde Ege, Akdeniz ve Marmara bölgelerinde bolca bulunurlar. Ana besinlerini kabuklular, solucanlar ve yumuşakçalar oluşturur.

En fazla 55 cm ve 1 kg ağırlığa ulaşmaktadırlar ancak, yaygın boyutları 30 cm civarındadır. Ticari değeri yüksek Ege denizi balık türlerinden biridir.

28. Orfoz Balığı
Serranidae familyasından Orfoz, Taş hanisi adıyla da bilinir. Bilimsel adı Epinephelus marginatus’dur. Orfozlar hermafrodit (çift cinsiyetli) deniz balıkları arasındadır.

Orfoz balığı neslinin tükenmesiyle karşı karşıya olduğu için avlanması yasak türlerdendir. Ülkemizde Akdeniz ve Ege denizlerinin güney kısımlarında yaşarlar.

En fazla 140 cm ve 60 kg boyutlarına ulaşabilirler. Boyutları ile iri ege balıklarından biridir. Ülkemiz denizlerinde yaygın görülen boyutları ortalama 60 cm ve 15 kg’dır.

29. Orkinos (Ton balığı)
Çoğumuzun marketlerde konserve içerinde gördüğü Orkinos, Uskumrugiller (Scombridae) ailesinin üyesidir. Kendi aralarında farklı türlere sahip olan, Orkinos ortak adı verilen bu balık denizlerdeki en iri balıklardan biridir.

Ege denizi balıkları arasında en büyük türlerden biridir. Yetişkin bir ton balığı, 6 metre uzunluğa ve 1 ton ağırlığa ulaşmaktadır. Ancak, bu boyutlarda Orkinos bulma ihtimali çok düşüktür genellikle 3-4 metre ve 400-600 kg arasında avlanırlar.

Ekonomik değeri çok yüksek ve son deree lezzetli balıklardandır.

30. Pisi Balığı
Pisi balığı kalkan ile karıştırılabilir ancak resimlerine bakıldığında kolayca ayırt edilebilir. Pleuronectidae familyasından olan pisi balığının vücudu kalkana göre daha elips şeklindedir ve kalkanın sırtında olan düğme diye tabir edilen kemikli yapılar yoktur.

Yine pisi balığının gözleri de vücudun sağ tarafındadır. En fazla 60 cm boyut ölçülmüştür ancak, yaygın boyutları 30 cm civarındadır.

Ülkemizde Akdeniz, Ege, Karadeniz ve Marmara bölgelerimizde bulunur.


31. Sardalya Balığı
Saldalya hamsi ile yakından akraba, Clupeinae familyasından bir balık türüdür. Sürüler halinde kıyıya yakın geçerek göç ederek yaşamlarını sürdürürler.

Akdeniz ve Karadeniz’de daha yaygın görülen sardalya, Ege denizi balık türleri arasında da yer almaktadır. Denizlerimizde 15-20 cm boyutlara ulaşırlar ancak okyanus bölgelerindeki sardalyalar 30 cm uzunluğa kadar büyümektedir.

Ticari değeri çok yüksek, lezzetli balık türlerindendir.

32. Sargan Balığı (Zargana)

Tipik balık görünümünün dışında uzun ve ince bir vücuda sahip sargan (Belone belone), Belonidae familyasının üyesidir. Vücut yapıları sayesinde hızlı ve çevik deniz balıklarındandır.

Yaşadıkları bölgeye göre 1 metre uzunluğa erişmektedirler ancak Akdeniz ve Ege denizlerimizde 60 cm civarına kadar büyümektedirler.

Ana besinleri küçük balıklardır ve hamsi, çaça gibi balık türleri ile beslenir. Ticari değeri yüksek, lezzetli Akdeniz ve Ege balıkları arasındadır.

33. Sargoz Balığı

Sargoz, Akdeniz ve Ege bölgelerinde sıklıkla Karagöz ile karıştırılır. Diplodus sargus bilimsel adı verilmiştir ve Sparidae ailesinden bir deniz balığı türüdür.

Bu balık bölgeye göre farklı isimler almıştır. Baltabaş, Sargos ve Ak Karagöz olarak da bilinirler. Ülkemizde Akdeniz ve Ege bölgelerimizde yaygındır.

Güçlü çeneye sahiptirler ana besinleri; kabuklular, yumuşakçalar ve deniz yosunları. Ekonomik değeri yüksek, lezzetli bir balıktır.

34. Sinarit Balığı

Sparidae familyasından olan Sinarit’in bilimsel adı Dentex dentex’dir. Akdeniz’de yaygındır ancak Karadeniz, Marmara ve Ege balıkları arasında da yer alırlar.

Taşlı ve kumlu bölgelerde 200 metre derinliğe kadar yaşarlar. Ana besinleri kafadanbacaklılar ve yumuşakçalardır. Genellikle yalnız yaşarlar ancak üreme dönemlerinde küçük sürüler halinde görülmektedirler.

1 metre uzunluğa, 20 kg ağırlığa ulaşırlar. Olta avcılığı son derece zevkli, eti lezzetli ama az bulunan bir balıktır.

35. Tekir Balığı
Tekir balığı ege balıklarıPin
Bilimsel adı Mullus surmuletus olan Tekir, Mullidae familyasından bir deniz balığıdır. Akdeniz, Karadeniz ve Ege denizi balık türleri arasındadır.

5 metrelik sığ sulardan 400 metre derinlikteki sulara kadar uzanan yaşam alanları vardır. Kaydedilmiş en büyük boyutları 40 cm ve 1 kg’dır ancak sularımızda yaygın olarak 25 cm civarında görülürler. Ticari değeri olan bir balıktır ve av balığı olarak da kullanılmaktadır.


36. Trakonya Balığı
Trakonya balığıPin
Trakonya balığı halk arasında dragon balığı olarak da bilinmektedir. Trachinidae ailesinden olan balığın bilimsel adı Trachinus draco’dur.

Vücudunda zehirli dikenlere sahiptir ve dokunulduğunda toksik bir madde salgılar. Zehirli Ege balıkları arasındadır. Zehri kuvvetlidir, uzuv kaybı veya kalp krizine neden olabilmektedir.

1 metre ile 150 metre arasında kumlu, çakıllı alanlarda yaşamaktadır. Küçük balıklar, omurgasızlar ve kabuklular ana besinleridir. En fazla 55 cm boyuta ulaşabilirler ve genellikle 25 cm civarında görülürler. Ticari değer yoktur.

37. Trança
Trança balığıPin
Ege balıkları arasında meşhurlaşmış türlerden biridir. Bölgede Çavuş, Antenli mercan, Altınkaş isimleri ile de bilinir. Bilimsel adı Pagrus caeruleostictus’dur ve mercan familyasından bir türdür.

Sığ ve sıcak sularda tek olarak yaşayan iri bir balıktır. Etçil bir balıktır ve kafadanbacaklılar, küçük balıklar ana besinleridir. Okyanuslara ve farklı denizlere sürekli göç eden balıklardandır.

Yetişkin boyutları 60-75 cm civarındadır ancak 1 metre üzerine de çıkabilmektedir. Ekonomik değeri yüksek, lezzetli bir balıktır.

38. Zurna Balığı
Zurna balığıPin
Zurna balığı (Scomberesox saurus), Scomberesocidae familyasından bir deniz balığıdır. Açık denizlerde yaşayan bu tür, Süveyş kanalının açılmasından sonra Akdeniz ve Ege denizlerinde görülmüştür.

En fazla 50 cm, ortamala 35 cm boyutlarındadır. Balık yavruları ve plankton ile beslenir. Avlanmadıkları için herhangi bir ticari değeri yoktur.

        ";


        List<EgeDeniziB> balikListesi = veriIsle(balikBilgileri);
        foreach (var item in balikListesi)
        {
            Console.WriteLine(item);
        }
        List<EgeDeniziB>[] balikGruplari = grupOlustur(balikListesi);
        //grupYazdir(balikGruplari);     // 1.Soru

        var data = stackEkle(balikListesi);
        //stackYazdir(data)                // 2.Soru a seçeneği

        var data2 = queueEkle(balikListesi);
        //queueYazdir(data2);              // 2.Soru b seçeneği

        var data3 = PQueueEkle(balikListesi);
        //data3.toString();                 // 3.Soru

        // 4.Soru a Şıkkı:
        musteriKuyruk<Musteri> kuyruk1 = new musteriKuyruk<Musteri>();

        kuyruk1.elemanEkle(new Musteri("Murat", 15));
        kuyruk1.elemanEkle(new Musteri("Bayram", 1));
        kuyruk1.elemanEkle(new Musteri("Ali Osman", 12));
        kuyruk1.elemanEkle(new Musteri("Mali", 8));
        kuyruk1.elemanEkle(new Musteri("Kemal", 7));
        kuyruk1.elemanEkle(new Musteri("Berfu", 4));
        kuyruk1.elemanEkle(new Musteri("Nur", 21));
        kuyruk1.elemanEkle(new Musteri("İrem", 3));
        kuyruk1.elemanEkle(new Musteri("Barış", 2));
        kuyruk1.elemanEkle(new Musteri("Merdan", 6));
        kuyruk1.elemanEkle(new Musteri("Gülsüm", 5));
        kuyruk1.elemanEkle(new Musteri("Fatmagül", 9));
        kuyruk1.elemanEkle(new Musteri("İbo", 1));

        int beklemeSuresi = 0;

        while (!kuyruk1.bosMu())
        {
            Musteri m = kuyruk1.elemanSil();
            Console.WriteLine($"Müşteri Adı: {m.musteriAdi}, Bekleme Süresi: {beklemeSuresi}");
            beklemeSuresi += m.urunSayisi;
        }
        Console.WriteLine($"Toplam Bekleme Süresi: {beklemeSuresi}");

        



    }
    static List<EgeDeniziB> veriIsle(string veri)
    {
        // Düzenli ifadeyi tanımlıyoruz (numaralarla başlayan maddeleri yakalar)
        string pattern = @"\d+\.\s";
        // Düzenli ifadeye göre metni bölüyoruz
        string[] baliklar = Regex.Split(veri, pattern, RegexOptions.Multiline);

        List<EgeDeniziB> liste = new List<EgeDeniziB>(); //1.soru için        

        foreach (string balik in baliklar)
        {
            // İlk satır (ad ve diğer ad için)
            string ilkSatir = balik.Split('\n')[0].Trim();
            string balikAdi = ilkSatir.Split('(')[0].Trim();
            string digerAdi = ilkSatir.Contains("(") ? ilkSatir.Split('(')[1].Replace(")", "").Trim() : null;

            // Boyut bilgisi (boyut, cm, kg gibi ifadeleri içeren satırlar)
            string boyut = string.Join("\n", balik.Split('\n')
                .Where(s => s.Contains("cm") || s.Contains("kg") || s.Contains("metre")).Select(s => s.Trim()));

            // Bilgi (tüm metni alıyoruz ancak ilk satırı hariç tutuyoruz)
            string bilgi = string.Join("\n", balik.Split('\n').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()));

            // Ortam bilgisi (Ege, Akdeniz, Karadeniz gibi deniz isimlerini kontrol ediyoruz)
            List<string> ortam = new List<string>();
            if (bilgi.Contains("Ege")) ortam.Add("Ege");
            if (bilgi.Contains("Akdeniz")) ortam.Add("Akdeniz");
            if (bilgi.Contains("Karadeniz")) ortam.Add("Karadeniz");
            if (bilgi.Contains("Kızıldeniz")) ortam.Add("Kızıldeniz");
            if (bilgi.Contains("Hint-Pasifik")) ortam.Add("Hint-Pasifik");
            if (bilgi.Contains("Endenozya")) ortam.Add("Endenozya");

            // Yeni bir EgeDeniziB nesnesi oluşturuyoruz ve listeye ekliyoruz
            liste.Add(new EgeDeniziB(balikAdi, digerAdi, boyut, bilgi, ortam));
        }
        return liste;
    }
    static List<EgeDeniziB>[] grupOlustur(List<EgeDeniziB> liste)
    {
        // 10'luk gruplar halinde diziyi oluşturuyoruz
        List<EgeDeniziB>[] grupDizisi = new List<EgeDeniziB>[4];
        for (int i = 0; i < 4; i++)
        {
            grupDizisi[i] = liste.Skip(i * 10).Take(10).ToList();//(List<EgeDeniziB>) de olur
        }
        return grupDizisi;
    }
    static void grupYazdir(List<EgeDeniziB>[] grupListesi)
    {
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Grup {i + 1}:");
            foreach (var item in grupListesi[i])
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
    static void stackYazdir(myStack<EgeDeniziB> data)
    {
        for (int i = 0; i < data.maxSize; i++)
        {
            Console.WriteLine(data.peek());  //peek() methoduyla verileri tersten yazdırmak için peek methodunda --top yaptım.
        }                                    //Son eleman hariç yazdırıyor!!!

    }
    static myStack<EgeDeniziB> stackEkle(List<EgeDeniziB> balikListesi)
    {
        myStack<EgeDeniziB> stack = new myStack<EgeDeniziB>(balikListesi.Count);
        for (int i = 0; i < balikListesi.Count; i++)
        {
            stack.push(balikListesi[i]);
        }
        return stack;
    }
    static myQueue<EgeDeniziB> queueEkle(List<EgeDeniziB> balikListesi)
    {
        myQueue<EgeDeniziB> queue = new myQueue<EgeDeniziB>(balikListesi.Count);
        for (int i = 0; i < balikListesi.Count; i++)
        {
            queue.insert(balikListesi[i]);
        }
        return queue;
    }
    static void queueYazdir(myQueue<EgeDeniziB> data2)
    {
        for (int i = 0; i < data2.maxSize; i++)
        {
            Console.WriteLine(data2.peekFront());
        }
    }
    static PriorityQ PQueueEkle(List<EgeDeniziB> balikListesi)
    {
        PriorityQ pQueue = new PriorityQ();
        for (int i = 0; i < balikListesi.Count; i++)
        {
            pQueue.ekle(balikListesi[i]);
        }
        return pQueue;
    }

}
class EgeDeniziB
{
    public string balıkAdi { get; set; }
    public string digerAdi { get; set; }
    public string boyut { get; set; }
    public string bilgi { get; set; }
    List<string> ortam { get; set; }
    public EgeDeniziB() { }
    public EgeDeniziB(string balıkAdi, string digerAdi, string boyut, string bilgi, List<string> ortam)
    {
        this.balıkAdi = balıkAdi;
        this.digerAdi = digerAdi;
        this.boyut = boyut;
        this.bilgi = bilgi;
        this.ortam = ortam;
    }
    public override string ToString()
    {

        if (digerAdi is not null)

            return $"{balıkAdi}({digerAdi})\n" +
            $"BOYUT: {boyut}\n" +
            $"BİLGİ: {bilgi}\n" +
            $"ORTAM: {string.Join(",", ortam)} \n";
        else
            return $"{balıkAdi}\n" +
            $"BOYUT: {boyut}\n" +
            $"BİLGİ: {bilgi}\n" +
            $"ORTAM: {string.Join(",", ortam)}\n";

    }
}

class myStack<T>
{
    private T[] stackArray;
    private int top;
    public int maxSize;

    public myStack(int maxSize)
    {
        this.maxSize = maxSize;
        stackArray = new T[maxSize];
        top = -1;
    }

    public void push(T data)
    {
        stackArray[++top] = data;
    }
    public object pop()
    {
        return stackArray[top--];
    }
    public object peek()
    {
        --top;              //elemanları tersten yazdırabilmek için azalttım!!
        return stackArray[top];
    }
    public bool isEmpty()
    {
        return (top == -1);
    }
    public bool isFull()
    {
        return (top == maxSize - 1);
    }

}

class myQueue<T>
{
    public int maxSize;
    private T[] queArray;
    private int front;
    private int rear;
    private int nItems;

    public myQueue(int maxSize)
    {
        this.maxSize = maxSize;
        queArray = new T[maxSize];
        front = 0;
        rear = -1;
        nItems = 0;
    }
    public void insert(T data)
    {
        if (rear == maxSize - 1)
            rear = -1;
        queArray[++rear] = data;
        nItems++;
    }
    public T remove()
    {
        T temp = queArray[front++];
        if (front == maxSize)
            front = 0;
        nItems--;
        return temp;
    }
    public T peekFront()
    {
        front++;   //sırasıyla verileri ekrana yazdırmak için arttırdım.İlk veri boş olduğu için returnden önce artması sorun çıkarmıyor.
        return queArray[front];
    }
    public bool isEmpty()
    {
        return (front == 0);
    }
    public bool isFull()
    {
        return (nItems == maxSize);
    }
    public int size()
    {
        return nItems;
    }
}

class PriorityQ : EgeDeniziB
{
    public List<EgeDeniziB> queArray;
    public int nItems;

    public PriorityQ()
    {
        queArray = new List<EgeDeniziB>();
        nItems = 0;
    }
    public void ekle(EgeDeniziB data)
    {
        queArray.Add(data);
        nItems++;
    }
    public EgeDeniziB sil()
    {
        if (bosMu())
        {
            throw new InvalidOperationException("Kuyruk boş!");
        }
        else
        {
            int enKucukIndex = 0;
            // En küçük (alfabetik olarak önce gelen) elemanı bul
            for (int i = 1; i < nItems; i++)
            {
                if (string.Compare(queArray[i].balıkAdi, queArray[enKucukIndex].balıkAdi, StringComparison.Ordinal) < 0)
                {
                    enKucukIndex = i;
                }
            }
            // En küçük elemanı al ve diziden kaldır
            EgeDeniziB enKucukEleman = queArray[enKucukIndex];
            queArray.RemoveAt(enKucukIndex);
            
            return enKucukEleman; //silinen elemanı döndürür
        }

    }
    public bool bosMu()
    {
        return (nItems == 0);
    }
    public void toString()
    {
        foreach (var item in queArray)
        {
            Console.WriteLine(item.ToString());
        }
    }


}

class Musteri
{
    public string musteriAdi;
    public int urunSayisi;

    public Musteri(string musteriAdi, int urunSayisi)
    {
        this.musteriAdi = musteriAdi;
        this.urunSayisi = urunSayisi;
    }
}

class musteriKuyruk<T>
{
    public List<T> list;

    public musteriKuyruk()
    {
        list = new List<T>();
    }
    public void elemanEkle(T data)
    {
        list.Add(data);
    }
    public T elemanSil()
    {
        T gecici = list[0];
        list.RemoveAt(0);
        return gecici;
    }
    public int elemanSayisi()
    {
        return list.Count;
    }
    public bool bosMu()
    {
        return elemanSayisi() == 0;
    }
}



