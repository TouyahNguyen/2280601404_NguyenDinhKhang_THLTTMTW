using System.Text;
using Lab01_03;

Console.OutputEncoding = Encoding.UTF8;

List<Student> danhSachSV = new List<Student>();
List<Teacher> danhSachGV = new List<Teacher>();
bool tiepTuc = true;

while (tiepTuc)
{
    Console.Clear();
    Console.WriteLine("QUAN LY SINH VIEN VA GIANG VIEN");
    Console.WriteLine("1. Them sinh vien");
    Console.WriteLine("2. Them giao vien");
    Console.WriteLine("3. Xuat danh sach sinh vien");
    Console.WriteLine("4. Xuat danh sach giao vien");
    Console.WriteLine("5. So luong tung danh sach (tong so sinh vien, tong so giao vien)");
    Console.WriteLine("6. Xuat danh sach sinh vien thuoc khoa \"CNTT\"");
    Console.WriteLine("7. Xuat danh sach giao vien co chuyen mon chua \"Lap trinh\"");
    Console.WriteLine("8. Xuat sinh vien co diem trung binh cao nhat va thuoc khoa \"CNTT\"");
    Console.WriteLine("9. Thong ke so luong theo tung xep loai hoc luc");
    Console.WriteLine("0. Thoat");
    Console.Write("Chon chuc nang: ");

    string? luaChon = Console.ReadLine();
    switch (luaChon)
    {
        case "1": ThemSinhVien(); break;
        case "2": ThemGiaoVien(); break;
        case "3": XuatDanhSachSV(danhSachSV); break;
        case "4": XuatDanhSachGV(danhSachGV); break;
        case "5": SoLuongTungDanhSach(); break;
        case "6": XuatSinhVienCNTT(); break;
        case "7": XuatGiaoVienLapTrinh(); break;
        case "8": XuatSinhVienDiemCaoNhatCNTT(); break;
        case "9": ThongKeXepLoaiHocLuc(); break;
        case "0": tiepTuc = false; break;
        default:
            Console.WriteLine("Lua chon khong hop le!");
            break;
    }

    if (tiepTuc)
    {
        Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
        Console.ReadKey();
    }
}

bool KiemTraTrungMaSo(string maSo)
{
    return danhSachSV.Any(s => s.MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase)) ||
           danhSachGV.Any(t => t.MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase));
}

void ThemSinhVien()
{
    Console.WriteLine("\n--- THEM SINH VIEN ---");
    string maSo;
    while (true)
    {
        Console.Write("Ma so: ");
        maSo = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(maSo))
        {
            Console.WriteLine("=> Ma so khong duoc de trong!");
            continue;
        }
        if (KiemTraTrungMaSo(maSo))
        {
            Console.WriteLine("=> Ma so da ton tai trong he thong! Vui long nhap lai.");
            continue;
        }
        break;
    }

    Console.Write("Ho ten: ");
    string hoTen = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Khoa: ");
    string khoa = Console.ReadLine()?.Trim() ?? "";

    double diemTB = NhapSoThuc("Diem trung binh (0.0 - 10.0): ", 0.0, 10.0);

    Console.Write("So dien thoai (co the bo trong): ");
    string? sdtInput = Console.ReadLine();
    string? soDienThoai = string.IsNullOrWhiteSpace(sdtInput) ? null : sdtInput.Trim();

    danhSachSV.Add(new Student(maSo, hoTen, khoa, diemTB, soDienThoai));
    Console.WriteLine("=> Them sinh vien thanh cong!");
}

void ThemGiaoVien()
{
    Console.WriteLine("\n--- THEM GIAO VIEN ---");
    string maSo;
    while (true)
    {
        Console.Write("Ma so: ");
        maSo = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(maSo))
        {
            Console.WriteLine("=> Ma so khong duoc de trong!");
            continue;
        }
        if (KiemTraTrungMaSo(maSo))
        {
            Console.WriteLine("=> Ma so da ton tai trong he thong! Vui long nhap lai.");
            continue;
        }
        break;
    }

    Console.Write("Ho ten: ");
    string hoTen = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Khoa: ");
    string khoa = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Chuyen mon: ");
    string chuyenMon = Console.ReadLine()?.Trim() ?? "";

    danhSachGV.Add(new Teacher(maSo, hoTen, khoa, chuyenMon));
    Console.WriteLine("=> Them giao vien thanh cong!");
}

void XuatDanhSachSV(IEnumerable<Student> ds)
{
    Console.WriteLine("\n--- DANH SACH SINH VIEN ---");
    if (!ds.Any())
    {
        Console.WriteLine("(Khong co du lieu)");
        return;
    }

    foreach (var sv in ds)
    {
        Console.WriteLine(sv);
    }
}

void XuatDanhSachGV(IEnumerable<Teacher> ds)
{
    Console.WriteLine("\n--- DANH SACH GIAO VIEN ---");
    if (!ds.Any())
    {
        Console.WriteLine("(Khong co du lieu)");
        return;
    }

    foreach (var gv in ds)
    {
        Console.WriteLine(gv);
    }
}

void SoLuongTungDanhSach()
{
    Console.WriteLine("\n--- SO LUONG TUNG DANH SACH ---");
    Console.WriteLine($"Tong so sinh vien : {danhSachSV.Count}");
    Console.WriteLine($"Tong so giao vien : {danhSachGV.Count}");
}

void XuatSinhVienCNTT()
{
    Console.WriteLine("\n--- SINH VIEN KHOA CNTT ---");
    var ketQua = danhSachSV.Where(x => x.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase));
    XuatDanhSachSV(ketQua);
}

void XuatGiaoVienLapTrinh()
{
    Console.WriteLine("\n--- GIAO VIEN CO CHUYEN MON CHUA \"LAP TRINH\" ---");
    var ketQua = danhSachGV.Where(x => x.ChuyenMon.Contains("Lap trinh", StringComparison.OrdinalIgnoreCase)
                                    || x.ChuyenMon.Contains("Lập trình", StringComparison.OrdinalIgnoreCase));
    XuatDanhSachGV(ketQua);
}

void XuatSinhVienDiemCaoNhatCNTT()
{
    Console.WriteLine("\n--- SINH VIEN DIEM TB CAO NHAT KHOA CNTT ---");
    var svMax = danhSachSV
        .Where(x => x.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase))
        .OrderByDescending(x => x.DiemTB)
        .FirstOrDefault();

    if (svMax != null)
    {
        Console.WriteLine(svMax);
    }
    else
    {
        Console.WriteLine("(Khong co sinh vien nao thuoc khoa CNTT)");
    }
}

string XepLoai(double diemTB)
{
    if (diemTB >= 9.0) return "Xuất sắc";
    if (diemTB >= 8.0) return "Giỏi";
    if (diemTB >= 6.5) return "Khá";
    if (diemTB >= 5.0) return "Trung bình";
    return "Yếu";
}

void ThongKeXepLoaiHocLuc()
{
    Console.WriteLine("\n--- THONG KE THEO TUNG XEP LOAI HOC LUC ---");
    if (!danhSachSV.Any())
    {
        Console.WriteLine("(Khong co du lieu sinh vien de thong ke)");
        return;
    }

    var thongKe = danhSachSV
        .GroupBy(x => XepLoai(x.DiemTB))
        .Select(g => new
        {
            Loai = g.Key,
            SoLuong = g.Count()
        });

    foreach (var item in thongKe)
    {
        Console.WriteLine($"Xep loai: {item.Loai,-12} | So luong: {item.SoLuong,3}");
    }
}

double NhapSoThuc(string thongBao, double min, double max)
{
    double gtri;
    while (true)
    {
        Console.Write(thongBao);
        if (double.TryParse(Console.ReadLine(), out gtri) && gtri >= min && gtri <= max)
        {
            return gtri;
        }
        Console.WriteLine($"=> Gia tri khong hop le, vui long nhap lai trong khoang [{min} - {max}].");
    }
}