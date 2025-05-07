namespace VM.Domain.Contracts.Presistence
{
    public interface IPageResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Results { get; set; }

    }
}
