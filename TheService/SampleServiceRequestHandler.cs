using System;
using Android.OS;
using Android.Service.QuickSettings;

namespace TheService
{
	public class SampleServiceRequestHandler:Handler
	{
        static string TAG = typeof(SampleServiceRequestHandler).FullName;

        WeakReference<SampleService> serviceRef;

        public SampleServiceRequestHandler(SampleService service)
        {
            serviceRef = new WeakReference<SampleService>(service);
        }

        SampleService Service
        {
            get
            {
                SampleService service;
                if (serviceRef.TryGetTarget(out service))
                {
                    return service;
                }
                return null;
            }
        }
    }
}

