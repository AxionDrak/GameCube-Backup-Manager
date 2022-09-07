using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class DFileSystemImageImport_SinkHelper : DFileSystemImageImportEvents
{
    // Fields

    public DFileSystemImageImport_SinkHelper(DFileSystemImageImport_EventHandler eventHandler)
    {
        Cookie = 0;
        UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
    }

    public int Cookie { get; set; }

    public DFileSystemImageImport_EventHandler UpdateDelegate { get; set; }

    public void UpdateImport(object sender, FsiFileSystems fileSystems, string currentItem,
        int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems)
    {
        UpdateDelegate(sender, fileSystems, currentItem, importedDirectoryItems, totalDirectoryItems,
            importedFileItems, totalFileItems);
    }
}