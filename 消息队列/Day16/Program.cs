using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
namespace Day16
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = ".\\Private$\\myQueue";
            MessageQueue queue;
            //如果存在指定路径的消息队列 
            if (MessageQueue.Exists(path))
            {
                //获取这个消息队列
                queue = new MessageQueue(path);
            }
            else
            {
                //不存在，就创建一个新的，并获取这个消息队列对象
                queue = MessageQueue.Create(path);
            }
            //  queue.Purge();

            while (true)
            {
                Console.WriteLine("请输入要操作的数字1：发送，2：获取");
                switch (Console.ReadLine())
                {
                    case "1": SendMessage(queue); break;
                    case "2":
                        GetMessage(queue); break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="queue"></param>
        public static void GetMessage(MessageQueue queue)
        {

            //接收到的消息对象
            System.Messaging.Message msg = queue.Receive();
            //指定格式化程序
            msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            //接收到的内容
            string str = msg.Body.ToString();
            Console.WriteLine(str);
            Console.ReadKey();

        }

        /// <summary>
        ///  发送消息
        /// </summary>

        public static void SendMessage(MessageQueue queue)
        {
            Console.WriteLine("请输入要存的数据");
            string str = Console.ReadLine();
            Message msg = new Message();
            //内容
            msg.Body = str;
            //指定格式化程序
            msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            queue.Send(msg);

        }

    }
}
