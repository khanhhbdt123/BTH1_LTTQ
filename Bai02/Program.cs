using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai02
{
    class Program
    {
        static bool laSNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine());
            int choice;
            do
            {
                Console.WriteLine("\n====MENU====\n");
                Console.WriteLine("1. Tong cac so nguyen to nho hon " + n + ". ");
                Console.WriteLine("0. Thoat chuong trinh. ");
                Console.WriteLine("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int tong = 0;
                        for (int i = 2; i < n; i++)
                        {
                            if (laSNT(i)) tong += i;
                        }
                        Console.WriteLine("Tong cac so nguyen to nho hon " + n + " la: " + tong);
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh. ");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. ");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}