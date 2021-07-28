namespace BepInEx.SRMLLoader
{
	[BepInPlugin("io.bepis.srmlloader", "SRML Plugin Loader", "1.0")]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
        {
            SRML.Main.PreLoad();
        }
	}
}
