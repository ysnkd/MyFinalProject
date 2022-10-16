using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //get: oku set:yaz BAŞARILI MI BAŞARISIZ MI? EKLEME İŞLEMİ
        string Message { get; } //BİLGİLENDİRME
    }
}
