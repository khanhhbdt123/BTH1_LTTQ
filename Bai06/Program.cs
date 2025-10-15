using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
namespace Bai06
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
        static void xuatMaTran(int[,]a, int n, int m)
        {
            Console.WriteLine("Ma tran: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void timMax(int[,]a)
        {
            int max = a[0, 0];
            foreach (int i in a)
            {
                if (i > max) max = i;
            }
            Console.WriteLine("Phan tu lon nhat: " + max);
        }
        static void timMin(int[,]a)
        {
            int min = a[0, 0];
            foreach (int i in a)
            {
                if (i < min) min = i;
            }
            Console.WriteLine("Phan tu nho nhat: " + min);
        }
        static void timDongCoTongLonNhat(int[,]a, int n, int m)
        {
            int maxDong = 0, maxTong = 0;
            for (int j = 0; j < m; j++)
            {
                maxTong += a[0, j];
            }
            for (int i = 1; i < n; i++)
            {
                int tongDong = 0;
                for (int j = 0; j < m; j++)
                    tongDong += a[i, j];
                if (tongDong > maxTong)
                {
                    maxTong = tongDong;
                    maxDong = i;
                }
            }
            Console.WriteLine("Dong co tong lon nhat la dong thu " + (maxDong + 1) + " voi tong la " + maxTong);
        }
        static void tongKhongPhaiSNT(int[,]a)
        {
            int tong = 0;
            foreach (int i in a)
            {
                if (!laSNT(i)) tong += i;
            }
            Console.WriteLine("Tong cac so khong phai la so nguyen to la: " + tong);
        }
        static void xoaDongThuK(ref int[,]a, ref int n, int m )
        {
            Console.WriteLine("Nhap dong can xoa: ");
            int k = int.Parse(Console.ReadLine()) - 1;
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Dong vua nhap khong hop le.");
                return;
            }
            int[,] b = new int[n - 1, m];
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                {
                    b[t, j] = a[i, j];
                }
                t++;
            }
            a = b;
            n--;
            Console.WriteLine("Da xoa dong thu " + (k + 1));
        }
        static void xoaCotChuaPhanTuMax(ref int[,]a, int n, ref int m)
        {
            int max = a[0, 0];
            int vtCotMax = 0;
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<m;j++)
                {
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        vtCotMax = j;
                    } 
                        
                }    
            }
            int[,] b = new int[n, m - 1];
            for (int i=0;i<n;i++)
            {
                int t = 0;
                for (int j=0;j<m;j++)
                {
                    if (j == vtCotMax) continue;
                    b[i, t] = a[i, j];
                    t++;
                }    
            }
            a = b;
            m--;
            Console.WriteLine("Da xoa cot chua phan tu lon nhat trong mang la " + max + ".");
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("Nhap so dong: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rnd.Next(-100, 101);
            int choice;
            do
            {
                Console.WriteLine("====MENU====");
                Console.WriteLine("1. Xuat ma tran.");
                Console.WriteLine("2. Tim phan tu lon nhat.");
                Console.WriteLine("3. Tim phan tu nho nhat.");
                Console.WriteLine("4. Tim dong co tong lon nhat.");
                Console.WriteLine("5. Tinh tong cac so khong phai la so nguyen to.");
                Console.WriteLine("6. Xoa dong thu k trong ma tran.");
                Console.WriteLine("7. Xoa cot chua phan tu lon nhat trong ma tran.");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.WriteLine("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le.");
                }
                switch (choice)
                {
                    case 1:
                        xuatMaTran(a, n, m);
                        break;
                    case 2:
                        timMax(a);
                        break;
                    case 3:
                        timMin(a);
                        break;
                    case 4:
                        timDongCoTongLonNhat(a, n, m);
                        break;
                    case 5:
                        tongKhongPhaiSNT(a);
                        break;
                    case 6:
                        xoaDongThuK(ref a, ref n, m);
                        xuatMaTran(a, n, m);
                        break;
                    case 7:
                        xoaCotChuaPhanTuMax(ref a, n, ref m);
                        xuatMaTran(a, n, m);
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
