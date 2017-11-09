namespace BidOn
{
    public static class Helper
    {
        public static RayCastHelper RayCast { get { return RayCastHelper.Instance; } }
        public static PhysicsHelper Physics { get { return PhysicsHelper.Instance; } }
    }
}