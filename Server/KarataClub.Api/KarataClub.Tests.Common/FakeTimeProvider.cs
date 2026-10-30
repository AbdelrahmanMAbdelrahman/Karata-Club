namespace KarataClub.Tests.Common
{
    public class FakeTimeProvider:TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return base.GetUtcNow();
        }
    }
}