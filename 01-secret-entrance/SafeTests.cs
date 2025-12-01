namespace SecretEntrance;

public sealed class SafeTests
{
    [Test]
    public async Task Dial_points_at_50_at_the_begging_of_safe_opening()
    {
        Safe safe = new ();

        await Assert.That(safe.DialPosition).IsEqualTo(50u);
    }
}