namespace ActiveMQ_ConsumerClient.Classes
{
    public  class UIController
    {
        private readonly String filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "files"));
        private MessageReceiver sender;
        public UIController(MessageReceiver sender_)
        {
            sender = sender_;
        }
        public void ManageMenus()
        {

            Console.WriteLine("Klient aplikacji - Odbiorca wiadomości.");
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("Wciśnij 1) Aby odebrac wiadomość z kolejki.");
                Console.WriteLine("Wciśnij 2) Aby zakończyć.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        ShowMessage();
                        break;
                    case '2':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowy wybór. Wciśnij 1 lub 2.");
                        break;
                }
            }

            Console.WriteLine("\n\nWciśnij dowolny przycisk, aby zakończyć...");
            Console.ReadKey();

        }
        private void ShowMessage()
        {
            String? message = sender.GetMessage();
            if(message == null)
                Console.WriteLine("\nBrak wiadomości.");
            else
                Console.WriteLine(message);
        }
    }
}
