namespace Core.Contracts {
    public interface IOrderQuery {
        public string Keyword { get; set; }

        public bool IsNotConfirmed { get; set; }
    }
}
