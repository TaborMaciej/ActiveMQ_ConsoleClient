using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace ActiveMQ_ConsumerClient.Classes
{
    public class MessageReceiver
    {
        private String queueName;
        private String brokerUri;

        public MessageReceiver(String brokerUri_, String queueName_) 
        {
            queueName = queueName_;
            brokerUri = brokerUri_;
        }

        public String? GetMessage()
        {
            IConnectionFactory factory = new NMSConnectionFactory(brokerUri);
            using (IConnection connection = factory.CreateConnection())
            {
                try
                {
                    connection.Start();
                    using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                    {
                        IDestination destination = session.GetQueue(queueName);
                        using (IMessageConsumer consumer = session.CreateConsumer(destination))
                        {
                            IMessage message = consumer.Receive(TimeSpan.FromMilliseconds(2000));
                            if (message == null) return null;

                            if (message is ITextMessage textMessage)
                            {
                                return textMessage.Text;
                            }
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
            return null;
        }
    }
}
