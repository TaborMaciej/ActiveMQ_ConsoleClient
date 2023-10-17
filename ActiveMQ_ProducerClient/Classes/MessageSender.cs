using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace ActiveMQ_ProducerClient.Classes
{
    public class MessageSender
    {
        private String queueName;
        private String brokerUri;

        public MessageSender(String brokerUri_, String queueName_) 
        {
            queueName = queueName_;
            brokerUri = brokerUri_;
        }

        public void SendMessage(String message)
        {
            IConnectionFactory factory = new ConnectionFactory(new Uri(brokerUri));

            using (IConnection connection = factory.CreateConnection())
            {
                try {
                    connection.Start();

                    using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                    {
                        IDestination destination = session.GetQueue(queueName);

                        using (IMessageProducer producer = session.CreateProducer(destination))
                        {
                            ITextMessage textMessage = producer.CreateTextMessage(message);

                            producer.Send(textMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wystąpił błąd: " + ex.Message);
                }
                finally
                {
                    if (connection != null && connection.IsStarted)
                    {
                        connection.Stop();
                        connection.Close();
                    }
                }
            }
        }
    }
}
