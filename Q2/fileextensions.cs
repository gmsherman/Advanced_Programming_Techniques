// Program for File Extensions

using System;
using System.Collections.Generic; //Utilizing the generic collections to make use of the data structure Dictionary

class FileExtensionInfo
{
     // Public access modifier with static Dictionary mapping file extensions to their descriptions
    public static Dictionary<string, string> fileExtensions {get;} = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
            { ".doc", "Microsoft Word Document"},
            { ".eml", "Email Message" },
            { ".msg", "Outlook Message Item" },
            { ".pages", "Apple Pages Document" },
            { ".txt", "Plain Text File" },
            { ".bin", "Generic Binary File" },
            { ".csv", "Comma Separated Value" },
            { ".dat", "Data File" },
            { ".log", "Log File" },
            { ".xml", "Extensible Markup Language" },
            { ".pdf", "Portable Document Format" },
            { ".mtm", "MultiTracker Module" },
            { ".vlc", "VideoLAN Client" },
            { ".wav", "Wave Audio" },
            { ".wma", "Windows Media Audio" },
            { ".asf", "Advanced Systems Format" },
            { ".flv", "Flash Video" },
            { ".swf", "Shockwave Flash Movie" },
            { ".vob", "DVD Video Object" },
            { ".wmv", "Windows Media Video" },
            { ".xlsx", "Microsoft Excel Spreadsheet" },
            { ".sql", "Structured Query Language Data File" },
            { ".cmd", "Windows Command File" },
            { ".dwg", "AutoCAD Drawing File" },
            { ".json", "JavaScript Object Notation File" }       
    };
}

    