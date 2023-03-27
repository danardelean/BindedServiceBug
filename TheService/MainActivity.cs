using Android.Content;
using Android.Service.QuickSettings;

namespace TheService;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    ServiceConnection? serviceConnection;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        serviceConnection = new ServiceConnection();

        Intent serviceToStart = new Intent(this, typeof(SampleService));
        var result = BindService(serviceToStart, serviceConnection, Bind.AutoCreate);
    }
}
