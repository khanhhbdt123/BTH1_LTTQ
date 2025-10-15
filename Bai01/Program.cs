using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
namespace Bai01
{
    class Program
    {
        static bool laSNT(int n)
        {
            if (n < 2) return false;
            for (int i=2; i*i<=n;i++)
            {
                if (n%i==0) return false;
            }
            return true;
        }
        static bool laSCP(int n)
        {
            if (n < 0) return false;
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }
        static void xuatMang(int[] a)
        {
            Console.WriteLine("Mang: ");
            Console.WriteLine(string.Join(" ", a));
        }
        static void tongCacSoLe(int[]a)
        {
            int tongle = 0;
            foreach (int i in a)
            {
                if (i % 2 != 0) tongle += i;
            }
            Console.WriteLine("Tong cac so le trong mang la: " + tongle);
        }
        static void demSNT(int[]a)
        {
            int dem = 0;
            foreach (int i in a)
            {
                if (laSNT(i)) dem++;
            }
            Console.WriteLine("So luong so nguyen to trong mang: " + dem);
        }
        static void timMinSCP(int[]a)
        {
            int? minsoCP = null;
            foreach (int i in a)
            {
                if (laSCP(i))
                {
                    if (minsoCP == null || i < minsoCP)
                        minsoCP = i;
                }
            }
            if (minsoCP == null) minsoCP = -1;
            Console.WriteLine("So chinh phuong nho nhat cua mang la: " + minsoCP);
        }
        static void Main()
        {
            Console.WriteLine("Nhap so luong phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(-100, 101);
            int choice;
            do
            {
                Console.WriteLine("\n====MENU====\n");
                Console.WriteLine("1. In mang. ");
                Console.WriteLine("2. Tong cac so le trong mang. ");
                Console.WriteLine("3. Dem so nguyen to trong mang. ");
                Console.WriteLine("4. So chinh phuong nho nhat cua mang. ");
                Console.WriteLine("0. Thoat.");
                Console.WriteLine("Nhap lua chon:");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le.");
                }
                switch (choice)
                {
                    case 1:
                        xuatMang(a);
                        break;
                    case 2:
                        tongCacSoLe(a);
                        break;
                    case 3:
                        demSNT(a);
                        break;
                    case 4:
                        timMinSCP(a);
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