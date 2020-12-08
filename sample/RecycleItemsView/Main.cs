using System;
using System.Resources;

using Xamarin.Forms;

// TODO: Define the default culture of your app.
// This improves lookup performance for the first resource to load.
// For more details, see https://docs.microsoft.com/dotnet/api/system.resources.neutralresourceslanguageattribute.
[assembly: NeutralResourcesLanguage("en-US")]

namespace RecycleItemsView
{
    class TizenApplication : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            using (var tizenApplication = new TizenApplication())
            {
                var option = new InitializationOptions(tizenApplication)
                {
                    UseSkiaSharp = true,
                    DisplayResolutionUnit = DisplayResolutionUnit.DP()
                };
                Forms.Init(option);
                tizenApplication.Run(args);
            }
        }
    }
}
