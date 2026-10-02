using System;

namespace Lab01_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random random = new Random();
            int targetNumber = random.Next(100, 1000);
            string targetString = targetNumber.ToString();

            int attempt = 1;
            const int MAX_GUESS = 7;
            string guess;
            string feedback = "";

            Console.WriteLine("CHƯƠNG TRÌNH ĐOÁN SỐ");

            while (feedback != "+++" && attempt <= MAX_GUESS)
            {
                Console.Write($"\nLần đoán thứ {attempt}: ");
                guess = Console.ReadLine()?.Trim() ?? "";

                if (guess.Length != 3 || !int.TryParse(guess, out int number) || number < 100 || number > 999)
                {
                    Console.WriteLine("Vui lòng nhập một số nguyên có đúng 3 chữ số (từ 100 đến 999).");
                    continue;
                }

                feedback = GetFeedback(targetString, guess);
                Console.WriteLine($"Phản hồi từ máy tính: {feedback}");

                attempt++;
            }

            if (feedback == "+++")
            {
                Console.WriteLine($"\nNgười chơi đã đoán đúng! Trò chơi kết thúc sau {attempt - 1} lần đoán.");
                Console.WriteLine("Người chơi thắng cuộc!");
            }
            else
            {
                Console.WriteLine($"\nNgười chơi đã đoán {MAX_GUESS} lần. Trò chơi kết thúc!");
                Console.WriteLine($"Số cần đoán là: {targetNumber}");
                Console.WriteLine("Người chơi thua cuộc!");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }


        static string GetFeedback(string target, string guess)
        {
            string feedback = "";

            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == guess[i])
                {
                    feedback += "+";
                }
                else if (target.Contains(guess[i]))
                {
                    feedback += "?";
                }
            }

            return feedback;
        }
    }
}