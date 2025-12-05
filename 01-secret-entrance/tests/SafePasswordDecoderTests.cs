namespace SecretEntrance;

public sealed class SafePasswordDecoderTests
{
    [Test]
    public async Task Password_is_number_of_dial_possitions_at_0()
    {
        uint password = SafePasswordDecoder.Decode([50u, 0u, 30u, 0u, 10u]);

        await Assert.That(password).IsEqualTo(2u);
    }
}