using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SimpleTransX
{ 
    class Program
    {
        static string queueName = @".\private$\testQueue";

        static void Main(string[] args)
        {
            
            int a = 1;
            using (TransactionScope tx = new TransactionScope())
            {
                // Anything here is transactional
                // IF IT KNOWS OF TRANSACTIONSCOPE!
                // as example: System.Messaging (MSMQ delivered before TransactionScope was introduced) doesn't !!

                // so sometimes you'll have to revert to old API's.
                MessageQueueTransaction mtx = new MessageQueueTransaction();
                mtx.Begin();

                MessageQueue mQueue = new MessageQueue(queueName);

                //  mQueue.Formatter = new BinaryMessageFormatter();

                // MessageQueue mQueue = MessageQueue.Create(queueName, true);
                 // mQueue.Send("Hello world", mtx);


                Message msg = mQueue.Receive();

                if (msg.BodyType == 768) // bin
                {
                    msg.Formatter = new BinaryMessageFormatter();

                }
                else if (msg.BodyType == 0) // xml
                {
                    msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                }


                Console.WriteLine(msg.Body);

                //// completed doesn't mean 'commited'. it might be rolled back. We can see on the status of the 
                //// given arguments to this event what the outcome was.
                //Transaction.Current.TransactionCompleted += (sender, arg) =>
                //{
                //    Console.WriteLine("The transaction was completed with outcome : " + arg.Transaction.TransactionInformation.Status);
                //};

                //a++;


                mtx.Commit();

                // tx.Complete();
            }

            Console.WriteLine(  a );

        }
    }
}
