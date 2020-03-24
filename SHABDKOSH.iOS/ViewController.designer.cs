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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddWord { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLibrary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWord { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWordMeaning { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddWord != null) {
                btnAddWord.Dispose ();
                btnAddWord = null;
            }

            if (btnLibrary != null) {
                btnLibrary.Dispose ();
                btnLibrary = null;
            }

            if (txtWord != null) {
                txtWord.Dispose ();
                txtWord = null;
            }

            if (txtWordMeaning != null) {
                txtWordMeaning.Dispose ();
                txtWordMeaning = null;
            }
        }
    }
}