// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SHABDKOSH.iOS
{
    [Register ("Library")]
    partial class Library
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView callHistoryController { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (callHistoryController != null) {
                callHistoryController.Dispose ();
                callHistoryController = null;
            }
        }
    }
}