# ILP ile Ders Programı Olusturma

Bu çalışmada Bitirme Projesi konusu olarak PuLP Kütüphanesi ile Integer Linear Programming tekniğini kullanarak üniversiteler için belirlenen kısıtlara göre otomatik ders programı oluşturan uygulama yazılmıştır.

Uygulamanın çalışması için öncelikle .Net Core 3.1 veya üzeri ve Python yüklü olmalı.Bilgisayarımızda Python Path Eklenmiş olmalıdır. 

Sonrasında aşağıdaki komutları sırası ile çalıştırıp ilgili paketler kurulmalıdır:

python -m pip install pulp

python -m pip install scikit-glpk

python -m pip install progressbar

Son olarak uygulamamızı Visual Studio  ile açıp çalıştırabiliriz.

## Solver olarak  PULP_CBC_CMD kullanılmıştır.Ancak solve_schedule.py dosyasında 266. satırdaki #print(pl.pulpTestAll()) açarsanız yada diğer yöntemlerle (dosya konumu üzerinden ulaşmak gibi) kendi sisteminizde hangi solver'ı seçebileceğinizi görüp istediğiniz solver'ı set edebilirsiniz.
