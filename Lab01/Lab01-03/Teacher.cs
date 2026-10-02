namespace Lab01_03
{
    public class Teacher : Person
    {
        public string ChuyenMon { get; set; }

        public Teacher(string maSo, string hoTen, string khoa, string chuyenMon)
            : base(maSo, hoTen, khoa)
        {
            ChuyenMon = chuyenMon;
        }

        public override string ToString()
        {
            return $"{MaSo} - {HoTen} - {Khoa} - Chuyên môn: {ChuyenMon}";
        }
    }
}