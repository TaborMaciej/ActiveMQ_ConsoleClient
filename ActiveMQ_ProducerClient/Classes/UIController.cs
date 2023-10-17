namespace ActiveMQ_ProducerClient.Classes
{
    public  class UIController
    {
        private readonly String filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "files"));
        private MessageSender sender;
        public UIController(MessageSender sender_)
        {
            sender = sender_;
        }
        public void ManageMenus()
        {

            Console.WriteLine("Klient aplikacji - Producent wiadomości.");
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("Wciśnij 1) Aby wysłać wiadomość.");
                Console.WriteLine("Wciśnij 2) Aby zakończyć.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        MessagePrompt();
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
        private void MessagePrompt()
        {
            Console.WriteLine("\nPodaj nazwę pliku do przesłania wraz z rozszerzeniem");

            String? xmlResponseContent = GetFile(Console.ReadLine());
            if (xmlResponseContent == null) return;
            try
            {
                sender.SendMessage(xmlResponseContent);
                Console.WriteLine("\nWiadomość wysłana!");
            }
            catch (Exception e) 
            {
                Console.WriteLine("Wystąpił błąd:\n" + e.ToString());
                return;
            }
        }


        private String? GetFile(String? fileName)
        {
            try
            {
                String filesContent = System.IO.File.ReadAllText(Path.Combine(filePath, fileName));
                return filesContent;
            }
            catch(Exception e)
            {
                Console.WriteLine("Wystąpił błąd:\n" + e.ToString());
                return null;
            }
        }
    }
}
