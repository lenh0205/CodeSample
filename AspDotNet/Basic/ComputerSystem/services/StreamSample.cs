namespace ComputerSystem.services
{
    internal class StreamSample
    {
        public void SampleReadStream()
        {
            // Tạo một stream và lưu vào đó một số byte
            var stream = new System.IO.MemoryStream();
            for (int i = 0; i < 122; i++)
            {
                stream.WriteByte((byte)i);
            }
            stream.Position = 0; // Thiết lập vị trí là điểm bắt đầu

            // Phương thức "Read()"
            // -> đọc 1 số lượng byte nhất định từ 1 vị trí nhất định
            // -> kết quả đọc lưu vào mảng byte được chỉ định; trả về số lượng byte đọc được (trả về 0 nếu đọc hết stream)
            byte[] buffer = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // tạo 1 mảng byte trong memory
            int numberbyte = stream.Read(buffer, 0, 2); // bắt đầu dọc

            while (numberbyte != 0) // lặp đến khi đọc hết stream
            {
                Console.WriteLine(" ----->");
                Console.WriteLine($"the number of bytes got read from stream is {numberbyte}, include:");
                for (int i = 0; i < numberbyte; i++)
                {
                    byte b = buffer[i]; // lấy ra 1 byte
                    Console.Write(string.Format("{0, 5}", b));
                }

                Console.WriteLine();
                numberbyte = stream.Read(buffer, 0, 5); 
            }
        }
    }
}
