namespace SecretEntrance;

public sealed class SafeTests
{
    [Test]
    public async Task Dial_points_at_50_at_the_begging_of_safe_opening()
    {
        Safe safe = new ();

        await Assert.That(safe.DialPosition).IsEqualTo(50u);
    }

    [Test]
    public async Task Dial_rotation_to_the_left_moves_the_dial_towards_lower_numbers()
    {
        Safe safe = new ();

        safe.TurnDial(["L10"]);

        await Assert.That(safe.DialPosition).IsEqualTo(40u);
    }

    [Test]
    public async Task Dial_rotation_to_the_right_moves_the_dial_towards_higher_numbers()
    {
        Safe safe = new ();

        safe.TurnDial(["R10"]);

        await Assert.That(safe.DialPosition).IsEqualTo(60u);
    }
}