using System;
using System.IO;
using System.Text;

public class FileOperations
{
    // a. Thao tác với file text
    public static class ThaoTacFileText
    {
        // Hàm tính số dòng trong file
        public static int DemSoDong(string duongDanFile)
        {
            int soDong = 0;
            using (StreamReader doc = new StreamReader(duongDanFile))
            {
                while (doc.ReadLine() != null)
                {
                    soDong++;
                }
            }
            return soDong;
        }

        // Hàm tính số ký tự cụ thể trong file
        public static int DemKyTu(string duongDanFile, char kyTu)
        {
            int soKyTu = 0;
            using (StreamReader doc = new StreamReader(duongDanFile))
            {
                int ch;
                while ((ch = doc.Read()) != -1)
                {
                    if ((char)ch == kyTu)
                    {
                        soKyTu++;
                    }
                }
            }
            return soKyTu;
        }

        // Hàm tính số từ phân tách bởi dấu cách trong file
        public static int DemSoTu(string duongDanFile)
        {
            int soTu = 0;
            using (StreamReader doc = new StreamReader(duongDanFile))
            {
                string dong;
                while ((dong = doc.ReadLine()) != null)
                {
                    soTu += dong.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }
            return soTu;
        }
    }

    // b. Đọc và ghi file UTF-8
    public static class ThaoTacFileUtf8
    {
        public static void SaoChepFileUtf8(string duongDanFileNguon, string duongDanFileDich)
        {
            string noiDung;
            using (StreamReader doc = new StreamReader(duongDanFileNguon, Encoding.UTF8))
            {
                noiDung = doc.ReadToEnd();
            }

            using (StreamWriter ghi = new StreamWriter(duongDanFileDich, false, Encoding.UTF8))
            {
                ghi.Write(noiDung);
            }
        }
    }

    // c. Đọc và ghi file UTF-16
    public static class ThaoTacFileUtf16
    {
        public static void SaoChepFileUtf16(string duongDanFileNguon, string duongDanFileDich)
        {
            string noiDung;
            using (StreamReader doc = new StreamReader(duongDanFileNguon, Encoding.Unicode))
            {
                noiDung = doc.ReadToEnd();
            }

            using (StreamWriter ghi = new StreamWriter(duongDanFileDich, false, Encoding.Unicode))
            {
                ghi.Write(noiDung);
            }
        }
    }

    // d. Ghi và đọc file nhị phân
    public static class ThaoTacFileNhiPhan
    {
        public static void GhiFileNhiPhan(string duongDanFile, double[,] mang)
        {
            using (BinaryWriter ghi = new BinaryWriter(File.Open(duongDanFile, FileMode.Create)))
            {
                int soDong = mang.GetLength(0);
                int soCot = mang.GetLength(1);

                ghi.Write(soDong);
                ghi.Write(soCot);

                for (int i = 0; i < soDong; i++)
                {
                    for (int j = 0; j < soCot; j++)
                    {
                        ghi.Write(mang[i, j]);
                    }
                }
            }
        }

        public static double[,] DocFileNhiPhan(string duongDanFile)
        {
            using (BinaryReader doc = new BinaryReader(File.Open(duongDanFile, FileMode.Open)))
            {
                int soDong = doc.ReadInt32();
                int soCot = doc.ReadInt32();
                double[,] mang = new double[soDong, soCot];

                for (int i = 0; i < soDong; i++)
                {
                    for (int j = 0; j < soCot; j++)
                    {
                        mang[i, j] = doc.ReadDouble();
                    }
                }

                return mang;
            }
        }
    }

    public static void Main()
    {
        // a. Thao tác với file text
        string duongDanFileText = "Program.cs";
        Console.WriteLine("So dong: " + ThaoTacFileText.DemSoDong(duongDanFileText));
        Console.WriteLine("So lan xuat hien cua ky tu 'a': " + ThaoTacFileText.DemKyTu(duongDanFileText, 'a'));
        Console.WriteLine("So tu: " + ThaoTacFileText.DemSoTu(duongDanFileText));

        // b. Đọc và ghi file UTF-8
        ThaoTacFileUtf8.SaoChepFileUtf8("vd1_read.txt", "vd1_ghi.txt");

        // c. Đọc và ghi file UTF-16
        ThaoTacFileUtf16.SaoChepFileUtf16("vd1_read.txt", "vd1_ghi.txt");

        // d. Ghi và đọc file nhị phân
        double[,] mangDeGhi = { { 1.1, 2.2 }, { 3.3, 4.4 } };
        string duongDanFileNhiPhan = "a2d.dat";
        ThaoTacFileNhiPhan.GhiFileNhiPhan(duongDanFileNhiPhan, mangDeGhi);

        double[,] mangDoc = ThaoTacFileNhiPhan.DocFileNhiPhan(duongDanFileNhiPhan);
        Console.WriteLine("Mang doc tu file:");
        for (int i = 0; i < mangDoc.GetLength(0); i++)
        {
            for (int j = 0; j < mangDoc.GetLength(1); j++)
            {
                Console.Write(mangDoc[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
