using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.TV.UIControls.Forms;

namespace Sample
{
    class Program : FormsApplication
    {
        protected override void OnPreCreate()
        {
            MainWindow = new ElmSharp.Window("forms")
            {
                Alpha = false,
            };
        }
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            try
            {
                UIControls.Init();
                UIControls.MainWindowProvider = () => app.MainWindow;
                Forms.Init(app);
                app.Run(args);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Exception : {e.Message}");
            }
        }
    }
}
