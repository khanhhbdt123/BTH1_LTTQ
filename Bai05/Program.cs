using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai05
{
    class Program
    {
        static bool ktNamNhuan(int nam)
        {
            return (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0));
        }
        static bool ktHopLe(int ngay, int thang, int nam)
        {
            if (nam < 1) return false;
            if (thang < 1 || thang > 12) return false;
            int[] SoNgayTrongThang = { 31, (ktNamNhuan(nam) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (ngay < 1 || ngay > SoNgayTrongThang[thang - 1]) return false;
            return true;
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("====MENU====");
                Console.WriteLine("1. Cho biet thu trong tuan.");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.WriteLine("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Nhap ngay: ");
                        int ngay = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap thang: ");
                        int thang = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap nam: ");
                        int nam = int.Parse(Console.ReadLine());
                        if (ktHopLe(ngay, thang, nam))
                        {
                            DateTime date = new DateTime(nam, thang, ngay);
                            string thu= "";
                            switch(date.DayOfWeek)
                            {
                                case DayOfWeek.Monday: thu = "thu hai"; break;
                                case DayOfWeek.Tuesday: thu = "thu ba"; break;
                                case DayOfWeek.Wednesday: thu = "thu tu"; break;
                                case DayOfWeek.Thursday: thu = "thu nam"; break;
                                case DayOfWeek.Friday: thu = "thu sau"; break;
                                case DayOfWeek.Saturday: thu = "thu bay"; break;
                                case DayOfWeek.Sunday: thu = "chu nhat"; break;
                            }
                            Console.WriteLine("Ngay " + ngay + " thang " + thang + " nam " + nam + " la ngay " + thu + " trong tuan.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ngay vua nhap khong hop le.");
                            break;
                        }    

                    case 0:
                            Console.WriteLine("Thoat chuong trinh.");
                            break;
                    default:
                            Console.WriteLine("Lua chon khong hop le.");
                            break;
                }    
            }
            while (choice != 0);
        }
    }
}
