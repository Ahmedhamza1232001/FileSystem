namespace FileSystem;

class Program
{
    static void Main(string[] args)
    {
        // Specify the directory you want to manage
        string directoryPath = @"./testfolder";

        // Check if directory exists
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("The specified directory does not exist.");
            return;
        }

        // Get the current date and time
        DateTime currentDate = DateTime.Now;
    
        // Define the cutoff date (5 days ago from now)
        //DateTime cutoffDate = currentDate.AddDays(-5);

        try
        {
            // Get all files in the specified directory
            var files = Directory.GetFiles(directoryPath);

            if (files.Length == 0)
            {
                Console.WriteLine("The folder is empty.");
                return;
            }

            foreach (var file in files)
            {
                // Get the last write time of the file
                DateTime lastWriteTime = File.GetLastWriteTime(file);

                // Check if the file is older than the cutoff date
                if (lastWriteTime < currentDate)
                {
                    // Delete the file
                    File.Delete(file);
                    Console.WriteLine($"Deleted: {file}");
                }
            }

            Console.WriteLine("Cleanup completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
   