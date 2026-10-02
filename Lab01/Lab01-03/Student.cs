namespace Lab01_03
{
    public class Student : Person
    {
        public double DiemTB { get; set; }
        public string? SoDienThoai { get; set; }

        public Student(string maSo, string hoTen, string khoa, double diemTB, string? soDienThoai)
            : base(maSo, hoTen, khoa)
        {
            DiemTB = diemTB;
            SoDienThoai = soDienThoai;
        }

        public override string ToString()
        {
            string sdt = string.IsNullOrWhiteSpace(SoDienThoai) ? "Chưa cập nhật" : SoDienThoai;
            return $"{MaSo} - {HoTen} - {Khoa} - Điểm TB: {DiemTB:0.0} - SĐT: {sdt}";
        }
    }
}