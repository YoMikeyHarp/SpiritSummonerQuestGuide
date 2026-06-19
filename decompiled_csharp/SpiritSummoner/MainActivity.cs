using Android.App;
using Android.Content;
using Microsoft.Maui;

namespace SpiritSummoner;

[Activity(/*Could not decode attribute arguments.*/)]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		((MauiAppCompatActivity)this).OnActivityResult(requestCode, resultCode, data);
	}
}
