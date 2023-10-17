
using ActiveMQ_ProducerClient.Classes;

class Program
{
    private static String brokerUri = "tcp://localhost:61616";
    private static String requestQueueName = "kolejka";

    static void Main(String[] args)
    {
        MessageSender sender = new MessageSender(brokerUri, requestQueueName);
        UIController controller = new UIController(sender);
        controller.ManageMenus();
    }

}