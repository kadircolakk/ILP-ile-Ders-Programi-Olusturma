# ILP ile Ders Programı Olusturma

Bu çalışmada Bitirme Projesi konusu olarak PuLP Kütüphanesi ile Integer Linear Programming tekniğini kullanarak üniversiteler için belirlenen kısıtlara göre otomatik ders programı oluşturan uygulama yazılmıştır.


![Ders Girisi](https://user-images.githubusercontent.com/65119767/123010596-92379180-d3c7-11eb-9b1d-cbbf8e96ddda.png)

•	Uygulamamızı çalıştırdığımızda karşımıza gelen ekran bu şekildedir.İlk kısımda ders programımızdaki derslerimizin sisteme kaydını yapıyoruz.

![Öğretmen Girisi](https://user-images.githubusercontent.com/65119767/123010634-a3809e00-d3c7-11eb-80f1-22c303b50adc.png)

•	İkinci kısımda öğretim görevlilerinin sisteme kaydını yapıyoruz.

![Öğrenci Girişi](https://user-images.githubusercontent.com/65119767/123010666-b72c0480-d3c7-11eb-9093-323ccaefc46b.png)

•	3. kısımda dersleri alacak öğrencilerimizi sisteme kayıt ediyoruz

![Ders-Öğretmen-Öğrenci Atamaları](https://user-images.githubusercontent.com/65119767/123010699-ca3ed480-d3c7-11eb-938f-00a3c5354afb.png)

•	4.kısımda öğretim görevlilerimizi verecekleri dersleri ile öğrencileri seçtikleri dersleri ile eşleştiriyoruz.Bu bölümde öğretmen ve öğrenci kısıtlarımız devreye giriyor.

![Ders Programı Oluşturma](https://user-images.githubusercontent.com/65119767/123010725-d88cf080-d3c7-11eb-9abe-d2e4523331af.png)

•	4.kısımda ki eşleştirmeleri yaptıktan sonra Report bölümümüzde program istenilen günü seçip Get dediğimizde bize girdiğimiz veriler eşliğinde bir ders programı oluşturuyor.

![Program Kısıtları Oluşturma](https://user-images.githubusercontent.com/65119767/123010736-e17dc200-d3c7-11eb-8c51-bf5ef39f2853.png)

•	Eğer bu ders programına  kısıtlar koymak istiyorsak örneğin şekilde görüldüğü gibi Algoritma dersini pazartesi günü sabah 8.00 ‘a Olasılık dersini 12.00 a atamak gibi bu kısıtları burada belirliyoruz.

![Kısıtlara Göre Program Oluşturma](https://user-images.githubusercontent.com/65119767/123010759-eb072a00-d3c7-11eb-9c22-84cc8ee600cb.png)

•	Son olarak Report bölümünden tekrar kısıt belirlediğimiz günlere ait ders programını oluşturmasını söylediğimiz de  istediğimiz derslerin istediğimiz saatte olduğunu gördüğümüz kısıtlarımızı sağlayan bir program üretmiş oluyoruz.

## Dikkat Edilmesi Gerekilenler

Öncelikle .Net Core 3.1 veya üzeri ve Python yüklü olmalı.Bilgisayarımızda Python Path Eklenmiş olmalıdır. 

Sonrasında aşağıdaki komutları sırası ile çalıştırıp ilgili paketler kurulmalıdır:

python -m pip install pulp

python -m pip install scikit-glpk

python -m pip install progressbar

Son olarak uygulamamızı Visual Studio  ile açıp çalıştırabiliriz.

•	Solver olarak  PULP_CBC_CMD kullanılmıştır.Ancak solve_schedule.py dosyasında 266. satırdaki #print(pl.pulpTestAll()) açarsanız yada diğer yöntemlerle (dosya konumu üzerinden ulaşmak gibi) kendi sisteminizde hangi solver'ı seçebileceğinizi görüp istediğiniz solver'ı set edebilirsiniz.Son olarak uygulamamızı Visual Studio  ile açıp çalıştırabiliriz.
