using Foundation;
using System;
using UIKit;

namespace WordWorld
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            string translatedNumber = string.Empty;

            btnTranslate.TouchUpInside += (object sender, EventArgs e) => 
            {
                translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);
                PhoneNumberText.ResignFirstResponder();

                if (string.IsNullOrEmpty(translatedNumber))
                {
                    btnCall.SetTitle("Call", UIControlState.Normal);
                    btnCall.Enabled = false;
                }
                else
                {
                    btnCall.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    btnCall.Enabled = true;
                }
            };


            btnCall.TouchUpInside += (object sender, EventArgs e) => 
            {
                var url = new NSUrl("tel:" + translatedNumber);

                if(!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}