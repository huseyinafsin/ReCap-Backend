using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    
    public static class Messages
    {
        public static string EntityAdded = "Added";
        public static string EntityUpdated = "updated";
        public static string EntityListed = "listed";
        public static string EntityFetched = "fetched";
        public static string EntityDeleted = "deleted";


        public static string CarAdded = "Araba eklendi";
        public static string BrandAdded = "Marka eklendi";
        public static string ColorAdded = " Renk eklendi";  
        public static string UserAdded = "Kullanıcı eklendi";
        public static string CustomerAdded = "Müsteri eklendi";
        public static string RentalAdded = "Araba kiralandı";  
        
        public static string CarDeleted = " Araba silindi";
        public static string BrandDeleted = "Marka silindi";
        public static string ColorDeleted = " Rendk silindi";  
        public static string UserDeleted = " Kullanıcı silindi";
        public static string CustomerDeleted = "Müsteri silindi";
        public static string RentalDeleted = "Araba iade edildi";  
        
        public static string CarUpdated = " Araba güncellendi";
        public static string BrandUpdated = " Marka güncellendi";
        public static string ColorUpdated = " Renk güncellendi";        
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string CustomerUpdated = "Müsteri güncellendi";
        public static string RentalUpdated = "Kiralama güncellendi";        
        
        public static string CarListed = "Araba listelendi";
        public static string BrandListed = " Marka listelendi";
        public static string ColorListed = "Renk Listelendi";   
        public static string UserListed = "Kullanıcı listelendi";
        public static string CustomerListed = "Müsteri listelendi";
        public static string RentalListed = "Kiralamalar Listelendi";   
        
        public static string CarFetched = "Araba getirildi";
        public static string BrandFetched = " Marka getirildi";
        public static string ColorFetched = "Renk getirildi";
        public static string UserFetched = "Araba getirildi";
        public static string CustomerFetched = "Müsteri getirildi";
        public static string RentalFetched = "Kiralama getirildi";


        public static string AddingError = "Ekleme hatası";
        public static string DeletingError = "Silme hatasi";
        public static string UpdatingError = "Güncelleme hatası";
        public static string ListingError = "Listeleme hatası";
        public static string FetchingError = "Getirme hatası";

        public static string RentalError = "Bu araba zaten kiralanmışs";

        public static string CarImageListed = "Araba renkleri listelendi";
        public static string FileDeletionException = "Dosya silinirken hata oluştur";
        public static string FileDeletionSucces = "Dosya başarı ile silindi.";
        public static string? AuthorizationDenied = "Yetkilendirme Başarısız !";
        public static string UserRegistered = "Kullanıcı kayıt olundu.";
        public static string UserNotFound = "Kullanıcı bulunmadı";
        public static string PasswordError = "Şifre hatalı";
        public static string CheckImageRestriction = "En fazla 5 resim eklenebilir.";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string UserNotExists = "Kullanıcı bulunmadı";
        public static string AccessTokenCreated = " Access Token oluşturuldu";
        public static string CarCanNotRentable = "This car can't rentable";
        public static string CarCanRentable = "This car can rentable";
        public static string UserNotExist = "User Not Exist";
        public static string UserAlreadyCustomer =" User Already Customer";
        public static string CustomerNotExist = "Customer Doesn't Exist";
        public static string NotAddedCustomer = "Customer Not Added";
        public static string UserNotAdded = "An error durring register custemer";
        public static string CreditCardSaved = "Credit Card Saved";

    }
}
