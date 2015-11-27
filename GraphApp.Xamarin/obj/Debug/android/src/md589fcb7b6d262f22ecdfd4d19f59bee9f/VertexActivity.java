package md589fcb7b6d262f22ecdfd4d19f59bee9f;


public class VertexActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GraphApp.Xamarin.VertexActivity, GraphApp.Xamarin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VertexActivity.class, __md_methods);
	}


	public VertexActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == VertexActivity.class)
			mono.android.TypeManager.Activate ("GraphApp.Xamarin.VertexActivity, GraphApp.Xamarin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
