namespace BidOn
{
    public class Controller
    {
        public static TouchManager TouchManager { get { return TouchManager.Instance; } }
        public static AudioCtrl Audio { get { return AudioCtrl.Instance; } }
        public static GarbageTankManager GarbageTankManager { get { return GarbageTankManager.Instance; } }
    }
}