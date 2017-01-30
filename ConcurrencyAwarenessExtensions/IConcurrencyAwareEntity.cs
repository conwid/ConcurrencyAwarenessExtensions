namespace ConcurrencyAwarenessExtensions
{
    public interface IConcurrencyAwareEntity
	{
		byte[] RowVersion { get; set; }
	}
}
