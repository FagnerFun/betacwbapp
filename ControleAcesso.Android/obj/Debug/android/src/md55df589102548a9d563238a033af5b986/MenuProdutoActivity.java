package md55df589102548a9d563238a033af5b986;


public class MenuProdutoActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ControleAcesso.Android.Activities.MenuProdutoActivity, ControleAcesso.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenuProdutoActivity.class, __md_methods);
	}


	public MenuProdutoActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MenuProdutoActivity.class)
			mono.android.TypeManager.Activate ("ControleAcesso.Android.Activities.MenuProdutoActivity, ControleAcesso.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
