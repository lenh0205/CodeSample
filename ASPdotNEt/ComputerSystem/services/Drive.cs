namespace ComputerSystem.services
{
    internal class Drive
    {
        public void GetDriveInfo ()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}");
                Console.WriteLine($"Drive type: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"Total size of drive: {drive.TotalSize} bytes");
                    Console.WriteLine($"Total available free space: {drive.TotalFreeSpace} bytes");
                    Console.WriteLine($"Available free space to current user: {drive.AvailableFreeSpace} bytes");
                    Console.WriteLine($"File system: {drive.DriveFormat}");
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                }
                else
                {
                    Console.WriteLine("Drive is not ready.");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
