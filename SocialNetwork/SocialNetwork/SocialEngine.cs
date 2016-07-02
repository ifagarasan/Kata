namespace SocialNetwork
{
    public class SocialEngine : ISocialEngine
    {
        private readonly IRepository _repository;

        public SocialEngine(IRepository repository)
        {
            _repository = repository;
        }

        public void Post(string username, string message)
        {
            _repository.Insert(username, message);
        }
    }
}