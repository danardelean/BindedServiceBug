using Android.Content;
using Android.Content.PM;
using Android.Nfc;
using Android.Util;

namespace TheClient;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    static readonly string TAG = typeof(MainActivity).FullName;
    ServiceConnection? _serviceConnection;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        _serviceConnection = new ServiceConnection();

        StartService();
    }

   void StartService()
    {
        Permission permissionCheck = CheckSelfPermission( "it.mahiz.theservice.PERMISSION");
        if( permissionCheck == Permission.Granted)
        {
            ComponentName cn = new ComponentName("it.mahiz.theservice", "it.mahiz.theservice.sampleservice");
            var intentToBindService = new Intent();
            intentToBindService.SetComponent(cn);
            BindService(intentToBindService, _serviceConnection, Bind.AutoCreate);
        }
    }
}
