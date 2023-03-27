using System;
using Android.Content;
using Android.OS;
using Android.Service.QuickSettings;
using Android.Util;

namespace TheService
{
    [Service(Name = "it.mahiz.theservice.sampleservice",
            Exported = true,
            Permission = "it.mahiz.theservice.PERMISSION"
           )]
    public class SampleService:Service
	{
        static readonly string TAG = typeof(SampleService).FullName;

        Messenger? _messenger;

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Debug(TAG, "OnCreate");
            _messenger = new Messenger(new SampleServiceRequestHandler(this));

            Log.Info(TAG, $"TinaService is running in process id {Android.OS.Process.MyPid()}.");
        }

        public override IBinder? OnBind(Intent? intent)
        {
            Toast.MakeText(ApplicationContext, $"OnBind {Binder.CallingPid}", ToastLength.Short).Show();
            return _messenger.Binder;
        }
    }
}

