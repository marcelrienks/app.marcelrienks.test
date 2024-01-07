using app.marcelrienks.test.Interfaces;

namespace app.marcelrienks.test.Services
{
    internal class DummyService : IDummyService
    {
        public string PadMessage(string message)
        {
            return $"This is a response to the post with message '{message}', that was sent as input";
        }
    }
}
