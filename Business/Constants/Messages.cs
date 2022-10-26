using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //newleyemeliyim diye static koyuyoruz.
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string ProductsListed = "Liste";

        public static string UnitPriceInvalid { get; internal set; }
        public static string CategoryLimitExceded = "Kategori limiti yüklendiği için kayıt edilemiyor.";

        public static string ProductNameAlreadyExist = "Bu isimde zaten bir ürün var.";

        public static string ProductCountCategoryError = "10'dan fazla ürün ekleyemezsiniz.";
    }
}
