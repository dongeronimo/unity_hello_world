var IsWebGLInMobilePlugin = {
	IsMobile: function() 
	{
		return UnityLoader.SystemInfo.mobile;
	}
};
mergeInto(LibraryManager.library, IsWebGLInMobilePlugin);
