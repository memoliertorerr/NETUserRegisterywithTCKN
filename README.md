# .NET TCKN Kullanıcı Kayıt ve Yönetim Sistemi

Bu proje, ASP.NET Core ve React kullanarak oluşturulmuş basit bir kullanıcı kayıt ve yönetim sistemidir. Proje, kullanıcıların eklenmesi, listelenmesi, güncellenmesi ve silinmesi gibi temel CRUD (Create, Read, Update, Delete) işlemlerini desteklemektedir. Ayrıca, her kullanıcının T.C. Kimlik Numarası (TCKN) doğrulaması yapılmaktadır.

## Özellikler

- **Kullanıcı Ekleme**: Yeni kullanıcılar ekleyebilirsiniz.
- **Kullanıcı Listeleme**: Mevcut kullanıcıları görüntüleyebilirsiniz.
- **Kullanıcı Güncelleme**: Var olan kullanıcı bilgilerini güncelleyebilirsiniz.
- **Kullanıcı Silme**: Kullanıcıları silebilirsiniz.
- **TCKN Doğrulama**: Eklenen veya güncellenen her kullanıcının TCKN'si geçerlilik kontrolünden geçer.

## Teknolojiler

- **Backend**: ASP.NET Core (.NET 8 SDK) (8.0.406)
- **Frontend**: React (Node.js v22.14.0)
- **Veritabanı**: SQLite (Entity Framework Core ile)
- **Geliştirme Ortamı**: Windows on ARM

## Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 
- [Node.js v22.14.0](https://nodejs.org/en/download/)
- [SQLite](https://www.sqlite.org/download.html)

## Kurulum ve Çalıştırma

### 1. Depoyu Klonlayın

```
git clone https://github.com/memoliertorerr/NETUserRegisterywithTCKN.git
cd NETUserRegisterywithTCKN
```

### 2. Backend (ASP.NET Core) Kurulumu

Proje dizinine gidin:
```
cd UserRegisteryNET
```

Gerekli bağımlılıkları yükleyin:
```
dotnet restore
```

Veritabanı migrasyonlarını uygulayın:
```
dotnet ef database update
```

API sunucusunu başlatın:
```
dotnet run
```

API varsayılan olarak çalışacağı adres, launchsettings.json adresine bulunmaktadır.

### 3. Frontend (React) Kurulumu

React istemci dizinine gidin:
```
cd ../reactclient
```

Gerekli paketleri yükleyin:
```
npm install
```

React uygulamasını başlatın:
```
npm start
```

React uygulaması varsayılan olarak http://localhost:3000 adresinde çalışacaktır.

## Klasör Yapısı

- **UserRegisteryNET/**: ASP.NET Core API projesi
- **reactclient/**: React istemci uygulaması

## Önemli Notlar

- node_modules, bin ve obj klasörleri projede bulunmaktadır. Projeyi dağıtmadan önce bu klasörleri kaldırmanız önerilir.
- Proje, Windows on ARM mimarisi üzerinde geliştirilmiştir. Farklı platformlarda uyumluluğu test edilmemiştir.
- TCKN doğrulaması için kullanılan algoritma, temel bir kontrol sağlamaktadır. Gerçek uygulamalarda ek doğrulama adımları eklemeniz gerekebilir.

## Katkıda Bulunma

1. Bu repo'yu fork edin
2. Yeni bir özellik dalı oluşturun (`git checkout -b yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Dalınızı push edin (`git push origin yeni-ozellik`)
5. Pull Request oluşturun

## İletişim

Herhangi bir soru veya öneriniz varsa, lütfen GitHub üzerinden iletişime geçin.
