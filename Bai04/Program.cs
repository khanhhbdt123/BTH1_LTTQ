using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai04
{
    class Program
    {
        static bool ktNamNhuan(int nam)
        {
            return (nam % 400 == 0 || nam % 4 == 0 && nam % 100 != 0);
        }
        static void Main(string[] args)
        {  
            int choice;
            do
            {
                Console.WriteLine("====MENU====");
                Console.WriteLine("1. In ra so ngay cua thang.");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.WriteLine("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap thang: ");
                        int thang = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nam: ");
                        int nam = int.Parse(Console.ReadLine());
                        if (nam < 1 || thang < 1 || thang > 12) Console.WriteLine("Thang nam vua nhap khong hop le.");
                        else
                        {
                            int[] SoNgayTrongThang = { 31, (ktNamNhuan(nam) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                            Console.WriteLine("So ngay trong thang " + thang + " nam " + nam + " la: " + SoNgayTrongThang[thang - 1]);
                        }
                        break;
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