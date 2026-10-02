namespace Lab01_02
{
    public class Student
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string Khoa { get; set; }
        public double DiemTB { get; set; }
        public string? SoDienThoai { get; set; }

        public Student(string maSo, string hoTen, string khoa, double diemTB, string? soDienThoai)
        {
            MaSo = maSo;
            HoTen = hoTen;
            Khoa = khoa;
            DiemTB = diemTB;
            SoDienThoai = soDienThoai;
        }

        public override string ToString()
        {
            string sdt = string.IsNullOrWhiteSpace(SoDienThoai) ? "Chưa cập nhật" : SoDienThoai;
            return $"{MaSo} - {HoTen} - {Khoa} - DiemTB: {DiemTB:0.0} - SDT: {sdt}";
        }
    }
}