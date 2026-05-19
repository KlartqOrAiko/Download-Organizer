# 📁 Downloads Organizer

A lightweight C# console application that automatically sorts all files and subfolders in your Downloads directory into organized categories.

---

## 🚀 Features

- Automatically categorizes files by type into dedicated folders
- Moves subfolders into a separate `Folders` directory
- Skips files that already exist at the destination (no overwrites)
- Handles errors gracefully — one failure won't stop the entire process
- Displays a summary with total files moved, skipped, and errors

---

## 📂 Folder Structure

After running the program, your Downloads folder will be organized as follows:

```
Downloads/
├── Images/        → .jpg, .jpeg, .png, .gif, .webp, .svg, .bmp, .ico, .tiff
├── Documents/     → .pdf, .docx, .doc, .txt, .xlsx, .xls, .pptx, .ppt, .odt, .csv, .xml
├── Apps/          → .exe, .msi
├── Videos/        → .mp4, .mkv, .avi, .mov, .wmv, .webm
├── Audios/        → .mp3, .wav, .ogg, .flac, .aac
├── Folders/       → any subfolders found in Downloads
└── Others/        → everything else
```

---

## 🛠️ Technologies

- **Language:** C#
- **Framework:** .NET
- **IDE:** Visual Studio Code

---

## ▶️ How to Run

**1. Clone the repository**
```bash
git clone https://github.com/your-username/downloads-organizer.git
cd downloads-organizer
```

**2. Run the application**
```bash
dotnet run
```

> The program will automatically target your system's Downloads folder.

---

## 📋 Example Output

```
=== DOWNLOADS ORGANIZER ===

Connecting to folder: C:\Users\you\Downloads

--- Organizing subfolders ---
📁 Folder moved: old-project

--- Organizing files ---
📸 Moved: wallpaper.png
📄 Moved: resume.pdf
🤖 Moved: setup.exe
🎬 Moved: tutorial.mp4
🎵 Moved: song.mp3
📦 Moved: archive.zip

=============================
✅ Moved:    6
⚠️  Skipped:  0
❌ Errors:   0
=============================
🎉 Organization complete!
```

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
