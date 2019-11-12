namespace MSDN.FSharp.Charting
    
open System
open System.Runtime.InteropServices

// Translated from http://support.microsoft.com/kb/323530
module internal ClipboardMetafileHelper =
    [<DllImport("user32.dll")>]
    extern bool OpenClipboard(nativeint hWndNewOwner)
    [<DllImport("user32.dll")>]
    extern bool EmptyClipboard()
    [<DllImport("user32.dll")>]
    extern IntPtr SetClipboardData(uint32 uFormat, nativeint hMem)
    [<DllImport("user32.dll")>]
    extern bool CloseClipboard()
    [<DllImport("gdi32.dll")>]
    extern nativeint CopyEnhMetaFile(nativeint hemfSrc, nativeint hNULL)
    [<DllImport("gdi32.dll")>]
    extern bool DeleteEnhMetaFile(IntPtr hemf)
    
    // Metafile mf is set to a state that is not valid inside this function.
    let PutEnhMetafileOnClipboard(hWnd, mf : System.Drawing.Imaging.Metafile) =
        let mutable bResult = false
        let hEMF = mf.GetHenhmetafile() // invalidates mf
        if (hEMF <> 0n) then
            let hEMF2 = CopyEnhMetaFile(hEMF, 0n)
            if (hEMF2 <> 0n) then
                if OpenClipboard(hWnd) && EmptyClipboard() then
                    let hRes = SetClipboardData( 14u (*CF_ENHMETAFILE*), hEMF2 );
                    bResult <- hRes = hEMF2
                    CloseClipboard() |> ignore
            DeleteEnhMetaFile( hEMF ) |> ignore
        bResult
