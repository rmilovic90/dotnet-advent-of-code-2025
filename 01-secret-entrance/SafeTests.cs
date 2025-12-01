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

    [Test]
    [MethodDataSource(nameof(LeftRotationsTestData))]
    public async Task Turning_the_dial_left_from_0_makes_dial_point_at_number_99_or_lower(RotationsTestData rotationsTestData)
    {
        Safe safe = new ();

        safe.TurnDial(rotationsTestData.Rotations);

        await Assert.That(safe.DialPosition).IsEqualTo(rotationsTestData.ExpectedResult);
    }
 
    public static IEnumerable<Func<RotationsTestData>> LeftRotationsTestData()
    {
        yield return () => new (Rotations: ["L50", "L10"], ExpectedResult: 90u);
        yield return () => new (Rotations: ["L60"], ExpectedResult: 90u);;
    }

    [Test]
    [MethodDataSource(nameof(RightRotationsTestData))]
    public async Task Turning_the_dial_right_from_99_makes_dial_point_at_number_0_or_higher(RotationsTestData rotationsTestData)
    {
        Safe safe = new ();

        safe.TurnDial(rotationsTestData.Rotations);

        await Assert.That(safe.DialPosition).IsEqualTo(rotationsTestData.ExpectedResult);
    }

    public static IEnumerable<Func<RotationsTestData>> RightRotationsTestData()
    {
        yield return () => new (Rotations: ["R50", "R10"], ExpectedResult: 10u);
        yield return () => new (Rotations: ["R60"], ExpectedResult: 10u);
    }

    public record RotationsTestData(IEnumerable<string> Rotations, uint ExpectedResult);
}