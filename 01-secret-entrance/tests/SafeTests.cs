using TUnit.Assertions.Enums;

namespace SecretEntrance;

public sealed class SafeTests
{
    [Test]
    public async Task Dial_points_at_50_at_the_begging_of_safe_opening()
    {
        IReadOnlyList<uint> positions = Safe.TurnDial([]);

        await Assert.That(positions).IsEquivalentTo([50u], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Dial_rotation_to_the_left_moves_the_dial_towards_lower_numbers()
    {
        IReadOnlyList<uint> positions = Safe.TurnDial(["L10"]);

        await Assert.That(positions).IsEquivalentTo([50u, 40u], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Dial_rotation_to_the_right_moves_the_dial_towards_higher_numbers()
    {
        IReadOnlyList<uint> positions = Safe.TurnDial(["R10"]);

        await Assert.That(positions).IsEquivalentTo([50u, 60u], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Turning_the_dial_left_from_0_makes_dial_point_at_number_99_or_lower()
    {
        IReadOnlyList<uint> positions = Safe.TurnDial(["L60"]);

        await Assert.That(positions).IsEquivalentTo([50u, 90u], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Turning_the_dial_right_from_99_makes_dial_point_at_number_0_or_higher()
    {
        IReadOnlyList<uint> positions = Safe.TurnDial(["R60"]);

        await Assert.That(positions).IsEquivalentTo([50u, 10u], CollectionOrdering.Matching);
    }

    [Test]
    [MethodDataSource(nameof(DialRotations))]
    public async Task Turning_the_dial_returns_expected_dial_positions(DialRotationsTestData dialRotations)
    {
        IReadOnlyList<uint> positions = Safe.TurnDial(dialRotations.Rotations);

        await Assert.That(positions).IsEquivalentTo(dialRotations.ExpectedPositions, CollectionOrdering.Matching);
    }

    public static Func<DialRotationsTestData> DialRotations() =>
        () => new DialRotationsTestData
        (
            Rotations: ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"],
            ExpectedPositions: [50u, 82u, 52u, 0u, 95u, 55u, 0u, 99u, 0u, 14u, 32u]
        );

    public record DialRotationsTestData(IEnumerable<string> Rotations, IEnumerable<uint> ExpectedPositions);
}