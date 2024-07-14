using System;
using System.Text.Json;

class Program
{
    // Hàm tính diện tích, chu vi và đường kính
    static string TinhToanHinhTron(double r)
    {
        double dienTich = Math.PI * Math.Pow(r, 2);
        double chuVi = 2 * Math.PI * r;
        double duongKinh = 2 * r;

        var ketQua = new
        {
            dien_tich = dienTich,
            chu_vi = chuVi,
            duong_kinh = duongKinh
        };

        return JsonSerializer.Serialize(ketQua);
    }

    // Hàm main
    static void Main(string[] args)
    {
        double r;
        bool validInput = false;

        do
        {
            Console.Write("Nhap ban kinh r: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out r) && r > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Gia tri nhap vao khong hop le. Vui long nhap lai.");
            }
        } while (!validInput);

        string ketQuaJson = TinhToanHinhTron(r);
        Console.WriteLine("Ket qua: " + ketQuaJson);
    }
}
