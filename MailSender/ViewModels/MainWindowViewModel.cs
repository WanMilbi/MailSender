using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        private string _Title = "Test window";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
