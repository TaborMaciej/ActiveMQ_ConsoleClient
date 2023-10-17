namespace ActiveMQ_ConsumerClient.Classes;

class Program
{
    private static String brokerUri = "tcp://localhost:61616";
    private static String requestQueueName = "kolejka";

    static void Main(String[] args)
    {
        MessageReceiver sender = new MessageReceiver(brokerUri, requestQueueName);
        UIController controller = new UIController(sender);
        controller.ManageMenus();
    }

}