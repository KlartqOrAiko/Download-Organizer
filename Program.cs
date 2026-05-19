using System;
using System.IO;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        Console.WriteLine("=== DOWNLOADS ORGANIZER ===");
 
        // 1. Downloads folder path
        string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        Console.WriteLine($"\nConnecting to folder: {downloadsFolder}");
 
        // 2. Destination folder paths
        string imagesFolder    = Path.Combine(downloadsFolder, "Images");
        string documentsFolder = Path.Combine(downloadsFolder, "Documents");
        string appsFolder      = Path.Combine(downloadsFolder, "Apps");
        string videosFolder    = Path.Combine(downloadsFolder, "Videos");
        string audiosFolder    = Path.Combine(downloadsFolder, "Audios");
        string foldersFolder   = Path.Combine(downloadsFolder, "Folders");
        string othersFolder    = Path.Combine(downloadsFolder, "Others");
 
        // Organizer folder names (used for safety check)
        HashSet<string> organizerFolders = new HashSet<string>
        {
            "Images", "Documents", "Apps", "Videos", "Audios", "Folders", "Others"
        };
 
        // 3. Create destination folders if they don't exist
        foreach (string folder in new[] { imagesFolder, documentsFolder, appsFolder, videosFolder, audiosFolder, foldersFolder, othersFolder })
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
 
        // 4. Extension-to-folder mapping
        var mapping = new Dictionary<string, string>
        {
            // Images
            { ".jpg",  imagesFolder }, { ".jpeg", imagesFolder }, { ".png",  imagesFolder },
            { ".gif",  imagesFolder }, { ".ico",  imagesFolder }, { ".webp", imagesFolder },
            { ".svg",  imagesFolder }, { ".bmp",  imagesFolder }, { ".tiff", imagesFolder },
 
            // Documents
            { ".pdf",  documentsFolder }, { ".docx", documentsFolder }, { ".doc",  documentsFolder },
            { ".txt",  documentsFolder }, { ".xlsx", documentsFolder }, { ".xls",  documentsFolder },
            { ".pptx", documentsFolder }, { ".ppt",  documentsFolder }, { ".odt",  documentsFolder },
            { ".csv",  documentsFolder }, { ".xml",  documentsFolder },
 
            // Apps
            { ".exe", appsFolder }, { ".msi", appsFolder },
 
            // Videos
            { ".mp4", videosFolder }, { ".mkv", videosFolder }, { ".avi",  videosFolder },
            { ".mov", videosFolder }, { ".wmv", videosFolder }, { ".webm", videosFolder },
 
            // Audios
            { ".mp3", audiosFolder }, { ".wav", audiosFolder }, { ".ogg",  audiosFolder },
            { ".flac", audiosFolder }, { ".aac", audiosFolder },
        };
 
        int moved = 0, skipped = 0, errors = 0;
 
        // =========================================================
        // PART 1: ORGANIZING SUBFOLDERS
        // =========================================================
        Console.WriteLine("\n--- Organizing subfolders ---");
 
        foreach (string subFolder in Directory.GetDirectories(downloadsFolder))
        {
            string folderName = Path.GetFileName(subFolder);
 
            // SAFETY: never move the organizer's own folders
            if (organizerFolders.Contains(folderName))
                continue;
 
            string destination = Path.Combine(foldersFolder, folderName);
 
            try
            {
                if (Directory.Exists(destination))
                {
                    Console.WriteLine($"⚠️  Folder already exists at destination, skipping: {folderName}");
                    skipped++;
                    continue;
                }
 
                Directory.Move(subFolder, destination);
                Console.WriteLine($"📁 Folder moved: {folderName}");
                moved++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error moving folder '{folderName}': {ex.Message}");
                errors++;
            }
        }
 
        // =========================================================
        // PART 2: ORGANIZING FILES
        // =========================================================
        Console.WriteLine("\n--- Organizing files ---");
 
        foreach (string file in Directory.GetFiles(downloadsFolder))
        {
            string extension = Path.GetExtension(file).ToLower();
            string fileName  = Path.GetFileName(file);
 
            string targetFolder = mapping.ContainsKey(extension) ? mapping[extension] : othersFolder;
            string destination  = Path.Combine(targetFolder, fileName);
 
            try
            {
                if (File.Exists(destination))
                {
                    Console.WriteLine($"⚠️  File already exists at destination, skipping: {fileName}");
                    skipped++;
                    continue;
                }
 
                File.Move(file, destination);
 
                string emoji = targetFolder == imagesFolder    ? "📸" :
                               targetFolder == documentsFolder ? "📄" :
                               targetFolder == appsFolder      ? "🤖" :
                               targetFolder == videosFolder    ? "🎬" :
                               targetFolder == audiosFolder    ? "🎵" : "📦";
 
                Console.WriteLine($"{emoji} Moved: {fileName}");
                moved++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error moving '{fileName}': {ex.Message}");
                errors++;
            }
        }
 
        // =========================================================
        // SUMMARY
        // =========================================================
        Console.WriteLine("\n=============================");
        Console.WriteLine($"✅ Moved:    {moved}");
        Console.WriteLine($"⚠️  Skipped:  {skipped}");
        Console.WriteLine($"❌ Errors:   {errors}");
        Console.WriteLine("=============================");
        Console.WriteLine("🎉 Organization complete!");
    }
}