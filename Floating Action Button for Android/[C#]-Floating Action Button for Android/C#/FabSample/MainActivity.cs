using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Animation;
using Android.Views.Animations;

using FloatingActionButton;

namespace FabSample
{
	[Activity (Label = "FabSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Fab _fab;
		private Fab fab_pop_1;
		private Fab fab_pop_2;
		private Fab fab_pop_3;
		public int i=0;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			LinearLayout MainLinear = FindViewById<LinearLayout> (Resource.Id.MainLinear);

			_fab = FindViewById<Fab> (Resource.Id.fabbutton);
			fab_pop_1 = FindViewById<Fab> (Resource.Id.fab_pop_1);
			fab_pop_2 = FindViewById<Fab> (Resource.Id.fab_pop_2);
			fab_pop_3 = FindViewById<Fab> (Resource.Id.fab_pop_3);


			fab_pop_1.Visibility = ViewStates.Invisible;
			fab_pop_2.Visibility = ViewStates.Invisible;
			fab_pop_3.Visibility = ViewStates.Invisible;

			Animation fade_in = AnimationUtils.LoadAnimation (this, Resource.Animation.fade_in);
			Animation fade_out = AnimationUtils.LoadAnimation (this, Resource.Animation.fade_out);

			var holodarkOrange = Resources.GetColor(Android.Resource.Color.HoloOrangeDark);
			var holoPurple = Resources.GetColor(Android.Resource.Color.HoloPurple);
			var holoGreen = Resources.GetColor(Android.Resource.Color.HoloGreenLight);

			_fab.FabColor = Color.Rgb (4,136,209);
			fab_pop_1.FabColor = holodarkOrange;
			fab_pop_2.FabColor = holoPurple;
			fab_pop_3.FabColor = holoGreen;

			_fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_content_new);

			_fab.Click += (s, e) => {
				if (i == 0) {
					fab_pop_3.StartAnimation (fade_in);
					fab_pop_3.Visibility = ViewStates.Visible;
					fab_pop_2.StartAnimation (fade_in);
					fab_pop_2.Visibility = ViewStates.Visible;
					fab_pop_1.StartAnimation (fade_in);	
					fab_pop_1.Visibility = ViewStates.Visible;
					i = 1;
				} 
				else {	
					fab_pop_1.StartAnimation (fade_out);
					fab_pop_1.Visibility = ViewStates.Invisible;
					fab_pop_2.StartAnimation (fade_out);
					fab_pop_2.Visibility = ViewStates.Invisible;
					fab_pop_3.StartAnimation (fade_out);
					fab_pop_3.Visibility = ViewStates.Invisible;
					i = 0;
				}

				fab_pop_1.Click+=delegate {
					MainLinear.SetBackgroundColor(holodarkOrange);
					MainLinear.StartAnimation(fade_in);
					MainLinear.StartAnimation(fade_in);
					fab_pop_1.StartAnimation (fade_out);
					fab_pop_1.Visibility = ViewStates.Invisible;
					fab_pop_2.StartAnimation (fade_out);
					fab_pop_2.Visibility = ViewStates.Invisible;
					fab_pop_3.StartAnimation (fade_out);
					fab_pop_3.Visibility = ViewStates.Invisible;
					i = 0;
				};
				fab_pop_2.Click+=delegate {	
					MainLinear.SetBackgroundColor(holoPurple);
					MainLinear.StartAnimation(fade_in);
					fab_pop_1.StartAnimation (fade_out);
					fab_pop_1.Visibility = ViewStates.Invisible;
					fab_pop_2.StartAnimation (fade_out);
					fab_pop_2.Visibility = ViewStates.Invisible;
					fab_pop_3.StartAnimation (fade_out);
					fab_pop_3.Visibility = ViewStates.Invisible;
					i = 0;
				};
				fab_pop_3.Click+=delegate {
					MainLinear.SetBackgroundColor(holoGreen);
					MainLinear.StartAnimation(fade_in);
					fab_pop_1.StartAnimation (fade_out);
					fab_pop_1.Visibility = ViewStates.Invisible;
					fab_pop_2.StartAnimation (fade_out);
					fab_pop_2.Visibility = ViewStates.Invisible;
					fab_pop_3.StartAnimation (fade_out);
					fab_pop_3.Visibility = ViewStates.Invisible;
					i = 0;
				};

			};
		}
	}
}


