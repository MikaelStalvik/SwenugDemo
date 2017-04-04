using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using GameDemoNative.Droid.Activities;

namespace GameDemoNative.Droid
{
    [Application(Debuggable = true, ManageSpaceActivity = typeof(LoginActivity))]
    public class DroidGameApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public DroidGameApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }


        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityDestroyed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityPaused(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityResumed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStarted(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStopped(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}