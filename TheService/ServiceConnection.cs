using System;
using Android.Content;
using Android.OS;

namespace TheService
{
	public class ServiceConnection:Java.Lang.Object, IServiceConnection
	{
        public Messenger Messenger { get; private set; }
        public bool IsConnected { get; private set; }


        public ServiceConnection()
		{
		}

        public void OnServiceConnected(ComponentName? name, IBinder? service)
        {
            Messenger = new Messenger(service);
            IsConnected = this.Messenger != null;
        }

        public void OnServiceDisconnected(ComponentName? name)
        {
            Messenger = null;
        }
    }
}

