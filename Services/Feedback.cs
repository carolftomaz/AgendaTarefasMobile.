namespace AgendaTarefasMobile.Services;

public static class Feedback
{
    public static void Show(string message)
    {
#if ANDROID
        Android.Widget.Toast.MakeText(Android.App.Application.Context, message, Android.Widget.ToastLength.Short)?.Show();
#endif
    }
}
